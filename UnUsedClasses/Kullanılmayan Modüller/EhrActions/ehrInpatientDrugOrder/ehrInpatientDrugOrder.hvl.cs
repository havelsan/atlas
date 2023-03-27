
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrInpatientDrugOrder")] 

    /// <summary>
    /// Yatan Hasta İlaç Emirleri
    /// </summary>
    public  partial class ehrInpatientDrugOrder : ehrDrugOrder
    {
        public class ehrInpatientDrugOrderList : TTObjectCollection<ehrInpatientDrugOrder> { }
                    
        public class ChildehrInpatientDrugOrderCollection : TTObject.TTChildObjectCollection<ehrInpatientDrugOrder>
        {
            public ChildehrInpatientDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrInpatientDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

        protected ehrInpatientDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrInpatientDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrInpatientDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrInpatientDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrInpatientDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRINPATIENTDRUGORDER", dataRow) { }
        protected ehrInpatientDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRINPATIENTDRUGORDER", dataRow, isImported) { }
        public ehrInpatientDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrInpatientDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrInpatientDrugOrder() : base() { }

    }
}