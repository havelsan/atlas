
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSChartOfAccounts")] 

    /// <summary>
    /// Hesap Planı
    /// </summary>
    public  partial class MhSChartOfAccounts : TTObject
    {
        public class MhSChartOfAccountsList : TTObjectCollection<MhSChartOfAccounts> { }
                    
        public class ChildMhSChartOfAccountsCollection : TTObject.TTChildObjectCollection<MhSChartOfAccounts>
        {
            public ChildMhSChartOfAccountsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSChartOfAccountsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("b3f7a963-e624-4f8e-8fdc-19e12ca04a20"); } }
            public static Guid Completed { get { return new Guid("2827b1d5-a864-47df-a3bf-76aee7fdc418"); } }
            public static Guid Saved { get { return new Guid("6af0d22b-5486-42c1-b425-f0fb90b30591"); } }
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
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Örnek Mi?
    /// </summary>
        public bool? IsTemplate
        {
            get { return (bool?)this["ISTEMPLATE"]; }
            set { this["ISTEMPLATE"] = value; }
        }

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Firma
    /// </summary>
        public MhSFirm Firm
        {
            get { return (MhSFirm)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountsCollection()
        {
            _Accounts = new MhSAccount.ChildMhSAccountCollection(this, new Guid("58059c9e-e0e1-422f-b27a-3708717b80fd"));
            ((ITTChildObjectCollection)_Accounts).GetChildren();
        }

        protected MhSAccount.ChildMhSAccountCollection _Accounts = null;
    /// <summary>
    /// Child collection for Hesap Planı
    /// </summary>
        public MhSAccount.ChildMhSAccountCollection Accounts
        {
            get
            {
                if (_Accounts == null)
                    CreateAccountsCollection();
                return _Accounts;
            }
        }

        protected MhSChartOfAccounts(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSChartOfAccounts(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSChartOfAccounts(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSChartOfAccounts(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSChartOfAccounts(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSCHARTOFACCOUNTS", dataRow) { }
        protected MhSChartOfAccounts(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSCHARTOFACCOUNTS", dataRow, isImported) { }
        public MhSChartOfAccounts(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSChartOfAccounts(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSChartOfAccounts() : base() { }

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