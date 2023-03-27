
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialPrice")] 

    /// <summary>
    /// Malzeme Fiyat Eşleştirme Tanımı
    /// </summary>
    public  partial class MaterialPrice : TerminologyManagerDef
    {
        public class MaterialPriceList : TTObjectCollection<MaterialPrice> { }
                    
        public class ChildMaterialPriceCollection : TTObject.TTChildObjectCollection<MaterialPrice>
        {
            public ChildMaterialPriceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialPriceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MaterialPriceNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateEnd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATEEND"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATESTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATESTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Pricinglistname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGLISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricingcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricinglistgroupdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGLISTGROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPriceNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialPriceNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialPriceNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialPriceByMaterialAndPriceList_Class : TTReportNqlObject 
        {
            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricelistname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICELISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? DateStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATESTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATESTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateEnd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATEEND"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Pricegroupcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEGROUPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricegroupname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public MaterialPriceByMaterialAndPriceList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialPriceByMaterialAndPriceList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialPriceByMaterialAndPriceList_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialPriceByMaterialForDefinition_Class : TTReportNqlObject 
        {
            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pricelistname
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRICELISTNAME"]);
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

            public DateTime? DateStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATESTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATESTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateEnd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATEEND"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Currencytype
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENCYTYPE"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? PriceWithOutDiscount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEWITHOUTDISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["PRICEWITHOUTDISCOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public MaterialPriceByMaterialForDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialPriceByMaterialForDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialPriceByMaterialForDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialPriceForCostBenefit_Class : TTReportNqlObject 
        {
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

            public MaterialPriceForCostBenefit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialPriceForCostBenefit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialPriceForCostBenefit_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialPriceByMaterial_Class : TTReportNqlObject 
        {
            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricelistname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICELISTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? DateStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATESTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATESTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateEnd
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEEND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DATEEND"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Pricegroupcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEGROUPCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pricegroupname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public MaterialPriceByMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialPriceByMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialPriceByMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialPriceForMedicalProcess_Class : TTReportNqlObject 
        {
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

            public MaterialPriceForMedicalProcess_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialPriceForMedicalProcess_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialPriceForMedicalProcess_Class() : base() { }
        }

        public static BindingList<MaterialPrice.MaterialPriceNQL_Class> MaterialPriceNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceNQL_Class> MaterialPriceNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaterialPrice> GetMaterialPriceBySPTSPricingDetailID(TTObjectContext objectContext, long PRICINGDETAILID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["GetMaterialPriceBySPTSPricingDetailID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICINGDETAILID", PRICINGDETAILID);

            return ((ITTQuery)objectContext).QueryObjects<MaterialPrice>(queryDef, paramList);
        }

        public static BindingList<MaterialPrice> GetMaterialPriceByMaterial(TTObjectContext objectContext, string MATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["GetMaterialPriceByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<MaterialPrice>(queryDef, paramList);
        }

        public static BindingList<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class> MaterialPriceByMaterialAndPriceList(string PRICELIST, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceByMaterialAndPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class> MaterialPriceByMaterialAndPriceList(TTObjectContext objectContext, string PRICELIST, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceByMaterialAndPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> MaterialPriceByMaterialForDefinition(string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceByMaterialForDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceByMaterialForDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> MaterialPriceByMaterialForDefinition(TTObjectContext objectContext, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceByMaterialForDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceByMaterialForDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice> GetMaterialPriceByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["GetMaterialPriceByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MaterialPrice>(queryDef, paramList);
        }

        public static BindingList<MaterialPrice.MaterialPriceForCostBenefit_Class> MaterialPriceForCostBenefit(string MATERIALOBJECTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceForCostBenefit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceForCostBenefit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceForCostBenefit_Class> MaterialPriceForCostBenefit(TTObjectContext objectContext, string MATERIALOBJECTID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceForCostBenefit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceForCostBenefit_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceByMaterial_Class> MaterialPriceByMaterial(string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceByMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceByMaterial_Class> MaterialPriceByMaterial(TTObjectContext objectContext, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceByMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceForMedicalProcess_Class> MaterialPriceForMedicalProcess(DateTime DATE, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceForMedicalProcess"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceForMedicalProcess_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialPrice.MaterialPriceForMedicalProcess_Class> MaterialPriceForMedicalProcess(TTObjectContext objectContext, DateTime DATE, string MATERIALOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALPRICE"].QueryDefs["MaterialPriceForMedicalProcess"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);

            return TTReportNqlObject.QueryObjects<MaterialPrice.MaterialPriceForMedicalProcess_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public PricingDetailDefinition PricingDetail
        {
            get { return (PricingDetailDefinition)((ITTObject)this).GetParent("PRICINGDETAIL"); }
            set { this["PRICINGDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialPrice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialPrice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialPrice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALPRICE", dataRow) { }
        protected MaterialPrice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALPRICE", dataRow, isImported) { }
        public MaterialPrice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialPrice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialPrice() : base() { }

    }
}