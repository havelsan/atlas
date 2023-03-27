
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTempDoctors")] 

    public  partial class RadiologyTempDoctors : TTObject
    {
        public class RadiologyTempDoctorsList : TTObjectCollection<RadiologyTempDoctors> { }
                    
        public class ChildRadiologyTempDoctorsCollection : TTObject.TTChildObjectCollection<RadiologyTempDoctors>
        {
            public ChildRadiologyTempDoctorsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTempDoctorsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTemplate RadiologyTemplate
        {
            get { return (RadiologyTemplate)((ITTObject)this).GetParent("RADIOLOGYTEMPLATE"); }
            set { this["RADIOLOGYTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyTempDoctors(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTempDoctors(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTempDoctors(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTempDoctors(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTempDoctors(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTEMPDOCTORS", dataRow) { }
        protected RadiologyTempDoctors(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTEMPDOCTORS", dataRow, isImported) { }
        public RadiologyTempDoctors(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTempDoctors(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTempDoctors() : base() { }

    }
}