using ECFramework.Algorithm;

namespace ECFramework.Alpha
{
    public class Insight
    {
        /// <summary>
        /// Gets the unique identifier for this insight
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets an identifier for the source model that generated this insight.
        /// </summary>
        public string SourceModel { get; set; }

        /// <summary>
        /// Gets the symbol this insight is for
        /// </summary>
        public Symbol Symbol { get; private set; }

        /// <summary>
        /// Gets the predicted direction, down, flat or up
        /// </summary>
        public InsightDirection Direction { get; private set; }

        /// <summary>
        /// Gets the portfolio weight of this insight
        /// </summary>
        public double? Weight { get; private set; }

        /// <summary>
        /// Gets the period over which this insight is expected to come to fruition
        /// </summary>
        public TimeSpan? Period { get; internal set; }

        /// <summary>
        /// The insight's tag containing additional information
        /// </summary>
        public string Tag { get; protected set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Insight"/> class
        /// </summary>
        /// <param name="symbol">The symbol this insight is for</param>
        /// <param name="period">The period over which the prediction will come true</param>
        /// <param name="direction">The predicted direction</param>
        /// <param name="sourceModel">An identifier defining the model that generated this insight</param>
        /// <param name="weight">The portfolio weight of this insight</param>
        /// <param name="tag">The insight's tag containing additional information</param>
        public Insight(Symbol symbol, InsightDirection direction, string sourceModel = "", double? weight = null, TimeSpan? period = null, string tag = "")
        {
            Id = Guid.NewGuid();
            SourceModel = sourceModel;

            Symbol = symbol;
            Direction = direction;
            
            // Optional
            Weight = weight;
            Period = period;
            Tag = tag;
        }
    }
}