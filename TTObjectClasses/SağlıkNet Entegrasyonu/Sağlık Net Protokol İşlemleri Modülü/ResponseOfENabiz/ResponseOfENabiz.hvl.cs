
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResponseOfENabiz")] 

    public  partial class ResponseOfENabiz : TTObject
    {
        public class ResponseOfENabizList : TTObjectCollection<ResponseOfENabiz> { }
                    
        public class ChildResponseOfENabizCollection : TTObject.TTChildObjectCollection<ResponseOfENabiz>
        {
            public ChildResponseOfENabizCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResponseOfENabizCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetListOfError_Class : TTReportNqlObject 
        {
            public string ResponseCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].AllPropertyDefs["RESPONSECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Msg
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MSG"]);
                }
            }

            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetListOfError_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetListOfError_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetListOfError_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCountOfResponseData_Class : TTReportNqlObject 
        {
            public string PackageCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["PACKAGECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTOENABIZ"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GetCountOfResponseData_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountOfResponseData_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountOfResponseData_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLastResponseOfNabiz_Class : TTReportNqlObject 
        {
            public string ResponseCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].AllPropertyDefs["RESPONSECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResponseMessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSEMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].AllPropertyDefs["RESPONSEMESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].AllPropertyDefs["SENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetLastResponseOfNabiz_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLastResponseOfNabiz_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLastResponseOfNabiz_Class() : base() { }
        }

        public static BindingList<ResponseOfENabiz.GetListOfError_Class> GetListOfError(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetListOfError"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ResponseOfENabiz.GetListOfError_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResponseOfENabiz.GetListOfError_Class> GetListOfError(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetListOfError"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ResponseOfENabiz.GetListOfError_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResponseOfENabiz> GetResponseOfENabizWithErrorCodeAndDates(TTObjectContext objectContext, string ERRORCODE, DateTime FIRSTDATE, DateTime LASTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetResponseOfENabizWithErrorCodeAndDates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERRORCODE", ERRORCODE);
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return ((ITTQuery)objectContext).QueryObjects<ResponseOfENabiz>(queryDef, paramList);
        }

        public static BindingList<ResponseOfENabiz.GetCountOfResponseData_Class> GetCountOfResponseData(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetCountOfResponseData"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ResponseOfENabiz.GetCountOfResponseData_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResponseOfENabiz.GetCountOfResponseData_Class> GetCountOfResponseData(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetCountOfResponseData"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ResponseOfENabiz.GetCountOfResponseData_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResponseOfENabiz.GetLastResponseOfNabiz_Class> GetLastResponseOfNabiz(Guid SENDTOENABIZ, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetLastResponseOfNabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDTOENABIZ", SENDTOENABIZ);

            return TTReportNqlObject.QueryObjects<ResponseOfENabiz.GetLastResponseOfNabiz_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResponseOfENabiz.GetLastResponseOfNabiz_Class> GetLastResponseOfNabiz(TTObjectContext objectContext, Guid SENDTOENABIZ, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZ"].QueryDefs["GetLastResponseOfNabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SENDTOENABIZ", SENDTOENABIZ);

            return TTReportNqlObject.QueryObjects<ResponseOfENabiz.GetLastResponseOfNabiz_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gönderim yapıldığı tarih
    /// </summary>
        public DateTime? SendDate
        {
            get { return (DateTime?)this["SENDDATE"]; }
            set { this["SENDDATE"] = value; }
        }

        public string ResponseCode
        {
            get { return (string)this["RESPONSECODE"]; }
            set { this["RESPONSECODE"] = value; }
        }

        public string ResponseMessage
        {
            get { return (string)this["RESPONSEMESSAGE"]; }
            set { this["RESPONSEMESSAGE"] = value; }
        }

        public SendToENabiz SendToENabiz
        {
            get { return (SendToENabiz)((ITTObject)this).GetParent("SENDTOENABIZ"); }
            set { this["SENDTOENABIZ"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResponseOfENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResponseOfENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResponseOfENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResponseOfENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResponseOfENabiz(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPONSEOFENABIZ", dataRow) { }
        protected ResponseOfENabiz(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPONSEOFENABIZ", dataRow, isImported) { }
        public ResponseOfENabiz(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResponseOfENabiz(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResponseOfENabiz() : base() { }

    }
}