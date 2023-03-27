
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyInterventionClinicalDecision")] 

    public  partial class EmergencyInterventionClinicalDecision : TTObject
    {
        public class EmergencyInterventionClinicalDecisionList : TTObjectCollection<EmergencyInterventionClinicalDecision> { }
                    
        public class ChildEmergencyInterventionClinicalDecisionCollection : TTObject.TTChildObjectCollection<EmergencyInterventionClinicalDecision>
        {
            public ChildEmergencyInterventionClinicalDecisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionClinicalDecisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? DecisionValue
        {
            get { return (int?)this["DECISIONVALUE"]; }
            set { this["DECISIONVALUE"] = value; }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencyClinicDecisionQuideDetailDefinition EMClinicDecisionQuideDetDef
        {
            get { return (EmergencyClinicDecisionQuideDetailDefinition)((ITTObject)this).GetParent("EMCLINICDECISIONQUIDEDETDEF"); }
            set { this["EMCLINICDECISIONQUIDEDETDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EmergencyInterventionClinicalDecision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyInterventionClinicalDecision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyInterventionClinicalDecision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyInterventionClinicalDecision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyInterventionClinicalDecision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTIONCLINICALDECISION", dataRow) { }
        protected EmergencyInterventionClinicalDecision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTIONCLINICALDECISION", dataRow, isImported) { }
        public EmergencyInterventionClinicalDecision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyInterventionClinicalDecision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyInterventionClinicalDecision() : base() { }

    }
}