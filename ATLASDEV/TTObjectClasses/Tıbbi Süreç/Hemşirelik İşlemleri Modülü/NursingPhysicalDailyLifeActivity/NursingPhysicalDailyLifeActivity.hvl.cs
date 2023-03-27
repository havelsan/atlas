
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingPhysicalDailyLifeActivity")] 

    public  partial class NursingPhysicalDailyLifeActivity : NursingDailyLifeActivity
    {
        public class NursingPhysicalDailyLifeActivityList : TTObjectCollection<NursingPhysicalDailyLifeActivity> { }
                    
        public class ChildNursingPhysicalDailyLifeActivityCollection : TTObject.TTChildObjectCollection<NursingPhysicalDailyLifeActivity>
        {
            public ChildNursingPhysicalDailyLifeActivityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingPhysicalDailyLifeActivityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public NursingDailyLifeActivityEnum? ExistState
        {
            get { return (NursingDailyLifeActivityEnum?)(int?)this["EXISTSTATE"]; }
            set { this["EXISTSTATE"] = value; }
        }

        protected NursingPhysicalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingPhysicalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingPhysicalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingPhysicalDailyLifeActivity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingPhysicalDailyLifeActivity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPHYSICALDAILYLIFEACTIVITY", dataRow) { }
        protected NursingPhysicalDailyLifeActivity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPHYSICALDAILYLIFEACTIVITY", dataRow, isImported) { }
        public NursingPhysicalDailyLifeActivity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingPhysicalDailyLifeActivity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingPhysicalDailyLifeActivity() : base() { }

    }
}