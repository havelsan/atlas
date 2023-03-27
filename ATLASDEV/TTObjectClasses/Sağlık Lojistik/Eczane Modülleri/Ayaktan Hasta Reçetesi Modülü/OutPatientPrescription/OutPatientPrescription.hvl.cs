
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OutPatientPrescription")] 

    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public  partial class OutPatientPrescription : Prescription, IWorkListEpisodeAction, ICreatePrescriptionStockOut
    {
        public class OutPatientPrescriptionList : TTObjectCollection<OutPatientPrescription> { }
                    
        public class ChildOutPatientPrescriptionCollection : TTObject.TTChildObjectCollection<OutPatientPrescription>
        {
            public ChildOutPatientPrescriptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOutPatientPrescriptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOutPatientDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject 
        {
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetOutPatientDrugPrescriptionTotalReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPatientDrugPrescriptionTotalReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPatientDrugPrescriptionTotalReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutpatientPrescriptionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Payer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Externalpharmacy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALPHARMACY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPHARMACY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Prescriptiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Druggivingdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGGIVINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["FILLINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Procedurespeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURESPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patient
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENT"]);
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

            public Object Employmentrecordid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                }
            }

            public Object Patientforce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFORCE"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public long? SPTSProvisionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSPROVISIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["SPTSPROVISIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string EReceteNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ERECETENO"].DataType;
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

            public string Drug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? CurrentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CURRENTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string UsageNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["PRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? ReceivedPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVEDPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["RECEIVEDPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string BarcodeLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODELEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["BARCODELEVEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSON"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DiplomaRegisterNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMAREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMAREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOutpatientPrescriptionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutpatientPrescriptionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutpatientPrescriptionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutPatientPrescriptionByObjectIDs_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string PrescriptionNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSigned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSIGNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ISSIGNED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string EHUUniqueNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EHUUNIQUENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["EHUUNIQUENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EHURecetePassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EHURECETEPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["EHURECETEPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["DISTRIBUTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PrescriptionPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string EReceteDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ERECETEDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object SignedData
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGNEDDATA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["SIGNEDDATA"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public ProvisionTypeEnum? ProvisionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVISIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PROVISIONTYPE"].DataType;
                    return (ProvisionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PrescriptionSubTypeEnum? PrescriptionSubType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONSUBTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONSUBTYPE"].DataType;
                    return (PrescriptionSubTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string EReceteNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ERECETENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? FillingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILLINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["FILLINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ERecetePassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETEPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ERECETEPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ISREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PatientGroupEnum? PatientGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["PATIENTGROUP"].DataType;
                    return (PatientGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? SPTSMessageID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SPTSMESSAGEID"]);
                }
            }

            public bool? SendOutPharmacy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDOUTPHARMACY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["SENDOUTPHARMACY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? SPTSProvisionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSPROVISIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["SPTSPROVISIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReceiptNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["RECEIPTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["FREEDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SPTSProvisionDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSPROVISIONDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["SPTSPROVISIONDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DiagnosisTypeEnum? AddDiagnosisType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDDIAGNOSISTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ADDDIAGNOSISTYPE"].DataType;
                    return (DiagnosisTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsDischargePrescripiton
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDISCHARGEPRESCRIPITON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["ISDISCHARGEPRESCRIPITON"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DiscriptionOfPharmacist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCRIPTIONOFPHARMACIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].AllPropertyDefs["DISCRIPTIONOFPHARMACIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOutPatientPrescriptionByObjectIDs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPatientPrescriptionByObjectIDs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPatientPrescriptionByObjectIDs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDetailOutPresciprtionReportQuery_Class : TTReportNqlObject 
        {
            public string Drug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDetailOutPresciprtionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDetailOutPresciprtionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDetailOutPresciprtionReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("439ded48-8553-42a9-9def-994f1eeac334"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6ca96cad-2b56-4057-a9fb-9a293c549e6e"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("daaa0044-2635-4ce9-af81-943a3007cca4"); } }
    /// <summary>
    /// Enfeksiyon Komitesi Onay
    /// </summary>
            public static Guid DrugControl { get { return new Guid("d58d4ede-1299-4758-aa1f-e3358c8e0ee7"); } }
    /// <summary>
    /// Elektronik İmza İle Tamamlandı
    /// </summary>
            public static Guid CompletedWithSign { get { return new Guid("223e5907-3a92-45a2-8c03-e3a1912f4720"); } }
        }

        public static BindingList<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class> GetOutPatientDrugPrescriptionTotalReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutPatientDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class> GetOutPatientDrugPrescriptionTotalReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutPatientDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription> GetReceiptNoNQL(TTObjectContext objectContext, string RECEIPTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetReceiptNoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RECEIPTNO", RECEIPTNO);

            return ((ITTQuery)objectContext).QueryObjects<OutPatientPrescription>(queryDef, paramList);
        }

        public static BindingList<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class> GetOutpatientPrescriptionReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutpatientPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class> GetOutpatientPrescriptionReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutpatientPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription> GetOutPatientPrescriptionByEpisodeIDs(TTObjectContext objectContext, Guid OBJECTIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutPatientPrescriptionByEpisodeIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return ((ITTQuery)objectContext).QueryObjects<OutPatientPrescription>(queryDef, paramList);
        }

        public static BindingList<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class> GetOutPatientPrescriptionByObjectIDs(Guid OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutPatientPrescriptionByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class> GetOutPatientPrescriptionByObjectIDs(TTObjectContext objectContext, Guid OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutPatientPrescriptionByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class> GetDetailOutPresciprtionReportQuery(Guid PRESCRIPTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetDetailOutPresciprtionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONID", PRESCRIPTIONID);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class> GetDetailOutPresciprtionReportQuery(TTObjectContext objectContext, Guid PRESCRIPTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetDetailOutPresciprtionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONID", PRESCRIPTIONID);

            return TTReportNqlObject.QueryObjects<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientPrescription> GetOutpatientPrescriptionByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetOutpatientPrescriptionByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<OutPatientPrescription>(queryDef, paramList);
        }

        public static BindingList<OutPatientPrescription> GetBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTPRESCRIPTION"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<OutPatientPrescription>(queryDef, paramList);
        }

        public PatientGroupEnum? PatientGroup
        {
            get { return (PatientGroupEnum?)(int?)this["PATIENTGROUP"]; }
            set { this["PATIENTGROUP"] = value; }
        }

        public Guid? SPTSMessageID
        {
            get { return (Guid?)this["SPTSMESSAGEID"]; }
            set { this["SPTSMESSAGEID"] = value; }
        }

    /// <summary>
    /// Diş eczaneye reçete gönderme durumunun kontrolünü yapar
    /// </summary>
        public bool? SendOutPharmacy
        {
            get { return (bool?)this["SENDOUTPHARMACY"]; }
            set { this["SENDOUTPHARMACY"] = value; }
        }

    /// <summary>
    /// SPTS Provizyon No
    /// </summary>
        public long? SPTSProvisionID
        {
            get { return (long?)this["SPTSPROVISIONID"]; }
            set { this["SPTSPROVISIONID"] = value; }
        }

    /// <summary>
    /// Makbuz Numarası
    /// </summary>
        public string ReceiptNO
        {
            get { return (string)this["RECEIPTNO"]; }
            set { this["RECEIPTNO"] = value; }
        }

    /// <summary>
    /// Serbest Tanı
    /// </summary>
        public string FreeDiagnosis
        {
            get { return (string)this["FREEDIAGNOSIS"]; }
            set { this["FREEDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Provizyon Açıklama
    /// </summary>
        public string SPTSProvisionDesc
        {
            get { return (string)this["SPTSPROVISIONDESC"]; }
            set { this["SPTSPROVISIONDESC"] = value; }
        }

    /// <summary>
    /// Tanı Tipi
    /// </summary>
        public DiagnosisTypeEnum? AddDiagnosisType
        {
            get { return (DiagnosisTypeEnum?)(int?)this["ADDDIAGNOSISTYPE"]; }
            set { this["ADDDIAGNOSISTYPE"] = value; }
        }

    /// <summary>
    /// Taburcu Reçetesi
    /// </summary>
        public bool? IsDischargePrescripiton
        {
            get { return (bool?)this["ISDISCHARGEPRESCRIPITON"]; }
            set { this["ISDISCHARGEPRESCRIPITON"] = value; }
        }

    /// <summary>
    /// Eczacının Açıklaması
    /// </summary>
        public string DiscriptionOfPharmacist
        {
            get { return (string)this["DISCRIPTIONOFPHARMACIST"]; }
            set { this["DISCRIPTIONOFPHARMACIST"] = value; }
        }

        public ExternalPharmacy ExternalPharmacy
        {
            get { return (ExternalPharmacy)((ITTObject)this).GetParent("EXTERNALPHARMACY"); }
            set { this["EXTERNALPHARMACY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition SpecialityDefinition
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITYDEFINITION"); }
            set { this["SPECIALITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOutPatientDrugOrdersCollection()
        {
            _OutPatientDrugOrders = new OutPatientDrugOrder.ChildOutPatientDrugOrderCollection(this, new Guid("8d050ef8-f791-44f1-ae80-1e757a41f82c"));
            ((ITTChildObjectCollection)_OutPatientDrugOrders).GetChildren();
        }

        protected OutPatientDrugOrder.ChildOutPatientDrugOrderCollection _OutPatientDrugOrders = null;
        public OutPatientDrugOrder.ChildOutPatientDrugOrderCollection OutPatientDrugOrders
        {
            get
            {
                if (_OutPatientDrugOrders == null)
                    CreateOutPatientDrugOrdersCollection();
                return _OutPatientDrugOrders;
            }
        }

        protected OutPatientPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OutPatientPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OutPatientPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OutPatientPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OutPatientPrescription(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OUTPATIENTPRESCRIPTION", dataRow) { }
        protected OutPatientPrescription(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OUTPATIENTPRESCRIPTION", dataRow, isImported) { }
        public OutPatientPrescription(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OutPatientPrescription(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OutPatientPrescription() : base() { }

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