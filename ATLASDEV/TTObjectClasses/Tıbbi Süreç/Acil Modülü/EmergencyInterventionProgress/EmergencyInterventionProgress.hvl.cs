
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyInterventionProgress")] 

    /// <summary>
    /// Acil Müdahale Müşahede Sekmesi
    /// </summary>
    public  partial class EmergencyInterventionProgress : TTObject
    {
        public class EmergencyInterventionProgressList : TTObjectCollection<EmergencyInterventionProgress> { }
                    
        public class ChildEmergencyInterventionProgressCollection : TTObject.TTChildObjectCollection<EmergencyInterventionProgress>
        {
            public ChildEmergencyInterventionProgressCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionProgressCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Müşahade Sekmesi
    /// </summary>
        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EmergencyInterventionProgress(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyInterventionProgress(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyInterventionProgress(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyInterventionProgress(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyInterventionProgress(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTIONPROGRESS", dataRow) { }
        protected EmergencyInterventionProgress(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTIONPROGRESS", dataRow, isImported) { }
        public EmergencyInterventionProgress(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyInterventionProgress(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyInterventionProgress() : base() { }

    }
}