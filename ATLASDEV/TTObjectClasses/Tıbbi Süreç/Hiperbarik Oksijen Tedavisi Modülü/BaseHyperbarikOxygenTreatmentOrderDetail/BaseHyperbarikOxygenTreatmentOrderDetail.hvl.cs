
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHyperbarikOxygenTreatmentOrderDetail")] 

    public  partial class BaseHyperbarikOxygenTreatmentOrderDetail : SubactionProcedureFlowable
    {
        public class BaseHyperbarikOxygenTreatmentOrderDetailList : TTObjectCollection<BaseHyperbarikOxygenTreatmentOrderDetail> { }
                    
        public class ChildBaseHyperbarikOxygenTreatmentOrderDetailCollection : TTObject.TTChildObjectCollection<BaseHyperbarikOxygenTreatmentOrderDetail>
        {
            public ChildBaseHyperbarikOxygenTreatmentOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHyperbarikOxygenTreatmentOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        protected BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHYPERBARIKOXYGENTREATMENTORDERDETAIL", dataRow) { }
        protected BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHYPERBARIKOXYGENTREATMENTORDERDETAIL", dataRow, isImported) { }
        public BaseHyperbarikOxygenTreatmentOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHyperbarikOxygenTreatmentOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHyperbarikOxygenTreatmentOrderDetail() : base() { }

    }
}