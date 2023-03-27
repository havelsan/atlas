
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FTRReport")] 

    /// <summary>
    /// FTR Raporu
    /// </summary>
    public  partial class FTRReport : TTObject
    {
        public class FTRReportList : TTObjectCollection<FTRReport> { }
                    
        public class ChildFTRReportCollection : TTObject.TTChildObjectCollection<FTRReport>
        {
            public ChildFTRReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFTRReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Özel Durum
    /// </summary>
        public MedulaRaporOzelDurumEnum? SpacialCase
        {
            get { return (MedulaRaporOzelDurumEnum?)(int?)this["SPACIALCASE"]; }
            set { this["SPACIALCASE"] = value; }
        }

    /// <summary>
    /// Trafik Kazası
    /// </summary>
        public bool? IsTrafficAccident
        {
            get { return (bool?)this["ISTRAFFICACCIDENT"]; }
            set { this["ISTRAFFICACCIDENT"] = value; }
        }

        virtual protected void CreateFTRReportDetailGridCollection()
        {
            _FTRReportDetailGrid = new FTRReportDetailGrid.ChildFTRReportDetailGridCollection(this, new Guid("7aeb83c1-7d2d-4f7b-9e8c-2020a10c850b"));
            ((ITTChildObjectCollection)_FTRReportDetailGrid).GetChildren();
        }

        protected FTRReportDetailGrid.ChildFTRReportDetailGridCollection _FTRReportDetailGrid = null;
        public FTRReportDetailGrid.ChildFTRReportDetailGridCollection FTRReportDetailGrid
        {
            get
            {
                if (_FTRReportDetailGrid == null)
                    CreateFTRReportDetailGridCollection();
                return _FTRReportDetailGrid;
            }
        }

        protected FTRReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FTRReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FTRReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FTRReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FTRReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FTRREPORT", dataRow) { }
        protected FTRReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FTRREPORT", dataRow, isImported) { }
        public FTRReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FTRReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FTRReport() : base() { }

    }
}