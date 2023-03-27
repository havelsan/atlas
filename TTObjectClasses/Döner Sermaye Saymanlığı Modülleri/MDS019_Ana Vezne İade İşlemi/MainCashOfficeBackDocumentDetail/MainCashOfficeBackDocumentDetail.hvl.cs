
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficeBackDocumentDetail")] 

    /// <summary>
    /// Vezne İade Döküman Detayı
    /// </summary>
    public  partial class MainCashOfficeBackDocumentDetail : AccountDocumentDetail
    {
        public class MainCashOfficeBackDocumentDetailList : TTObjectCollection<MainCashOfficeBackDocumentDetail> { }
                    
        public class ChildMainCashOfficeBackDocumentDetailCollection : TTObject.TTChildObjectCollection<MainCashOfficeBackDocumentDetail>
        {
            public ChildMainCashOfficeBackDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficeBackDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e524ef62-6c27-4b5b-bf87-d0911e03d346"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("d5ccb745-1508-4b97-9f7b-c3f806486a73"); } }
        }

        protected MainCashOfficeBackDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficeBackDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficeBackDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficeBackDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficeBackDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEBACKDOCUMENTDETAIL", dataRow) { }
        protected MainCashOfficeBackDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEBACKDOCUMENTDETAIL", dataRow, isImported) { }
        public MainCashOfficeBackDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficeBackDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficeBackDocumentDetail() : base() { }

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