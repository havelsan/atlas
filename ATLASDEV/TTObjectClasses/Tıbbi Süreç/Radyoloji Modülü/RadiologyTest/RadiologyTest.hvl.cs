
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTest")] 

    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
    public  partial class RadiologyTest : SubactionProcedureFlowable, IAppointmentDef, ITreatmentMaterialCollection, ICheckPaid, INumaratorAppointment, ICreateSubEpisode, IWorkListRadiology
    {
        public class RadiologyTestList : TTObjectCollection<RadiologyTest> { }
                    
        public class ChildRadiologyTestCollection : TTObject.TTChildObjectCollection<RadiologyTest>
        {
            public ChildRadiologyTestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RadiologyTestAppointmentInfoQuery_Class : TTReportNqlObject 
        {
            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public RadiologyTestAppointmentInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RadiologyTestAppointmentInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RadiologyTestAppointmentInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class RadiologyTestResultReport_Class : TTReportNqlObject 
        {
            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reportedby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Approvedby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public RadiologyTestResultReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RadiologyTestResultReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RadiologyTestResultReport_Class() : base() { }
        }

        [Serializable] 

        public partial class RadiologyTestPatientInfoReportQuery_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? RadiologyRequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOLOGYREQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalRequest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALREQUEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ADDITIONALREQUEST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInPACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINPACS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? TestToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTTOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodyPositionEnum? BodyPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYPOSITION"].DataType;
                    return (RadiologyBodyPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodySiteEnum? BodySite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYSITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYSITE"].DataType;
                    return (RadiologyBodySiteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BIRIM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string GeneralDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["GENERALDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINTELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINTELETIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessagePACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEPACS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGETELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGETELETIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ImageQualityAssesmentEnum? ImageQualityAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGEQUALITYASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["IMAGEQUALITYASSESMENT"].DataType;
                    return (ImageQualityAssesmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object RadiographyTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOGRAPHYTECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOGRAPHYTECHNIQUE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ComparisonInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPARISONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPARISONINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Results
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RESULTS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINEXTERNALHIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEEXTERNALHIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RequestReasonAssesment? RequestReasonAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTREASONASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTREASONASSESMENT"].DataType;
                    return (RequestReasonAssesment?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyContrastTypeEnum? ContrastType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRASTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CONTRASTTYPE"].DataType;
                    return (RadiologyContrastTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREID"]);
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

            public RadiologyTestPatientInfoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RadiologyTestPatientInfoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RadiologyTestPatientInfoReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledRadiologyTest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public DateTime? TestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCancelledRadiologyTest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledRadiologyTest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledRadiologyTest_Class() : base() { }
        }

        [Serializable] 

        public partial class RadiologyTestByObjectIDQuery_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? RadiologyRequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOLOGYREQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalRequest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALREQUEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ADDITIONALREQUEST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInPACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINPACS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? TestToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTTOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodyPositionEnum? BodyPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYPOSITION"].DataType;
                    return (RadiologyBodyPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodySiteEnum? BodySite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYSITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYSITE"].DataType;
                    return (RadiologyBodySiteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BIRIM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string GeneralDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["GENERALDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINTELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINTELETIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessagePACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEPACS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGETELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGETELETIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ImageQualityAssesmentEnum? ImageQualityAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGEQUALITYASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["IMAGEQUALITYASSESMENT"].DataType;
                    return (ImageQualityAssesmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object RadiographyTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOGRAPHYTECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOGRAPHYTECHNIQUE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ComparisonInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPARISONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPARISONINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Results
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RESULTS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINEXTERNALHIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEEXTERNALHIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RequestReasonAssesment? RequestReasonAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTREASONASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTREASONASSESMENT"].DataType;
                    return (RequestReasonAssesment?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyContrastTypeEnum? ContrastType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRASTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CONTRASTTYPE"].DataType;
                    return (RadiologyContrastTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Procedureid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREID"]);
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

            public RadiologyTestByObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RadiologyTestByObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RadiologyTestByObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRadiologyTestByEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? RadiologyRequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOLOGYREQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalRequest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALREQUEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ADDITIONALREQUEST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInPACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINPACS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? TestToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTTOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodyPositionEnum? BodyPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYPOSITION"].DataType;
                    return (RadiologyBodyPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodySiteEnum? BodySite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYSITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYSITE"].DataType;
                    return (RadiologyBodySiteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BIRIM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string GeneralDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["GENERALDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINTELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINTELETIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessagePACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEPACS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGETELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGETELETIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ImageQualityAssesmentEnum? ImageQualityAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGEQUALITYASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["IMAGEQUALITYASSESMENT"].DataType;
                    return (ImageQualityAssesmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object RadiographyTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOGRAPHYTECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOGRAPHYTECHNIQUE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ComparisonInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPARISONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPARISONINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Results
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RESULTS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINEXTERNALHIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEEXTERNALHIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RequestReasonAssesment? RequestReasonAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTREASONASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTREASONASSESMENT"].DataType;
                    return (RequestReasonAssesment?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyContrastTypeEnum? ContrastType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRASTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CONTRASTTYPE"].DataType;
                    return (RadiologyContrastTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTestByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRadiologyTestBySubEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? RadiologyRequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOLOGYREQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalRequest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALREQUEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ADDITIONALREQUEST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInPACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINPACS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? TestToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTTOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodyPositionEnum? BodyPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYPOSITION"].DataType;
                    return (RadiologyBodyPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodySiteEnum? BodySite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYSITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYSITE"].DataType;
                    return (RadiologyBodySiteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BIRIM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string GeneralDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["GENERALDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINTELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINTELETIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessagePACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEPACS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGETELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGETELETIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ImageQualityAssesmentEnum? ImageQualityAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGEQUALITYASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["IMAGEQUALITYASSESMENT"].DataType;
                    return (ImageQualityAssesmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object RadiographyTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOGRAPHYTECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOGRAPHYTECHNIQUE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ComparisonInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPARISONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPARISONINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Results
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RESULTS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINEXTERNALHIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEEXTERNALHIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RequestReasonAssesment? RequestReasonAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTREASONASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTREASONASSESMENT"].DataType;
                    return (RequestReasonAssesment?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyContrastTypeEnum? ContrastType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRASTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CONTRASTTYPE"].DataType;
                    return (RadiologyContrastTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTestBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByRadTestWorklistDateReport_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Equipmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EQUIPMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESRADIOLOGYEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
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

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
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

            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Descriptionforworklist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByRadTestWorklistDateReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByRadTestWorklistDateReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByRadTestWorklistDateReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRadiologyTestStatisticsByFilter_Class : TTReportNqlObject 
        {
            public Guid? Radiologytestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RADIOLOGYTESTOBJECTID"]);
                }
            }

            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
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

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public string Testcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Reportedby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTestStatisticsByFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestStatisticsByFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestStatisticsByFilter_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByRadTestFilterExpressionReport_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Equipmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EQUIPMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESRADIOLOGYEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
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

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
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

            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Descriptionforworklist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByRadTestFilterExpressionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByRadTestFilterExpressionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByRadTestFilterExpressionReport_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_RADYOLOJI_SONUC_Class : TTReportNqlObject 
        {
            public Guid? Radyoloji_sonuc_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RADYOLOJI_SONUC_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Radyoloji_ornek_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RADYOLOJI_ORNEK_KODU"]);
                }
            }

            public string Tetkik_sonucu_metin
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETKIK_SONUCU_METIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Tetkik_sonucu_formatli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TETKIK_SONUCU_FORMATLI"]);
                }
            }

            public Object Icerik_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ICERIK_TURU"]);
                }
            }

            public Object Rapor_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RAPOR_TURU"]);
                }
            }

            public Guid? Rapor_yazan_personel_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RAPOR_YAZAN_PERSONEL_KODU"]);
                }
            }

            public Guid? Onaylayan_personel_kodu_1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ONAYLAYAN_PERSONEL_KODU_1"]);
                }
            }

            public Object Onaylayan_personel_kodu_2
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ONAYLAYAN_PERSONEL_KODU_2"]);
                }
            }

            public Object Onaylayan_personel_kodu_3
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ONAYLAYAN_PERSONEL_KODU_3"]);
                }
            }

            public Object Uzman_onay_zamani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UZMAN_ONAY_ZAMANI"]);
                }
            }

            public DateTime? Rapor_kayit_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR_KAYIT_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public VEM_RADYOLOJI_SONUC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_RADYOLOJI_SONUC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_RADYOLOJI_SONUC_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForRadiology_Class : TTReportNqlObject 
        {
            public long? Requestno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Testcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORID"]);
                }
            }

            public string Requestedclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
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

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForRadiology_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForRadiology_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForRadiology_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountRadiology_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountRadiology_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountRadiology_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountRadiology_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientOldRadiologyTestByDate_Class : TTReportNqlObject 
        {
            public Guid? Radtestobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RADTESTOBJID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Testcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requesteddoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
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

            public GetPatientOldRadiologyTestByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientOldRadiologyTestByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientOldRadiologyTestByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientRadiologicalResultsDetail_Class : TTReportNqlObject 
        {
            public long? Requestno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Testcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctorid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORID"]);
                }
            }

            public string Requestedclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
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

            public GetPatientRadiologicalResultsDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientRadiologicalResultsDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientRadiologicalResultsDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllRadiologyWithFilter_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? RadiologyRequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOLOGYREQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOLOGYREQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalRequest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALREQUEST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ADDITIONALREQUEST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OwnerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["OWNERTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInPACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINPACS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? TestToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TESTTOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodyPositionEnum? BodyPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYPOSITION"].DataType;
                    return (RadiologyBodyPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyBodySiteEnum? BodySite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BODYSITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BODYSITE"].DataType;
                    return (RadiologyBodySiteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsProcedureRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPROCEDUREREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISPROCEDUREREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccessionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCESSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACCESSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["BIRIM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsResultSeen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESULTSEEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISRESULTSEEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string GeneralDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["GENERALDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINTELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINTELETIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessagePACS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEPACS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEPACS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageTELETIP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGETELETIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGETELETIP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ImageQualityAssesmentEnum? ImageQualityAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGEQUALITYASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["IMAGEQUALITYASSESMENT"].DataType;
                    return (ImageQualityAssesmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object RadiographyTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOGRAPHYTECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RADIOGRAPHYTECHNIQUE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ComparisonInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPARISONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["COMPARISONINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Results
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["RESULTS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsMessageInExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMESSAGEINEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ISMESSAGEINEXTERNALHIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ACKMessageExternalHIS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACKMESSAGEEXTERNALHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["ACKMESSAGEEXTERNALHIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RequestReasonAssesment? RequestReasonAssesment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTREASONASSESMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["REQUESTREASONASSESMENT"].DataType;
                    return (RequestReasonAssesment?)(int)dataType.ConvertValue(val);
                }
            }

            public RadiologyContrastTypeEnum? ContrastType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRASTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].AllPropertyDefs["CONTRASTTYPE"].DataType;
                    return (RadiologyContrastTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetAllRadiologyWithFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllRadiologyWithFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllRadiologyWithFilter_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountRadiologyTestByReqAcceptionStateByDate_Class : TTReportNqlObject 
        {
            public Object Radiologytestcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RADIOLOGYTESTCOUNT"]);
                }
            }

            public GetCountRadiologyTestByReqAcceptionStateByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountRadiologyTestByReqAcceptionStateByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountRadiologyTestByReqAcceptionStateByDate_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Onayda
    /// </summary>
            public static Guid Approve { get { return new Guid("28739443-e6b8-41e7-ac75-3a540874471e"); } }
    /// <summary>
    /// Randevu
    /// </summary>
            public static Guid Appointment { get { return new Guid("8c10952f-a4d9-4007-a8fb-1660dba7b45d"); } }
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("08ad8075-a8db-4b81-a798-9f707a2bee73"); } }
    /// <summary>
    /// Rapor Giriş
    /// </summary>
            public static Guid ResultEntry { get { return new Guid("dbd208e3-3b58-4fc1-98a7-57e651bc5035"); } }
    /// <summary>
    /// Çekim Yapıldı
    /// </summary>
            public static Guid Completed { get { return new Guid("8dc60b22-7a81-43a9-ac53-7ad0efb1fb8a"); } }
    /// <summary>
    /// Rapor Onaylandı
    /// </summary>
            public static Guid Reported { get { return new Guid("c3f04846-a2b1-4e8d-b7b6-4b248eccecbe"); } }
    /// <summary>
    /// İşlem İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2bdac399-eae5-40e7-8b5a-ba4d2bdd630e"); } }
            public static Guid Reject { get { return new Guid("916410d2-2fa8-460c-a0cd-db9e19e8303d"); } }
    /// <summary>
    /// İstek Kabul
    /// </summary>
            public static Guid RequestAcception { get { return new Guid("6b05d04d-f08e-4752-97f6-c0f88963f859"); } }
            public static Guid New { get { return new Guid("66151cc1-9a6a-4961-a2f5-e7528f65a6f9"); } }
            public static Guid AdmissionAppointment { get { return new Guid("28dceff5-3512-4dd3-929f-c7cd4a7393cd"); } }
        }

        public static BindingList<RadiologyTest> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RadiologyTest> GetTests(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetTests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList);
        }

    /// <summary>
    /// Radyoloji Randevu Bilgisi
    /// </summary>
        public static BindingList<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class> RadiologyTestAppointmentInfoQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestAppointmentInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Radyoloji Randevu Bilgisi
    /// </summary>
        public static BindingList<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class> RadiologyTestAppointmentInfoQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestAppointmentInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestAppointmentInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest> GetRadTestByPatientByTestByDate(TTObjectContext objectContext, string PATIENTID, string TESTID, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadTestByPatientByTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("TESTID", TESTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList);
        }

        public static BindingList<RadiologyTest.RadiologyTestResultReport_Class> RadiologyTestResultReport(string PARAMOBJID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestResultReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestResultReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.RadiologyTestResultReport_Class> RadiologyTestResultReport(TTObjectContext objectContext, string PARAMOBJID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestResultReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestResultReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class> RadiologyTestPatientInfoReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class> RadiologyTestPatientInfoReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestPatientInfoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class> OLAP_GetCancelledRadiologyTest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["OLAP_GetCancelledRadiologyTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class> OLAP_GetCancelledRadiologyTest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["OLAP_GetCancelledRadiologyTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.OLAP_GetCancelledRadiologyTest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest> GetByWLFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetByWLFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RadiologyTest.RadiologyTestByObjectIDQuery_Class> RadiologyTestByObjectIDQuery(string PARAMTESTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTESTOBJID", PARAMTESTOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestByObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.RadiologyTestByObjectIDQuery_Class> RadiologyTestByObjectIDQuery(TTObjectContext objectContext, string PARAMTESTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["RadiologyTestByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTESTOBJID", PARAMTESTOBJID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.RadiologyTestByObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetRadiologyTestByEpisode_Class> GetRadiologyTestByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadiologyTestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetRadiologyTestByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetRadiologyTestByEpisode_Class> GetRadiologyTestByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadiologyTestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetRadiologyTestByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest> GetRadTestByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadTestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList);
        }

        public static BindingList<RadiologyTest> GetRadTestBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadTestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList);
        }

        public static BindingList<RadiologyTest.GetRadiologyTestBySubEpisode_Class> GetRadiologyTestBySubEpisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadiologyTestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetRadiologyTestBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetRadiologyTestBySubEpisode_Class> GetRadiologyTestBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadiologyTestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetRadiologyTestBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetByRadTestWorklistDateReport_Class> GetByRadTestWorklistDateReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetByRadTestWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetByRadTestWorklistDateReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetByRadTestWorklistDateReport_Class> GetByRadTestWorklistDateReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetByRadTestWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetByRadTestWorklistDateReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class> GetRadiologyTestStatisticsByFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadiologyTestStatisticsByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class> GetRadiologyTestStatisticsByFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadiologyTestStatisticsByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetRadiologyTestStatisticsByFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetByRadTestFilterExpressionReport_Class> GetByRadTestFilterExpressionReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetByRadTestFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetByRadTestFilterExpressionReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetByRadTestFilterExpressionReport_Class> GetByRadTestFilterExpressionReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetByRadTestFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetByRadTestFilterExpressionReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest> GetByFilterExpressionStatistics(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetByFilterExpressionStatistics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RadiologyTest.VEM_RADYOLOJI_SONUC_Class> VEM_RADYOLOJI_SONUC(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["VEM_RADYOLOJI_SONUC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.VEM_RADYOLOJI_SONUC_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.VEM_RADYOLOJI_SONUC_Class> VEM_RADYOLOJI_SONUC(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["VEM_RADYOLOJI_SONUC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.VEM_RADYOLOJI_SONUC_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Radyoloji Geçmişi
    /// </summary>
        public static BindingList<RadiologyTest.GetOldInfoForRadiology_Class> GetOldInfoForRadiology(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetOldInfoForRadiology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetOldInfoForRadiology_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Radyoloji Geçmişi
    /// </summary>
        public static BindingList<RadiologyTest.GetOldInfoForRadiology_Class> GetOldInfoForRadiology(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetOldInfoForRadiology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetOldInfoForRadiology_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmiş Radyoloji Sayısı
    /// </summary>
        public static BindingList<RadiologyTest.GetOldInfoCountRadiology_Class> GetOldInfoCountRadiology(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetOldInfoCountRadiology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetOldInfoCountRadiology_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmiş Radyoloji Sayısı
    /// </summary>
        public static BindingList<RadiologyTest.GetOldInfoCountRadiology_Class> GetOldInfoCountRadiology(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetOldInfoCountRadiology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetOldInfoCountRadiology_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetPatientOldRadiologyTestByDate_Class> GetPatientOldRadiologyTestByDate(string PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetPatientOldRadiologyTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetPatientOldRadiologyTestByDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetPatientOldRadiologyTestByDate_Class> GetPatientOldRadiologyTestByDate(TTObjectContext objectContext, string PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetPatientOldRadiologyTestByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetPatientOldRadiologyTestByDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetPatientRadiologicalResultsDetail_Class> GetPatientRadiologicalResultsDetail(string RESULTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetPatientRadiologicalResultsDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESULTID", RESULTID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetPatientRadiologicalResultsDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetPatientRadiologicalResultsDetail_Class> GetPatientRadiologicalResultsDetail(TTObjectContext objectContext, string RESULTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetPatientRadiologicalResultsDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESULTID", RESULTID);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetPatientRadiologicalResultsDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetAllRadiologyWithFilter_Class> GetAllRadiologyWithFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetAllRadiologyWithFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetAllRadiologyWithFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest.GetAllRadiologyWithFilter_Class> GetAllRadiologyWithFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetAllRadiologyWithFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetAllRadiologyWithFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTest> GetRadTestWithEquipmentBySE(TTObjectContext objectContext, Guid SUBEPISODEID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetRadTestWithEquipmentBySE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTest>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RadiologyTest.GetCountRadiologyTestByReqAcceptionStateByDate_Class> GetCountRadiologyTestByReqAcceptionStateByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetCountRadiologyTestByReqAcceptionStateByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetCountRadiologyTestByReqAcceptionStateByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTest.GetCountRadiologyTestByReqAcceptionStateByDate_Class> GetCountRadiologyTestByReqAcceptionStateByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEST"].QueryDefs["GetCountRadiologyTestByReqAcceptionStateByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<RadiologyTest.GetCountRadiologyTestByReqAcceptionStateByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public TTSequence RadiologyRequestNo
        {
            get { return GetSequence("RADIOLOGYREQUESTNO"); }
        }

    /// <summary>
    /// Ek İstek
    /// </summary>
        public string AdditionalRequest
        {
            get { return (string)this["ADDITIONALREQUEST"]; }
            set { this["ADDITIONALREQUEST"] = value; }
        }

    /// <summary>
    /// Owner Tipi
    /// </summary>
        public string OwnerType
        {
            get { return (string)this["OWNERTYPE"]; }
            set { this["OWNERTYPE"] = value; }
        }

    /// <summary>
    /// Test Tarihi
    /// </summary>
        public DateTime? TestDate
        {
            get { return (DateTime?)this["TESTDATE"]; }
            set { this["TESTDATE"] = value; }
        }

    /// <summary>
    /// Mesaj PACSta
    /// </summary>
        public bool? IsMessageInPACS
        {
            get { return (bool?)this["ISMESSAGEINPACS"]; }
            set { this["ISMESSAGEINPACS"] = value; }
        }

    /// <summary>
    /// Diş Numarası
    /// </summary>
        public ToothNumberEnum? TestToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TESTTOOTHNUMBER"]; }
            set { this["TESTTOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? DisTaahhutNo
        {
            get { return (int?)this["DISTAAHHUTNO"]; }
            set { this["DISTAAHHUTNO"] = value; }
        }

    /// <summary>
    /// Günübirlik Takip Al
    /// </summary>
        public bool? IsGunubirlikTakip
        {
            get { return (bool?)this["ISGUNUBIRLIKTAKIP"]; }
            set { this["ISGUNUBIRLIKTAKIP"] = value; }
        }

    /// <summary>
    /// Vücut Pozisyonu
    /// </summary>
        public RadiologyBodyPositionEnum? BodyPosition
        {
            get { return (RadiologyBodyPositionEnum?)(int?)this["BODYPOSITION"]; }
            set { this["BODYPOSITION"] = value; }
        }

    /// <summary>
    /// Vücut Bölgesi
    /// </summary>
        public RadiologyBodySiteEnum? BodySite
        {
            get { return (RadiologyBodySiteEnum?)(int?)this["BODYSITE"]; }
            set { this["BODYSITE"] = value; }
        }

    /// <summary>
    /// Seç
    /// </summary>
        public bool? Check
        {
            get { return (bool?)this["CHECK"]; }
            set { this["CHECK"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string ReportTxt
        {
            get { return (string)this["REPORTTXT"]; }
            set { this["REPORTTXT"] = value; }
        }

        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public bool? Anomali
        {
            get { return (bool?)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
        }

    /// <summary>
    /// İşlem Tekrarı
    /// </summary>
        public bool? IsProcedureRepeated
        {
            get { return (bool?)this["ISPROCEDUREREPEATED"]; }
            set { this["ISPROCEDUREREPEATED"] = value; }
        }

    /// <summary>
    /// Diş Numarası
    /// </summary>
        public string ToothNumber
        {
            get { return (string)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Giriş Numarası
    /// </summary>
        public string AccessionNo
        {
            get { return (string)this["ACCESSIONNO"]; }
            set { this["ACCESSIONNO"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string birim
        {
            get { return (string)this["BIRIM"]; }
            set { this["BIRIM"] = value; }
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
    /// Sonuç görüntülendi ise True olacak.
    /// </summary>
        public bool? IsResultSeen
        {
            get { return (bool?)this["ISRESULTSEEN"]; }
            set { this["ISRESULTSEEN"] = value; }
        }

    /// <summary>
    /// Kısa Anamnez ve Klinik Bulgular
    /// </summary>
        public object PreDiagnosis
        {
            get { return (object)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Genel Açıklama
    /// </summary>
        public string GeneralDescription
        {
            get { return (string)this["GENERALDESCRIPTION"]; }
            set { this["GENERALDESCRIPTION"] = value; }
        }

        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

        public object MTSConclusion
        {
            get { return (object)this["MTSCONCLUSION"]; }
            set { this["MTSCONCLUSION"] = value; }
        }

    /// <summary>
    /// Mesaj İstem TELETIPta
    /// </summary>
        public bool? IsMessageInTELETIP
        {
            get { return (bool?)this["ISMESSAGEINTELETIP"]; }
            set { this["ISMESSAGEINTELETIP"] = value; }
        }

    /// <summary>
    /// PACS a gönderilen mesaj ACK bilgisi
    /// </summary>
        public string ACKMessagePACS
        {
            get { return (string)this["ACKMESSAGEPACS"]; }
            set { this["ACKMESSAGEPACS"] = value; }
        }

    /// <summary>
    /// TELETIP a gönderilen mesaj ACK bilgisi
    /// </summary>
        public string ACKMessageTELETIP
        {
            get { return (string)this["ACKMESSAGETELETIP"]; }
            set { this["ACKMESSAGETELETIP"] = value; }
        }

    /// <summary>
    /// Çekim Kalitesi Değerlendirme
    /// </summary>
        public ImageQualityAssesmentEnum? ImageQualityAssesment
        {
            get { return (ImageQualityAssesmentEnum?)(int?)this["IMAGEQUALITYASSESMENT"]; }
            set { this["IMAGEQUALITYASSESMENT"] = value; }
        }

    /// <summary>
    /// Çekim Tekniği
    /// </summary>
        public object RadiographyTechnique
        {
            get { return (object)this["RADIOGRAPHYTECHNIQUE"]; }
            set { this["RADIOGRAPHYTECHNIQUE"] = value; }
        }

    /// <summary>
    /// Karşılaştırma Bilgisi
    /// </summary>
        public object ComparisonInfo
        {
            get { return (object)this["COMPARISONINFO"]; }
            set { this["COMPARISONINFO"] = value; }
        }

    /// <summary>
    /// Bulgular
    /// </summary>
        public object Results
        {
            get { return (object)this["RESULTS"]; }
            set { this["RESULTS"] = value; }
        }

    /// <summary>
    /// Mesaj İstem TELETIPta
    /// </summary>
        public bool? IsMessageInExternalHIS
        {
            get { return (bool?)this["ISMESSAGEINEXTERNALHIS"]; }
            set { this["ISMESSAGEINEXTERNALHIS"] = value; }
        }

    /// <summary>
    /// TELETIP a gönderilen mesaj ACK bilgisi
    /// </summary>
        public string ACKMessageExternalHIS
        {
            get { return (string)this["ACKMESSAGEEXTERNALHIS"]; }
            set { this["ACKMESSAGEEXTERNALHIS"] = value; }
        }

    /// <summary>
    /// Tetkik İstem Nedeni Değerlendirme 
    /// </summary>
        public RequestReasonAssesment? RequestReasonAssesment
        {
            get { return (RequestReasonAssesment?)(int?)this["REQUESTREASONASSESMENT"]; }
            set { this["REQUESTREASONASSESMENT"] = value; }
        }

    /// <summary>
    /// Kontrastlı - Kontrsatsız
    /// </summary>
        public RadiologyContrastTypeEnum? ContrastType
        {
            get { return (RadiologyContrastTypeEnum?)(int?)this["CONTRASTTYPE"]; }
            set { this["CONTRASTTYPE"] = value; }
        }

    /// <summary>
    /// Rapor Eden İlişkisi
    /// </summary>
        public ResUser ReportedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("REPORTEDBY"); }
            set { this["REPORTEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Onaylayan İlişkisi
    /// </summary>
        public ResUser ApprovedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVEDBY"); }
            set { this["APPROVEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bölüm İlişkisi
    /// </summary>
        public ResRadiologyDepartment Department
        {
            get { return (ResRadiologyDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Red Nedeni İlişkisi
    /// </summary>
        public RadiologyRejectReasonDefinition RejectReason
        {
            get { return (RadiologyRejectReasonDefinition)((ITTObject)this).GetParent("REJECTREASON"); }
            set { this["REJECTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tekrar Nedeni İlişkisi
    /// </summary>
        public RadiologyRepeatReasonDefinition RepeatReason
        {
            get { return (RadiologyRepeatReasonDefinition)((ITTObject)this).GetParent("REPEATREASON"); }
            set { this["REPEATREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Cihaz İlişkisi
    /// </summary>
        public ResRadiologyEquipment Equipment
        {
            get { return (ResRadiologyEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyoloji OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyoloji AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyoloji SagSol
    /// </summary>
        public SagSol SagSol
        {
            get { return (SagSol)((ITTObject)this).GetParent("SAGSOL"); }
            set { this["SAGSOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyAdditionalReport RadiologyAdditionalReport
        {
            get { return (RadiologyAdditionalReport)((ITTObject)this).GetParent("RADIOLOGYADDITIONALREPORT"); }
            set { this["RADIOLOGYADDITIONALREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MasterResource
    /// </summary>
        public ResObservationUnit ResObservationUnit
        {
            get 
            {   
                if (MasterResource is ResObservationUnit)
                    return (ResObservationUnit)MasterResource; 
                return null;
            }            
            set { MasterResource = value; }
        }

        public Radiology Radiology
        {
            get 
            {   
                if (EpisodeAction is Radiology)
                    return (Radiology)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public RadiologyTestDefinition RadiologyTestDefinition
        {
            get 
            {   
                if (ProcedureObject is RadiologyTestDefinition)
                    return (RadiologyTestDefinition)ProcedureObject; 
                return null;
            }            
            set { ProcedureObject = value; }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("14a9a383-e024-4989-afdc-883d61f0f0b9"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for RadiologyTest Çoklu Özel Durum
    /// </summary>
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateExternalServiceRequestsCollection()
        {
            _ExternalServiceRequests = new ExternalProviderServiceRequest.ChildExternalProviderServiceRequestCollection(this, new Guid("5f8b3a83-ff0b-4876-882d-73b6445f893a"));
            ((ITTChildObjectCollection)_ExternalServiceRequests).GetChildren();
        }

        protected ExternalProviderServiceRequest.ChildExternalProviderServiceRequestCollection _ExternalServiceRequests = null;
        public ExternalProviderServiceRequest.ChildExternalProviderServiceRequestCollection ExternalServiceRequests
        {
            get
            {
                if (_ExternalServiceRequests == null)
                    CreateExternalServiceRequestsCollection();
                return _ExternalServiceRequests;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _RadiologyTestTreatmentMaterial = new RadiologyMaterial.ChildRadiologyMaterialCollection(_TreatmentMaterials, "RadiologyTestTreatmentMaterial");
            _RadiologyTest_SurgeryDirectPurchaseGrids = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(_TreatmentMaterials, "RadiologyTest_SurgeryDirectPurchaseGrids");
        }

        private RadiologyMaterial.ChildRadiologyMaterialCollection _RadiologyTestTreatmentMaterial = null;
        public RadiologyMaterial.ChildRadiologyMaterialCollection RadiologyTestTreatmentMaterial
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _RadiologyTestTreatmentMaterial;
            }            
        }

        private SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _RadiologyTest_SurgeryDirectPurchaseGrids = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection RadiologyTest_SurgeryDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _RadiologyTest_SurgeryDirectPurchaseGrids;
            }            
        }

        protected RadiologyTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTEST", dataRow) { }
        protected RadiologyTest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTEST", dataRow, isImported) { }
        public RadiologyTest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTest() : base() { }

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