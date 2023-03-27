
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorklistMenuDefinition")] 

    /// <summary>
    /// İş Listesi ek command ler
    /// </summary>
    public  partial class WorklistMenuDefinition : TerminologyManagerDef
    {
        public class WorklistMenuDefinitionList : TTObjectCollection<WorklistMenuDefinition> { }
                    
        public class ChildWorklistMenuDefinitionCollection : TTObject.TTChildObjectCollection<WorklistMenuDefinition>
        {
            public ChildWorklistMenuDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorklistMenuDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<WorklistMenuDefinition> GetWorklistMenuDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLISTMENUDEFINITION"].QueryDefs["GetWorklistMenuDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<WorklistMenuDefinition>(queryDef, paramList);
        }

        public int? MenuOrder
        {
            get { return (int?)this["MENUORDER"]; }
            set { this["MENUORDER"] = value; }
        }

    /// <summary>
    /// Menu yazısı
    /// </summary>
        public string MenuText
        {
            get { return (string)this["MENUTEXT"]; }
            set { this["MENUTEXT"] = value; }
        }

    /// <summary>
    /// Key
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public WorkListDefinition WorkList
        {
            get { return (WorkListDefinition)((ITTObject)this).GetParent("WORKLIST"); }
            set { this["WORKLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WorklistMenuDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorklistMenuDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorklistMenuDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorklistMenuDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorklistMenuDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKLISTMENUDEFINITION", dataRow) { }
        protected WorklistMenuDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKLISTMENUDEFINITION", dataRow, isImported) { }
        public WorklistMenuDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorklistMenuDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorklistMenuDefinition() : base() { }

    }
}