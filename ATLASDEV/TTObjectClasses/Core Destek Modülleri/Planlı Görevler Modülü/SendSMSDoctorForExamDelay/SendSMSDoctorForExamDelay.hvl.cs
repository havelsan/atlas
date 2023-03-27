
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSDoctorForExamDelay")] 

    /// <summary>
    /// Poliklinik Muayeneleri Gecikmesi için Doktora SMS Gönderme İşlemi
    /// </summary>
    public  partial class SendSMSDoctorForExamDelay : BaseScheduledTask
    {
        public class SendSMSDoctorForExamDelayList : TTObjectCollection<SendSMSDoctorForExamDelay> { }
                    
        public class ChildSendSMSDoctorForExamDelayCollection : TTObject.TTChildObjectCollection<SendSMSDoctorForExamDelay>
        {
            public ChildSendSMSDoctorForExamDelayCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSDoctorForExamDelayCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SendSMSDoctorForExamDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSDoctorForExamDelay(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSDoctorForExamDelay(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSDoctorForExamDelay(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSDoctorForExamDelay(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSDOCTORFOREXAMDELAY", dataRow) { }
        protected SendSMSDoctorForExamDelay(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSDOCTORFOREXAMDELAY", dataRow, isImported) { }
        public SendSMSDoctorForExamDelay(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSDoctorForExamDelay(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSDoctorForExamDelay() : base() { }

    }
}