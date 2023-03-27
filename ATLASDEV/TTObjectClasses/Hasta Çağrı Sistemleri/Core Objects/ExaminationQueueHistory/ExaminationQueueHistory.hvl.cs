
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationQueueHistory")] 

    /// <summary>
    /// Eski Randevu Sırası Nesnesi
    /// </summary>
    public  partial class ExaminationQueueHistory : TTObject
    {
        public class ExaminationQueueHistoryList : TTObjectCollection<ExaminationQueueHistory> { }
                    
        public class ChildExaminationQueueHistoryCollection : TTObject.TTChildObjectCollection<ExaminationQueueHistory>
        {
            public ChildExaminationQueueHistoryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationQueueHistoryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çağrılacağı Zaman
    /// </summary>
        public DateTime? CallTime
        {
            get { return (DateTime?)this["CALLTIME"]; }
            set { this["CALLTIME"] = value; }
        }

    /// <summary>
    /// Ötelenmiş Zaman
    /// </summary>
        public DateTime? DivertedTime
        {
            get { return (DateTime?)this["DIVERTEDTIME"]; }
            set { this["DIVERTEDTIME"] = value; }
        }

    /// <summary>
    /// Öncelik
    /// </summary>
        public long? Priority
        {
            get { return (long?)this["PRIORITY"]; }
            set { this["PRIORITY"] = value; }
        }

    /// <summary>
    /// Yaratılma Tarihi
    /// </summary>
        public DateTime? QueueDate
        {
            get { return (DateTime?)this["QUEUEDATE"]; }
            set { this["QUEUEDATE"] = value; }
        }

        public DateTime? HistoryDate
        {
            get { return (DateTime?)this["HISTORYDATE"]; }
            set { this["HISTORYDATE"] = value; }
        }

        public Appointment Appointment
        {
            get { return (Appointment)((ITTObject)this).GetParent("APPOINTMENT"); }
            set { this["APPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayene Odası
    /// </summary>
        public Resource DestinationResource
        {
            get { return (Resource)((ITTObject)this).GetParent("DESTINATIONRESOURCE"); }
            set { this["DESTINATIONRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExaminationQueueDefinition ExaminationQueueDefinition
        {
            get { return (ExaminationQueueDefinition)((ITTObject)this).GetParent("EXAMINATIONQUEUEDEFINITION"); }
            set { this["EXAMINATIONQUEUEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExaminationQueueItem ExaminationQueueItem
        {
            get { return (ExaminationQueueItem)((ITTObject)this).GetParent("EXAMINATIONQUEUEITEM"); }
            set { this["EXAMINATIONQUEUEITEM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser CompletedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("COMPLETEDBY"); }
            set { this["COMPLETEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubactionProcedureFlowable SubactionProcedureFlowable
        {
            get { return (SubactionProcedureFlowable)((ITTObject)this).GetParent("SUBACTIONPROCEDUREFLOWABLE"); }
            set { this["SUBACTIONPROCEDUREFLOWABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExaminationQueueHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationQueueHistory(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationQueueHistory(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationQueueHistory(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationQueueHistory(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONQUEUEHISTORY", dataRow) { }
        protected ExaminationQueueHistory(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONQUEUEHISTORY", dataRow, isImported) { }
        public ExaminationQueueHistory(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationQueueHistory(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationQueueHistory() : base() { }

    }
}