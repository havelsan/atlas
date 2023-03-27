
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METDistributionPlan")] 

    /// <summary>
    /// Dağıtım Planı
    /// </summary>
    public  partial class METDistributionPlan : TTObject
    {
        public class METDistributionPlanList : TTObjectCollection<METDistributionPlan> { }
                    
        public class ChildMETDistributionPlanCollection : TTObject.TTChildObjectCollection<METDistributionPlan>
        {
            public ChildMETDistributionPlanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETDistributionPlanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ad
    /// </summary>
        public string Alias
        {
            get { return (string)this["ALIAS"]; }
            set { this["ALIAS"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        virtual protected void CreateTargetsCollection()
        {
            _Targets = new METTargetDefault.ChildMETTargetDefaultCollection(this, new Guid("b4aed882-f891-4a37-a0ce-ec950465ede0"));
            ((ITTChildObjectCollection)_Targets).GetChildren();
        }

        protected METTargetDefault.ChildMETTargetDefaultCollection _Targets = null;
    /// <summary>
    /// Child collection for Dağıtım Planı Hedefler
    /// </summary>
        public METTargetDefault.ChildMETTargetDefaultCollection Targets
        {
            get
            {
                if (_Targets == null)
                    CreateTargetsCollection();
                return _Targets;
            }
        }

        protected METDistributionPlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METDistributionPlan(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METDistributionPlan(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METDistributionPlan(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METDistributionPlan(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METDISTRIBUTIONPLAN", dataRow) { }
        protected METDistributionPlan(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METDISTRIBUTIONPLAN", dataRow, isImported) { }
        public METDistributionPlan(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METDistributionPlan(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METDistributionPlan() : base() { }

    }
}