
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicFormSubmission")] 

    public  partial class DynamicFormSubmission : TTObject
    {
        public class DynamicFormSubmissionList : TTObjectCollection<DynamicFormSubmission> { }
                    
        public class ChildDynamicFormSubmissionCollection : TTObject.TTChildObjectCollection<DynamicFormSubmission>
        {
            public ChildDynamicFormSubmissionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicFormSubmissionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? UpdateDate
        {
            get { return (DateTime?)this["UPDATEDATE"]; }
            set { this["UPDATEDATE"] = value; }
        }

        public bool? IsEnable
        {
            get { return (bool?)this["ISENABLE"]; }
            set { this["ISENABLE"] = value; }
        }

        public DynamicFormRevision DynamicFormRevision
        {
            get { return (DynamicFormRevision)((ITTObject)this).GetParent("DYNAMICFORMREVISION"); }
            set { this["DYNAMICFORMREVISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser CreatedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("CREATEDBY"); }
            set { this["CREATEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicFormSubmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicFormSubmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicFormSubmission(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicFormSubmission(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicFormSubmission(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICFORMSUBMISSION", dataRow) { }
        protected DynamicFormSubmission(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICFORMSUBMISSION", dataRow, isImported) { }
        public DynamicFormSubmission(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicFormSubmission(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicFormSubmission() : base() { }

    }
}