
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendDetailDependentStore")] 

    /// <summary>
    /// Bağlı Birlik Demirbaş Detayı Gönderme
    /// </summary>
    public  partial class SendDetailDependentStore : BaseAction, IWorkListBaseAction
    {
        public class SendDetailDependentStoreList : TTObjectCollection<SendDetailDependentStore> { }
                    
        public class ChildSendDetailDependentStoreCollection : TTObject.TTChildObjectCollection<SendDetailDependentStore>
        {
            public ChildSendDetailDependentStoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendDetailDependentStoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ab186084-da86-4ade-9542-273b9bb2b57b"); } }
    /// <summary>
    /// Oluştur
    /// </summary>
            public static Guid Create { get { return new Guid("49c08a3f-99be-47f0-b7f7-6217eb57d761"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("1ad0a552-03a6-4743-b9f8-3f2908e25fc2"); } }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSendDetailFixedAssetsCollection()
        {
            _SendDetailFixedAssets = new SendDetailFixedAsset.ChildSendDetailFixedAssetCollection(this, new Guid("8c6b696b-4426-420f-bb96-0aa8b706652c"));
            ((ITTChildObjectCollection)_SendDetailFixedAssets).GetChildren();
        }

        protected SendDetailFixedAsset.ChildSendDetailFixedAssetCollection _SendDetailFixedAssets = null;
        public SendDetailFixedAsset.ChildSendDetailFixedAssetCollection SendDetailFixedAssets
        {
            get
            {
                if (_SendDetailFixedAssets == null)
                    CreateSendDetailFixedAssetsCollection();
                return _SendDetailFixedAssets;
            }
        }

        protected SendDetailDependentStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendDetailDependentStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendDetailDependentStore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendDetailDependentStore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendDetailDependentStore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDDETAILDEPENDENTSTORE", dataRow) { }
        protected SendDetailDependentStore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDDETAILDEPENDENTSTORE", dataRow, isImported) { }
        public SendDetailDependentStore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendDetailDependentStore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendDetailDependentStore() : base() { }

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