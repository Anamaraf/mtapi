using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECFramework.Algorithm;
using ECFramework.Alpha;
using ECFramework.Data;

namespace ECFramework.Interfaces
{
    public interface IAlphaModel
    {
        /// <summary>
        /// Defines a name for an alpha model
        /// </summary>
        string Name { get; }

        ulong MagicNumber { get; }

        /// <summary>
        /// Updates this alpha model with the latest data from the algorithm.
        /// This is called each time the algorithm receives data for subscribed securities
        /// </summary>
        /// <param name="algorithm">The algorithm instance</param>
        /// <param name="data">The new data available</param>
        /// <returns>The new insights generated</returns>
        IEnumerable<Insight> Update(ECAlgorithm algorithm, Slice data);


    }
}
