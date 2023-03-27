
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureRequestTemplateDetail")] 

    public  partial class ProcedureRequestTemplateDetail : TTObject
    {
        public class ProcedureRequestTemplateDetailList : TTObjectCollection<ProcedureRequestTemplateDetail> { }
                    
        public class ChildProcedureRequestTemplateDetailCollection : TTObject.TTChildObjectCollection<ProcedureRequestTemplateDetail>
        {
            public ChildProcedureRequestTemplateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureRequestTemplateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public long? Amount
        {
            get { return (long?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureRequestTemplateDefinition TemplateDefinition
        {
            get { return (ProcedureRequestTemplateDefinition)((ITTObject)this).GetParent("TEMPLATEDEFINITION"); }
            set { this["TEMPLATEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedureRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureRequestTemplateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureRequestTemplateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREREQUESTTEMPLATEDETAIL", dataRow) { }
        protected ProcedureRequestTemplateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREREQUESTTEMPLATEDETAIL", dataRow, isImported) { }
        public ProcedureRequestTemplateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureRequestTemplateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureRequestTemplateDetail() : base() { }

    }
}