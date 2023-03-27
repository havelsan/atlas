
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckLaboratoryWorkListFirstTime")] 

    /// <summary>
    /// Laboratouvar Kan Alma işleminin tanımlanan zaman parametresinde başlayıp başlamadığını kontrol eder. İşleme başlanmadıysa ilgili kullanıcılara SMS gönderilir. 
    /// </summary>
    public  partial class CheckLaboratoryWorkListFirstTime : BaseScheduledTask
    {
        public class CheckLaboratoryWorkListFirstTimeList : TTObjectCollection<CheckLaboratoryWorkListFirstTime> { }
                    
        public class ChildCheckLaboratoryWorkListFirstTimeCollection : TTObject.TTChildObjectCollection<CheckLaboratoryWorkListFirstTime>
        {
            public ChildCheckLaboratoryWorkListFirstTimeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckLaboratoryWorkListFirstTimeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKLABORATORYWORKLISTFIRSTTIME", dataRow) { }
        protected CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKLABORATORYWORKLISTFIRSTTIME", dataRow, isImported) { }
        public CheckLaboratoryWorkListFirstTime(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckLaboratoryWorkListFirstTime(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckLaboratoryWorkListFirstTime() : base() { }

    }
}