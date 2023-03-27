
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Complaint")] 

    /// <summary>
    /// Şikayet Gridi
    /// </summary>
    public  partial class Complaint : TTObject
    {
        public class ComplaintList : TTObjectCollection<Complaint> { }
                    
        public class ChildComplaintCollection : TTObject.TTChildObjectCollection<Complaint>
        {
            public ChildComplaintCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildComplaintCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Şikayetin Girildiği Tarih
    /// </summary>
        public DateTime? ComplaintDate
        {
            get { return (DateTime?)this["COMPLAINTDATE"]; }
            set { this["COMPLAINTDATE"] = value; }
        }

    /// <summary>
    /// Şikayet Süresi
    /// </summary>
        public int? ComplaintDuration
        {
            get { return (int?)this["COMPLAINTDURATION"]; }
            set { this["COMPLAINTDURATION"] = value; }
        }

        public UnitOfTimeEnum? ComplaintDurationType
        {
            get { return (UnitOfTimeEnum?)(int?)this["COMPLAINTDURATIONTYPE"]; }
            set { this["COMPLAINTDURATIONTYPE"] = value; }
        }

        public ComplaintDefinition ComplaintDefinition
        {
            get { return (ComplaintDefinition)((ITTObject)this).GetParent("COMPLAINTDEFINITION"); }
            set { this["COMPLAINTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Complaint(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Complaint(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Complaint(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Complaint(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Complaint(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMPLAINT", dataRow) { }
        protected Complaint(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMPLAINT", dataRow, isImported) { }
        public Complaint(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Complaint(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Complaint() : base() { }

    }
}