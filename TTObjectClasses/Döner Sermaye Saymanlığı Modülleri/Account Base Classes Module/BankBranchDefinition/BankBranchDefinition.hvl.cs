
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BankBranchDefinition")] 

    /// <summary>
    /// Banka Şube Tanımı
    /// </summary>
    public  partial class BankBranchDefinition : TTDefinitionSet
    {
        public class BankBranchDefinitionList : TTObjectCollection<BankBranchDefinition> { }
                    
        public class ChildBankBranchDefinitionCollection : TTObject.TTChildObjectCollection<BankBranchDefinition>
        {
            public ChildBankBranchDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBankBranchDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBankBranchDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBankBranchDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBankBranchDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBankBranchDefinitions_Class() : base() { }
        }

        public static BindingList<BankBranchDefinition.GetBankBranchDefinitions_Class> GetBankBranchDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].QueryDefs["GetBankBranchDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BankBranchDefinition.GetBankBranchDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BankBranchDefinition.GetBankBranchDefinitions_Class> GetBankBranchDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].QueryDefs["GetBankBranchDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BankBranchDefinition.GetBankBranchDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Banka Şube İlişkisi
    /// </summary>
        public BankDefinition Bank
        {
            get { return (BankDefinition)((ITTObject)this).GetParent("BANK"); }
            set { this["BANK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBankAccountsCollection()
        {
            _BankAccounts = new BankAccountDefinition.ChildBankAccountDefinitionCollection(this, new Guid("bcd8752c-78ba-46ce-b917-3f611ed3a8fe"));
            ((ITTChildObjectCollection)_BankAccounts).GetChildren();
        }

        protected BankAccountDefinition.ChildBankAccountDefinitionCollection _BankAccounts = null;
    /// <summary>
    /// Child collection for Şube Hesap İlişkisi
    /// </summary>
        public BankAccountDefinition.ChildBankAccountDefinitionCollection BankAccounts
        {
            get
            {
                if (_BankAccounts == null)
                    CreateBankAccountsCollection();
                return _BankAccounts;
            }
        }

        protected BankBranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BankBranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BankBranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BankBranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BankBranchDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BANKBRANCHDEFINITION", dataRow) { }
        protected BankBranchDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BANKBRANCHDEFINITION", dataRow, isImported) { }
        public BankBranchDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BankBranchDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BankBranchDefinition() : base() { }

    }
}