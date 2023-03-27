
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubUnitMaterialInheld")] 

    /// <summary>
    /// Bağlı Birlik Malzeme Mevcudu
    /// </summary>
    public  partial class SubUnitMaterialInheld : BaseAction
    {
        public class SubUnitMaterialInheldList : TTObjectCollection<SubUnitMaterialInheld> { }
                    
        public class ChildSubUnitMaterialInheldCollection : TTObject.TTChildObjectCollection<SubUnitMaterialInheld>
        {
            public ChildSubUnitMaterialInheldCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubUnitMaterialInheldCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("71d70be1-06cb-4ae8-9375-8db9bc511b10"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Complated { get { return new Guid("8dc2893d-6e44-45c8-a605-f4cca0f8fe18"); } }
        }

        virtual protected void CreateSubUnitMatGridsCollection()
        {
            _SubUnitMatGrids = new SubUnitMatGridClass.ChildSubUnitMatGridClassCollection(this, new Guid("0729d020-43ce-4e30-9305-eb37ed001729"));
            ((ITTChildObjectCollection)_SubUnitMatGrids).GetChildren();
        }

        protected SubUnitMatGridClass.ChildSubUnitMatGridClassCollection _SubUnitMatGrids = null;
        public SubUnitMatGridClass.ChildSubUnitMatGridClassCollection SubUnitMatGrids
        {
            get
            {
                if (_SubUnitMatGrids == null)
                    CreateSubUnitMatGridsCollection();
                return _SubUnitMatGrids;
            }
        }

        protected SubUnitMaterialInheld(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubUnitMaterialInheld(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubUnitMaterialInheld(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubUnitMaterialInheld(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubUnitMaterialInheld(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBUNITMATERIALINHELD", dataRow) { }
        protected SubUnitMaterialInheld(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBUNITMATERIALINHELD", dataRow, isImported) { }
        public SubUnitMaterialInheld(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubUnitMaterialInheld(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubUnitMaterialInheld() : base() { }

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