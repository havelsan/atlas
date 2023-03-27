
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OutPatientDrugOrder")] 

    /// <summary>
    /// İlaç Drektifi ( Ayaktan Hasta Reçetesi )
    /// </summary>
    public  partial class OutPatientDrugOrder : DrugOrder
    {
        public class OutPatientDrugOrderList : TTObjectCollection<OutPatientDrugOrder> { }
                    
        public class ChildOutPatientDrugOrderCollection : TTObject.TTChildObjectCollection<OutPatientDrugOrder>
        {
            public ChildOutPatientDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOutPatientDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOutPatientOtherGroupsForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Outpatientamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OUTPATIENTAMOUNT"]);
                }
            }

            public GetOutPatientOtherGroupsForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPatientOtherGroupsForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPatientOtherGroupsForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsToOutPatientsForDoctorNameReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
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

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetDrugsToOutPatientsForDoctorNameReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToOutPatientsForDoctorNameReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToOutPatientsForDoctorNameReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutPatientPrivateNonComForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Outpatientamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OUTPATIENTAMOUNT"]);
                }
            }

            public GetOutPatientPrivateNonComForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPatientPrivateNonComForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPatientPrivateNonComForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsToOutPatientsForDrugNameReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
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

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
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

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetDrugsToOutPatientsForDrugNameReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToOutPatientsForDrugNameReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToOutPatientsForDrugNameReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugByDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Drug
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUG"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Clinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINIC"]);
                }
            }

            public Guid? Presobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRESOBJECTID"]);
                }
            }

            public GetDrugByDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugByDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugByDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOutPatientDrungOrderListQery_Class : TTReportNqlObject 
        {
            public string Ilac
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILAC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? PhysicianDrug
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSICIANDRUG"]);
                }
            }

            public GetOutPatientDrungOrderListQery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOutPatientDrungOrderListQery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOutPatientDrungOrderListQery_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_AyaktanReceteIlacSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_AyaktanReceteIlacSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_AyaktanReceteIlacSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_AyaktanReceteIlacSayisi_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Karşılanmadı
    /// </summary>
            public static Guid UnCompleted { get { return new Guid("1f97d7a9-5c1d-4b15-8e91-f80f8944e14b"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approve { get { return new Guid("af0b6cf8-9918-481c-98e3-1e576e4f4755"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("6bfe9933-d89b-4662-92cc-10292d989f70"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("18c1e341-a7b5-4a55-9bd0-ccee9124849b"); } }
    /// <summary>
    /// Devam Ediyor
    /// </summary>
            public static Guid Continued { get { return new Guid("2702dfd1-ad6a-4355-aa52-dac8127fc9de"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("8b7007f9-d730-4207-b577-df5e92d78f29"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("834036c7-d4ef-4124-8723-1869d2ad3a01"); } }
    /// <summary>
    /// Durduruldu
    /// </summary>
            public static Guid Stopped { get { return new Guid("a5bb50e1-bea9-4e8e-8faa-46a0db8a41fa"); } }
        }

        public static BindingList<OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class> GetOutPatientOtherGroupsForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetOutPatientOtherGroupsForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class> GetOutPatientOtherGroupsForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetOutPatientOtherGroupsForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetDrugsToOutPatientsForDoctorNameReportQuery_Class> GetDrugsToOutPatientsForDoctorNameReportQuery(string DOCTORID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetDrugsToOutPatientsForDoctorNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTORID", DOCTORID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetDrugsToOutPatientsForDoctorNameReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetDrugsToOutPatientsForDoctorNameReportQuery_Class> GetDrugsToOutPatientsForDoctorNameReportQuery(TTObjectContext objectContext, string DOCTORID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetDrugsToOutPatientsForDoctorNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTORID", DOCTORID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetDrugsToOutPatientsForDoctorNameReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class> GetOutPatientPrivateNonComForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetOutPatientPrivateNonComForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class> GetOutPatientPrivateNonComForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetOutPatientPrivateNonComForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetDrugsToOutPatientsForDrugNameReportQuery_Class> GetDrugsToOutPatientsForDrugNameReportQuery(string DRUGID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetDrugsToOutPatientsForDrugNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGID", DRUGID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetDrugsToOutPatientsForDrugNameReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetDrugsToOutPatientsForDrugNameReportQuery_Class> GetDrugsToOutPatientsForDrugNameReportQuery(TTObjectContext objectContext, string DRUGID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetDrugsToOutPatientsForDrugNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGID", DRUGID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetDrugsToOutPatientsForDrugNameReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetDrugByDiagnosis_Class> GetDrugByDiagnosis(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetDrugByDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetDrugByDiagnosis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetDrugByDiagnosis_Class> GetDrugByDiagnosis(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetDrugByDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetDrugByDiagnosis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetOutPatientDrungOrderListQery_Class> GetOutPatientDrungOrderListQery(DateTime StartDate, DateTime EndDate, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetOutPatientDrungOrderListQery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetOutPatientDrungOrderListQery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GetOutPatientDrungOrderListQery_Class> GetOutPatientDrungOrderListQery(TTObjectContext objectContext, DateTime StartDate, DateTime EndDate, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GetOutPatientDrungOrderListQery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GetOutPatientDrungOrderListQery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GunSonu_AyaktanReceteIlacSayisi_Class> GunSonu_AyaktanReceteIlacSayisi(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GunSonu_AyaktanReceteIlacSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GunSonu_AyaktanReceteIlacSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OutPatientDrugOrder.GunSonu_AyaktanReceteIlacSayisi_Class> GunSonu_AyaktanReceteIlacSayisi(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["OUTPATIENTDRUGORDER"].QueryDefs["GunSonu_AyaktanReceteIlacSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<OutPatientDrugOrder.GunSonu_AyaktanReceteIlacSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Provizyon Sonuç
    /// </summary>
        public string SPTSProvisionDetail
        {
            get { return (string)this["SPTSPROVISIONDETAIL"]; }
            set { this["SPTSPROVISIONDETAIL"] = value; }
        }

    /// <summary>
    /// Provizyon Durumu
    /// </summary>
        public bool? SPTSProvisionResult
        {
            get { return (bool?)this["SPTSPROVISIONRESULT"]; }
            set { this["SPTSPROVISIONRESULT"] = value; }
        }

    /// <summary>
    /// Raporlu
    /// </summary>
        public bool? Report
        {
            get { return (bool?)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public double? RequiredAmount
        {
            get { return (double?)this["REQUIREDAMOUNT"]; }
            set { this["REQUIREDAMOUNT"] = value; }
        }

    /// <summary>
    /// Paket Adedi
    /// </summary>
        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public double? UnitPrice
        {
            get { return (double?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Tutar
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Eczane Mevcudu
    /// </summary>
        public double? StoreInheld
        {
            get { return (double?)this["STOREINHELD"]; }
            set { this["STOREINHELD"] = value; }
        }

    /// <summary>
    /// Alınan Tutar %20
    /// </summary>
        public double? ReceivedPrice
        {
            get { return (double?)this["RECEIVEDPRICE"]; }
            set { this["RECEIVEDPRICE"] = value; }
        }

    /// <summary>
    /// On Günlük
    /// </summary>
        public bool? TenDaily
        {
            get { return (bool?)this["TENDAILY"]; }
            set { this["TENDAILY"] = value; }
        }

    /// <summary>
    /// Kullanım Periyot Birimi
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnitType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNITTYPE"]; }
            set { this["PERIODUNITTYPE"] = value; }
        }

    /// <summary>
    /// İlaç Karşılama Bilgisi
    /// </summary>
        public OutPatientDrugSupplyEnum? DrugSupply
        {
            get { return (OutPatientDrugSupplyEnum?)(int?)this["DRUGSUPPLY"]; }
            set { this["DRUGSUPPLY"] = value; }
        }

    /// <summary>
    /// Tedavi Süresi
    /// </summary>
        public double? TreatmentTime
        {
            get { return (double?)this["TREATMENTTIME"]; }
            set { this["TREATMENTTIME"] = value; }
        }

        public OutPatientPrescription OutPatientPrescription
        {
            get { return (OutPatientPrescription)((ITTObject)this).GetParent("OUTPATIENTPRESCRIPTION"); }
            set { this["OUTPATIENTPRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition PhysicianDrug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("PHYSICIANDRUG"); }
            set { this["PHYSICIANDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OutPatientDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OutPatientDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OutPatientDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OutPatientDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OutPatientDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OUTPATIENTDRUGORDER", dataRow) { }
        protected OutPatientDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OUTPATIENTDRUGORDER", dataRow, isImported) { }
        public OutPatientDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OutPatientDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OutPatientDrugOrder() : base() { }

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