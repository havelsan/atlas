
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LabaratoryReservation")] 

    public  partial class LabaratoryReservation : BaseAction, IWorkListBaseAction
    {
        public class LabaratoryReservationList : TTObjectCollection<LabaratoryReservation> { }
                    
        public class ChildLabaratoryReservationCollection : TTObject.TTChildObjectCollection<LabaratoryReservation>
        {
            public ChildLabaratoryReservationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLabaratoryReservationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ArgeProject Project
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("PROJECT"); }
            set { this["PROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public LabaratoryPlaning LabaratoryPlan
        {
            get { return (LabaratoryPlaning)((ITTObject)this).GetParent("LABARATORYPLAN"); }
            set { this["LABARATORYPLAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LabaratoryReservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LabaratoryReservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LabaratoryReservation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LabaratoryReservation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LabaratoryReservation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABARATORYRESERVATION", dataRow) { }
        protected LabaratoryReservation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABARATORYRESERVATION", dataRow, isImported) { }
        public LabaratoryReservation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LabaratoryReservation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LabaratoryReservation() : base() { }

    }
}