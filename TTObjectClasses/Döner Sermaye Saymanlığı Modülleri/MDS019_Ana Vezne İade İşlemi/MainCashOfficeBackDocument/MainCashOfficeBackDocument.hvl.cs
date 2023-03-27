
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficeBackDocument")] 

    /// <summary>
    /// Vezne İade Dökümanı
    /// </summary>
    public  partial class MainCashOfficeBackDocument : AccountDocument
    {
        public class MainCashOfficeBackDocumentList : TTObjectCollection<MainCashOfficeBackDocument> { }
                    
        public class ChildMainCashOfficeBackDocumentCollection : TTObject.TTChildObjectCollection<MainCashOfficeBackDocument>
        {
            public ChildMainCashOfficeBackDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficeBackDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("c583c05b-3f50-4136-85fd-8efba7fe29bb"); } }
            public static Guid New { get { return new Guid("53b1385e-f52f-47aa-8303-f17271d85724"); } }
            public static Guid Paid { get { return new Guid("5142ccf8-db0e-45f6-8110-ce181acc74e1"); } }
        }

    /// <summary>
    /// Özel No
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

    /// <summary>
    /// Para İade Türleriyle İlişki
    /// </summary>
        public MainCashOfficeBackTypeDefinition MoneyBackType
        {
            get { return (MainCashOfficeBackTypeDefinition)((ITTObject)this).GetParent("MONEYBACKTYPE"); }
            set { this["MONEYBACKTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Banka Hesap Numarasıyla İlişki
    /// </summary>
        public BankAccountDefinition BankAccount
        {
            get { return (BankAccountDefinition)((ITTObject)this).GetParent("BANKACCOUNT"); }
            set { this["BANKACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bankadan İade Hesap Numarasıyla İlişki
    /// </summary>
        public BankAccountDefinition BackBankAccount
        {
            get { return (BankAccountDefinition)((ITTObject)this).GetParent("BACKBANKACCOUNT"); }
            set { this["BACKBANKACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMainCashOfficeBackOperationCollection()
        {
            _MainCashOfficeBackOperation = new MainCashOfficeBackOperation.ChildMainCashOfficeBackOperationCollection(this, new Guid("39430b4e-b63f-45b4-88d8-08688d3682f8"));
            ((ITTChildObjectCollection)_MainCashOfficeBackOperation).GetChildren();
        }

        protected MainCashOfficeBackOperation.ChildMainCashOfficeBackOperationCollection _MainCashOfficeBackOperation = null;
    /// <summary>
    /// Child collection for Vezne İade Dökümanıyla İlişki
    /// </summary>
        public MainCashOfficeBackOperation.ChildMainCashOfficeBackOperationCollection MainCashOfficeBackOperation
        {
            get
            {
                if (_MainCashOfficeBackOperation == null)
                    CreateMainCashOfficeBackOperationCollection();
                return _MainCashOfficeBackOperation;
            }
        }

        protected MainCashOfficeBackDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficeBackDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficeBackDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficeBackDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficeBackDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEBACKDOCUMENT", dataRow) { }
        protected MainCashOfficeBackDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEBACKDOCUMENT", dataRow, isImported) { }
        public MainCashOfficeBackDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficeBackDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficeBackDocument() : base() { }

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