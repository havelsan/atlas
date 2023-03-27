
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientInvoiceDocumentDetail")] 

    /// <summary>
    /// Hasta Faturası Döküman Detayı
    /// </summary>
    public  partial class PatientInvoiceDocumentDetail : AccountDocumentDetail
    {
        public class PatientInvoiceDocumentDetailList : TTObjectCollection<PatientInvoiceDocumentDetail> { }
                    
        public class ChildPatientInvoiceDocumentDetailCollection : TTObject.TTChildObjectCollection<PatientInvoiceDocumentDetail>
        {
            public ChildPatientInvoiceDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientInvoiceDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("ae3b262a-3d6f-46e0-9261-1cb7c009041f"); } }
            public static Guid Invoiced { get { return new Guid("3edd9547-f049-4d7d-88a1-ce6d1b4ed502"); } }
        }

        protected PatientInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTINVOICEDOCUMENTDETAIL", dataRow) { }
        protected PatientInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTINVOICEDOCUMENTDETAIL", dataRow, isImported) { }
        public PatientInvoiceDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientInvoiceDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientInvoiceDocumentDetail() : base() { }

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