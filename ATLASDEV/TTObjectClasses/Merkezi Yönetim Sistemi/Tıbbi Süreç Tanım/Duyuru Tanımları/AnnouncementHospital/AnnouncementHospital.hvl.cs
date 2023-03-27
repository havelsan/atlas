
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnouncementHospital")] 

    public  partial class AnnouncementHospital : TerminologyManagerDef
    {
        public class AnnouncementHospitalList : TTObjectCollection<AnnouncementHospital> { }
                    
        public class ChildAnnouncementHospitalCollection : TTObject.TTChildObjectCollection<AnnouncementHospital>
        {
            public ChildAnnouncementHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnouncementHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public AnnouncementDefinition AnnouncementDefinition
        {
            get { return (AnnouncementDefinition)((ITTObject)this).GetParent("ANNOUNCEMENTDEFINITION"); }
            set { this["ANNOUNCEMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnnouncementHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnouncementHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnouncementHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnouncementHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnouncementHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNOUNCEMENTHOSPITAL", dataRow) { }
        protected AnnouncementHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNOUNCEMENTHOSPITAL", dataRow, isImported) { }
        public AnnouncementHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnouncementHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnouncementHospital() : base() { }

    }
}