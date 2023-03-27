
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResponseOfENabizWOSYS")] 

    /// <summary>
    /// Günde yada ayda bir kere çalışan systakip numarasından bağımsız paketlerin loglarının tutulduğu tablo
    /// </summary>
    public  partial class ResponseOfENabizWOSYS : TTObject
    {
        public class ResponseOfENabizWOSYSList : TTObjectCollection<ResponseOfENabizWOSYS> { }
                    
        public class ChildResponseOfENabizWOSYSCollection : TTObject.TTChildObjectCollection<ResponseOfENabizWOSYS>
        {
            public ChildResponseOfENabizWOSYSCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResponseOfENabizWOSYSCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDailyBasedResponseOfNabiz_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ResponseCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZWOSYS"].AllPropertyDefs["RESPONSECODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZWOSYS"].AllPropertyDefs["RESPONSEMESSAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZWOSYS"].AllPropertyDefs["SENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public SendToENabizEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZWOSYS"].AllPropertyDefs["STATUS"].DataType;
                    return (SendToENabizEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDailyBasedResponseOfNabiz_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDailyBasedResponseOfNabiz_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDailyBasedResponseOfNabiz_Class() : base() { }
        }

        public static BindingList<ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class> GetDailyBasedResponseOfNabiz(DateTime STARTDATE, DateTime ENDDATE, int PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZWOSYS"].QueryDefs["GetDailyBasedResponseOfNabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class> GetDailyBasedResponseOfNabiz(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, int PACKAGECODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPONSEOFENABIZWOSYS"].QueryDefs["GetDailyBasedResponseOfNabiz"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PACKAGECODE", PACKAGECODE);

            return TTReportNqlObject.QueryObjects<ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class>(objectContext, queryDef, paramList, pi);
        }

        public string PackageCode
        {
            get { return (string)this["PACKAGECODE"]; }
            set { this["PACKAGECODE"] = value; }
        }

        public SendToENabizEnum? Status
        {
            get { return (SendToENabizEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

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

        protected ResponseOfENabizWOSYS(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResponseOfENabizWOSYS(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResponseOfENabizWOSYS(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResponseOfENabizWOSYS(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResponseOfENabizWOSYS(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPONSEOFENABIZWOSYS", dataRow) { }
        protected ResponseOfENabizWOSYS(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPONSEOFENABIZWOSYS", dataRow, isImported) { }
        public ResponseOfENabizWOSYS(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResponseOfENabizWOSYS(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResponseOfENabizWOSYS() : base() { }

    }
}