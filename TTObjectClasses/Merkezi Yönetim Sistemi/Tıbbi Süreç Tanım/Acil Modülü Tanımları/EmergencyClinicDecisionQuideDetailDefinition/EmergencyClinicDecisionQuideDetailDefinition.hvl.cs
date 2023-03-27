
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyClinicDecisionQuideDetailDefinition")] 

    public  partial class EmergencyClinicDecisionQuideDetailDefinition : TTDefinitionSet
    {
        public class EmergencyClinicDecisionQuideDetailDefinitionList : TTObjectCollection<EmergencyClinicDecisionQuideDetailDefinition> { }
                    
        public class ChildEmergencyClinicDecisionQuideDetailDefinitionCollection : TTObject.TTChildObjectCollection<EmergencyClinicDecisionQuideDetailDefinition>
        {
            public ChildEmergencyClinicDecisionQuideDetailDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyClinicDecisionQuideDetailDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Detay kriterinin soru sorma tipi bilgisi tutulur.
    /// </summary>
        public ClinicalDecisionDetailQuestionTypeEnum? QuestionType
        {
            get { return (ClinicalDecisionDetailQuestionTypeEnum?)(int?)this["QUESTIONTYPE"]; }
            set { this["QUESTIONTYPE"] = value; }
        }

        public EmergencyClinicDecisionQuideDefinition EMClinicDecisionQuideDef
        {
            get { return (EmergencyClinicDecisionQuideDefinition)((ITTObject)this).GetParent("EMCLINICDECISIONQUIDEDEF"); }
            set { this["EMCLINICDECISIONQUIDEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEMClinicalDecisionCollection()
        {
            _EMClinicalDecision = new EmergencyInterventionClinicalDecision.ChildEmergencyInterventionClinicalDecisionCollection(this, new Guid("d588ca1a-0893-4f6a-8515-915687dd60c7"));
            ((ITTChildObjectCollection)_EMClinicalDecision).GetChildren();
        }

        protected EmergencyInterventionClinicalDecision.ChildEmergencyInterventionClinicalDecisionCollection _EMClinicalDecision = null;
        public EmergencyInterventionClinicalDecision.ChildEmergencyInterventionClinicalDecisionCollection EMClinicalDecision
        {
            get
            {
                if (_EMClinicalDecision == null)
                    CreateEMClinicalDecisionCollection();
                return _EMClinicalDecision;
            }
        }

        protected EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYCLINICDECISIONQUIDEDETAILDEFINITION", dataRow) { }
        protected EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYCLINICDECISIONQUIDEDETAILDEFINITION", dataRow, isImported) { }
        public EmergencyClinicDecisionQuideDetailDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyClinicDecisionQuideDetailDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyClinicDecisionQuideDetailDefinition() : base() { }

    }
}