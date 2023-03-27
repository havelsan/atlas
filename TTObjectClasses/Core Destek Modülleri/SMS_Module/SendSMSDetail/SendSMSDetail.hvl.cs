
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSDetail")] 

    public  partial class SendSMSDetail : TTObject
    {
        public class SendSMSDetailList : TTObjectCollection<SendSMSDetail> { }
                    
        public class ChildSendSMSDetailCollection : TTObject.TTChildObjectCollection<SendSMSDetail>
        {
            public ChildSendSMSDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSMSLog_Class : TTReportNqlObject 
        {
            public string MessageText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGETEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDSMSMASTER"].AllPropertyDefs["MESSAGETEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Recipientfirstname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECIPIENTFIRSTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDSMSDETAIL"].AllPropertyDefs["FIRSTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Recipientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECIPIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDSMSDETAIL"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sendername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDSMSDETAIL"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Masterstatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERSTATUS"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public SMSTypeEnum? SMSType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDSMSMASTER"].AllPropertyDefs["SMSTYPE"].DataType;
                    return (SMSTypeEnum?)(int)dataType.ConvertValue(val);
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

            public GetSMSLog_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSMSLog_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSMSLog_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("e2b3cf60-e576-4962-b7b8-f133ed6fa933"); } }
    /// <summary>
    /// Gönderildi
    /// </summary>
            public static Guid Sent { get { return new Guid("28f76c63-cae2-4488-b327-db7b2063d930"); } }
    /// <summary>
    /// Gönderilemedi
    /// </summary>
            public static Guid NotSent { get { return new Guid("4d31710c-d482-444a-bc10-de6822e073e7"); } }
    /// <summary>
    /// Kişi Telefon Numrası Mevcut Değil
    /// </summary>
            public static Guid HasNoPhonenumber { get { return new Guid("4dc2d50c-e1ea-40b1-aa14-03e725545b72"); } }
    /// <summary>
    /// Numara Formatı Yanlış
    /// </summary>
            public static Guid IncorrectPhoneNumber { get { return new Guid("dcd13d23-0b2e-4687-bf8d-be28d6203d07"); } }
        }

    /// <summary>
    /// SMS Log
    /// </summary>
        public static BindingList<SendSMSDetail.GetSMSLog_Class> GetSMSLog(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDSMSDETAIL"].QueryDefs["GetSMSLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SendSMSDetail.GetSMSLog_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// SMS Log
    /// </summary>
        public static BindingList<SendSMSDetail.GetSMSLog_Class> GetSMSLog(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDSMSDETAIL"].QueryDefs["GetSMSLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SendSMSDetail.GetSMSLog_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Gönderilen Kişinin Adı
    /// </summary>
        public string FirstName
        {
            get { return (string)this["FIRSTNAME"]; }
            set { this["FIRSTNAME"] = value; }
        }

    /// <summary>
    /// Gönderilen Kişinin Soyadı
    /// </summary>
        public string SurName
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Gönderilen Telefon Numarası
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

        public SendSMSMaster SendSMSMaster
        {
            get { return (SendSMSMaster)((ITTObject)this).GetParent("SENDSMSMASTER"); }
            set { this["SENDSMSMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SMS Gönderen Kullanıcı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SMS Gönderilen Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SendSMSDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSDETAIL", dataRow) { }
        protected SendSMSDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSDETAIL", dataRow, isImported) { }
        public SendSMSDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSDetail() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}