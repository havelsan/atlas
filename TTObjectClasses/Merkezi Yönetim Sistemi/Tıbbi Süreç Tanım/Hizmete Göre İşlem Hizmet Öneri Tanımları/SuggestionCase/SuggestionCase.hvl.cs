
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SuggestionCase")] 

    public  partial class SuggestionCase : TTObject
    {
        public class SuggestionCaseList : TTObjectCollection<SuggestionCase> { }
                    
        public class ChildSuggestionCaseCollection : TTObject.TTChildObjectCollection<SuggestionCase>
        {
            public ChildSuggestionCaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSuggestionCaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string MaxResult
        {
            get { return (string)this["MAXRESULT"]; }
            set { this["MAXRESULT"] = value; }
        }

        public string MinResult
        {
            get { return (string)this["MINRESULT"]; }
            set { this["MINRESULT"] = value; }
        }

        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureActionSuggestion ProcedureActionSuggestion
        {
            get { return (ProcedureActionSuggestion)((ITTObject)this).GetParent("PROCEDUREACTIONSUGGESTION"); }
            set { this["PROCEDUREACTIONSUGGESTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SuggestionCase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SuggestionCase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SuggestionCase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SuggestionCase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SuggestionCase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUGGESTIONCASE", dataRow) { }
        protected SuggestionCase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUGGESTIONCASE", dataRow, isImported) { }
        public SuggestionCase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SuggestionCase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SuggestionCase() : base() { }

    }
}