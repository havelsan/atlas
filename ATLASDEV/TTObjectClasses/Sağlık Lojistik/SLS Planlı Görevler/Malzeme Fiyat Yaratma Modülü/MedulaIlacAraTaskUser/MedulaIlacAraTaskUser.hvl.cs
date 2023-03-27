
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaIlacAraTaskUser")] 

    public  partial class MedulaIlacAraTaskUser : TTObject
    {
        public class MedulaIlacAraTaskUserList : TTObjectCollection<MedulaIlacAraTaskUser> { }
                    
        public class ChildMedulaIlacAraTaskUserCollection : TTObject.TTChildObjectCollection<MedulaIlacAraTaskUser>
        {
            public ChildMedulaIlacAraTaskUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaIlacAraTaskUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedulaIlacAraTask MedulaIlacAraTask
        {
            get { return (MedulaIlacAraTask)((ITTObject)this).GetParent("MEDULAILACARATASK"); }
            set { this["MEDULAILACARATASK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaIlacAraTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaIlacAraTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaIlacAraTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaIlacAraTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaIlacAraTaskUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAILACARATASKUSER", dataRow) { }
        protected MedulaIlacAraTaskUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAILACARATASKUSER", dataRow, isImported) { }
        public MedulaIlacAraTaskUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaIlacAraTaskUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaIlacAraTaskUser() : base() { }

    }
}