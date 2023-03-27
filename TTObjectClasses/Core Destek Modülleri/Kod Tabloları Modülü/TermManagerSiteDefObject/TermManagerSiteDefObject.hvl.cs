
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TermManagerSiteDefObject")] 

    public  partial class TermManagerSiteDefObject : TerminologyManagerDef
    {
        public class TermManagerSiteDefObjectList : TTObjectCollection<TermManagerSiteDefObject> { }
                    
        public class ChildTermManagerSiteDefObjectCollection : TTObject.TTChildObjectCollection<TermManagerSiteDefObject>
        {
            public ChildTermManagerSiteDefObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTermManagerSiteDefObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<TermManagerSiteDefObject> GetSiteDefObjectByObjDefID(TTObjectContext objectContext, Guid OBJDEFID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TERMMANAGERSITEDEFOBJECT"].QueryDefs["GetSiteDefObjectByObjDefID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJDEFID", OBJDEFID);

            return ((ITTQuery)objectContext).QueryObjects<TermManagerSiteDefObject>(queryDef, paramList);
        }

    /// <summary>
    /// ObjDefID
    /// </summary>
        public Guid? ObjDefID
        {
            get { return (Guid?)this["OBJDEFID"]; }
            set { this["OBJDEFID"] = value; }
        }

        public TerminologyManagerSiteDef TerminologyManagerSite
        {
            get { return (TerminologyManagerSiteDef)((ITTObject)this).GetParent("TERMINOLOGYMANAGERSITE"); }
            set { this["TERMINOLOGYMANAGERSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TermManagerSiteDefObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TermManagerSiteDefObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TermManagerSiteDefObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TermManagerSiteDefObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TermManagerSiteDefObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TERMMANAGERSITEDEFOBJECT", dataRow) { }
        protected TermManagerSiteDefObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TERMMANAGERSITEDEFOBJECT", dataRow, isImported) { }
        public TermManagerSiteDefObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TermManagerSiteDefObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TermManagerSiteDefObject() : base() { }

    }
}