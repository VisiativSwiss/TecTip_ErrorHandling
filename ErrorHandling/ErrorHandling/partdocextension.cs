using SolidWorks.Interop.sldworks;
using System;

namespace ErrorHandling
{
    public static class partdocextension
    {
        public static void AddFeatureXYZ(this PartDoc partDoc)
        {
            throw new Exception("Here is my Error");
        }
    }
}
