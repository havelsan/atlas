
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionPaperDetail")] 

    public  partial class PrescriptionPaperDetail : TTObject
    {
        public class PrescriptionPaperDetailList : TTObjectCollection<PrescriptionPaperDetail> { }
                    
        public class ChildPrescriptionPaperDetailCollection : TTObject.TTChildObjectCollection<PrescriptionPaperDetail>
        {
            public ChildPrescriptionPaperDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionPaperDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PrescriptionPaperDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionPaperDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionPaperDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionPaperDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionPaperDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONPAPERDETAIL", dataRow) { }
        protected PrescriptionPaperDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONPAPERDETAIL", dataRow, isImported) { }
        public PrescriptionPaperDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionPaperDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionPaperDetail() : base() { }

    }
}