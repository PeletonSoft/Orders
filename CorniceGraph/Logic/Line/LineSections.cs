using System;
using CorniceGraph.Datasets;

namespace CorniceGraph.Logic.Line
{
    public class LineSections
    {
        public static Section SectionByID(dsLines dsLines, int ID)
        {
            dsLines.tbLineSectionsRow rw = dsLines.tbLineSections.FindByКод(ID);
            if (rw == null)
                return null;
            if (rw.Длина < 0.001)
                return new JunctSection(dsLines, ID);
            if (Math.Abs(rw.Угол) < 0.01)
                return new LineSection(dsLines, ID);
            return new ArcSection(dsLines, ID);
        }
    }
}