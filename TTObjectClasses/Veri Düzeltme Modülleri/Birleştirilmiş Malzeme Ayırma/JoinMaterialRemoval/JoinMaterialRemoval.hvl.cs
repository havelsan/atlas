
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="JoinMaterialRemoval")] 

    /// <summary>
    /// Birleştirilen Malzemeyi Düzeltme
    /// </summary>
    public  partial class JoinMaterialRemoval : BaseAction, IWorkListBaseAction
    {
        public class JoinMaterialRemovalList : TTObjectCollection<JoinMaterialRemoval> { }
                    
        public class ChildJoinMaterialRemovalCollection : TTObject.TTChildObjectCollection<JoinMaterialRemoval>
        {
            public ChildJoinMaterialRemovalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildJoinMaterialRemovalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ce979d09-7fe8-447b-962d-1f2d0123bb46"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complated { get { return new Guid("8dee03cd-bfe9-410c-a984-cdd7d16e05b0"); } }
    /// <summary>
    /// Ayır
    /// </summary>
            public static Guid Removal { get { return new Guid("d3a6b4ee-7183-4b66-9480-9581ee26ccb7"); } }
        }

        public Guid? JoinMaterial
        {
            get { return (Guid?)this["JOINMATERIAL"]; }
            set { this["JOINMATERIAL"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected JoinMaterialRemoval(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected JoinMaterialRemoval(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected JoinMaterialRemoval(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected JoinMaterialRemoval(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected JoinMaterialRemoval(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "JOINMATERIALREMOVAL", dataRow) { }
        protected JoinMaterialRemoval(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "JOINMATERIALREMOVAL", dataRow, isImported) { }
        public JoinMaterialRemoval(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public JoinMaterialRemoval(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public JoinMaterialRemoval() : base() { }

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