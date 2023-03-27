
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyOrder")] 

    /// <summary>
    /// Acil Servis Order
    /// </summary>
    public  partial class EmergencyOrder : TTObject
    {
        public class EmergencyOrderList : TTObjectCollection<EmergencyOrder> { }
                    
        public class ChildEmergencyOrderCollection : TTObject.TTChildObjectCollection<EmergencyOrder>
        {
            public ChildEmergencyOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid New { get { return new Guid("b4469e13-a5b5-4420-af75-a66dca0750af"); } }
    /// <summary>
    /// Uygula
    /// </summary>
            public static Guid Approve { get { return new Guid("406dc9b6-b016-4d2e-8319-7f3664fc71e2"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("161b3da5-4135-481f-bd87-407255ddbb4d"); } }
    /// <summary>
    /// İptal Et
    /// </summary>
            public static Guid Cancelled { get { return new Guid("52efdd21-371e-4809-8217-d87391984fa5"); } }
        }

        public Guid? SubEpisodeID
        {
            get { return (Guid?)this["SUBEPISODEID"]; }
            set { this["SUBEPISODEID"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

    /// <summary>
    /// Acil Order
    /// </summary>
        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEmergencyOrderDetailsCollection()
        {
            _EmergencyOrderDetails = new EmergencyOrderDetail.ChildEmergencyOrderDetailCollection(this, new Guid("3c5ca894-7a80-4b1d-88ed-9787ed84a065"));
            ((ITTChildObjectCollection)_EmergencyOrderDetails).GetChildren();
        }

        protected EmergencyOrderDetail.ChildEmergencyOrderDetailCollection _EmergencyOrderDetails = null;
        public EmergencyOrderDetail.ChildEmergencyOrderDetailCollection EmergencyOrderDetails
        {
            get
            {
                if (_EmergencyOrderDetails == null)
                    CreateEmergencyOrderDetailsCollection();
                return _EmergencyOrderDetails;
            }
        }

        protected EmergencyOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYORDER", dataRow) { }
        protected EmergencyOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYORDER", dataRow, isImported) { }
        public EmergencyOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyOrder() : base() { }

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