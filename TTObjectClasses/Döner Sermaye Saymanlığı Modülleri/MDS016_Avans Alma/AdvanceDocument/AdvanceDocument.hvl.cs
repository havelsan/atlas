
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceDocument")] 

    /// <summary>
    /// Avans Alındısı
    /// </summary>
    public  partial class AdvanceDocument : AccountDocument
    {
        public class AdvanceDocumentList : TTObjectCollection<AdvanceDocument> { }
                    
        public class ChildAdvanceDocumentCollection : TTObject.TTChildObjectCollection<AdvanceDocument>
        {
            public ChildAdvanceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Paid { get { return new Guid("d2469264-3643-4ab1-982b-9bcf0f82d955"); } }
            public static Guid Cancelled { get { return new Guid("e8d5e9b4-27aa-46af-9a15-d220ebc48aab"); } }
            public static Guid New { get { return new Guid("4cede074-08ff-4693-bb36-d9db15156161"); } }
        }

    /// <summary>
    /// Kredi Kartı Alındısı Numarası
    /// </summary>
        public string CreditCardDocumentNo
        {
            get { return (string)this["CREDITCARDDOCUMENTNO"]; }
            set { this["CREDITCARDDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Parayı Teslim Eden Kişi
    /// </summary>
        public string PayeeName
        {
            get { return (string)this["PAYEENAME"]; }
            set { this["PAYEENAME"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısında Kullanılmış Avansı Gösterir
    /// </summary>
        public bool? Used
        {
            get { return (bool?)this["USED"]; }
            set { this["USED"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Özel Numara
    /// </summary>
        public TTSequence SpecialNo
        {
            get { return GetSequence("SPECIALNO"); }
        }

    /// <summary>
    /// Kredi Kartı Alındısı Özel Numarası
    /// </summary>
        public TTSequence CreditCardSpecialNo
        {
            get { return GetSequence("CREDITCARDSPECIALNO"); }
        }

    /// <summary>
    /// Hasta Numarası
    /// </summary>
        public long? PatientNo
        {
            get { return (long?)this["PATIENTNO"]; }
            set { this["PATIENTNO"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı Dökümanıyla İlişkisi
    /// </summary>
        public ReceiptDocument ReceiptDocument
        {
            get { return (ReceiptDocument)((ITTObject)this).GetParent("RECEIPTDOCUMENT"); }
            set { this["RECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatış işlemiyle ilişkisi
    /// </summary>
        public InpatientAdmission InpatientAdmission
        {
            get { return (InpatientAdmission)((ITTObject)this).GetParent("INPATIENTADMISSION"); }
            set { this["INPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BondDocument BondDocument
        {
            get { return (BondDocument)((ITTObject)this).GetParent("BONDDOCUMENT"); }
            set { this["BONDDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAdvanceCollection()
        {
            _Advance = new Advance.ChildAdvanceCollection(this, new Guid("25fa1b75-2e19-4f2f-ae4f-14ec41849d3f"));
            ((ITTChildObjectCollection)_Advance).GetChildren();
        }

        protected Advance.ChildAdvanceCollection _Advance = null;
    /// <summary>
    /// Child collection for Avans Alındısı İlişkisi
    /// </summary>
        public Advance.ChildAdvanceCollection Advance
        {
            get
            {
                if (_Advance == null)
                    CreateAdvanceCollection();
                return _Advance;
            }
        }

        protected AdvanceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEDOCUMENT", dataRow) { }
        protected AdvanceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEDOCUMENT", dataRow, isImported) { }
        public AdvanceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceDocument() : base() { }

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