
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseProjectDetail")] 

    /// <summary>
    /// Mahalli Satınalma Ana Sınıfına Bağlı Her Detayın/Kalemin Bağlı Olduğu Sınıftır
    /// </summary>
    public  partial class PurchaseProjectDetail : TTObject
    {
        public class PurchaseProjectDetailList : TTObjectCollection<PurchaseProjectDetail> { }
                    
        public class ChildPurchaseProjectDetailCollection : TTObject.TTChildObjectCollection<PurchaseProjectDetail>
        {
            public ChildPurchaseProjectDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseProjectDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPurchaseOrderChaseReportQuery_Class : TTReportNqlObject 
        {
            public long? PurchaseProjectNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEPROJECTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PURCHASEPROJECTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].AllPropertyDefs["DUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? OrderedPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEREDPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDER"].AllPropertyDefs["ORDEREDPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? TotalContractValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCONTRACTVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["TOTALCONTRACTVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDERDETAIL"].AllPropertyDefs["RESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Totalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALAMOUNT"]);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetPurchaseOrderChaseReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseOrderChaseReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseOrderChaseReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProjectDetails_Class : TTReportNqlObject 
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

            public int? OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? Rate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["RATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string ConclusionNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCLUSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["CONCLUSIONNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public int? ContractTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["CONTRACTTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["REQUESTEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? PurchasePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["PURCHASEPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Currency? CancelledAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["CANCELLEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string NSN
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["NSN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UBBCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UBBCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["UBBCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FeasibilityEtude
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FEASIBILITYETUDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["FEASIBILITYETUDE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Isayf
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAYF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["ISAYF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PriceFormulationDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEFORMULATIONDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["PRICEFORMULATIONDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TenderCommisionDetailStatusEnum? TenderCommisionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERCOMMISIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["TENDERCOMMISIONSTATUS"].DataType;
                    return (TenderCommisionDetailStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["CONTRACTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? WorkTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["WORKTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GuarantyTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["GUARANTYTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["WORKENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GuarantyEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["GUARANTYENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["CONTRACTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Purchased
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["PURCHASED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["WORKSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? GuarantyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["GUARANTYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AppPriceCalculated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPPRICECALCULATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["APPPRICECALCULATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Purchaseitemname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Purchaseitemobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PURCHASEITEMOBJECTID"]);
                }
            }

            public string Purchaseitemunittypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEITEMUNITTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["TEMPDISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProjectDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProjectDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProjectDetails_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("bed53942-bf9d-41e1-98bf-45109d60ca72"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("f75dc32c-3a5f-40e1-b2cf-f093ef4c29a2"); } }
        }

        public static BindingList<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class> GetPurchaseOrderChaseReportQuery(DateTime STARTDATE, DateTime ENDDATE, long ORDERNO, Guid PROJECTNO, Guid SUPPLIERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].QueryDefs["GetPurchaseOrderChaseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("ORDERNO", ORDERNO);
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class> GetPurchaseOrderChaseReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, long ORDERNO, Guid PROJECTNO, Guid SUPPLIERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].QueryDefs["GetPurchaseOrderChaseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("ORDERNO", ORDERNO);
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectDetail.GetPurchaseOrderChaseReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectDetail> GetProjectDetailByConclusionNo(TTObjectContext objectContext, string CONCLUSIONNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].QueryDefs["GetProjectDetailByConclusionNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONCLUSIONNO", CONCLUSIONNO);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseProjectDetail>(queryDef, paramList);
        }

        public static BindingList<PurchaseProjectDetail.GetProjectDetails_Class> GetProjectDetails(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].QueryDefs["GetProjectDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectDetail.GetProjectDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProjectDetail.GetProjectDetails_Class> GetProjectDetails(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].QueryDefs["GetProjectDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProjectDetail.GetProjectDetails_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sıra NO
    /// </summary>
        public int? OrderNO
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Kur
    /// </summary>
        public Currency? Rate
        {
            get { return (Currency?)this["RATE"]; }
            set { this["RATE"] = value; }
        }

    /// <summary>
    /// Karar No
    /// </summary>
        public string ConclusionNO
        {
            get { return (string)this["CONCLUSIONNO"]; }
            set { this["CONCLUSIONNO"] = value; }
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
    /// Sözleşme Süresi
    /// </summary>
        public int? ContractTime
        {
            get { return (int?)this["CONTRACTTIME"]; }
            set { this["CONTRACTTIME"] = value; }
        }

    /// <summary>
    /// İstek Miktarı
    /// </summary>
        public Currency? RequestedAmount
        {
            get { return (Currency?)this["REQUESTEDAMOUNT"]; }
            set { this["REQUESTEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Alım Fiyatı (Avans Alımı İçin)
    /// </summary>
        public BigCurrency? PurchasePrice
        {
            get { return (BigCurrency?)this["PURCHASEPRICE"]; }
            set { this["PURCHASEPRICE"] = value; }
        }

    /// <summary>
    /// İptal Edilen Miktar
    /// </summary>
        public Currency? CancelledAmount
        {
            get { return (Currency?)this["CANCELLEDAMOUNT"]; }
            set { this["CANCELLEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Nato Stok No
    /// </summary>
        public string NSN
        {
            get { return (string)this["NSN"]; }
            set { this["NSN"] = value; }
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
    /// Olurluk Etüdü
    /// </summary>
        public string FeasibilityEtude
        {
            get { return (string)this["FEASIBILITYETUDE"]; }
            set { this["FEASIBILITYETUDE"] = value; }
        }

    /// <summary>
    /// İdari Şatnameye Atıf Yapılan Hususlar
    /// </summary>
        public string Isayf
        {
            get { return (string)this["ISAYF"]; }
            set { this["ISAYF"] = value; }
        }

    /// <summary>
    /// Fiyat Tespit Açıklaması
    /// </summary>
        public string PriceFormulationDesc
        {
            get { return (string)this["PRICEFORMULATIONDESC"]; }
            set { this["PRICEFORMULATIONDESC"] = value; }
        }

    /// <summary>
    /// İhale Komisyonu Durumu
    /// </summary>
        public TenderCommisionDetailStatusEnum? TenderCommisionStatus
        {
            get { return (TenderCommisionDetailStatusEnum?)(int?)this["TENDERCOMMISIONSTATUS"]; }
            set { this["TENDERCOMMISIONSTATUS"] = value; }
        }

    /// <summary>
    /// Sözleşme Başlangıç Tarihi
    /// </summary>
        public DateTime? ContractStartDate
        {
            get { return (DateTime?)this["CONTRACTSTARTDATE"]; }
            set { this["CONTRACTSTARTDATE"] = value; }
        }

    /// <summary>
    /// İşin Süresi
    /// </summary>
        public int? WorkTime
        {
            get { return (int?)this["WORKTIME"]; }
            set { this["WORKTIME"] = value; }
        }

    /// <summary>
    /// Garanti Süresi
    /// </summary>
        public int? GuarantyTime
        {
            get { return (int?)this["GUARANTYTIME"]; }
            set { this["GUARANTYTIME"] = value; }
        }

    /// <summary>
    /// İşin Bitiş Tarihi
    /// </summary>
        public DateTime? WorkEndDate
        {
            get { return (DateTime?)this["WORKENDDATE"]; }
            set { this["WORKENDDATE"] = value; }
        }

    /// <summary>
    /// Garanti Bitiş Tarihi
    /// </summary>
        public DateTime? GuarantyEndDate
        {
            get { return (DateTime?)this["GUARANTYENDDATE"]; }
            set { this["GUARANTYENDDATE"] = value; }
        }

    /// <summary>
    /// Sözleşme Bitiş Tarihi
    /// </summary>
        public DateTime? ContractEndDate
        {
            get { return (DateTime?)this["CONTRACTENDDATE"]; }
            set { this["CONTRACTENDDATE"] = value; }
        }

    /// <summary>
    /// Alımı Yapıldı
    /// </summary>
        public bool? Purchased
        {
            get { return (bool?)this["PURCHASED"]; }
            set { this["PURCHASED"] = value; }
        }

    /// <summary>
    /// İşin Başlangıç Tarihi
    /// </summary>
        public DateTime? WorkStartDate
        {
            get { return (DateTime?)this["WORKSTARTDATE"]; }
            set { this["WORKSTARTDATE"] = value; }
        }

    /// <summary>
    /// Garanti Bitiş Tarihi
    /// </summary>
        public DateTime? GuarantyStartDate
        {
            get { return (DateTime?)this["GUARANTYSTARTDATE"]; }
            set { this["GUARANTYSTARTDATE"] = value; }
        }

    /// <summary>
    /// Fiyat Tespiti Yapıldı
    /// </summary>
        public bool? AppPriceCalculated
        {
            get { return (bool?)this["APPPRICECALCULATED"]; }
            set { this["APPPRICECALCULATED"] = value; }
        }

        public PurchaseProjectGroup PurchaseProjectGroup
        {
            get { return (PurchaseProjectGroup)((ITTObject)this).GetParent("PURCHASEPROJECTGROUP"); }
            set { this["PURCHASEPROJECTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ContractDetail ContractDetail
        {
            get { return (ContractDetail)((ITTObject)this).GetParent("CONTRACTDETAIL"); }
            set { this["CONTRACTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateOldPurchasesCollection()
        {
            _OldPurchases = new OldPurchase.ChildOldPurchaseCollection(this, new Guid("022484bf-15dd-4b53-a671-3c260ff11dee"));
            ((ITTChildObjectCollection)_OldPurchases).GetChildren();
        }

        protected OldPurchase.ChildOldPurchaseCollection _OldPurchases = null;
        public OldPurchase.ChildOldPurchaseCollection OldPurchases
        {
            get
            {
                if (_OldPurchases == null)
                    CreateOldPurchasesCollection();
                return _OldPurchases;
            }
        }

        virtual protected void CreateProposalDetailsCollection()
        {
            _ProposalDetails = new ProposalDetail.ChildProposalDetailCollection(this, new Guid("3b938a54-b8d5-4f45-8e1a-4cb7b5f72ea3"));
            ((ITTChildObjectCollection)_ProposalDetails).GetChildren();
        }

        protected ProposalDetail.ChildProposalDetailCollection _ProposalDetails = null;
        public ProposalDetail.ChildProposalDetailCollection ProposalDetails
        {
            get
            {
                if (_ProposalDetails == null)
                    CreateProposalDetailsCollection();
                return _ProposalDetails;
            }
        }

        virtual protected void CreatePublicPurchasesForFormulationsCollection()
        {
            _PublicPurchasesForFormulations = new PublicPurchasesForFormulation.ChildPublicPurchasesForFormulationCollection(this, new Guid("badc4553-6876-4abf-9d8f-566ab6d7dd4a"));
            ((ITTChildObjectCollection)_PublicPurchasesForFormulations).GetChildren();
        }

        protected PublicPurchasesForFormulation.ChildPublicPurchasesForFormulationCollection _PublicPurchasesForFormulations = null;
        public PublicPurchasesForFormulation.ChildPublicPurchasesForFormulationCollection PublicPurchasesForFormulations
        {
            get
            {
                if (_PublicPurchasesForFormulations == null)
                    CreatePublicPurchasesForFormulationsCollection();
                return _PublicPurchasesForFormulations;
            }
        }

        virtual protected void CreatePurchaseOrderDetailsCollection()
        {
            _PurchaseOrderDetails = new PurchaseOrderDetail.ChildPurchaseOrderDetailCollection(this, new Guid("12bf97d8-126f-4a31-8aa5-7bf3ef05e5d7"));
            ((ITTChildObjectCollection)_PurchaseOrderDetails).GetChildren();
        }

        protected PurchaseOrderDetail.ChildPurchaseOrderDetailCollection _PurchaseOrderDetails = null;
        public PurchaseOrderDetail.ChildPurchaseOrderDetailCollection PurchaseOrderDetails
        {
            get
            {
                if (_PurchaseOrderDetails == null)
                    CreatePurchaseOrderDetailsCollection();
                return _PurchaseOrderDetails;
            }
        }

        virtual protected void CreatePreProposalsForFormulationsCollection()
        {
            _PreProposalsForFormulations = new PreProposalsForFormulation.ChildPreProposalsForFormulationCollection(this, new Guid("21431c5f-6ef4-431b-a82f-521dad99a601"));
            ((ITTChildObjectCollection)_PreProposalsForFormulations).GetChildren();
        }

        protected PreProposalsForFormulation.ChildPreProposalsForFormulationCollection _PreProposalsForFormulations = null;
        public PreProposalsForFormulation.ChildPreProposalsForFormulationCollection PreProposalsForFormulations
        {
            get
            {
                if (_PreProposalsForFormulations == null)
                    CreatePreProposalsForFormulationsCollection();
                return _PreProposalsForFormulations;
            }
        }

        virtual protected void CreateDemandDetailsCollection()
        {
            _DemandDetails = new DemandDetail.ChildDemandDetailCollection(this, new Guid("0f11d027-4a8c-4d98-b4a1-675e17cad8a2"));
            ((ITTChildObjectCollection)_DemandDetails).GetChildren();
        }

        protected DemandDetail.ChildDemandDetailCollection _DemandDetails = null;
        public DemandDetail.ChildDemandDetailCollection DemandDetails
        {
            get
            {
                if (_DemandDetails == null)
                    CreateDemandDetailsCollection();
                return _DemandDetails;
            }
        }

        virtual protected void CreateLBApproveDetailsCollection()
        {
            _LBApproveDetails = new LBApproveDetail.ChildLBApproveDetailCollection(this, new Guid("17044a6f-7dcf-4188-8236-8d1b9c8e5cc8"));
            ((ITTChildObjectCollection)_LBApproveDetails).GetChildren();
        }

        protected LBApproveDetail.ChildLBApproveDetailCollection _LBApproveDetails = null;
        public LBApproveDetail.ChildLBApproveDetailCollection LBApproveDetails
        {
            get
            {
                if (_LBApproveDetails == null)
                    CreateLBApproveDetailsCollection();
                return _LBApproveDetails;
            }
        }

        virtual protected void CreateAccountancyAmountsCollection()
        {
            _AccountancyAmounts = new PPDAccountancyAmount.ChildPPDAccountancyAmountCollection(this, new Guid("7fed31fb-2996-4187-ab82-f1e6cb553dae"));
            ((ITTChildObjectCollection)_AccountancyAmounts).GetChildren();
        }

        protected PPDAccountancyAmount.ChildPPDAccountancyAmountCollection _AccountancyAmounts = null;
        public PPDAccountancyAmount.ChildPPDAccountancyAmountCollection AccountancyAmounts
        {
            get
            {
                if (_AccountancyAmounts == null)
                    CreateAccountancyAmountsCollection();
                return _AccountancyAmounts;
            }
        }

        protected PurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseProjectDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseProjectDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEPROJECTDETAIL", dataRow) { }
        protected PurchaseProjectDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEPROJECTDETAIL", dataRow, isImported) { }
        public PurchaseProjectDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseProjectDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseProjectDetail() : base() { }

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