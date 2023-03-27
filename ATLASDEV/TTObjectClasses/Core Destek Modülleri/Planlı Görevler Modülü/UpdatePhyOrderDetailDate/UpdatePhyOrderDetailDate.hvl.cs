
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpdatePhyOrderDetailDate")] 

    /// <summary>
    /// Fizyoterapi Tatil Günleri OrderDetail Tarihi Değiştirme
    /// </summary>
    public  partial class UpdatePhyOrderDetailDate : BaseScheduledTask
    {
        public class UpdatePhyOrderDetailDateList : TTObjectCollection<UpdatePhyOrderDetailDate> { }
                    
        public class ChildUpdatePhyOrderDetailDateCollection : TTObject.TTChildObjectCollection<UpdatePhyOrderDetailDate>
        {
            public ChildUpdatePhyOrderDetailDateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpdatePhyOrderDetailDateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected UpdatePhyOrderDetailDate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpdatePhyOrderDetailDate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpdatePhyOrderDetailDate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpdatePhyOrderDetailDate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpdatePhyOrderDetailDate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPDATEPHYORDERDETAILDATE", dataRow) { }
        protected UpdatePhyOrderDetailDate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPDATEPHYORDERDETAILDATE", dataRow, isImported) { }
        public UpdatePhyOrderDetailDate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpdatePhyOrderDetailDate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpdatePhyOrderDetailDate() : base() { }

    }
}