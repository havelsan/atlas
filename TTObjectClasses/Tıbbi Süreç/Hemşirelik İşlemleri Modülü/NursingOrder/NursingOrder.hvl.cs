
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingOrder")] 

    /// <summary>
    /// Hemşire Takip Gözlem Talimatları (Klinik İşlemleri) 'nin Gerçekleştirildiği Nesnedir
    /// </summary>
    public  partial class NursingOrder : BaseNursingOrder
    {
        public class NursingOrderList : TTObjectCollection<NursingOrder> { }
                    
        public class ChildNursingOrderCollection : TTObject.TTChildObjectCollection<NursingOrder>
        {
            public ChildNursingOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("820b1f50-21f3-40a0-bd11-44dca3b08c14"); } }
            public static Guid Planned { get { return new Guid("5be79eda-89bf-4f1f-ac96-d816852e64a6"); } }
        }

        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new PeriodicOrderDetail.ChildPeriodicOrderDetailCollection(this, new Guid("aed14046-588d-401f-956c-88eb46f5f641"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        protected NursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGORDER", dataRow) { }
        protected NursingOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGORDER", dataRow, isImported) { }
        public NursingOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingOrder() : base() { }

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