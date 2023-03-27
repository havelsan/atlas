
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubActionMaterial")] 

    public  abstract  partial class SubActionMaterial : TTObject, ISubActionMaterial, IMySubActionMaterial, IAccountOperation, ISUTInstance
    {
        public class SubActionMaterialList : TTObjectCollection<SubActionMaterial> { }
                    
        public class ChildSubActionMaterialCollection : TTObject.TTChildObjectCollection<SubActionMaterial>
        {
            public ChildSubActionMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubActionMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_SGKStatisticQuery1_SECount_Class : TTReportNqlObject 
        {
            public Object Altvakasayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ALTVAKASAYISI"]);
                }
            }

            public OLAP_SGKStatisticQuery1_SECount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SGKStatisticQuery1_SECount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SGKStatisticQuery1_SECount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaterialByPatient_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaterialByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_SGKStatisticQuery1_PatientCount_Class : TTReportNqlObject 
        {
            public Object Tckimliknosayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TCKIMLIKNOSAYISI"]);
                }
            }

            public OLAP_SGKStatisticQuery1_PatientCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_SGKStatisticQuery1_PatientCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_SGKStatisticQuery1_PatientCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNameByObjectID_Class : TTReportNqlObject 
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

            public GetNameByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNameByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNameByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnUsedUTSNotification_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Utsamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UTSAMOUNT"]);
                }
            }

            public GetUnUsedUTSNotification_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnUsedUTSNotification_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnUsedUTSNotification_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCovidOutPatientList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Drug
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUG"]);
                }
            }

            public GetCovidOutPatientList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCovidOutPatientList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCovidOutPatientList_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c4c3064c-5b92-4053-8e76-14723188541a"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("dd6fb9b4-ddc1-4816-a199-977e7742f624"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("4833943c-676e-470f-b651-98652395f71f"); } }
        }

        public static BindingList<SubActionMaterial> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<SubActionMaterial>(queryDef, paramList);
        }

        public static BindingList<SubActionMaterial> GetSubActionsByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetSubActionsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionMaterial>(queryDef, paramList);
        }

        public static BindingList<SubActionMaterial> GetByEpisodeAndSEP(TTObjectContext objectContext, Guid EPISODE, Guid SEP, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetByEpisodeAndSEP"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SEP", SEP);

            return ((ITTQuery)objectContext).QueryObjects<SubActionMaterial>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionMaterial.OLAP_SGKStatisticQuery1_SECount_Class> OLAP_SGKStatisticQuery1_SECount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["OLAP_SGKStatisticQuery1_SECount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.OLAP_SGKStatisticQuery1_SECount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionMaterial.OLAP_SGKStatisticQuery1_SECount_Class> OLAP_SGKStatisticQuery1_SECount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["OLAP_SGKStatisticQuery1_SECount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.OLAP_SGKStatisticQuery1_SECount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial> GetByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<SubActionMaterial>(queryDef, paramList);
        }

        public static BindingList<SubActionMaterial.GetMaterialByPatient_Class> GetMaterialByPatient(Guid STOREID, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetMaterialByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetMaterialByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial.GetMaterialByPatient_Class> GetMaterialByPatient(TTObjectContext objectContext, Guid STOREID, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetMaterialByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetMaterialByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionMaterial.OLAP_SGKStatisticQuery1_PatientCount_Class> OLAP_SGKStatisticQuery1_PatientCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["OLAP_SGKStatisticQuery1_PatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.OLAP_SGKStatisticQuery1_PatientCount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// OLAP ta kullanılmıyor artık
    /// </summary>
        public static BindingList<SubActionMaterial.OLAP_SGKStatisticQuery1_PatientCount_Class> OLAP_SGKStatisticQuery1_PatientCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["OLAP_SGKStatisticQuery1_PatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.OLAP_SGKStatisticQuery1_PatientCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial> GetByEpisodeAndMasterPackage(TTObjectContext objectContext, string EPISODE, string MASTERPACKAGESP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetByEpisodeAndMasterPackage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MASTERPACKAGESP", MASTERPACKAGESP);

            return ((ITTQuery)objectContext).QueryObjects<SubActionMaterial>(queryDef, paramList);
        }

        public static BindingList<SubActionMaterial> GetByOpenedAndClosedToNewEpisode(TTObjectContext objectContext, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetByOpenedAndClosedToNewEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<SubActionMaterial>(queryDef, paramList);
        }

        public static BindingList<SubActionMaterial.GetNameByObjectID_Class> GetNameByObjectID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetNameByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetNameByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial.GetNameByObjectID_Class> GetNameByObjectID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetNameByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetNameByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial.GetUnUsedUTSNotification_Class> GetUnUsedUTSNotification(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetUnUsedUTSNotification"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetUnUsedUTSNotification_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial.GetUnUsedUTSNotification_Class> GetUnUsedUTSNotification(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetUnUsedUTSNotification"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetUnUsedUTSNotification_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial.GetCovidOutPatientList_Class> GetCovidOutPatientList(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetCovidOutPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetCovidOutPatientList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubActionMaterial.GetCovidOutPatientList_Class> GetCovidOutPatientList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBACTIONMATERIAL"].QueryDefs["GetCovidOutPatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<SubActionMaterial.GetCovidOutPatientList_Class>(objectContext, queryDef, paramList, pi);
        }

        public bool? Eligible
        {
            get { return (bool?)this["ELIGIBLE"]; }
            set { this["ELIGIBLE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Ücretlendirilme Tarihi
    /// </summary>
        public DateTime? PricingDate
        {
            get { return (DateTime?)this["PRICINGDATE"]; }
            set { this["PRICINGDATE"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

        public bool? AccTrxsMultipliedByAmount
        {
            get { return (bool?)this["ACCTRXSMULTIPLIEDBYAMOUNT"]; }
            set { this["ACCTRXSMULTIPLIEDBYAMOUNT"] = value; }
        }

    /// <summary>
    /// Ücretlendi mi
    /// </summary>
        public bool? AccountOperationDone
        {
            get { return (bool?)this["ACCOUNTOPERATIONDONE"]; }
            set { this["ACCOUNTOPERATIONDONE"] = value; }
        }

        public bool? PatientPay
        {
            get { return (bool?)this["PATIENTPAY"]; }
            set { this["PATIENTPAY"] = value; }
        }

    /// <summary>
    /// Dönor ID
    /// </summary>
        public string DonorID
        {
            get { return (string)this["DONORID"]; }
            set { this["DONORID"] = value; }
        }

    /// <summary>
    /// Kullanılan Miktar
    /// </summary>
        public int? UseAmount
        {
            get { return (int?)this["USEAMOUNT"]; }
            set { this["USEAMOUNT"] = value; }
        }

    /// <summary>
    /// UBB Kodu
    /// </summary>
        public string UBBCode
        {
            get { return (string)this["UBBCODE"]; }
            set { this["UBBCODE"] = value; }
        }

    /// <summary>
    /// Oluşturma Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// İşlemin aktarımla gelip gelmediğine bakar
    /// </summary>
        public bool? IsOldAction
        {
            get { return (bool?)this["ISOLDACTION"]; }
            set { this["ISOLDACTION"] = value; }
        }

    /// <summary>
    /// Medula Rapor Numarası
    /// </summary>
        public string MedulaReportNo
        {
            get { return (string)this["MEDULAREPORTNO"]; }
            set { this["MEDULAREPORTNO"] = value; }
        }

    /// <summary>
    /// Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure MasterPackgSubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("MASTERPACKGSUBACTIONPROCEDURE"); }
            set { this["MASTERPACKGSUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Medula Hasta Kabul-Malzemeler
    /// </summary>
        public PatientMedulaHastaKabul MedulaHastaKabul
        {
            get { return (PatientMedulaHastaKabul)((ITTObject)this).GetParent("MEDULAHASTAKABUL"); }
            set { this["MEDULAHASTAKABUL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzemeyi İsteyen Kullanıcı
    /// </summary>
        public ResUser RequestedByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTEDBYUSER"); }
            set { this["REQUESTEDBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTransferFromPackSubActMatsCollection()
        {
            _TransferFromPackSubActMats = new TransferFromPackSubActMats.ChildTransferFromPackSubActMatsCollection(this, new Guid("514a1171-91d5-4a37-a0dd-00451bceb3a0"));
            ((ITTChildObjectCollection)_TransferFromPackSubActMats).GetChildren();
        }

        protected TransferFromPackSubActMats.ChildTransferFromPackSubActMatsCollection _TransferFromPackSubActMats = null;
        public TransferFromPackSubActMats.ChildTransferFromPackSubActMatsCollection TransferFromPackSubActMats
        {
            get
            {
                if (_TransferFromPackSubActMats == null)
                    CreateTransferFromPackSubActMatsCollection();
                return _TransferFromPackSubActMats;
            }
        }

        virtual protected void CreateAccountTransactionsCollectionViews()
        {
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("286ae725-4d9d-4dea-b455-4d1910374a32"));
            CreateAccountTransactionsCollectionViews();
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
    /// <summary>
    /// Child collection for SubActionMaterial a ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransactions
        {
            get
            {
                if (_AccountTransactions == null)
                    CreateAccountTransactionsCollection();
                return _AccountTransactions;
            }
        }

        virtual protected void CreateSubActionMatPricingDetCollection()
        {
            _SubActionMatPricingDet = new SubActionMatPricingDet.ChildSubActionMatPricingDetCollection(this, new Guid("4b9d28a7-a8ee-4da0-b666-34829da2cfae"));
            ((ITTChildObjectCollection)_SubActionMatPricingDet).GetChildren();
        }

        protected SubActionMatPricingDet.ChildSubActionMatPricingDetCollection _SubActionMatPricingDet = null;
        public SubActionMatPricingDet.ChildSubActionMatPricingDetCollection SubActionMatPricingDet
        {
            get
            {
                if (_SubActionMatPricingDet == null)
                    CreateSubActionMatPricingDetCollection();
                return _SubActionMatPricingDet;
            }
        }

        virtual protected void CreatePriceUpdatingMaterialCollection()
        {
            _PriceUpdatingMaterial = new PriceUpdatingSubActionMaterial.ChildPriceUpdatingSubActionMaterialCollection(this, new Guid("52ff6d25-15fb-44ae-b242-5ed90d451b0a"));
            ((ITTChildObjectCollection)_PriceUpdatingMaterial).GetChildren();
        }

        protected PriceUpdatingSubActionMaterial.ChildPriceUpdatingSubActionMaterialCollection _PriceUpdatingMaterial = null;
    /// <summary>
    /// Child collection for Malzeme hareketi ile ilişki
    /// </summary>
        public PriceUpdatingSubActionMaterial.ChildPriceUpdatingSubActionMaterialCollection PriceUpdatingMaterial
        {
            get
            {
                if (_PriceUpdatingMaterial == null)
                    CreatePriceUpdatingMaterialCollection();
                return _PriceUpdatingMaterial;
            }
        }

        virtual protected void CreatePackageTransferProtocolSubActionMaterialsCollection()
        {
            _PackageTransferProtocolSubActionMaterials = new PackageTransferProtocolSubActionMaterials.ChildPackageTransferProtocolSubActionMaterialsCollection(this, new Guid("e21af5ea-5dd3-4177-959d-777d82b5c445"));
            ((ITTChildObjectCollection)_PackageTransferProtocolSubActionMaterials).GetChildren();
        }

        protected PackageTransferProtocolSubActionMaterials.ChildPackageTransferProtocolSubActionMaterialsCollection _PackageTransferProtocolSubActionMaterials = null;
    /// <summary>
    /// Child collection for Malzeme Hareketi ile ilişki
    /// </summary>
        public PackageTransferProtocolSubActionMaterials.ChildPackageTransferProtocolSubActionMaterialsCollection PackageTransferProtocolSubActionMaterials
        {
            get
            {
                if (_PackageTransferProtocolSubActionMaterials == null)
                    CreatePackageTransferProtocolSubActionMaterialsCollection();
                return _PackageTransferProtocolSubActionMaterials;
            }
        }

        virtual protected void CreateENabizMaterialsCollection()
        {
            _ENabizMaterials = new ENabizMaterial.ChildENabizMaterialCollection(this, new Guid("bc3971c6-0346-43fd-8b46-c577f4b3015d"));
            ((ITTChildObjectCollection)_ENabizMaterials).GetChildren();
        }

        protected ENabizMaterial.ChildENabizMaterialCollection _ENabizMaterials = null;
        public ENabizMaterial.ChildENabizMaterialCollection ENabizMaterials
        {
            get
            {
                if (_ENabizMaterials == null)
                    CreateENabizMaterialsCollection();
                return _ENabizMaterials;
            }
        }

        protected SubActionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubActionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubActionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubActionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubActionMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBACTIONMATERIAL", dataRow) { }
        protected SubActionMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBACTIONMATERIAL", dataRow, isImported) { }
        public SubActionMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubActionMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubActionMaterial() : base() { }

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