
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SupplyRequest")] 

    /// <summary>
    /// Satınalma Talebi
    /// </summary>
    public  partial class SupplyRequest : StockAction, ISupplyRequest
    {
        public class SupplyRequestList : TTObjectCollection<SupplyRequest> { }
                    
        public class ChildSupplyRequestCollection : TTObject.TTChildObjectCollection<SupplyRequest>
        {
            public ChildSupplyRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSupplyRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("5a02968a-3643-4320-aa93-5f2650e63a22"); } }
            public static Guid Completed { get { return new Guid("b813f79a-3e0d-40f7-8320-be5cf15d35d7"); } }
            public static Guid New { get { return new Guid("1634f7d0-e140-498f-8652-33702bf22ca5"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("9dc79589-426e-4f42-85b8-431a0464d4fb"); } }
        }

    /// <summary>
    /// Alım Türü
    /// </summary>
        public SupplyRequestTypeEnum? RequestType
        {
            get { return (SupplyRequestTypeEnum?)(int?)this["REQUESTTYPE"]; }
            set { this["REQUESTTYPE"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

    /// <summary>
    /// Personelin Adı, Soyadı
    /// </summary>
        public ResUser SignUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SIGNUSER"); }
            set { this["SIGNUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSupplyRequestDetailsCollection()
        {
            _SupplyRequestDetails = new SupplyRequestDetail.ChildSupplyRequestDetailCollection(this, new Guid("0bc11bca-38d4-4078-96a3-116063ba5af9"));
            ((ITTChildObjectCollection)_SupplyRequestDetails).GetChildren();
        }

        protected SupplyRequestDetail.ChildSupplyRequestDetailCollection _SupplyRequestDetails = null;
    /// <summary>
    /// Child collection for İstek İşlemi
    /// </summary>
        public SupplyRequestDetail.ChildSupplyRequestDetailCollection SupplyRequestDetails
        {
            get
            {
                if (_SupplyRequestDetails == null)
                    CreateSupplyRequestDetailsCollection();
                return _SupplyRequestDetails;
            }
        }

        protected SupplyRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SupplyRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SupplyRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SupplyRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SupplyRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUPPLYREQUEST", dataRow) { }
        protected SupplyRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUPPLYREQUEST", dataRow, isImported) { }
        public SupplyRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SupplyRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SupplyRequest() : base() { }

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