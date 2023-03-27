
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingDischargingInstructionPlan")] 

    public  partial class NursingDischargingInstructionPlan : TTObject
    {
        public class NursingDischargingInstructionPlanList : TTObjectCollection<NursingDischargingInstructionPlan> { }
                    
        public class ChildNursingDischargingInstructionPlanCollection : TTObject.TTChildObjectCollection<NursingDischargingInstructionPlan>
        {
            public ChildNursingDischargingInstructionPlanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingDischargingInstructionPlanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Evet/Hayır
    /// </summary>
        public bool? PatientGetInstruction
        {
            get { return (bool?)this["PATIENTGETINSTRUCTION"]; }
            set { this["PATIENTGETINSTRUCTION"] = value; }
        }

    /// <summary>
    /// Taburculuk Eğitim Planı
    /// </summary>
        public DischargingInstructionPlanDefinition DischargingInstructionPlan
        {
            get { return (DischargingInstructionPlanDefinition)((ITTObject)this).GetParent("DISCHARGINGINSTRUCTIONPLAN"); }
            set { this["DISCHARGINGINSTRUCTIONPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseNursingDischargingInstructionPlan BaseDischargingPlan
        {
            get { return (BaseNursingDischargingInstructionPlan)((ITTObject)this).GetParent("BASEDISCHARGINGPLAN"); }
            set { this["BASEDISCHARGINGPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingDischargingInstructionPlan(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGDISCHARGINGINSTRUCTIONPLAN", dataRow) { }
        protected NursingDischargingInstructionPlan(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGDISCHARGINGINSTRUCTIONPLAN", dataRow, isImported) { }
        public NursingDischargingInstructionPlan(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingDischargingInstructionPlan(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingDischargingInstructionPlan() : base() { }

    }
}