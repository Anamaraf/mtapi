using ECFramework.Algorithm;
using ECFramework.Data;
using ECFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECFramework.Alpha
{
    public class AlphaModel : IAlphaModel
    {
        /// <summary>
        /// Defines a name for a framework model
        /// </summary>
        public virtual string Name { get; set; }

        public virtual ulong MagicNumber { get; set; }

        /// <summary>
        /// Initialize new <see cref="AlphaModel"/>
        /// </summary>
        public AlphaModel()
        {
            Name = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Updates this alpha model with the latest data from the algorithm.
        /// This is called each time the algorithm receives data for subscribed securities
        /// </summary>
        /// <param name="algorithm">The algorithm instance</param>
        /// <param name="data">The new data available</param>
        /// <returns>The new insights generated</returns>
        public virtual IEnumerable<Insight> Update(ECAlgorithm algorithm, Slice data)
        {
            throw new System.NotImplementedException("Types deriving from 'AlphaModel' must implement the 'IEnumerable<Insight> Update(QCAlgorithm, Slice) method.");
        }
    }
}
