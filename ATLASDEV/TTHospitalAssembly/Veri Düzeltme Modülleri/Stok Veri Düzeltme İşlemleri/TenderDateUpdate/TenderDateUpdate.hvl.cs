
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TenderDateUpdate")] 

    /// <summary>
    /// İhale Tarih ve Kayıt No Güncelleme
    /// </summary>
    public  partial class TenderDateUpdate : BaseDataCorrection, IWorkListBaseAction
    {
        public class TenderDateUpdateList : TTObjectCollection<TenderDateUpdate> { }
                    
        public class ChildTenderDateUpdateCollection : TTObject.TTChildObjectCollection<TenderDateUpdate>
        {
            public ChildTenderDateUpdateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTenderDateUpdateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Completed { get { return new Guid("73c3ee7f-54b2-49e0-88aa-81da814f1c52"); } }
            public static Guid New { get { return new Guid("d661ed53-9dec-47e9-8947-ec6cc1df3b53"); } }
        }

    /// <summary>
    /// İhale Kesinleşme Tarihi
    /// </summary>
        public DateTime? AuctionDate
        {
            get { return (DateTime?)this["AUCTIONDATE"]; }
            set { this["AUCTIONDATE"] = value; }
        }

    /// <summary>
    /// İhale Kayıt No /Alım No
    /// </summary>
        public string RegistrationAuctionNo
        {
            get { return (string)this["REGISTRATIONAUCTIONNO"]; }
            set { this["REGISTRATIONAUCTIONNO"] = value; }
        }

        public StockAction StockAction
        {
            get { return (StockAction)((ITTObject)this).GetParent("STOCKACTION"); }
            set { this["STOCKACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TenderDateUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TenderDateUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TenderDateUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TenderDateUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TenderDateUpdate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TENDERDATEUPDATE", dataRow) { }
        protected TenderDateUpdate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TENDERDATEUPDATE", dataRow, isImported) { }
        public TenderDateUpdate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TenderDateUpdate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TenderDateUpdate() : base() { }

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