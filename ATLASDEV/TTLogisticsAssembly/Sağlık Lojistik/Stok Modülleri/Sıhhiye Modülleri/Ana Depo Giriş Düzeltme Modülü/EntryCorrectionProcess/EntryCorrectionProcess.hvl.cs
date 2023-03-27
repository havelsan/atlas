
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EntryCorrectionProcess")] 

    public  partial class EntryCorrectionProcess : StockAction
    {
        public class EntryCorrectionProcessList : TTObjectCollection<EntryCorrectionProcess> { }
                    
        public class ChildEntryCorrectionProcessCollection : TTObject.TTChildObjectCollection<EntryCorrectionProcess>
        {
            public ChildEntryCorrectionProcessCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEntryCorrectionProcessCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8be9e4d8-5853-41de-9c71-f10c348d8ed2"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("11e85d79-c9ae-45f0-9f8a-7719edbf7e48"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("43a9386c-de71-4852-8929-364f915cf102"); } }
        }

        public DateTime? BaseDateTime
        {
            get { return (DateTime?)this["BASEDATETIME"]; }
            set { this["BASEDATETIME"] = value; }
        }

        public string BaseNumber
        {
            get { return (string)this["BASENUMBER"]; }
            set { this["BASENUMBER"] = value; }
        }

    /// <summary>
    /// Muayene Komisyonu Rapor Tarihi
    /// </summary>
        public DateTime? ExaminationReportDate
        {
            get { return (DateTime?)this["EXAMINATIONREPORTDATE"]; }
            set { this["EXAMINATIONREPORTDATE"] = value; }
        }

    /// <summary>
    /// Muayene Komisyonu Rapor Sayısı
    /// </summary>
        public string ExaminationReportNo
        {
            get { return (string)this["EXAMINATIONREPORTNO"]; }
            set { this["EXAMINATIONREPORTNO"] = value; }
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public long? PurchaseActionID
        {
            get { return (long?)this["PURCHASEACTIONID"]; }
            set { this["PURCHASEACTIONID"] = value; }
        }

        public BaseChattelDocument BaseChattelDocument
        {
            get { return (BaseChattelDocument)((ITTObject)this).GetParent("BASECHATTELDOCUMENT"); }
            set { this["BASECHATTELDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _EntryCorrectionProcessDets = new EntryCorrectionProcessDet.ChildEntryCorrectionProcessDetCollection(_StockActionDetails, "EntryCorrectionProcessDets");
        }

        private EntryCorrectionProcessDet.ChildEntryCorrectionProcessDetCollection _EntryCorrectionProcessDets = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public EntryCorrectionProcessDet.ChildEntryCorrectionProcessDetCollection EntryCorrectionProcessDets
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _EntryCorrectionProcessDets;
            }            
        }

        protected EntryCorrectionProcess(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EntryCorrectionProcess(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EntryCorrectionProcess(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EntryCorrectionProcess(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EntryCorrectionProcess(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENTRYCORRECTIONPROCESS", dataRow) { }
        protected EntryCorrectionProcess(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENTRYCORRECTIONPROCESS", dataRow, isImported) { }
        public EntryCorrectionProcess(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EntryCorrectionProcess(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EntryCorrectionProcess() : base() { }

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