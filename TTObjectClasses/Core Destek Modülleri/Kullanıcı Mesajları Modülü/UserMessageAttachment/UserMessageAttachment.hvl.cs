
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserMessageAttachment")] 

    public  partial class UserMessageAttachment : TTObject
    {
        public class UserMessageAttachmentList : TTObjectCollection<UserMessageAttachment> { }
                    
        public class ChildUserMessageAttachmentCollection : TTObject.TTChildObjectCollection<UserMessageAttachment>
        {
            public ChildUserMessageAttachmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserMessageAttachmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAttachments_Class : TTReportNqlObject 
        {
            public Guid? Attachmentid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ATTACHMENTID"]);
                }
            }

            public string Ekadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEATTACHMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAttachments_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAttachments_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAttachments_Class() : base() { }
        }

        public static BindingList<UserMessageAttachment.GetAttachments_Class> GetAttachments(Guid MESSAGEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEATTACHMENT"].QueryDefs["GetAttachments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MESSAGEID", MESSAGEID);

            return TTReportNqlObject.QueryObjects<UserMessageAttachment.GetAttachments_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessageAttachment.GetAttachments_Class> GetAttachments(TTObjectContext objectContext, Guid MESSAGEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEATTACHMENT"].QueryDefs["GetAttachments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MESSAGEID", MESSAGEID);

            return TTReportNqlObject.QueryObjects<UserMessageAttachment.GetAttachments_Class>(objectContext, queryDef, paramList, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public object Attachment
        {
            get { return (object)this["ATTACHMENT"]; }
            set { this["ATTACHMENT"] = value; }
        }

        public UserMessage UserMessage
        {
            get { return (UserMessage)((ITTObject)this).GetParent("USERMESSAGE"); }
            set { this["USERMESSAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserMessageAttachment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserMessageAttachment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserMessageAttachment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserMessageAttachment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserMessageAttachment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERMESSAGEATTACHMENT", dataRow) { }
        protected UserMessageAttachment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERMESSAGEATTACHMENT", dataRow, isImported) { }
        public UserMessageAttachment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserMessageAttachment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserMessageAttachment() : base() { }

    }
}