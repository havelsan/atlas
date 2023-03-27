
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OccupationDefinition")] 

    /// <summary>
    /// Meslek Tanımları
    /// </summary>
    public  partial class OccupationDefinition : TTDefinitionSet
    {
        public class OccupationDefinitionList : TTObjectCollection<OccupationDefinition> { }
                    
        public class ChildOccupationDefinitionCollection : TTObject.TTChildObjectCollection<OccupationDefinition>
        {
            public ChildOccupationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOccupationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Occupation_Shadow
        {
            get { return (string)this["OCCUPATION_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Meslek
    /// </summary>
        public string Occupation
        {
            get { return (string)this["OCCUPATION"]; }
            set { this["OCCUPATION"] = value; }
        }

        protected OccupationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OccupationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OccupationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OccupationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OccupationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OCCUPATIONDEFINITION", dataRow) { }
        protected OccupationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OCCUPATIONDEFINITION", dataRow, isImported) { }
        protected OccupationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OccupationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OccupationDefinition() : base() { }

    }
}