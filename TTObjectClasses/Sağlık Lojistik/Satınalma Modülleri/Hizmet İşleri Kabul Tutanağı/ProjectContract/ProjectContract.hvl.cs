
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectContract")] 

    public  partial class ProjectContract : TTObject
    {
        public class ProjectContractList : TTObjectCollection<ProjectContract> { }
                    
        public class ChildProjectContractCollection : TTObject.TTChildObjectCollection<ProjectContract>
        {
            public ChildProjectContractCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectContractCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureWorksAcceptNotice ProcedureWorksAcceptNotice
        {
            get { return (ProcedureWorksAcceptNotice)((ITTObject)this).GetParent("PROCEDUREWORKSACCEPTNOTICE"); }
            set { this["PROCEDUREWORKSACCEPTNOTICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Contract Contract
        {
            get { return (Contract)((ITTObject)this).GetParent("CONTRACT"); }
            set { this["CONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectContract(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectContract(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectContract(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectContract(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectContract(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTCONTRACT", dataRow) { }
        protected ProjectContract(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTCONTRACT", dataRow, isImported) { }
        public ProjectContract(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectContract(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectContract() : base() { }

    }
}