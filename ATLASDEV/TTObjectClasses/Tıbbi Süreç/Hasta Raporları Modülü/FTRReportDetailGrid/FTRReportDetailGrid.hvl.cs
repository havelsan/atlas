
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FTRReportDetailGrid")] 

    /// <summary>
    /// FTR Rapor Detayları 
    /// </summary>
    public  partial class FTRReportDetailGrid : TTObject
    {
        public class FTRReportDetailGridList : TTObjectCollection<FTRReportDetailGrid> { }
                    
        public class ChildFTRReportDetailGridCollection : TTObject.TTChildObjectCollection<FTRReportDetailGrid>
        {
            public ChildFTRReportDetailGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFTRReportDetailGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? NumberOfSessions
        {
            get { return (int?)this["NUMBEROFSESSIONS"]; }
            set { this["NUMBEROFSESSIONS"] = value; }
        }

        public FTRReport FTRReport
        {
            get { return (FTRReport)((ITTObject)this).GetParent("FTRREPORT"); }
            set { this["FTRREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviRaporiIslemKodlari TedaviRaporiIslemKodlari
        {
            get { return (TedaviRaporiIslemKodlari)((ITTObject)this).GetParent("TEDAVIRAPORIISLEMKODLARI"); }
            set { this["TEDAVIRAPORIISLEMKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TedaviTuru TedaviTuru
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("TEDAVITURU"); }
            set { this["TEDAVITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FTRVucutBolgesi FTRVucutBolgesi
        {
            get { return (FTRVucutBolgesi)((ITTObject)this).GetParent("FTRVUCUTBOLGESI"); }
            set { this["FTRVUCUTBOLGESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FTRReportDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FTRReportDetailGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FTRReportDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FTRReportDetailGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FTRReportDetailGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FTRREPORTDETAILGRID", dataRow) { }
        protected FTRReportDetailGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FTRREPORTDETAILGRID", dataRow, isImported) { }
        public FTRReportDetailGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FTRReportDetailGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FTRReportDetailGrid() : base() { }

    }
}