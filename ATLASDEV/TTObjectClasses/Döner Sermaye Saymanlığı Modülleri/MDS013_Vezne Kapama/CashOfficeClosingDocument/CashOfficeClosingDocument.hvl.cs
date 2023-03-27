
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeClosingDocument")] 

    /// <summary>
    /// Vezne Kapama Dökümanı 
    /// </summary>
    public  partial class CashOfficeClosingDocument : AccountDocument
    {
        public class CashOfficeClosingDocumentList : TTObjectCollection<CashOfficeClosingDocument> { }
                    
        public class ChildCashOfficeClosingDocumentCollection : TTObject.TTChildObjectCollection<CashOfficeClosingDocument>
        {
            public ChildCashOfficeClosingDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeClosingDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("dd723c3e-1fe9-4fdd-9503-0e19df187bf0"); } }
            public static Guid Submitted { get { return new Guid("86fd2e73-cfba-46a5-bc33-33f81c4dc357"); } }
        }

    /// <summary>
    /// Özel No
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

    /// <summary>
    /// Banka Hesap Numarası
    /// </summary>
        public BankAccountDefinition BankAccount
        {
            get { return (BankAccountDefinition)((ITTObject)this).GetParent("BANKACCOUNT"); }
            set { this["BANKACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCashOfficeClosingCollection()
        {
            _CashOfficeClosing = new CashOfficeClosing.ChildCashOfficeClosingCollection(this, new Guid("1029d8d1-04bb-470e-93e4-00b5f516c0e1"));
            ((ITTChildObjectCollection)_CashOfficeClosing).GetChildren();
        }

        protected CashOfficeClosing.ChildCashOfficeClosingCollection _CashOfficeClosing = null;
    /// <summary>
    /// Child collection for Vezne Kapama Dökümanı ile ilişki
    /// </summary>
        public CashOfficeClosing.ChildCashOfficeClosingCollection CashOfficeClosing
        {
            get
            {
                if (_CashOfficeClosing == null)
                    CreateCashOfficeClosingCollection();
                return _CashOfficeClosing;
            }
        }

        protected CashOfficeClosingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeClosingDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeClosingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeClosingDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeClosingDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICECLOSINGDOCUMENT", dataRow) { }
        protected CashOfficeClosingDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICECLOSINGDOCUMENT", dataRow, isImported) { }
        public CashOfficeClosingDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeClosingDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeClosingDocument() : base() { }

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