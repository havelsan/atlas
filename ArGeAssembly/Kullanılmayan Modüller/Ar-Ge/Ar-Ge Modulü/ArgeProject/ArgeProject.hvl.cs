
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ArgeProject")] 

    /// <summary>
    /// Proje Başvuru Formu
    /// </summary>
    public  partial class ArgeProject : BaseAction, IWorkListBaseAction
    {
        public class ArgeProjectList : TTObjectCollection<ArgeProject> { }
                    
        public class ChildArgeProjectCollection : TTObject.TTChildObjectCollection<ArgeProject>
        {
            public ChildArgeProjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildArgeProjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("1de9bd16-e177-4108-8928-e74865ab5c13"); } }
    /// <summary>
    /// Proje Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("7e86e81f-75ea-462e-9293-2a50da4a7e1b"); } }
    /// <summary>
    /// Bilimsel Kurul Onayı
    /// </summary>
            public static Guid AcademicCommApproval { get { return new Guid("b016c0fa-d6cb-4db6-8da7-03d18af8fe5d"); } }
    /// <summary>
    /// Proje Tamamlandı
    /// </summary>
            public static Guid ProjectCompleted { get { return new Guid("2e055ca3-aa81-4744-b9dc-6ba234e73851"); } }
    /// <summary>
    /// Ön Değerlendirme Kabul
    /// </summary>
            public static Guid PreClaimApealApprove { get { return new Guid("63e9362c-6ad4-45fe-858d-3375c8052934"); } }
    /// <summary>
    /// Danışman Onayı
    /// </summary>
            public static Guid AdvisorApproval { get { return new Guid("2f3fb985-ddb9-40fe-b43f-11669fc279fb"); } }
        }

    /// <summary>
    /// ProjectDuration
    /// </summary>
        public string ProjectDuration
        {
            get { return (string)this["PROJECTDURATION"]; }
            set { this["PROJECTDURATION"] = value; }
        }

    /// <summary>
    /// ProjectName
    /// </summary>
        public string ProjectName
        {
            get { return (string)this["PROJECTNAME"]; }
            set { this["PROJECTNAME"] = value; }
        }

        public string EthicCommisionApproveNo
        {
            get { return (string)this["ETHICCOMMISIONAPPROVENO"]; }
            set { this["ETHICCOMMISIONAPPROVENO"] = value; }
        }

    /// <summary>
    /// ProjectNo
    /// </summary>
        public TTSequence ProjectNo
        {
            get { return GetSequence("PROJECTNO"); }
        }

    /// <summary>
    /// StartDate
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public string Email
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

        public string HomeTel
        {
            get { return (string)this["HOMETEL"]; }
            set { this["HOMETEL"] = value; }
        }

        public string MobilTel
        {
            get { return (string)this["MOBILTEL"]; }
            set { this["MOBILTEL"] = value; }
        }

        public string PersonalCv
        {
            get { return (string)this["PERSONALCV"]; }
            set { this["PERSONALCV"] = value; }
        }

        public DurationType? ProjectDurationType
        {
            get { return (DurationType?)(int?)this["PROJECTDURATIONTYPE"]; }
            set { this["PROJECTDURATIONTYPE"] = value; }
        }

        public string ProjectSummary
        {
            get { return (string)this["PROJECTSUMMARY"]; }
            set { this["PROJECTSUMMARY"] = value; }
        }

        public string ProjectInternationalName
        {
            get { return (string)this["PROJECTINTERNATIONALNAME"]; }
            set { this["PROJECTINTERNATIONALNAME"] = value; }
        }

        public ResUser ProjectOwner
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROJECTOWNER"); }
            set { this["PROJECTOWNER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ProjectSpecies
    /// </summary>
        public ProjectSpeciesDef ProjectSpecies
        {
            get { return (ProjectSpeciesDef)((ITTObject)this).GetParent("PROJECTSPECIES"); }
            set { this["PROJECTSPECIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ProjectType
    /// </summary>
        public ProjectTypeDef ProjectType
        {
            get { return (ProjectTypeDef)((ITTObject)this).GetParent("PROJECTTYPE"); }
            set { this["PROJECTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ProjectRaportor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROJECTRAPORTOR"); }
            set { this["PROJECTRAPORTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResDepartment OwnerDepartment
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("OWNERDEPARTMENT"); }
            set { this["OWNERDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EthicCommisionClaim EthicCommClaim
        {
            get { return (EthicCommisionClaim)((ITTObject)this).GetParent("ETHICCOMMCLAIM"); }
            set { this["ETHICCOMMCLAIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProjectPreAssement PreAssesment
        {
            get { return (ProjectPreAssement)((ITTObject)this).GetParent("PREASSESMENT"); }
            set { this["PREASSESMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AcademicCommClaim AcademicCommClaim
        {
            get { return (AcademicCommClaim)((ITTObject)this).GetParent("ACADEMICCOMMCLAIM"); }
            set { this["ACADEMICCOMMCLAIM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateParticipiantsCollection()
        {
            _Participiants = new Participiants.ChildParticipiantsCollection(this, new Guid("7591d596-8204-480e-a94e-c61edd7cb6a9"));
            ((ITTChildObjectCollection)_Participiants).GetChildren();
        }

        protected Participiants.ChildParticipiantsCollection _Participiants = null;
        public Participiants.ChildParticipiantsCollection Participiants
        {
            get
            {
                if (_Participiants == null)
                    CreateParticipiantsCollection();
                return _Participiants;
            }
        }

        virtual protected void CreateReagentCostsCollection()
        {
            _ReagentCosts = new ReagentDetail.ChildReagentDetailCollection(this, new Guid("49854f38-7f0e-44f7-b388-b3a1bce4e05c"));
            ((ITTChildObjectCollection)_ReagentCosts).GetChildren();
        }

        protected ReagentDetail.ChildReagentDetailCollection _ReagentCosts = null;
        public ReagentDetail.ChildReagentDetailCollection ReagentCosts
        {
            get
            {
                if (_ReagentCosts == null)
                    CreateReagentCostsCollection();
                return _ReagentCosts;
            }
        }

        virtual protected void CreateOtherCostsCollection()
        {
            _OtherCosts = new OtherCostDetail.ChildOtherCostDetailCollection(this, new Guid("9bb77f14-2205-4b56-8573-73a0a723e361"));
            ((ITTChildObjectCollection)_OtherCosts).GetChildren();
        }

        protected OtherCostDetail.ChildOtherCostDetailCollection _OtherCosts = null;
        public OtherCostDetail.ChildOtherCostDetailCollection OtherCosts
        {
            get
            {
                if (_OtherCosts == null)
                    CreateOtherCostsCollection();
                return _OtherCosts;
            }
        }

        virtual protected void CreateProjectReportsCollection()
        {
            _ProjectReports = new ProjectProgressReport.ChildProjectProgressReportCollection(this, new Guid("d6f0bd54-72f3-4bb7-bcb0-9f9b8bb6341f"));
            ((ITTChildObjectCollection)_ProjectReports).GetChildren();
        }

        protected ProjectProgressReport.ChildProjectProgressReportCollection _ProjectReports = null;
        public ProjectProgressReport.ChildProjectProgressReportCollection ProjectReports
        {
            get
            {
                if (_ProjectReports == null)
                    CreateProjectReportsCollection();
                return _ProjectReports;
            }
        }

        virtual protected void CreateDutyCostsCollection()
        {
            _DutyCosts = new DutiesDetail.ChildDutiesDetailCollection(this, new Guid("76d5777b-0feb-44c2-882f-345feeb3c102"));
            ((ITTChildObjectCollection)_DutyCosts).GetChildren();
        }

        protected DutiesDetail.ChildDutiesDetailCollection _DutyCosts = null;
        public DutiesDetail.ChildDutiesDetailCollection DutyCosts
        {
            get
            {
                if (_DutyCosts == null)
                    CreateDutyCostsCollection();
                return _DutyCosts;
            }
        }

        virtual protected void CreateAdvisiorsCollection()
        {
            _Advisiors = new ProjectAdvisor.ChildProjectAdvisorCollection(this, new Guid("a8950fd3-57b6-4a4c-a378-942e017d624d"));
            ((ITTChildObjectCollection)_Advisiors).GetChildren();
        }

        protected ProjectAdvisor.ChildProjectAdvisorCollection _Advisiors = null;
        public ProjectAdvisor.ChildProjectAdvisorCollection Advisiors
        {
            get
            {
                if (_Advisiors == null)
                    CreateAdvisiorsCollection();
                return _Advisiors;
            }
        }

        virtual protected void CreateReservationCollection()
        {
            _Reservation = new LabaratoryReservation.ChildLabaratoryReservationCollection(this, new Guid("2325aa34-f809-4459-8d8d-6761df9bf6eb"));
            ((ITTChildObjectCollection)_Reservation).GetChildren();
        }

        protected LabaratoryReservation.ChildLabaratoryReservationCollection _Reservation = null;
        public LabaratoryReservation.ChildLabaratoryReservationCollection Reservation
        {
            get
            {
                if (_Reservation == null)
                    CreateReservationCollection();
                return _Reservation;
            }
        }

        virtual protected void CreateConsumableMaterialsCollection()
        {
            _ConsumableMaterials = new ConsumableMaterialDetail.ChildConsumableMaterialDetailCollection(this, new Guid("fc844b5d-7550-42ee-b7e2-285921fb97d2"));
            ((ITTChildObjectCollection)_ConsumableMaterials).GetChildren();
        }

        protected ConsumableMaterialDetail.ChildConsumableMaterialDetailCollection _ConsumableMaterials = null;
        public ConsumableMaterialDetail.ChildConsumableMaterialDetailCollection ConsumableMaterials
        {
            get
            {
                if (_ConsumableMaterials == null)
                    CreateConsumableMaterialsCollection();
                return _ConsumableMaterials;
            }
        }

        virtual protected void CreateAdditionalTimeDemandsCollection()
        {
            _AdditionalTimeDemands = new AdditionalTimeDemand.ChildAdditionalTimeDemandCollection(this, new Guid("54d8dd41-cdb6-42f9-890f-bc6851690adb"));
            ((ITTChildObjectCollection)_AdditionalTimeDemands).GetChildren();
        }

        protected AdditionalTimeDemand.ChildAdditionalTimeDemandCollection _AdditionalTimeDemands = null;
        public AdditionalTimeDemand.ChildAdditionalTimeDemandCollection AdditionalTimeDemands
        {
            get
            {
                if (_AdditionalTimeDemands == null)
                    CreateAdditionalTimeDemandsCollection();
                return _AdditionalTimeDemands;
            }
        }

        virtual protected void CreateDocumentsCollection()
        {
            _Documents = new ProjectDocument.ChildProjectDocumentCollection(this, new Guid("77c94f11-70de-4160-9426-9302e7b1e327"));
            ((ITTChildObjectCollection)_Documents).GetChildren();
        }

        protected ProjectDocument.ChildProjectDocumentCollection _Documents = null;
        public ProjectDocument.ChildProjectDocumentCollection Documents
        {
            get
            {
                if (_Documents == null)
                    CreateDocumentsCollection();
                return _Documents;
            }
        }

        virtual protected void CreateAwardsCollection()
        {
            _Awards = new ProjectAward.ChildProjectAwardCollection(this, new Guid("c675725b-c542-4bf8-a3f6-6d52aab80ef9"));
            ((ITTChildObjectCollection)_Awards).GetChildren();
        }

        protected ProjectAward.ChildProjectAwardCollection _Awards = null;
        public ProjectAward.ChildProjectAwardCollection Awards
        {
            get
            {
                if (_Awards == null)
                    CreateAwardsCollection();
                return _Awards;
            }
        }

        virtual protected void CreateJournalsCollection()
        {
            _Journals = new ProjectJournal.ChildProjectJournalCollection(this, new Guid("8d70af64-518c-4e40-b5ed-e694aa287a45"));
            ((ITTChildObjectCollection)_Journals).GetChildren();
        }

        protected ProjectJournal.ChildProjectJournalCollection _Journals = null;
        public ProjectJournal.ChildProjectJournalCollection Journals
        {
            get
            {
                if (_Journals == null)
                    CreateJournalsCollection();
                return _Journals;
            }
        }

        protected ArgeProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ArgeProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ArgeProject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ArgeProject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ArgeProject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARGEPROJECT", dataRow) { }
        protected ArgeProject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARGEPROJECT", dataRow, isImported) { }
        public ArgeProject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ArgeProject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ArgeProject() : base() { }

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