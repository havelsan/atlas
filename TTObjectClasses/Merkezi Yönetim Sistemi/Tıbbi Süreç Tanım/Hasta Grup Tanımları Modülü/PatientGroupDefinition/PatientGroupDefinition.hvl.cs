
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientGroupDefinition")] 

    /// <summary>
    /// Hasta Grup Tanımı
    /// </summary>
    public  partial class PatientGroupDefinition : TerminologyManagerDef
    {
        public class PatientGroupDefinitionList : TTObjectCollection<PatientGroupDefinition> { }
                    
        public class ChildPatientGroupDefinitionCollection : TTObject.TTChildObjectCollection<PatientGroupDefinition>
        {
            public ChildPatientGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientGroupDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PatientGroupEnum? PatientGroupEnum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTGROUPENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["PATIENTGROUPENUM"].DataType;
                    return (PatientGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? MilitaryPersonnel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYPERSONNEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MILITARYPERSONNEL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public BeneficiaryEnum? Beneficiary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["BENEFICIARY"].DataType;
                    return (BeneficiaryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MainPatientGroupEnum? MainPatientGroupEnum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINPATIENTGROUPENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINPATIENTGROUPDEFINITION"].AllPropertyDefs["MAINPATIENTGROUPENUM"].DataType;
                    return (MainPatientGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientGroupDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientGroupDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientGroupDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientGroupDefinitionID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPatientGroupDefinitionID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientGroupDefinitionID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientGroupDefinitionID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientGroupDefHC_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public PatientGroupEnum? PatientGroupEnum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTGROUPENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["PATIENTGROUPENUM"].DataType;
                    return (PatientGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public BeneficiaryEnum? Beneficiary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["BENEFICIARY"].DataType;
                    return (BeneficiaryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? MilitaryPersonnel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYPERSONNEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MILITARYPERSONNEL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? RequiredQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUIREDQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["REQUIREDQUOTA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AdmitAccordingToMainGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMITACCORDINGTOMAINGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["ADMITACCORDINGTOMAINGROUP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsRequiredSmartdCard
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREQUIREDSMARTDCARD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["ISREQUIREDSMARTDCARD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PassQuarantineForInpatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASSQUARANTINEFORINPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["PASSQUARANTINEFORINPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PatientGroupForeignUsageEnum? ForeignUsage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["FOREIGNUSAGE"].DataType;
                    return (PatientGroupForeignUsageEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaTedaviTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATEDAVITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MEDULATEDAVITURU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTedaviTipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATEDAVITIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MEDULATEDAVITIPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaTakipTipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULATAKIPTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MEDULATAKIPTIPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaSigortaliTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASIGORTALITURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MEDULASIGORTALITURU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaDevredilenKurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADEVREDILENKURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MEDULADEVREDILENKURUM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientGroupTypeEnum? PatientGroupType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTGROUPTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["PATIENTGROUPTYPE"].DataType;
                    return (PatientGroupTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SecurePersonTypeEnum? SecureType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECURETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["SECURETYPE"].DataType;
                    return (SecurePersonTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaProvizyonTipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPROVIZYONTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["MEDULAPROVIZYONTIPI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? EpisodeClosingDayLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODECLOSINGDAYLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["EPISODECLOSINGDAYLIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientGroupDefHC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientGroupDefHC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientGroupDefHC_Class() : base() { }
        }

        public static BindingList<PatientGroupDefinition> GetByPatientGroup(TTObjectContext objectContext, PatientGroupEnum PARAMPATIENTGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTGROUP", (int)PARAMPATIENTGROUP);

            return ((ITTQuery)objectContext).QueryObjects<PatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientGroupDefinition> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientGroupDefinition.GetPatientGroupDefinition_Class> GetPatientGroupDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientGroupDefinition.GetPatientGroupDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientGroupDefinition.GetPatientGroupDefinition_Class> GetPatientGroupDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientGroupDefinition.GetPatientGroupDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientGroupDefinition> GetActivePatientGroups(TTObjectContext objectContext, bool GETALL, bool ISEMERGENCYUSER, bool ISMEDULAINTEGRATION, int FOREIGNUSAGE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetActivePatientGroups"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GETALL", GETALL);
            paramList.Add("ISEMERGENCYUSER", ISEMERGENCYUSER);
            paramList.Add("ISMEDULAINTEGRATION", ISMEDULAINTEGRATION);
            paramList.Add("FOREIGNUSAGE", FOREIGNUSAGE);

            return ((ITTQuery)objectContext).QueryObjects<PatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientGroupDefinition> GetByMainPatientGroup(TTObjectContext objectContext, Guid MAINPATIENTGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetByMainPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINPATIENTGROUP", MAINPATIENTGROUP);

            return ((ITTQuery)objectContext).QueryObjects<PatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientGroupDefinition> GetPatientGroupDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientGroupDefinition.GetPatientGroupDefinitionID_Class> GetPatientGroupDefinitionID(PatientGroupEnum PARAMPATIENTGROUP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefinitionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTGROUP", (int)PARAMPATIENTGROUP);

            return TTReportNqlObject.QueryObjects<PatientGroupDefinition.GetPatientGroupDefinitionID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientGroupDefinition.GetPatientGroupDefinitionID_Class> GetPatientGroupDefinitionID(TTObjectContext objectContext, PatientGroupEnum PARAMPATIENTGROUP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefinitionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTGROUP", (int)PARAMPATIENTGROUP);

            return TTReportNqlObject.QueryObjects<PatientGroupDefinition.GetPatientGroupDefinitionID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientGroupDefinition> GetByPatientGroupType(TTObjectContext objectContext, PatientGroupTypeEnum PATIENTGROUPTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetByPatientGroupType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTGROUPTYPE", (int)PATIENTGROUPTYPE);

            return ((ITTQuery)objectContext).QueryObjects<PatientGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientGroupDefinition.GetPatientGroupDefHC_Class> GetPatientGroupDefHC(PatientGroupEnum PARAMPATIENTGROUP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefHC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTGROUP", (int)PARAMPATIENTGROUP);

            return TTReportNqlObject.QueryObjects<PatientGroupDefinition.GetPatientGroupDefHC_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientGroupDefinition.GetPatientGroupDefHC_Class> GetPatientGroupDefHC(TTObjectContext objectContext, PatientGroupEnum PARAMPATIENTGROUP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTGROUPDEFINITION"].QueryDefs["GetPatientGroupDefHC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATIENTGROUP", (int)PARAMPATIENTGROUP);

            return TTReportNqlObject.QueryObjects<PatientGroupDefinition.GetPatientGroupDefHC_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Grubu
    /// </summary>
        public PatientGroupEnum? PatientGroupEnum
        {
            get { return (PatientGroupEnum?)(int?)this["PATIENTGROUPENUM"]; }
            set { this["PATIENTGROUPENUM"] = value; }
        }

    /// <summary>
    /// HakSahipliği
    /// </summary>
        public BeneficiaryEnum? Beneficiary
        {
            get { return (BeneficiaryEnum?)(int?)this["BENEFICIARY"]; }
            set { this["BENEFICIARY"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Hizmet İçi Pesonel
    /// </summary>
        public bool? MilitaryPersonnel
        {
            get { return (bool?)this["MILITARYPERSONNEL"]; }
            set { this["MILITARYPERSONNEL"] = value; }
        }

    /// <summary>
    /// Kontenjan Gerektirir
    /// </summary>
        public bool? RequiredQuota
        {
            get { return (bool?)this["REQUIREDQUOTA"]; }
            set { this["REQUIREDQUOTA"] = value; }
        }

    /// <summary>
    /// MPVT'den Geldiğinde Ana Grubuna Göre Kabul Et
    /// </summary>
        public bool? AdmitAccordingToMainGroup
        {
            get { return (bool?)this["ADMITACCORDINGTOMAINGROUP"]; }
            set { this["ADMITACCORDINGTOMAINGROUP"] = value; }
        }

    /// <summary>
    /// Akıllı Kart Kulanımı Gerektirir
    /// </summary>
        public bool? IsRequiredSmartdCard
        {
            get { return (bool?)this["ISREQUIREDSMARTDCARD"]; }
            set { this["ISREQUIREDSMARTDCARD"] = value; }
        }

        public bool? PassQuarantineForInpatient
        {
            get { return (bool?)this["PASSQUARANTINEFORINPATIENT"]; }
            set { this["PASSQUARANTINEFORINPATIENT"] = value; }
        }

    /// <summary>
    /// Yerli/Yabancı Hasta 
    /// </summary>
        public PatientGroupForeignUsageEnum? ForeignUsage
        {
            get { return (PatientGroupForeignUsageEnum?)(int?)this["FOREIGNUSAGE"]; }
            set { this["FOREIGNUSAGE"] = value; }
        }

    /// <summary>
    /// Tedavi Türü
    /// </summary>
        public string MedulaTedaviTuru
        {
            get { return (string)this["MEDULATEDAVITURU"]; }
            set { this["MEDULATEDAVITURU"] = value; }
        }

    /// <summary>
    /// Tedavi Tipi
    /// </summary>
        public string MedulaTedaviTipi
        {
            get { return (string)this["MEDULATEDAVITIPI"]; }
            set { this["MEDULATEDAVITIPI"] = value; }
        }

    /// <summary>
    /// Takibin Tipi
    /// </summary>
        public string MedulaTakipTipi
        {
            get { return (string)this["MEDULATAKIPTIPI"]; }
            set { this["MEDULATAKIPTIPI"] = value; }
        }

    /// <summary>
    /// Sigortalı Türü
    /// </summary>
        public string MedulaSigortaliTuru
        {
            get { return (string)this["MEDULASIGORTALITURU"]; }
            set { this["MEDULASIGORTALITURU"] = value; }
        }

    /// <summary>
    /// Hastanın Devredilen Kurumu
    /// </summary>
        public string MedulaDevredilenKurum
        {
            get { return (string)this["MEDULADEVREDILENKURUM"]; }
            set { this["MEDULADEVREDILENKURUM"] = value; }
        }

    /// <summary>
    /// Hasta Grubu Tipi
    /// </summary>
        public PatientGroupTypeEnum? PatientGroupType
        {
            get { return (PatientGroupTypeEnum?)(int?)this["PATIENTGROUPTYPE"]; }
            set { this["PATIENTGROUPTYPE"] = value; }
        }

        public SecurePersonTypeEnum? SecureType
        {
            get { return (SecurePersonTypeEnum?)(int?)this["SECURETYPE"]; }
            set { this["SECURETYPE"] = value; }
        }

    /// <summary>
    /// Provizyonun Tipi
    /// </summary>
        public string MedulaProvizyonTipi
        {
            get { return (string)this["MEDULAPROVIZYONTIPI"]; }
            set { this["MEDULAPROVIZYONTIPI"] = value; }
        }

    /// <summary>
    /// Vaka Geçerlilik Süresi(Gün)
    /// </summary>
        public int? EpisodeClosingDayLimit
        {
            get { return (int?)this["EPISODECLOSINGDAYLIMIT"]; }
            set { this["EPISODECLOSINGDAYLIMIT"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Ana Hasta Grubu
    /// </summary>
        public MainPatientGroupDefinition MainPatientGroup
        {
            get { return (MainPatientGroupDefinition)((ITTObject)this).GetParent("MAINPATIENTGROUP"); }
            set { this["MAINPATIENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReasonForAdmissionsCollection()
        {
            _ReasonForAdmissions = new PGReasonForAdmissionGrid.ChildPGReasonForAdmissionGridCollection(this, new Guid("7e02befd-eac6-42ef-bbb9-b0c85ed50e5e"));
            ((ITTChildObjectCollection)_ReasonForAdmissions).GetChildren();
        }

        protected PGReasonForAdmissionGrid.ChildPGReasonForAdmissionGridCollection _ReasonForAdmissions = null;
    /// <summary>
    /// Child collection for Hasta Grubu-Kabul Sebepleri
    /// </summary>
        public PGReasonForAdmissionGrid.ChildPGReasonForAdmissionGridCollection ReasonForAdmissions
        {
            get
            {
                if (_ReasonForAdmissions == null)
                    CreateReasonForAdmissionsCollection();
                return _ReasonForAdmissions;
            }
        }

        virtual protected void CreateHCDesicionDefPatGroupGridsCollection()
        {
            _HCDesicionDefPatGroupGrids = new HCDesicionDefPatGroupGrid.ChildHCDesicionDefPatGroupGridCollection(this, new Guid("061a3e42-3976-4d56-bdde-f746128fef08"));
            ((ITTChildObjectCollection)_HCDesicionDefPatGroupGrids).GetChildren();
        }

        protected HCDesicionDefPatGroupGrid.ChildHCDesicionDefPatGroupGridCollection _HCDesicionDefPatGroupGrids = null;
        public HCDesicionDefPatGroupGrid.ChildHCDesicionDefPatGroupGridCollection HCDesicionDefPatGroupGrids
        {
            get
            {
                if (_HCDesicionDefPatGroupGrids == null)
                    CreateHCDesicionDefPatGroupGridsCollection();
                return _HCDesicionDefPatGroupGrids;
            }
        }

        protected PatientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTGROUPDEFINITION", dataRow) { }
        protected PatientGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTGROUPDEFINITION", dataRow, isImported) { }
        public PatientGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientGroupDefinition() : base() { }

    }
}