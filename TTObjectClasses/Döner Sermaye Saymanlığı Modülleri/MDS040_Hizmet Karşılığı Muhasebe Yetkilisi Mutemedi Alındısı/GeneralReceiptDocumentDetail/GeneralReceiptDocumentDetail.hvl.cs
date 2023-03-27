
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralReceiptDocumentDetail")] 

    /// <summary>
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı Döküman Detayı
    /// </summary>
    public  partial class GeneralReceiptDocumentDetail : AccountDocumentDetail
    {
        public class GeneralReceiptDocumentDetailList : TTObjectCollection<GeneralReceiptDocumentDetail> { }
                    
        public class ChildGeneralReceiptDocumentDetailCollection : TTObject.TTChildObjectCollection<GeneralReceiptDocumentDetail>
        {
            public ChildGeneralReceiptDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralReceiptDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("82c09ac3-286e-4d1c-8912-3e75e14637a7"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d92a2bbd-1cd7-4785-8505-955561954374"); } }
        }

        virtual protected void CreateGeneralReceiptProcedureCollection()
        {
            _GeneralReceiptProcedure = new GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection(this, new Guid("a085666c-177c-4b61-905f-e7a7d85b9d95"));
            ((ITTChildObjectCollection)_GeneralReceiptProcedure).GetChildren();
        }

        protected GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection _GeneralReceiptProcedure = null;
    /// <summary>
    /// Child collection for GeneralReceiptDocumentDetail e ilişki
    /// </summary>
        public GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection GeneralReceiptProcedure
        {
            get
            {
                if (_GeneralReceiptProcedure == null)
                    CreateGeneralReceiptProcedureCollection();
                return _GeneralReceiptProcedure;
            }
        }

        protected GeneralReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralReceiptDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralReceiptDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALRECEIPTDOCUMENTDETAIL", dataRow) { }
        protected GeneralReceiptDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALRECEIPTDOCUMENTDETAIL", dataRow, isImported) { }
        public GeneralReceiptDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralReceiptDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralReceiptDocumentDetail() : base() { }

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