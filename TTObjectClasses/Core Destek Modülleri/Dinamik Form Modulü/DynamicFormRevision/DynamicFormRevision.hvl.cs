
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormRevision")] 

    public  partial class DynamicFormRevision : TTObject
    {
        public class DynamicFormRevisionList : TTObjectCollection<DynamicFormRevision> { }
                    
        public class ChildDynamicFormRevisionCollection : TTObject.TTChildObjectCollection<DynamicFormRevision>
        {
            public ChildDynamicFormRevisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormRevisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

        public int? RevisionNumber
        {
            get { return (int?)this["REVISIONNUMBER"]; }
            set { this["REVISIONNUMBER"] = value; }
        }

        public bool? IsMain
        {
            get { return (bool?)this["ISMAIN"]; }
            set { this["ISMAIN"] = value; }
        }

        public object JsonTemplate
        {
            get { return (object)this["JSONTEMPLATE"]; }
            set { this["JSONTEMPLATE"] = value; }
        }

        public DateTime? UpdateDate
        {
            get { return (DateTime?)this["UPDATEDATE"]; }
            set { this["UPDATEDATE"] = value; }
        }

        public DynamicForm DynamicFormId
        {
            get { return (DynamicForm)((ITTObject)this).GetParent("DYNAMICFORMID"); }
            set { this["DYNAMICFORMID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormRevision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormRevision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormRevision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormRevision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormRevision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMREVISION", dataRow) { }
        protected DynamicFormRevision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMREVISION", dataRow, isImported) { }
        public DynamicFormRevision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormRevision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormRevision() : base() { }

    }
}