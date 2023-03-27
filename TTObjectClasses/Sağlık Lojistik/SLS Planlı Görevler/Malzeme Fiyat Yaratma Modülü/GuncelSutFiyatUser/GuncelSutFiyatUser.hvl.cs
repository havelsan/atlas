
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GuncelSutFiyatUser")] 

    public  partial class GuncelSutFiyatUser : TTObject
    {
        public class GuncelSutFiyatUserList : TTObjectCollection<GuncelSutFiyatUser> { }
                    
        public class ChildGuncelSutFiyatUserCollection : TTObject.TTChildObjectCollection<GuncelSutFiyatUser>
        {
            public ChildGuncelSutFiyatUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGuncelSutFiyatUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public GuncelSutFiyatTask GuncelSutFiyatTask
        {
            get { return (GuncelSutFiyatTask)((ITTObject)this).GetParent("GUNCELSUTFIYATTASK"); }
            set { this["GUNCELSUTFIYATTASK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GuncelSutFiyatUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GuncelSutFiyatUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GuncelSutFiyatUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GuncelSutFiyatUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GuncelSutFiyatUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GUNCELSUTFIYATUSER", dataRow) { }
        protected GuncelSutFiyatUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GUNCELSUTFIYATUSER", dataRow, isImported) { }
        public GuncelSutFiyatUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GuncelSutFiyatUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GuncelSutFiyatUser() : base() { }

    }
}