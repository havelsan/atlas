
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionInspection")] 

    public  partial class StockActionInspection : TTObject
    {
        public class StockActionInspectionList : TTObjectCollection<StockActionInspection> { }
                    
        public class ChildStockActionInspectionCollection : TTObject.TTChildObjectCollection<StockActionInspection>
        {
            public ChildStockActionInspectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionInspectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public TTSequence ReportNumberSeq
        {
            get { return GetSequence("REPORTNUMBERSEQ"); }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public DateTime? InspectionDate
        {
            get { return (DateTime?)this["INSPECTIONDATE"]; }
            set { this["INSPECTIONDATE"] = value; }
        }

    /// <summary>
    /// Muayene Raporu
    /// </summary>
        public object InspectionReport
        {
            get { return (object)this["INSPECTIONREPORT"]; }
            set { this["INSPECTIONREPORT"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public string ReportNumberNotSeq
        {
            get { return (string)this["REPORTNUMBERNOTSEQ"]; }
            set { this["REPORTNUMBERNOTSEQ"] = value; }
        }

        virtual protected void CreateStockActionInspectionDetailsCollection()
        {
            _StockActionInspectionDetails = new StockActionInspectionDetail.ChildStockActionInspectionDetailCollection(this, new Guid("4f671988-adcb-4472-b6f7-f47239b1e5a7"));
            ((ITTChildObjectCollection)_StockActionInspectionDetails).GetChildren();
        }

        protected StockActionInspectionDetail.ChildStockActionInspectionDetailCollection _StockActionInspectionDetails = null;
        public StockActionInspectionDetail.ChildStockActionInspectionDetailCollection StockActionInspectionDetails
        {
            get
            {
                if (_StockActionInspectionDetails == null)
                    CreateStockActionInspectionDetailsCollection();
                return _StockActionInspectionDetails;
            }
        }

        protected StockActionInspection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionInspection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionInspection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionInspection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionInspection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONINSPECTION", dataRow) { }
        protected StockActionInspection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONINSPECTION", dataRow, isImported) { }
        public StockActionInspection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionInspection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionInspection() : base() { }

    }
}