
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientPrescription")] 

    /// <summary>
    /// Yatan Hasta Reçetesi
    /// </summary>
    public  partial class InpatientPrescription : Prescription, ICreatePrescriptionStockOut, IWorkListEpisodeAction
    {
        public class InpatientPrescriptionList : TTObjectCollection<InpatientPrescription> { }
                    
        public class ChildInpatientPrescriptionCollection : TTObject.TTChildObjectCollection<InpatientPrescription>
        {
            public ChildInpatientPrescriptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientPrescriptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugsFromExternalPharmacyReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Externalpharmacyid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXTERNALPHARMACYID"]);
                }
            }

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

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetDrugsFromExternalPharmacyReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsFromExternalPharmacyReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsFromExternalPharmacyReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInPatientDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject 
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

            public GetInPatientDrugPrescriptionTotalReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInPatientDrugPrescriptionTotalReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInPatientDrugPrescriptionTotalReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionDrugsQuery_Class : TTReportNqlObject 
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? Unitprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
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

            public GetInpatientPrescriptionDrugsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionDrugsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionDrugsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrescriptionReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].AllPropertyDefs["FILLINGDATE"].DataType;
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

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["AMOUNT"].DataType;
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

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BarcodeLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODELEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["BARCODELEVEL"].DataType;
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

            public GetInpatientPrescriptionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrescriptionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrescriptionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDetailInPresciprtionReportQuery_Class : TTReportNqlObject 
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["AMOUNT"].DataType;
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

            public GetDetailInPresciprtionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDetailInPresciprtionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDetailInPresciprtionReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("cf172dd3-d02b-407c-9b5a-04de07353087"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("9a64442a-2052-4ec1-bb25-6c4dc13b8a43"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("5a418789-3458-44d2-87a8-662fb1f3f8ab"); } }
    /// <summary>
    /// Enfeksiyon Komitesi Onayı
    /// </summary>
            public static Guid InfectionApproval { get { return new Guid("0d6c289f-bc58-4c2e-b0a7-2a1106616bb0"); } }
        }

        public static BindingList<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class> GetDrugsFromExternalPharmacyReportQuery(DateTime STARTDATE, DateTime ENDDATE, string PHARMACYID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetDrugsFromExternalPharmacyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PHARMACYID", PHARMACYID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class> GetDrugsFromExternalPharmacyReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PHARMACYID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetDrugsFromExternalPharmacyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PHARMACYID", PHARMACYID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class> GetInPatientDrugPrescriptionTotalReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetInPatientDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class> GetInPatientDrugPrescriptionTotalReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetInPatientDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class> GetInpatientPrescriptionDrugsQuery(Guid PRESCRIPTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetInpatientPrescriptionDrugsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONID", PRESCRIPTIONID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class> GetInpatientPrescriptionDrugsQuery(TTObjectContext objectContext, Guid PRESCRIPTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetInpatientPrescriptionDrugsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONID", PRESCRIPTIONID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class> GetInpatientPrescriptionReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetInpatientPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class> GetInpatientPrescriptionReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetInpatientPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class> GetDetailInPresciprtionReportQuery(Guid PRESCRIPTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetDetailInPresciprtionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONID", PRESCRIPTIONID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class> GetDetailInPresciprtionReportQuery(TTObjectContext objectContext, Guid PRESCRIPTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetDetailInPresciprtionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONID", PRESCRIPTIONID);

            return TTReportNqlObject.QueryObjects<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientPrescription> GetBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPRESCRIPTION"].QueryDefs["GetBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<InpatientPrescription>(queryDef, paramList);
        }

    /// <summary>
    /// Reçete Güncellendi
    /// </summary>
        public bool? ChangePres
        {
            get { return (bool?)this["CHANGEPRES"]; }
            set { this["CHANGEPRES"] = value; }
        }

        public ExternalPharmacy ExternalPharmacy
        {
            get { return (ExternalPharmacy)((ITTObject)this).GetParent("EXTERNALPHARMACY"); }
            set { this["EXTERNALPHARMACY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInpatientDrugOrdersCollection()
        {
            _InpatientDrugOrders = new InpatientDrugOrder.ChildInpatientDrugOrderCollection(this, new Guid("003e2bb3-a71e-4c1b-8966-d9f21f71ebbe"));
            ((ITTChildObjectCollection)_InpatientDrugOrders).GetChildren();
        }

        protected InpatientDrugOrder.ChildInpatientDrugOrderCollection _InpatientDrugOrders = null;
        public InpatientDrugOrder.ChildInpatientDrugOrderCollection InpatientDrugOrders
        {
            get
            {
                if (_InpatientDrugOrders == null)
                    CreateInpatientDrugOrdersCollection();
                return _InpatientDrugOrders;
            }
        }

        virtual protected void CreateInfectionApprovalDrugOrderCollection()
        {
            _InfectionApprovalDrugOrder = new InfectionApprovalDrugOrder.ChildInfectionApprovalDrugOrderCollection(this, new Guid("91e89cb0-4298-4fc8-9211-2cc69da28dd5"));
            ((ITTChildObjectCollection)_InfectionApprovalDrugOrder).GetChildren();
        }

        protected InfectionApprovalDrugOrder.ChildInfectionApprovalDrugOrderCollection _InfectionApprovalDrugOrder = null;
        public InfectionApprovalDrugOrder.ChildInfectionApprovalDrugOrderCollection InfectionApprovalDrugOrder
        {
            get
            {
                if (_InfectionApprovalDrugOrder == null)
                    CreateInfectionApprovalDrugOrderCollection();
                return _InfectionApprovalDrugOrder;
            }
        }

        protected InpatientPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientPrescription(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTPRESCRIPTION", dataRow) { }
        protected InpatientPrescription(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTPRESCRIPTION", dataRow, isImported) { }
        public InpatientPrescription(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientPrescription(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientPrescription() : base() { }

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