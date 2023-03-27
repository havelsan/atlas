
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormRevisionParam")] 

    public  partial class DynamicFormRevisionParam : TTObject
    {
        public class DynamicFormRevisionParamList : TTObjectCollection<DynamicFormRevisionParam> { }
                    
        public class ChildDynamicFormRevisionParamCollection : TTObject.TTChildObjectCollection<DynamicFormRevisionParam>
        {
            public ChildDynamicFormRevisionParamCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormRevisionParamCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DynamicFormRevision DynamicFormRevision
        {
            get { return (DynamicFormRevision)((ITTObject)this).GetParent("DYNAMICFORMREVISION"); }
            set { this["DYNAMICFORMREVISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FormParam FormParam
        {
            get { return (FormParam)((ITTObject)this).GetParent("FORMPARAM"); }
            set { this["FORMPARAM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormRevisionParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormRevisionParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormRevisionParam(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormRevisionParam(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormRevisionParam(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMREVISIONPARAM", dataRow) { }
        protected DynamicFormRevisionParam(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMREVISIONPARAM", dataRow, isImported) { }
        public DynamicFormRevisionParam(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormRevisionParam(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormRevisionParam() : base() { }

    }
}