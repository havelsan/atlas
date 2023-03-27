
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForAdmissionProcedureDefinitions")] 

    public  partial class ReasonForAdmissionProcedureDefinitions : TTObject
    {
        public class ReasonForAdmissionProcedureDefinitionsList : TTObjectCollection<ReasonForAdmissionProcedureDefinitions> { }
                    
        public class ChildReasonForAdmissionProcedureDefinitionsCollection : TTObject.TTChildObjectCollection<ReasonForAdmissionProcedureDefinitions>
        {
            public ChildReasonForAdmissionProcedureDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForAdmissionProcedureDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlatılacak Prosedure
    /// </summary>
        public ReasonForAdmissionRelatedResources RelatedResource
        {
            get { return (ReasonForAdmissionRelatedResources)((ITTObject)this).GetParent("RELATEDRESOURCE"); }
            set { this["RELATEDRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFORADMISSIONPROCEDUREDEFINITIONS", dataRow) { }
        protected ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFORADMISSIONPROCEDUREDEFINITIONS", dataRow, isImported) { }
        public ReasonForAdmissionProcedureDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForAdmissionProcedureDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForAdmissionProcedureDefinitions() : base() { }

    }
}