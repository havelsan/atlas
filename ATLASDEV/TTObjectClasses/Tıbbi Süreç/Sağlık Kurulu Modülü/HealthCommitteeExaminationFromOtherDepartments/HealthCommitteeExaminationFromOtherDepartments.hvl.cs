
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeExaminationFromOtherDepartments")] 

    /// <summary>
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class HealthCommitteeExaminationFromOtherDepartments : BaseHealthCommittee, IWorkListEpisodeAction
    {
        public class HealthCommitteeExaminationFromOtherDepartmentsList : TTObjectCollection<HealthCommitteeExaminationFromOtherDepartments> { }
                    
        public class ChildHealthCommitteeExaminationFromOtherDepartmentsCollection : TTObject.TTChildObjectCollection<HealthCommitteeExaminationFromOtherDepartments>
        {
            public ChildHealthCommitteeExaminationFromOtherDepartmentsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeExaminationFromOtherDepartmentsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("6bfe28ad-028e-4a45-8891-7527c39c488d"); } }
            public static Guid Rejected { get { return new Guid("0106b5cd-6696-4de7-88ba-d77583c35842"); } }
    /// <summary>
    /// İptal State i
    /// </summary>
            public static Guid Cancelled { get { return new Guid("59967eac-45cd-4003-b5eb-d10c295611d5"); } }
            public static Guid Acceptance { get { return new Guid("ebf06305-50b9-4ac0-a52f-cb3615c190b5"); } }
            public static Guid Approval { get { return new Guid("e7553d42-b5f4-42ba-a94e-964548282838"); } }
        }

    /// <summary>
    /// Red Açıklaması
    /// </summary>
        public string ExplanationOfRejection
        {
            get { return (string)this["EXPLANATIONOFREJECTION"]; }
            set { this["EXPLANATIONOFREJECTION"] = value; }
        }

        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Önceki Birimler
    /// </summary>
        public ResClinic ExaminationUnitsHospitals
        {
            get { return (ResClinic)((ITTObject)this).GetParent("EXAMINATIONUNITSHOSPITALS"); }
            set { this["EXAMINATIONUNITSHOSPITALS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birimler
    /// </summary>
        public ResClinic PreviousUnits
        {
            get { return (ResClinic)((ITTObject)this).GetParent("PREVIOUSUNITS"); }
            set { this["PREVIOUSUNITS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayenelerin Bağlanacağı SK 
    /// </summary>
        public HealthCommittee HCActionToBeLinked
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HCACTIONTOBELINKED"); }
            set { this["HCACTIONTOBELINKED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePrevHospitalsUnitsCollection()
        {
            _PrevHospitalsUnits = new HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid.ChildHCExaminationFromOtherDepartments_PrevHospitalsUnitsGridCollection(this, new Guid("68974dc9-fd7a-4d46-a7a4-40078c69f086"));
            ((ITTChildObjectCollection)_PrevHospitalsUnits).GetChildren();
        }

        protected HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid.ChildHCExaminationFromOtherDepartments_PrevHospitalsUnitsGridCollection _PrevHospitalsUnits = null;
        public HCExaminationFromOtherDepartments_PrevHospitalsUnitsGrid.ChildHCExaminationFromOtherDepartments_PrevHospitalsUnitsGridCollection PrevHospitalsUnits
        {
            get
            {
                if (_PrevHospitalsUnits == null)
                    CreatePrevHospitalsUnitsCollection();
                return _PrevHospitalsUnits;
            }
        }

        virtual protected void CreateHealthCommitteeExaminationsCollection()
        {
            _HealthCommitteeExaminations = new HealthCommitteeExamination.ChildHealthCommitteeExaminationCollection(this, new Guid("34c7cd44-c40e-46aa-8860-728cae78cc9d"));
            ((ITTChildObjectCollection)_HealthCommitteeExaminations).GetChildren();
        }

        protected HealthCommitteeExamination.ChildHealthCommitteeExaminationCollection _HealthCommitteeExaminations = null;
    /// <summary>
    /// Child collection for Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
        public HealthCommitteeExamination.ChildHealthCommitteeExaminationCollection HealthCommitteeExaminations
        {
            get
            {
                if (_HealthCommitteeExaminations == null)
                    CreateHealthCommitteeExaminationsCollection();
                return _HealthCommitteeExaminations;
            }
        }

        protected HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEEXAMINATIONFROMOTHERDEPARTMENTS", dataRow) { }
        protected HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEEXAMINATIONFROMOTHERDEPARTMENTS", dataRow, isImported) { }
        public HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeExaminationFromOtherDepartments(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeExaminationFromOtherDepartments() : base() { }

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