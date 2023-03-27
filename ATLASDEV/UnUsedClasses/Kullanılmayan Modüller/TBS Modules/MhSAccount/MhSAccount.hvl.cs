
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSAccount")] 

    /// <summary>
    /// Hesap
    /// </summary>
    public  partial class MhSAccount : TTDefinitionSet
    {
        public class MhSAccountList : TTObjectCollection<MhSAccount> { }
                    
        public class ChildMhSAccountCollection : TTObject.TTChildObjectCollection<MhSAccount>
        {
            public ChildMhSAccountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSAccountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hesap Düzeyi
    /// </summary>
        public int? Level
        {
            get { return (int?)this["LEVEL"]; }
            set { this["LEVEL"] = value; }
        }

    /// <summary>
    /// Alacak Toplamı
    /// </summary>
        public double? Credit
        {
            get { return (double?)this["CREDIT"]; }
            set { this["CREDIT"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Borç Toplamı
    /// </summary>
        public double? Debit
        {
            get { return (double?)this["DEBIT"]; }
            set { this["DEBIT"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public MhSAccountTypes? Type
        {
            get { return (MhSAccountTypes?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Bakiye
    /// </summary>
        public double? Balance
        {
            get { return (double?)this["BALANCE"]; }
            set { this["BALANCE"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public int? ID
        {
            get { return (int?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Fiş Girişinde Kullanılabilirmi
    /// </summary>
        public bool? IsSelectable
        {
            get { return (bool?)this["ISSELECTABLE"]; }
            set { this["ISSELECTABLE"] = value; }
        }

    /// <summary>
    /// Birincil Grup
    /// </summary>
        public MhSAccountGroupDefinition Group1
        {
            get { return (MhSAccountGroupDefinition)((ITTObject)this).GetParent("GROUP1"); }
            set { this["GROUP1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dördüncül Grup
    /// </summary>
        public MhSAccountGroupDefinition Group4
        {
            get { return (MhSAccountGroupDefinition)((ITTObject)this).GetParent("GROUP4"); }
            set { this["GROUP4"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Üçüncül Grup
    /// </summary>
        public MhSAccountGroupDefinition Group3
        {
            get { return (MhSAccountGroupDefinition)((ITTObject)this).GetParent("GROUP3"); }
            set { this["GROUP3"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap Planı
    /// </summary>
        public MhSChartOfAccounts ChartOfAccounts
        {
            get { return (MhSChartOfAccounts)((ITTObject)this).GetParent("CHARTOFACCOUNTS"); }
            set { this["CHARTOFACCOUNTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Masraf Merkezi
    /// </summary>
        public MhSExpenseCenterDefinition ExpenceCenter
        {
            get { return (MhSExpenseCenterDefinition)((ITTObject)this).GetParent("EXPENCECENTER"); }
            set { this["EXPENCECENTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap Kuralları
    /// </summary>
        public MhSAcccountRule Account
        {
            get { return (MhSAcccountRule)((ITTObject)this).GetParent("ACCOUNT"); }
            set { this["ACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İkincil Grup
    /// </summary>
        public MhSAccountGroupDefinition Group2
        {
            get { return (MhSAccountGroupDefinition)((ITTObject)this).GetParent("GROUP2"); }
            set { this["GROUP2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Üst Hesap
    /// </summary>
        public MhSAccount ParentAccount
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("PARENTACCOUNT"); }
            set { this["PARENTACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBalanceStatusesCollection()
        {
            _BalanceStatuses = new MhSMonthlyBalance.ChildMhSMonthlyBalanceCollection(this, new Guid("3830a110-dd62-4cfc-83e2-6bb9f8fb71f6"));
            ((ITTChildObjectCollection)_BalanceStatuses).GetChildren();
        }

        protected MhSMonthlyBalance.ChildMhSMonthlyBalanceCollection _BalanceStatuses = null;
    /// <summary>
    /// Child collection for Bakiye Durumu
    /// </summary>
        public MhSMonthlyBalance.ChildMhSMonthlyBalanceCollection BalanceStatuses
        {
            get
            {
                if (_BalanceStatuses == null)
                    CreateBalanceStatusesCollection();
                return _BalanceStatuses;
            }
        }

        virtual protected void CreateRulesCollection()
        {
            _Rules = new MhSAccountAccountRules.ChildMhSAccountAccountRulesCollection(this, new Guid("1713ec41-bff7-4ccf-9ece-9b438d4367cc"));
            ((ITTChildObjectCollection)_Rules).GetChildren();
        }

        protected MhSAccountAccountRules.ChildMhSAccountAccountRulesCollection _Rules = null;
    /// <summary>
    /// Child collection for Hesap Kuralları
    /// </summary>
        public MhSAccountAccountRules.ChildMhSAccountAccountRulesCollection Rules
        {
            get
            {
                if (_Rules == null)
                    CreateRulesCollection();
                return _Rules;
            }
        }

        virtual protected void CreateChildAccountsCollection()
        {
            _ChildAccounts = new MhSAccount.ChildMhSAccountCollection(this, new Guid("31c3a73d-ff14-4186-9084-e63d93af91a9"));
            ((ITTChildObjectCollection)_ChildAccounts).GetChildren();
        }

        protected MhSAccount.ChildMhSAccountCollection _ChildAccounts = null;
    /// <summary>
    /// Child collection for Üst Hesap
    /// </summary>
        public MhSAccount.ChildMhSAccountCollection ChildAccounts
        {
            get
            {
                if (_ChildAccounts == null)
                    CreateChildAccountsCollection();
                return _ChildAccounts;
            }
        }

        protected MhSAccount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSAccount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSAccount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSAccount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSAccount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSACCOUNT", dataRow) { }
        protected MhSAccount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSACCOUNT", dataRow, isImported) { }
        public MhSAccount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSAccount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSAccount() : base() { }

    }
}