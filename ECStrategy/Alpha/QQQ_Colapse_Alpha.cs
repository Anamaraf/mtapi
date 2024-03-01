using ECFramework.Algorithm;
using ECFramework.Alpha;
using ECFramework.Data;

namespace ECStrategy.Alpha
{
    public class QQQ_Colapse_Alpha : AlphaModel
    {
        public QQQ_Colapse_Alpha(
            ulong magicNumber,
            string symbolToAnalyze,
            string symbolToTrade = "")
        {
            Name = "QQQ_Collapse_Alpha";
            MagicNumber = magicNumber;
        }
                
        public override IEnumerable<Insight> Update(ECAlgorithm algorithm, Slice data)
        {
            throw new NotImplementedException();
        }

    }
}
