
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingDischargingInstructionPlan")] 

    /// <summary>
    /// Hasta Taburculuk Planlama
    /// </summary>
    public  partial class BaseNursingDischargingInstructionPlan : BaseNursingDataEntry
    {
        public class BaseNursingDischargingInstructionPlanList : TTObjectCollection<BaseNursingDischargingInstructionPlan> { }
                    
        public class ChildBaseNursingDischargingInstructionPlanCollection : TTObject.TTChildObjectCollection<BaseNursingDischargingInstructionPlan>
        {
            public ChildBaseNursingDischargingInstructionPlanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingDischargingInstructionPlanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        virtual protected void CreateNursingDischargingInstructionPlansCollection()
        {
            _NursingDischargingInstructionPlans = new NursingDischargingInstructionPlan.ChildNursingDischargingInstructionPlanCollection(this, new Guid("cee4f544-2d6c-464a-b3c1-0467bcba3bb0"));
            ((ITTChildObjectCollection)_NursingDischargingInstructionPlans).GetChildren();
        }

        protected NursingDischargingInstructionPlan.ChildNursingDischargingInstructionPlanCollection _NursingDischargingInstructionPlans = null;
        public NursingDischargingInstructionPlan.ChildNursingDischargingInstructionPlanCollection NursingDischargingInstructionPlans
        {
            get
            {
                if (_NursingDischargingInstructionPlans == null)
                    CreateNursingDischargingInstructionPlansCollection();
                return _NursingDischargingInstructionPlans;
            }
        }

        protected BaseNursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingDischargingInstructionPlan(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingDischargingInstructionPlan(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGDISCHARGINGINSTRUCTIONPLAN", dataRow) { }
        protected BaseNursingDischargingInstructionPlan(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGDISCHARGINGINSTRUCTIONPLAN", dataRow, isImported) { }
        public BaseNursingDischargingInstructionPlan(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingDischargingInstructionPlan(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingDischargingInstructionPlan() : base() { }

    }
}