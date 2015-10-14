namespace CorniceGraph.Logic.Splint
{
    public class SplintSections
    {
        public static SplintContourType ReverseSplintContourType(SplintContourType SplintContourType)
        {
            return (SplintContourType)(-(int)SplintContourType);
        }
    }
}