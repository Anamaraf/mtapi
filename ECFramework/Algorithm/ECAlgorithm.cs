using ECFramework.Interfaces;
using System.Collections.Concurrent;

namespace ECFramework.Algorithm
{
    public abstract class ECAlgorithm : IAlgorithm
    {
        /// <summary>
        /// Data subscription manager controls the information and subscriptions the algorithms recieves.
        /// Subscription configurations can be added through the Subscription Manager.
        /// </summary>
        //SubscriptionManager SubscriptionManager { get;}

        /// <summary>
        /// Security object collection class stores an array of objects representing representing each security/asset
        /// we have a subscription for.
        /// </summary>
        /// <remarks>It is an IDictionary implementation and can be indexed by symbol</remarks>
        //SecurityManager Securities { get; }

        /// <summary>
        /// Gets the collection of universes for the algorithm
        /// </summary>
        //UniverseManager UniverseManager { get; }

        /// <summary>
        /// Security portfolio management class provides wrapper and helper methods for the Security.Holdings class such as
        /// IsLong, IsShort, TotalProfit
        /// </summary>
        /// <remarks>Portfolio is a wrapper and helper class encapsulating the Securities[].Holdings objects</remarks>
        ///SecurityPortfolioManager Portfolio { get; }

        /// <summary>
        /// Security transaction manager class controls the store and processing of orders.
        /// </summary>
        /// <remarks>The orders and their associated events are accessible here. When a new OrderEvent is recieved the algorithm portfolio is updated.</remarks>
        ///SecurityTransactionManager Transactions { get; }

        /// <summary>
        /// Gets the brokerage model used to emulate a real brokerage
        /// </summary>
        //IBrokerageModel BrokerageModel { get; }

        /// <summary>
        /// Notification manager for storing and processing live event messages
        /// </summary>
        //NotificationManager Notify { get; }

        /// <summary>
        /// Gets schedule manager for adding/removing scheduled events
        /// </summary>
        //ScheduleManager Schedule { get; }

        /// <summary>
        /// AlgorithmId for the backtest
        /// </summary>
        string AlgorithmId { get; }

        /// <summary>
        /// A list of tags associated with the algorithm or the backtest, useful for categorization
        /// </summary>
        HashSet<string> Tags
        {
            get;
            set;
        }

        /// <summary>
        /// Algorithm is running on a live server.
        /// </summary>
        bool LiveMode
        {
            get;
        }

        /// <summary>
        /// Gets the run time error from the algorithm, or null if none was encountered.
        /// </summary>
        Exception RunTimeError
        {
            get;
            set;
        }

        /// <summary>
        /// The current algorithm statistics for the running algorithm.
        /// </summary>
        //StatisticsResults Statistics
        //{
        //    get;
        //}

        /// <summary>
        /// Gets an instance that is to be used to initialize newly created securities.
        /// </summary>
        //ISecurityInitializer SecurityInitializer
        //{
        //    get;
        //}

        /// <summary>
        /// Gets the account currency
        /// </summary>
        string AccountCurrency { get; }

        public abstract void Initialize();

    }
}
