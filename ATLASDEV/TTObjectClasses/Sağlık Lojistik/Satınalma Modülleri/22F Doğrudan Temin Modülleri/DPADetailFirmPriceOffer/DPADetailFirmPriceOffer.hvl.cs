
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DPADetailFirmPriceOffer")] 

    /// <summary>
    /// Firma Fiyat Teklifleri
    /// </summary>
    public  partial class DPADetailFirmPriceOffer : TTObject
    {
        public class DPADetailFirmPriceOfferList : TTObjectCollection<DPADetailFirmPriceOffer> { }
                    
        public class ChildDPADetailFirmPriceOfferCollection : TTObject.TTChildObjectCollection<DPADetailFirmPriceOffer>
        {
            public ChildDPADetailFirmPriceOfferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDPADetailFirmPriceOfferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDirectPurchaseActionDetailList_Class : TTReportNqlObject 
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

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public GetDirectPurchaseActionDetailList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDirectPurchaseActionDetailList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDirectPurchaseActionDetailList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRadyofarmasotikDPADetailList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public GetRadyofarmasotikDPADetailList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadyofarmasotikDPADetailList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadyofarmasotikDPADetailList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCodelessMatDPADetailList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATERIALNAME"].DataType;
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

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public GetCodelessMatDPADetailList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCodelessMatDPADetailList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCodelessMatDPADetailList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalPriceDPADetailFirmOffer_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Firm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIRMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FirmAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["FIRMADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Firmaobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FIRMAOBJECTID"]);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].AllPropertyDefs["UNITPRICE"].DataType;
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

            public GetTotalPriceDPADetailFirmOffer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalPriceDPADetailFirmOffer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalPriceDPADetailFirmOffer_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialInspectionAndReceivingReportInfoNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? Birimfiyat
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIMFIYAT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Ubbkodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UBBKODU"]);
                }
            }

            public Guid? Onerilensutkodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ONERILENSUTKODU"]);
                }
            }

            public Guid? Tedarikci
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDARIKCI"]);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
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

            public Guid? Olcubirimi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCUBIRIMI"]);
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

            public MaterialInspectionAndReceivingReportInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialInspectionAndReceivingReportInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialInspectionAndReceivingReportInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUygunGorulenFirmalarQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Firm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIRMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FirmAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["FIRMADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Firmaobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FIRMAOBJECTID"]);
                }
            }

            public string ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].AllPropertyDefs["UNITPRICE"].DataType;
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

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public string Rpcsutkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RPCSUTKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rpcmalzemeismi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RPCMALZEMEISMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetUygunGorulenFirmalarQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUygunGorulenFirmalarQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUygunGorulenFirmalarQuery_Class() : base() { }
        }

        public static BindingList<DPADetailFirmPriceOffer.GetDirectPurchaseActionDetailList_Class> GetDirectPurchaseActionDetailList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetDirectPurchaseActionDetailList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetDirectPurchaseActionDetailList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetDirectPurchaseActionDetailList_Class> GetDirectPurchaseActionDetailList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetDirectPurchaseActionDetailList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetDirectPurchaseActionDetailList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetRadyofarmasotikDPADetailList_Class> GetRadyofarmasotikDPADetailList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetRadyofarmasotikDPADetailList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetRadyofarmasotikDPADetailList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetRadyofarmasotikDPADetailList_Class> GetRadyofarmasotikDPADetailList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetRadyofarmasotikDPADetailList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetRadyofarmasotikDPADetailList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetCodelessMatDPADetailList_Class> GetCodelessMatDPADetailList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetCodelessMatDPADetailList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetCodelessMatDPADetailList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetCodelessMatDPADetailList_Class> GetCodelessMatDPADetailList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetCodelessMatDPADetailList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetCodelessMatDPADetailList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer> GetUnsedAndApproved22FMaterialByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetUnsedAndApproved22FMaterialByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<DPADetailFirmPriceOffer>(queryDef, paramList);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> GetTotalPriceDPADetailFirmOffer(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetTotalPriceDPADetailFirmOffer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class> GetTotalPriceDPADetailFirmOffer(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetTotalPriceDPADetailFirmOffer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetTotalPriceDPADetailFirmOffer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class> MaterialInspectionAndReceivingReportInfoNQL(string DPADETAILFIRMPRICEOFFER, string FIRMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["MaterialInspectionAndReceivingReportInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DPADETAILFIRMPRICEOFFER", DPADETAILFIRMPRICEOFFER);
            paramList.Add("FIRMOBJECTID", FIRMOBJECTID);

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class> MaterialInspectionAndReceivingReportInfoNQL(TTObjectContext objectContext, string DPADETAILFIRMPRICEOFFER, string FIRMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["MaterialInspectionAndReceivingReportInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DPADETAILFIRMPRICEOFFER", DPADETAILFIRMPRICEOFFER);
            paramList.Add("FIRMOBJECTID", FIRMOBJECTID);

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class> GetUygunGorulenFirmalarQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetUygunGorulenFirmalarQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class> GetUygunGorulenFirmalarQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPADETAILFIRMPRICEOFFER"].QueryDefs["GetUygunGorulenFirmalarQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DPADetailFirmPriceOffer.GetUygunGorulenFirmalarQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Donör ID
    /// </summary>
        public string DonorID
        {
            get { return (string)this["DONORID"]; }
            set { this["DONORID"] = value; }
        }

    /// <summary>
    /// Uygun Bulundu
    /// </summary>
        public bool? Approved
        {
            get { return (bool?)this["APPROVED"]; }
            set { this["APPROVED"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Teklifin Kabul veya Red Durumu
    /// </summary>
        public bool? AcceptedRejected
        {
            get { return (bool?)this["ACCEPTEDREJECTED"]; }
            set { this["ACCEPTEDREJECTED"] = value; }
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
    /// Teklif Ettiği UBB
    /// </summary>
        public ProductDefinition OfferedUBB
        {
            get { return (ProductDefinition)((ITTObject)this).GetParent("OFFEREDUBB"); }
            set { this["OFFEREDUBB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProductSUTMatchDefinition OfferedSUTCode
        {
            get { return (ProductSUTMatchDefinition)((ITTObject)this).GetParent("OFFEREDSUTCODE"); }
            set { this["OFFEREDSUTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FirmDefinition Firm
        {
            get { return (FirmDefinition)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DirectPurchaseFirmProposal DirectPurchaseFirmProposal
        {
            get { return (DirectPurchaseFirmProposal)((ITTObject)this).GetParent("DIRECTPURCHASEFIRMPROPOSAL"); }
            set { this["DIRECTPURCHASEFIRMPROPOSAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Firma Fiyat Teklifleri
    /// </summary>
        public DirectPurchaseActionDetail DirectPurchaseActionDetail
        {
            get { return (DirectPurchaseActionDetail)((ITTObject)this).GetParent("DIRECTPURCHASEACTIONDETAIL"); }
            set { this["DIRECTPURCHASEACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRadyofarmasotikDirectPurchaseGridCollection()
        {
            _RadyofarmasotikDirectPurchaseGrid = new RadyofarmasotikDirectPurchaseGrid.ChildRadyofarmasotikDirectPurchaseGridCollection(this, new Guid("1bc42303-6cb2-420c-be9d-cbbb254b5ccd"));
            ((ITTChildObjectCollection)_RadyofarmasotikDirectPurchaseGrid).GetChildren();
        }

        protected RadyofarmasotikDirectPurchaseGrid.ChildRadyofarmasotikDirectPurchaseGridCollection _RadyofarmasotikDirectPurchaseGrid = null;
        public RadyofarmasotikDirectPurchaseGrid.ChildRadyofarmasotikDirectPurchaseGridCollection RadyofarmasotikDirectPurchaseGrid
        {
            get
            {
                if (_RadyofarmasotikDirectPurchaseGrid == null)
                    CreateRadyofarmasotikDirectPurchaseGridCollection();
                return _RadyofarmasotikDirectPurchaseGrid;
            }
        }

        virtual protected void CreateSurgeryDirectPurchaseGridCollection()
        {
            _SurgeryDirectPurchaseGrid = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(this, new Guid("a42965a8-0249-45d4-a58f-fc012be16150"));
            ((ITTChildObjectCollection)_SurgeryDirectPurchaseGrid).GetChildren();
        }

        protected SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _SurgeryDirectPurchaseGrid = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection SurgeryDirectPurchaseGrid
        {
            get
            {
                if (_SurgeryDirectPurchaseGrid == null)
                    CreateSurgeryDirectPurchaseGridCollection();
                return _SurgeryDirectPurchaseGrid;
            }
        }

        virtual protected void CreateCodelessMaterialDirectPurchaseGridCollection()
        {
            _CodelessMaterialDirectPurchaseGrid = new CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection(this, new Guid("d1cec1c3-72ca-464c-bc29-f9230f7e629b"));
            ((ITTChildObjectCollection)_CodelessMaterialDirectPurchaseGrid).GetChildren();
        }

        protected CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection _CodelessMaterialDirectPurchaseGrid = null;
        public CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection CodelessMaterialDirectPurchaseGrid
        {
            get
            {
                if (_CodelessMaterialDirectPurchaseGrid == null)
                    CreateCodelessMaterialDirectPurchaseGridCollection();
                return _CodelessMaterialDirectPurchaseGrid;
            }
        }

        protected DPADetailFirmPriceOffer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DPADetailFirmPriceOffer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DPADetailFirmPriceOffer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DPADetailFirmPriceOffer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DPADetailFirmPriceOffer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPADETAILFIRMPRICEOFFER", dataRow) { }
        protected DPADetailFirmPriceOffer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPADETAILFIRMPRICEOFFER", dataRow, isImported) { }
        public DPADetailFirmPriceOffer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DPADetailFirmPriceOffer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DPADetailFirmPriceOffer() : base() { }

    }
}