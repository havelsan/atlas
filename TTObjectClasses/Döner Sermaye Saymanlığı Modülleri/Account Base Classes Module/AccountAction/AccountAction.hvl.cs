
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountAction")] 

    /// <summary>
    /// Genel finansal işlemlerin ana sınıfıdır
    /// </summary>
    public  partial class AccountAction : BaseAction
    {
        public class AccountActionList : TTObjectCollection<AccountAction> { }
                    
        public class ChildAccountActionCollection : TTObject.TTChildObjectCollection<AccountAction>
        {
            public ChildAccountActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CashOfficeWorkListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Documentdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Currentstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CashOfficeWorkListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeWorkListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeWorkListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class CashOfficeWorkListNQLNoDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Documentdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Currentstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CashOfficeWorkListNQLNoDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeWorkListNQLNoDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeWorkListNQLNoDate_Class() : base() { }
        }

        public static BindingList<AccountAction.CashOfficeWorkListNQL_Class> CashOfficeWorkListNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountAction.CashOfficeWorkListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountAction.CashOfficeWorkListNQL_Class> CashOfficeWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<AccountAction.CashOfficeWorkListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountAction.CashOfficeWorkListNQLNoDate_Class> CashOfficeWorkListNQLNoDate(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQLNoDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountAction.CashOfficeWorkListNQLNoDate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AccountAction.CashOfficeWorkListNQLNoDate_Class> CashOfficeWorkListNQLNoDate(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTACTION"].QueryDefs["CashOfficeWorkListNQLNoDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AccountAction.CashOfficeWorkListNQLNoDate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Finansal İşlemin Toplam Tutarıdır
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Finansal İşlemi yapan Veznenin Adıdır
    /// </summary>
        public string CashOfficeName
        {
            get { return (string)this["CASHOFFICENAME"]; }
            set { this["CASHOFFICENAME"] = value; }
        }

    /// <summary>
    /// Finansal İşlemi yapan Veznenin Açıklamasıdır
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Oluşturma Tarihi
    /// </summary>
        public DateTime? CreateDate
        {
            get { return (DateTime?)this["CREATEDATE"]; }
            set { this["CREATEDATE"] = value; }
        }

        virtual protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("6ab177fe-9618-4e42-93f7-efbb00576c1e"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected AccountDocument.ChildAccountDocumentCollection _AccountDocuments = null;
    /// <summary>
    /// Child collection for Genel finansal işlemlerle ilişki
    /// </summary>
        public AccountDocument.ChildAccountDocumentCollection AccountDocuments
        {
            get
            {
                if (_AccountDocuments == null)
                    CreateAccountDocumentsCollection();
                return _AccountDocuments;
            }
        }

        protected AccountAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTACTION", dataRow) { }
        protected AccountAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTACTION", dataRow, isImported) { }
        protected AccountAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountAction() : base() { }

    }
}