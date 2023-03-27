
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SystemForHealthCommitteeGrid")] 

    public  partial class SystemForHealthCommitteeGrid : TTObject
    {
        public class SystemForHealthCommitteeGridList : TTObjectCollection<SystemForHealthCommitteeGrid> { }
                    
        public class ChildSystemForHealthCommitteeGridCollection : TTObject.TTChildObjectCollection<SystemForHealthCommitteeGrid>
        {
            public ChildSystemForHealthCommitteeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSystemForHealthCommitteeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Engelli Karar Önerisi
    /// </summary>
        public string DisabledOfferDecision
        {
            get { return (string)this["DISABLEDOFFERDECISION"]; }
            set { this["DISABLEDOFFERDECISION"] = value; }
        }

    /// <summary>
    /// Engel Oranı
    /// </summary>
        public string DisabledRatio
        {
            get { return (string)this["DISABLEDRATIO"]; }
            set { this["DISABLEDRATIO"] = value; }
        }

        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SystemForDisabledReportDefinition SystemForDisabled
        {
            get { return (SystemForDisabledReportDefinition)((ITTObject)this).GetParent("SYSTEMFORDISABLED"); }
            set { this["SYSTEMFORDISABLED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SystemForHealthCommitteeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SystemForHealthCommitteeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SystemForHealthCommitteeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SystemForHealthCommitteeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SystemForHealthCommitteeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSTEMFORHEALTHCOMMITTEEGRID", dataRow) { }
        protected SystemForHealthCommitteeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSTEMFORHEALTHCOMMITTEEGRID", dataRow, isImported) { }
        public SystemForHealthCommitteeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SystemForHealthCommitteeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SystemForHealthCommitteeGrid() : base() { }

    }
}