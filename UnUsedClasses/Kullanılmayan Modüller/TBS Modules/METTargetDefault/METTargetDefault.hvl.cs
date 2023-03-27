
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METTargetDefault")] 

    public  partial class METTargetDefault : TTObject
    {
        public class METTargetDefaultList : TTObjectCollection<METTargetDefault> { }
                    
        public class ChildMETTargetDefaultCollection : TTObject.TTChildObjectCollection<METTargetDefault>
        {
            public ChildMETTargetDefaultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETTargetDefaultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? IsDefault
        {
            get { return (bool?)this["ISDEFAULT"]; }
            set { this["ISDEFAULT"] = value; }
        }

        public METTarget Target
        {
            get { return (METTarget)((ITTObject)this).GetParent("TARGET"); }
            set { this["TARGET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dağıtım Planı Hedefler
    /// </summary>
        public METDistributionPlan DistributionPlan
        {
            get { return (METDistributionPlan)((ITTObject)this).GetParent("DISTRIBUTIONPLAN"); }
            set { this["DISTRIBUTIONPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected METTargetDefault(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METTargetDefault(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METTargetDefault(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METTargetDefault(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METTargetDefault(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METTARGETDEFAULT", dataRow) { }
        protected METTargetDefault(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METTARGETDEFAULT", dataRow, isImported) { }
        public METTargetDefault(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METTargetDefault(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METTargetDefault() : base() { }

    }
}