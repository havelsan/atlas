
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrBaseNursingOrder")] 

    /// <summary>
    /// Hemşire Takip Gözlem Talimatları
    /// </summary>
    public  partial class ehrBaseNursingOrder : ehrEpisodeAction
    {
        public class ehrBaseNursingOrderList : TTObjectCollection<ehrBaseNursingOrder> { }
                    
        public class ChildehrBaseNursingOrderCollection : TTObject.TTChildObjectCollection<ehrBaseNursingOrder>
        {
            public ChildehrBaseNursingOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrBaseNursingOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// İstek Yapılan İşlem-Hemşire Talimatları
    /// </summary>
        public ehrEpisodeAction ehrRequesterEpisodeAction
        {
            get { return (ehrEpisodeAction)((ITTObject)this).GetParent("EHRREQUESTEREPISODEACTION"); }
            set { this["EHRREQUESTEREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Talimat
    /// </summary>
        public VitalSignAndNursingDefinition ProcedureObject
        {
            get { return (VitalSignAndNursingDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan İşlem-Hemşire Talimatları
    /// </summary>
        public ehrSubactionFlowable ehrSubactionFlowable
        {
            get { return (ehrSubactionFlowable)((ITTObject)this).GetParent("EHRSUBACTIONFLOWABLE"); }
            set { this["EHRSUBACTIONFLOWABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrNursingOrderDetailsCollection()
        {
            _ehrNursingOrderDetails = new ehrNursingOrderDetail.ChildehrNursingOrderDetailCollection(this, new Guid("03a4b6a5-b373-4f82-bc79-d8d239116cb6"));
            ((ITTChildObjectCollection)_ehrNursingOrderDetails).GetChildren();
        }

        protected ehrNursingOrderDetail.ChildehrNursingOrderDetailCollection _ehrNursingOrderDetails = null;
    /// <summary>
    /// Child collection for Hemşire Talimatları-Hemşire Talimat Uygulamaları
    /// </summary>
        public ehrNursingOrderDetail.ChildehrNursingOrderDetailCollection ehrNursingOrderDetails
        {
            get
            {
                if (_ehrNursingOrderDetails == null)
                    CreateehrNursingOrderDetailsCollection();
                return _ehrNursingOrderDetails;
            }
        }

        protected ehrBaseNursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrBaseNursingOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrBaseNursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrBaseNursingOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrBaseNursingOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRBASENURSINGORDER", dataRow) { }
        protected ehrBaseNursingOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRBASENURSINGORDER", dataRow, isImported) { }
        public ehrBaseNursingOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrBaseNursingOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrBaseNursingOrder() : base() { }

    }
}