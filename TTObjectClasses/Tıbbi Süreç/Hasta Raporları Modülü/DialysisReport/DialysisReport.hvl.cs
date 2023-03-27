
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisReport")] 

    /// <summary>
    /// Diyaliz Raporu
    /// </summary>
    public  partial class DialysisReport : TTObject
    {
        public class DialysisReportList : TTObjectCollection<DialysisReport> { }
                    
        public class ChildDialysisReportCollection : TTObject.TTChildObjectCollection<DialysisReport>
        {
            public ChildDialysisReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Diyaliz Seans Gün
    /// </summary>
        public DiyalizSeansGunEnum? DialysisSessionsDay
        {
            get { return (DiyalizSeansGunEnum?)(int?)this["DIALYSISSESSIONSDAY"]; }
            set { this["DIALYSISSESSIONSDAY"] = value; }
        }

    /// <summary>
    /// Refakatçi Var
    /// </summary>
        public bool? IsCompanion
        {
            get { return (bool?)this["ISCOMPANION"]; }
            set { this["ISCOMPANION"] = value; }
        }

        public TedaviRaporiIslemKodlari TedaviRaporiIslemKodlari
        {
            get { return (TedaviRaporiIslemKodlari)((ITTObject)this).GetParent("TEDAVIRAPORIISLEMKODLARI"); }
            set { this["TEDAVIRAPORIISLEMKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DialysisReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISREPORT", dataRow) { }
        protected DialysisReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISREPORT", dataRow, isImported) { }
        public DialysisReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisReport() : base() { }

    }
}