
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnouncementUserType")] 

    public  partial class AnnouncementUserType : TerminologyManagerDef
    {
        public class AnnouncementUserTypeList : TTObjectCollection<AnnouncementUserType> { }
                    
        public class ChildAnnouncementUserTypeCollection : TTObject.TTChildObjectCollection<AnnouncementUserType>
        {
            public ChildAnnouncementUserTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnouncementUserTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public UserTypeEnum? UserType
        {
            get { return (UserTypeEnum?)(int?)this["USERTYPE"]; }
            set { this["USERTYPE"] = value; }
        }

        public AnnouncementDefinition AnnouncementDefinition
        {
            get { return (AnnouncementDefinition)((ITTObject)this).GetParent("ANNOUNCEMENTDEFINITION"); }
            set { this["ANNOUNCEMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnnouncementUserType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnouncementUserType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnouncementUserType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnouncementUserType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnouncementUserType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNOUNCEMENTUSERTYPE", dataRow) { }
        protected AnnouncementUserType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNOUNCEMENTUSERTYPE", dataRow, isImported) { }
        public AnnouncementUserType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnouncementUserType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnouncementUserType() : base() { }

    }
}