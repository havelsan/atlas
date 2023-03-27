
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResClinic")] 

    /// <summary>
    /// Klinik
    /// </summary>
    public  partial class ResClinic : ResWard
    {
        public class ResClinicList : TTObjectCollection<ResClinic> { }
                    
        public class ChildResClinicCollection : TTObject.TTChildObjectCollection<ResClinic>
        {
            public ChildResClinicCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResClinicCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetClinicDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Departmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetClinicDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetClinicDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetClinicDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResClinic_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public OLAP_ResClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllClinics_Class : TTReportNqlObject 
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

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Location
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["LOCATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeskPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESKPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? AppointmentLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["APPOINTMENTLIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ActionCancelledTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONCANCELLEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ACTIONCANCELLEDTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public ResourceEnableType? EnabledType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENABLEDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ENABLEDTYPE"].DataType;
                    return (ResourceEnableType?)(int)dataType.ConvertValue(val);
                }
            }

            public int? AprilQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APRILQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["APRILQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? AugustQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUGUSTQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["AUGUSTQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? JuneQuata
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JUNEQUATA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["JUNEQUATA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastQuotaDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTQUOTADATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["LASTQUOTADATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? NovemberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOVEMBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NOVEMBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? OctoberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OCTOBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["OCTOBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SeptemberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEPTEMBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["SEPTEMBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? WeeklyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["WEEKLYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? DontShowHCDepartmentReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONTSHOWHCDEPARTMENTREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["DONTSHOWHCDEPARTMENTREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ContactPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTACTPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["CONTACTPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsToBeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTOBECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEtiquettePrinted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISETIQUETTEPRINTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ISETIQUETTEPRINTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? EtiquetteCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETIQUETTECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ETIQUETTECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? PCSInUse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PCSINUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["PCSINUSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MarchQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARCHQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["MARCHQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DailyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["DAILYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DecemberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECEMBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["DECEMBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FebruaryQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FEBRUARYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["FEBRUARYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? JanuaryQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JANUARYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["JANUARYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? JulyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JULYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["JULYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MayQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["MAYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MonthlyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONTHLYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["MONTHLYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? NotChargeHCExaminationPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCHARGEHCEXAMINATIONPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NOTCHARGEHCEXAMINATIONPRICE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ContactAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTACTADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["CONTACTADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreQuotaControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREQUOTACONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["IGNOREQUOTACONTROL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? InpatientQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["INPATIENTQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? HimssRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HIMSSREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["HIMSSREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsmedicalWaste
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMEDICALWASTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ISMEDICALWASTE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ResSectionTypeEnum? ResSectionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["RESSECTIONTYPE"].DataType;
                    return (ResSectionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResourceStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCESTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["RESOURCESTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResourceEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCEENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["RESOURCEENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? ShownInKiosk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWNINKIOSK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["SHOWNINKIOSK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? OptionalDelayMinute
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPTIONALDELAYMINUTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["OPTIONALDELAYMINUTE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? SexException
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEXEXCEPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["SEXEXCEPTION"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MaxAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["MAXAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? DontTakeGSSProvision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONTTAKEGSSPROVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["DONTTAKEGSSPROVISION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MinAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["MINAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? PercentageOfEmptyBedFor112
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERCENTAGEOFEMPTYBEDFOR112"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["PERCENTAGEOFEMPTYBEDFOR112"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Floor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FLOOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["FLOOR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIntensiveCare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINTENSIVECARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ISINTENSIVECARE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public BedProcedureTypeEnum? BedProcedureType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDPROCEDURETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["BEDPROCEDURETYPE"].DataType;
                    return (BedProcedureTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergencyClinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ISEMERGENCYCLINIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? PreDischargeLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDISCHARGELIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["PREDISCHARGELIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAllowAppointment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISALLOWAPPOINTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["ISALLOWAPPOINTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasCertificate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCERTIFICATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["HASCERTIFICATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetAllClinics_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllClinics_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllClinics_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyClinics_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetEmergencyClinics_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyClinics_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyClinics_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveClinicsBySpeciality_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveClinicsBySpeciality_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveClinicsBySpeciality_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveClinicsBySpeciality_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveClinics_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveClinics_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveClinics_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveClinics_Class() : base() { }
        }

        public static BindingList<ResClinic> ClinicExceptIntensiveCareListNQL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["ClinicExceptIntensiveCareListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResClinic> GetByDepartment(TTObjectContext objectContext, string DEPARTMENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetByDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList);
        }

        public static BindingList<ResClinic.GetClinicDefinition_Class> GetClinicDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetClinicDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetClinicDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResClinic.GetClinicDefinition_Class> GetClinicDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetClinicDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetClinicDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResClinic> OLAP_ResClinic2(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["OLAP_ResClinic2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList);
        }

        public static BindingList<ResClinic.OLAP_ResClinic_Class> OLAP_ResClinic(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["OLAP_ResClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.OLAP_ResClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResClinic.OLAP_ResClinic_Class> OLAP_ResClinic(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["OLAP_ResClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.OLAP_ResClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResClinic> GetClinicByMedulaBrans(TTObjectContext objectContext, string BRANS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetClinicByMedulaBrans"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BRANS", BRANS);

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList);
        }

        public static BindingList<ResClinic.GetAllClinics_Class> GetAllClinics(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetAllClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetAllClinics_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResClinic.GetAllClinics_Class> GetAllClinics(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetAllClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetAllClinics_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Acil Klinikleri
    /// </summary>
        public static BindingList<ResClinic.GetEmergencyClinics_Class> GetEmergencyClinics(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetEmergencyClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetEmergencyClinics_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Acil Klinikleri
    /// </summary>
        public static BindingList<ResClinic.GetEmergencyClinics_Class> GetEmergencyClinics(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetEmergencyClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetEmergencyClinics_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResClinic> GetAllActiveClinics(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetAllActiveClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList);
        }

        public static BindingList<ResClinic> GetClinicForDailyOperation(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetClinicForDailyOperation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList);
        }

        public static BindingList<ResClinic> GetDailyClinicAutomatically(TTObjectContext objectContext, string DEPARTMENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetDailyClinicAutomatically"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DEPARTMENT", DEPARTMENT);

            return ((ITTQuery)objectContext).QueryObjects<ResClinic>(queryDef, paramList);
        }

        public static BindingList<ResClinic.GetActiveClinicsBySpeciality_Class> GetActiveClinicsBySpeciality(IList<Guid> SPECIALITY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetActiveClinicsBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALITY", SPECIALITY);

            return TTReportNqlObject.QueryObjects<ResClinic.GetActiveClinicsBySpeciality_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResClinic.GetActiveClinicsBySpeciality_Class> GetActiveClinicsBySpeciality(TTObjectContext objectContext, IList<Guid> SPECIALITY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetActiveClinicsBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALITY", SPECIALITY);

            return TTReportNqlObject.QueryObjects<ResClinic.GetActiveClinicsBySpeciality_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResClinic.GetActiveClinics_Class> GetActiveClinics(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetActiveClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetActiveClinics_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResClinic.GetActiveClinics_Class> GetActiveClinics(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].QueryDefs["GetActiveClinics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResClinic.GetActiveClinics_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Acil Klinik
    /// </summary>
        public bool? IsEmergencyClinic
        {
            get { return (bool?)this["ISEMERGENCYCLINIC"]; }
            set { this["ISEMERGENCYCLINIC"] = value; }
        }

        public int? PreDischargeLimit
        {
            get { return (int?)this["PREDISCHARGELIMIT"]; }
            set { this["PREDISCHARGELIMIT"] = value; }
        }

    /// <summary>
    /// Randevu kullanımı
    /// </summary>
        public bool? IsAllowAppointment
        {
            get { return (bool?)this["ISALLOWAPPOINTMENT"]; }
            set { this["ISALLOWAPPOINTMENT"] = value; }
        }

    /// <summary>
    /// Sertifikalı
    /// </summary>
        public bool? HasCertificate
        {
            get { return (bool?)this["HASCERTIFICATE"]; }
            set { this["HASCERTIFICATE"] = value; }
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEquipmentsCollection()
        {
            _Equipments = new ResEquipment.ChildResEquipmentCollection(this, new Guid("7bc89ad0-2d52-4c4d-a715-31a1edcead9d"));
            ((ITTChildObjectCollection)_Equipments).GetChildren();
        }

        protected ResEquipment.ChildResEquipmentCollection _Equipments = null;
    /// <summary>
    /// Child collection for Klinik
    /// </summary>
        public ResEquipment.ChildResEquipmentCollection Equipments
        {
            get
            {
                if (_Equipments == null)
                    CreateEquipmentsCollection();
                return _Equipments;
            }
        }

        protected ResClinic(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResClinic(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResClinic(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResClinic(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResClinic(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESCLINIC", dataRow) { }
        protected ResClinic(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESCLINIC", dataRow, isImported) { }
        public ResClinic(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResClinic(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResClinic() : base() { }

    }
}