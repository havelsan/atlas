
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalProcedure")] 

    public  partial class DentalProcedure : SubactionProcedureWithDiagnosis
    {
        public class DentalProcedureList : TTObjectCollection<DentalProcedure> { }
                    
        public class ChildDentalProcedureCollection : TTObject.TTChildObjectCollection<DentalProcedure>
        {
            public ChildDentalProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDentalProceduresByEpisodeAction_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ExternalID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["EXTERNALID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ToothNumberEnum? ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? AccountRecordable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTRECORDABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ACCOUNTRECORDABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? PatientPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["PATIENTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public bool? Anomali
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANOMALI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["ANOMALI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? DisTaahhutNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTAAHHUTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DentalPositionEnum? DentalPosition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALPOSITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["DENTALPOSITION"].DataType;
                    return (DentalPositionEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDentalProceduresByEpisodeAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalProceduresByEpisodeAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalProceduresByEpisodeAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDentalProcedureByProcedureDoctorSection_Class : TTReportNqlObject 
        {
            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public Guid? Ressection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESSECTION"]);
                }
            }

            public GetDentalProcedureByProcedureDoctorSection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalProcedureByProcedureDoctorSection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalProcedureByProcedureDoctorSection_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_HASTA_DIS_Class : TTReportNqlObject 
        {
            public Guid? Hasta_dis_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_DIS_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public DentalRequestTypeEnum? Dis_islem_turu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIS_ISLEM_TURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALTREATMENTDEFINITION"].AllPropertyDefs["CATEGORY"].DataType;
                    return (DentalRequestTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Hasta_hizmet_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_HIZMET_KODU"]);
                }
            }

            public int? Dis_taahhut_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIS_TAAHHUT_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["DISTAAHHUTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Dis_durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIS_DURUMU"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public ToothNumberEnum? Dis_kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIS_KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Cene_bolgesi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CENE_BOLGESI"]);
                }
            }

            public Object Sonuc_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_KODU"]);
                }
            }

            public Object Sonuc_mesaji
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SONUC_MESAJI"]);
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

            public VEM_HASTA_DIS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_DIS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_DIS_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDentalProtesisProcedures_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public ToothNumberEnum? ToothNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOOTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].AllPropertyDefs["TOOTHNUMBER"].DataType;
                    return (ToothNumberEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDentalProtesisProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDentalProtesisProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDentalProtesisProcedures_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Completed { get { return new Guid("11ab6822-778d-4c33-a4a5-9d5d1476d2ef"); } }
            public static Guid New { get { return new Guid("6470014d-4a26-4b48-a629-79418078cd85"); } }
            public static Guid Cancelled { get { return new Guid("2f8e0e27-c70a-4a20-b1ba-ceb1c6c64e90"); } }
        }

        public static BindingList<DentalProcedure> GetByExternalID(TTObjectContext objectContext, string EXTERNALID, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetByExternalID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALID", EXTERNALID);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<DentalProcedure>(queryDef, paramList);
        }

        public static BindingList<DentalProcedure.GetDentalProceduresByEpisodeAction_Class> GetDentalProceduresByEpisodeAction(Guid EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetDentalProceduresByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<DentalProcedure.GetDentalProceduresByEpisodeAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.GetDentalProceduresByEpisodeAction_Class> GetDentalProceduresByEpisodeAction(TTObjectContext objectContext, Guid EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetDentalProceduresByEpisodeAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<DentalProcedure.GetDentalProceduresByEpisodeAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class> GetDentalProcedureByProcedureDoctorSection(string PROCEDUREOBJECT, string PROCEDUREDOCTOR, string RESSECTION, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetDentalProcedureByProcedureDoctorSection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREOBJECT", PROCEDUREOBJECT);
            paramList.Add("PROCEDUREDOCTOR", PROCEDUREDOCTOR);
            paramList.Add("RESSECTION", RESSECTION);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class> GetDentalProcedureByProcedureDoctorSection(TTObjectContext objectContext, string PROCEDUREOBJECT, string PROCEDUREDOCTOR, string RESSECTION, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetDentalProcedureByProcedureDoctorSection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREOBJECT", PROCEDUREOBJECT);
            paramList.Add("PROCEDUREDOCTOR", PROCEDUREDOCTOR);
            paramList.Add("RESSECTION", RESSECTION);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.VEM_HASTA_DIS_Class> VEM_HASTA_DIS(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["VEM_HASTA_DIS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProcedure.VEM_HASTA_DIS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.VEM_HASTA_DIS_Class> VEM_HASTA_DIS(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["VEM_HASTA_DIS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DentalProcedure.VEM_HASTA_DIS_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.GetDentalProtesisProcedures_Class> GetDentalProtesisProcedures(string EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetDentalProtesisProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<DentalProcedure.GetDentalProtesisProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalProcedure.GetDentalProtesisProcedures_Class> GetDentalProtesisProcedures(TTObjectContext objectContext, string EPISODEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALPROCEDURE"].QueryDefs["GetDentalProtesisProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return TTReportNqlObject.QueryObjects<DentalProcedure.GetDentalProtesisProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// DentalineID
    /// </summary>
        public string ExternalID
        {
            get { return (string)this["EXTERNALID"]; }
            set { this["EXTERNALID"] = value; }
        }

    /// <summary>
    /// Diş No
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Hizmet Kaydedilebilir
    /// </summary>
        public bool? AccountRecordable
        {
            get { return (bool?)this["ACCOUNTRECORDABLE"]; }
            set { this["ACCOUNTRECORDABLE"] = value; }
        }

    /// <summary>
    /// Hastanın Ödeyeceği Tutar
    /// </summary>
        public Currency? PatientPrice
        {
            get { return (Currency?)this["PATIENTPRICE"]; }
            set { this["PATIENTPRICE"] = value; }
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
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? DisTaahhutNo
        {
            get { return (int?)this["DISTAAHHUTNO"]; }
            set { this["DISTAAHHUTNO"] = value; }
        }

    /// <summary>
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

        public ResUser AnesteziDoktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTEZIDOKTOR"); }
            set { this["ANESTEZIDOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// DisBilgisi AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// DisBilgisi OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalExamination DentalExamination
        {
            get 
            {   
                if (EpisodeAction is DentalExamination)
                    return (DentalExamination)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public DentalTreatmentDefinition DentalTreatmentProcedureObject
        {
            get 
            {   
                if (ProcedureObject is DentalTreatmentDefinition)
                    return (DentalTreatmentDefinition)ProcedureObject; 
                return null;
            }            
            set { ProcedureObject = value; }
        }

        protected DentalProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALPROCEDURE", dataRow) { }
        protected DentalProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALPROCEDURE", dataRow, isImported) { }
        public DentalProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalProcedure() : base() { }

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