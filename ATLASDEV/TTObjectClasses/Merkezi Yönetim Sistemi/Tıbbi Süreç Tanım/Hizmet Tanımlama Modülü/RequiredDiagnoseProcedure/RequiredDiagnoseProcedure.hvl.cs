
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RequiredDiagnoseProcedure")] 

    public  partial class RequiredDiagnoseProcedure : TTObject
    {
        public class RequiredDiagnoseProcedureList : TTObjectCollection<RequiredDiagnoseProcedure> { }
                    
        public class ChildRequiredDiagnoseProcedureCollection : TTObject.TTChildObjectCollection<RequiredDiagnoseProcedure>
        {
            public ChildRequiredDiagnoseProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRequiredDiagnoseProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RequiredDiagnoseProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RequiredDiagnoseProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RequiredDiagnoseProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RequiredDiagnoseProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RequiredDiagnoseProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REQUIREDDIAGNOSEPROCEDURE", dataRow) { }
        protected RequiredDiagnoseProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REQUIREDDIAGNOSEPROCEDURE", dataRow, isImported) { }
        public RequiredDiagnoseProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RequiredDiagnoseProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RequiredDiagnoseProcedure() : base() { }

    }
}