
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResTenderCommision")] 

    public  partial class ResTenderCommision : TTDefinitionSet
    {
        public class ResTenderCommisionList : TTObjectCollection<ResTenderCommision> { }
                    
        public class ChildResTenderCommisionCollection : TTObject.TTChildObjectCollection<ResTenderCommision>
        {
            public ChildResTenderCommisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResTenderCommisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResHospital ResHospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("RESHOSPITAL"); }
            set { this["RESHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcurementUnitDef ProcurementUnitDef
        {
            get { return (ProcurementUnitDef)((ITTObject)this).GetParent("PROCUREMENTUNITDEF"); }
            set { this["PROCUREMENTUNITDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResTenderCommision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResTenderCommision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResTenderCommision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResTenderCommision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResTenderCommision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESTENDERCOMMISION", dataRow) { }
        protected ResTenderCommision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESTENDERCOMMISION", dataRow, isImported) { }
        public ResTenderCommision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResTenderCommision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResTenderCommision() : base() { }

    }
}