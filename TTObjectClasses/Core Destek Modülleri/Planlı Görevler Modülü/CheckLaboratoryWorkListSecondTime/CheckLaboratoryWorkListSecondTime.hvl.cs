
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckLaboratoryWorkListSecondTime")] 

    /// <summary>
    /// Laboratouvar Kan Alma işleminin tanımlanan zaman parametresinde başlayıp başlamadığını kontrol eder. İşleme başlanmadıysa ilgili kullanıcılara SMS gönderilir. 
    /// </summary>
    public  partial class CheckLaboratoryWorkListSecondTime : BaseScheduledTask
    {
        public class CheckLaboratoryWorkListSecondTimeList : TTObjectCollection<CheckLaboratoryWorkListSecondTime> { }
                    
        public class ChildCheckLaboratoryWorkListSecondTimeCollection : TTObject.TTChildObjectCollection<CheckLaboratoryWorkListSecondTime>
        {
            public ChildCheckLaboratoryWorkListSecondTimeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckLaboratoryWorkListSecondTimeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKLABORATORYWORKLISTSECONDTIME", dataRow) { }
        protected CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKLABORATORYWORKLISTSECONDTIME", dataRow, isImported) { }
        public CheckLaboratoryWorkListSecondTime(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckLaboratoryWorkListSecondTime(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckLaboratoryWorkListSecondTime() : base() { }

    }
}