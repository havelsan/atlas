
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryRunMethodDefinitionX")] 

    /// <summary>
    /// Laboratuvar Çalışma Metod Tanımı
    /// </summary>
    public  partial class LaboratoryRunMethodDefinitionX : TTDefinitionSet
    {
        public class LaboratoryRunMethodDefinitionXList : TTObjectCollection<LaboratoryRunMethodDefinitionX> { }
                    
        public class ChildLaboratoryRunMethodDefinitionXCollection : TTObject.TTChildObjectCollection<LaboratoryRunMethodDefinitionX>
        {
            public ChildLaboratoryRunMethodDefinitionXCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryRunMethodDefinitionXCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("e66825db-38e5-45dd-a81a-5ac4826a5616"); } }
            public static Guid Complete { get { return new Guid("7a0fdddd-bd5e-444f-9c06-a23f483af7b0"); } }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public int? IdX
        {
            get { return (int?)this["IDX"]; }
            set { this["IDX"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string DescriptionX
        {
            get { return (string)this["DESCRIPTIONX"]; }
            set { this["DESCRIPTIONX"] = value; }
        }

        public string NameX_Shadow
        {
            get { return (string)this["NAMEX_SHADOW"]; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? ActiveX
        {
            get { return (bool?)this["ACTIVEX"]; }
            set { this["ACTIVEX"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string NameX
        {
            get { return (string)this["NAMEX"]; }
            set { this["NAMEX"] = value; }
        }

        protected LaboratoryRunMethodDefinitionX(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryRunMethodDefinitionX(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryRunMethodDefinitionX(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryRunMethodDefinitionX(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryRunMethodDefinitionX(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYRUNMETHODDEFINITIONX", dataRow) { }
        protected LaboratoryRunMethodDefinitionX(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYRUNMETHODDEFINITIONX", dataRow, isImported) { }
        public LaboratoryRunMethodDefinitionX(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryRunMethodDefinitionX(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryRunMethodDefinitionX() : base() { }

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