
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryIngredientDefinition")] 

    /// <summary>
    /// Laboratuvar Etken Madde Tanımı
    /// </summary>
    public  partial class LaboratoryIngredientDefinition : TTDefinitionSet
    {
        public class LaboratoryIngredientDefinitionList : TTObjectCollection<LaboratoryIngredientDefinition> { }
                    
        public class ChildLaboratoryIngredientDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryIngredientDefinition>
        {
            public ChildLaboratoryIngredientDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryIngredientDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("be423fe1-2bbd-4f15-8758-026bb8b0504c"); } }
            public static Guid Complete { get { return new Guid("d451ab23-9bfe-4868-a0e1-fda8481b53af"); } }
        }

    /// <summary>
    /// Kısaltma
    /// </summary>
        public string Summary
        {
            get { return (string)this["SUMMARY"]; }
            set { this["SUMMARY"] = value; }
        }

    /// <summary>
    /// Sıra
    /// </summary>
        public int? Order
        {
            get { return (int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

    /// <summary>
    /// Beta-Laktam
    /// </summary>
        public bool? IsBetaLactam
        {
            get { return (bool?)this["ISBETALACTAM"]; }
            set { this["ISBETALACTAM"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Beta-Laktam Değil
    /// </summary>
        public bool? IsNotBetaLactamX
        {
            get { return (bool?)this["ISNOTBETALACTAMX"]; }
            set { this["ISNOTBETALACTAMX"] = value; }
        }

    /// <summary>
    /// Tetikleyici
    /// </summary>
        public bool? IsTrigger
        {
            get { return (bool?)this["ISTRIGGER"]; }
            set { this["ISTRIGGER"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public LaboratoryIngredientGroupDefinition IngredientGroup
        {
            get { return (LaboratoryIngredientGroupDefinition)((ITTObject)this).GetParent("INGREDIENTGROUP"); }
            set { this["INGREDIENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryIngredientDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryIngredientDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryIngredientDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryIngredientDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryIngredientDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYINGREDIENTDEFINITION", dataRow) { }
        protected LaboratoryIngredientDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYINGREDIENTDEFINITION", dataRow, isImported) { }
        public LaboratoryIngredientDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryIngredientDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryIngredientDefinition() : base() { }

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