
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubCashOfficeReceiptDocDet")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Tahsilat Döküman Detayı
    /// </summary>
    public  partial class SubCashOfficeReceiptDocDet : AccountDocumentDetail
    {
        public class SubCashOfficeReceiptDocDetList : TTObjectCollection<SubCashOfficeReceiptDocDet> { }
                    
        public class ChildSubCashOfficeReceiptDocDetCollection : TTObject.TTChildObjectCollection<SubCashOfficeReceiptDocDet>
        {
            public ChildSubCashOfficeReceiptDocDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubCashOfficeReceiptDocDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("7b684e8d-18ba-441d-85e0-de2069d6c9f5"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fa052a84-ed86-4469-8ba2-598a4858d421"); } }
        }

        protected SubCashOfficeReceiptDocDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubCashOfficeReceiptDocDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubCashOfficeReceiptDocDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubCashOfficeReceiptDocDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubCashOfficeReceiptDocDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBCASHOFFICERECEIPTDOCDET", dataRow) { }
        protected SubCashOfficeReceiptDocDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBCASHOFFICERECEIPTDOCDET", dataRow, isImported) { }
        public SubCashOfficeReceiptDocDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubCashOfficeReceiptDocDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubCashOfficeReceiptDocDet() : base() { }

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