
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSEtkenMadde")] 

    public  partial class SOSEtkenMadde : TerminologyManagerDef
    {
        public class SOSEtkenMaddeList : TTObjectCollection<SOSEtkenMadde> { }
                    
        public class ChildSOSEtkenMaddeCollection : TTObject.TTChildObjectCollection<SOSEtkenMadde>
        {
            public ChildSOSEtkenMaddeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSEtkenMaddeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

    /// <summary>
    /// Etken Madde Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public ActiveIngredientDefinition XXXXXXActiveIngredient
        {
            get { return (ActiveIngredientDefinition)((ITTObject)this).GetParent("XXXXXXACTIVEINGREDIENT"); }
            set { this["XXXXXXACTIVEINGREDIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSEtkenMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSEtkenMadde(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSEtkenMadde(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSEtkenMadde(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSEtkenMadde(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSETKENMADDE", dataRow) { }
        protected SOSEtkenMadde(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSETKENMADDE", dataRow, isImported) { }
        public SOSEtkenMadde(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSEtkenMadde(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSEtkenMadde() : base() { }

    }
}