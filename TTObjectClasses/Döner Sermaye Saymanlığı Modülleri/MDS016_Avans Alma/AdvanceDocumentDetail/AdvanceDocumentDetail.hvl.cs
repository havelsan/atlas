
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceDocumentDetail")] 

    /// <summary>
    /// Avans Alındısı Dökümanı
    /// </summary>
    public  partial class AdvanceDocumentDetail : AccountDocumentDetail
    {
        public class AdvanceDocumentDetailList : TTObjectCollection<AdvanceDocumentDetail> { }
                    
        public class ChildAdvanceDocumentDetailCollection : TTObject.TTChildObjectCollection<AdvanceDocumentDetail>
        {
            public ChildAdvanceDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("686a85ca-5cfe-4bcf-a300-7178a3996a0c"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("344a5d96-9666-4aa2-b79f-8e74227fc311"); } }
        }

        protected AdvanceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEDOCUMENTDETAIL", dataRow) { }
        protected AdvanceDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEDOCUMENTDETAIL", dataRow, isImported) { }
        public AdvanceDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceDocumentDetail() : base() { }

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