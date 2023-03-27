
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResEquipment")] 

    /// <summary>
    /// Cihaz
    /// </summary>
    public  partial class ResEquipment : ResSection
    {
        public class ResEquipmentList : TTObjectCollection<ResEquipment> { }
                    
        public class ChildResEquipmentCollection : TTObject.TTChildObjectCollection<ResEquipment>
        {
            public ChildResEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEquipmentDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEquipmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEquipmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEquipmentDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_CIHAZ_Class : TTReportNqlObject 
        {
            public Guid? Cihaz_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CIHAZ_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Cihaz_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CIHAZ_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cihaz_grubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CIHAZ_GRUBU"]);
                }
            }

            public Object Birim_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRIM_KODU"]);
                }
            }

            public Object Model
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MODEL"]);
                }
            }

            public Object Marka
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MARKA"]);
                }
            }

            public Object Seri_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SERI_NUMARASI"]);
                }
            }

            public Object Mkys_kunye_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_KUNYE_NUMARASI"]);
                }
            }

            public Boolean? Aktiflik_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIFLIK_BILGISI"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public VEM_CIHAZ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_CIHAZ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_CIHAZ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHemodialysisResEquipment_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["LOCATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["APPOINTMENTLIMIT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ACTIONCANCELLEDTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ENABLEDTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["APRILQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["AUGUSTQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["JUNEQUATA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["LASTQUOTADATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NOVEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["OCTOBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["SEPTEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["WEEKLYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["DONTSHOWHCDEPARTMENTREPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["CONTACTPHONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ISETIQUETTEPRINTED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ETIQUETTECOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["PCSINUSE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["MARCHQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["DAILYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["DECEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["FEBRUARYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["JANUARYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["JULYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["MAYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["MONTHLYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["NOTCHARGEHCEXAMINATIONPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["CONTACTADDRESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["IGNOREQUOTACONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["INPATIENTQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["HIMSSREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["ISMEDICALWASTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["RESSECTIONTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["RESOURCESTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["RESOURCEENDTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["OPTIONALDELAYMINUTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["SEXEXCEPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["MAXAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["DONTTAKEGSSPROVISION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["MINAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["MKYSNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].AllPropertyDefs["STATEDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHemodialysisResEquipment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHemodialysisResEquipment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHemodialysisResEquipment_Class() : base() { }
        }

        public static BindingList<ResEquipment.GetEquipmentDefinition_Class> GetEquipmentDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GetEquipmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResEquipment.GetEquipmentDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResEquipment.GetEquipmentDefinition_Class> GetEquipmentDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GetEquipmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResEquipment.GetEquipmentDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResEquipment> GetResEquipments(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GetResEquipments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResEquipment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResEquipment.VEM_CIHAZ_Class> VEM_CIHAZ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["VEM_CIHAZ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResEquipment.VEM_CIHAZ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResEquipment.VEM_CIHAZ_Class> VEM_CIHAZ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["VEM_CIHAZ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResEquipment.VEM_CIHAZ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResEquipment> GETBYMKYSNO(TTObjectContext objectContext, string MKYSNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GETBYMKYSNO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MKYSNO", MKYSNO);

            return ((ITTQuery)objectContext).QueryObjects<ResEquipment>(queryDef, paramList);
        }

        public static BindingList<ResEquipment> GetNotAppointedEquipments(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GetNotAppointedEquipments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResEquipment>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResEquipment.GetHemodialysisResEquipment_Class> GetHemodialysisResEquipment(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GetHemodialysisResEquipment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResEquipment.GetHemodialysisResEquipment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResEquipment.GetHemodialysisResEquipment_Class> GetHemodialysisResEquipment(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESEQUIPMENT"].QueryDefs["GetHemodialysisResEquipment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResEquipment.GetHemodialysisResEquipment_Class>(objectContext, queryDef, paramList, pi);
        }

        public string MkysNo
        {
            get { return (string)this["MKYSNO"]; }
            set { this["MKYSNO"] = value; }
        }

        public string StateDefinition
        {
            get { return (string)this["STATEDEFINITION"]; }
            set { this["STATEDEFINITION"] = value; }
        }

    /// <summary>
    /// Klinik
    /// </summary>
        public ResClinic Clinic
        {
            get { return (ResClinic)((ITTObject)this).GetParent("CLINIC"); }
            set { this["CLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Labaratuvar Birimi
    /// </summary>
        public ResObservationUnit ObservationUnit
        {
            get { return (ResObservationUnit)((ITTObject)this).GetParent("OBSERVATIONUNIT"); }
            set { this["OBSERVATIONUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDialysisTreatmentEquipmentGridsCollection()
        {
            _DialysisTreatmentEquipmentGrids = new DialysisTreatmentEquipmentGrid.ChildDialysisTreatmentEquipmentGridCollection(this, new Guid("6e76890b-e219-4c73-ac95-36950572b5b6"));
            ((ITTChildObjectCollection)_DialysisTreatmentEquipmentGrids).GetChildren();
        }

        protected DialysisTreatmentEquipmentGrid.ChildDialysisTreatmentEquipmentGridCollection _DialysisTreatmentEquipmentGrids = null;
    /// <summary>
    /// Child collection for Tedavi Cihazı
    /// </summary>
        public DialysisTreatmentEquipmentGrid.ChildDialysisTreatmentEquipmentGridCollection DialysisTreatmentEquipmentGrids
        {
            get
            {
                if (_DialysisTreatmentEquipmentGrids == null)
                    CreateDialysisTreatmentEquipmentGridsCollection();
                return _DialysisTreatmentEquipmentGrids;
            }
        }

        virtual protected void CreateHyperbaricTreatmentEquipmentsCollection()
        {
            _HyperbaricTreatmentEquipments = new HyperbaricTreatmentEquipment.ChildHyperbaricTreatmentEquipmentCollection(this, new Guid("080d7eda-c951-4064-9cec-583dd6cd9363"));
            ((ITTChildObjectCollection)_HyperbaricTreatmentEquipments).GetChildren();
        }

        protected HyperbaricTreatmentEquipment.ChildHyperbaricTreatmentEquipmentCollection _HyperbaricTreatmentEquipments = null;
        public HyperbaricTreatmentEquipment.ChildHyperbaricTreatmentEquipmentCollection HyperbaricTreatmentEquipments
        {
            get
            {
                if (_HyperbaricTreatmentEquipments == null)
                    CreateHyperbaricTreatmentEquipmentsCollection();
                return _HyperbaricTreatmentEquipments;
            }
        }

        protected ResEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESEQUIPMENT", dataRow) { }
        protected ResEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESEQUIPMENT", dataRow, isImported) { }
        public ResEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResEquipment() : base() { }

    }
}