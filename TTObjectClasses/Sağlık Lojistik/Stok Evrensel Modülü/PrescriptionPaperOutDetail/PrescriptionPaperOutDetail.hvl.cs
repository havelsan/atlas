
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionPaperOutDetail")] 

    public  partial class PrescriptionPaperOutDetail : PrescriptionPaperDetail
    {
        public class PrescriptionPaperOutDetailList : TTObjectCollection<PrescriptionPaperOutDetail> { }
                    
        public class ChildPrescriptionPaperOutDetailCollection : TTObject.TTChildObjectCollection<PrescriptionPaperOutDetail>
        {
            public ChildPrescriptionPaperOutDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionPaperOutDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PrescriptionPaper PrescriptionPaper
        {
            get { return (PrescriptionPaper)((ITTObject)this).GetParent("PRESCRIPTIONPAPER"); }
            set { this["PRESCRIPTIONPAPER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockActionDetailOut StockActionDetailOut
        {
            get 
            {   
                if (StockActionDetail is StockActionDetailOut)
                    return (StockActionDetailOut)StockActionDetail; 
                return null;
            }            
            set { StockActionDetail = value; }
        }

        protected PrescriptionPaperOutDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionPaperOutDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionPaperOutDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionPaperOutDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionPaperOutDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONPAPEROUTDETAIL", dataRow) { }
        protected PrescriptionPaperOutDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONPAPEROUTDETAIL", dataRow, isImported) { }
        public PrescriptionPaperOutDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionPaperOutDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionPaperOutDetail() : base() { }

    }
}