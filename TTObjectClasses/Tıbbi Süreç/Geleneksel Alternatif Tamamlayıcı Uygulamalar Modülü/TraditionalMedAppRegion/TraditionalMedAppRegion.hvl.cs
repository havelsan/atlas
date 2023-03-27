
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TraditionalMedAppRegion")] 

    public  partial class TraditionalMedAppRegion : TTObject
    {
        public class TraditionalMedAppRegionList : TTObjectCollection<TraditionalMedAppRegion> { }
                    
        public class ChildTraditionalMedAppRegionCollection : TTObject.TTChildObjectCollection<TraditionalMedAppRegion>
        {
            public ChildTraditionalMedAppRegionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTraditionalMedAppRegionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Getat Uygulama Bölgesi
    /// </summary>
        public SKRSGETATUygulamaBolgesi SKRSGetatApplicationRegion
        {
            get { return (SKRSGETATUygulamaBolgesi)((ITTObject)this).GetParent("SKRSGETATAPPLICATIONREGION"); }
            set { this["SKRSGETATAPPLICATIONREGION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Traditional Medicine
    /// </summary>
        public TraditionalMedicine TraditionalMedicine
        {
            get { return (TraditionalMedicine)((ITTObject)this).GetParent("TRADITIONALMEDICINE"); }
            set { this["TRADITIONALMEDICINE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TraditionalMedAppRegion(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TraditionalMedAppRegion(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TraditionalMedAppRegion(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TraditionalMedAppRegion(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TraditionalMedAppRegion(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRADITIONALMEDAPPREGION", dataRow) { }
        protected TraditionalMedAppRegion(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRADITIONALMEDAPPREGION", dataRow, isImported) { }
        public TraditionalMedAppRegion(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TraditionalMedAppRegion(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TraditionalMedAppRegion() : base() { }

    }
}