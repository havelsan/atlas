
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NotIncludeSites")] 

    /// <summary>
    /// Menu Tanımını İçermeyen XXXXXXler
    /// </summary>
    public  partial class NotIncludeSites : TerminologyManagerDef
    {
        public class NotIncludeSitesList : TTObjectCollection<NotIncludeSites> { }
                    
        public class ChildNotIncludeSitesCollection : TTObject.TTChildObjectCollection<NotIncludeSites>
        {
            public ChildNotIncludeSitesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNotIncludeSitesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Site
    /// </summary>
        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MenuDefinition MenuDefinition
        {
            get { return (MenuDefinition)((ITTObject)this).GetParent("MENUDEFINITION"); }
            set { this["MENUDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NotIncludeSites(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NotIncludeSites(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NotIncludeSites(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NotIncludeSites(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NotIncludeSites(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NOTINCLUDESITES", dataRow) { }
        protected NotIncludeSites(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NOTINCLUDESITES", dataRow, isImported) { }
        public NotIncludeSites(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NotIncludeSites(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NotIncludeSites() : base() { }

    }
}