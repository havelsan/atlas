
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NeededDocument")] 

    /// <summary>
    /// İhalede Firmalardan İstenilen Gerekli Belgelerin Bilgilerini Tutan Sınıftır
    /// </summary>
    public  partial class NeededDocument : TTObject
    {
        public class NeededDocumentList : TTObjectCollection<NeededDocument> { }
                    
        public class ChildNeededDocumentCollection : TTObject.TTChildObjectCollection<NeededDocument>
        {
            public ChildNeededDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNeededDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("b6277067-d7fb-4298-a8e9-a0762b57e3c8"); } }
            public static Guid Cancelled { get { return new Guid("7aacefe9-581c-4641-baa5-efd98040db61"); } }
        }

    /// <summary>
    /// Döküman Adı
    /// </summary>
        public string DocName
        {
            get { return (string)this["DOCNAME"]; }
            set { this["DOCNAME"] = value; }
        }

    /// <summary>
    /// Zorunlu
    /// </summary>
        public bool? Mandatory
        {
            get { return (bool?)this["MANDATORY"]; }
            set { this["MANDATORY"] = value; }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchasingDocumentsForFirmsDefinition PurchasingDocsForFirmsDef
        {
            get { return (PurchasingDocumentsForFirmsDefinition)((ITTObject)this).GetParent("PURCHASINGDOCSFORFIRMSDEF"); }
            set { this["PURCHASINGDOCSFORFIRMSDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NeededDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NeededDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NeededDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NeededDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NeededDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NEEDEDDOCUMENT", dataRow) { }
        protected NeededDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NEEDEDDOCUMENT", dataRow, isImported) { }
        public NeededDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NeededDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NeededDocument() : base() { }

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