
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendMessageToPatient")] 

    /// <summary>
    /// HastaMesajGonder methodu için kullanılan object
    /// </summary>
    public  partial class SendMessageToPatient : TTObject
    {
        public class SendMessageToPatientList : TTObjectCollection<SendMessageToPatient> { }
                    
        public class ChildSendMessageToPatientCollection : TTObject.TTChildObjectCollection<SendMessageToPatient>
        {
            public ChildSendMessageToPatientCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendMessageToPatientCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mesaj Detayı
    /// </summary>
        public string MessageInfo
        {
            get { return (string)this["MESSAGEINFO"]; }
            set { this["MESSAGEINFO"] = value; }
        }

    /// <summary>
    /// Mesaj Tarihi
    /// </summary>
        public DateTime? MessageDate
        {
            get { return (DateTime?)this["MESSAGEDATE"]; }
            set { this["MESSAGEDATE"] = value; }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSHastaMesajlari SKRSHastaMesajlari
        {
            get { return (SKRSHastaMesajlari)((ITTObject)this).GetParent("SKRSHASTAMESAJLARI"); }
            set { this["SKRSHASTAMESAJLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SendMessageToPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendMessageToPatient(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendMessageToPatient(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendMessageToPatient(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendMessageToPatient(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDMESSAGETOPATIENT", dataRow) { }
        protected SendMessageToPatient(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDMESSAGETOPATIENT", dataRow, isImported) { }
        public SendMessageToPatient(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendMessageToPatient(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendMessageToPatient() : base() { }

    }
}