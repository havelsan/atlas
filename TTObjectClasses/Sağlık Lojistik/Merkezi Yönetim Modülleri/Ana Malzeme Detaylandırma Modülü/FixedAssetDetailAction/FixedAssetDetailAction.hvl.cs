
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailAction")] 

    /// <summary>
    /// Ana Malzeme Detaylandırma İşlemi
    /// </summary>
    public  partial class FixedAssetDetailAction : BaseCentralAction
    {
        public class FixedAssetDetailActionList : TTObjectCollection<FixedAssetDetailAction> { }
                    
        public class ChildFixedAssetDetailActionCollection : TTObject.TTChildObjectCollection<FixedAssetDetailAction>
        {
            public ChildFixedAssetDetailActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// 2.Aşama
    /// </summary>
            public static Guid StageTwo { get { return new Guid("9ed94124-2320-4b7c-b484-73db81320fc1"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8dd2bb53-6cc0-44c1-8bc8-531dc2e9388e"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("af29d8fd-3708-4e38-80e6-93977c82669c"); } }
    /// <summary>
    /// 3.Aşama
    /// </summary>
            public static Guid StageThree { get { return new Guid("fa5bbc52-c327-42b8-89ef-aa4a0cd40816"); } }
    /// <summary>
    /// 1.Aşama
    /// </summary>
            public static Guid StageOne { get { return new Guid("b3c655ff-74de-4d3d-b40c-cf4deca29228"); } }
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
    /// Depo
    /// </summary>
        public string StoreName
        {
            get { return (string)this["STORENAME"]; }
            set { this["STORENAME"] = value; }
        }

        public Guid? StoreObjectID
        {
            get { return (Guid?)this["STOREOBJECTID"]; }
            set { this["STOREOBJECTID"] = value; }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFixedAssetDetailActionDetailsCollection()
        {
            _FixedAssetDetailActionDetails = new FixedAssetDetailActionDet.ChildFixedAssetDetailActionDetCollection(this, new Guid("03ea3c34-c68f-4139-bc64-af4b0b98f4d8"));
            ((ITTChildObjectCollection)_FixedAssetDetailActionDetails).GetChildren();
        }

        protected FixedAssetDetailActionDet.ChildFixedAssetDetailActionDetCollection _FixedAssetDetailActionDetails = null;
        public FixedAssetDetailActionDet.ChildFixedAssetDetailActionDetCollection FixedAssetDetailActionDetails
        {
            get
            {
                if (_FixedAssetDetailActionDetails == null)
                    CreateFixedAssetDetailActionDetailsCollection();
                return _FixedAssetDetailActionDetails;
            }
        }

        protected FixedAssetDetailAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILACTION", dataRow) { }
        protected FixedAssetDetailAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILACTION", dataRow, isImported) { }
        public FixedAssetDetailAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailAction() : base() { }

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