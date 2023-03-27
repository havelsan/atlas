
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExtendExpirationDate")] 

    /// <summary>
    /// Miad Güncelleme İşlemi
    /// </summary>
    public  partial class ExtendExpirationDate : BaseChattelDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IStockOutTransaction, IExtendExpirationDate, IAutoDocumentRecordLog
    {
        public class ExtendExpirationDateList : TTObjectCollection<ExtendExpirationDate> { }
                    
        public class ChildExtendExpirationDateCollection : TTObject.TTChildObjectCollection<ExtendExpirationDate>
        {
            public ChildExtendExpirationDateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExtendExpirationDateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("47c7c586-3e6a-4995-a43f-beb19f279ecb"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("b0c1f426-dc5e-4f7b-a41b-6dda28e18d85"); } }
        }

    /// <summary>
    /// MKYS Giriş Kontrol 
    /// </summary>
        public bool? InMkysControl
        {
            get { return (bool?)this["INMKYSCONTROL"]; }
            set { this["INMKYSCONTROL"] = value; }
        }

    /// <summary>
    /// MKYS Çıkış Kontrol 
    /// </summary>
        public bool? OutMkysControl
        {
            get { return (bool?)this["OUTMKYSCONTROL"]; }
            set { this["OUTMKYSCONTROL"] = value; }
        }

        public int? MKYS_AyniyatMakbuzIDGiris
        {
            get { return (int?)this["MKYS_AYNIYATMAKBUZIDGIRIS"]; }
            set { this["MKYS_AYNIYATMAKBUZIDGIRIS"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ExtendExpirationDateDetails = new ExtendExpirationDateDetail.ChildExtendExpirationDateDetailCollection(_StockActionDetails, "ExtendExpirationDateDetails");
        }

        private ExtendExpirationDateDetail.ChildExtendExpirationDateDetailCollection _ExtendExpirationDateDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ExtendExpirationDateDetail.ChildExtendExpirationDateDetailCollection ExtendExpirationDateDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ExtendExpirationDateDetails;
            }            
        }

        protected ExtendExpirationDate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExtendExpirationDate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExtendExpirationDate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExtendExpirationDate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExtendExpirationDate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTENDEXPIRATIONDATE", dataRow) { }
        protected ExtendExpirationDate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTENDEXPIRATIONDATE", dataRow, isImported) { }
        public ExtendExpirationDate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExtendExpirationDate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExtendExpirationDate() : base() { }

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