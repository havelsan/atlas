
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectPurchaseActionDetail")] 

    /// <summary>
    /// 22F Doğrudan Temin Malzemeler
    /// </summary>
    public  partial class DirectPurchaseActionDetail : TTObject
    {
        public class DirectPurchaseActionDetailList : TTObjectCollection<DirectPurchaseActionDetail> { }
                    
        public class ChildDirectPurchaseActionDetailCollection : TTObject.TTChildObjectCollection<DirectPurchaseActionDetail>
        {
            public ChildDirectPurchaseActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectPurchaseActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MaterialRequestFormReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Sutkodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUTKODU"]);
                }
            }

            public Currency? Sutfiyat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTFIYAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Talepcinsi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TALEPCINSI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Olcubirimi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCUBIRIMI"]);
                }
            }

            public DateTime? Isteminsuresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEMINSURESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DirectPurchaseAction
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIRECTPURCHASEACTION"]);
                }
            }

            public string Islemkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rpcmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RPCMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MatchedSUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATCHEDSUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATCHEDSUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MatchedSUTPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATCHEDSUTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATCHEDSUTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Codelessmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODELESSMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialRequestFormReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialRequestFormReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialRequestFormReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterielInspectionAndReceivingReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Talepcinsi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TALEPCINSI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sutkodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUTKODU"]);
                }
            }

            public Currency? Sutfiyat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTFIYAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Kesinlesenmiktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KESINLESENMIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["CERTAINAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public MaterielInspectionAndReceivingReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterielInspectionAndReceivingReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterielInspectionAndReceivingReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPiyasaArastirmaTutanagiReport_Class : TTReportNqlObject 
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

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? SUTPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string SUTName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public bool? HasUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["HASUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public VatrateEnum? KDV
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KDV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["KDV"].DataType;
                    return (VatrateEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Cancelled
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["CANCELLED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? CertainAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CERTAINAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["CERTAINAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPiyasaArastirmaTutanagiReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPiyasaArastirmaTutanagiReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPiyasaArastirmaTutanagiReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDirectPurchaseActionDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string SUTName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public GetDirectPurchaseActionDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDirectPurchaseActionDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDirectPurchaseActionDetail_Class() : base() { }
        }

        public static BindingList<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class> MaterialRequestFormReportNQL(string DIRECTPURCHASEACTIONINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["MaterialRequestFormReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONINFO", DIRECTPURCHASEACTIONINFO);

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class> MaterialRequestFormReportNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTIONINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["MaterialRequestFormReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONINFO", DIRECTPURCHASEACTIONINFO);

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.MaterialRequestFormReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.MaterielInspectionAndReceivingReportNQL_Class> MaterielInspectionAndReceivingReportNQL(string DIRECTPURCHASEACTIONDETAIL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["MaterielInspectionAndReceivingReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONDETAIL", DIRECTPURCHASEACTIONDETAIL);

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.MaterielInspectionAndReceivingReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.MaterielInspectionAndReceivingReportNQL_Class> MaterielInspectionAndReceivingReportNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTIONDETAIL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["MaterielInspectionAndReceivingReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONDETAIL", DIRECTPURCHASEACTIONDETAIL);

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.MaterielInspectionAndReceivingReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.GetPiyasaArastirmaTutanagiReport_Class> GetPiyasaArastirmaTutanagiReport(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["GetPiyasaArastirmaTutanagiReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.GetPiyasaArastirmaTutanagiReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.GetPiyasaArastirmaTutanagiReport_Class> GetPiyasaArastirmaTutanagiReport(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["GetPiyasaArastirmaTutanagiReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.GetPiyasaArastirmaTutanagiReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.GetDirectPurchaseActionDetail_Class> GetDirectPurchaseActionDetail(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["GetDirectPurchaseActionDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.GetDirectPurchaseActionDetail_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DirectPurchaseActionDetail.GetDirectPurchaseActionDetail_Class> GetDirectPurchaseActionDetail(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].QueryDefs["GetDirectPurchaseActionDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DirectPurchaseActionDetail.GetDirectPurchaseActionDetail_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İstemin Süresi
    /// </summary>
        public DateTime? PurchaseDate
        {
            get { return (DateTime?)this["PURCHASEDATE"]; }
            set { this["PURCHASEDATE"] = value; }
        }

    /// <summary>
    /// Sıra Numarası
    /// </summary>
        public TTSequence OrderNo
        {
            get { return GetSequence("ORDERNO"); }
        }

    /// <summary>
    /// SUT Fiyatı
    /// </summary>
        public Currency? SUTPrice
        {
            get { return (Currency?)this["SUTPRICE"]; }
            set { this["SUTPRICE"] = value; }
        }

    /// <summary>
    /// Talebin Cinsi
    /// </summary>
        public string SUTName
        {
            get { return (string)this["SUTNAME"]; }
            set { this["SUTNAME"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Kullanıldı mı?
    /// </summary>
        public bool? HasUsed
        {
            get { return (bool?)this["HASUSED"]; }
            set { this["HASUSED"] = value; }
        }

    /// <summary>
    /// KDV Oranı
    /// </summary>
        public VatrateEnum? KDV
        {
            get { return (VatrateEnum?)(int?)this["KDV"]; }
            set { this["KDV"] = value; }
        }

    /// <summary>
    /// İptal Edildi
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kesinleşen Miktar
    /// </summary>
        public Currency? CertainAmount
        {
            get { return (Currency?)this["CERTAINAMOUNT"]; }
            set { this["CERTAINAMOUNT"] = value; }
        }

    /// <summary>
    /// Ölçü Birimi
    /// </summary>
        public DistributionTypeDefinition DistributionType
        {
            get { return (DistributionTypeDefinition)((ITTObject)this).GetParent("DISTRIBUTIONTYPE"); }
            set { this["DISTRIBUTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme Detayları
    /// </summary>
        public DirectPurchaseAction DirectPurchaseAction
        {
            get { return (DirectPurchaseAction)((ITTObject)this).GetParent("DIRECTPURCHASEACTION"); }
            set { this["DIRECTPURCHASEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadioPharmaceuticalDefinition RadioPharmaceuticalMaterial
        {
            get { return (RadioPharmaceuticalDefinition)((ITTObject)this).GetParent("RADIOPHARMACEUTICALMATERIAL"); }
            set { this["RADIOPHARMACEUTICALMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public NuclearMedicineTestDefinition ProcedureSUTCode
        {
            get { return (NuclearMedicineTestDefinition)((ITTObject)this).GetParent("PROCEDURESUTCODE"); }
            set { this["PROCEDURESUTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DPA22FCodelessMaterialDef DPA22FCodelessMaterial
        {
            get { return (DPA22FCodelessMaterialDef)((ITTObject)this).GetParent("DPA22FCODELESSMATERIAL"); }
            set { this["DPA22FCODELESSMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public ProductSUTMatchDefinition SUTCode
        {
            get { return (ProductSUTMatchDefinition)((ITTObject)this).GetParent("SUTCODE"); }
            set { this["SUTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFirmPriceOffersCollection()
        {
            _FirmPriceOffers = new DPADetailFirmPriceOffer.ChildDPADetailFirmPriceOfferCollection(this, new Guid("88c89354-cbcf-4991-b345-ed9058759ef6"));
            ((ITTChildObjectCollection)_FirmPriceOffers).GetChildren();
        }

        protected DPADetailFirmPriceOffer.ChildDPADetailFirmPriceOfferCollection _FirmPriceOffers = null;
    /// <summary>
    /// Child collection for Firma Fiyat Teklifleri
    /// </summary>
        public DPADetailFirmPriceOffer.ChildDPADetailFirmPriceOfferCollection FirmPriceOffers
        {
            get
            {
                if (_FirmPriceOffers == null)
                    CreateFirmPriceOffersCollection();
                return _FirmPriceOffers;
            }
        }

        protected DirectPurchaseActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectPurchaseActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectPurchaseActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectPurchaseActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectPurchaseActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTPURCHASEACTIONDETAIL", dataRow) { }
        protected DirectPurchaseActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTPURCHASEACTIONDETAIL", dataRow, isImported) { }
        public DirectPurchaseActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectPurchaseActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectPurchaseActionDetail() : base() { }

    }
}