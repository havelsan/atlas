
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendNabizWithResponceCode")] 

    /// <summary>
    /// Hata Almış Nabız Satırlarını Tekrar Kuyruğa Ekler
    /// </summary>
    public  partial class SendNabizWithResponceCode : BaseScheduledTask
    {
        public class SendNabizWithResponceCodeList : TTObjectCollection<SendNabizWithResponceCode> { }
                    
        public class ChildSendNabizWithResponceCodeCollection : TTObject.TTChildObjectCollection<SendNabizWithResponceCode>
        {
            public ChildSendNabizWithResponceCodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendNabizWithResponceCodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendNabizWithResponceCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendNabizWithResponceCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendNabizWithResponceCode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendNabizWithResponceCode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendNabizWithResponceCode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDNABIZWITHRESPONCECODE", dataRow) { }
        protected SendNabizWithResponceCode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDNABIZWITHRESPONCECODE", dataRow, isImported) { }
        public SendNabizWithResponceCode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendNabizWithResponceCode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendNabizWithResponceCode() : base() { }

    }
}