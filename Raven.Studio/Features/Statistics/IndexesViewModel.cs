﻿namespace Raven.Studio.Features.Statistics
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Caliburn.Micro;
    using Database;
    using Messages;
    using Raven.Database.Data;

    [Export]
    public class IndexesViewModel : Screen, IHandle<StatisticsUpdated>
    {
        private Style defaultStyle;
        private Style staleStyle;

        [ImportingConstructor]
        public IndexesViewModel(IServer server, IEventAggregator events)
        {
            DisplayName = "Indexes";

            server.CurrentDatabaseChanged += delegate
            {
                Indexes = new List<dynamic>();
                NotifyOfPropertyChange(() => Indexes);
                events.Publish(new StatisticsUpdateRequested());
            };

            events.Subscribe(this);
            events.Publish(new StatisticsUpdateRequested());

            defaultStyle = new Style { TargetType = typeof(TextBlock) };
            staleStyle = new Style { TargetType = typeof(TextBlock) };
            staleStyle.Setters.Add(new Setter(TextBlock.ForegroundProperty, new SolidColorBrush(new Color { A = 0xff, R = 0xff, G = 0x00, B = 0x00 })));
        }

        public IEnumerable<dynamic> Indexes { get; private set; }

        #region IHandle<StatisticsUpdated> Members

        public void Handle(StatisticsUpdated message)
        {
            var stats = message.Statistics;
            var proxies = from index in stats.Indexes
                          let proxy = (dynamic) new DynamicViewModel<IndexStats>(index)
                          let stale = (proxy.State = stats.StaleIndexes.Contains(index.Name) ? "Stale" : string.Empty)
                          let style = (proxy.NameStyle = stats.StaleIndexes.Contains(index.Name) ? staleStyle : defaultStyle)
                          select proxy;

            Indexes = proxies.ToList();

            NotifyOfPropertyChange(() => Indexes);
        }

        #endregion
    }
}