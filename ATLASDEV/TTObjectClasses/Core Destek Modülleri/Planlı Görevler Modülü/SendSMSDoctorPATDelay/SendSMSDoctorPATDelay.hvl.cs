
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSDoctorPATDelay")] 

    /// <summary>
    /// Patoloji Gecikmeleri için Doktora SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSDoctorPATDelay : BaseScheduledTask
    {
        public class SendSMSDoctorPATDelayList : TTObjectCollection<SendSMSDoctorPATDelay> { }
                    
        public class ChildSendSMSDoctorPATDelayCollection : TTObject.TTChildObjectCollection<SendSMSDoctorPATDelay>
        {
            public ChildSendSMSDoctorPATDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSDoctorPATDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSDoctorPATDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSDoctorPATDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSDoctorPATDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSDoctorPATDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSDoctorPATDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSDOCTORPATDELAY", dataRow) { }
        protected SendSMSDoctorPATDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSDOCTORPATDELAY", dataRow, isImported) { }
        public SendSMSDoctorPATDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSDoctorPATDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSDoctorPATDelay() : base() { }

    }
}