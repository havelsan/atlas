
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeAction")] 

    /// <summary>
    /// Vakaya Bağlı Hasta İşlemlerinini Ana Nesnesi
    /// </summary>
    public  abstract  partial class EpisodeAction : BaseAction, IEpisodeActionResources, IAccountOperation, ICheckPaid, ITreatmentMaterialCollection, IEpisodeActionPermission, IOldActions, IEpisodeAction, ISUTEpisodeAction, ISubEpisodeStarter, IStartFromNewActionInPatientFolder
    {
        public class EpisodeActionList : TTObjectCollection<EpisodeAction> { }
                    
        public class ChildEpisodeActionCollection : TTObject.TTChildObjectCollection<EpisodeAction>
        {
            public ChildEpisodeActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBirthEpisodeAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fr
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mr
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Dr
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBirthEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBirthEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBirthEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientInfoByEpisodeAction_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Maritalstatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARITALSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMEDENIHALI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Countryofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTRYOFBIRTH"]);
                }
            }

            public Object Cityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYOFBIRTH"]);
                }
            }

            public Object Townofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOWNOFBIRTH"]);
                }
            }

            public Object Cityofregistry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYOFREGISTRY"]);
                }
            }

            public Object Townofregistry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOWNOFREGISTRY"]);
                }
            }

            public string VillageOfRegistry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VILLAGEOFREGISTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["VILLAGEOFREGISTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Treatmentclinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTCLINIC"]);
                }
            }

            public GetPatientInfoByEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientInfoByEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientInfoByEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodesNotExistsMTS_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Fno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Hprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetEpisodesNotExistsMTS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodesNotExistsMTS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodesNotExistsMTS_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPoliclinicExaminationDetail_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Fno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
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

            public long? Hprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object DentalExaminationFile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALEXAMINATIONFILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DENTALEXAMINATIONFILE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public bool? BDYearOnly
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BDYEARONLY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BDYEARONLY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetPoliclinicExaminationDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPoliclinicExaminationDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPoliclinicExaminationDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyAdmissionCount_Class : TTReportNqlObject 
        {
            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? IsQuotaUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUOTAUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISQUOTAUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetEmergencyAdmissionCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyAdmissionCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyAdmissionCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeActionsByRequestDate_Class : TTReportNqlObject 
        {
            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetEpisodeActionsByRequestDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionsByRequestDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionsByRequestDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientFolderInfoForIAandNA_Class : TTReportNqlObject 
        {
            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Requestdepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Quarantineinpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
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

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public string Patienttownofbirth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTOWNOFBIRTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Address
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESS"]);
                }
            }

            public Object Addresstown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESSTOWN"]);
                }
            }

            public Object Addresscity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESSCITY"]);
                }
            }

            public Object Addresscountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESSCOUNTRY"]);
                }
            }

            public Object Phone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PHONE"]);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Treatmentclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Revir
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REVIR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientFolderInfoForIAandNA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientFolderInfoForIAandNA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientFolderInfoForIAandNA_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class : TTReportNqlObject 
        {
            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnCompletedEpisodeActionsByEpisode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetUnCompletedEpisodeActionsByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnCompletedEpisodeActionsByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnCompletedEpisodeActionsByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByEpisodeActionFilterExpressionReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Secmasterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECMASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetByEpisodeActionFilterExpressionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByEpisodeActionFilterExpressionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByEpisodeActionFilterExpressionReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEndOfDayPoliclinicReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Fno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
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

            public long? Hprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Sicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Docrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEndOfDayPoliclinicReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEndOfDayPoliclinicReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEndOfDayPoliclinicReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByEpisodeActionWorklistDateReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetByEpisodeActionWorklistDateReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByEpisodeActionWorklistDateReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByEpisodeActionWorklistDateReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeActionsCount_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetEpisodeActionsCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionsCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionsCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByMasterAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByMasterAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEHREpisodeActionSubactionProcedures_Class : TTReportNqlObject 
        {
            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetEHREpisodeActionSubactionProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHREpisodeActionSubactionProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHREpisodeActionSubactionProcedures_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPoliclinicAdmissionCount_Class : TTReportNqlObject 
        {
            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? IsQuotaUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUOTAUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISQUOTAUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetPoliclinicAdmissionCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPoliclinicAdmissionCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPoliclinicAdmissionCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeActionsByObjectIDs_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeActionsByObjectIDs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionsByObjectIDs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionsByObjectIDs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEHREpisodeActionDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Diagnosisobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSISOBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DiagnoseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["DIAGNOSEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMainDiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMAINDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISGRID"].AllPropertyDefs["ISMAINDIAGNOSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEHREpisodeActionDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHREpisodeActionDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHREpisodeActionDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForEpisodeAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetOldInfoForEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEHREpisodeActionSubactionMaterialsTotalAmount_Class : TTReportNqlObject 
        {
            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public GetEHREpisodeActionSubactionMaterialsTotalAmount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHREpisodeActionSubactionMaterialsTotalAmount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHREpisodeActionSubactionMaterialsTotalAmount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEHREpisodeActionSubactionProceduresTotalAmount_Class : TTReportNqlObject 
        {
            public Guid? Procedureobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public GetEHREpisodeActionSubactionProceduresTotalAmount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHREpisodeActionSubactionProceduresTotalAmount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHREpisodeActionSubactionProceduresTotalAmount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Yabancisicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCISICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? Yabancimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Soyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeActionByObjectID_Class : TTReportNqlObject 
        {
            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Curstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURSTATE"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? FromResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRESOURCE"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String Objdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDESCRIPTION"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objectname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetEpisodeActionByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientFolderEpisodeActions_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientFolderEpisodeActions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientFolderEpisodeActions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientFolderEpisodeActions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActionDetailNQLByEpisode_Class : TTReportNqlObject 
        {
            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Curstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURSTATE"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? FromResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRESOURCE"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String Objdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDESCRIPTION"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objectname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetActionDetailNQLByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActionDetailNQLByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActionDetailNQLByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeActionsGroupByHasApp_Class : TTReportNqlObject 
        {
            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hasapp
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASAPP"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetEpisodeActionsGroupByHasApp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionsGroupByHasApp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionsGroupByHasApp_Class() : base() { }
        }

        [Serializable] 

        public partial class DisTetkikIstemRaporByEpisodeActionNQL_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public string BirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Masterres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRES"]);
                }
            }

            public DateTime? Requestdate2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DisTetkikIstemRaporByEpisodeActionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DisTetkikIstemRaporByEpisodeActionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DisTetkikIstemRaporByEpisodeActionNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeActionsForPatientFolder_Class : TTReportNqlObject 
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

            public String Ttobjectdefname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TTOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Secmasterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECMASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Actiondate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                }
            }

            public Object Objectdisplaytext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OBJECTDISPLAYTEXT"]);
                }
            }

            public String Statedisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeActionsForPatientFolder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeActionsForPatientFolder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeActionsForPatientFolder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSevkNQL_Class : TTReportNqlObject 
        {
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? PatientAddress
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTADDRESS"]);
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kurumadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SERVICE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetSevkNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSevkNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSevkNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockEpisodeActionWorkListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetStockEpisodeActionWorkListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockEpisodeActionWorkListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockEpisodeActionWorkListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpicrisisPatientInfoByEpisodeAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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

            public string BirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public string Yattigi_bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGI_BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Yatis_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATIS_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Cikis_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CIKIS_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public GetEpicrisisPatientInfoByEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpicrisisPatientInfoByEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpicrisisPatientInfoByEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class TestQuery1_Class : TTReportNqlObject 
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

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Secmasterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECMASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TestQuery1_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TestQuery1_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TestQuery1_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStockEpisodeActionWorkListNQLByID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetStockEpisodeActionWorkListNQLByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStockEpisodeActionWorkListNQLByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStockEpisodeActionWorkListNQLByID_Class() : base() { }
        }

        public static BindingList<EpisodeAction> GetAllExaminationsOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllExaminationsOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetBirthEpisodeAction_Class> GetBirthEpisodeAction(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetBirthEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetBirthEpisodeAction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetBirthEpisodeAction_Class> GetBirthEpisodeAction(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetBirthEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetBirthEpisodeAction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetPatientInfoByEpisodeAction_Class> GetPatientInfoByEpisodeAction(string EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPatientInfoByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPatientInfoByEpisodeAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetPatientInfoByEpisodeAction_Class> GetPatientInfoByEpisodeAction(TTObjectContext objectContext, string EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPatientInfoByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPatientInfoByEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Episode un Action larını get eder
    /// </summary>
        public static BindingList<EpisodeAction> GetEpisodeActionsByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetAllConsFromOtherHospOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllConsFromOtherHospOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetUnCompletedEAByActiondate(TTObjectContext objectContext, DateTime ACTIONDATE, string MASTERRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetUnCompletedEAByActiondate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONDATE", ACTIONDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetEpisodesNotExistsMTS_Class> GetEpisodesNotExistsMTS(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodesNotExistsMTS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodesNotExistsMTS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodesNotExistsMTS_Class> GetEpisodesNotExistsMTS(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodesNotExistsMTS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodesNotExistsMTS_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetConsFromOtherHospOfSubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetConsFromOtherHospOfSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

    /// <summary>
    /// Poliklinik hizmeti yapıldıktan sonra gün sonunda verilen hizmetin rapor query si
    /// </summary>
        public static BindingList<EpisodeAction.GetPoliclinicExaminationDetail_Class> GetPoliclinicExaminationDetail(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPoliclinicExaminationDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPoliclinicExaminationDetail_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Poliklinik hizmeti yapıldıktan sonra gün sonunda verilen hizmetin rapor query si
    /// </summary>
        public static BindingList<EpisodeAction.GetPoliclinicExaminationDetail_Class> GetPoliclinicExaminationDetail(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPoliclinicExaminationDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPoliclinicExaminationDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEmergencyAdmissionCount_Class> GetEmergencyAdmissionCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEmergencyAdmissionCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEmergencyAdmissionCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEmergencyAdmissionCount_Class> GetEmergencyAdmissionCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEmergencyAdmissionCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEmergencyAdmissionCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetByEpisodeOrderByRequestDate(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByEpisodeOrderByRequestDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsByRequestDate_Class> GetEpisodeActionsByRequestDate(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsByRequestDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsByRequestDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsByRequestDate_Class> GetEpisodeActionsByRequestDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsByRequestDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsByRequestDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetByWorklistDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByWorklistDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class> GetInpatientFolderInfoForIAandNA(Guid EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetInpatientFolderInfoForIAandNA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class> GetInpatientFolderInfoForIAandNA(TTObjectContext objectContext, Guid EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetInpatientFolderInfoForIAandNA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetInpatientFolderInfoForIAandNA_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetAllPatientExaminationsOfPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllPatientExaminationsOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class> GetEHREpisodeActionSubactProcFlowablesTotalAmount(Guid PROCEDUREID, Guid EPISODEACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactProcFlowablesTotalAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREID", PROCEDUREID);
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class> GetEHREpisodeActionSubactProcFlowablesTotalAmount(TTObjectContext objectContext, Guid PROCEDUREID, Guid EPISODEACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactProcFlowablesTotalAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREID", PROCEDUREID);
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactProcFlowablesTotalAmount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class> GetUnCompletedEpisodeActionsByEpisode(Guid EPISODE, Guid EAOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetUnCompletedEpisodeActionsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("EAOBJECTID", EAOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class> GetUnCompletedEpisodeActionsByEpisode(TTObjectContext objectContext, Guid EPISODE, Guid EAOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetUnCompletedEpisodeActionsByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("EAOBJECTID", EAOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetUnCompletedEpisodeActionsByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class> GetByEpisodeActionFilterExpressionReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByEpisodeActionFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class> GetByEpisodeActionFilterExpressionReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByEpisodeActionFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetByEpisodeActionFilterExpressionReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction> GetByFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<EpisodeAction.GetEndOfDayPoliclinicReport_Class> GetEndOfDayPoliclinicReport(DateTime ENDDATE, DateTime STARTDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEndOfDayPoliclinicReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEndOfDayPoliclinicReport_Class> GetEndOfDayPoliclinicReport(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEndOfDayPoliclinicReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEndOfDayPoliclinicReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetByEpisodeAndId(TTObjectContext objectContext, string EPISODE, IList<string> ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByEpisodeAndId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class> GetByEpisodeActionWorklistDateReport(DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByEpisodeActionWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class> GetByEpisodeActionWorklistDateReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByEpisodeActionWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetByEpisodeActionWorklistDateReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<EpisodeAction.GetEpisodeActionsCount_Class> GetEpisodeActionsCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<EpisodeAction.GetEpisodeActionsCount_Class> GetEpisodeActionsCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetByMasterAction_Class> GetByMasterAction(string MASTERACTIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONOBJECTID", MASTERACTIONOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetByMasterAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetByMasterAction_Class> GetByMasterAction(TTObjectContext objectContext, string MASTERACTIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONOBJECTID", MASTERACTIONOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetByMasterAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// EpisodeAction ı objectID ile get eder
    /// </summary>
        public static BindingList<EpisodeAction> GetEpisodeActionByID(TTObjectContext objectContext, string ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

    /// <summary>
    /// Episode daki Laboratuvar istek aşamasında olan episodeaction ları listeler.
    /// </summary>
        public static BindingList<EpisodeAction> GetLaboratoryRequestActionOfEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetLaboratoryRequestActionOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class> GetEHREpisodeActionSubactionProcedures(Guid PROCEDUREID, Guid EPISODEACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactionProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREID", PROCEDUREID);
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class> GetEHREpisodeActionSubactionProcedures(TTObjectContext objectContext, Guid PROCEDUREID, Guid EPISODEACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactionProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREID", PROCEDUREID);
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactionProcedures_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction> GetAllAnesthesiaConsultationOfEpisode(TTObjectContext objectContext, string EPISODEOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllAnesthesiaConsultationOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJECTID", EPISODEOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetPoliclinicAdmissionCount_Class> GetPoliclinicAdmissionCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPoliclinicAdmissionCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPoliclinicAdmissionCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetPoliclinicAdmissionCount_Class> GetPoliclinicAdmissionCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPoliclinicAdmissionCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPoliclinicAdmissionCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsByObjectIDs_Class> GetEpisodeActionsByObjectIDs(IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsByObjectIDs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsByObjectIDs_Class> GetEpisodeActionsByObjectIDs(TTObjectContext objectContext, IList<string> OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsByObjectIDs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionDiagnosis_Class> GetEHREpisodeActionDiagnosis(Guid EPISODEACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionDiagnosis_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionDiagnosis_Class> GetEHREpisodeActionDiagnosis(TTObjectContext objectContext, Guid EPISODEACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionDiagnosis_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction> GetExaminationsOfEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetExaminationsOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetConsFromOtherHospOfEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetConsFromOtherHospOfEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetAllAnesthesiaConsultationOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllAnesthesiaConsultationOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Geçmişi
    /// </summary>
        public static BindingList<EpisodeAction.GetOldInfoForEpisodeAction_Class> GetOldInfoForEpisodeAction(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetOldInfoForEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetOldInfoForEpisodeAction_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi
    /// </summary>
        public static BindingList<EpisodeAction.GetOldInfoForEpisodeAction_Class> GetOldInfoForEpisodeAction(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetOldInfoForEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetOldInfoForEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetEpisodeActionsOfPatientToInsertIntoQueue(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsOfPatientToInsertIntoQueue"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class> GetEHREpisodeActionSubactionMaterialsTotalAmount(Guid EPISODEACTIONID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactionMaterialsTotalAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class> GetEHREpisodeActionSubactionMaterialsTotalAmount(TTObjectContext objectContext, Guid EPISODEACTIONID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactionMaterialsTotalAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactionMaterialsTotalAmount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class> GetEHREpisodeActionSubactionProceduresTotalAmount(Guid EPISODEACTIONID, Guid PROCEDUREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactionProceduresTotalAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);
            paramList.Add("PROCEDUREID", PROCEDUREID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class> GetEHREpisodeActionSubactionProceduresTotalAmount(TTObjectContext objectContext, Guid EPISODEACTIONID, Guid PROCEDUREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEHREpisodeActionSubactionProceduresTotalAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTIONID", EPISODEACTIONID);
            paramList.Add("PROCEDUREID", PROCEDUREID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEHREpisodeActionSubactionProceduresTotalAmount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class> GetClinicStatisticsByDateDiagnosisAndPoliclinics(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, IList<string> DIAGNOSIS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetClinicStatisticsByDateDiagnosisAndPoliclinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class> GetClinicStatisticsByDateDiagnosisAndPoliclinics(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, IList<string> DIAGNOSIS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetClinicStatisticsByDateDiagnosisAndPoliclinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetClinicStatisticsByDateDiagnosisAndPoliclinics_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionByObjectID_Class> GetEpisodeActionByObjectID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionByObjectID_Class> GetEpisodeActionByObjectID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetAllExaminationsExceptCurrentExamination(TTObjectContext objectContext, Guid MASTERRESOURCE, string PATIENT, Guid OBJECTID, DateTime REQUESTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllExaminationsExceptCurrentExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("REQUESTDATE", REQUESTDATE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetAllDentalExaminationsOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllDentalExaminationsOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetPatientFolderEpisodeActions_Class> GetPatientFolderEpisodeActions(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPatientFolderEpisodeActions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPatientFolderEpisodeActions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetPatientFolderEpisodeActions_Class> GetPatientFolderEpisodeActions(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetPatientFolderEpisodeActions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetPatientFolderEpisodeActions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetOutPatientsByPatientObjectIDs(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PATIENTOBJECTIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetOutPatientsByPatientObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTOBJECTIDS", PATIENTOBJECTIDS);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetAllAnesthesiaConsultationOfSubEpisode(TTObjectContext objectContext, string SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllAnesthesiaConsultationOfSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetActionDetailNQLByEpisode_Class> GetActionDetailNQLByEpisode(Guid RESOURCE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetActionDetailNQLByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetActionDetailNQLByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetActionDetailNQLByEpisode_Class> GetActionDetailNQLByEpisode(TTObjectContext objectContext, Guid RESOURCE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetActionDetailNQLByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetActionDetailNQLByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class> GetEpisodeActionsGroupByHasApp(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsGroupByHasApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class> GetEpisodeActionsGroupByHasApp(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsGroupByHasApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsGroupByHasApp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class> DisTetkikIstemRaporByEpisodeActionNQL(Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["DisTetkikIstemRaporByEpisodeActionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class> DisTetkikIstemRaporByEpisodeActionNQL(TTObjectContext objectContext, Guid PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["DisTetkikIstemRaporByEpisodeActionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.DisTetkikIstemRaporByEpisodeActionNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsForPatientFolder_Class> GetEpisodeActionsForPatientFolder(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsForPatientFolder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpisodeActionsForPatientFolder_Class> GetEpisodeActionsForPatientFolder(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpisodeActionsForPatientFolder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpisodeActionsForPatientFolder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// GetSevkNQL
    /// </summary>
        public static BindingList<EpisodeAction.GetSevkNQL_Class> GetSevkNQL(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetSevkNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetSevkNQL_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// GetSevkNQL
    /// </summary>
        public static BindingList<EpisodeAction.GetSevkNQL_Class> GetSevkNQL(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetSevkNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetSevkNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQL_Class> GetStockEpisodeActionWorkListNQL(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> EPISODEOBJDEFIDS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetStockEpisodeActionWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODEOBJDEFIDS", EPISODEOBJDEFIDS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetStockEpisodeActionWorkListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQL_Class> GetStockEpisodeActionWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> EPISODEOBJDEFIDS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetStockEpisodeActionWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODEOBJDEFIDS", EPISODEOBJDEFIDS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetStockEpisodeActionWorkListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction> GetAllReportsOfPatientCancelled(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllReportsOfPatientCancelled"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class> GetEpicrisisPatientInfoByEpisodeAction(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpicrisisPatientInfoByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class> GetEpicrisisPatientInfoByEpisodeAction(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetEpicrisisPatientInfoByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetEpicrisisPatientInfoByEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EpisodeAction> GetAllReportsOfPatient(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllReportsOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetAllReportsOfSubEpisode(TTObjectContext objectContext, string SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetAllReportsOfSubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction> GetByObjectID(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<EpisodeAction>(queryDef, paramList);
        }

        public static BindingList<EpisodeAction.TestQuery1_Class> TestQuery1(DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["TestQuery1"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.TestQuery1_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.TestQuery1_Class> TestQuery1(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["TestQuery1"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<EpisodeAction.TestQuery1_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQLByID_Class> GetStockEpisodeActionWorkListNQLByID(IList<Guid> EPISODEOBJDEFIDS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetStockEpisodeActionWorkListNQLByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJDEFIDS", EPISODEOBJDEFIDS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetStockEpisodeActionWorkListNQLByID_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EpisodeAction.GetStockEpisodeActionWorkListNQLByID_Class> GetStockEpisodeActionWorkListNQLByID(TTObjectContext objectContext, IList<Guid> EPISODEOBJDEFIDS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].QueryDefs["GetStockEpisodeActionWorkListNQLByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJDEFIDS", EPISODEOBJDEFIDS);

            return TTReportNqlObject.QueryObjects<EpisodeAction.GetStockEpisodeActionWorkListNQLByID_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İşlemin İstendiği Tarihi Tutan Alandır
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// İşlemin Acil Olup Olmadığını Tutan Alandır
    /// </summary>
        public bool? Emergency
        {
            get { return (bool?)this["EMERGENCY"]; }
            set { this["EMERGENCY"] = value; }
        }

        public bool? PatientPay
        {
            get { return (bool?)this["PATIENTPAY"]; }
            set { this["PATIENTPAY"] = value; }
        }

    /// <summary>
    /// İş Listesinde filtrelerken hata vermemesi için konuldu.
    /// </summary>
        public string OrderObject
        {
            get { return (string)this["ORDEROBJECT"]; }
            set { this["ORDEROBJECT"] = value; }
        }

    /// <summary>
    /// İş Listesi Açıklama
    /// </summary>
        public string DescriptionForWorkList
        {
            get { return (string)this["DESCRIPTIONFORWORKLIST"]; }
            set { this["DESCRIPTIONFORWORKLIST"] = value; }
        }

        public bool? IgnoreEpisodeStateOnUpdate
        {
            get { return (bool?)this["IGNOREEPISODESTATEONUPDATE"]; }
            set { this["IGNOREEPISODESTATEONUPDATE"] = value; }
        }

    /// <summary>
    /// MHRS hastası olmayan kabullerde birim bazlı günlük artan numara
    /// </summary>
        public TTSequence AdmissionQueueNumber
        {
            get { return GetSequence("ADMISSIONQUEUENUMBER"); }
        }

    /// <summary>
    /// İşlemi Yapan İkincil Birimi Tutan Alandır
    /// </summary>
        public ResSection SecondaryMasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("SECONDARYMASTERRESOURCE"); }
            set { this["SECONDARYMASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan Birimin  Tutulduğu Alan
    /// </summary>
        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Başlatan Birimin Tutulduğu Alan
    /// </summary>
        public ResSection FromResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("FROMRESOURCE"); }
            set { this["FROMRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemin Yapan  Uzmanlık Dalı Bilgisinin Tutulduğu Alandır
    /// </summary>
        public SpecialityDefinition ProcedureSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("PROCEDURESPECIALITY"); }
            set { this["PROCEDURESPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemin Bağlı Olduğu Vaka
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşleme Bağlı Medula Hasta Kabul Nesnesi
    /// </summary>
        public PatientMedulaHastaKabul MedulaHastaKabul
        {
            get { return (PatientMedulaHastaKabul)((ITTObject)this).GetParent("MEDULAHASTAKABUL"); }
            set { this["MEDULAHASTAKABUL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlem Hasta Kabulden Başlatıldı İse Başlatıldığı Hasta Kabul Nesnesi
    /// </summary>
        public PatientAdmission PatientAdmission
        {
            get { return (PatientAdmission)((ITTObject)this).GetParent("PATIENTADMISSION"); }
            set { this["PATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Gerçekleştiren Doktor Nesnesini Taşıyan Alandır
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi gerçekleştiren teknisyen, operator vs. ilişkisi.
    /// </summary>
        public ResUser ProcedureByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREBYUSER"); }
            set { this["PROCEDUREBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubactionProceduresCollectionViews()
        {
            _SubactionProcedureFlowables = new SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection(_SubactionProcedures, "SubactionProcedureFlowables");
        }

        virtual protected void CreateSubactionProceduresCollection()
        {
            _SubactionProcedures = new SubActionProcedure.ChildSubActionProcedureCollection(this, new Guid("b649170f-2f25-4a8e-81ab-15714baec0f7"));
            CreateSubactionProceduresCollectionViews();
            ((ITTChildObjectCollection)_SubactionProcedures).GetChildren();
        }

        protected SubActionProcedure.ChildSubActionProcedureCollection _SubactionProcedures = null;
        public SubActionProcedure.ChildSubActionProcedureCollection SubactionProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _SubactionProcedures;
            }
        }

        private SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection _SubactionProcedureFlowables = null;
        public SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection SubactionProcedureFlowables
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _SubactionProcedureFlowables;
            }            
        }

        virtual protected void CreateVitalSignsCollectionViews()
        {
            _BloodPressures = new BloodPressure.ChildBloodPressureCollection(_VitalSigns, "BloodPressures");
            _Heights = new Height.ChildHeightCollection(_VitalSigns, "Heights");
            _Weights = new Weight.ChildWeightCollection(_VitalSigns, "Weights");
            _Temperatures = new Temperature.ChildTemperatureCollection(_VitalSigns, "Temperatures");
            _Pulses = new Pulse.ChildPulseCollection(_VitalSigns, "Pulses");
            _Respirations = new Respiration.ChildRespirationCollection(_VitalSigns, "Respirations");
            _SPO2s = new SPO2.ChildSPO2Collection(_VitalSigns, "SPO2s");
        }

        virtual protected void CreateVitalSignsCollection()
        {
            _VitalSigns = new VitalSign.ChildVitalSignCollection(this, new Guid("07977d77-d58c-417f-9676-a23b78e220cc"));
            CreateVitalSignsCollectionViews();
            ((ITTChildObjectCollection)_VitalSigns).GetChildren();
        }

        protected VitalSign.ChildVitalSignCollection _VitalSigns = null;
        public VitalSign.ChildVitalSignCollection VitalSigns
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _VitalSigns;
            }
        }

        private BloodPressure.ChildBloodPressureCollection _BloodPressures = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public BloodPressure.ChildBloodPressureCollection BloodPressures
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _BloodPressures;
            }            
        }

        private Height.ChildHeightCollection _Heights = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public Height.ChildHeightCollection Heights
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _Heights;
            }            
        }

        private Weight.ChildWeightCollection _Weights = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public Weight.ChildWeightCollection Weights
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _Weights;
            }            
        }

        private Temperature.ChildTemperatureCollection _Temperatures = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public Temperature.ChildTemperatureCollection Temperatures
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _Temperatures;
            }            
        }

        private Pulse.ChildPulseCollection _Pulses = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public Pulse.ChildPulseCollection Pulses
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _Pulses;
            }            
        }

        private Respiration.ChildRespirationCollection _Respirations = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public Respiration.ChildRespirationCollection Respirations
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _Respirations;
            }            
        }

        private SPO2.ChildSPO2Collection _SPO2s = null;
    /// <summary>
    /// Vital Bulgular
    /// </summary>
        public SPO2.ChildSPO2Collection SPO2s
        {
            get
            {
                if (_VitalSigns == null)
                    CreateVitalSignsCollection();
                return _SPO2s;
            }            
        }

        virtual protected void CreateComplaintsCollection()
        {
            _Complaints = new Complaint.ChildComplaintCollection(this, new Guid("9c894936-6d11-4600-a9c7-00d3d8c1210f"));
            ((ITTChildObjectCollection)_Complaints).GetChildren();
        }

        protected Complaint.ChildComplaintCollection _Complaints = null;
        public Complaint.ChildComplaintCollection Complaints
        {
            get
            {
                if (_Complaints == null)
                    CreateComplaintsCollection();
                return _Complaints;
            }
        }

        virtual protected void CreateDirectPurchaseGridsCollection()
        {
            _DirectPurchaseGrids = new DirectPurchaseGrid.ChildDirectPurchaseGridCollection(this, new Guid("2466c7ca-e98a-471d-956b-237eb197bd5a"));
            ((ITTChildObjectCollection)_DirectPurchaseGrids).GetChildren();
        }

        protected DirectPurchaseGrid.ChildDirectPurchaseGridCollection _DirectPurchaseGrids = null;
        public DirectPurchaseGrid.ChildDirectPurchaseGridCollection DirectPurchaseGrids
        {
            get
            {
                if (_DirectPurchaseGrids == null)
                    CreateDirectPurchaseGridsCollection();
                return _DirectPurchaseGrids;
            }
        }

        virtual protected void CreateExaminationMeasesCollection()
        {
            _ExaminationMeases = new ExaminationMeasGrid.ChildExaminationMeasGridCollection(this, new Guid("3de53d69-dc11-4f33-9a2b-8f1775128a1f"));
            ((ITTChildObjectCollection)_ExaminationMeases).GetChildren();
        }

        protected ExaminationMeasGrid.ChildExaminationMeasGridCollection _ExaminationMeases = null;
        public ExaminationMeasGrid.ChildExaminationMeasGridCollection ExaminationMeases
        {
            get
            {
                if (_ExaminationMeases == null)
                    CreateExaminationMeasesCollection();
                return _ExaminationMeases;
            }
        }

        virtual protected void CreateNumaratorAppointmentsCollection()
        {
            _NumaratorAppointments = new Appointment.ChildAppointmentCollection(this, new Guid("7fbf0ff0-cfa4-4450-9a8e-807684ff9752"));
            ((ITTChildObjectCollection)_NumaratorAppointments).GetChildren();
        }

        protected Appointment.ChildAppointmentCollection _NumaratorAppointments = null;
    /// <summary>
    /// Child collection for Numaratör sistemi için kullanılan appointmentlar ile  ilgili Episode Action bağlantısı
    /// </summary>
        public Appointment.ChildAppointmentCollection NumaratorAppointments
        {
            get
            {
                if (_NumaratorAppointments == null)
                    CreateNumaratorAppointmentsCollection();
                return _NumaratorAppointments;
            }
        }

        virtual protected void CreateTreatmentMaterialsCollectionViews()
        {
        }

        virtual protected void CreateTreatmentMaterialsCollection()
        {
            _TreatmentMaterials = new BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection(this, new Guid("e05ee8c2-a747-4650-9daf-4e6426d78be2"));
            CreateTreatmentMaterialsCollectionViews();
            ((ITTChildObjectCollection)_TreatmentMaterials).GetChildren();
        }

        protected BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection _TreatmentMaterials = null;
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection TreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _TreatmentMaterials;
            }
        }

        virtual protected void CreateQueueItemsCollection()
        {
            _QueueItems = new ExaminationQueueItem.ChildExaminationQueueItemCollection(this, new Guid("095a9c01-0569-42e4-a74d-288d2762e58c"));
            ((ITTChildObjectCollection)_QueueItems).GetChildren();
        }

        protected ExaminationQueueItem.ChildExaminationQueueItemCollection _QueueItems = null;
        public ExaminationQueueItem.ChildExaminationQueueItemCollection QueueItems
        {
            get
            {
                if (_QueueItems == null)
                    CreateQueueItemsCollection();
                return _QueueItems;
            }
        }

        virtual protected void CreateAccountingProcessEpisodeActionsCollection()
        {
            _AccountingProcessEpisodeActions = new AccountingProcessAction.ChildAccountingProcessActionCollection(this, new Guid("de508438-2df2-410e-88cd-e5eff3864c81"));
            ((ITTChildObjectCollection)_AccountingProcessEpisodeActions).GetChildren();
        }

        protected AccountingProcessAction.ChildAccountingProcessActionCollection _AccountingProcessEpisodeActions = null;
        public AccountingProcessAction.ChildAccountingProcessActionCollection AccountingProcessEpisodeActions
        {
            get
            {
                if (_AccountingProcessEpisodeActions == null)
                    CreateAccountingProcessEpisodeActionsCollection();
                return _AccountingProcessEpisodeActions;
            }
        }

        virtual protected void CreateInPatientPhysicianProgressesCollection()
        {
            _InPatientPhysicianProgresses = new InPatientPhysicianProgresses.ChildInPatientPhysicianProgressesCollection(this, new Guid("68c3d088-fb63-4321-aeab-23e95f0c2c23"));
            ((ITTChildObjectCollection)_InPatientPhysicianProgresses).GetChildren();
        }

        protected InPatientPhysicianProgresses.ChildInPatientPhysicianProgressesCollection _InPatientPhysicianProgresses = null;
    /// <summary>
    /// Child collection for Giriş yapıldığı episodeAction (Kilinik doktor işlemleri yada  Epikriz olabilir )
    /// </summary>
        public InPatientPhysicianProgresses.ChildInPatientPhysicianProgressesCollection InPatientPhysicianProgresses
        {
            get
            {
                if (_InPatientPhysicianProgresses == null)
                    CreateInPatientPhysicianProgressesCollection();
                return _InPatientPhysicianProgresses;
            }
        }

        virtual protected void CreateInPatientRtfBySpecialitiesCollection()
        {
            _InPatientRtfBySpecialities = new InPatientRtfBySpeciality.ChildInPatientRtfBySpecialityCollection(this, new Guid("a4f7ccd4-dc90-4aa7-a58c-60a9421e6638"));
            ((ITTChildObjectCollection)_InPatientRtfBySpecialities).GetChildren();
        }

        protected InPatientRtfBySpeciality.ChildInPatientRtfBySpecialityCollection _InPatientRtfBySpecialities = null;
        public InPatientRtfBySpeciality.ChildInPatientRtfBySpecialityCollection InPatientRtfBySpecialities
        {
            get
            {
                if (_InPatientRtfBySpecialities == null)
                    CreateInPatientRtfBySpecialitiesCollection();
                return _InPatientRtfBySpecialities;
            }
        }

        virtual protected void CreateENabizCollection()
        {
            _ENabiz = new ENabiz.ChildENabizCollection(this, new Guid("763e0576-6946-4a2a-b6a3-085f1358117b"));
            ((ITTChildObjectCollection)_ENabiz).GetChildren();
        }

        protected ENabiz.ChildENabizCollection _ENabiz = null;
        public ENabiz.ChildENabizCollection ENabiz
        {
            get
            {
                if (_ENabiz == null)
                    CreateENabizCollection();
                return _ENabiz;
            }
        }

        virtual protected void CreateReportDiagnosisCollection()
        {
            _ReportDiagnosis = new ReportDiagnosis.ChildReportDiagnosisCollection(this, new Guid("018df247-b83f-4da1-be97-0376d31b5176"));
            ((ITTChildObjectCollection)_ReportDiagnosis).GetChildren();
        }

        protected ReportDiagnosis.ChildReportDiagnosisCollection _ReportDiagnosis = null;
        public ReportDiagnosis.ChildReportDiagnosisCollection ReportDiagnosis
        {
            get
            {
                if (_ReportDiagnosis == null)
                    CreateReportDiagnosisCollection();
                return _ReportDiagnosis;
            }
        }

        virtual protected void CreateLinkedDentalConsultationsCollection()
        {
            _LinkedDentalConsultations = new PhysicianApplication.ChildPhysicianApplicationCollection(this, new Guid("3c393aa6-f7e1-4c72-9a4b-1dd1883766c6"));
            ((ITTChildObjectCollection)_LinkedDentalConsultations).GetChildren();
        }

        protected PhysicianApplication.ChildPhysicianApplicationCollection _LinkedDentalConsultations = null;
        public PhysicianApplication.ChildPhysicianApplicationCollection LinkedDentalConsultations
        {
            get
            {
                if (_LinkedDentalConsultations == null)
                    CreateLinkedDentalConsultationsCollection();
                return _LinkedDentalConsultations;
            }
        }

        virtual protected void CreateBaseMultipleDataEntriesCollectionViews()
        {
        }

        virtual protected void CreateBaseMultipleDataEntriesCollection()
        {
            _BaseMultipleDataEntries = new BaseMultipleDataEntry.ChildBaseMultipleDataEntryCollection(this, new Guid("ae098bf3-6c71-4198-a147-3c27fc9f43c1"));
            CreateBaseMultipleDataEntriesCollectionViews();
            ((ITTChildObjectCollection)_BaseMultipleDataEntries).GetChildren();
        }

        protected BaseMultipleDataEntry.ChildBaseMultipleDataEntryCollection _BaseMultipleDataEntries = null;
        public BaseMultipleDataEntry.ChildBaseMultipleDataEntryCollection BaseMultipleDataEntries
        {
            get
            {
                if (_BaseMultipleDataEntries == null)
                    CreateBaseMultipleDataEntriesCollection();
                return _BaseMultipleDataEntries;
            }
        }

        virtual protected void CreatePhysiotherapyTreatmentNotesCollection()
        {
            _PhysiotherapyTreatmentNotes = new PhysiotherapyTreatmentNote.ChildPhysiotherapyTreatmentNoteCollection(this, new Guid("f30e1e5d-cf51-44df-a3e3-bc9f60f85b66"));
            ((ITTChildObjectCollection)_PhysiotherapyTreatmentNotes).GetChildren();
        }

        protected PhysiotherapyTreatmentNote.ChildPhysiotherapyTreatmentNoteCollection _PhysiotherapyTreatmentNotes = null;
        public PhysiotherapyTreatmentNote.ChildPhysiotherapyTreatmentNoteCollection PhysiotherapyTreatmentNotes
        {
            get
            {
                if (_PhysiotherapyTreatmentNotes == null)
                    CreatePhysiotherapyTreatmentNotesCollection();
                return _PhysiotherapyTreatmentNotes;
            }
        }

        virtual protected void CreateEpisodeActionSMSInfosCollection()
        {
            _EpisodeActionSMSInfos = new EpisodeActionSMSInfo.ChildEpisodeActionSMSInfoCollection(this, new Guid("977ef875-615e-46f7-8363-5803f6c70871"));
            ((ITTChildObjectCollection)_EpisodeActionSMSInfos).GetChildren();
        }

        protected EpisodeActionSMSInfo.ChildEpisodeActionSMSInfoCollection _EpisodeActionSMSInfos = null;
        public EpisodeActionSMSInfo.ChildEpisodeActionSMSInfoCollection EpisodeActionSMSInfos
        {
            get
            {
                if (_EpisodeActionSMSInfos == null)
                    CreateEpisodeActionSMSInfosCollection();
                return _EpisodeActionSMSInfos;
            }
        }

        protected EpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACTION", dataRow) { }
        protected EpisodeAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACTION", dataRow, isImported) { }
        protected EpisodeAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeAction() : base() { }

    }
}