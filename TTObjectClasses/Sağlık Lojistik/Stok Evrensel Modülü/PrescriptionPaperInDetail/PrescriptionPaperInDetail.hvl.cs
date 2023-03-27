
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionPaperInDetail")] 

    public  partial class PrescriptionPaperInDetail : PrescriptionPaperDetail
    {
        public class PrescriptionPaperInDetailList : TTObjectCollection<PrescriptionPaperInDetail> { }
                    
        public class ChildPrescriptionPaperInDetailCollection : TTObject.TTChildObjectCollection<PrescriptionPaperInDetail>
        {
            public ChildPrescriptionPaperInDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionPaperInDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seri Nu
    /// </summary>
        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

    /// <summary>
    /// Cilt Nu
    /// </summary>
        public string VolumeNo
        {
            get { return (string)this["VOLUMENO"]; }
            set { this["VOLUMENO"] = value; }
        }

        public CreatePresDetailAction CreatePresDetailAction
        {
            get { return (CreatePresDetailAction)((ITTObject)this).GetParent("CREATEPRESDETAILACTION"); }
            set { this["CREATEPRESDETAILACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PrescriptionPaper CreatedPrescriptionPaper
        {
            get { return (PrescriptionPaper)((ITTObject)this).GetParent("CREATEDPRESCRIPTIONPAPER"); }
            set { this["CREATEDPRESCRIPTIONPAPER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockActionDetailIn StockActionDetailIn
        {
            get 
            {   
                if (StockActionDetail is StockActionDetailIn)
                    return (StockActionDetailIn)StockActionDetail; 
                return null;
            }            
            set { StockActionDetail = value; }
        }

        protected PrescriptionPaperInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionPaperInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionPaperInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionPaperInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionPaperInDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONPAPERINDETAIL", dataRow) { }
        protected PrescriptionPaperInDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONPAPERINDETAIL", dataRow, isImported) { }
        public PrescriptionPaperInDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionPaperInDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionPaperInDetail() : base() { }

    }
}