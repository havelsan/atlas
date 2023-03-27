
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserMessage")] 

    /// <summary>
    /// Kullanıcı Mesajları
    /// </summary>
    public  partial class UserMessage : TTObject
    {
        public class UserMessageList : TTObjectCollection<UserMessage> { }
                    
        public class ChildUserMessageCollection : TTObject.TTChildObjectCollection<UserMessage>
        {
            public ChildUserMessageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserMessageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUserInboxMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MessageStatusEnum? Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["RECEIVERSTATUS"].DataType;
                    return (MessageStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Mesajgrubuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESAJGRUBUID"]);
                }
            }

            public string Mesajgrubuadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJGRUBUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUserInboxMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserInboxMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserInboxMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNewUserMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Acilismesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACILISMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSPLASHMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Panikmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANIKMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISPANICMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNewUserMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewUserMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewUserMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDraftUserMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MessageStatusEnum? Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SENDERSTATUS"].DataType;
                    return (MessageStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDraftUserMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDraftUserMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDraftUserMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSentItemsUserMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MessageStatusEnum? Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SENDERSTATUS"].DataType;
                    return (MessageStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? UserMessageID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USERMESSAGEID"]);
                }
            }

            public Guid? Grupid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GRUPID"]);
                }
            }

            public GetSentItemsUserMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSentItemsUserMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSentItemsUserMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnreadSysMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public MessageStatusEnum? Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["RECEIVERSTATUS"].DataType;
                    return (MessageStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnreadSysMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnreadSysMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnreadSysMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSentGroupItemsUserMessages_Class : TTReportNqlObject 
        {
            public string Subject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Grupid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GRUPID"]);
                }
            }

            public string Grupadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRUPADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEGROUPDEFINITION"].AllPropertyDefs["CAPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? UserMessageID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["USERMESSAGEID"]);
                }
            }

            public GetSentGroupItemsUserMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSentGroupItemsUserMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSentGroupItemsUserMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSentGroupMessage_Class : TTReportNqlObject 
        {
            public Object Grupmesajid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GRUPMESAJID"]);
                }
            }

            public GetSentGroupMessage_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSentGroupMessage_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSentGroupMessage_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnreadMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnreadMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnreadMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnreadMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSentGroupMessageDate_Class : TTReportNqlObject 
        {
            public Object Tarih
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TARIH"]);
                }
            }

            public GetSentGroupMessageDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSentGroupMessageDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSentGroupMessageDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDeletedItemsUserMessages_Class : TTReportNqlObject 
        {
            public Guid? Messageid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MESSAGEID"]);
                }
            }

            public bool? Sistemmesaji
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMMESAJI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["ISSYSTEMMESSAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object Mesaj
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESAJ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEBODY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["MESSAGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MessageStatusEnum? Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SENDERSTATUS"].DataType;
                    return (MessageStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Baslik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public Guid? Gonderenid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GONDERENID"]);
                }
            }

            public Guid? Kimeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KIMEID"]);
                }
            }

            public string Gonderenadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GONDERENADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kimeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Ek
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGEATTACHMENT"].AllPropertyDefs["ATTACHMENT"].DataType;
                    return (object)dataType.ConvertValue(val);
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

            public GetDeletedItemsUserMessages_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDeletedItemsUserMessages_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDeletedItemsUserMessages_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnreadMessagesCount_Class : TTReportNqlObject 
        {
            public Object Mesajsayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MESAJSAYISI"]);
                }
            }

            public GetUnreadMessagesCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnreadMessagesCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnreadMessagesCount_Class() : base() { }
        }

        public static BindingList<UserMessage.GetUserInboxMessages_Class> GetUserInboxMessages(string TOUSER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUserInboxMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUserInboxMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetUserInboxMessages_Class> GetUserInboxMessages(TTObjectContext objectContext, string TOUSER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUserInboxMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUserInboxMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetNewUserMessages_Class> GetNewUserMessages(string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetNewUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetNewUserMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetNewUserMessages_Class> GetNewUserMessages(TTObjectContext objectContext, string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetNewUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetNewUserMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetDraftUserMessages_Class> GetDraftUserMessages(string SENDER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetDraftUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetDraftUserMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetDraftUserMessages_Class> GetDraftUserMessages(TTObjectContext objectContext, string SENDER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetDraftUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetDraftUserMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentItemsUserMessages_Class> GetSentItemsUserMessages(string SENDER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentItemsUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentItemsUserMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentItemsUserMessages_Class> GetSentItemsUserMessages(TTObjectContext objectContext, string SENDER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentItemsUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentItemsUserMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetUnreadSysMessages_Class> GetUnreadSysMessages(string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUnreadSysMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUnreadSysMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetUnreadSysMessages_Class> GetUnreadSysMessages(TTObjectContext objectContext, string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUnreadSysMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUnreadSysMessages_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// OBJECTID ile get eder
    /// </summary>
        public static BindingList<UserMessage> GetUserMessageByID(TTObjectContext objectContext, string OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUserMessageByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<UserMessage>(queryDef, paramList);
        }

        public static BindingList<UserMessage.GetSentGroupItemsUserMessages_Class> GetSentGroupItemsUserMessages(string SENDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentGroupItemsUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentGroupItemsUserMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentGroupItemsUserMessages_Class> GetSentGroupItemsUserMessages(TTObjectContext objectContext, string SENDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentGroupItemsUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentGroupItemsUserMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentGroupMessage_Class> GetSentGroupMessage(string SENDER, string USERMESSAGEGROUP, string USERMESSAGEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentGroupMessage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("USERMESSAGEGROUP", USERMESSAGEGROUP);
            paramList.Add("USERMESSAGEID", USERMESSAGEID);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentGroupMessage_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentGroupMessage_Class> GetSentGroupMessage(TTObjectContext objectContext, string SENDER, string USERMESSAGEGROUP, string USERMESSAGEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentGroupMessage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("USERMESSAGEGROUP", USERMESSAGEGROUP);
            paramList.Add("USERMESSAGEID", USERMESSAGEID);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentGroupMessage_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage> GetUserMessageByToUser(TTObjectContext objectContext, string TOUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUserMessageByToUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return ((ITTQuery)objectContext).QueryObjects<UserMessage>(queryDef, paramList);
        }

        public static BindingList<UserMessage.GetUnreadMessages_Class> GetUnreadMessages(string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUnreadMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUnreadMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetUnreadMessages_Class> GetUnreadMessages(TTObjectContext objectContext, string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUnreadMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUnreadMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentGroupMessageDate_Class> GetSentGroupMessageDate(string SENDER, string USERMESSAGEGROUP, string USERMESSAGEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentGroupMessageDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("USERMESSAGEGROUP", USERMESSAGEGROUP);
            paramList.Add("USERMESSAGEID", USERMESSAGEID);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentGroupMessageDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetSentGroupMessageDate_Class> GetSentGroupMessageDate(TTObjectContext objectContext, string SENDER, string USERMESSAGEGROUP, string USERMESSAGEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetSentGroupMessageDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDER", SENDER);
            paramList.Add("USERMESSAGEGROUP", USERMESSAGEGROUP);
            paramList.Add("USERMESSAGEID", USERMESSAGEID);

            return TTReportNqlObject.QueryObjects<UserMessage.GetSentGroupMessageDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetDeletedItemsUserMessages_Class> GetDeletedItemsUserMessages(string USER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetDeletedItemsUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetDeletedItemsUserMessages_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetDeletedItemsUserMessages_Class> GetDeletedItemsUserMessages(TTObjectContext objectContext, string USER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetDeletedItemsUserMessages"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<UserMessage.GetDeletedItemsUserMessages_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetUnreadMessagesCount_Class> GetUnreadMessagesCount(string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUnreadMessagesCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUnreadMessagesCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UserMessage.GetUnreadMessagesCount_Class> GetUnreadMessagesCount(TTObjectContext objectContext, string TOUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["USERMESSAGE"].QueryDefs["GetUnreadMessagesCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TOUSER", TOUSER);

            return TTReportNqlObject.QueryObjects<UserMessage.GetUnreadMessagesCount_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Mesaj
    /// </summary>
        public object MessageBody
        {
            get { return (object)this["MESSAGEBODY"]; }
            set { this["MESSAGEBODY"] = value; }
        }

    /// <summary>
    /// Mesaj Tarihi
    /// </summary>
        public DateTime? MessageDate
        {
            get { return (DateTime?)this["MESSAGEDATE"]; }
            set { this["MESSAGEDATE"] = value; }
        }

    /// <summary>
    /// Sistem Mesajı
    /// </summary>
        public bool? IsSystemMessage
        {
            get { return (bool?)this["ISSYSTEMMESSAGE"]; }
            set { this["ISSYSTEMMESSAGE"] = value; }
        }

    /// <summary>
    /// Mesajın Durumu
    /// </summary>
        public MessageStatusEnum? ReceiverStatus
        {
            get { return (MessageStatusEnum?)(int?)this["RECEIVERSTATUS"]; }
            set { this["RECEIVERSTATUS"] = value; }
        }

    /// <summary>
    /// Başlık
    /// </summary>
        public string Subject
        {
            get { return (string)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Panik Bildirim Mesajı Mı
    /// </summary>
        public bool? IsPanicMessage
        {
            get { return (bool?)this["ISPANICMESSAGE"]; }
            set { this["ISPANICMESSAGE"] = value; }
        }

    /// <summary>
    /// Geçerlilik Bitiş Tarihi
    /// </summary>
        public DateTime? ExpireDate
        {
            get { return (DateTime?)this["EXPIREDATE"]; }
            set { this["EXPIREDATE"] = value; }
        }

    /// <summary>
    /// Mesajdan sonra hasta dosyası açılacak mı?
    /// </summary>
        public bool? OpenForm
        {
            get { return (bool?)this["OPENFORM"]; }
            set { this["OPENFORM"] = value; }
        }

    /// <summary>
    /// Splah Mesaj
    /// </summary>
        public bool? IsSplashMessage
        {
            get { return (bool?)this["ISSPLASHMESSAGE"]; }
            set { this["ISSPLASHMESSAGE"] = value; }
        }

    /// <summary>
    /// Mesaj Geribildirimi
    /// </summary>
        public bool? MessageFeedback
        {
            get { return (bool?)this["MESSAGEFEEDBACK"]; }
            set { this["MESSAGEFEEDBACK"] = value; }
        }

    /// <summary>
    /// User Message ID
    /// </summary>
        public Guid? UserMessageID
        {
            get { return (Guid?)this["USERMESSAGEID"]; }
            set { this["USERMESSAGEID"] = value; }
        }

    /// <summary>
    /// Report Def ID
    /// </summary>
        public Guid? ReportDefID
        {
            get { return (Guid?)this["REPORTDEFID"]; }
            set { this["REPORTDEFID"] = value; }
        }

    /// <summary>
    /// Mesajın Durumu
    /// </summary>
        public MessageStatusEnum? SenderStatus
        {
            get { return (MessageStatusEnum?)(int?)this["SENDERSTATUS"]; }
            set { this["SENDERSTATUS"] = value; }
        }

    /// <summary>
    /// Kimden
    /// </summary>
        public ResUser Sender
        {
            get { return (ResUser)((ITTObject)this).GetParent("SENDER"); }
            set { this["SENDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kime
    /// </summary>
        public ResUser ToUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("TOUSER"); }
            set { this["TOUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Grup
    /// </summary>
        public UserMessageGroupDefinition UserMessageGroup
        {
            get { return (UserMessageGroupDefinition)((ITTObject)this).GetParent("USERMESSAGEGROUP"); }
            set { this["USERMESSAGEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseAction BaseAction
        {
            get { return (BaseAction)((ITTObject)this).GetParent("BASEACTION"); }
            set { this["BASEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure SubAction
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTION"); }
            set { this["SUBACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAttachmentsCollection()
        {
            _Attachments = new UserMessageAttachment.ChildUserMessageAttachmentCollection(this, new Guid("52847eb9-cf5b-41fe-916a-373faeedf912"));
            ((ITTChildObjectCollection)_Attachments).GetChildren();
        }

        protected UserMessageAttachment.ChildUserMessageAttachmentCollection _Attachments = null;
        public UserMessageAttachment.ChildUserMessageAttachmentCollection Attachments
        {
            get
            {
                if (_Attachments == null)
                    CreateAttachmentsCollection();
                return _Attachments;
            }
        }

        protected UserMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserMessage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserMessage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserMessage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserMessage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERMESSAGE", dataRow) { }
        protected UserMessage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERMESSAGE", dataRow, isImported) { }
        public UserMessage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserMessage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserMessage() : base() { }

    }
}