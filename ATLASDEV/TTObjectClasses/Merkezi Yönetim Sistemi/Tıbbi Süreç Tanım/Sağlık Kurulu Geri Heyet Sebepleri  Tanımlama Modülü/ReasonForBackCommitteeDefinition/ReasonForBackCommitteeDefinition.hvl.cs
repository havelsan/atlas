
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForBackCommitteeDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Geri Heyet Sebepleri Listesi
    /// </summary>
    public  partial class ReasonForBackCommitteeDefinition : TTDefinitionSet
    {
        public class ReasonForBackCommitteeDefinitionList : TTObjectCollection<ReasonForBackCommitteeDefinition> { }
                    
        public class ChildReasonForBackCommitteeDefinitionCollection : TTObject.TTChildObjectCollection<ReasonForBackCommitteeDefinition>
        {
            public ChildReasonForBackCommitteeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForBackCommitteeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Geri Heyet Sebebi
    /// </summary>
        public string ReasonForBackCommittee
        {
            get { return (string)this["REASONFORBACKCOMMITTEE"]; }
            set { this["REASONFORBACKCOMMITTEE"] = value; }
        }

        public string ReasonForBackCommittee_Sha
        {
            get { return (string)this["REASONFORBACKCOMMITTEE_SHA"]; }
        }

        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFORBACKCOMMITTEEDEFINITION", dataRow) { }
        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFORBACKCOMMITTEEDEFINITION", dataRow, isImported) { }
        protected ReasonForBackCommitteeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForBackCommitteeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForBackCommitteeDefinition() : base() { }

    }
}