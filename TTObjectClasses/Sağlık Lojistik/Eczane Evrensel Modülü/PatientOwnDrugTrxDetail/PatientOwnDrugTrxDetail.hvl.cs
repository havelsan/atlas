
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOwnDrugTrxDetail")] 

    public  partial class PatientOwnDrugTrxDetail : TTObject
    {
        public class PatientOwnDrugTrxDetailList : TTObjectCollection<PatientOwnDrugTrxDetail> { }
                    
        public class ChildPatientOwnDrugTrxDetailCollection : TTObject.TTChildObjectCollection<PatientOwnDrugTrxDetail>
        {
            public ChildPatientOwnDrugTrxDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOwnDrugTrxDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("cf7d8b70-ad9c-45b7-9481-1377405b3c4f"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e28eef4e-c79f-4d0e-a48e-176bf51ebedb"); } }
        }

        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public DrugOrderDetail DrugOrderDetail
        {
            get { return (DrugOrderDetail)((ITTObject)this).GetParent("DRUGORDERDETAIL"); }
            set { this["DRUGORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientOwnDrugTrx PatientOwnDrugTrx
        {
            get { return (PatientOwnDrugTrx)((ITTObject)this).GetParent("PATIENTOWNDRUGTRX"); }
            set { this["PATIENTOWNDRUGTRX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientOwnDrugTrxDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOwnDrugTrxDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOwnDrugTrxDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOwnDrugTrxDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOwnDrugTrxDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTOWNDRUGTRXDETAIL", dataRow) { }
        protected PatientOwnDrugTrxDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTOWNDRUGTRXDETAIL", dataRow, isImported) { }
        public PatientOwnDrugTrxDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOwnDrugTrxDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOwnDrugTrxDetail() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}