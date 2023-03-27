
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeExaminationFromOtherHospitals")] 

    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class HealthCommitteeExaminationFromOtherHospitals : BaseHealthCommitteeExamination, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public class HealthCommitteeExaminationFromOtherHospitalsList : TTObjectCollection<HealthCommitteeExaminationFromOtherHospitals> { }
                    
        public class ChildHealthCommitteeExaminationFromOtherHospitalsCollection : TTObject.TTChildObjectCollection<HealthCommitteeExaminationFromOtherHospitals>
        {
            public ChildHealthCommitteeExaminationFromOtherHospitalsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeExaminationFromOtherHospitalsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCEFOHByMasterAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Referablehospital
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERABLEHOSPITAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Referableresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERABLERESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestExplanation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEXPLANATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REQUESTEXPLANATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InfoOfSent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFOOFSENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["INFOOFSENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCEFOHByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCEFOHByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCEFOHByMasterAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCEFOHByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Referablehospital
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERABLEHOSPITAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Referableresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERABLERESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Name
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NAME"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetHCEFOHByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCEFOHByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCEFOHByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCurrentHCEFromOtherHospital_Class : TTReportNqlObject 
        {
            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["REPORTNOTEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usersicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERSICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Userunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Usersinif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERSINIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Userrutbe
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERRUTBE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usergorev
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERGOREV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Bolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUMID"]);
                }
            }

            public Object Dogumyeriil
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIIL"]);
                }
            }

            public string Dogumyeriilce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
                }
            }

            public GetCurrentHCEFromOtherHospital_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrentHCEFromOtherHospital_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrentHCEFromOtherHospital_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SaglikKuruluSevk_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Kabultur
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KABULTUR"]);
                }
            }

            public Guid? Sevkeeden_birim
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVKEEDEN_BIRIM"]);
                }
            }

            public Guid? Sevkedilen_brans
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVKEDILEN_BRANS"]);
                }
            }

            public Guid? Sevkedilen_XXXXXX
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEVKEDILEN_XXXXXX"]);
                }
            }

            public Object Sevk_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SEVK_TURU"]);
                }
            }

            public OLAP_SaglikKuruluSevk_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SaglikKuruluSevk_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SaglikKuruluSevk_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCEFOHForTransferReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Dogumyeriil
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIIL"]);
                }
            }

            public string Dogumyeriilce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResourceName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HavaleedilenXXXXXX
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HAVALEEDILENXXXXXX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SentOtherResources
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENTOTHERRESOURCES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].AllPropertyDefs["SENTOTHERRESOURCES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Hcobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HCOBJECTID"]);
                }
            }

            public GetHCEFOHForTransferReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCEFOHForTransferReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCEFOHForTransferReport_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal State i
    /// </summary>
            public static Guid Cancelled { get { return new Guid("3ff7b45d-eed4-48ea-902a-1422b8db25ec"); } }
            public static Guid TransferDocumentConstitution { get { return new Guid("c1a0e343-8330-4242-a640-a365f4834791"); } }
            public static Guid Resulted { get { return new Guid("0169c61f-e6e5-434a-962c-6e591f2eb495"); } }
            public static Guid DecisionRegistration { get { return new Guid("98776f09-2af3-40bc-8b53-c5ecdc85d924"); } }
            public static Guid New { get { return new Guid("cf43bea6-f62e-4dbe-a169-d3b080d1b4a8"); } }
            public static Guid ExternalHospitalDecisionRegistration { get { return new Guid("5f89f965-67de-4b2c-9c48-f963dc4ad8fd"); } }
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class> GetHCEFOHByMasterAction(string MASTERACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFOHByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class> GetHCEFOHByMasterAction(TTObjectContext objectContext, string MASTERACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFOHByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByMasterAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class> GetHCEFOHByDate(DateTime STARTDATE, DateTime ENDDATE, int SENDINGSITUATIONFLAG, string HOSPITALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFOHByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SENDINGSITUATIONFLAG", SENDINGSITUATIONFLAG);
            paramList.Add("HOSPITALOBJECTID", HOSPITALOBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class> GetHCEFOHByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int SENDINGSITUATIONFLAG, string HOSPITALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFOHByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SENDINGSITUATIONFLAG", SENDINGSITUATIONFLAG);
            paramList.Add("HOSPITALOBJECTID", HOSPITALOBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi Raporu
    /// </summary>
        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class> GetCurrentHCEFromOtherHospital(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetCurrentHCEFromOtherHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi Raporu
    /// </summary>
        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class> GetCurrentHCEFromOtherHospital(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetCurrentHCEFromOtherHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetCurrentHCEFromOtherHospital_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.OLAP_SaglikKuruluSevk_Class> OLAP_SaglikKuruluSevk(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["OLAP_SaglikKuruluSevk"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.OLAP_SaglikKuruluSevk_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.OLAP_SaglikKuruluSevk_Class> OLAP_SaglikKuruluSevk(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["OLAP_SaglikKuruluSevk"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.OLAP_SaglikKuruluSevk_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class> GetHCEFOHForTransferReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFOHForTransferReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class> GetHCEFOHForTransferReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFOHForTransferReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExaminationFromOtherHospitals.GetHCEFOHForTransferReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExaminationFromOtherHospitals> GetHCEFromOtherHospByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS"].QueryDefs["GetHCEFromOtherHospByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommitteeExaminationFromOtherHospitals>(queryDef, paramList);
        }

    /// <summary>
    /// Tabip Sicil No
    /// </summary>
        public string DrEmploymentRecordID
        {
            get { return (string)this["DREMPLOYMENTRECORDID"]; }
            set { this["DREMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string RequestExplanation
        {
            get { return (string)this["REQUESTEXPLANATION"]; }
            set { this["REQUESTEXPLANATION"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Muamele Sayısı
    /// </summary>
        public int? NumberofProcess
        {
            get { return (int?)this["NUMBEROFPROCESS"]; }
            set { this["NUMBEROFPROCESS"] = value; }
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
    /// Sevk Yazısı
    /// </summary>
        public string InfoOfSent
        {
            get { return (string)this["INFOOFSENT"]; }
            set { this["INFOOFSENT"] = value; }
        }

    /// <summary>
    /// Evrak Sayısı
    /// </summary>
        public TTSequence DocumentNumber
        {
            get { return GetSequence("DOCUMENTNUMBER"); }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Sevkedilen Diğer Birimler
    /// </summary>
        public string SentOtherResources
        {
            get { return (string)this["SENTOTHERRESOURCES"]; }
            set { this["SENTOTHERRESOURCES"] = value; }
        }

    /// <summary>
    /// Sağlam
    /// </summary>
        public bool? IsHealthy
        {
            get { return (bool?)this["ISHEALTHY"]; }
            set { this["ISHEALTHY"] = value; }
        }

    /// <summary>
    /// Tabip Adı
    /// </summary>
        public string DrName
        {
            get { return (string)this["DRNAME"]; }
            set { this["DRNAME"] = value; }
        }

    /// <summary>
    /// Tabip Ünvan
    /// </summary>
        public string DrTitle
        {
            get { return (string)this["DRTITLE"]; }
            set { this["DRTITLE"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public string ReportNoText
        {
            get { return (string)this["REPORTNOTEXT"]; }
            set { this["REPORTNOTEXT"] = value; }
        }

    /// <summary>
    /// Gönderen XXXXXXdeki işlemin ObjectID si
    /// </summary>
        public string SourceObjectID
        {
            get { return (string)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

    /// <summary>
    /// Gönderilen XXXXXXdeki işlemin ObjectID si
    /// </summary>
        public string TargetObjectID
        {
            get { return (string)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

        public string MessageID
        {
            get { return (string)this["MESSAGEID"]; }
            set { this["MESSAGEID"] = value; }
        }

    /// <summary>
    /// Başlama Tarihi
    /// </summary>
        public DateTime? HealthCommitteeStartDate
        {
            get { return (DateTime?)this["HEALTHCOMMITTEESTARTDATE"]; }
            set { this["HEALTHCOMMITTEESTARTDATE"] = value; }
        }

        public ResDepartment Unit
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public RankDefinitions DrRank
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("DRRANK"); }
            set { this["DRRANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResSection Hospitals
        {
            get { return (ResSection)((ITTObject)this).GetParent("HOSPITALS"); }
            set { this["HOSPITALS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tabip Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition DrSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("DRSPECIALITY"); }
            set { this["DRSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReferableResource ReferableResource
        {
            get { return (ReferableResource)((ITTObject)this).GetParent("REFERABLERESOURCE"); }
            set { this["REFERABLERESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan XXXXXX
    /// </summary>
        public ResOtherHospital RequesterHospital
        {
            get { return (ResOtherHospital)((ITTObject)this).GetParent("REQUESTERHOSPITAL"); }
            set { this["REQUESTERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.ChildHCExaminationFromOtherHospitals_MatterSliceAnectodeGridCollection(this, new Guid("f8d318b5-cdb2-421b-be3c-8884a8fb0c93"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.ChildHCExaminationFromOtherHospitals_MatterSliceAnectodeGridCollection _MatterSliceAnectodes = null;
    /// <summary>
    /// Child collection for MAdde Dilim Fıkra
    /// </summary>
        public HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid.ChildHCExaminationFromOtherHospitals_MatterSliceAnectodeGridCollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        protected HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", dataRow) { }
        protected HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", dataRow, isImported) { }
        public HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeExaminationFromOtherHospitals(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeExaminationFromOtherHospitals() : base() { }

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