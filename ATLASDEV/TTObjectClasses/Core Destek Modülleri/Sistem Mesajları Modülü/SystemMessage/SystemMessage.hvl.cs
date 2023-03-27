
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SystemMessage")] 

    /// <summary>
    /// Sistem Mesajları Tanımı
    /// </summary>
    public  partial class SystemMessage : TerminologyManagerDef
    {
        public class SystemMessageList : TTObjectCollection<SystemMessage> { }
                    
        public class ChildSystemMessageCollection : TTObject.TTChildObjectCollection<SystemMessage>
        {
            public ChildSystemMessageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSystemMessageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSystemMessagesDefinition_Class : TTReportNqlObject 
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

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? MessageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].AllPropertyDefs["MESSAGECODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public SystemMessageTypeEnum? MessageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].AllPropertyDefs["MESSAGETYPE"].DataType;
                    return (SystemMessageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetSystemMessagesDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSystemMessagesDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSystemMessagesDefinition_Class() : base() { }
        }

        public static BindingList<SystemMessage> GetSystem_Message(TTObjectContext objectContext, int CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].QueryDefs["GetSystem_Message"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<SystemMessage>(queryDef, paramList);
        }

        public static BindingList<SystemMessage.GetSystemMessagesDefinition_Class> GetSystemMessagesDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].QueryDefs["GetSystemMessagesDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemMessage.GetSystemMessagesDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemMessage.GetSystemMessagesDefinition_Class> GetSystemMessagesDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].QueryDefs["GetSystemMessagesDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemMessage.GetSystemMessagesDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemMessage> GetSystemMessageByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMMESSAGE"].QueryDefs["GetSystemMessageByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SystemMessage>(queryDef, paramList);
        }

    /// <summary>
    /// Mesaj
    /// </summary>
        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

    /// <summary>
    /// Mesaj Kodu
    /// </summary>
        public TTSequence MessageCode
        {
            get { return GetSequence("MESSAGECODE"); }
        }

    /// <summary>
    /// Mesaj Tipi
    /// </summary>
        public SystemMessageTypeEnum? MessageType
        {
            get { return (SystemMessageTypeEnum?)(int?)this["MESSAGETYPE"]; }
            set { this["MESSAGETYPE"] = value; }
        }

        protected SystemMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SystemMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SystemMessage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SystemMessage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SystemMessage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSTEMMESSAGE", dataRow) { }
        protected SystemMessage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSTEMMESSAGE", dataRow, isImported) { }
        public SystemMessage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SystemMessage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SystemMessage() : base() { }

    }
}