
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencySurveyObject")] 

    /// <summary>
    /// Acil muayene ekranındaki genel değerlendirme tanımlamaları 
    /// </summary>
    public  partial class EmergencySurveyObject : TTObject
    {
        public class EmergencySurveyObjectList : TTObjectCollection<EmergencySurveyObject> { }
                    
        public class ChildEmergencySurveyObjectCollection : TTObject.TTChildObjectCollection<EmergencySurveyObject>
        {
            public ChildEmergencySurveyObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencySurveyObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EmergencySurveyDefinition EmergencySurveyDefinitions
        {
            get { return (EmergencySurveyDefinition)((ITTObject)this).GetParent("EMERGENCYSURVEYDEFINITIONS"); }
            set { this["EMERGENCYSURVEYDEFINITIONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencySpecialityObject EmergencySpecialityObject
        {
            get { return (EmergencySpecialityObject)((ITTObject)this).GetParent("EMERGENCYSPECIALITYOBJECT"); }
            set { this["EMERGENCYSPECIALITYOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EmergencySurveyObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencySurveyObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencySurveyObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencySurveyObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencySurveyObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYSURVEYOBJECT", dataRow) { }
        protected EmergencySurveyObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYSURVEYOBJECT", dataRow, isImported) { }
        public EmergencySurveyObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencySurveyObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencySurveyObject() : base() { }

    }
}