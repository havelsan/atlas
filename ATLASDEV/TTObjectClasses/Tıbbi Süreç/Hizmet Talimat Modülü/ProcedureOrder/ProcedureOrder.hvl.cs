
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureOrder")] 

    /// <summary>
    /// Hizmet Talimat/İstek
    /// </summary>
    public  partial class ProcedureOrder : BaseProcedureOrder
    {
        public class ProcedureOrderList : TTObjectCollection<ProcedureOrder> { }
                    
        public class ChildProcedureOrderCollection : TTObject.TTChildObjectCollection<ProcedureOrder>
        {
            public ChildProcedureOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ce15208a-a5af-4844-9aae-22de32685c83"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("074c374f-fe90-4c82-a8bd-05cc41ddcd89"); } }
            public static Guid Cancelled { get { return new Guid("f3211c62-b64f-4c05-82f9-bf93f7880c53"); } }
        }

    /// <summary>
    /// Anestezi ve Reanimasyon
    /// </summary>
        public AnesthesiaAndReanimation AnesthesiaAndReanimation
        {
            get { return (AnesthesiaAndReanimation)((ITTObject)this).GetParent("ANESTHESIAANDREANIMATION"); }
            set { this["ANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anestezi Konsültasyonu
    /// </summary>
        public AnesthesiaConsultation AnesthesiaConsultation
        {
            get { return (AnesthesiaConsultation)((ITTObject)this).GetParent("ANESTHESIACONSULTATION"); }
            set { this["ANESTHESIACONSULTATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureOrderDetail ProcedureOrderDetail
        {
            get { return (ProcedureOrderDetail)((ITTObject)this).GetParent("PROCEDUREORDERDETAIL"); }
            set { this["PROCEDUREORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientExamination PatientExamination
        {
            get { return (PatientExamination)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FollowUpExamination FollowUpExamination
        {
            get { return (FollowUpExamination)((ITTObject)this).GetParent("FOLLOWUPEXAMINATION"); }
            set { this["FOLLOWUPEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Consultation Consultation
        {
            get { return (Consultation)((ITTObject)this).GetParent("CONSULTATION"); }
            set { this["CONSULTATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollectionViews()
        {
            base.CreateOrderDetailsCollectionViews();
            _ProcedureOrderDetails = new ProcedureOrderDetail.ChildProcedureOrderDetailCollection(_OrderDetails, "ProcedureOrderDetails");
        }

        private ProcedureOrderDetail.ChildProcedureOrderDetailCollection _ProcedureOrderDetails = null;
        public ProcedureOrderDetail.ChildProcedureOrderDetailCollection ProcedureOrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                    CreateOrderDetailsCollection();
                return _ProcedureOrderDetails;
            }            
        }

        protected ProcedureOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREORDER", dataRow) { }
        protected ProcedureOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREORDER", dataRow, isImported) { }
        public ProcedureOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureOrder() : base() { }

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