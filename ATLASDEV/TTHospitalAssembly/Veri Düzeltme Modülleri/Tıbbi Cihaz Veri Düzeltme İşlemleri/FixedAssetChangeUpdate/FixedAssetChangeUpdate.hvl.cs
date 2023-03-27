
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetChangeUpdate")] 

    /// <summary>
    /// Demirbaş Tipi Değiştirme İşlemi Güncelleme
    /// </summary>
    public  partial class FixedAssetChangeUpdate : BaseDataCorrection, IWorkListBaseAction
    {
        public class FixedAssetChangeUpdateList : TTObjectCollection<FixedAssetChangeUpdate> { }
                    
        public class ChildFixedAssetChangeUpdateCollection : TTObject.TTChildObjectCollection<FixedAssetChangeUpdate>
        {
            public ChildFixedAssetChangeUpdateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetChangeUpdateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2c056679-31c6-4eed-bc42-68c3a1f7d818"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("4544a58d-d23c-4467-8391-fd8249edf681"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("faf9538c-9565-445e-97c1-5d71906f10ef"); } }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFixedAssetChangeDetailsCollection()
        {
            _FixedAssetChangeDetails = new FixedAssetChangeDetail.ChildFixedAssetChangeDetailCollection(this, new Guid("02f42486-acc5-404f-b853-6fb9864ecdf9"));
            ((ITTChildObjectCollection)_FixedAssetChangeDetails).GetChildren();
        }

        protected FixedAssetChangeDetail.ChildFixedAssetChangeDetailCollection _FixedAssetChangeDetails = null;
        public FixedAssetChangeDetail.ChildFixedAssetChangeDetailCollection FixedAssetChangeDetails
        {
            get
            {
                if (_FixedAssetChangeDetails == null)
                    CreateFixedAssetChangeDetailsCollection();
                return _FixedAssetChangeDetails;
            }
        }

        protected FixedAssetChangeUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetChangeUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetChangeUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetChangeUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetChangeUpdate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETCHANGEUPDATE", dataRow) { }
        protected FixedAssetChangeUpdate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETCHANGEUPDATE", dataRow, isImported) { }
        public FixedAssetChangeUpdate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetChangeUpdate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetChangeUpdate() : base() { }

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