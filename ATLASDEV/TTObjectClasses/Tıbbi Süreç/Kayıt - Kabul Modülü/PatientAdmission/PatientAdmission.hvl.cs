
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAdmission")] 

    public  partial class PatientAdmission : BaseAction, IWorkListPatientAdmission, IEpisodeCreation, IOAPatientAdmission, IOldActions, ICreateSubEpisode
    {
        public class PatientAdmissionList : TTObjectCollection<PatientAdmission> { }
                    
        public class ChildPatientAdmissionCollection : TTObject.TTChildObjectCollection<PatientAdmission>
        {
            public ChildPatientAdmissionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAdmissionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAdressInfoNotExists_Class : TTReportNqlObject 
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

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAdressInfoNotExists_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdressInfoNotExists_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdressInfoNotExists_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProvisionNumberNotExists_Class : TTReportNqlObject 
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

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProvisionNumberNotExists_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProvisionNumberNotExists_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProvisionNumberNotExists_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientAdmissionsCount_Class : TTReportNqlObject 
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

            public GetPatientAdmissionsCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientAdmissionsCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientAdmissionsCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPADetails_Class : TTReportNqlObject 
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

            public string OtherBirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERBIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["OTHERBIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CountryOfBirth
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["COUNTRYOFBIRTH"]);
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

            public Guid? PatientAddress
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTADDRESS"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Email
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DispatchTypeEnum? DispatchType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DISPATCHTYPE"].DataType;
                    return (DispatchTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsFiresFromPACorrection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISFIRESFROMPACORRECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ISFIRESFROMPACORRECTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCorrected
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCORRECTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ISCORRECTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ProvisionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVISIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PROVISIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DocumentNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Arrested
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRESTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ARRESTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public AdmissionStatusEnum? AdmissionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ADMISSIONSTATUS"].DataType;
                    return (AdmissionStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public WhoPaysEnum? HCModeOfPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HCMODEOFPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["HCMODEOFPAYMENT"].DataType;
                    return (WhoPaysEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? RealDisabled
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REALDISABLED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["REALDISABLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Sevkli
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKLI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["SEVKLI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string takipAlCevap
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPALCEVAP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["TAKIPALCEVAP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string takipAlHataMesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAKIPALHATAMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["TAKIPALHATAMESAJI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelatedProvision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATEDPROVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["RELATEDPROVISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Donor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DONOR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DispatchedConsultationDef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEDCONSULTATIONDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DISPATCHEDCONSULTATIONDEF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PAStatusEnum? PAStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PASTATUS"].DataType;
                    return (PAStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsNewBorn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNEWBORN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ISNEWBORN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Sevkli112
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKLI112"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["SEVKLI112"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Emergency112RefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY112REFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["EMERGENCY112REFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ImportantPAInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMPORTANTPAINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["IMPORTANTPAINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ResultQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["RESULTQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? DispatchEmergencyCons
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPATCHEMERGENCYCONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DISPATCHEMERGENCYCONS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string BeneficiaryName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["BENEFICIARYNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BeneficiaryUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARYUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["BENEFICIARYUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? DeathApplication
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATHAPPLICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["DEATHAPPLICATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? PatientClassGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTCLASSGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? ApplicationReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? MedulaVakaTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAVAKATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["MEDULAVAKATARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string SevkEdenDoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKEDENDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["SEVKEDENDOKTOR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KurumSevkTalepNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUMSEVKTALEPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["KURUMSEVKTALEPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPADetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPADetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPADetails_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_AdliVaka_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public Guid? Kabultur
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KABULTUR"]);
                }
            }

            public OLAP_AdliVaka_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_AdliVaka_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_AdliVaka_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutPatientEtiquette_Class : TTReportNqlObject 
        {
            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Protokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNO"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Dogumyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERI"]);
                }
            }

            public DateTime? Dogumtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetOutPatientEtiquette_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPatientEtiquette_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPatientEtiquette_Class() : base() { }
        }

        [Serializable] 

        public partial class GetForeignPatientsNQL_Class : TTReportNqlObject 
        {
            public string Isim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Hprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetForeignPatientsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForeignPatientsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForeignPatientsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMAPByCountryAndDate_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public Object Kimlikdogumyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KIMLIKDOGUMYERI"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
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

            public double? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
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

            public DateTime? Kayittarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAYITTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Uzmanlikdali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANLIKDALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Toplamfiyat
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAMFIYAT"]);
                }
            }

            public GetMAPByCountryAndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMAPByCountryAndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMAPByCountryAndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientAdmissionByFilterExpression_Class : TTReportNqlObject 
        {
            public Object Patientobjectid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public GetPatientAdmissionByFilterExpression_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientAdmissionByFilterExpression_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientAdmissionByFilterExpression_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_ILETISIM_Class : TTReportNqlObject 
        {
            public Guid? Hasta_iletisim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_ILETISIM_KODU"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Object Adres_tipi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES_TIPI"]);
                }
            }

            public Object Adres_kodu_seviyesi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES_KODU_SEVIYESI"]);
                }
            }

            public Object Beyan_adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BEYAN_ADRES"]);
                }
            }

            public Object Nvi_adres
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NVI_ADRES"]);
                }
            }

            public Object Adres_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADRES_NUMARASI"]);
                }
            }

            public Object Il_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IL_KODU"]);
                }
            }

            public Object Ilce_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ILCE_KODU"]);
                }
            }

            public Object Csbm_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CSBM_KODU"]);
                }
            }

            public Object Ev_telefonu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EV_TELEFONU"]);
                }
            }

            public Object Cep_telefonu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CEP_TELEFONU"]);
                }
            }

            public string Eposta_adresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPOSTA_ADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HASTA_ILETISIM_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_ILETISIM_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_ILETISIM_Class() : base() { }
        }

        [Serializable] 

        public partial class HasSameReceptionForSameReason_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public HasSameReceptionForSameReason_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HasSameReceptionForSameReason_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HasSameReceptionForSameReason_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPAdmissionEK8InformationByObjectID_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Ceptelefonu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CEPTELEFONU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Evadresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yakinadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YAKINADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["RELATIVEFULLNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yakinevadresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YAKINEVADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["RELATIVEHOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yakincepnumarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YAKINCEPNUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["RELATIVEMOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PayerTypeEnum? PayerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["PAYERTYPE"].DataType;
                    return (PayerTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPAdmissionEK8InformationByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPAdmissionEK8InformationByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPAdmissionEK8InformationByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Refno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Doktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["EMERGENCY112REFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Gelissebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GELISSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaxResultQueueByPol_Class : TTReportNqlObject 
        {
            public Object Maximumqueuenum
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAXIMUMQUEUENUM"]);
                }
            }

            public GetMaxResultQueueByPol_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaxResultQueueByPol_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaxResultQueueByPol_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

    /// <summary>
    /// İletişim Bilgisi Eksik Olan Hasta Listesi
    /// </summary>
        public static BindingList<PatientAdmission.GetAdressInfoNotExists_Class> GetAdressInfoNotExists(DateTime STARTDATE, DateTime ENDDATE, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetAdressInfoNotExists"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetAdressInfoNotExists_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İletişim Bilgisi Eksik Olan Hasta Listesi
    /// </summary>
        public static BindingList<PatientAdmission.GetAdressInfoNotExists_Class> GetAdressInfoNotExists(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetAdressInfoNotExists"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetAdressInfoNotExists_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Provizyon Numarası Olmayan Hasta Listesi
    /// </summary>
        public static BindingList<PatientAdmission.GetProvisionNumberNotExists_Class> GetProvisionNumberNotExists(DateTime STARTDATE, DateTime ENDDATE, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetProvisionNumberNotExists"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetProvisionNumberNotExists_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Provizyon Numarası Olmayan Hasta Listesi
    /// </summary>
        public static BindingList<PatientAdmission.GetProvisionNumberNotExists_Class> GetProvisionNumberNotExists(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> RESOURCE, int RESOURCEFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetProvisionNumberNotExists"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("RESOURCEFLAG", RESOURCEFLAG);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetProvisionNumberNotExists_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<PatientAdmission.GetPatientAdmissionsCount_Class> GetPatientAdmissionsCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPatientAdmissionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPatientAdmissionsCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem Sayıları
    /// </summary>
        public static BindingList<PatientAdmission.GetPatientAdmissionsCount_Class> GetPatientAdmissionsCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPatientAdmissionsCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPatientAdmissionsCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPADetails_Class> GetPADetails(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPADetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPADetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPADetails_Class> GetPADetails(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPADetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPADetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission> CloseDailyAdmisnsAfter24(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["CloseDailyAdmisnsAfter24"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmission>(queryDef, paramList);
        }

        public static BindingList<PatientAdmission.OLAP_AdliVaka_Class> OLAP_AdliVaka(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["OLAP_AdliVaka"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.OLAP_AdliVaka_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.OLAP_AdliVaka_Class> OLAP_AdliVaka(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["OLAP_AdliVaka"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.OLAP_AdliVaka_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission> GetByStartAndEndDates(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetByStartAndEndDates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmission>(queryDef, paramList);
        }

    /// <summary>
    /// Ayaktan Hasta Etiketi
    /// </summary>
        public static BindingList<PatientAdmission.GetOutPatientEtiquette_Class> GetOutPatientEtiquette(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetOutPatientEtiquette"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetOutPatientEtiquette_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Ayaktan Hasta Etiketi
    /// </summary>
        public static BindingList<PatientAdmission.GetOutPatientEtiquette_Class> GetOutPatientEtiquette(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetOutPatientEtiquette"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetOutPatientEtiquette_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetForeignPatientsNQL_Class> GetForeignPatientsNQL(DateTime ACTIONSTARTDATE, DateTime ACTIONENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetForeignPatientsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONSTARTDATE", ACTIONSTARTDATE);
            paramList.Add("ACTIONENDDATE", ACTIONENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetForeignPatientsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetForeignPatientsNQL_Class> GetForeignPatientsNQL(TTObjectContext objectContext, DateTime ACTIONSTARTDATE, DateTime ACTIONENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetForeignPatientsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONSTARTDATE", ACTIONSTARTDATE);
            paramList.Add("ACTIONENDDATE", ACTIONENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetForeignPatientsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetMAPByCountryAndDate_Class> GetMAPByCountryAndDate(DateTime STARTDATE, DateTime ENDDATE, string MAINSPECIALITY, int MAINSPECIALITYFLAG, int INPATIENTFLAG, int OUTPATIENTFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetMAPByCountryAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MAINSPECIALITY", MAINSPECIALITY);
            paramList.Add("MAINSPECIALITYFLAG", MAINSPECIALITYFLAG);
            paramList.Add("INPATIENTFLAG", INPATIENTFLAG);
            paramList.Add("OUTPATIENTFLAG", OUTPATIENTFLAG);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetMAPByCountryAndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetMAPByCountryAndDate_Class> GetMAPByCountryAndDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string MAINSPECIALITY, int MAINSPECIALITYFLAG, int INPATIENTFLAG, int OUTPATIENTFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetMAPByCountryAndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MAINSPECIALITY", MAINSPECIALITY);
            paramList.Add("MAINSPECIALITYFLAG", MAINSPECIALITYFLAG);
            paramList.Add("INPATIENTFLAG", INPATIENTFLAG);
            paramList.Add("OUTPATIENTFLAG", OUTPATIENTFLAG);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetMAPByCountryAndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPatientAdmissionByFilterExpression_Class> GetPatientAdmissionByFilterExpression(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPatientAdmissionByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPatientAdmissionByFilterExpression_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientAdmission.GetPatientAdmissionByFilterExpression_Class> GetPatientAdmissionByFilterExpression(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPatientAdmissionByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPatientAdmissionByFilterExpression_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientAdmission> GetByDateAndPatients(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> PATIENTGUIDS, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetByDateAndPatients"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTGUIDS", PATIENTGUIDS);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmission>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PatientAdmission.VEM_HASTA_ILETISIM_Class> VEM_HASTA_ILETISIM(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["VEM_HASTA_ILETISIM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientAdmission.VEM_HASTA_ILETISIM_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.VEM_HASTA_ILETISIM_Class> VEM_HASTA_ILETISIM(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["VEM_HASTA_ILETISIM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientAdmission.VEM_HASTA_ILETISIM_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission> GetLastPatientAdmission(TTObjectContext objectContext, Guid OBJECTID, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetLastPatientAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmission>(queryDef, paramList);
        }

        public static BindingList<PatientAdmission> GetLastPatientAdmissionByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetLastPatientAdmissionByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmission>(queryDef, paramList);
        }

        public static BindingList<PatientAdmission.HasSameReceptionForSameReason_Class> HasSameReceptionForSameReason(Guid Reason, Guid PatientID, int DayLimit, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["HasSameReceptionForSameReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REASON", Reason);
            paramList.Add("PATIENTID", PatientID);
            paramList.Add("DAYLIMIT", DayLimit);

            return TTReportNqlObject.QueryObjects<PatientAdmission.HasSameReceptionForSameReason_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.HasSameReceptionForSameReason_Class> HasSameReceptionForSameReason(TTObjectContext objectContext, Guid Reason, Guid PatientID, int DayLimit, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["HasSameReceptionForSameReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REASON", Reason);
            paramList.Add("PATIENTID", PatientID);
            paramList.Add("DAYLIMIT", DayLimit);

            return TTReportNqlObject.QueryObjects<PatientAdmission.HasSameReceptionForSameReason_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class> GetPAdmissionEK8InformationByObjectID(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPAdmissionEK8InformationByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class> GetPAdmissionEK8InformationByObjectID(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPAdmissionEK8InformationByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPAdmissionEK8InformationByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPatientList_Class> GetPatientList(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPatientList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission.GetPatientList_Class> GetPatientList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetPatientList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// bu birim ve doctora ait bugünkü en son sonuç sıra numarasını döner
    /// </summary>
        public static BindingList<PatientAdmission.GetMaxResultQueueByPol_Class> GetMaxResultQueueByPol(Guid POLICLINIC, Guid DOCTOR, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetMaxResultQueueByPol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINIC", POLICLINIC);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetMaxResultQueueByPol_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// bu birim ve doctora ait bugünkü en son sonuç sıra numarasını döner
    /// </summary>
        public static BindingList<PatientAdmission.GetMaxResultQueueByPol_Class> GetMaxResultQueueByPol(TTObjectContext objectContext, Guid POLICLINIC, Guid DOCTOR, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetMaxResultQueueByPol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINIC", POLICLINIC);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<PatientAdmission.GetMaxResultQueueByPol_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientAdmission> GetDataForHospitalInformation(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].QueryDefs["GetDataForHospitalInformation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientAdmission>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Eposta
    /// </summary>
        public string Email
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Sevkli tetkik türü
    /// </summary>
        public DispatchTypeEnum? DispatchType
        {
            get { return (DispatchTypeEnum?)(int?)this["DISPATCHTYPE"]; }
            set { this["DISPATCHTYPE"] = value; }
        }

    /// <summary>
    /// hasta kabul düzeltmeden başlatıldı
    /// </summary>
        public bool? IsFiresFromPACorrection
        {
            get { return (bool?)this["ISFIRESFROMPACORRECTION"]; }
            set { this["ISFIRESFROMPACORRECTION"] = value; }
        }

    /// <summary>
    /// Hasta Habul düzeltme yapıldı ve iptal edildi
    /// </summary>
        public bool? IsCorrected
        {
            get { return (bool?)this["ISCORRECTED"]; }
            set { this["ISCORRECTED"] = value; }
        }

        public string ProvisionNo
        {
            get { return (string)this["PROVISIONNO"]; }
            set { this["PROVISIONNO"] = value; }
        }

    /// <summary>
    /// Evrak Sayısı
    /// </summary>
        public string DocumentNumber
        {
            get { return (string)this["DOCUMENTNUMBER"]; }
            set { this["DOCUMENTNUMBER"] = value; }
        }

    /// <summary>
    /// Tutuklu
    /// </summary>
        public bool? Arrested
        {
            get { return (bool?)this["ARRESTED"]; }
            set { this["ARRESTED"] = value; }
        }

    /// <summary>
    /// Evrak Tarihi
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Kabul Durum
    /// </summary>
        public AdmissionStatusEnum? AdmissionStatus
        {
            get { return (AdmissionStatusEnum?)(int?)this["ADMISSIONSTATUS"]; }
            set { this["ADMISSIONSTATUS"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Ödeme Türü
    /// </summary>
        public WhoPaysEnum? HCModeOfPayment
        {
            get { return (WhoPaysEnum?)(int?)this["HCMODEOFPAYMENT"]; }
            set { this["HCMODEOFPAYMENT"] = value; }
        }

    /// <summary>
    /// Engelli
    /// </summary>
        public bool? RealDisabled
        {
            get { return (bool?)this["REALDISABLED"]; }
            set { this["REALDISABLED"] = value; }
        }

    /// <summary>
    /// Sevkli
    /// </summary>
        public bool? Sevkli
        {
            get { return (bool?)this["SEVKLI"]; }
            set { this["SEVKLI"] = value; }
        }

    /// <summary>
    /// takipAlCevap
    /// </summary>
        public string takipAlCevap
        {
            get { return (string)this["TAKIPALCEVAP"]; }
            set { this["TAKIPALCEVAP"] = value; }
        }

    /// <summary>
    /// takipAlHataMesajı
    /// </summary>
        public string takipAlHataMesaji
        {
            get { return (string)this["TAKIPALHATAMESAJI"]; }
            set { this["TAKIPALHATAMESAJI"] = value; }
        }

        public string MedulaESevkNo
        {
            get { return (string)this["MEDULAESEVKNO"]; }
            set { this["MEDULAESEVKNO"] = value; }
        }

    /// <summary>
    /// Bağlı Takip No
    /// </summary>
        public string RelatedProvision
        {
            get { return (string)this["RELATEDPROVISION"]; }
            set { this["RELATEDPROVISION"] = value; }
        }

    /// <summary>
    /// Donor
    /// </summary>
        public bool? Donor
        {
            get { return (bool?)this["DONOR"]; }
            set { this["DONOR"] = value; }
        }

    /// <summary>
    /// Sevkli Konsültasyon Açıklaması
    /// </summary>
        public string DispatchedConsultationDef
        {
            get { return (string)this["DISPATCHEDCONSULTATIONDEF"]; }
            set { this["DISPATCHEDCONSULTATIONDEF"] = value; }
        }

    /// <summary>
    /// Kabul Durumu
    /// </summary>
        public PAStatusEnum? PAStatus
        {
            get { return (PAStatusEnum?)(int?)this["PASTATUS"]; }
            set { this["PASTATUS"] = value; }
        }

    /// <summary>
    /// Hastanın Yeni Doğan Olup Olmadığı Bilgisinin Tutulduğu Alandır
    /// </summary>
        public bool? IsNewBorn
        {
            get { return (bool?)this["ISNEWBORN"]; }
            set { this["ISNEWBORN"] = value; }
        }

    /// <summary>
    /// 112 Sevkli
    /// </summary>
        public bool? Sevkli112
        {
            get { return (bool?)this["SEVKLI112"]; }
            set { this["SEVKLI112"] = value; }
        }

    /// <summary>
    /// 112 Referans No
    /// </summary>
        public string Emergency112RefNo
        {
            get { return (string)this["EMERGENCY112REFNO"]; }
            set { this["EMERGENCY112REFNO"] = value; }
        }

    /// <summary>
    /// Kabule Ait Önemli Bilgilerin Tutulduğu Alandır
    /// </summary>
        public object ImportantPAInfo
        {
            get { return (object)this["IMPORTANTPAINFO"]; }
            set { this["IMPORTANTPAINFO"] = value; }
        }

    /// <summary>
    /// Sonuç Sıra No
    /// </summary>
        public TTSequence ResultQueueNumber
        {
            get { return GetSequence("RESULTQUEUENUMBER"); }
        }

    /// <summary>
    /// Acil sevkli konsültasyon mu
    /// </summary>
        public bool? DispatchEmergencyCons
        {
            get { return (bool?)this["DISPATCHEMERGENCYCONS"]; }
            set { this["DISPATCHEMERGENCYCONS"] = value; }
        }

    /// <summary>
    /// Hak Sahibinin Adı
    /// </summary>
        public string BeneficiaryName
        {
            get { return (string)this["BENEFICIARYNAME"]; }
            set { this["BENEFICIARYNAME"] = value; }
        }

    /// <summary>
    /// Hak sahibinin TC Kimlik numarası
    /// </summary>
        public long? BeneficiaryUniqueRefNo
        {
            get { return (long?)this["BENEFICIARYUNIQUEREFNO"]; }
            set { this["BENEFICIARYUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// Kişinin XXXXXXye ölü getirilip getirilmediğini tutan bilgi
    /// </summary>
        public bool? DeathApplication
        {
            get { return (bool?)this["DEATHAPPLICATION"]; }
            set { this["DEATHAPPLICATION"] = value; }
        }

    /// <summary>
    /// MHRS hastası olmayan kabullerde birim bazlı günlük artan numara
    /// </summary>
        public TTSequence AdmissionQueueNumber
        {
            get { return GetSequence("ADMISSIONQUEUENUMBER"); }
        }

    /// <summary>
    /// Hasta Statü
    /// </summary>
        public PatientClassTypeEnum? PatientClassGroup
        {
            get { return (PatientClassTypeEnum?)(int?)this["PATIENTCLASSGROUP"]; }
            set { this["PATIENTCLASSGROUP"] = value; }
        }

    /// <summary>
    /// Başvuru Sebebi
    /// </summary>
        public ApplicationReasonEnum? ApplicationReason
        {
            get { return (ApplicationReasonEnum?)(int?)this["APPLICATIONREASON"]; }
            set { this["APPLICATIONREASON"] = value; }
        }

        public DateTime? MedulaVakaTarihi
        {
            get { return (DateTime?)this["MEDULAVAKATARIHI"]; }
            set { this["MEDULAVAKATARIHI"] = value; }
        }

    /// <summary>
    /// Kayıt Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Sevkli Gönderen Doktor
    /// </summary>
        public string SevkEdenDoktor
        {
            get { return (string)this["SEVKEDENDOKTOR"]; }
            set { this["SEVKEDENDOKTOR"] = value; }
        }

    /// <summary>
    /// Geliş Sebebi Kurum Sevk Olanlar İçin
    /// </summary>
        public string KurumSevkTalepNo
        {
            get { return (string)this["KURUMSEVKTALEPNO"]; }
            set { this["KURUMSEVKTALEPNO"] = value; }
        }

    /// <summary>
    /// Episode_PatientAdmission
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Arşivi kaydeden kullanıcıyı tutan alan
    /// </summary>
        public ResUser RecordUserID
        {
            get { return (ResUser)((ITTObject)this).GetParent("RECORDUSERID"); }
            set { this["RECORDUSERID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Protokol
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HCRequestReason HCRequestReason
        {
            get { return (HCRequestReason)((ITTObject)this).GetParent("HCREQUESTREASON"); }
            set { this["HCREQUESTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Borçlu
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Olay afet bilgisi
    /// </summary>
        public SKRSOlayAfetBilgisi SKRSOlayAfetBilgisi
        {
            get { return (SKRSOlayAfetBilgisi)((ITTObject)this).GetParent("SKRSOLAYAFETBILGISI"); }
            set { this["SKRSOLAYAFETBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Afet olay vatandaş tipi
    /// </summary>
        public SKRSAFETOLAYVATANDASTIPI SKRSVatandasTipi
        {
            get { return (SKRSAFETOLAYVATANDASTIPI)((ITTObject)this).GetParent("SKRSVATANDASTIPI"); }
            set { this["SKRSVATANDASTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Öcelik Durumu
    /// </summary>
        public PriorityStatusDefinition PriorityStatus
        {
            get { return (PriorityStatusDefinition)((ITTObject)this).GetParent("PRIORITYSTATUS"); }
            set { this["PRIORITYSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SigortaliTuru MedulaSigortaliTuru
        {
            get { return (SigortaliTuru)((ITTObject)this).GetParent("MEDULASIGORTALITURU"); }
            set { this["MEDULASIGORTALITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kabulün adres bilgisinin tutulduğu alan
    /// </summary>
        public PatientIdentityAndAddress PA_Address
        {
            get { return (PatientIdentityAndAddress)((ITTObject)this).GetParent("PA_ADDRESS"); }
            set { this["PA_ADDRESS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Kabul Randevusu
    /// </summary>
        public AdmissionAppointment AdmissionAppointment
        {
            get { return (AdmissionAppointment)((ITTObject)this).GetParent("ADMISSIONAPPOINTMENT"); }
            set { this["ADMISSIONAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kabul alınan branşın bağlı olduğu bina bilgisi
    /// </summary>
        public ResBuilding Building
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("BUILDING"); }
            set { this["BUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kabul alınan birim
    /// </summary>
        public ResPoliclinic Policlinic
        {
            get { return (ResPoliclinic)((ITTObject)this).GetParent("POLICLINIC"); }
            set { this["POLICLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MedulaHastaKabul
    /// </summary>
        public PatientMedulaHastaKabul PatientMedulaHastaKabul
        {
            get { return (PatientMedulaHastaKabul)((ITTObject)this).GetParent("PATIENTMEDULAHASTAKABUL"); }
            set { this["PATIENTMEDULAHASTAKABUL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProvisionRequest ProvisionRequest
        {
            get { return (ProvisionRequest)((ITTObject)this).GetParent("PROVISIONREQUEST"); }
            set { this["PROVISIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// AdmissionType tarafından set edilir
    /// </summary>
        public SKRSVakaTuru SKRSVakaTuru
        {
            get { return (SKRSVakaTuru)((ITTObject)this).GetParent("SKRSVAKATURU"); }
            set { this["SKRSVAKATURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ambulans ile geldiği XXXXXX bilgisi
    /// </summary>
        public ExternalHospitalDefinition ExternalHospital
        {
            get { return (ExternalHospitalDefinition)((ITTObject)this).GetParent("EXTERNALHOSPITAL"); }
            set { this["EXTERNALHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kabul alınan branş
    /// </summary>
        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Kayıt kabulde alınan acil bilgisini tutan objecdir
    /// </summary>
        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Eski Acil Triaj bilgisi
    /// </summary>
        public SKRSTRIAJKODU OldTriage
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("OLDTRIAGE"); }
            set { this["OLDTRIAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Geliş Sebebi
    /// </summary>
        public ProvizyonTipi AdmissionType
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("ADMISSIONTYPE"); }
            set { this["ADMISSIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Acil Triaj
    /// </summary>
        public SKRSTRIAJKODU Triage
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("TRIAGE"); }
            set { this["TRIAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IstisnaiHal MedulaIstisnaiHal
        {
            get { return (IstisnaiHal)((ITTObject)this).GetParent("MEDULAISTISNAIHAL"); }
            set { this["MEDULAISTISNAIHAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SKRS Adli Vaka Gelis Sekli
    /// </summary>
        public SKRSAdliVakaGelisSekli SKRSAdliVaka
        {
            get { return (SKRSAdliVakaGelisSekli)((ITTObject)this).GetParent("SKRSADLIVAKA"); }
            set { this["SKRSADLIVAKA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EDisabledReport EDisabledReport
        {
            get { return (EDisabledReport)((ITTObject)this).GetParent("EDISABLEDREPORT"); }
            set { this["EDISABLEDREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EStatusNotRepCommitteeObj EStatusNotRepCommitteeObj
        {
            get { return (EStatusNotRepCommitteeObj)((ITTObject)this).GetParent("ESTATUSNOTREPCOMMITTEEOBJ"); }
            set { this["ESTATUSNOTREPCOMMITTEEOBJ"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResourcesToBeReferredCollection()
        {
            _ResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred.ChildPatientAdmissionResourcesToBeReferredCollection(this, new Guid("f36c6e51-807e-423e-9362-31da6ac36c63"));
            ((ITTChildObjectCollection)_ResourcesToBeReferred).GetChildren();
        }

        protected PatientAdmissionResourcesToBeReferred.ChildPatientAdmissionResourcesToBeReferredCollection _ResourcesToBeReferred = null;
    /// <summary>
    /// Child collection for Havale Edilecek Birim(ler)
    /// </summary>
        public PatientAdmissionResourcesToBeReferred.ChildPatientAdmissionResourcesToBeReferredCollection ResourcesToBeReferred
        {
            get
            {
                if (_ResourcesToBeReferred == null)
                    CreateResourcesToBeReferredCollection();
                return _ResourcesToBeReferred;
            }
        }

        virtual protected void CreateFiredEpisodeActionsCollection()
        {
            _FiredEpisodeActions = new EpisodeAction.ChildEpisodeActionCollection(this, new Guid("6d464855-4319-47e5-ad53-749144d7f77c"));
            ((ITTChildObjectCollection)_FiredEpisodeActions).GetChildren();
        }

        protected EpisodeAction.ChildEpisodeActionCollection _FiredEpisodeActions = null;
    /// <summary>
    /// Child collection for İşlem Hasta Kabulden Başlatıldı İse Başlatıldığı Hasta Kabul Nesnesi
    /// </summary>
        public EpisodeAction.ChildEpisodeActionCollection FiredEpisodeActions
        {
            get
            {
                if (_FiredEpisodeActions == null)
                    CreateFiredEpisodeActionsCollection();
                return _FiredEpisodeActions;
            }
        }

        virtual protected void CreateSubEpisodesCollection()
        {
            _SubEpisodes = new SubEpisode.ChildSubEpisodeCollection(this, new Guid("21952a25-207c-4cdf-922b-a5e8fa7acc56"));
            ((ITTChildObjectCollection)_SubEpisodes).GetChildren();
        }

        protected SubEpisode.ChildSubEpisodeCollection _SubEpisodes = null;
        public SubEpisode.ChildSubEpisodeCollection SubEpisodes
        {
            get
            {
                if (_SubEpisodes == null)
                    CreateSubEpisodesCollection();
                return _SubEpisodes;
            }
        }

        virtual protected void CreateMedulaSPASErrorsCollection()
        {
            _MedulaSPASErrors = new MedulaSPASError.ChildMedulaSPASErrorCollection(this, new Guid("47ac997c-b41a-4371-ad76-4aa9da8f5a3c"));
            ((ITTChildObjectCollection)_MedulaSPASErrors).GetChildren();
        }

        protected MedulaSPASError.ChildMedulaSPASErrorCollection _MedulaSPASErrors = null;
        public MedulaSPASError.ChildMedulaSPASErrorCollection MedulaSPASErrors
        {
            get
            {
                if (_MedulaSPASErrors == null)
                    CreateMedulaSPASErrorsCollection();
                return _MedulaSPASErrors;
            }
        }

        protected PatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAdmission(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTADMISSION", dataRow) { }
        protected PatientAdmission(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTADMISSION", dataRow, isImported) { }
        public PatientAdmission(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAdmission(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAdmission() : base() { }

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