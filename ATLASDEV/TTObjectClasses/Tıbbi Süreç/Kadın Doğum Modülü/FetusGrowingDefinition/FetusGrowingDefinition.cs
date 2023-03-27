
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public partial class FetusGrowingDefinition : TTDefinitionSet
    {
        public partial class FetusGrowingDefinitionNQL_Class : TTReportNqlObject
        {
        }

        public class FetusGrowing
        {
            public int? AbdominalCircumference { get; set; }
            public int? BiparietalDiameter { get; set; }
            public int? FemurLength { get; set; }
            public int? HeadCircumference { get; set; }
            public int? Length { get; set; }
            public double? Weight { get; set; }
        }

        public static FetusGrowingDefinition GetFetusGrowingByPregnancyWeek(TTObjectContext context,int pregnancyWeek)
        {
            BindingList<FetusGrowingDefinition> fetusGrowingDefinitionList = FetusGrowingDefinition.GetFetusGrowingByWeekNQL(context, pregnancyWeek, "");

            FetusGrowingDefinition fetusGrowing = new FetusGrowingDefinition();

            fetusGrowing.AbdominalCircumference = fetusGrowingDefinitionList.FirstOrDefault().AbdominalCircumference;
            fetusGrowing.BiparietalDiameter = fetusGrowingDefinitionList.FirstOrDefault().BiparietalDiameter;
            fetusGrowing.FemurLength = fetusGrowingDefinitionList.FirstOrDefault().FemurLength;
            fetusGrowing.HeadCircumference = fetusGrowingDefinitionList.FirstOrDefault().HeadCircumference;
            fetusGrowing.Length = fetusGrowingDefinitionList.FirstOrDefault().Length;
            fetusGrowing.Weight = fetusGrowingDefinitionList.FirstOrDefault().Weight;

            return fetusGrowing;
        }

    }
}