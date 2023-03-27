
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptBackDocument")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Dökümanı
    /// </summary>
    public  partial class ReceiptBackDocument : AccountDocument
    {
        public class ReceiptBackDocumentList : TTObjectCollection<ReceiptBackDocument> { }
                    
        public class ChildReceiptBackDocumentCollection : TTObject.TTChildObjectCollection<ReceiptBackDocument>
        {
            public ChildReceiptBackDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptBackDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("ecd17ce9-13f0-4764-ba58-48fe6208c2df"); } }
            public static Guid New { get { return new Guid("2423f2c7-2ad1-4073-a8b0-7a67f18fefb4"); } }
            public static Guid Paid { get { return new Guid("9546bdf8-1338-4f72-993d-add6358ec381"); } }
        }

    /// <summary>
    /// Saymanlıktan iade
    /// </summary>
        public bool? AccountantShipBack
        {
            get { return (bool?)this["ACCOUNTANTSHIPBACK"]; }
            set { this["ACCOUNTANTSHIPBACK"] = value; }
        }

    /// <summary>
    /// Bankadan İade Hesap Numarasıyla İlişki
    /// </summary>
        public BankAccountDefinition BackBankAccount
        {
            get { return (BankAccountDefinition)((ITTObject)this).GetParent("BACKBANKACCOUNT"); }
            set { this["BACKBANKACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReceiptBackCollection()
        {
            _ReceiptBack = new ReceiptBack.ChildReceiptBackCollection(this, new Guid("4d0a5852-b51a-4631-adf5-28549b7d03bc"));
            ((ITTChildObjectCollection)_ReceiptBack).GetChildren();
        }

        protected ReceiptBack.ChildReceiptBackCollection _ReceiptBack = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı İade Dökümanıyla ilişki
    /// </summary>
        public ReceiptBack.ChildReceiptBackCollection ReceiptBack
        {
            get
            {
                if (_ReceiptBack == null)
                    CreateReceiptBackCollection();
                return _ReceiptBack;
            }
        }

        protected ReceiptBackDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptBackDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptBackDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptBackDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptBackDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTBACKDOCUMENT", dataRow) { }
        protected ReceiptBackDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTBACKDOCUMENT", dataRow, isImported) { }
        public ReceiptBackDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptBackDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptBackDocument() : base() { }

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