
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficeBackOperation")] 

    /// <summary>
    /// Vezne İade İşlemi
    /// </summary>
    public  partial class MainCashOfficeBackOperation : AccountAction, IWorkListBaseAction
    {
        public class MainCashOfficeBackOperationList : TTObjectCollection<MainCashOfficeBackOperation> { }
                    
        public class ChildMainCashOfficeBackOperationCollection : TTObject.TTChildObjectCollection<MainCashOfficeBackOperation>
        {
            public ChildMainCashOfficeBackOperationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficeBackOperationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class BankDeliveryReportQuery_Class : TTReportNqlObject 
        {
            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SpecialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AccountNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].AllPropertyDefs["ACCOUNTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bankbranchname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BANKBRANCHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bankname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BANKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cashiername
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKOPERATION"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BankDeliveryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public BankDeliveryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected BankDeliveryReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("6af8af34-93a1-4cb3-a381-04661261db33"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("50ccb0ee-f543-44e0-8256-214cec3f5a89"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("4a92cee5-b81a-470a-9dfc-3647e3293775"); } }
        }

        public static BindingList<MainCashOfficeBackOperation.BankDeliveryReportQuery_Class> BankDeliveryReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKOPERATION"].QueryDefs["BankDeliveryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MainCashOfficeBackOperation.BankDeliveryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainCashOfficeBackOperation.BankDeliveryReportQuery_Class> BankDeliveryReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEBACKOPERATION"].QueryDefs["BankDeliveryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MainCashOfficeBackOperation.BankDeliveryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Vezne İade Dökümanıyla İlişki
    /// </summary>
        public MainCashOfficeBackDocument MainCashOfficeBackDocument
        {
            get { return (MainCashOfficeBackDocument)((ITTObject)this).GetParent("MAINCASHOFFICEBACKDOCUMENT"); }
            set { this["MAINCASHOFFICEBACKDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("765b9e74-7804-4740-b160-6238d64ebf6a"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected MainCashOfficeBackOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficeBackOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficeBackOperation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficeBackOperation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficeBackOperation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEBACKOPERATION", dataRow) { }
        protected MainCashOfficeBackOperation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEBACKOPERATION", dataRow, isImported) { }
        public MainCashOfficeBackOperation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficeBackOperation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficeBackOperation() : base() { }

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