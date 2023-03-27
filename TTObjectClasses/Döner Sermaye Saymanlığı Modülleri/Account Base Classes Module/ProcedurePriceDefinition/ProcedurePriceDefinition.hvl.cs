
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedurePriceDefinition")] 

    /// <summary>
    /// Hizmet Fiyat Eşleştirme Tanımı
    /// </summary>
    public  partial class ProcedurePriceDefinition : TerminologyManagerDef
    {
        public class ProcedurePriceDefinitionList : TTObjectCollection<ProcedurePriceDefinition> { }
                    
        public class ChildProcedurePriceDefinitionCollection : TTObject.TTChildObjectCollection<ProcedurePriceDefinition>
        {
            public ChildProcedurePriceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedurePriceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ProcedurePriceListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public ProcedurePriceListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ProcedurePriceListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ProcedurePriceListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class ProcedurePriceListByProcedure_Class : TTReportNqlObject 
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

            public ProcedurePriceListByProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ProcedurePriceListByProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ProcedurePriceListByProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class ProcedurePriceListByProcedureAndPriceList_Class : TTReportNqlObject 
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

            public ProcedurePriceListByProcedureAndPriceList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ProcedurePriceListByProcedureAndPriceList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ProcedurePriceListByProcedureAndPriceList_Class() : base() { }
        }

        public static BindingList<ProcedurePriceDefinition.ProcedurePriceListNQL_Class> ProcedurePriceListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["ProcedurePriceListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedurePriceDefinition.ProcedurePriceListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedurePriceDefinition.ProcedurePriceListNQL_Class> ProcedurePriceListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["ProcedurePriceListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedurePriceDefinition.ProcedurePriceListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class> ProcedurePriceListByProcedure(string PROCEDUREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["ProcedurePriceListByProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);

            return TTReportNqlObject.QueryObjects<ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class> ProcedurePriceListByProcedure(TTObjectContext objectContext, string PROCEDUREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["ProcedurePriceListByProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);

            return TTReportNqlObject.QueryObjects<ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedurePriceDefinition> GetProcedurePriceDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["GetProcedurePriceDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedurePriceDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class> ProcedurePriceListByProcedureAndPriceList(string PROCEDUREOBJECTID, string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["ProcedurePriceListByProcedureAndPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class> ProcedurePriceListByProcedureAndPriceList(TTObjectContext objectContext, string PROCEDUREOBJECTID, string PRICELIST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["ProcedurePriceListByProcedureAndPriceList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREOBJECTID", PROCEDUREOBJECTID);
            paramList.Add("PRICELIST", PRICELIST);

            return TTReportNqlObject.QueryObjects<ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedurePriceDefinition> GetByPricingDetail(TTObjectContext objectContext, string PRICINGDETAIL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREPRICEDEFINITION"].QueryDefs["GetByPricingDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRICINGDETAIL", PRICINGDETAIL);

            return ((ITTQuery)objectContext).QueryObjects<ProcedurePriceDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? AMOUNT
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public PricingDetailDefinition PricingDetail
        {
            get { return (PricingDetailDefinition)((ITTObject)this).GetParent("PRICINGDETAIL"); }
            set { this["PRICINGDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedurePriceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedurePriceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedurePriceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedurePriceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedurePriceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREPRICEDEFINITION", dataRow) { }
        protected ProcedurePriceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREPRICEDEFINITION", dataRow, isImported) { }
        public ProcedurePriceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedurePriceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedurePriceDefinition() : base() { }

    }
}