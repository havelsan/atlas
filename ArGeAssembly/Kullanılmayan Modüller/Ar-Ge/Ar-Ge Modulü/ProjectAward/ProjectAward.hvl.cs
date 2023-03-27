
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectAward")] 

    public  partial class ProjectAward : TTObject
    {
        public class ProjectAwardList : TTObjectCollection<ProjectAward> { }
                    
        public class ChildProjectAwardCollection : TTObject.TTChildObjectCollection<ProjectAward>
        {
            public ChildProjectAwardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectAwardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Award
        {
            get { return (string)this["AWARD"]; }
            set { this["AWARD"] = value; }
        }

        public string GivingAuthority
        {
            get { return (string)this["GIVINGAUTHORITY"]; }
            set { this["GIVINGAUTHORITY"] = value; }
        }

        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

        public string WhyGived
        {
            get { return (string)this["WHYGIVED"]; }
            set { this["WHYGIVED"] = value; }
        }

        public ArgeProject Project
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("PROJECT"); }
            set { this["PROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectAward(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectAward(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectAward(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectAward(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectAward(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTAWARD", dataRow) { }
        protected ProjectAward(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTAWARD", dataRow, isImported) { }
        public ProjectAward(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectAward(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectAward() : base() { }

    }
}