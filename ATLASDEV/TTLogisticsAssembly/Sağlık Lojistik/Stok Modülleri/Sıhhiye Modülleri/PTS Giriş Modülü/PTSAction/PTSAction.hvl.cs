
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PTSAction")] 

    /// <summary>
    /// PTS Giriş İşlemi
    /// </summary>
    public  partial class PTSAction : StockAction, IStockAction
    {
        public class PTSActionList : TTObjectCollection<PTSAction> { }
                    
        public class ChildPTSActionCollection : TTObject.TTChildObjectCollection<PTSAction>
        {
            public ChildPTSActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPTSActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("b07301fb-011f-4e68-acbf-afb847df8d23"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("3c41dd8c-207c-4199-86b2-8e58cbf15cf5"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("605ab44b-d2ac-449f-9728-0c643af63dfa"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("2b9242f5-3de3-474c-9f86-2a736082edc0"); } }
    /// <summary>
    /// Taşınır Mal İşlemi Giriş
    /// </summary>
            public static Guid CreateInputDocument { get { return new Guid("6c7b82b6-3ad3-41aa-860b-b2551db4803d"); } }
        }

        public static BindingList<PTSAction> GetInputDocumentStateAction(TTObjectContext objectContext, DateTime WORKLISTDATE, Guid STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PTSACTION"].QueryDefs["GetInputDocumentStateAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKLISTDATE", WORKLISTDATE);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<PTSAction>(queryDef, paramList);
        }

    /// <summary>
    /// PTS Nu.
    /// </summary>
        public int? PTSID
        {
            get { return (int?)this["PTSID"]; }
            set { this["PTSID"] = value; }
        }

        public DateTime? ConclusionDateTime
        {
            get { return (DateTime?)this["CONCLUSIONDATETIME"]; }
            set { this["CONCLUSIONDATETIME"] = value; }
        }

        public Guid? ChattelDocumentObjectID
        {
            get { return (Guid?)this["CHATTELDOCUMENTOBJECTID"]; }
            set { this["CHATTELDOCUMENTOBJECTID"] = value; }
        }

        public string ConclusionNumber
        {
            get { return (string)this["CONCLUSIONNUMBER"]; }
            set { this["CONCLUSIONNUMBER"] = value; }
        }

        public DateTime? ContractDateTime
        {
            get { return (DateTime?)this["CONTRACTDATETIME"]; }
            set { this["CONTRACTDATETIME"] = value; }
        }

        public string ContractNumber
        {
            get { return (string)this["CONTRACTNUMBER"]; }
            set { this["CONTRACTNUMBER"] = value; }
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

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PTSActionDetails = new PTSActionDetail.ChildPTSActionDetailCollection(_StockActionDetails, "PTSActionDetails");
        }

        private PTSActionDetail.ChildPTSActionDetailCollection _PTSActionDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PTSActionDetail.ChildPTSActionDetailCollection PTSActionDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PTSActionDetails;
            }            
        }

        protected PTSAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PTSAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PTSAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PTSAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PTSAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PTSACTION", dataRow) { }
        protected PTSAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PTSACTION", dataRow, isImported) { }
        public PTSAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PTSAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PTSAction() : base() { }

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