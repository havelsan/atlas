
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugUpdateFromAuditsTask")] 

    /// <summary>
    /// İlaç Fiyat Güncelleme
    /// </summary>
    public  partial class DrugUpdateFromAuditsTask : BaseScheduledTask
    {
        public class DrugUpdateFromAuditsTaskList : TTObjectCollection<DrugUpdateFromAuditsTask> { }
                    
        public class ChildDrugUpdateFromAuditsTaskCollection : TTObject.TTChildObjectCollection<DrugUpdateFromAuditsTask>
        {
            public ChildDrugUpdateFromAuditsTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugUpdateFromAuditsTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateTaskUsersCollection()
        {
            _TaskUsers = new DrugUpdateTaskUser.ChildDrugUpdateTaskUserCollection(this, new Guid("117e0a50-2149-4ef2-8759-55d16a068f58"));
            ((ITTChildObjectCollection)_TaskUsers).GetChildren();
        }

        protected DrugUpdateTaskUser.ChildDrugUpdateTaskUserCollection _TaskUsers = null;
        public DrugUpdateTaskUser.ChildDrugUpdateTaskUserCollection TaskUsers
        {
            get
            {
                if (_TaskUsers == null)
                    CreateTaskUsersCollection();
                return _TaskUsers;
            }
        }

        protected DrugUpdateFromAuditsTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugUpdateFromAuditsTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugUpdateFromAuditsTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugUpdateFromAuditsTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugUpdateFromAuditsTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGUPDATEFROMAUDITSTASK", dataRow) { }
        protected DrugUpdateFromAuditsTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGUPDATEFROMAUDITSTASK", dataRow, isImported) { }
        public DrugUpdateFromAuditsTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugUpdateFromAuditsTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugUpdateFromAuditsTask() : base() { }

    }
}