
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTemplateProcedureDefinition")] 

    public  partial class PackageTemplateProcedureDefinition : TTDefinitionSet
    {
        public class PackageTemplateProcedureDefinitionList : TTObjectCollection<PackageTemplateProcedureDefinition> { }
                    
        public class ChildPackageTemplateProcedureDefinitionCollection : TTObject.TTChildObjectCollection<PackageTemplateProcedureDefinition>
        {
            public ChildPackageTemplateProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTemplateProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PackageTemplateDefinition PackageTemplateDefinition
        {
            get { return (PackageTemplateDefinition)((ITTObject)this).GetParent("PACKAGETEMPLATEDEFINITION"); }
            set { this["PACKAGETEMPLATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTemplateProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTemplateProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTemplateProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTemplateProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTemplateProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETEMPLATEPROCEDUREDEFINITION", dataRow) { }
        protected PackageTemplateProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETEMPLATEPROCEDUREDEFINITION", dataRow, isImported) { }
        public PackageTemplateProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTemplateProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTemplateProcedureDefinition() : base() { }

    }
}