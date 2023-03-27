
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PricingListDefinition")] 

    /// <summary>
    /// Fiyat Listesi
    /// </summary>
    public  partial class PricingListDefinition : TerminologyManagerDef
    {
        public class PricingListDefinitionList : TTObjectCollection<PricingListDefinition> { }
                    
        public class ChildPricingListDefinitionCollection : TTObject.TTChildObjectCollection<PricingListDefinition>
        {
            public ChildPricingListDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPricingListDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPricingListDefinitions_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPricingListDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPricingListDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPricingListDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetPricingListDef_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetPricingListDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPricingListDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPricingListDef_Class() : base() { }
        }

        public static BindingList<PricingListDefinition> GetByCode(TTObjectContext objectContext, string PARAMCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["GetByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCODE", PARAMCODE);

            return ((ITTQuery)objectContext).QueryObjects<PricingListDefinition>(queryDef, paramList);
        }

        public static BindingList<PricingListDefinition.GetPricingListDefinitions_Class> GetPricingListDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["GetPricingListDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListDefinition.GetPricingListDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PricingListDefinition.GetPricingListDefinitions_Class> GetPricingListDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["GetPricingListDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListDefinition.GetPricingListDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PricingListDefinition.OLAP_GetPricingListDef_Class> OLAP_GetPricingListDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["OLAP_GetPricingListDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListDefinition.OLAP_GetPricingListDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PricingListDefinition.OLAP_GetPricingListDef_Class> OLAP_GetPricingListDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["OLAP_GetPricingListDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListDefinition.OLAP_GetPricingListDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PricingListDefinition> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PricingListDefinition>(queryDef, paramList);
        }

        public static BindingList<PricingListDefinition> GetPricingListDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTDEFINITION"].QueryDefs["GetPricingListDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PricingListDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Fiyat listesi kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Fiyat listesi adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreatePricingListGroupsCollection()
        {
            _PricingListGroups = new PricingListGroupDefinition.ChildPricingListGroupDefinitionCollection(this, new Guid("ad6dd2a5-cc2a-4d5e-99cd-19eef086afd7"));
            ((ITTChildObjectCollection)_PricingListGroups).GetChildren();
        }

        protected PricingListGroupDefinition.ChildPricingListGroupDefinitionCollection _PricingListGroups = null;
        public PricingListGroupDefinition.ChildPricingListGroupDefinitionCollection PricingListGroups
        {
            get
            {
                if (_PricingListGroups == null)
                    CreatePricingListGroupsCollection();
                return _PricingListGroups;
            }
        }

        virtual protected void CreatePriceUpdatingCollection()
        {
            _PriceUpdating = new PriceUpdating.ChildPriceUpdatingCollection(this, new Guid("5602ff10-45b1-4fe5-9b67-aaf92d73cbe9"));
            ((ITTChildObjectCollection)_PriceUpdating).GetChildren();
        }

        protected PriceUpdating.ChildPriceUpdatingCollection _PriceUpdating = null;
    /// <summary>
    /// Child collection for Fiyat listesi ile ilişki
    /// </summary>
        public PriceUpdating.ChildPriceUpdatingCollection PriceUpdating
        {
            get
            {
                if (_PriceUpdating == null)
                    CreatePriceUpdatingCollection();
                return _PriceUpdating;
            }
        }

        protected PricingListDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PricingListDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PricingListDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PricingListDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PricingListDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICINGLISTDEFINITION", dataRow) { }
        protected PricingListDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICINGLISTDEFINITION", dataRow, isImported) { }
        public PricingListDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PricingListDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PricingListDefinition() : base() { }

    }
}