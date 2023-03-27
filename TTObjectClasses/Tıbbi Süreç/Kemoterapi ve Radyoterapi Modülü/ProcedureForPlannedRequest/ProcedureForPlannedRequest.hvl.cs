
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureForPlannedRequest")] 

    /// <summary>
    /// Planlanan İstem Nesnesi
    /// </summary>
    public  partial class ProcedureForPlannedRequest : TTObject
    {
        public class ProcedureForPlannedRequestList : TTObjectCollection<ProcedureForPlannedRequest> { }
                    
        public class ChildProcedureForPlannedRequestCollection : TTObject.TTChildObjectCollection<ProcedureForPlannedRequest>
        {
            public ChildProcedureForPlannedRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureForPlannedRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureRequestFormDetailDefinition ProcedureDetailDefinition
        {
            get { return (ProcedureRequestFormDetailDefinition)((ITTObject)this).GetParent("PROCEDUREDETAILDEFINITION"); }
            set { this["PROCEDUREDETAILDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PlannedProcedureRequest PlannedProcedureRequest
        {
            get { return (PlannedProcedureRequest)((ITTObject)this).GetParent("PLANNEDPROCEDUREREQUEST"); }
            set { this["PLANNEDPROCEDUREREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedureForPlannedRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureForPlannedRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureForPlannedRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureForPlannedRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureForPlannedRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREFORPLANNEDREQUEST", dataRow) { }
        protected ProcedureForPlannedRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREFORPLANNEDREQUEST", dataRow, isImported) { }
        public ProcedureForPlannedRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureForPlannedRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureForPlannedRequest() : base() { }

    }
}