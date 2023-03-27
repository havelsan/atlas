
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubProcedureDefinition")] 

    /// <summary>
    /// Alt Hizmet Tanımları
    /// </summary>
    public  partial class SubProcedureDefinition : TerminologyManagerDef
    {
        public class SubProcedureDefinitionList : TTObjectCollection<SubProcedureDefinition> { }
                    
        public class ChildSubProcedureDefinitionCollection : TTObject.TTChildObjectCollection<SubProcedureDefinition>
        {
            public ChildSubProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public long? Amount
        {
            get { return (long?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ProcedureDefinition ChildProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("CHILDPROCEDUREDEFINITION"); }
            set { this["CHILDPROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition ParentProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PARENTPROCEDUREDEFINITION"); }
            set { this["PARENTPROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SubProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBPROCEDUREDEFINITION", dataRow) { }
        protected SubProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBPROCEDUREDEFINITION", dataRow, isImported) { }
        public SubProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubProcedureDefinition() : base() { }

    }
}