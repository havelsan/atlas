
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugUpdateTaskUser")] 

    /// <summary>
    /// İlaç Güncelleme Bildirim Kullanıcısı
    /// </summary>
    public  partial class DrugUpdateTaskUser : TTObject
    {
        public class DrugUpdateTaskUserList : TTObjectCollection<DrugUpdateTaskUser> { }
                    
        public class ChildDrugUpdateTaskUserCollection : TTObject.TTChildObjectCollection<DrugUpdateTaskUser>
        {
            public ChildDrugUpdateTaskUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugUpdateTaskUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugUpdateFromAuditsTask DrugUpdateFromAuditsTask
        {
            get { return (DrugUpdateFromAuditsTask)((ITTObject)this).GetParent("DRUGUPDATEFROMAUDITSTASK"); }
            set { this["DRUGUPDATEFROMAUDITSTASK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugUpdateTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugUpdateTaskUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugUpdateTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugUpdateTaskUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugUpdateTaskUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGUPDATETASKUSER", dataRow) { }
        protected DrugUpdateTaskUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGUPDATETASKUSER", dataRow, isImported) { }
        public DrugUpdateTaskUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugUpdateTaskUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugUpdateTaskUser() : base() { }

    }
}