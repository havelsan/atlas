
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryAppointmentMaterial")] 

    public  partial class SurgeryAppointmentMaterial : TTObject
    {
        public class SurgeryAppointmentMaterialList : TTObjectCollection<SurgeryAppointmentMaterial> { }
                    
        public class ChildSurgeryAppointmentMaterialCollection : TTObject.TTChildObjectCollection<SurgeryAppointmentMaterial>
        {
            public ChildSurgeryAppointmentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryAppointmentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<SurgeryAppointmentMaterial> GetSurgeryAppointmentMaterials(TTObjectContext objectContext, string APPOINTMENTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYAPPOINTMENTMATERIAL"].QueryDefs["GetSurgeryAppointmentMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("APPOINTMENTID", APPOINTMENTID);

            return ((ITTQuery)objectContext).QueryObjects<SurgeryAppointmentMaterial>(queryDef, paramList);
        }

        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurgeryAppointment SurgeryAppointment
        {
            get { return (SurgeryAppointment)((ITTObject)this).GetParent("SURGERYAPPOINTMENT"); }
            set { this["SURGERYAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryAppointmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryAppointmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryAppointmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryAppointmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryAppointmentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYAPPOINTMENTMATERIAL", dataRow) { }
        protected SurgeryAppointmentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYAPPOINTMENTMATERIAL", dataRow, isImported) { }
        public SurgeryAppointmentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryAppointmentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryAppointmentMaterial() : base() { }

    }
}