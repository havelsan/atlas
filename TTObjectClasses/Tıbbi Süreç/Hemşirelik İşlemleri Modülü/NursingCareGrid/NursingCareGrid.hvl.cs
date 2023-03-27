
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingCareGrid")] 

    /// <summary>
    /// Hemşirelik Girişimi Gridi
    /// </summary>
    public  partial class NursingCareGrid : TTObject
    {
        public class NursingCareGridList : TTObjectCollection<NursingCareGrid> { }
                    
        public class ChildNursingCareGridCollection : TTObject.TTChildObjectCollection<NursingCareGrid>
        {
            public ChildNursingCareGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingCareGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hemşirelik Bakımı
    /// </summary>
        public NursingCareDefinition NursingCare
        {
            get { return (NursingCareDefinition)((ITTObject)this).GetParent("NURSINGCARE"); }
            set { this["NURSINGCARE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingCare NursingNanda
        {
            get { return (NursingCare)((ITTObject)this).GetParent("NURSINGNANDA"); }
            set { this["NURSINGNANDA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingCareGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingCareGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingCareGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingCareGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingCareGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGCAREGRID", dataRow) { }
        protected NursingCareGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGCAREGRID", dataRow, isImported) { }
        public NursingCareGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingCareGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingCareGrid() : base() { }

    }
}