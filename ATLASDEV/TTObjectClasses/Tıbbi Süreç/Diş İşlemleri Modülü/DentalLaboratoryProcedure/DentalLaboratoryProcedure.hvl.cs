
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalLaboratoryProcedure")] 

    /// <summary>
    /// Diş Laboratuar Kontrol
    /// </summary>
    public  partial class DentalLaboratoryProcedure : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class DentalLaboratoryProcedureList : TTObjectCollection<DentalLaboratoryProcedure> { }
                    
        public class ChildDentalLaboratoryProcedureCollection : TTObject.TTChildObjectCollection<DentalLaboratoryProcedure>
        {
            public ChildDentalLaboratoryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalLaboratoryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("ddb24399-916f-4b31-88fd-e62530b409f6"); } }
            public static Guid Completed { get { return new Guid("a4c5963b-e430-45ba-a88f-459e6fef4fc9"); } }
            public static Guid Cancelled { get { return new Guid("a42b5e1f-31e3-45b6-a458-408fd8df92a0"); } }
        }

    /// <summary>
    /// Protez Ölçüsü
    /// </summary>
        public string ProsthesisMeasurement
        {
            get { return (string)this["PROSTHESISMEASUREMENT"]; }
            set { this["PROSTHESISMEASUREMENT"] = value; }
        }

    /// <summary>
    /// Teknisyene İşlem  Açıklaması
    /// </summary>
        public string DefinitionToTechnician
        {
            get { return (string)this["DEFINITIONTOTECHNICIAN"]; }
            set { this["DEFINITIONTOTECHNICIAN"] = value; }
        }

    /// <summary>
    /// Dış Labaratuar Adı
    /// </summary>
        public string OuterLabName
        {
            get { return (string)this["OUTERLABNAME"]; }
            set { this["OUTERLABNAME"] = value; }
        }

        public Technician Technician
        {
            get { return (Technician)((ITTObject)this).GetParent("TECHNICIAN"); }
            set { this["TECHNICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Teknisyen İşlemleri Birimi
    /// </summary>
        public ResSection TechnicalDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("TECHNICALDEPARTMENT"); }
            set { this["TECHNICALDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Protez Birimi
    /// </summary>
        public ResSection ProcedureDepartment
        {
            get { return (ResSection)((ITTObject)this).GetParent("PROCEDUREDEPARTMENT"); }
            set { this["PROCEDUREDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalExamination DentalExamination
        {
            get { return (DentalExamination)((ITTObject)this).GetParent("DENTALEXAMINATION"); }
            set { this["DENTALEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSuggestedProsthesisCollection()
        {
            _SuggestedProsthesis = new DentalExaminationSuggestedProsthesis.ChildDentalExaminationSuggestedProsthesisCollection(this, new Guid("66a200a7-0b7a-4d2e-873b-48cf83d2d64b"));
            ((ITTChildObjectCollection)_SuggestedProsthesis).GetChildren();
        }

        protected DentalExaminationSuggestedProsthesis.ChildDentalExaminationSuggestedProsthesisCollection _SuggestedProsthesis = null;
    /// <summary>
    /// Child collection for Önerilen Lab Diş Protez
    /// </summary>
        public DentalExaminationSuggestedProsthesis.ChildDentalExaminationSuggestedProsthesisCollection SuggestedProsthesis
        {
            get
            {
                if (_SuggestedProsthesis == null)
                    CreateSuggestedProsthesisCollection();
                return _SuggestedProsthesis;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _DentalLaboratoryProcedureProthesises = new DentalLaboratoryProcedureProthesis.ChildDentalLaboratoryProcedureProthesisCollection(_SubactionProcedures, "DentalLaboratoryProcedureProthesises");
        }

        private DentalLaboratoryProcedureProthesis.ChildDentalLaboratoryProcedureProthesisCollection _DentalLaboratoryProcedureProthesises = null;
        public DentalLaboratoryProcedureProthesis.ChildDentalLaboratoryProcedureProthesisCollection DentalLaboratoryProcedureProthesises
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _DentalLaboratoryProcedureProthesises;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _DentalProsthesisMaterials = new DentalProsthesisMaterial.ChildDentalProsthesisMaterialCollection(_TreatmentMaterials, "DentalProsthesisMaterials");
        }

        private DentalProsthesisMaterial.ChildDentalProsthesisMaterialCollection _DentalProsthesisMaterials = null;
        public DentalProsthesisMaterial.ChildDentalProsthesisMaterialCollection DentalProsthesisMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _DentalProsthesisMaterials;
            }            
        }

        protected DentalLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalLaboratoryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalLaboratoryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALLABORATORYPROCEDURE", dataRow) { }
        protected DentalLaboratoryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALLABORATORYPROCEDURE", dataRow, isImported) { }
        public DentalLaboratoryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalLaboratoryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalLaboratoryProcedure() : base() { }

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