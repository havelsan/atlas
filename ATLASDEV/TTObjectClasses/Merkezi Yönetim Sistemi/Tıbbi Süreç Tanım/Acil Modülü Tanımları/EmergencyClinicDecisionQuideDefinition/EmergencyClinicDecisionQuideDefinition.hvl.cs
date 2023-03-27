
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyClinicDecisionQuideDefinition")] 

    public  partial class EmergencyClinicDecisionQuideDefinition : TTDefinitionSet
    {
        public class EmergencyClinicDecisionQuideDefinitionList : TTObjectCollection<EmergencyClinicDecisionQuideDefinition> { }
                    
        public class ChildEmergencyClinicDecisionQuideDefinitionCollection : TTObject.TTChildObjectCollection<EmergencyClinicDecisionQuideDefinition>
        {
            public ChildEmergencyClinicDecisionQuideDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyClinicDecisionQuideDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisDefinition.ChildDiagnosisDefinitionCollection(this, new Guid("38444d95-566d-49d3-adae-bf5c38f1e41c"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected DiagnosisDefinition.ChildDiagnosisDefinitionCollection _Diagnosis = null;
        public DiagnosisDefinition.ChildDiagnosisDefinitionCollection Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    CreateDiagnosisCollection();
                return _Diagnosis;
            }
        }

        virtual protected void CreateEMClinicDecisionQuideDetailsCollection()
        {
            _EMClinicDecisionQuideDetails = new EmergencyClinicDecisionQuideDetailDefinition.ChildEmergencyClinicDecisionQuideDetailDefinitionCollection(this, new Guid("9f2c2ca1-dc12-44ce-8ec5-7afbd20911e0"));
            ((ITTChildObjectCollection)_EMClinicDecisionQuideDetails).GetChildren();
        }

        protected EmergencyClinicDecisionQuideDetailDefinition.ChildEmergencyClinicDecisionQuideDetailDefinitionCollection _EMClinicDecisionQuideDetails = null;
        public EmergencyClinicDecisionQuideDetailDefinition.ChildEmergencyClinicDecisionQuideDetailDefinitionCollection EMClinicDecisionQuideDetails
        {
            get
            {
                if (_EMClinicDecisionQuideDetails == null)
                    CreateEMClinicDecisionQuideDetailsCollection();
                return _EMClinicDecisionQuideDetails;
            }
        }

        protected EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYCLINICDECISIONQUIDEDEFINITION", dataRow) { }
        protected EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYCLINICDECISIONQUIDEDEFINITION", dataRow, isImported) { }
        public EmergencyClinicDecisionQuideDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyClinicDecisionQuideDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyClinicDecisionQuideDefinition() : base() { }

    }
}