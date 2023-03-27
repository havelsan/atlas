
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TubeBabyReport")] 

    /// <summary>
    /// Tüp Bebek Raporu
    /// </summary>
    public  partial class TubeBabyReport : TTObject
    {
        public class TubeBabyReportList : TTObjectCollection<TubeBabyReport> { }
                    
        public class ChildTubeBabyReportCollection : TTObject.TTChildObjectCollection<TubeBabyReport>
        {
            public ChildTubeBabyReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTubeBabyReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tüp Bebek Rapor Türü
    /// </summary>
        public TupBebekRaporTuruEnum? TubeBabyReportType
        {
            get { return (TupBebekRaporTuruEnum?)(int?)this["TUBEBABYREPORTTYPE"]; }
            set { this["TUBEBABYREPORTTYPE"] = value; }
        }

        public TedaviRaporiIslemKodlari TedaviRaporiIslemKodlari
        {
            get { return (TedaviRaporiIslemKodlari)((ITTObject)this).GetParent("TEDAVIRAPORIISLEMKODLARI"); }
            set { this["TEDAVIRAPORIISLEMKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TubeBabyReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TubeBabyReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TubeBabyReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TubeBabyReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TubeBabyReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TUBEBABYREPORT", dataRow) { }
        protected TubeBabyReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TUBEBABYREPORT", dataRow, isImported) { }
        public TubeBabyReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TubeBabyReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TubeBabyReport() : base() { }

    }
}