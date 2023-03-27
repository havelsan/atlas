
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresReturningDocument")] 

    /// <summary>
    /// İade Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresReturningDocument : ReturningDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IReturningDocument, IStockTransferTransaction, IBasePrescriptionTransaction
    {
        public class PresReturningDocumentList : TTObjectCollection<PresReturningDocument> { }
                    
        public class ChildPresReturningDocumentCollection : TTObject.TTChildObjectCollection<PresReturningDocument>
        {
            public ChildPresReturningDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresReturningDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("8591d5e5-e024-4adf-8894-abe15b3a7ddc"); } }
            public static Guid Cancelled { get { return new Guid("faf0765f-80d7-4a86-a43a-ac23e036eb9c"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("ee5d31bc-387a-4c0e-89d9-8a2fde003a32"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("96433b71-3d30-4b00-a376-9b9c60e7ff6b"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresReturningDocumentMaterials = new PresReturningDocMaterial.ChildPresReturningDocMaterialCollection(_StockActionDetails, "PresReturningDocumentMaterials");
        }

        private PresReturningDocMaterial.ChildPresReturningDocMaterialCollection _PresReturningDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresReturningDocMaterial.ChildPresReturningDocMaterialCollection PresReturningDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresReturningDocumentMaterials;
            }            
        }

        protected PresReturningDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresReturningDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresReturningDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresReturningDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresReturningDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESRETURNINGDOCUMENT", dataRow) { }
        protected PresReturningDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESRETURNINGDOCUMENT", dataRow, isImported) { }
        public PresReturningDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresReturningDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresReturningDocument() : base() { }

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