
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PricingDetailDefinition")] 

    /// <summary>
    /// Fiyat  Tanımlama
    /// </summary>
    public  partial class PricingDetailDefinition : TerminologyManagerDef
    {
        public class PricingDetailDefinitionList : TTObjectCollection<PricingDetailDefinition> { }
                    
        public class ChildPricingDetailDefinitionCollection : TTObject.TTChildObjectCollection<PricingDetailDefinition>
        {
            public ChildPricingDetailDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPricingDetailDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_PricingDetailDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Guid? PricingList
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRICINGLIST"]);
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

            public Guid? PricingListGroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRICINGLISTGROUP"]);
                }
            }

            public OLAP_PricingDetailDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_PricingDetailDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_PricingDetailDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEffectivePricingDetailDefsByPriceList_Class : TTReportNqlObject 
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

            public GetEffectivePricingDetailDefsByPriceList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEffectivePricingDetailDefsByPriceList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEffectivePricingDetailDefsByPriceList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEffectivePricingDetailDefsByEndDate_Class : TTReportNqlObject 
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

            public long? SPTSPricingDetailID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSPRICINGDETAILID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["SPTSPRICINGDETAILID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? OutPatientDiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTDISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["OUTPATIENTDISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Description_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION_SHADOW"].DataType;
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

            public double? Point
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["POINT"].DataType;
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

            public MedulaSUTGroupEnum? MedulaSUTGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASUTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["MEDULASUTGROUP"].DataType;
                    return (MedulaSUTGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? InPatientDiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["INPATIENTDISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public GetEffectivePricingDetailDefsByEndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEffectivePricingDetailDefsByEndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEffectivePricingDetailDefsByEndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPricingDetailDefinitions_Class : TTReportNqlObject 
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

            public string Currencytypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENCYTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CURRENCYTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetPricingDetailDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPricingDetailDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPricingDetailDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByPriceListAndExternalCode_Class : TTReportNqlObject 
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

            public long? SPTSPricingDetailID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSPRICINGDETAILID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["SPTSPRICINGDETAILID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? OutPatientDiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTDISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["OUTPATIENTDISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Description_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["DESCRIPTION_SHADOW"].DataType;
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

            public double? Point
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["POINT"].DataType;
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

            public MedulaSUTGroupEnum? MedulaSUTGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASUTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["MEDULASUTGROUP"].DataType;
                    return (MedulaSUTGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? InPatientDiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].AllPropertyDefs["INPATIENTDISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetByPriceListAndExternalCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPriceListAndExternalCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPriceListAndExternalCode_Class() : base() { }
        }

        public static BindingList<PricingDetailDefinition.OLAP_PricingDetailDefinition_Class> OLAP_PricingDetailDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["OLAP_PricingDetailDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.OLAP_PricingDetailDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition.OLAP_PricingDetailDefinition_Class> OLAP_PricingDetailDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["OLAP_PricingDetailDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.OLAP_PricingDetailDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition> GetPricingDetailDefinitionByObjectID(TTObjectContext objectContext, string PARAMOBJID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetPricingDetailDefinitionByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return ((ITTQuery)objectContext).QueryObjects<PricingDetailDefinition>(queryDef, paramList);
        }

        public static BindingList<PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class> GetEffectivePricingDetailDefsByPriceList(string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetEffectivePricingDetailDefsByPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class> GetEffectivePricingDetailDefsByPriceList(TTObjectContext objectContext, string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetEffectivePricingDetailDefsByPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class> GetEffectivePricingDetailDefsByEndDate(DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetEffectivePricingDetailDefsByEndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class> GetEffectivePricingDetailDefsByEndDate(TTObjectContext objectContext, DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetEffectivePricingDetailDefsByEndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition.GetPricingDetailDefinitions_Class> GetPricingDetailDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetPricingDetailDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetPricingDetailDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PricingDetailDefinition.GetPricingDetailDefinitions_Class> GetPricingDetailDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetPricingDetailDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetPricingDetailDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PricingDetailDefinition> GetPricingDetailDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetPricingDetailDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PricingDetailDefinition>(queryDef, paramList);
        }

        public static BindingList<PricingDetailDefinition.GetByPriceListAndExternalCode_Class> GetByPriceListAndExternalCode(string PRICELIST, string EXTERNALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetByPriceListAndExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetByPriceListAndExternalCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PricingDetailDefinition.GetByPriceListAndExternalCode_Class> GetByPriceListAndExternalCode(TTObjectContext objectContext, string PRICELIST, string EXTERNALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGDETAILDEFINITION"].QueryDefs["GetByPriceListAndExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICELIST", PRICELIST);
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return TTReportNqlObject.QueryObjects<PricingDetailDefinition.GetByPriceListAndExternalCode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Fiyat geçerlilik bitiş tarihi
    /// </summary>
        public DateTime? DateEnd
        {
            get { return (DateTime?)this["DATEEND"]; }
            set { this["DATEEND"] = value; }
        }

    /// <summary>
    /// Fiyat geçerlilik başlama zamanı
    /// </summary>
        public DateTime? DateStart
        {
            get { return (DateTime?)this["DATESTART"]; }
            set { this["DATESTART"] = value; }
        }

    /// <summary>
    /// Fiyat açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Fiyat kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// SPTS Fiyat Tanımı
    /// </summary>
        public long? SPTSPricingDetailID
        {
            get { return (long?)this["SPTSPRICINGDETAILID"]; }
            set { this["SPTSPRICINGDETAILID"] = value; }
        }

    /// <summary>
    /// Ayaktan Hasta İndirim/Artırım Oranı
    /// </summary>
        public double? OutPatientDiscountPercent
        {
            get { return (double?)this["OUTPATIENTDISCOUNTPERCENT"]; }
            set { this["OUTPATIENTDISCOUNTPERCENT"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Puanı
    /// </summary>
        public double? Point
        {
            get { return (double?)this["POINT"]; }
            set { this["POINT"] = value; }
        }

    /// <summary>
    /// İndirimsiz Fiyat
    /// </summary>
        public Currency? PriceWithOutDiscount
        {
            get { return (Currency?)this["PRICEWITHOUTDISCOUNT"]; }
            set { this["PRICEWITHOUTDISCOUNT"] = value; }
        }

    /// <summary>
    /// İndirim Oranı
    /// </summary>
        public double? DiscountPercent
        {
            get { return (double?)this["DISCOUNTPERCENT"]; }
            set { this["DISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// Medula Grubu
    /// </summary>
        public MedulaSUTGroupEnum? MedulaSUTGroup
        {
            get { return (MedulaSUTGroupEnum?)(int?)this["MEDULASUTGROUP"]; }
            set { this["MEDULASUTGROUP"] = value; }
        }

    /// <summary>
    /// Yatan Hasta İndirim/Artırım Oranı
    /// </summary>
        public double? InPatientDiscountPercent
        {
            get { return (double?)this["INPATIENTDISCOUNTPERCENT"]; }
            set { this["INPATIENTDISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// Fiyat Listesi ilişkisi
    /// </summary>
        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bağlı Olduğu Fiyat Grubu ilişkisi
    /// </summary>
        public PricingListGroupDefinition PricingListGroup
        {
            get { return (PricingListGroupDefinition)((ITTObject)this).GetParent("PRICINGLISTGROUP"); }
            set { this["PRICINGLISTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Para Birimi ile ilişki
    /// </summary>
        public CurrencyTypeDefinition CurrencyType
        {
            get { return (CurrencyTypeDefinition)((ITTObject)this).GetParent("CURRENCYTYPE"); }
            set { this["CURRENCYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("3b7aeba7-d7d7-46d9-8496-6dca3220d5fa"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Fiyat ile ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransaction
        {
            get
            {
                if (_AccountTransaction == null)
                    CreateAccountTransactionCollection();
                return _AccountTransaction;
            }
        }

        virtual protected void CreateProcedurePriceCollection()
        {
            _ProcedurePrice = new ProcedurePriceDefinition.ChildProcedurePriceDefinitionCollection(this, new Guid("c3f86ba4-8db0-4cc0-a482-dd03afc3f8a9"));
            ((ITTChildObjectCollection)_ProcedurePrice).GetChildren();
        }

        protected ProcedurePriceDefinition.ChildProcedurePriceDefinitionCollection _ProcedurePrice = null;
    /// <summary>
    /// Child collection for Fiyat
    /// </summary>
        public ProcedurePriceDefinition.ChildProcedurePriceDefinitionCollection ProcedurePrice
        {
            get
            {
                if (_ProcedurePrice == null)
                    CreateProcedurePriceCollection();
                return _ProcedurePrice;
            }
        }

        virtual protected void CreateGeneralReceiptProcedureCollection()
        {
            _GeneralReceiptProcedure = new GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection(this, new Guid("d85d0af6-80e6-4e0e-859b-46a0744676f8"));
            ((ITTChildObjectCollection)_GeneralReceiptProcedure).GetChildren();
        }

        protected GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection _GeneralReceiptProcedure = null;
    /// <summary>
    /// Child collection for Fiyatla ilişki
    /// </summary>
        public GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection GeneralReceiptProcedure
        {
            get
            {
                if (_GeneralReceiptProcedure == null)
                    CreateGeneralReceiptProcedureCollection();
                return _GeneralReceiptProcedure;
            }
        }

        virtual protected void CreateGeneralInvoiceProcedureCollection()
        {
            _GeneralInvoiceProcedure = new GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection(this, new Guid("48b084f7-0ae7-4b9e-940e-3bcb2739a3aa"));
            ((ITTChildObjectCollection)_GeneralInvoiceProcedure).GetChildren();
        }

        protected GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection _GeneralInvoiceProcedure = null;
    /// <summary>
    /// Child collection for Fiyatla ilişki
    /// </summary>
        public GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection GeneralInvoiceProcedure
        {
            get
            {
                if (_GeneralInvoiceProcedure == null)
                    CreateGeneralInvoiceProcedureCollection();
                return _GeneralInvoiceProcedure;
            }
        }

        protected PricingDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PricingDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PricingDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PricingDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PricingDetailDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICINGDETAILDEFINITION", dataRow) { }
        protected PricingDetailDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICINGDETAILDEFINITION", dataRow, isImported) { }
        public PricingDetailDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PricingDetailDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PricingDetailDefinition() : base() { }

    }
}