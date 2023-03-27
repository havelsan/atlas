
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralInvoiceDocumentDetail")] 

    public  partial class GeneralInvoiceDocumentDetail : AccountDocumentDetail
    {
        public class GeneralInvoiceDocumentDetailList : TTObjectCollection<GeneralInvoiceDocumentDetail> { }
                    
        public class ChildGeneralInvoiceDocumentDetailCollection : TTObject.TTChildObjectCollection<GeneralInvoiceDocumentDetail>
        {
            public ChildGeneralInvoiceDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralInvoiceDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Gönderildi
    /// </summary>
            public static Guid Send { get { return new Guid("e92c028d-1122-4a67-87d0-9c0a9626289e"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f99f7273-6012-479a-a383-5818739921cd"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("cfde1997-6f81-4775-9aa3-56adc70d282d"); } }
        }

        virtual protected void CreateGeneralInvoiceProcedureCollection()
        {
            _GeneralInvoiceProcedure = new GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection(this, new Guid("c4e093ff-37d5-4741-999d-79d91875eac7"));
            ((ITTChildObjectCollection)_GeneralInvoiceProcedure).GetChildren();
        }

        protected GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection _GeneralInvoiceProcedure = null;
    /// <summary>
    /// Child collection for GeneralInvoiceDocumentDetail e ilişki
    /// </summary>
        public GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection GeneralInvoiceProcedure
        {
            get
            {
                if (_GeneralInvoiceProcedure == null)
                    CreateGeneralInvoiceProcedureCollection();
                return _GeneralInvoiceProcedure;
            }
        }

        protected GeneralInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALINVOICEDOCUMENTDETAIL", dataRow) { }
        protected GeneralInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALINVOICEDOCUMENTDETAIL", dataRow, isImported) { }
        public GeneralInvoiceDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralInvoiceDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralInvoiceDocumentDetail() : base() { }

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