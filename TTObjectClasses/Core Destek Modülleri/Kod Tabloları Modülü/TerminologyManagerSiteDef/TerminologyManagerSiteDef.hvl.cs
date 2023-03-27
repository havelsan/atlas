
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TerminologyManagerSiteDef")] 

    public  partial class TerminologyManagerSiteDef : TerminologyManagerDef
    {
        public class TerminologyManagerSiteDefList : TTObjectCollection<TerminologyManagerSiteDef> { }
                    
        public class ChildTerminologyManagerSiteDefCollection : TTObject.TTChildObjectCollection<TerminologyManagerSiteDef>
        {
            public ChildTerminologyManagerSiteDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTerminologyManagerSiteDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Definition Set'i Edit Edebilecek Saha
    /// </summary>
        public Sites EditorSite
        {
            get { return (Sites)((ITTObject)this).GetParent("EDITORSITE"); }
            set { this["EDITORSITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTermManagerSiteDefObjectsCollection()
        {
            _TermManagerSiteDefObjects = new TermManagerSiteDefObject.ChildTermManagerSiteDefObjectCollection(this, new Guid("b030aaec-5617-4fdd-bc5e-01a13a35d656"));
            ((ITTChildObjectCollection)_TermManagerSiteDefObjects).GetChildren();
        }

        protected TermManagerSiteDefObject.ChildTermManagerSiteDefObjectCollection _TermManagerSiteDefObjects = null;
        public TermManagerSiteDefObject.ChildTermManagerSiteDefObjectCollection TermManagerSiteDefObjects
        {
            get
            {
                if (_TermManagerSiteDefObjects == null)
                    CreateTermManagerSiteDefObjectsCollection();
                return _TermManagerSiteDefObjects;
            }
        }

        protected TerminologyManagerSiteDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TerminologyManagerSiteDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TerminologyManagerSiteDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TerminologyManagerSiteDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TerminologyManagerSiteDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TERMINOLOGYMANAGERSITEDEF", dataRow) { }
        protected TerminologyManagerSiteDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TERMINOLOGYMANAGERSITEDEF", dataRow, isImported) { }
        public TerminologyManagerSiteDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TerminologyManagerSiteDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TerminologyManagerSiteDef() : base() { }

    }
}