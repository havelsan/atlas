
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaIlacAraTask")] 

    /// <summary>
    /// Medula İlaç Fiyat Güncelleme
    /// </summary>
    public  partial class MedulaIlacAraTask : BaseScheduledTask
    {
        public class MedulaIlacAraTaskList : TTObjectCollection<MedulaIlacAraTask> { }
                    
        public class ChildMedulaIlacAraTaskCollection : TTObject.TTChildObjectCollection<MedulaIlacAraTask>
        {
            public ChildMedulaIlacAraTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaIlacAraTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateMedulaIlacAraTaskUsersCollection()
        {
            _MedulaIlacAraTaskUsers = new MedulaIlacAraTaskUser.ChildMedulaIlacAraTaskUserCollection(this, new Guid("8b59e97f-f048-4004-9950-21edd2fff1bb"));
            ((ITTChildObjectCollection)_MedulaIlacAraTaskUsers).GetChildren();
        }

        protected MedulaIlacAraTaskUser.ChildMedulaIlacAraTaskUserCollection _MedulaIlacAraTaskUsers = null;
        public MedulaIlacAraTaskUser.ChildMedulaIlacAraTaskUserCollection MedulaIlacAraTaskUsers
        {
            get
            {
                if (_MedulaIlacAraTaskUsers == null)
                    CreateMedulaIlacAraTaskUsersCollection();
                return _MedulaIlacAraTaskUsers;
            }
        }

        protected MedulaIlacAraTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaIlacAraTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaIlacAraTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaIlacAraTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaIlacAraTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAILACARATASK", dataRow) { }
        protected MedulaIlacAraTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAILACARATASK", dataRow, isImported) { }
        public MedulaIlacAraTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaIlacAraTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaIlacAraTask() : base() { }

    }
}