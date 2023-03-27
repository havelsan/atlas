
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockPrescriptionDetail")] 

    public  partial class StockPrescriptionDetail : TTObject
    {
        public class StockPrescriptionDetailList : TTObjectCollection<StockPrescriptionDetail> { }
                    
        public class ChildStockPrescriptionDetailCollection : TTObject.TTChildObjectCollection<StockPrescriptionDetail>
        {
            public ChildStockPrescriptionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockPrescriptionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cilt Nu
    /// </summary>
        public string VolumeNo
        {
            get { return (string)this["VOLUMENO"]; }
            set { this["VOLUMENO"] = value; }
        }

    /// <summary>
    /// Seri Nu
    /// </summary>
        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Prescription Prescription
        {
            get { return (Prescription)((ITTObject)this).GetParent("PRESCRIPTION"); }
            set { this["PRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PrescriptionPaper PrescriptionPaper
        {
            get { return (PrescriptionPaper)((ITTObject)this).GetParent("PRESCRIPTIONPAPER"); }
            set { this["PRESCRIPTIONPAPER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockPrescriptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockPrescriptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockPrescriptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockPrescriptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockPrescriptionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKPRESCRIPTIONDETAIL", dataRow) { }
        protected StockPrescriptionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKPRESCRIPTIONDETAIL", dataRow, isImported) { }
        public StockPrescriptionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockPrescriptionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockPrescriptionDetail() : base() { }

    }
}