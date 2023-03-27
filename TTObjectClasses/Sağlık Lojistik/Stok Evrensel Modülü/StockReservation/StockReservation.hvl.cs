
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockReservation")] 

    /// <summary>
    /// Stok Rezervasyonu için kullanılan sınıftır. Rezervasyonla ilgili bilgileri tutar
    /// </summary>
    public  partial class StockReservation : TTObject
    {
        public class StockReservationList : TTObjectCollection<StockReservation> { }
                    
        public class ChildStockReservationCollection : TTObject.TTChildObjectCollection<StockReservation>
        {
            public ChildStockReservationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockReservationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ad497af3-4b11-4ee3-9a16-8b47a42a7d54"); } }
            public static Guid Reserved { get { return new Guid("3019cce4-0ec3-4f28-9abd-eebfbe054591"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("971434b5-bb09-465f-84d1-927e3b413b12"); } }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockActionOutDetailsCollection()
        {
            _StockActionOutDetails = new StockActionDetailOut.ChildStockActionDetailOutCollection(this, new Guid("708da83e-08bb-4363-aa68-e2374e202472"));
            ((ITTChildObjectCollection)_StockActionOutDetails).GetChildren();
        }

        protected StockActionDetailOut.ChildStockActionDetailOutCollection _StockActionOutDetails = null;
        public StockActionDetailOut.ChildStockActionDetailOutCollection StockActionOutDetails
        {
            get
            {
                if (_StockActionOutDetails == null)
                    CreateStockActionOutDetailsCollection();
                return _StockActionOutDetails;
            }
        }

        protected StockReservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockReservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockReservation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockReservation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockReservation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKRESERVATION", dataRow) { }
        protected StockReservation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKRESERVATION", dataRow, isImported) { }
        public StockReservation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockReservation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockReservation() : base() { }

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