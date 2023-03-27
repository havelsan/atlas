
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckRadWorkListFirstTime")] 

    /// <summary>
    /// Radyoloji iş listesinde işleminin tanımlanan zaman parametresinde başlayıp başlamadığını kontrol eder. İşleme başlanmadıysa ilgili kullanıcılara SMS gönderilir. 
    /// </summary>
    public  partial class CheckRadWorkListFirstTime : BaseScheduledTask
    {
        public class CheckRadWorkListFirstTimeList : TTObjectCollection<CheckRadWorkListFirstTime> { }
                    
        public class ChildCheckRadWorkListFirstTimeCollection : TTObject.TTChildObjectCollection<CheckRadWorkListFirstTime>
        {
            public ChildCheckRadWorkListFirstTimeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckRadWorkListFirstTimeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CheckRadWorkListFirstTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckRadWorkListFirstTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckRadWorkListFirstTime(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckRadWorkListFirstTime(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckRadWorkListFirstTime(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKRADWORKLISTFIRSTTIME", dataRow) { }
        protected CheckRadWorkListFirstTime(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKRADWORKLISTFIRSTTIME", dataRow, isImported) { }
        public CheckRadWorkListFirstTime(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckRadWorkListFirstTime(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckRadWorkListFirstTime() : base() { }

    }
}