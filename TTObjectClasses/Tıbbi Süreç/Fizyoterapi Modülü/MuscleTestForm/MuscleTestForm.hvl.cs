
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuscleTestForm")] 

    /// <summary>
    /// Adele Testi
    /// </summary>
    public  partial class MuscleTestForm : BaseAdditionalInfo
    {
        public class MuscleTestFormList : TTObjectCollection<MuscleTestForm> { }
                    
        public class ChildMuscleTestFormCollection : TTObject.TTChildObjectCollection<MuscleTestForm>
        {
            public ChildMuscleTestFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuscleTestFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ekstansiyon
    /// </summary>
        public MuscleTestEnum? Extension
        {
            get { return (MuscleTestEnum?)(int?)this["EXTENSION"]; }
            set { this["EXTENSION"] = value; }
        }

    /// <summary>
    /// Fleksiyon
    /// </summary>
        public MuscleTestEnum? Flexion
        {
            get { return (MuscleTestEnum?)(int?)this["FLEXION"]; }
            set { this["FLEXION"] = value; }
        }

    /// <summary>
    /// Abduksiyon
    /// </summary>
        public MuscleTestEnum? Abduction
        {
            get { return (MuscleTestEnum?)(int?)this["ABDUCTION"]; }
            set { this["ABDUCTION"] = value; }
        }

    /// <summary>
    /// Rotasyon
    /// </summary>
        public MuscleTestEnum? Rotation
        {
            get { return (MuscleTestEnum?)(int?)this["ROTATION"]; }
            set { this["ROTATION"] = value; }
        }

        protected MuscleTestForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuscleTestForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuscleTestForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuscleTestForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuscleTestForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUSCLETESTFORM", dataRow) { }
        protected MuscleTestForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUSCLETESTFORM", dataRow, isImported) { }
        public MuscleTestForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuscleTestForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuscleTestForm() : base() { }

    }
}