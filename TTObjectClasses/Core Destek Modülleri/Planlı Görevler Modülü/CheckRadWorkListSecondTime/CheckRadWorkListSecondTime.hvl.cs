
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckRadWorkListSecondTime")] 

    /// <summary>
    /// Radyoloji iş listesinde işleminin tanımlanan zaman parametresinde başlayıp başlamadığını kontrol eder. İşleme başlanmadıysa ilgili kullanıcılara SMS gönderilir. 
    /// </summary>
    public  partial class CheckRadWorkListSecondTime : BaseScheduledTask
    {
        public class CheckRadWorkListSecondTimeList : TTObjectCollection<CheckRadWorkListSecondTime> { }
                    
        public class ChildCheckRadWorkListSecondTimeCollection : TTObject.TTChildObjectCollection<CheckRadWorkListSecondTime>
        {
            public ChildCheckRadWorkListSecondTimeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckRadWorkListSecondTimeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CheckRadWorkListSecondTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckRadWorkListSecondTime(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckRadWorkListSecondTime(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckRadWorkListSecondTime(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckRadWorkListSecondTime(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKRADWORKLISTSECONDTIME", dataRow) { }
        protected CheckRadWorkListSecondTime(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKRADWORKLISTSECONDTIME", dataRow, isImported) { }
        public CheckRadWorkListSecondTime(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckRadWorkListSecondTime(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckRadWorkListSecondTime() : base() { }

    }
}