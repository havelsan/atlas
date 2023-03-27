
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureMaterialAdding")] 

    /// <summary>
    /// Hizmet Malzeme Giriş
    /// </summary>
    public  partial class ProcedureMaterialAdding : EpisodeAction
    {
        public class ProcedureMaterialAddingList : TTObjectCollection<ProcedureMaterialAdding> { }
                    
        public class ChildProcedureMaterialAddingCollection : TTObject.TTChildObjectCollection<ProcedureMaterialAdding>
        {
            public ChildProcedureMaterialAddingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureMaterialAddingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("761e2d83-b950-4d95-a4c8-be799d00ebc9"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("916f2884-aebf-4813-ae99-f8b1df43f78c"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f86ef914-5f54-412f-985b-50c8f93ff673"); } }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? PStartDate
        {
            get { return (DateTime?)this["PSTARTDATE"]; }
            set { this["PSTARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? PEndDate
        {
            get { return (DateTime?)this["PENDDATE"]; }
            set { this["PENDDATE"] = value; }
        }

    /// <summary>
    /// İki Tarih Arası Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PMAddingProcedures = new PMAddingProcedure.ChildPMAddingProcedureCollection(_SubactionProcedures, "PMAddingProcedures");
        }

        private PMAddingProcedure.ChildPMAddingProcedureCollection _PMAddingProcedures = null;
        public PMAddingProcedure.ChildPMAddingProcedureCollection PMAddingProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PMAddingProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PMAddingTreatmentMaterials = new PMAddingTreatmentMaterial.ChildPMAddingTreatmentMaterialCollection(_TreatmentMaterials, "PMAddingTreatmentMaterials");
        }

        private PMAddingTreatmentMaterial.ChildPMAddingTreatmentMaterialCollection _PMAddingTreatmentMaterials = null;
        public PMAddingTreatmentMaterial.ChildPMAddingTreatmentMaterialCollection PMAddingTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PMAddingTreatmentMaterials;
            }            
        }

        protected ProcedureMaterialAdding(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureMaterialAdding(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureMaterialAdding(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureMaterialAdding(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureMaterialAdding(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREMATERIALADDING", dataRow) { }
        protected ProcedureMaterialAdding(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREMATERIALADDING", dataRow, isImported) { }
        public ProcedureMaterialAdding(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureMaterialAdding(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureMaterialAdding() : base() { }

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