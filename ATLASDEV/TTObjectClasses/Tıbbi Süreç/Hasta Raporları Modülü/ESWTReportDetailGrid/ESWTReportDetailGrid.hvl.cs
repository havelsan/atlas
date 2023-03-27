
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ESWTReportDetailGrid")] 

    /// <summary>
    /// ESWT  Rapor Detayları
    /// </summary>
    public  partial class ESWTReportDetailGrid : TTObject
    {
        public class ESWTReportDetailGridList : TTObjectCollection<ESWTReportDetailGrid> { }
                    
        public class ChildESWTReportDetailGridCollection : TTObject.TTChildObjectCollection<ESWTReportDetailGrid>
        {
            public ChildESWTReportDetailGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildESWTReportDetailGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? NumberOfSessions
        {
            get { return (int?)this["NUMBEROFSESSIONS"]; }
            set { this["NUMBEROFSESSIONS"] = value; }
        }

        public TedaviRaporiIslemKodlari TedaviRaporiIslemKodlari
        {
            get { return (TedaviRaporiIslemKodlari)((ITTObject)this).GetParent("TEDAVIRAPORIISLEMKODLARI"); }
            set { this["TEDAVIRAPORIISLEMKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FTRVucutBolgesi FTRVucutBolgesi
        {
            get { return (FTRVucutBolgesi)((ITTObject)this).GetParent("FTRVUCUTBOLGESI"); }
            set { this["FTRVUCUTBOLGESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ESWTReport ESWTReport
        {
            get { return (ESWTReport)((ITTObject)this).GetParent("ESWTREPORT"); }
            set { this["ESWTREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ESWTReportDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ESWTReportDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ESWTReportDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ESWTReportDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ESWTReportDetailGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESWTREPORTDETAILGRID", dataRow) { }
        protected ESWTReportDetailGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESWTREPORTDETAILGRID", dataRow, isImported) { }
        public ESWTReportDetailGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ESWTReportDetailGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ESWTReportDetailGrid() : base() { }

    }
}