
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormSavedParam")] 

    public  partial class DynamicFormSavedParam : TTObject
    {
        public class DynamicFormSavedParamList : TTObjectCollection<DynamicFormSavedParam> { }
                    
        public class ChildDynamicFormSavedParamCollection : TTObject.TTChildObjectCollection<DynamicFormSavedParam>
        {
            public ChildDynamicFormSavedParamCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormSavedParamCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public DynamicFormRevisionParam DynamicFormRevisionParam
        {
            get { return (DynamicFormRevisionParam)((ITTObject)this).GetParent("DYNAMICFORMREVISIONPARAM"); }
            set { this["DYNAMICFORMREVISIONPARAM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DynamicFormSubmission DynamicFormSubmission
        {
            get { return (DynamicFormSubmission)((ITTObject)this).GetParent("DYNAMICFORMSUBMISSION"); }
            set { this["DYNAMICFORMSUBMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormSavedParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormSavedParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormSavedParam(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormSavedParam(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormSavedParam(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMSAVEDPARAM", dataRow) { }
        protected DynamicFormSavedParam(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMSAVEDPARAM", dataRow, isImported) { }
        public DynamicFormSavedParam(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormSavedParam(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormSavedParam() : base() { }

    }
}