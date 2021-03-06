﻿#if !NET_3_5
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Raven.Abstractions.Data;
using Raven.Client.Client;
using Raven.Client.Client.Async;

namespace Raven.Client.Document
{
    /// <summary>
    /// A query against a Raven index
    /// </summary>
    public class AsyncDocumentQuery<T> : AbstractDocumentQuery<T, AsyncDocumentQuery<T>>, IAsyncDocumentQuery<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentQuery&lt;T&gt;"/> class.
        /// </summary>
        public AsyncDocumentQuery(InMemoryDocumentSessionOperations session,
#if !SILVERLIGHT
            IDatabaseCommands databaseCommands,
#endif
            IAsyncDatabaseCommands asyncDatabaseCommands, string indexName, string[] projectionFields, IDocumentQueryListener[] queryListeners)
            : base(session, 
#if !SILVERLIGHT
            databaseCommands, 
#endif
            asyncDatabaseCommands, indexName, projectionFields, queryListeners)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentQuery&lt;T&gt;"/> class.
        /// </summary>
        public AsyncDocumentQuery(AsyncDocumentQuery<T> other)
            : base(other)
        {
        }

        /// <summary>
        /// Includes the specified path in the query, loading the document specified in that path
        /// </summary>
        /// <param name="path">The path.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Include(string path)
        {
            Include(path);
            return this;
        }

        /// <summary>
        /// Includes the specified path in the query, loading the document specified in that path
        /// </summary>
        /// <param name="path">The path.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Include(Expression<Func<T, object>> path)
        {
            Include(path);
            return this;
        }

        /// <summary>
        /// Negate the next operation
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Not
        {
            get
            {
                NegateNext();
                return this;
            }
        }

        /// <summary>
        /// Takes the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Take(int count)
        {
            Take(count);
            return this;
        }

        /// <summary>
        /// Skips the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Skip(int count)
        {
            Skip(count);
            return this;
        }

        /// <summary>
        /// Filter the results from the index using the specified where clause.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Where(string whereClause)
        {
            Where(whereClause);
            return this;
        }

        /// <summary>
        /// 	Matches exact value
        /// </summary>
        /// <remarks>
        /// 	Defaults to NotAnalyzed
        /// </remarks>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereEquals(string fieldName, object value)
        {
            WhereEquals(fieldName, value);
            return this;
        }

        /// <summary>
        /// 	Matches exact value
        /// </summary>
        /// <remarks>
        /// 	Defaults to allow wildcards only if analyzed
        /// </remarks>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereEquals(string fieldName, object value, bool isAnalyzed)
        {
            WhereEquals(fieldName, value, isAnalyzed);
            return this;
        }

        /// <summary>
        /// 	Matches exact value
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereEquals(WhereEqualsParams whereEqualsParams)
        {
            WhereEquals(whereEqualsParams);
            return this;
        }

        /// <summary>
        /// 	Matches substrings of the field
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereContains(string fieldName, object value)
        {
            WhereContains(fieldName, value);
            return this;
        }

		/// <summary>
		/// 	Matches substrings of the field
		/// </summary>
		IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereContains(string fieldName, params object [] values)
		{
			WhereContains(fieldName, values);
			return this;
		}

		/// <summary>
		/// 	Matches substrings of the field
		/// </summary>
		IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereContains(string fieldName, IEnumerable<object> values)
		{
			WhereContains(fieldName, values);
			return this;
		}

        /// <summary>
        /// Matches fields which starts with the specified value.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereStartsWith(string fieldName, object value)
        {
            WhereStartsWith(fieldName, value);
            return this;
        }

        /// <summary>
        /// Matches fields which ends with the specified value.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereEndsWith(string fieldName, object value)
        {
            WhereEndsWith(fieldName, value);
            return this;
        }

        /// <summary>
        /// Matches fields where the value is between the specified start and end, exclusive
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereBetween(string fieldName, object start, object end)
        {
            WhereBetween(fieldName, start, end);
            return this;
        }

        /// <summary>
        /// Matches fields where the value is between the specified start and end, inclusive
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereBetweenOrEqual(string fieldName, object start, object end)
        {
            WhereBetweenOrEqual(fieldName, start, end);
            return this;
        }

        /// <summary>
        /// Matches fields where the value is greater than the specified value
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereGreaterThan(string fieldName, object value)
        {
            WhereGreaterThan(fieldName, value);
            return this;
        }

        /// <summary>
        /// Matches fields where the value is greater than or equal to the specified value
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereGreaterThanOrEqual(string fieldName, object value)
        {
            WhereGreaterThanOrEqual(fieldName, value);
            return this;
        }

        /// <summary>
        /// Matches fields where the value is less than the specified value
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereLessThan(string fieldName, object value)
        {
            WhereLessThan(fieldName, value);
            return this;
        }

        /// <summary>
        /// Matches fields where the value is less than or equal to the specified value
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WhereLessThanOrEqual(string fieldName, object value)
        {
            WhereLessThanOrEqual(fieldName, value);
            return this;
        }

        /// <summary>
        /// Add an AND to the query
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.AndAlso()
        {
            AndAlso();
            return this;
        }

        /// <summary>
        /// Add an OR to the query
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.OrElse()
        {
            OrElse();
            return this;
        }

        /// <summary>
        /// Specifies a boost weight to the last where clause.
        /// The higher the boost factor, the more relevant the term will be.
        /// </summary>
        /// <param name="boost">boosting factor where 1.0 is default, less than 1.0 is lower weight, greater than 1.0 is higher weight</param>
        /// <returns></returns>
        /// <remarks>
        /// http://lucene.apache.org/java/2_4_0/queryparsersyntax.html#Boosting%20a%20Term
        /// </remarks>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Boost(decimal boost)
        {
            Boost(boost);
            return this;
        }

        /// <summary>
        /// Specifies a fuzziness factor to the single word term in the last where clause
        /// </summary>
        /// <param name="fuzzy">0.0 to 1.0 where 1.0 means closer match</param>
        /// <returns></returns>
        /// <remarks>
        /// http://lucene.apache.org/java/2_4_0/queryparsersyntax.html#Fuzzy%20Searches
        /// </remarks>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Fuzzy(decimal fuzzy)
        {
            Fuzzy(fuzzy);
            return this;
        }

        /// <summary>
        /// Specifies a proximity distance for the phrase in the last where clause
        /// </summary>
        /// <param name="proximity">number of words within</param>
        /// <returns></returns>
        /// <remarks>
        /// http://lucene.apache.org/java/2_4_0/queryparsersyntax.html#Proximity%20Searches
        /// </remarks>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.Proximity(int proximity)
        {
            Proximity(proximity);
            return this;
        }

        /// <summary>
        /// Filter matches to be inside the specified radius
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WithinRadiusOf(double radius, double latitude, double longitude)
        {
            return (IAsyncDocumentQuery<T>)GenerateQueryWithinRadiusOf(radius, latitude, longitude);
        }

        /// <summary>
        /// Sorts the query results by distance.
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.SortByDistance()
        {
            return new AsyncSpatialDocumentQuery<T>(this, true);
        }

        /// <summary>
        /// Order the results by the specified fields
        /// </summary>
        /// <remarks>
        /// The fields are the names of the fields to sort, defaulting to sorting by ascending.
        /// You can prefix a field name with '-' to indicate sorting by descending or '+' to sort by ascending
        /// </remarks>
        /// <param name="fields">The fields.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.OrderBy(params string[] fields)
        {
            OrderBy(fields);
            return this;
        }

        /// <summary>
        /// Instructs the query to wait for non stale results as of now.
        /// </summary>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WaitForNonStaleResultsAsOfNow()
        {
            WaitForNonStaleResultsAsOfNow();
            return this;
        }

        /// <summary>
        /// Instructs the query to wait for non stale results as of now for the specified timeout.
        /// </summary>
        /// <param name="waitTimeout">The wait timeout.</param>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WaitForNonStaleResultsAsOfNow(TimeSpan waitTimeout)
        {
            WaitForNonStaleResultsAsOfNow(waitTimeout);
            return this;
        }

        /// <summary>
        /// Instructs the query to wait for non stale results as of the cutoff date.
        /// </summary>
        /// <param name="cutOff">The cut off.</param>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WaitForNonStaleResultsAsOf(DateTime cutOff)
        {
            WaitForNonStaleResultsAsOf(cutOff);
            return this;
        }

        /// <summary>
        /// Instructs the query to wait for non stale results as of the cutoff date for the specified timeout
        /// </summary>
        /// <param name="cutOff">The cut off.</param>
        /// <param name="waitTimeout">The wait timeout.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WaitForNonStaleResultsAsOf(DateTime cutOff, TimeSpan waitTimeout)
        {
            WaitForNonStaleResultsAsOf(cutOff, waitTimeout);
            return this;
        }

        /// <summary>
        /// EXPERT ONLY: Instructs the query to wait for non stale results.
        /// This shouldn't be used outside of unit tests unless you are well aware of the implications
        /// </summary>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WaitForNonStaleResults()
        {
            WaitForNonStaleResults();
            return this;
        }

        /// <summary>
        /// EXPERT ONLY: Instructs the query to wait for non stale results for the specified wait timeout.
        /// This shouldn't be used outside of unit tests unless you are well aware of the implications
        /// </summary>
        /// <param name="waitTimeout">The wait timeout.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.WaitForNonStaleResults(TimeSpan waitTimeout)
        {
            WaitForNonStaleResults(waitTimeout);
            return this;
        }


        /// <summary>
        /// Selects the specified fields directly from the index
        /// </summary>
        /// <typeparam name="TProjection">The type of the projection.</typeparam>
        /// <param name="fields">The fields.</param>
        public IAsyncDocumentQuery<TProjection> SelectFields<TProjection>(params string[] fields)
        {
            return new AsyncDocumentQuery<TProjection>(theSession,
#if !SILVERLIGHT
 theDatabaseCommands,
#endif
#if !NET_3_5
 theAsyncDatabaseCommands,
#endif
 indexName, fields, queryListeners)
            {
                pageSize = pageSize,
                theQueryText = new StringBuilder(theQueryText.ToString()),
                start = start,
                timeout = timeout,
                cutoff = cutoff,
                theWaitForNonStaleResults = theWaitForNonStaleResults,
                sortByHints = sortByHints,
                orderByFields = orderByFields,
                groupByFields = groupByFields,
                aggregationOp = aggregationOp
            }; 
        }

        /// <summary>
        /// Selects the specified fields directly from the index
        /// </summary>
        /// <typeparam name="TProjection">The type of the projection.</typeparam>
        /// <param name="fields">The fields.</param>
        protected override IDocumentQueryCustomization CreateQueryForSelectedFields<TProjection>(string[] fields)
        {
            return (IDocumentQueryCustomization)SelectFields<TProjection>(fields);
        }

        /// <summary>
        /// Adds an ordering for a specific field to the query
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="descending">if set to <c>true</c> [descending].</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.AddOrder(string fieldName, bool descending)
        {
            AddOrder(fieldName, descending);
            return this;
        }

        /// <summary>
        /// Adds an ordering for a specific field to the query and specifies the type of field for sorting purposes
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="descending">if set to <c>true</c> [descending].</param>
        /// <param name="fieldType">the type of the field to be sorted.</param>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.AddOrder(string fieldName, bool descending, Type fieldType)
        {
            AddOrder(fieldName, descending, fieldType);
            return this;
        }

        /// <summary>
        /// Simplified method for opening a new clause within the query
        /// </summary>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.OpenSubclause()
        {
            OpenSubclause();
            return this;
        }

        /// <summary>
        /// Simplified method for closing a clause within the query
        /// </summary>
        /// <returns></returns>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.CloseSubclause()
        {
            CloseSubclause();
            return this;
        }

        ///<summary>
        /// Instruct the index to group by the specified fields using the specified aggregation operation
        ///</summary>
        /// <remarks>
        /// This is only valid on dynamic indexes queries
        /// </remarks>
        IAsyncDocumentQuery<T> IDocumentQueryBase<T, IAsyncDocumentQuery<T>>.GroupBy(AggregationOperation aggregationOperation, params string[] fieldsToGroupBy)
        {
            GroupBy(aggregationOperation, fieldsToGroupBy);
            return this;
        }

        /// <summary>
        /// Filter matches to be inside the specified radius
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        protected override object GenerateQueryWithinRadiusOf(double radius, double latitude, double longitude)
        {
            var spatialDocumentQuery = new AsyncSpatialDocumentQuery<T>(this, radius, latitude, longitude);
            if (negate)
            {
                negate = false;
                spatialDocumentQuery.NegateNext();
            }
            return spatialDocumentQuery;
        }

    }
}
#endif