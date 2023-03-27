
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentInputDetailWithAccountancy")] 

    public  partial class ChattelDocumentInputDetailWithAccountancy : StockActionDetailIn
    {
        public class ChattelDocumentInputDetailWithAccountancyList : TTObjectCollection<ChattelDocumentInputDetailWithAccountancy> { }
                    
        public class ChildChattelDocumentInputDetailWithAccountancyCollection : TTObject.TTChildObjectCollection<ChattelDocumentInputDetailWithAccountancy>
        {
            public ChildChattelDocumentInputDetailWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentInputDetailWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class : TTReportNqlObject 
        {
            public Object Stockactionobjectid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class() : base() { }
        }

        public static BindingList<ChattelDocumentInputDetailWithAccountancy.CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class> CensusReportNQL_ChatDocInputDetWithAccNoGAB(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY"].QueryDefs["CensusReportNQL_ChatDocInputDetWithAccNoGAB"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentInputDetailWithAccountancy.CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentInputDetailWithAccountancy.CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class> CensusReportNQL_ChatDocInputDetWithAccNoGAB(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY"].QueryDefs["CensusReportNQL_ChatDocInputDetWithAccNoGAB"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentInputDetailWithAccountancy.CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class>(objectContext, queryDef, paramList, pi);
        }

        public string ConflictSubject
        {
            get { return (string)this["CONFLICTSUBJECT"]; }
            set { this["CONFLICTSUBJECT"] = value; }
        }

        public Currency? SentAmount
        {
            get { return (Currency?)this["SENTAMOUNT"]; }
            set { this["SENTAMOUNT"] = value; }
        }

    /// <summary>
    /// Taşınır malın alındığı bayi
    /// </summary>
        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY", dataRow) { }
        protected ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY", dataRow, isImported) { }
        public ChattelDocumentInputDetailWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentInputDetailWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentInputDetailWithAccountancy() : base() { }

    }
}