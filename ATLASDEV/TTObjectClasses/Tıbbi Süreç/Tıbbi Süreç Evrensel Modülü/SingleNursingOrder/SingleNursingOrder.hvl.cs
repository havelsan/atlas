
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SingleNursingOrder")] 

    /// <summary>
    /// Hemşire Takip Gözlem Talimatları (Anestezi Konsültasyonu)
    /// </summary>
    public  partial class SingleNursingOrder : BaseNursingOrder
    {
        public class SingleNursingOrderList : TTObjectCollection<SingleNursingOrder> { }
                    
        public class ChildSingleNursingOrderCollection : TTObject.TTChildObjectCollection<SingleNursingOrder>
        {
            public ChildSingleNursingOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSingleNursingOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("bf1f369e-67f8-48cd-bb56-a90c3d94fbcb"); } }
            public static Guid Planned { get { return new Guid("4e1c663e-3b8a-4bec-96f7-8bdc317be155"); } }
            public static Guid Cancelled { get { return new Guid("1cfcab56-d060-4bca-9688-1a60f5b430d6"); } }
        }

        public SingleNursingOrderDetail SingleNursingOrderDetail
        {
            get { return (SingleNursingOrderDetail)((ITTObject)this).GetParent("SINGLENURSINGORDERDETAIL"); }
            set { this["SINGLENURSINGORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysicianApplication PhysicianApplication
        {
            get { return (PhysicianApplication)((ITTObject)this).GetParent("PHYSICIANAPPLICATION"); }
            set { this["PHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollectionViews()
        {
            base.CreateOrderDetailsCollectionViews();
            _SingleNursingOrderDetails = new SingleNursingOrderDetail.ChildSingleNursingOrderDetailCollection(_OrderDetails, "SingleNursingOrderDetails");
        }

        private SingleNursingOrderDetail.ChildSingleNursingOrderDetailCollection _SingleNursingOrderDetails = null;
        public SingleNursingOrderDetail.ChildSingleNursingOrderDetailCollection SingleNursingOrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                    CreateOrderDetailsCollection();
                return _SingleNursingOrderDetails;
            }            
        }

        protected SingleNursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SingleNursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SingleNursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SingleNursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SingleNursingOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SINGLENURSINGORDER", dataRow) { }
        protected SingleNursingOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SINGLENURSINGORDER", dataRow, isImported) { }
        public SingleNursingOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SingleNursingOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SingleNursingOrder() : base() { }

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