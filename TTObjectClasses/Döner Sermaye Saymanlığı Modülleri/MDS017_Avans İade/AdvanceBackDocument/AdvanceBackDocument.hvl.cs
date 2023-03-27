
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceBackDocument")] 

    /// <summary>
    /// Avans İade Dökümanı
    /// </summary>
    public  partial class AdvanceBackDocument : AccountDocument
    {
        public class AdvanceBackDocumentList : TTObjectCollection<AdvanceBackDocument> { }
                    
        public class ChildAdvanceBackDocumentCollection : TTObject.TTChildObjectCollection<AdvanceBackDocument>
        {
            public ChildAdvanceBackDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceBackDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Paid { get { return new Guid("2b29e805-767d-4dc6-a9a0-0baef648656b"); } }
            public static Guid Cancelled { get { return new Guid("059d95cd-8da6-4446-9056-9dd43b4c4df2"); } }
            public static Guid New { get { return new Guid("4e838fb9-5d6f-42a4-b46b-700216472490"); } }
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
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
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

        virtual protected void CreateAdvanceBackCollection()
        {
            _AdvanceBack = new AdvanceBack.ChildAdvanceBackCollection(this, new Guid("6948ec71-e048-44eb-b9ad-65ac39375b35"));
            ((ITTChildObjectCollection)_AdvanceBack).GetChildren();
        }

        protected AdvanceBack.ChildAdvanceBackCollection _AdvanceBack = null;
    /// <summary>
    /// Child collection for Avans İade Dökümanıyla İlişkisi
    /// </summary>
        public AdvanceBack.ChildAdvanceBackCollection AdvanceBack
        {
            get
            {
                if (_AdvanceBack == null)
                    CreateAdvanceBackCollection();
                return _AdvanceBack;
            }
        }

        protected AdvanceBackDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceBackDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceBackDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceBackDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceBackDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEBACKDOCUMENT", dataRow) { }
        protected AdvanceBackDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEBACKDOCUMENT", dataRow, isImported) { }
        public AdvanceBackDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceBackDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceBackDocument() : base() { }

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