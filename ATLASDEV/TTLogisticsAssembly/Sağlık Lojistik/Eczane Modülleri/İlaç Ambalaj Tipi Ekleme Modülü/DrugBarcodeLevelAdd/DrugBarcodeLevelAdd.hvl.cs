
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugBarcodeLevelAdd")] 

    /// <summary>
    /// İlaç Ambalaj Tipi Ekleme
    /// </summary>
    public  partial class DrugBarcodeLevelAdd : BaseAction
    {
        public class DrugBarcodeLevelAddList : TTObjectCollection<DrugBarcodeLevelAdd> { }
                    
        public class ChildDrugBarcodeLevelAddCollection : TTObject.TTChildObjectCollection<DrugBarcodeLevelAdd>
        {
            public ChildDrugBarcodeLevelAddCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugBarcodeLevelAddCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("eecadd8e-3631-4370-8e78-aa9af4b60179"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("abb1634e-43e3-4d98-888c-f2e913813192"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("856c740d-64e2-40d1-9320-141842c8361c"); } }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugBarcodeLevelAdd(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugBarcodeLevelAdd(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugBarcodeLevelAdd(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugBarcodeLevelAdd(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugBarcodeLevelAdd(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGBARCODELEVELADD", dataRow) { }
        protected DrugBarcodeLevelAdd(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGBARCODELEVELADD", dataRow, isImported) { }
        public DrugBarcodeLevelAdd(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugBarcodeLevelAdd(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugBarcodeLevelAdd() : base() { }

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