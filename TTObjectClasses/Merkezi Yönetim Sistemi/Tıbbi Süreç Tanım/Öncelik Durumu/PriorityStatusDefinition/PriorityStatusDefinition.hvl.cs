
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PriorityStatusDefinition")] 

    /// <summary>
    /// Öncelik Durumu Tanımlama
    /// </summary>
    public  partial class PriorityStatusDefinition : TerminologyManagerDef
    {
        public class PriorityStatusDefinitionList : TTObjectCollection<PriorityStatusDefinition> { }
                    
        public class ChildPriorityStatusDefinitionCollection : TTObject.TTChildObjectCollection<PriorityStatusDefinition>
        {
            public ChildPriorityStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPriorityStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPriorityStatus_Class : TTReportNqlObject 
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Order
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["ORDER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPriorityStatus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPriorityStatus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPriorityStatus_Class() : base() { }
        }

        public static BindingList<PriorityStatusDefinition.GetPriorityStatus_Class> GetPriorityStatus(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].QueryDefs["GetPriorityStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PriorityStatusDefinition.GetPriorityStatus_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PriorityStatusDefinition.GetPriorityStatus_Class> GetPriorityStatus(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].QueryDefs["GetPriorityStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PriorityStatusDefinition.GetPriorityStatus_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PriorityStatusDefinition> GetPriorityStatusByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].QueryDefs["GetPriorityStatusByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<PriorityStatusDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Öncelik
    /// </summary>
        public long? Order
        {
            get { return (long?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

        protected PriorityStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PriorityStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PriorityStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PriorityStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PriorityStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRIORITYSTATUSDEFINITION", dataRow) { }
        protected PriorityStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRIORITYSTATUSDEFINITION", dataRow, isImported) { }
        protected PriorityStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PriorityStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PriorityStatusDefinition() : base() { }

    }
}