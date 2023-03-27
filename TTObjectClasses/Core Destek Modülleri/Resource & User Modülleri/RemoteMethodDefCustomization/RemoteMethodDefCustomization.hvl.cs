
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RemoteMethodDefCustomization")] 

    public  partial class RemoteMethodDefCustomization : TerminologyManagerDef
    {
        public class RemoteMethodDefCustomizationList : TTObjectCollection<RemoteMethodDefCustomization> { }
                    
        public class ChildRemoteMethodDefCustomizationCollection : TTObject.TTChildObjectCollection<RemoteMethodDefCustomization>
        {
            public ChildRemoteMethodDefCustomizationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRemoteMethodDefCustomizationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRemoteMethodDefCustomizationDefinitionRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? IsSendingStartStop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDINGSTARTSTOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REMOTEMETHODDEFCUSTOMIZATION"].AllPropertyDefs["ISSENDINGSTARTSTOP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsKeepCompleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISKEEPCOMPLETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REMOTEMETHODDEFCUSTOMIZATION"].AllPropertyDefs["ISKEEPCOMPLETED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? RemoteMethodDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REMOTEMETHODDEFID"]);
                }
            }

            public string RemoteMethodDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMOTEMETHODDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REMOTEMETHODDEFCUSTOMIZATION"].AllPropertyDefs["REMOTEMETHODDEFNAME"].DataType;
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

            public GetRemoteMethodDefCustomizationDefinitionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRemoteMethodDefCustomizationDefinitionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRemoteMethodDefCustomizationDefinitionRQ_Class() : base() { }
        }

        public static BindingList<RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ_Class> GetRemoteMethodDefCustomizationDefinitionRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REMOTEMETHODDEFCUSTOMIZATION"].QueryDefs["GetRemoteMethodDefCustomizationDefinitionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ_Class> GetRemoteMethodDefCustomizationDefinitionRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REMOTEMETHODDEFCUSTOMIZATION"].QueryDefs["GetRemoteMethodDefCustomizationDefinitionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RemoteMethodDefCustomization.GetRemoteMethodDefCustomizationDefinitionRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string RemoteMethodDefName
        {
            get { return (string)this["REMOTEMETHODDEFNAME"]; }
            set { this["REMOTEMETHODDEFNAME"] = value; }
        }

        public bool? IsKeepCompleted
        {
            get { return (bool?)this["ISKEEPCOMPLETED"]; }
            set { this["ISKEEPCOMPLETED"] = value; }
        }

        public Guid? RemoteMethodDefID
        {
            get { return (Guid?)this["REMOTEMETHODDEFID"]; }
            set { this["REMOTEMETHODDEFID"] = value; }
        }

        public bool? IsSendingStartStop
        {
            get { return (bool?)this["ISSENDINGSTARTSTOP"]; }
            set { this["ISSENDINGSTARTSTOP"] = value; }
        }

        public DateTime? SendingEndTime
        {
            get { return (DateTime?)this["SENDINGENDTIME"]; }
            set { this["SENDINGENDTIME"] = value; }
        }

        public DateTime? SendingStartTime
        {
            get { return (DateTime?)this["SENDINGSTARTTIME"]; }
            set { this["SENDINGSTARTTIME"] = value; }
        }

        public int? KeepDays
        {
            get { return (int?)this["KEEPDAYS"]; }
            set { this["KEEPDAYS"] = value; }
        }

        virtual protected void CreateMessageQueueIterationsCollection()
        {
            _MessageQueueIterations = new RemoteMethodDefIteration.ChildRemoteMethodDefIterationCollection(this, new Guid("3a925818-185d-42d9-b420-355d5a889d47"));
            ((ITTChildObjectCollection)_MessageQueueIterations).GetChildren();
        }

        protected RemoteMethodDefIteration.ChildRemoteMethodDefIterationCollection _MessageQueueIterations = null;
        public RemoteMethodDefIteration.ChildRemoteMethodDefIterationCollection MessageQueueIterations
        {
            get
            {
                if (_MessageQueueIterations == null)
                    CreateMessageQueueIterationsCollection();
                return _MessageQueueIterations;
            }
        }

        protected RemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RemoteMethodDefCustomization(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REMOTEMETHODDEFCUSTOMIZATION", dataRow) { }
        protected RemoteMethodDefCustomization(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REMOTEMETHODDEFCUSTOMIZATION", dataRow, isImported) { }
        public RemoteMethodDefCustomization(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RemoteMethodDefCustomization(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RemoteMethodDefCustomization() : base() { }

    }
}