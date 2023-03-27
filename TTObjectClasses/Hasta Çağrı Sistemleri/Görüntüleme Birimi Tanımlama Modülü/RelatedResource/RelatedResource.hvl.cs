
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RelatedResource")] 

    public  partial class RelatedResource : TTObject
    {
        public class RelatedResourceList : TTObjectCollection<RelatedResource> { }
                    
        public class ChildRelatedResourceCollection : TTObject.TTChildObjectCollection<RelatedResource>
        {
            public ChildRelatedResourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRelatedResourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AppointmentViewerCompDef AppointmentViewerCompDef
        {
            get { return (AppointmentViewerCompDef)((ITTObject)this).GetParent("APPOINTMENTVIEWERCOMPDEF"); }
            set { this["APPOINTMENTVIEWERCOMPDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RelatedResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RelatedResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RelatedResource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RelatedResource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RelatedResource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RELATEDRESOURCE", dataRow) { }
        protected RelatedResource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RELATEDRESOURCE", dataRow, isImported) { }
        public RelatedResource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RelatedResource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RelatedResource() : base() { }

    }
}