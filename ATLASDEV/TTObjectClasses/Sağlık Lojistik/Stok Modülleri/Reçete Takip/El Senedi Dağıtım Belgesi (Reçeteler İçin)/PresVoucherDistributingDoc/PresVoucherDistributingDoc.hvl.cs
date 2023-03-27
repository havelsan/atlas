
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresVoucherDistributingDoc")] 

    /// <summary>
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresVoucherDistributingDoc : VoucherDistributingDocument, IStockTransferTransaction, IVoucherDistributingDocument, IBasePrescriptionTransaction
    {
        public class PresVoucherDistributingDocList : TTObjectCollection<PresVoucherDistributingDoc> { }
                    
        public class ChildPresVoucherDistributingDocCollection : TTObject.TTChildObjectCollection<PresVoucherDistributingDoc>
        {
            public ChildPresVoucherDistributingDocCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresVoucherDistributingDocCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("e66fbb6e-f222-420e-88da-79f79ece8000"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f36f7707-fba4-45bf-be4a-42b7cbb4aed4"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("ed4199ce-c9ed-475b-b884-676ea6b441c3"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("005f75ea-3dcd-4268-81db-387a2b2bf262"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresVoucherDistDocMaterials = new PresVoucherDistDocMaterial.ChildPresVoucherDistDocMaterialCollection(_StockActionDetails, "PresVoucherDistDocMaterials");
        }

        private PresVoucherDistDocMaterial.ChildPresVoucherDistDocMaterialCollection _PresVoucherDistDocMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresVoucherDistDocMaterial.ChildPresVoucherDistDocMaterialCollection PresVoucherDistDocMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresVoucherDistDocMaterials;
            }            
        }

        protected PresVoucherDistributingDoc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresVoucherDistributingDoc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresVoucherDistributingDoc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresVoucherDistributingDoc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresVoucherDistributingDoc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESVOUCHERDISTRIBUTINGDOC", dataRow) { }
        protected PresVoucherDistributingDoc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESVOUCHERDISTRIBUTINGDOC", dataRow, isImported) { }
        public PresVoucherDistributingDoc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresVoucherDistributingDoc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresVoucherDistributingDoc() : base() { }

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