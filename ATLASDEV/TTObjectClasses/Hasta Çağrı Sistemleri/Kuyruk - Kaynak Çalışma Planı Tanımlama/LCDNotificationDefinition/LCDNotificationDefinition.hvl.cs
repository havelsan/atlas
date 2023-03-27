
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LCDNotificationDefinition")] 

    /// <summary>
    /// LCD Bilgilendirme Tanımları
    /// </summary>
    public  partial class LCDNotificationDefinition : TTDefinitionSet
    {
        public class LCDNotificationDefinitionList : TTObjectCollection<LCDNotificationDefinition> { }
                    
        public class ChildLCDNotificationDefinitionCollection : TTObject.TTChildObjectCollection<LCDNotificationDefinition>
        {
            public ChildLCDNotificationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLCDNotificationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class LCDNotificationDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Notification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LCDNOTIFICATIONDEFINITION"].AllPropertyDefs["NOTIFICATION"].DataType;
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

            public LCDNotificationDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LCDNotificationDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LCDNotificationDefinitionNQL_Class() : base() { }
        }

        public static BindingList<LCDNotificationDefinition.LCDNotificationDefinitionNQL_Class> LCDNotificationDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LCDNOTIFICATIONDEFINITION"].QueryDefs["LCDNotificationDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LCDNotificationDefinition.LCDNotificationDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LCDNotificationDefinition.LCDNotificationDefinitionNQL_Class> LCDNotificationDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LCDNOTIFICATIONDEFINITION"].QueryDefs["LCDNotificationDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LCDNotificationDefinition.LCDNotificationDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Notification
        {
            get { return (string)this["NOTIFICATION"]; }
            set { this["NOTIFICATION"] = value; }
        }

        protected LCDNotificationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LCDNotificationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LCDNotificationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LCDNotificationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LCDNotificationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LCDNOTIFICATIONDEFINITION", dataRow) { }
        protected LCDNotificationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LCDNOTIFICATIONDEFINITION", dataRow, isImported) { }
        public LCDNotificationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LCDNotificationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LCDNotificationDefinition() : base() { }

    }
}