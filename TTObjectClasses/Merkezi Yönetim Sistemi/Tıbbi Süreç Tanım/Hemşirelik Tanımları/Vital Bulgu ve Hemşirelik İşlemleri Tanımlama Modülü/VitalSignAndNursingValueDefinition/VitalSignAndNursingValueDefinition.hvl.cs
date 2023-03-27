
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VitalSignAndNursingValueDefinition")] 

    public  partial class VitalSignAndNursingValueDefinition : TTDefinitionSet
    {
        public class VitalSignAndNursingValueDefinitionList : TTObjectCollection<VitalSignAndNursingValueDefinition> { }
                    
        public class ChildVitalSignAndNursingValueDefinitionCollection : TTObject.TTChildObjectCollection<VitalSignAndNursingValueDefinition>
        {
            public ChildVitalSignAndNursingValueDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVitalSignAndNursingValueDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<VitalSignAndNursingValueDefinition> GetAllVitalSignDefValueList(TTObjectContext objectContext, string VITALSIGNANDNURSINGDEFINITIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VITALSIGNANDNURSINGVALUEDEFINITION"].QueryDefs["GetAllVitalSignDefValueList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("VITALSIGNANDNURSINGDEFINITIONID", VITALSIGNANDNURSINGDEFINITIONID);

            return ((ITTQuery)objectContext).QueryObjects<VitalSignAndNursingValueDefinition>(queryDef, paramList);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

        public VitalSignAndNursingDefinition VitalSignAndNursingDefinition
        {
            get { return (VitalSignAndNursingDefinition)((ITTObject)this).GetParent("VITALSIGNANDNURSINGDEFINITION"); }
            set { this["VITALSIGNANDNURSINGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VitalSignAndNursingValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VitalSignAndNursingValueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VitalSignAndNursingValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VitalSignAndNursingValueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VitalSignAndNursingValueDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VITALSIGNANDNURSINGVALUEDEFINITION", dataRow) { }
        protected VitalSignAndNursingValueDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VITALSIGNANDNURSINGVALUEDEFINITION", dataRow, isImported) { }
        public VitalSignAndNursingValueDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VitalSignAndNursingValueDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VitalSignAndNursingValueDefinition() : base() { }

    }
}