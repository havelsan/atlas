
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HomeHemodialysisReport")] 

    /// <summary>
    /// Ev Hemodiyaliz Raporu
    /// </summary>
    public  partial class HomeHemodialysisReport : TTObject
    {
        public class HomeHemodialysisReportList : TTObjectCollection<HomeHemodialysisReport> { }
                    
        public class ChildHomeHemodialysisReportCollection : TTObject.TTChildObjectCollection<HomeHemodialysisReport>
        {
            public ChildHomeHemodialysisReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHomeHemodialysisReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? NumberOfSessions
        {
            get { return (int?)this["NUMBEROFSESSIONS"]; }
            set { this["NUMBEROFSESSIONS"] = value; }
        }

    /// <summary>
    /// Tedavi Süresi
    /// </summary>
        public int? TreatmenDuration
        {
            get { return (int?)this["TREATMENDURATION"]; }
            set { this["TREATMENDURATION"] = value; }
        }

    /// <summary>
    /// Diyaliz Seans Gün
    /// </summary>
        public DiyalizSeansGunEnum? DialysisSessionsDay
        {
            get { return (DiyalizSeansGunEnum?)(int?)this["DIALYSISSESSIONSDAY"]; }
            set { this["DIALYSISSESSIONSDAY"] = value; }
        }

        public TedaviRaporiIslemKodlari TedaviRaporiIslemKodlari
        {
            get { return (TedaviRaporiIslemKodlari)((ITTObject)this).GetParent("TEDAVIRAPORIISLEMKODLARI"); }
            set { this["TEDAVIRAPORIISLEMKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HomeHemodialysisReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HomeHemodialysisReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HomeHemodialysisReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HomeHemodialysisReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HomeHemodialysisReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOMEHEMODIALYSISREPORT", dataRow) { }
        protected HomeHemodialysisReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOMEHEMODIALYSISREPORT", dataRow, isImported) { }
        public HomeHemodialysisReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HomeHemodialysisReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HomeHemodialysisReport() : base() { }

    }
}