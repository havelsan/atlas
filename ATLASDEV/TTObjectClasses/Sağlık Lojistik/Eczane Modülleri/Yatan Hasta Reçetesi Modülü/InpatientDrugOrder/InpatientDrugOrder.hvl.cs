
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientDrugOrder")] 

    /// <summary>
    /// İlaç Direktifi
    /// </summary>
    public  partial class InpatientDrugOrder : DrugOrder
    {
        public class InpatientDrugOrderList : TTObjectCollection<InpatientDrugOrder> { }
                    
        public class ChildInpatientDrugOrderCollection : TTObject.TTChildObjectCollection<InpatientDrugOrder>
        {
            public ChildInpatientDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugsToInPatientsForDoctorNameReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DAY"].DataType;
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

            public GetDrugsToInPatientsForDoctorNameReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToInPatientsForDoctorNameReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToInPatientsForDoctorNameReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleDrugsForDoctorNameReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DAY"].DataType;
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

            public GetKScheduleDrugsForDoctorNameReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDrugsForDoctorNameReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDrugsForDoctorNameReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetKScheduleDrugsForDrugNameReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DAY"].DataType;
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

            public GetKScheduleDrugsForDrugNameReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKScheduleDrugsForDrugNameReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKScheduleDrugsForDrugNameReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInPatientAmountForStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Inpatientamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INPATIENTAMOUNT"]);
                }
            }

            public GetInPatientAmountForStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInPatientAmountForStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInPatientAmountForStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsToInPatientsForDrugNameReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["DAY"].DataType;
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

            public GetDrugsToInPatientsForDrugNameReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToInPatientsForDrugNameReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToInPatientsForDrugNameReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_YatanReceteIlacSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_YatanReceteIlacSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_YatanReceteIlacSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_YatanReceteIlacSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionReport_Class : TTReportNqlObject 
        {
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

            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string EReceteNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERECETENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].AllPropertyDefs["ERECETENO"].DataType;
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

            public GetInpatientPrescriptionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionReport_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Durduruldu
    /// </summary>
            public static Guid Stopped { get { return new Guid("b9722c8e-a860-49bb-84a9-5f57329e9f5e"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("bf44d139-8cbb-4dd2-a4da-019ceb617d88"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("76d94534-e494-4344-b85a-5a10936ca890"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approve { get { return new Guid("88dc5b13-4f88-49bb-882e-7ab22e161546"); } }
    /// <summary>
    /// İptal Edildi.
    /// </summary>
            public static Guid Cancelled { get { return new Guid("65899317-c3be-4fb8-8a72-b00c0b7c6fd1"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2b61bebd-4a25-4669-b676-f2a0e344fbe3"); } }
        }

        public static BindingList<InpatientDrugOrder.GetDrugsToInPatientsForDoctorNameReportQuery_Class> GetDrugsToInPatientsForDoctorNameReportQuery(DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetDrugsToInPatientsForDoctorNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetDrugsToInPatientsForDoctorNameReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetDrugsToInPatientsForDoctorNameReportQuery_Class> GetDrugsToInPatientsForDoctorNameReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetDrugsToInPatientsForDoctorNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetDrugsToInPatientsForDoctorNameReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class> GetKScheduleDrugsForDoctorNameReportQuery(DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetKScheduleDrugsForDoctorNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class> GetKScheduleDrugsForDoctorNameReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetKScheduleDrugsForDoctorNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetKScheduleDrugsForDrugNameReportQuery_Class> GetKScheduleDrugsForDrugNameReportQuery(DateTime STARTDATE, DateTime ENDDATE, string DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetKScheduleDrugsForDrugNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetKScheduleDrugsForDrugNameReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetKScheduleDrugsForDrugNameReportQuery_Class> GetKScheduleDrugsForDrugNameReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetKScheduleDrugsForDrugNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetKScheduleDrugsForDrugNameReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class> GetInPatientAmountForStatisticReportQuery(string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetInPatientAmountForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class> GetInPatientAmountForStatisticReportQuery(TTObjectContext objectContext, string MATERIALID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetInPatientAmountForStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetDrugsToInPatientsForDrugNameReportQuery_Class> GetDrugsToInPatientsForDrugNameReportQuery(DateTime STARTDATE, DateTime ENDDATE, string DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetDrugsToInPatientsForDrugNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetDrugsToInPatientsForDrugNameReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetDrugsToInPatientsForDrugNameReportQuery_Class> GetDrugsToInPatientsForDrugNameReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetDrugsToInPatientsForDrugNameReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetDrugsToInPatientsForDrugNameReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GunSonu_YatanReceteIlacSayisi_Class> GunSonu_YatanReceteIlacSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GunSonu_YatanReceteIlacSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GunSonu_YatanReceteIlacSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GunSonu_YatanReceteIlacSayisi_Class> GunSonu_YatanReceteIlacSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GunSonu_YatanReceteIlacSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GunSonu_YatanReceteIlacSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetInpatientPrescriptionReport_Class> GetInpatientPrescriptionReport(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetInpatientPrescriptionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetInpatientPrescriptionReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientDrugOrder.GetInpatientPrescriptionReport_Class> GetInpatientPrescriptionReport(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].QueryDefs["GetInpatientPrescriptionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientDrugOrder.GetInpatientPrescriptionReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Paket Adedi
    /// </summary>
        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

        public Guid? DrugOrderID
        {
            get { return (Guid?)this["DRUGORDERID"]; }
            set { this["DRUGORDERID"] = value; }
        }

        public InpatientPrescription InpatientPrescription
        {
            get { return (InpatientPrescription)((ITTObject)this).GetParent("INPATIENTPRESCRIPTION"); }
            set { this["INPATIENTPRESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("2b280c5d-4a40-407a-ab6c-e0a2d46aae99"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected InpatientDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTDRUGORDER", dataRow) { }
        protected InpatientDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTDRUGORDER", dataRow, isImported) { }
        public InpatientDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientDrugOrder() : base() { }

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