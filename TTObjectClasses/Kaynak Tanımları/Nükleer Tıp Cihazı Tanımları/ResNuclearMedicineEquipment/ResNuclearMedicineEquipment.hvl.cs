
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResNuclearMedicineEquipment")] 

    /// <summary>
    /// Nükleer Tıp Cihazı
    /// </summary>
    public  partial class ResNuclearMedicineEquipment : ResEquipment
    {
        public class ResNuclearMedicineEquipmentList : TTObjectCollection<ResNuclearMedicineEquipment> { }
                    
        public class ChildResNuclearMedicineEquipmentCollection : TTObject.TTChildObjectCollection<ResNuclearMedicineEquipment>
        {
            public ChildResNuclearMedicineEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResNuclearMedicineEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResNucEquipmentNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["LOCATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["APPOINTMENTLIMIT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ACTIONCANCELLEDTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ENABLEDTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["APRILQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["AUGUSTQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["JUNEQUATA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["LASTQUOTADATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["NOVEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["OCTOBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["SEPTEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["WEEKLYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["DONTSHOWHCDEPARTMENTREPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["CONTACTPHONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ISETIQUETTEPRINTED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ETIQUETTECOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["PCSINUSE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["MARCHQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["DAILYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["DECEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["FEBRUARYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["JANUARYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["JULYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["MAYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["MONTHLYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["NOTCHARGEHCEXAMINATIONPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["CONTACTADDRESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["IGNOREQUOTACONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["INPATIENTQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["HIMSSREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["ISMEDICALWASTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["RESSECTIONTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["RESOURCESTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["RESOURCEENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? OptionalDelayMinute
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPTIONALDELAYMINUTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["OPTIONALDELAYMINUTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["SEXEXCEPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["MAXAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["DONTTAKEGSSPROVISION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["MINAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MkysNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["MKYSNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StateDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].AllPropertyDefs["STATEDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResNucEquipmentNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResNucEquipmentNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResNucEquipmentNQL_Class() : base() { }
        }

        public static BindingList<ResNuclearMedicineEquipment.GetResNucEquipmentNQL_Class> GetResNucEquipmentNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].QueryDefs["GetResNucEquipmentNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResNuclearMedicineEquipment.GetResNucEquipmentNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResNuclearMedicineEquipment.GetResNucEquipmentNQL_Class> GetResNucEquipmentNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESNUCLEARMEDICINEEQUIPMENT"].QueryDefs["GetResNucEquipmentNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResNuclearMedicineEquipment.GetResNucEquipmentNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected ResNuclearMedicineEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResNuclearMedicineEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResNuclearMedicineEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResNuclearMedicineEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResNuclearMedicineEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESNUCLEARMEDICINEEQUIPMENT", dataRow) { }
        protected ResNuclearMedicineEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESNUCLEARMEDICINEEQUIPMENT", dataRow, isImported) { }
        public ResNuclearMedicineEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResNuclearMedicineEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResNuclearMedicineEquipment() : base() { }

    }
}