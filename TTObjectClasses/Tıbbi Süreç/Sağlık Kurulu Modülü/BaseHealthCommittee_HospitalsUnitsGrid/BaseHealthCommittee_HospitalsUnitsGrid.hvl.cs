
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHealthCommittee_HospitalsUnitsGrid")] 

    public  partial class BaseHealthCommittee_HospitalsUnitsGrid : HospitalsUnitsGrid
    {
        public class BaseHealthCommittee_HospitalsUnitsGridList : TTObjectCollection<BaseHealthCommittee_HospitalsUnitsGrid> { }
                    
        public class ChildBaseHealthCommittee_HospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<BaseHealthCommittee_HospitalsUnitsGrid>
        {
            public ChildBaseHealthCommittee_HospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHealthCommittee_HospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ActionTemplate Template
        {
            get { return (ActionTemplate)((ITTObject)this).GetParent("TEMPLATE"); }
            set { this["TEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BaseHealthCommittee_HospitalsUnits
    /// </summary>
        public BaseHealthCommittee BaseHealthCommittee
        {
            get { return (BaseHealthCommittee)((ITTObject)this).GetParent("BASEHEALTHCOMMITTEE"); }
            set { this["BASEHEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeActionTemplate EpisodeActionTemplate
        {
            get { return (EpisodeActionTemplate)((ITTObject)this).GetParent("EPISODEACTIONTEMPLATE"); }
            set { this["EPISODEACTIONTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHEALTHCOMMITTEE_HOSPITALSUNITSGRID", dataRow) { }
        protected BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHEALTHCOMMITTEE_HOSPITALSUNITSGRID", dataRow, isImported) { }
        public BaseHealthCommittee_HospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHealthCommittee_HospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHealthCommittee_HospitalsUnitsGrid() : base() { }

    }
}