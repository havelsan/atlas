
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialMatchAction")] 

    /// <summary>
    /// Malzeme Aktarım
    /// </summary>
    public  partial class MaterialMatchAction : BaseAction, IWorkListBaseAction
    {
        public class MaterialMatchActionList : TTObjectCollection<MaterialMatchAction> { }
                    
        public class ChildMaterialMatchActionCollection : TTObject.TTChildObjectCollection<MaterialMatchAction>
        {
            public ChildMaterialMatchActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialMatchActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("e0cd51a8-482d-49dc-a933-eea17ec71cfa"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("546b6d3f-8fc0-4c1a-8d87-6815f24b6f57"); } }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material WrongMaterial
        {
            get { return (Material)((ITTObject)this).GetParent("WRONGMATERIAL"); }
            set { this["WRONGMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material MatchMaterial
        {
            get { return (Material)((ITTObject)this).GetParent("MATCHMATERIAL"); }
            set { this["MATCHMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialMatchAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialMatchAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialMatchAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialMatchAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialMatchAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALMATCHACTION", dataRow) { }
        protected MaterialMatchAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALMATCHACTION", dataRow, isImported) { }
        public MaterialMatchAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialMatchAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialMatchAction() : base() { }

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