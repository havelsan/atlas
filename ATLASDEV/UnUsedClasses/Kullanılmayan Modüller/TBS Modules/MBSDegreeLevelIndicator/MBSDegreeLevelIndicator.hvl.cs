
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSDegreeLevelIndicator")] 

    public  partial class MBSDegreeLevelIndicator : TTObject
    {
        public class MBSDegreeLevelIndicatorList : TTObjectCollection<MBSDegreeLevelIndicator> { }
                    
        public class ChildMBSDegreeLevelIndicatorCollection : TTObject.TTChildObjectCollection<MBSDegreeLevelIndicator>
        {
            public ChildMBSDegreeLevelIndicatorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSDegreeLevelIndicatorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Derece
    /// </summary>
        public int? Degree
        {
            get { return (int?)this["DEGREE"]; }
            set { this["DEGREE"] = value; }
        }

    /// <summary>
    /// Kademe
    /// </summary>
        public int? Level
        {
            get { return (int?)this["LEVEL"]; }
            set { this["LEVEL"] = value; }
        }

    /// <summary>
    /// Gösterge
    /// </summary>
        public int? Indicator
        {
            get { return (int?)this["INDICATOR"]; }
            set { this["INDICATOR"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSDegreeLevelIndicator(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSDegreeLevelIndicator(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSDegreeLevelIndicator(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSDegreeLevelIndicator(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSDegreeLevelIndicator(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSDEGREELEVELINDICATOR", dataRow) { }
        protected MBSDegreeLevelIndicator(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSDEGREELEVELINDICATOR", dataRow, isImported) { }
        public MBSDegreeLevelIndicator(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSDegreeLevelIndicator(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSDegreeLevelIndicator() : base() { }

    }
}