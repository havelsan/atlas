
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneticRejectReasonDefinition")] 

    public  partial class GeneticRejectReasonDefinition : TTDefinitionSet
    {
        public class GeneticRejectReasonDefinitionList : TTObjectCollection<GeneticRejectReasonDefinition> { }
                    
        public class ChildGeneticRejectReasonDefinitionCollection : TTObject.TTChildObjectCollection<GeneticRejectReasonDefinition>
        {
            public ChildGeneticRejectReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneticRejectReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected GeneticRejectReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneticRejectReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneticRejectReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneticRejectReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneticRejectReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENETICREJECTREASONDEFINITION", dataRow) { }
        protected GeneticRejectReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENETICREJECTREASONDEFINITION", dataRow, isImported) { }
        public GeneticRejectReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneticRejectReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneticRejectReasonDefinition() : base() { }

    }
}