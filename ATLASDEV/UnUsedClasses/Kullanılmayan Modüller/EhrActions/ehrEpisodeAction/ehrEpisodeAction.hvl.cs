
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrEpisodeAction")] 

    public  partial class ehrEpisodeAction : BaseEhr, IOldActions, Itest
    {
        public class ehrEpisodeActionList : TTObjectCollection<ehrEpisodeAction> { }
                    
        public class ChildehrEpisodeActionCollection : TTObject.TTChildObjectCollection<ehrEpisodeAction>
        {
            public ChildehrEpisodeActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrEpisodeActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? Emergency
        {
            get { return (bool?)this["EMERGENCY"]; }
            set { this["EMERGENCY"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// İşlemin Yapıldığı Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition ProcedureSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("PROCEDURESPECIALITY"); }
            set { this["PROCEDURESPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ehrEpisodeAction
    /// </summary>
        public ehrEpisode ehrEpisode
        {
            get { return (ehrEpisode)((ITTObject)this).GetParent("EHREPISODE"); }
            set { this["EHREPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrDiagnosisCollection()
        {
            _ehrDiagnosis = new ehrDiagnosis.ChildehrDiagnosisCollection(this, new Guid("5ed00407-5d19-4bd9-813a-8ada751751fc"));
            ((ITTChildObjectCollection)_ehrDiagnosis).GetChildren();
        }

        protected ehrDiagnosis.ChildehrDiagnosisCollection _ehrDiagnosis = null;
    /// <summary>
    /// Child collection for Tanı
    /// </summary>
        public ehrDiagnosis.ChildehrDiagnosisCollection ehrDiagnosis
        {
            get
            {
                if (_ehrDiagnosis == null)
                    CreateehrDiagnosisCollection();
                return _ehrDiagnosis;
            }
        }

        virtual protected void CreateehrSubactionMaterialsCollectionViews()
        {
            _ehrBaseTreatmentMaterials = new ehrBaseTreatmentMaterial.ChildehrBaseTreatmentMaterialCollection(_ehrSubactionMaterials, "ehrBaseTreatmentMaterials");
        }

        virtual protected void CreateehrSubactionMaterialsCollection()
        {
            _ehrSubactionMaterials = new ehrSubactionMaterial.ChildehrSubactionMaterialCollection(this, new Guid("cfa9670b-5949-4f3c-a5fd-7774827db39a"));
            CreateehrSubactionMaterialsCollectionViews();
            ((ITTChildObjectCollection)_ehrSubactionMaterials).GetChildren();
        }

        protected ehrSubactionMaterial.ChildehrSubactionMaterialCollection _ehrSubactionMaterials = null;
    /// <summary>
    /// Child collection for İşlem-Malzemeler
    /// </summary>
        public ehrSubactionMaterial.ChildehrSubactionMaterialCollection ehrSubactionMaterials
        {
            get
            {
                if (_ehrSubactionMaterials == null)
                    CreateehrSubactionMaterialsCollection();
                return _ehrSubactionMaterials;
            }
        }

        private ehrBaseTreatmentMaterial.ChildehrBaseTreatmentMaterialCollection _ehrBaseTreatmentMaterials = null;
    /// <summary>
    /// Malzemeler
    /// </summary>
        public ehrBaseTreatmentMaterial.ChildehrBaseTreatmentMaterialCollection ehrBaseTreatmentMaterials
        {
            get
            {
                if (_ehrSubactionMaterials == null)
                    CreateehrSubactionMaterialsCollection();
                return _ehrBaseTreatmentMaterials;
            }            
        }

        virtual protected void CreateehrSubactProcedureFlowablesCollection()
        {
            _ehrSubactProcedureFlowables = new ehrSubactionFlowable.ChildehrSubactionFlowableCollection(this, new Guid("e0982699-06df-40ee-9060-1dc023e2ba1a"));
            ((ITTChildObjectCollection)_ehrSubactProcedureFlowables).GetChildren();
        }

        protected ehrSubactionFlowable.ChildehrSubactionFlowableCollection _ehrSubactProcedureFlowables = null;
        public ehrSubactionFlowable.ChildehrSubactionFlowableCollection ehrSubactProcedureFlowables
        {
            get
            {
                if (_ehrSubactProcedureFlowables == null)
                    CreateehrSubactProcedureFlowablesCollection();
                return _ehrSubactProcedureFlowables;
            }
        }

        virtual protected void CreateehrBaseNursingOrdersCollection()
        {
            _ehrBaseNursingOrders = new ehrBaseNursingOrder.ChildehrBaseNursingOrderCollection(this, new Guid("282c6fe9-ab8b-44e6-aba4-5118c947120f"));
            ((ITTChildObjectCollection)_ehrBaseNursingOrders).GetChildren();
        }

        protected ehrBaseNursingOrder.ChildehrBaseNursingOrderCollection _ehrBaseNursingOrders = null;
    /// <summary>
    /// Child collection for İstek Yapılan İşlem-Hemşire Talimatları
    /// </summary>
        public ehrBaseNursingOrder.ChildehrBaseNursingOrderCollection ehrBaseNursingOrders
        {
            get
            {
                if (_ehrBaseNursingOrders == null)
                    CreateehrBaseNursingOrdersCollection();
                return _ehrBaseNursingOrders;
            }
        }

        protected ehrEpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrEpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrEpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrEpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrEpisodeAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHREPISODEACTION", dataRow) { }
        protected ehrEpisodeAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHREPISODEACTION", dataRow, isImported) { }
        public ehrEpisodeAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrEpisodeAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrEpisodeAction() : base() { }

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