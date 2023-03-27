
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PricingListGroupDefinition")] 

    /// <summary>
    /// Fiyat listesi grubu
    /// </summary>
    public  partial class PricingListGroupDefinition : TerminologyManagerDef
    {
        public class PricingListGroupDefinitionList : TTObjectCollection<PricingListGroupDefinition> { }
                    
        public class ChildPricingListGroupDefinitionCollection : TTObject.TTChildObjectCollection<PricingListGroupDefinition>
        {
            public ChildPricingListGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPricingListGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPricingListGroupDefinitions_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Pricinglistgroupdescription
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICINGLISTGROUPDESCRIPTION"]);
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

            public GetPricingListGroupDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPricingListGroupDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPricingListGroupDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_PricingListGroupDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? ParentPricingListGroupID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTPRICINGLISTGROUPID"]);
                }
            }

            public OLAP_PricingListGroupDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_PricingListGroupDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_PricingListGroupDefinition_Class() : base() { }
        }

        public static BindingList<PricingListGroupDefinition.GetPricingListGroupDefinitions_Class> GetPricingListGroupDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].QueryDefs["GetPricingListGroupDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListGroupDefinition.GetPricingListGroupDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PricingListGroupDefinition.GetPricingListGroupDefinitions_Class> GetPricingListGroupDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].QueryDefs["GetPricingListGroupDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListGroupDefinition.GetPricingListGroupDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PricingListGroupDefinition.OLAP_PricingListGroupDefinition_Class> OLAP_PricingListGroupDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].QueryDefs["OLAP_PricingListGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListGroupDefinition.OLAP_PricingListGroupDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PricingListGroupDefinition.OLAP_PricingListGroupDefinition_Class> OLAP_PricingListGroupDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].QueryDefs["OLAP_PricingListGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PricingListGroupDefinition.OLAP_PricingListGroupDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PricingListGroupDefinition> GetPricingListGroupDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICINGLISTGROUPDEFINITION"].QueryDefs["GetPricingListGroupDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PricingListGroupDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public PricingListDefinition PricingList
        {
            get { return (PricingListDefinition)((ITTObject)this).GetParent("PRICINGLIST"); }
            set { this["PRICINGLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PricingListGroupDefinition ParentPricingListGroupID
        {
            get { return (PricingListGroupDefinition)((ITTObject)this).GetParent("PARENTPRICINGLISTGROUPID"); }
            set { this["PARENTPRICINGLISTGROUPID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePricingListGroupsCollection()
        {
            _PricingListGroups = new PricingListGroupDefinition.ChildPricingListGroupDefinitionCollection(this, new Guid("72a86d75-8366-4f77-b244-b833ca6fee9f"));
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

        protected PricingListGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PricingListGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PricingListGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PricingListGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PricingListGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICINGLISTGROUPDEFINITION", dataRow) { }
        protected PricingListGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICINGLISTGROUPDEFINITION", dataRow, isImported) { }
        protected PricingListGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PricingListGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PricingListGroupDefinition() : base() { }

    }
}