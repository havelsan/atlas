
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceLog")] 

    /// <summary>
    /// Fatura Ekranı Logları
    /// </summary>
    public  partial class InvoiceLog : TTObject
    {
        public class InvoiceLogList : TTObjectCollection<InvoiceLog> { }
                    
        public class ChildInvoiceLogCollection : TTObject.TTChildObjectCollection<InvoiceLog>
        {
            public ChildInvoiceLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceLog_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Mtype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MTYPE"]);
                }
            }

            public InvoiceLogTypeEnum? Mtypeenum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTYPEENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["MESSAGETYPE"].DataType;
                    return (InvoiceLogTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Optype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OPTYPE"]);
                }
            }

            public InvoiceOperationTypeEnum? Optypeenum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPTYPEENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["OPERATIONTYPE"].DataType;
                    return (InvoiceOperationTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceLog_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceLog_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceLog_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedulaInvoiceLogs_Class : TTReportNqlObject 
        {
            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Mtype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MTYPE"]);
                }
            }

            public Object Optype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OPTYPE"]);
                }
            }

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaInvoiceLogs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaInvoiceLogs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaInvoiceLogs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAccTrxLogs_Class : TTReportNqlObject 
        {
            public DateTime? Logdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Patientuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Acctrxid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTTRANSACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Acctrxcodename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACCTRXCODENAME"]);
                }
            }

            public APRTypeEnum? Acctrxtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTPAYABLERECEIVABLE"].AllPropertyDefs["TYPE"].DataType;
                    return (APRTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string OldValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["OLDVALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NewValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].AllPropertyDefs["NEWVALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAccTrxLogs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccTrxLogs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccTrxLogs_Class() : base() { }
        }

        public static BindingList<InvoiceLog.GetInvoiceLog_Class> GetInvoiceLog(Guid KEY, InvoiceLogObjectTypeEnum TYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetInvoiceLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KEY", KEY);
            paramList.Add("TYPE", (int)TYPE);

            return TTReportNqlObject.QueryObjects<InvoiceLog.GetInvoiceLog_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceLog.GetInvoiceLog_Class> GetInvoiceLog(TTObjectContext objectContext, Guid KEY, InvoiceLogObjectTypeEnum TYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetInvoiceLog"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("KEY", KEY);
            paramList.Add("TYPE", (int)TYPE);

            return TTReportNqlObject.QueryObjects<InvoiceLog.GetInvoiceLog_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceLog.GetMedulaInvoiceLogs_Class> GetMedulaInvoiceLogs(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetMedulaInvoiceLogs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InvoiceLog.GetMedulaInvoiceLogs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceLog.GetMedulaInvoiceLogs_Class> GetMedulaInvoiceLogs(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetMedulaInvoiceLogs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InvoiceLog.GetMedulaInvoiceLogs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceLog> GetInvoiceLogObject(TTObjectContext objectContext, InvoiceLogObjectTypeEnum TYPE, Guid KEY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetInvoiceLogObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPE", (int)TYPE);
            paramList.Add("KEY", KEY);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceLog>(queryDef, paramList);
        }

        public static BindingList<InvoiceLog.GetAccTrxLogs_Class> GetAccTrxLogs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetAccTrxLogs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceLog.GetAccTrxLogs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceLog.GetAccTrxLogs_Class> GetAccTrxLogs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICELOG"].QueryDefs["GetAccTrxLogs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceLog.GetAccTrxLogs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İşlem Türü
    /// </summary>
        public InvoiceOperationTypeEnum? OperationType
        {
            get { return (InvoiceOperationTypeEnum?)(int?)this["OPERATIONTYPE"]; }
            set { this["OPERATIONTYPE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
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
    /// Mesaj Tipi
    /// </summary>
        public InvoiceLogTypeEnum? MessageType
        {
            get { return (InvoiceLogTypeEnum?)(int?)this["MESSAGETYPE"]; }
            set { this["MESSAGETYPE"] = value; }
        }

        public Guid? ObjectPrimaryKey
        {
            get { return (Guid?)this["OBJECTPRIMARYKEY"]; }
            set { this["OBJECTPRIMARYKEY"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public InvoiceLogObjectTypeEnum? ObjectType
        {
            get { return (InvoiceLogObjectTypeEnum?)(int?)this["OBJECTTYPE"]; }
            set { this["OBJECTTYPE"] = value; }
        }

        public string OldValue
        {
            get { return (string)this["OLDVALUE"]; }
            set { this["OLDVALUE"] = value; }
        }

        public string NewValue
        {
            get { return (string)this["NEWVALUE"]; }
            set { this["NEWVALUE"] = value; }
        }

    /// <summary>
    /// Kullanıcı Bağlantısı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SEPDiagnosis SEPDiagnosis
        {
            get { return (SEPDiagnosis)((ITTObject)this).GetParent("SEPDIAGNOSIS"); }
            set { this["SEPDIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisodeProtocol SubEpisodeProtocol
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SUBEPISODEPROTOCOL"); }
            set { this["SUBEPISODEPROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoiceLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICELOG", dataRow) { }
        protected InvoiceLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICELOG", dataRow, isImported) { }
        public InvoiceLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceLog() : base() { }

    }
}