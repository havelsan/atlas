
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTemplateProcReqFormDetailDefinition")] 

    /// <summary>
    /// PackageTemplate ProcedureRequestFormDetail detay objesi.
    /// </summary>
    public  partial class PackageTemplateProcReqFormDetailDefinition : TTDefinitionSet
    {
        public class PackageTemplateProcReqFormDetailDefinitionList : TTObjectCollection<PackageTemplateProcReqFormDetailDefinition> { }
                    
        public class ChildPackageTemplateProcReqFormDetailDefinitionCollection : TTObject.TTChildObjectCollection<PackageTemplateProcReqFormDetailDefinition>
        {
            public ChildPackageTemplateProcReqFormDetailDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTemplateProcReqFormDetailDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureRequestFormDetailDefinition ProcedureReqFormDetailDef
        {
            get { return (ProcedureRequestFormDetailDefinition)((ITTObject)this).GetParent("PROCEDUREREQFORMDETAILDEF"); }
            set { this["PROCEDUREREQFORMDETAILDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PackageTemplateDefinition PackageTemplateDefinition
        {
            get { return (PackageTemplateDefinition)((ITTObject)this).GetParent("PACKAGETEMPLATEDEFINITION"); }
            set { this["PACKAGETEMPLATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETEMPLATEPROCREQFORMDETAILDEFINITION", dataRow) { }
        protected PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETEMPLATEPROCREQFORMDETAILDEFINITION", dataRow, isImported) { }
        public PackageTemplateProcReqFormDetailDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTemplateProcReqFormDetailDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTemplateProcReqFormDetailDefinition() : base() { }

    }
}