
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Patient")] 

    /// <summary>
    /// Hasta
    /// </summary>
    public  partial class Patient : Person, IOldActions, ISUTPatient
    {
        public class PatientList : TTObjectCollection<Patient> { }
                    
        public class ChildPatientCollection : TTObject.TTChildObjectCollection<Patient>
        {
            public ChildPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_deneme_Class : TTReportNqlObject 
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

            public OLAP_deneme_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_deneme_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_deneme_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientByInjection_Class : TTReportNqlObject 
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

            public string IdentificationSeriesNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONSERIESNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONSERIESNO"].DataType;
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

            public string FamilyNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FAMILYNO"].DataType;
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

            public string IdentificationCardNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONCARDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONCARDNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NameIsUpdated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMEISUPDATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAMEISUPDATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string IdentificationVolumeNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONVOLUMENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONVOLUMENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SurnameIsUpdated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAMEISUPDATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAMEISUPDATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string IdentificationCardSerialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONCARDSERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONCARDSERIALNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public DateTime? ExDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EXDATE"].DataType;
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

            public string PassportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASSPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PASSPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IdentificationGivenTown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONGIVENTOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONGIVENTOWN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IdentificationGivenReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONGIVENREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONGIVENREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? IdentificationGivenDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONGIVENDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONGIVENDATE"].DataType;
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

            public int? DeathReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATHREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DEATHREPORTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? PrivacyUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string HomePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HOMEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Length
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["LENGTH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public EyeColorEnum? EyeColor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EYECOLOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EYECOLOR"].DataType;
                    return (EyeColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string SpecialStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SPECIALSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BeneficiaryEnum? Beneficiary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARY"].DataType;
                    return (BeneficiaryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ImportantPatientInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMPORTANTPATIENTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IMPORTANTPATIENTINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? BeneficiaryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? Deleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DELETED"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? OldID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["OLDID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object Photo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHOTO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PHOTO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? UnIdentified
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIDENTIFIED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIDENTIFIED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Alive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ALIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string EMail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotRequiredQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTREQUIREDQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NOTREQUIREDQUOTA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string Religion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELIGION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["RELIGION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Privacy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PrivacyEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PrivacyReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYREASON"].DataType;
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

            public bool? SecurePerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECUREPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SECUREPERSON"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PatientFamilyHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFAMILYHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public double? Heigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HEIGTH"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? ChestCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHESTCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["CHESTCIRCUMFERENCE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? HeadCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HEADCIRCUMFERENCE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTrusted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTRUSTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ISTRUSTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PrivacyName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrivacySurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYSURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Death
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DEATH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? DonorUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONORUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DONORUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? KPSUpdateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KPSUPDATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["KPSUPDATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string BeneficiaryName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARYNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARYUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string PrivacyHomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYHOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYHOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrivacyMobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYMOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYMOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VemHastaKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VEMHASTAKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["VEMHASTAKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientIdentityAddress_Class : TTReportNqlObject 
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

            public string IdentificationSeriesNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONSERIESNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONSERIESNO"].DataType;
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

            public string FamilyNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FAMILYNO"].DataType;
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

            public string IdentificationCardNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONCARDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONCARDNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NameIsUpdated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMEISUPDATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAMEISUPDATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string IdentificationVolumeNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONVOLUMENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONVOLUMENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SurnameIsUpdated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAMEISUPDATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAMEISUPDATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string IdentificationCardSerialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONCARDSERIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONCARDSERIALNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public DateTime? ExDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EXDATE"].DataType;
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

            public string PassportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASSPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PASSPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IdentificationGivenTown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONGIVENTOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONGIVENTOWN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IdentificationGivenReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONGIVENREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONGIVENREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? IdentificationGivenDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONGIVENDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IDENTIFICATIONGIVENDATE"].DataType;
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

            public int? DeathReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATHREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DEATHREPORTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public long? PrivacyUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string HomePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HOMEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Length
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["LENGTH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public EyeColorEnum? EyeColor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EYECOLOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EYECOLOR"].DataType;
                    return (EyeColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string SpecialStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SPECIALSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BeneficiaryEnum? Beneficiary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARY"].DataType;
                    return (BeneficiaryEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ImportantPatientInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMPORTANTPATIENTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IMPORTANTPATIENTINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? BeneficiaryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? Deleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DELETED"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? OldID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["OLDID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object Photo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHOTO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PHOTO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? UnIdentified
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIDENTIFIED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIDENTIFIED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Alive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ALIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string EMail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NotRequiredQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTREQUIREDQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NOTREQUIREDQUOTA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public string Religion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELIGION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["RELIGION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Privacy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PrivacyEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PrivacyReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYREASON"].DataType;
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

            public bool? SecurePerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECUREPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SECUREPERSON"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PatientFamilyHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFAMILYHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public double? Heigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HEIGTH"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? ChestCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHESTCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["CHESTCIRCUMFERENCE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? HeadCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HEADCIRCUMFERENCE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTrusted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTRUSTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ISTRUSTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PrivacyName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrivacySurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYSURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Death
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DEATH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? DonorUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONORUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["DONORUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? KPSUpdateDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KPSUPDATEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["KPSUPDATEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string BeneficiaryName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFICIARYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARYNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BENEFICIARYUNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string PrivacyHomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYHOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYHOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrivacyMobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIVACYMOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PRIVACYMOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VemHastaKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VEMHASTAKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["VEMHASTAKODU"].DataType;
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

            public GetPatientIdentityAddress_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientIdentityAddress_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientIdentityAddress_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExistsByUniqueRefNO_RQ_Class : TTReportNqlObject 
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

            public GetPatientExistsByUniqueRefNO_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExistsByUniqueRefNO_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExistsByUniqueRefNO_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForImportantMedicalInfo_Class : TTReportNqlObject 
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

            public GetOldInfoForImportantMedicalInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForImportantMedicalInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForImportantMedicalInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientObjectIDByInjection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPatientObjectIDByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientObjectIDByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientObjectIDByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientInformation_RQ_Class : TTReportNqlObject 
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

            public Object Cinsiyet
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CINSIYET"]);
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

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
                }
            }

            public Object Dogumyeriil
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIIL"]);
                }
            }

            public Object Dogumyeriilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                }
            }

            public string Babaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anneadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Kangrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KANGRUBU"]);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public Object Evadresi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVADRESI"]);
                }
            }

            public Object Evpostakodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVPOSTAKODU"]);
                }
            }

            public Object Evtelefonu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVTELEFONU"]);
                }
            }

            public Object Evil
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVIL"]);
                }
            }

            public Object Evilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVILCE"]);
                }
            }

            public GetPatientInformation_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientInformation_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientInformation_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_Class : TTReportNqlObject 
        {
            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public long? Tc_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Uyruk
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UYRUK"]);
                }
            }

            public bool? Hasta_tipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTA_TIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public DateTime? Dogum_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUM_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Dogum_yeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUM_YERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Anne_kimlik_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNE_KIMLIK_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dogum_sirasi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOGUM_SIRASI"]);
                }
            }

            public string Anne_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNE_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Baba_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABA_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Medeni_hali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDENI_HALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMEDENIHALI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Meslek
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESLEK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMESLEKLER"].AllPropertyDefs["KODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ogrenim_durumu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OGRENIM_DURUMU"]);
                }
            }

            public string Kan_grubu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAN_GRUBU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKANGRUBU"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Olum_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUM_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["EXDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Olum_yeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OLUM_YERI"]);
                }
            }

            public string Pasaport_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASAPORT_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["PASSPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Yabanci_hasta_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YABANCI_HASTA_TURU"]);
                }
            }

            public int? Yupass_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASS_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Son_kurum_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SON_KURUM_KODU"]);
                }
            }

            public Guid? Ekleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Guid? Guncelleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HASTA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_ARSIV_Class : TTReportNqlObject 
        {
            public Guid? Hasta_arsiv_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_ARSIV_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public long? Arsiv_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARSIV_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDER"].AllPropertyDefs["PATIENTFOLDERID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Defter_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEFTER_TURU"]);
                }
            }

            public string Arsiv_yeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARSIV_YERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["IMPORTANTPATIENTINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Object Arsiv_giris_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ARSIV_GIRIS_TARIHI"]);
                }
            }

            public Object Kayit_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KAYIT_ZAMANI"]);
                }
            }

            public Guid? Ekleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Guid? Guncelleme_tarihi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Guid? Guncelleyen_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_HASTA_ARSIV_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_ARSIV_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_ARSIV_Class() : base() { }
        }

        [Serializable] 

        public partial class PatientHasProcedureBySUTCodes_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PatientHasProcedureBySUTCodes_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PatientHasProcedureBySUTCodes_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PatientHasProcedureBySUTCodes_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientEK8InformationByObjectID_Class : TTReportNqlObject 
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

            public Guid? Cinsiyet
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CINSIYET"]);
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

            public string Dogumyeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMYERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Babaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anneadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Evtelefonu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVTELEFONU"]);
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

            public string RelativeFullName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVEFULLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["RELATIVEFULLNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientEK8InformationByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientEK8InformationByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientEK8InformationByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCovidPatientByDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetCovidPatientByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCovidPatientByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCovidPatientByDate_Class() : base() { }
        }

        public static BindingList<Patient> GetAllPatients(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetAllPatients"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient.OLAP_deneme_Class> OLAP_deneme(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["OLAP_deneme"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.OLAP_deneme_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.OLAP_deneme_Class> OLAP_deneme(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["OLAP_deneme"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.OLAP_deneme_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Patient.GetPatientByInjection_Class> GetPatientByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient.GetPatientByInjection_Class> GetPatientByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient> GetPatientsByIdentityInfo(TTObjectContext objectContext, string Name, string FatherName, string SurName, string MotherName, string CityOfBirth, string TownOfBirth, DateTime BirthDate, SexEnum Sex)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientsByIdentityInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NAME", Name);
            paramList.Add("FATHERNAME", FatherName);
            paramList.Add("SURNAME", SurName);
            paramList.Add("MOTHERNAME", MotherName);
            paramList.Add("CITYOFBIRTH", CityOfBirth);
            paramList.Add("TOWNOFBIRTH", TownOfBirth);
            paramList.Add("BIRTHDATE", BirthDate);
            paramList.Add("SEX", (int)Sex);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetImportantMedicalInformationByPatient(TTObjectContext objectContext, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetImportantMedicalInformationByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetPatientByPID(TTObjectContext objectContext, long ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientByPID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

    /// <summary>
    /// Searches patients with uniquerefno
    /// </summary>
        public static BindingList<Patient> GetPatientsByUniqueRefNo(TTObjectContext objectContext, long UNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientsByUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

    /// <summary>
    /// Patient ı objectID ile get eder
    /// </summary>
        public static BindingList<Patient> GetPatientByID(TTObjectContext objectContext, string ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetPatientsBetweenUniqueRefNo(TTObjectContext objectContext, long UNIQUEREFNO1, long UNIQUEREFNO2)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientsBetweenUniqueRefNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO1", UNIQUEREFNO1);
            paramList.Add("UNIQUEREFNO2", UNIQUEREFNO2);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetPatientsBetweenIDExceptFamily(TTObjectContext objectContext, int ID1, int ID2, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientsBetweenIDExceptFamily"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID1", ID1);
            paramList.Add("ID2", ID2);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Patient.GetPatientIdentityAddress_Class> GetPatientIdentityAddress(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientIdentityAddress"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientIdentityAddress_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient.GetPatientIdentityAddress_Class> GetPatientIdentityAddress(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientIdentityAddress"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientIdentityAddress_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient> GetPatientsBetweenIDOnlyFamily(TTObjectContext objectContext, int ID1, int ID2, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientsBetweenIDOnlyFamily"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID1", ID1);
            paramList.Add("ID2", ID2);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Patient> GetInpatientPatientsByPatientGroup(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetInpatientPatientsByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient.GetPatientExistsByUniqueRefNO_RQ_Class> GetPatientExistsByUniqueRefNO_RQ(long RFN, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientExistsByUniqueRefNO_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RFN", RFN);

            return TTReportNqlObject.QueryObjects<Patient.GetPatientExistsByUniqueRefNO_RQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.GetPatientExistsByUniqueRefNO_RQ_Class> GetPatientExistsByUniqueRefNO_RQ(TTObjectContext objectContext, long RFN, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientExistsByUniqueRefNO_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RFN", RFN);

            return TTReportNqlObject.QueryObjects<Patient.GetPatientExistsByUniqueRefNO_RQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Önemli Tıbbi Bilgiler
    /// </summary>
        public static BindingList<Patient.GetOldInfoForImportantMedicalInfo_Class> GetOldInfoForImportantMedicalInfo(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetOldInfoForImportantMedicalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Patient.GetOldInfoForImportantMedicalInfo_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Önemli Tıbbi Bilgiler
    /// </summary>
        public static BindingList<Patient.GetOldInfoForImportantMedicalInfo_Class> GetOldInfoForImportantMedicalInfo(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetOldInfoForImportantMedicalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Patient.GetOldInfoForImportantMedicalInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Patient.GetPatientObjectIDByInjection_Class> GetPatientObjectIDByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientObjectIDByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientObjectIDByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient.GetPatientObjectIDByInjection_Class> GetPatientObjectIDByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientObjectIDByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientObjectIDByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient.GetPatientInformation_RQ_Class> GetPatientInformation_RQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientInformation_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientInformation_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient.GetPatientInformation_RQ_Class> GetPatientInformation_RQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientInformation_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.GetPatientInformation_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Patient> GetPatientObjectsByInjection(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientObjectsByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Patient> GetByPrivacyPatient(TTObjectContext objectContext, long PRIVACYUNIQUEREFNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetByPrivacyPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRIVACYUNIQUEREFNO", PRIVACYUNIQUEREFNO);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetPatients(TTObjectContext objectContext, IList<Guid> OBJECTIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatients"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient.VEM_HASTA_Class> VEM_HASTA(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["VEM_HASTA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.VEM_HASTA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.VEM_HASTA_Class> VEM_HASTA(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["VEM_HASTA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.VEM_HASTA_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Patient.VEM_HASTA_ARSIV_Class> VEM_HASTA_ARSIV(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["VEM_HASTA_ARSIV"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.VEM_HASTA_ARSIV_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.VEM_HASTA_ARSIV_Class> VEM_HASTA_ARSIV(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["VEM_HASTA_ARSIV"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Patient.VEM_HASTA_ARSIV_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Patient> GetPatientByVemHastaKodu(TTObjectContext objectContext, string PatientOldID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientByVemHastaKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOLDID", PatientOldID);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

    /// <summary>
    /// Gizli Hastaları Çeker
    /// </summary>
        public static BindingList<Patient> GetPrivatePatientsByDate(TTObjectContext objectContext, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPrivatePatientsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetPatientByUniqueRefNoAndObjID(TTObjectContext objectContext, long UNIQUEREFNO, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientByUniqueRefNoAndObjID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient> GetInpatienPatientsByClinicWOParam(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetInpatienPatientsByClinicWOParam"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Patient.PatientHasProcedureBySUTCodes_Class> PatientHasProcedureBySUTCodes(IList<string> SUTCODES, Guid PATIENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["PatientHasProcedureBySUTCodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTCODES", SUTCODES);
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return TTReportNqlObject.QueryObjects<Patient.PatientHasProcedureBySUTCodes_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.PatientHasProcedureBySUTCodes_Class> PatientHasProcedureBySUTCodes(TTObjectContext objectContext, IList<string> SUTCODES, Guid PATIENTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["PatientHasProcedureBySUTCodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUTCODES", SUTCODES);
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return TTReportNqlObject.QueryObjects<Patient.PatientHasProcedureBySUTCodes_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Patient.GetPatientEK8InformationByObjectID_Class> GetPatientEK8InformationByObjectID(string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientEK8InformationByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<Patient.GetPatientEK8InformationByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.GetPatientEK8InformationByObjectID_Class> GetPatientEK8InformationByObjectID(TTObjectContext objectContext, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetPatientEK8InformationByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<Patient.GetPatientEK8InformationByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Patient> GetInpatienPatientsByClinic(TTObjectContext objectContext, Guid MasterResource)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetInpatienPatientsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MasterResource);

            return ((ITTQuery)objectContext).QueryObjects<Patient>(queryDef, paramList);
        }

        public static BindingList<Patient.GetCovidPatientByDate_Class> GetCovidPatientByDate(DateTime DATELIMIT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetCovidPatientByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATELIMIT", DATELIMIT);

            return TTReportNqlObject.QueryObjects<Patient.GetCovidPatientByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Patient.GetCovidPatientByDate_Class> GetCovidPatientByDate(TTObjectContext objectContext, DateTime DATELIMIT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].QueryDefs["GetCovidPatientByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATELIMIT", DATELIMIT);

            return TTReportNqlObject.QueryObjects<Patient.GetCovidPatientByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastanın Boy Bilgisini Tutulduğu Alandır
    /// </summary>
        public string Length
        {
            get { return (string)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// Hastanın 'Özgeçmiş' Bilgisinin Tutulduğu
    /// </summary>
        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Hastanın Güncel 'Göz Rengi' Bilgisini Taşıyan Alandır
    /// </summary>
        public EyeColorEnum? EyeColor
        {
            get { return (EyeColorEnum?)(int?)this["EYECOLOR"]; }
            set { this["EYECOLOR"] = value; }
        }

    /// <summary>
    /// Hastanın Özel Durumlarının Yeraldığı  Alandır
    /// </summary>
        public string SpecialStatus
        {
            get { return (string)this["SPECIALSTATUS"]; }
            set { this["SPECIALSTATUS"] = value; }
        }

    /// <summary>
    /// Hastanın Güncel 'Hak Sahipliği' Bilgisini Taşıyan Alandır
    /// </summary>
        public BeneficiaryEnum? Beneficiary
        {
            get { return (BeneficiaryEnum?)(int?)this["BENEFICIARY"]; }
            set { this["BENEFICIARY"] = value; }
        }

    /// <summary>
    /// Hastaya Ait Önemli Bilgilerin Tutulduğu Alandır
    /// </summary>
        public object ImportantPatientInfo
        {
            get { return (object)this["IMPORTANTPATIENTINFO"]; }
            set { this["IMPORTANTPATIENTINFO"] = value; }
        }

    /// <summary>
    /// Hastanın Güncel 'Hak Sahipliğine Geçiş Tarihi' Bilgisini Taşıyan Alandır
    /// </summary>
        public DateTime? BeneficiaryDate
        {
            get { return (DateTime?)this["BENEFICIARYDATE"]; }
            set { this["BENEFICIARYDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Silinip Silinmediği Bilgisini Tutan Alandır.
    /// </summary>
        public YesNoEnum? Deleted
        {
            get { return (YesNoEnum?)(int?)this["DELETED"]; }
            set { this["DELETED"] = value; }
        }

    /// <summary>
    /// Hastanın XXXXXX Sistemine Geçmeden Önceki Huy Programından Gelen Eski Hasta No
    /// </summary>
        public long? OldID
        {
            get { return (long?)this["OLDID"]; }
            set { this["OLDID"] = value; }
        }

    /// <summary>
    /// Hastanın Fotografının Bulunduğu Alan
    /// </summary>
        public object Photo
        {
            get { return (object)this["PHOTO"]; }
            set { this["PHOTO"] = value; }
        }

    /// <summary>
    /// Hastanın Kimlik Bilgilerinin Bilinip Bilinmediğini Tutan Alandır.
    /// </summary>
        public bool? UnIdentified
        {
            get { return (bool?)this["UNIDENTIFIED"]; }
            set { this["UNIDENTIFIED"] = value; }
        }

    /// <summary>
    /// Hayatta Olup Olmadığını Bilgisini Tutan Alandır
    /// </summary>
        public bool? Alive
        {
            get { return (bool?)this["ALIVE"]; }
            set { this["ALIVE"] = value; }
        }

    /// <summary>
    /// Hasta Numarası Bilgisini Taşıyan Alandır
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Hastanın Güncel 'EMail' Bilgisini Taşıyan Alandır
    /// </summary>
        public string EMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Hastaya Ait Extra Notların Yazılacağı Alandır.
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Hastanın kontenjana takılmadan tek seferlik kabulünü sağlar
    /// </summary>
        public bool? NotRequiredQuota
        {
            get { return (bool?)this["NOTREQUIREDQUOTA"]; }
            set { this["NOTREQUIREDQUOTA"] = value; }
        }

    /// <summary>
    /// Hastanın Yabancı Olup Olmadığı Bilgisini Taşıyan Alandır
    /// </summary>
        public bool? Foreign
        {
            get { return (bool?)this["FOREIGN"]; }
            set { this["FOREIGN"] = value; }
        }

    /// <summary>
    /// Din
    /// </summary>
        public string Religion
        {
            get { return (string)this["RELIGION"]; }
            set { this["RELIGION"] = value; }
        }

        public bool? Privacy
        {
            get { return (bool?)this["PRIVACY"]; }
            set { this["PRIVACY"] = value; }
        }

        public DateTime? PrivacyEndDate
        {
            get { return (DateTime?)this["PRIVACYENDDATE"]; }
            set { this["PRIVACYENDDATE"] = value; }
        }

        public string PrivacyReason
        {
            get { return (string)this["PRIVACYREASON"]; }
            set { this["PRIVACYREASON"] = value; }
        }

    /// <summary>
    /// YUPASS No
    /// </summary>
        public int? YUPASSNO
        {
            get { return (int?)this["YUPASSNO"]; }
            set { this["YUPASSNO"] = value; }
        }

        public bool? SecurePerson
        {
            get { return (bool?)this["SECUREPERSON"]; }
            set { this["SECUREPERSON"] = value; }
        }

    /// <summary>
    /// Hastanın Soygeçmiş Bilgisini Taşıyan Alandır
    /// </summary>
        public object PatientFamilyHistory
        {
            get { return (object)this["PATIENTFAMILYHISTORY"]; }
            set { this["PATIENTFAMILYHISTORY"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Heigth
        {
            get { return (double?)this["HEIGTH"]; }
            set { this["HEIGTH"] = value; }
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
    /// Göğüs Çevresi
    /// </summary>
        public double? ChestCircumference
        {
            get { return (double?)this["CHESTCIRCUMFERENCE"]; }
            set { this["CHESTCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Baş Çevresi
    /// </summary>
        public double? HeadCircumference
        {
            get { return (double?)this["HEADCIRCUMFERENCE"]; }
            set { this["HEADCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Mernisten sorgusu yapılıp yapılmadığını kontrol eder
    /// </summary>
        public bool? IsTrusted
        {
            get { return (bool?)this["ISTRUSTED"]; }
            set { this["ISTRUSTED"] = value; }
        }

    /// <summary>
    /// Rumuz Ad
    /// </summary>
        public string PrivacyName
        {
            get { return (string)this["PRIVACYNAME"]; }
            set { this["PRIVACYNAME"] = value; }
        }

    /// <summary>
    /// Rumuz Soyad
    /// </summary>
        public string PrivacySurname
        {
            get { return (string)this["PRIVACYSURNAME"]; }
            set { this["PRIVACYSURNAME"] = value; }
        }

    /// <summary>
    /// Ölü Olup Olmadığını Bilgisini Tutan Alandır
    /// </summary>
        public bool? Death
        {
            get { return (bool?)this["DEATH"]; }
            set { this["DEATH"] = value; }
        }

    /// <summary>
    /// Donör Tc Kimlik no
    /// </summary>
        public long? DonorUniqueRefNo
        {
            get { return (long?)this["DONORUNIQUEREFNO"]; }
            set { this["DONORUNIQUEREFNO"] = value; }
        }

    /// <summary>
    /// KPS Bilgi Güncelleme Tarihi
    /// </summary>
        public DateTime? KPSUpdateDate
        {
            get { return (DateTime?)this["KPSUPDATEDATE"]; }
            set { this["KPSUPDATEDATE"] = value; }
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
    /// Hastanın 'Gizli Ev Adresi' Bilgisini Taşıyan Alandır
    /// </summary>
        public string PrivacyHomeAddress
        {
            get { return (string)this["PRIVACYHOMEADDRESS"]; }
            set { this["PRIVACYHOMEADDRESS"] = value; }
        }

    /// <summary>
    /// Hastanın 'Cep Telefonu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string PrivacyMobilePhone
        {
            get { return (string)this["PRIVACYMOBILEPHONE"]; }
            set { this["PRIVACYMOBILEPHONE"] = value; }
        }

        public string VemHastaKodu
        {
            get { return (string)this["VEMHASTAKODU"]; }
            set { this["VEMHASTAKODU"] = value; }
        }

    /// <summary>
    /// Hastanın Yattığı Servis Bilgisini Taşıyan Alandır
    /// </summary>
        public Service Service
        {
            get { return (Service)((ITTObject)this).GetParent("SERVICE"); }
            set { this["SERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Appointment verirken geçiş objesi olarak kullanılır
    /// </summary>
        public AdmissionAppointment MyAdmissionAppointment
        {
            get { return (AdmissionAppointment)((ITTObject)this).GetParent("MYADMISSIONAPPOINTMENT"); }
            set { this["MYADMISSIONAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kafa Randevusu için kullanılır Dinamik kalmalı
    /// </summary>
        public Patient ChangedPatient
        {
            get { return (Patient)((ITTObject)this).GetParent("CHANGEDPATIENT"); }
            set { this["CHANGEDPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Hastanın Aile Reisi İle  Arasındaki  'Yakınlık Derecesi' Bilgisini Taşıyan Alandır
    /// </summary>
        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Güncel 'Kurum' Bilgisini Taşıyan Alandır
    /// </summary>
        public PayerDefinition Foundation
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("FOUNDATION"); }
            set { this["FOUNDATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalInformation MedicalInformation
        {
            get { return (MedicalInformation)((ITTObject)this).GetParent("MEDICALINFORMATION"); }
            set { this["MEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Yattığı Vakanın Tutulduğu Alnadır
    /// </summary>
        public Episode InpatientEpisode
        {
            get { return (Episode)((ITTObject)this).GetParent("INPATIENTEPISODE"); }
            set { this["INPATIENTEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Güncel 'Kurum İli' Bilgisini Taşıyan Alandır
    /// </summary>
        public City FoundationCity
        {
            get { return (City)((ITTObject)this).GetParent("FOUNDATIONCITY"); }
            set { this["FOUNDATIONCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın , Kayıtların Birleştirildiği Hastayı Tutan Alandır
    /// </summary>
        public Patient MergedToPatient
        {
            get { return (Patient)((ITTObject)this).GetParent("MERGEDTOPATIENT"); }
            set { this["MERGEDTOPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Arşivdeki Hasta Dosyası Nesnesinin Tutulduğu Alandır
    /// </summary>
        public PatientFolder PatientFolder
        {
            get { return (PatientFolder)((ITTObject)this).GetParent("PATIENTFOLDER"); }
            set { this["PATIENTFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın adres bilgisinin tutulduğu alan
    /// </summary>
        public PatientIdentityAndAddress PatientAddress
        {
            get { return (PatientIdentityAndAddress)((ITTObject)this).GetParent("PATIENTADDRESS"); }
            set { this["PATIENTADDRESS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Önemli Tıbbi Bilgilerinin Yeraldığı Nesneyi Tutan Alandır
    /// </summary>
        public ImportantMedicalInformation ImportantMedicalInformation
        {
            get { return (ImportantMedicalInformation)((ITTObject)this).GetParent("IMPORTANTMEDICALINFORMATION"); }
            set { this["IMPORTANTMEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pregnancy ActivePregnancy
        {
            get { return (Pregnancy)((ITTObject)this).GetParent("ACTIVEPREGNANCY"); }
            set { this["ACTIVEPREGNANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sigorta türü - çalışma durumu
    /// </summary>
        public SKRSSigortaliTuru InsuranceType
        {
            get { return (SKRSSigortaliTuru)((ITTObject)this).GetParent("INSURANCETYPE"); }
            set { this["INSURANCETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Annesi Olan Hastanın Tutulduğu Alandır
    /// </summary>
        public Patient Mother
        {
            get { return (Patient)((ITTObject)this).GetParent("MOTHER"); }
            set { this["MOTHER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Öğrenim Durumu
    /// </summary>
        public SKRSOgrenimDurumu EducationStatus
        {
            get { return (SKRSOgrenimDurumu)((ITTObject)this).GetParent("EDUCATIONSTATUS"); }
            set { this["EDUCATIONSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Protokol
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InfertilityPatientInformation InfertilityPatientInformation
        {
            get { return (InfertilityPatientInformation)((ITTObject)this).GetParent("INFERTILITYPATIENTINFORMATION"); }
            set { this["INFERTILITYPATIENTINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gizli Hasta
    /// </summary>
        public PrivacyPatient PrivacyPatient
        {
            get { return (PrivacyPatient)((ITTObject)this).GetParent("PRIVACYPATIENT"); }
            set { this["PRIVACYPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Meslek
    /// </summary>
        public SKRSMeslekler Occupation
        {
            get { return (SKRSMeslekler)((ITTObject)this).GetParent("OCCUPATION"); }
            set { this["OCCUPATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BloodGroupType
    /// </summary>
        public SKRSKanGrubu BloodGroupType
        {
            get { return (SKRSKanGrubu)((ITTObject)this).GetParent("BLOODGROUPTYPE"); }
            set { this["BLOODGROUPTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum Sırası
    /// </summary>
        public SKRSDogumSirasi BirthOrder
        {
            get { return (SKRSDogumSirasi)((ITTObject)this).GetParent("BIRTHORDER"); }
            set { this["BIRTHORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SKRS Yabanci Hasta Turu
    /// </summary>
        public SKRSYabanciHastaTuru SKRSYabanciHasta
        {
            get { return (SKRSYabanciHastaTuru)((ITTObject)this).GetParent("SKRSYABANCIHASTA"); }
            set { this["SKRSYABANCIHASTA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Özürlülük Durumu
    /// </summary>
        public SKRSOzurlulukDurumu SKRSOzurlulukDurumu
        {
            get { return (SKRSOzurlulukDurumu)((ITTObject)this).GetParent("SKRSOZURLULUKDURUMU"); }
            set { this["SKRSOZURLULUKDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAPRCollection()
        {
            _APR = new AccountPayableReceivable.ChildAccountPayableReceivableCollection(this, new Guid("55e6b53e-a4bf-43d4-970b-050cf7a0552c"));
            ((ITTChildObjectCollection)_APR).GetChildren();
        }

        protected AccountPayableReceivable.ChildAccountPayableReceivableCollection _APR = null;
    /// <summary>
    /// Child collection for Hasta ile ilişki
    /// </summary>
        public AccountPayableReceivable.ChildAccountPayableReceivableCollection APR
        {
            get
            {
                if (_APR == null)
                    CreateAPRCollection();
                return _APR;
            }
        }

        virtual protected void CreateEpisodesCollection()
        {
            _Episodes = new Episode.ChildEpisodeCollection(this, new Guid("596e92d0-29fe-4e31-8384-09c780bb8ee5"));
            ((ITTChildObjectCollection)_Episodes).GetChildren();
        }

        protected Episode.ChildEpisodeCollection _Episodes = null;
    /// <summary>
    /// Child collection for Vakanın Bağlı Olduğu Hasta
    /// </summary>
        public Episode.ChildEpisodeCollection Episodes
        {
            get
            {
                if (_Episodes == null)
                    CreateEpisodesCollection();
                return _Episodes;
            }
        }

        virtual protected void CreatePatientMedulaHastaKabulleriCollection()
        {
            _PatientMedulaHastaKabulleri = new PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection(this, new Guid("6ce082c6-9be2-4609-9a20-705fce99744c"));
            ((ITTChildObjectCollection)_PatientMedulaHastaKabulleri).GetChildren();
        }

        protected PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection _PatientMedulaHastaKabulleri = null;
    /// <summary>
    /// Child collection for Hasta-Medula Hasta Kabulleri
    /// </summary>
        public PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection PatientMedulaHastaKabulleri
        {
            get
            {
                if (_PatientMedulaHastaKabulleri == null)
                    CreatePatientMedulaHastaKabulleriCollection();
                return _PatientMedulaHastaKabulleri;
            }
        }

        virtual protected void CreateFTRequestersInQueueCollection()
        {
            _FTRequestersInQueue = new FileTransferRequestersInQueueGrid.ChildFileTransferRequestersInQueueGridCollection(this, new Guid("7d727f03-3773-4e8c-bd1d-516783499e0d"));
            ((ITTChildObjectCollection)_FTRequestersInQueue).GetChildren();
        }

        protected FileTransferRequestersInQueueGrid.ChildFileTransferRequestersInQueueGridCollection _FTRequestersInQueue = null;
        public FileTransferRequestersInQueueGrid.ChildFileTransferRequestersInQueueGridCollection FTRequestersInQueue
        {
            get
            {
                if (_FTRequestersInQueue == null)
                    CreateFTRequestersInQueueCollection();
                return _FTRequestersInQueue;
            }
        }

        virtual protected void CreatePatientTokensCollection()
        {
            _PatientTokens = new PatientToken.ChildPatientTokenCollection(this, new Guid("20544294-0c32-41d2-b8b5-88f95f6c97b0"));
            ((ITTChildObjectCollection)_PatientTokens).GetChildren();
        }

        protected PatientToken.ChildPatientTokenCollection _PatientTokens = null;
        public PatientToken.ChildPatientTokenCollection PatientTokens
        {
            get
            {
                if (_PatientTokens == null)
                    CreatePatientTokensCollection();
                return _PatientTokens;
            }
        }

        virtual protected void CreateVaccineDetailsCollection()
        {
            _VaccineDetails = new VaccineDetails.ChildVaccineDetailsCollection(this, new Guid("91b7ed8e-200e-49a0-a103-94d1fe17180b"));
            ((ITTChildObjectCollection)_VaccineDetails).GetChildren();
        }

        protected VaccineDetails.ChildVaccineDetailsCollection _VaccineDetails = null;
        public VaccineDetails.ChildVaccineDetailsCollection VaccineDetails
        {
            get
            {
                if (_VaccineDetails == null)
                    CreateVaccineDetailsCollection();
                return _VaccineDetails;
            }
        }

        virtual protected void CreateMergedEpisodesCollection()
        {
            _MergedEpisodes = new Episode.ChildEpisodeCollection(this, new Guid("ec1ff58e-5d1a-4496-9dc4-73f69779a9a8"));
            ((ITTChildObjectCollection)_MergedEpisodes).GetChildren();
        }

        protected Episode.ChildEpisodeCollection _MergedEpisodes = null;
    /// <summary>
    /// Child collection for Hastaları Birleştirilen Vakaların  Birleşmeden önceki  Hastası
    /// </summary>
        public Episode.ChildEpisodeCollection MergedEpisodes
        {
            get
            {
                if (_MergedEpisodes == null)
                    CreateMergedEpisodesCollection();
                return _MergedEpisodes;
            }
        }

        virtual protected void CreatePatientInvoiceDocumentsCollection()
        {
            _PatientInvoiceDocuments = new PatientInvoiceDocument.ChildPatientInvoiceDocumentCollection(this, new Guid("5f4abd9a-f910-4fd6-acbc-b5c0c17704ff"));
            ((ITTChildObjectCollection)_PatientInvoiceDocuments).GetChildren();
        }

        protected PatientInvoiceDocument.ChildPatientInvoiceDocumentCollection _PatientInvoiceDocuments = null;
    /// <summary>
    /// Child collection for Hastayla İlişki
    /// </summary>
        public PatientInvoiceDocument.ChildPatientInvoiceDocumentCollection PatientInvoiceDocuments
        {
            get
            {
                if (_PatientInvoiceDocuments == null)
                    CreatePatientInvoiceDocumentsCollection();
                return _PatientInvoiceDocuments;
            }
        }

        virtual protected void CreateAppointmentsCollection()
        {
            _Appointments = new Appointment.ChildAppointmentCollection(this, new Guid("d3e47d2b-63e7-4764-9ea5-e08d2d949e9c"));
            ((ITTChildObjectCollection)_Appointments).GetChildren();
        }

        protected Appointment.ChildAppointmentCollection _Appointments = null;
    /// <summary>
    /// Child collection for Hasta
    /// </summary>
        public Appointment.ChildAppointmentCollection Appointments
        {
            get
            {
                if (_Appointments == null)
                    CreateAppointmentsCollection();
                return _Appointments;
            }
        }

        virtual protected void CreatePregnanciesCollection()
        {
            _Pregnancies = new Pregnancy.ChildPregnancyCollection(this, new Guid("31bf1830-9321-47fa-9d01-a72a38a3508c"));
            ((ITTChildObjectCollection)_Pregnancies).GetChildren();
        }

        protected Pregnancy.ChildPregnancyCollection _Pregnancies = null;
        public Pregnancy.ChildPregnancyCollection Pregnancies
        {
            get
            {
                if (_Pregnancies == null)
                    CreatePregnanciesCollection();
                return _Pregnancies;
            }
        }

        virtual protected void CreateChildGrowthVisitsCollection()
        {
            _ChildGrowthVisits = new ChildGrowthVisits.ChildChildGrowthVisitsCollection(this, new Guid("e013b922-f531-442d-840b-7dd638891f6e"));
            ((ITTChildObjectCollection)_ChildGrowthVisits).GetChildren();
        }

        protected ChildGrowthVisits.ChildChildGrowthVisitsCollection _ChildGrowthVisits = null;
        public ChildGrowthVisits.ChildChildGrowthVisitsCollection ChildGrowthVisits
        {
            get
            {
                if (_ChildGrowthVisits == null)
                    CreateChildGrowthVisitsCollection();
                return _ChildGrowthVisits;
            }
        }

        virtual protected void CreateChildCollection()
        {
            _Child = new Patient.ChildPatientCollection(this, new Guid("59e6536b-38c0-4382-beec-f6698adeb559"));
            ((ITTChildObjectCollection)_Child).GetChildren();
        }

        protected Patient.ChildPatientCollection _Child = null;
    /// <summary>
    /// Child collection for Hastanın Annesi Olan Hastanın Tutulduğu Alandır
    /// </summary>
        public Patient.ChildPatientCollection Child
        {
            get
            {
                if (_Child == null)
                    CreateChildCollection();
                return _Child;
            }
        }

        virtual protected void CreateInfertilitiesCollection()
        {
            _Infertilities = new Infertility.ChildInfertilityCollection(this, new Guid("ab8ba76c-0238-496e-b74d-240ac533aca3"));
            ((ITTChildObjectCollection)_Infertilities).GetChildren();
        }

        protected Infertility.ChildInfertilityCollection _Infertilities = null;
        public Infertility.ChildInfertilityCollection Infertilities
        {
            get
            {
                if (_Infertilities == null)
                    CreateInfertilitiesCollection();
                return _Infertilities;
            }
        }

        virtual protected void CreatePatientAuthorizedResourcesCollection()
        {
            _PatientAuthorizedResources = new PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection(this, new Guid("c86a9556-fbf2-4f61-a58e-a99940f2db5d"));
            ((ITTChildObjectCollection)_PatientAuthorizedResources).GetChildren();
        }

        protected PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection _PatientAuthorizedResources = null;
        public PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection PatientAuthorizedResources
        {
            get
            {
                if (_PatientAuthorizedResources == null)
                    CreatePatientAuthorizedResourcesCollection();
                return _PatientAuthorizedResources;
            }
        }

        virtual protected void CreateNewBornCollection()
        {
            _NewBorn = new NewBornIntensiveCare.ChildNewBornIntensiveCareCollection(this, new Guid("6aa20aff-5ce9-40f8-8bbe-1f688fb62563"));
            ((ITTChildObjectCollection)_NewBorn).GetChildren();
        }

        protected NewBornIntensiveCare.ChildNewBornIntensiveCareCollection _NewBorn = null;
        public NewBornIntensiveCare.ChildNewBornIntensiveCareCollection NewBorn
        {
            get
            {
                if (_NewBorn == null)
                    CreateNewBornCollection();
                return _NewBorn;
            }
        }

        virtual protected void CreateDirectPurchaseActionsCollection()
        {
            _DirectPurchaseActions = new DirectPurchaseAction.ChildDirectPurchaseActionCollection(this, new Guid("a753cb2e-177c-4e7d-accb-8be504570c49"));
            ((ITTChildObjectCollection)_DirectPurchaseActions).GetChildren();
        }

        protected DirectPurchaseAction.ChildDirectPurchaseActionCollection _DirectPurchaseActions = null;
    /// <summary>
    /// Child collection for Hasta
    /// </summary>
        public DirectPurchaseAction.ChildDirectPurchaseActionCollection DirectPurchaseActions
        {
            get
            {
                if (_DirectPurchaseActions == null)
                    CreateDirectPurchaseActionsCollection();
                return _DirectPurchaseActions;
            }
        }

        virtual protected void CreateBaseAdmissionAppointmentsCollection()
        {
            _BaseAdmissionAppointments = new BaseAdmissionAppointment.ChildBaseAdmissionAppointmentCollection(this, new Guid("ca4f2464-56d8-4fe5-8b81-cc21902d05cd"));
            ((ITTChildObjectCollection)_BaseAdmissionAppointments).GetChildren();
        }

        protected BaseAdmissionAppointment.ChildBaseAdmissionAppointmentCollection _BaseAdmissionAppointments = null;
    /// <summary>
    /// Child collection for Hasta
    /// </summary>
        public BaseAdmissionAppointment.ChildBaseAdmissionAppointmentCollection BaseAdmissionAppointments
        {
            get
            {
                if (_BaseAdmissionAppointments == null)
                    CreateBaseAdmissionAppointmentsCollection();
                return _BaseAdmissionAppointments;
            }
        }

        virtual protected void CreateSigortaliAdliGecmisiCollection()
        {
            _SigortaliAdliGecmisi = new SigortaliAdliGecmisi.ChildSigortaliAdliGecmisiCollection(this, new Guid("5d0875f5-4f6b-49cf-b81f-156c5d451cca"));
            ((ITTChildObjectCollection)_SigortaliAdliGecmisi).GetChildren();
        }

        protected SigortaliAdliGecmisi.ChildSigortaliAdliGecmisiCollection _SigortaliAdliGecmisi = null;
        public SigortaliAdliGecmisi.ChildSigortaliAdliGecmisiCollection SigortaliAdliGecmisi
        {
            get
            {
                if (_SigortaliAdliGecmisi == null)
                    CreateSigortaliAdliGecmisiCollection();
                return _SigortaliAdliGecmisi;
            }
        }

        virtual protected void CreatePatientOldDebtCollection()
        {
            _PatientOldDebt = new PatientOldDebt.ChildPatientOldDebtCollection(this, new Guid("c6badd73-f66a-4fe3-8620-df9ea2d03370"));
            ((ITTChildObjectCollection)_PatientOldDebt).GetChildren();
        }

        protected PatientOldDebt.ChildPatientOldDebtCollection _PatientOldDebt = null;
        public PatientOldDebt.ChildPatientOldDebtCollection PatientOldDebt
        {
            get
            {
                if (_PatientOldDebt == null)
                    CreatePatientOldDebtCollection();
                return _PatientOldDebt;
            }
        }

        virtual protected void CreateObstetricInformationCollection()
        {
            _ObstetricInformation = new RegularObstetric.ChildRegularObstetricCollection(this, new Guid("92a79283-003f-4233-8259-f11334c646ba"));
            ((ITTChildObjectCollection)_ObstetricInformation).GetChildren();
        }

        protected RegularObstetric.ChildRegularObstetricCollection _ObstetricInformation = null;
    /// <summary>
    /// Child collection for Annenin Hangi Hasta Olduğu Bilgisi
    /// </summary>
        public RegularObstetric.ChildRegularObstetricCollection ObstetricInformation
        {
            get
            {
                if (_ObstetricInformation == null)
                    CreateObstetricInformationCollection();
                return _ObstetricInformation;
            }
        }

        protected Patient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Patient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Patient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Patient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Patient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENT", dataRow) { }
        protected Patient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENT", dataRow, isImported) { }
        public Patient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Patient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Patient() : base() { }

    }
}