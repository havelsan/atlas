
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCSummary")] 

    /// <summary>
    /// Sağlık Kurulu Özeti
    /// </summary>
    public  partial class HCSummary : TTObject
    {
        public class HCSummaryList : TTObjectCollection<HCSummary> { }
                    
        public class ChildHCSummaryCollection : TTObject.TTChildObjectCollection<HCSummary>
        {
            public ChildHCSummaryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCSummaryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<HCSummary> GetByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCSUMMARY"].QueryDefs["GetByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<HCSummary>(queryDef, paramList);
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu işleminin ObjectID si
    /// </summary>
        public Guid? HCObjectID
        {
            get { return (Guid?)this["HCOBJECTID"]; }
            set { this["HCOBJECTID"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// İlave Karar
    /// </summary>
        public string AdditionalDecision
        {
            get { return (string)this["ADDITIONALDECISION"]; }
            set { this["ADDITIONALDECISION"] = value; }
        }

    /// <summary>
    /// Karar Süresi
    /// </summary>
        public int? DecisionTime
        {
            get { return (int?)this["DECISIONTIME"]; }
            set { this["DECISIONTIME"] = value; }
        }

    /// <summary>
    /// Karar Süresi Birimi
    /// </summary>
        public UnitOfTimeEnum? DecisionUnitOfTime
        {
            get { return (UnitOfTimeEnum?)(int?)this["DECISIONUNITOFTIME"]; }
            set { this["DECISIONUNITOFTIME"] = value; }
        }

    /// <summary>
    /// XXXXXXliğe elverişli değil
    /// </summary>
        public bool? UnsuitableForMilitaryService
        {
            get { return (bool?)this["UNSUITABLEFORMILITARYSERVICE"]; }
            set { this["UNSUITABLEFORMILITARYSERVICE"] = value; }
        }

    /// <summary>
    /// Vaka Açılış Tarihi
    /// </summary>
        public DateTime? EpisodeOpeningDate
        {
            get { return (DateTime?)this["EPISODEOPENINGDATE"]; }
            set { this["EPISODEOPENINGDATE"] = value; }
        }

    /// <summary>
    /// Saha
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Uçtuğu Uçak Tipi
    /// </summary>
        public AircraftTypeDefinition AircraftType
        {
            get { return (AircraftTypeDefinition)((ITTObject)this).GetParent("AIRCRAFTTYPE"); }
            set { this["AIRCRAFTTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Kararı
    /// </summary>
        public HealthCommitteeDecisionDefinition Decision
        {
            get { return (HealthCommitteeDecisionDefinition)((ITTObject)this).GetParent("DECISION"); }
            set { this["DECISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Görev Tanımları
    /// </summary>
        public HCDutyTypeDef Duty
        {
            get { return (HCDutyTypeDef)((ITTObject)this).GetParent("DUTY"); }
            set { this["DUTY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gönderen Makam
    /// </summary>
        public MilitaryUnit SenderChair
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("SENDERCHAIR"); }
            set { this["SENDERCHAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birlik
    /// </summary>
        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sınıf
    /// </summary>
        public MilitaryClassDefinitions MilitaryClass
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("MILITARYCLASS"); }
            set { this["MILITARYCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions Rank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANK"); }
            set { this["RANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new HCSummaryMSA.ChildHCSummaryMSACollection(this, new Guid("bdd96e1e-9de8-4763-87cf-0ca47f3d0425"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected HCSummaryMSA.ChildHCSummaryMSACollection _MatterSliceAnectodes = null;
        public HCSummaryMSA.ChildHCSummaryMSACollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        virtual protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new HCSummaryDiagnosis.ChildHCSummaryDiagnosisCollection(this, new Guid("827544c1-2d31-4aac-b526-29cbffd86ee3"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected HCSummaryDiagnosis.ChildHCSummaryDiagnosisCollection _Diagnosis = null;
        public HCSummaryDiagnosis.ChildHCSummaryDiagnosisCollection Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    CreateDiagnosisCollection();
                return _Diagnosis;
            }
        }

        protected HCSummary(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCSummary(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCSummary(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCSummary(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCSummary(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCSUMMARY", dataRow) { }
        protected HCSummary(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCSUMMARY", dataRow, isImported) { }
        public HCSummary(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCSummary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCSummary() : base() { }

    }
}