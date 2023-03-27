
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecificationClause")] 

    public  partial class SpecificationClause : TerminologyManagerDef
    {
        public class SpecificationClauseList : TTObjectCollection<SpecificationClause> { }
                    
        public class ChildSpecificationClauseCollection : TTObject.TTChildObjectCollection<SpecificationClause>
        {
            public ChildSpecificationClauseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecificationClauseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string ClauseNo
        {
            get { return (string)this["CLAUSENO"]; }
            set { this["CLAUSENO"] = value; }
        }

    /// <summary>
    /// Madde
    /// </summary>
        public string Clause
        {
            get { return (string)this["CLAUSE"]; }
            set { this["CLAUSE"] = value; }
        }

        public SpecificationDefinition SpecificationDefinition
        {
            get { return (SpecificationDefinition)((ITTObject)this).GetParent("SPECIFICATIONDEFINITION"); }
            set { this["SPECIFICATIONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SpecificationClause(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecificationClause(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecificationClause(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecificationClause(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecificationClause(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIFICATIONCLAUSE", dataRow) { }
        protected SpecificationClause(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIFICATIONCLAUSE", dataRow, isImported) { }
        public SpecificationClause(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecificationClause(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecificationClause() : base() { }

    }
}