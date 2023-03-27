
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GuncelSutFiyatTask")] 

    /// <summary>
    /// SUT Fiyat Güncelleme
    /// </summary>
    public  partial class GuncelSutFiyatTask : BaseScheduledTask
    {
        public class GuncelSutFiyatTaskList : TTObjectCollection<GuncelSutFiyatTask> { }
                    
        public class ChildGuncelSutFiyatTaskCollection : TTObject.TTChildObjectCollection<GuncelSutFiyatTask>
        {
            public ChildGuncelSutFiyatTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGuncelSutFiyatTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateGuncelSutFiyatUsersCollection()
        {
            _GuncelSutFiyatUsers = new GuncelSutFiyatUser.ChildGuncelSutFiyatUserCollection(this, new Guid("e1e278a9-82a0-4c5b-ae74-6190d0a6babd"));
            ((ITTChildObjectCollection)_GuncelSutFiyatUsers).GetChildren();
        }

        protected GuncelSutFiyatUser.ChildGuncelSutFiyatUserCollection _GuncelSutFiyatUsers = null;
        public GuncelSutFiyatUser.ChildGuncelSutFiyatUserCollection GuncelSutFiyatUsers
        {
            get
            {
                if (_GuncelSutFiyatUsers == null)
                    CreateGuncelSutFiyatUsersCollection();
                return _GuncelSutFiyatUsers;
            }
        }

        protected GuncelSutFiyatTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GuncelSutFiyatTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GuncelSutFiyatTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GuncelSutFiyatTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GuncelSutFiyatTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GUNCELSUTFIYATTASK", dataRow) { }
        protected GuncelSutFiyatTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GUNCELSUTFIYATTASK", dataRow, isImported) { }
        public GuncelSutFiyatTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GuncelSutFiyatTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GuncelSutFiyatTask() : base() { }

    }
}