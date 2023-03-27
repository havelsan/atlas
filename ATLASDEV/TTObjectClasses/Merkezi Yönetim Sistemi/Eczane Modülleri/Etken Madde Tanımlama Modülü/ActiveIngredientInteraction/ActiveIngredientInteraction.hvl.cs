
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActiveIngredientInteraction")] 

    public  partial class ActiveIngredientInteraction : TerminologyManagerDef
    {
        public class ActiveIngredientInteractionList : TTObjectCollection<ActiveIngredientInteraction> { }
                    
        public class ChildActiveIngredientInteractionCollection : TTObject.TTChildObjectCollection<ActiveIngredientInteraction>
        {
            public ChildActiveIngredientInteractionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActiveIngredientInteractionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Oran
    /// </summary>
        public double? Rate
        {
            get { return (double?)this["RATE"]; }
            set { this["RATE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public long? Value
        {
            get { return (long?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public ActiveIngredientDefinition InteractActiveIngredient
        {
            get { return (ActiveIngredientDefinition)((ITTObject)this).GetParent("INTERACTACTIVEINGREDIENT"); }
            set { this["INTERACTACTIVEINGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ActiveIngredientDefinition ActiveIngredient
        {
            get { return (ActiveIngredientDefinition)((ITTObject)this).GetParent("ACTIVEINGREDIENT"); }
            set { this["ACTIVEINGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ActiveIngredientInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActiveIngredientInteraction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActiveIngredientInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActiveIngredientInteraction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActiveIngredientInteraction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIVEINGREDIENTINTERACTION", dataRow) { }
        protected ActiveIngredientInteraction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIVEINGREDIENTINTERACTION", dataRow, isImported) { }
        public ActiveIngredientInteraction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActiveIngredientInteraction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActiveIngredientInteraction() : base() { }

    }
}