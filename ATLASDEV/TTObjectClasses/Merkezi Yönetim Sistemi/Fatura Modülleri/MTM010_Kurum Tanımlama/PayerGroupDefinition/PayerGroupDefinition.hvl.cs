
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerGroupDefinition")] 

    /// <summary>
    /// Kurum Grubu
    /// </summary>
    public  partial class PayerGroupDefinition : TerminologyManagerDef
    {
        public class PayerGroupDefinitionList : TTObjectCollection<PayerGroupDefinition> { }
                    
        public class ChildPayerGroupDefinitionCollection : TTObject.TTChildObjectCollection<PayerGroupDefinition>
        {
            public ChildPayerGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPayerGroupDefinitions_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERGROUPDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERGROUPDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPayerGroupDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerGroupDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerGroupDefinitions_Class() : base() { }
        }

        public static BindingList<PayerGroupDefinition> GetPayerGroupDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERGROUPDEFINITION"].QueryDefs["GetPayerGroupDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PayerGroupDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerGroupDefinition.GetPayerGroupDefinitions_Class> GetPayerGroupDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERGROUPDEFINITION"].QueryDefs["GetPayerGroupDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerGroupDefinition.GetPayerGroupDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerGroupDefinition.GetPayerGroupDefinitions_Class> GetPayerGroupDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERGROUPDEFINITION"].QueryDefs["GetPayerGroupDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerGroupDefinition.GetPayerGroupDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected PayerGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERGROUPDEFINITION", dataRow) { }
        protected PayerGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERGROUPDEFINITION", dataRow, isImported) { }
        protected PayerGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerGroupDefinition() : base() { }

    }
}