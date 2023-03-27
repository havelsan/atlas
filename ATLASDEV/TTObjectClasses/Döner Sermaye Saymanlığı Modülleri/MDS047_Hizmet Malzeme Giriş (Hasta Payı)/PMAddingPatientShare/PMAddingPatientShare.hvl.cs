
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PMAddingPatientShare")] 

    /// <summary>
    /// Hizmet Malzeme Giriş (Hasta Payı)
    /// </summary>
    public  partial class PMAddingPatientShare : EpisodeAction
    {
        public class PMAddingPatientShareList : TTObjectCollection<PMAddingPatientShare> { }
                    
        public class ChildPMAddingPatientShareCollection : TTObject.TTChildObjectCollection<PMAddingPatientShare>
        {
            public ChildPMAddingPatientShareCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPMAddingPatientShareCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("7e6c74cc-c456-4972-a872-4a9a304deee9"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("952d1b11-b84d-4830-ac54-a7fd35ab9e1b"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("4dff9166-ecb3-423e-a4f7-0ec1ccab5517"); } }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PMAddingPSProcedures = new PMAddingPSProcedure.ChildPMAddingPSProcedureCollection(_SubactionProcedures, "PMAddingPSProcedures");
        }

        private PMAddingPSProcedure.ChildPMAddingPSProcedureCollection _PMAddingPSProcedures = null;
        public PMAddingPSProcedure.ChildPMAddingPSProcedureCollection PMAddingPSProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PMAddingPSProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PMAddingPSMaterials = new PMAddingPSMaterial.ChildPMAddingPSMaterialCollection(_TreatmentMaterials, "PMAddingPSMaterials");
        }

        private PMAddingPSMaterial.ChildPMAddingPSMaterialCollection _PMAddingPSMaterials = null;
        public PMAddingPSMaterial.ChildPMAddingPSMaterialCollection PMAddingPSMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PMAddingPSMaterials;
            }            
        }

        protected PMAddingPatientShare(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PMAddingPatientShare(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PMAddingPatientShare(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PMAddingPatientShare(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PMAddingPatientShare(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PMADDINGPATIENTSHARE", dataRow) { }
        protected PMAddingPatientShare(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PMADDINGPATIENTSHARE", dataRow, isImported) { }
        public PMAddingPatientShare(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PMAddingPatientShare(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PMAddingPatientShare() : base() { }

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