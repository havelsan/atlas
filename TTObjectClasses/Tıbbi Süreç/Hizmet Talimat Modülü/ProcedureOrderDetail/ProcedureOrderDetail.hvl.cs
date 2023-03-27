
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureOrderDetail")] 

    /// <summary>
    /// Hizmet Talimat/İstek Detayı
    /// </summary>
    public  partial class ProcedureOrderDetail : BaseProcedureOrderDetail, ITreatmentMaterialCollection
    {
        public class ProcedureOrderDetailList : TTObjectCollection<ProcedureOrderDetail> { }
                    
        public class ChildProcedureOrderDetailCollection : TTObject.TTChildObjectCollection<ProcedureOrderDetail>
        {
            public ChildProcedureOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("549d1025-9d1d-418b-8480-31960f0967a8"); } }
    /// <summary>
    /// Uygulama
    /// </summary>
            public static Guid Execution { get { return new Guid("89f645e3-7362-4231-8514-76bce967d3c7"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("ba15e7d0-fd11-427f-b0c2-0a00ad71589f"); } }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
        }

        public ProcedureOrder ProcedureOrder
        {
            get 
            {   
                if (PeriodicOrder is ProcedureOrder)
                    return (ProcedureOrder)PeriodicOrder; 
                return null;
            }            
            set { PeriodicOrder = value; }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _ProcedureOrderTreatmentMaterials = new ProcedureOrderTreatmentMaterial.ChildProcedureOrderTreatmentMaterialCollection(_TreatmentMaterials, "ProcedureOrderTreatmentMaterials");
        }

        private ProcedureOrderTreatmentMaterial.ChildProcedureOrderTreatmentMaterialCollection _ProcedureOrderTreatmentMaterials = null;
        public ProcedureOrderTreatmentMaterial.ChildProcedureOrderTreatmentMaterialCollection ProcedureOrderTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _ProcedureOrderTreatmentMaterials;
            }            
        }

        protected ProcedureOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREORDERDETAIL", dataRow) { }
        protected ProcedureOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREORDERDETAIL", dataRow, isImported) { }
        public ProcedureOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureOrderDetail() : base() { }

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