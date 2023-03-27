
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSDecisionStampOperationTypeDefinition")] 

    /// <summary>
    /// Karar Pulu İşlem Türü
    /// </summary>
    public  partial class MhSDecisionStampOperationTypeDefinition : TTDefinitionSet
    {
        public class MhSDecisionStampOperationTypeDefinitionList : TTObjectCollection<MhSDecisionStampOperationTypeDefinition> { }
                    
        public class ChildMhSDecisionStampOperationTypeDefinitionCollection : TTObject.TTChildObjectCollection<MhSDecisionStampOperationTypeDefinition>
        {
            public ChildMhSDecisionStampOperationTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSDecisionStampOperationTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Oran
    /// </summary>
        public double? Ratio
        {
            get { return (double?)this["RATIO"]; }
            set { this["RATIO"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSDECISIONSTAMPOPERATIONTYPEDEFINITION", dataRow) { }
        protected MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSDECISIONSTAMPOPERATIONTYPEDEFINITION", dataRow, isImported) { }
        public MhSDecisionStampOperationTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSDecisionStampOperationTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSDecisionStampOperationTypeDefinition() : base() { }

    }
}