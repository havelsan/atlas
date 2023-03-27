
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeSituationDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Akıbet Tanımları
    /// </summary>
    public  partial class HealthCommitteeSituationDefinition : TTDefinitionSet
    {
        public class HealthCommitteeSituationDefinitionList : TTObjectCollection<HealthCommitteeSituationDefinition> { }
                    
        public class ChildHealthCommitteeSituationDefinitionCollection : TTObject.TTChildObjectCollection<HealthCommitteeSituationDefinition>
        {
            public ChildHealthCommitteeSituationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeSituationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Situation_Shadow
        {
            get { return (string)this["SITUATION_SHADOW"]; }
        }

    /// <summary>
    /// Akıbet
    /// </summary>
        public string Situation
        {
            get { return (string)this["SITUATION"]; }
            set { this["SITUATION"] = value; }
        }

        protected HealthCommitteeSituationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeSituationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeSituationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeSituationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeSituationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEESITUATIONDEFINITION", dataRow) { }
        protected HealthCommitteeSituationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEESITUATIONDEFINITION", dataRow, isImported) { }
        public HealthCommitteeSituationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeSituationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeSituationDefinition() : base() { }

    }
}