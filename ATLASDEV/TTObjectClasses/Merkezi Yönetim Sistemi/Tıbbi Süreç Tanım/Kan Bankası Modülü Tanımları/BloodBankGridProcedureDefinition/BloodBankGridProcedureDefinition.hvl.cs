
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankGridProcedureDefinition")] 

    public  partial class BloodBankGridProcedureDefinition : TTDefinitionSet
    {
        public class BloodBankGridProcedureDefinitionList : TTObjectCollection<BloodBankGridProcedureDefinition> { }
                    
        public class ChildBloodBankGridProcedureDefinitionCollection : TTObject.TTChildObjectCollection<BloodBankGridProcedureDefinition>
        {
            public ChildBloodBankGridProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankGridProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public BloodBankTestDefinition BloodBankTestDefinition
        {
            get { return (BloodBankTestDefinition)((ITTObject)this).GetParent("BLOODBANKTESTDEFINITION"); }
            set { this["BLOODBANKTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition SubProcedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("SUBPROCEDURE"); }
            set { this["SUBPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BloodBankGridProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankGridProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankGridProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankGridProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankGridProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKGRIDPROCEDUREDEFINITION", dataRow) { }
        protected BloodBankGridProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKGRIDPROCEDUREDEFINITION", dataRow, isImported) { }
        public BloodBankGridProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankGridProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankGridProcedureDefinition() : base() { }

    }
}