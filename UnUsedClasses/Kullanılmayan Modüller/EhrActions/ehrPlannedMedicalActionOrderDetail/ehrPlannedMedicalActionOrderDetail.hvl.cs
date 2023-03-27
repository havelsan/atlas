
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrPlannedMedicalActionOrderDetail")] 

    public  partial class ehrPlannedMedicalActionOrderDetail : ehrSubactionProcedure
    {
        public class ehrPlannedMedicalActionOrderDetailList : TTObjectCollection<ehrPlannedMedicalActionOrderDetail> { }
                    
        public class ChildehrPlannedMedicalActionOrderDetailCollection : TTObject.TTChildObjectCollection<ehrPlannedMedicalActionOrderDetail>
        {
            public ChildehrPlannedMedicalActionOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrPlannedMedicalActionOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public string State
        {
            get { return (string)this["STATE"]; }
            set { this["STATE"] = value; }
        }

        protected ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRPLANNEDMEDICALACTIONORDERDETAIL", dataRow) { }
        protected ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRPLANNEDMEDICALACTIONORDERDETAIL", dataRow, isImported) { }
        public ehrPlannedMedicalActionOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrPlannedMedicalActionOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrPlannedMedicalActionOrderDetail() : base() { }

    }
}