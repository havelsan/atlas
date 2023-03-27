
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SUTProcedureTotalAmount")] 

    public  partial class SUTProcedureTotalAmount : TTObject, ISUTProcedureTotalAmount
    {
        public class SUTProcedureTotalAmountList : TTObjectCollection<SUTProcedureTotalAmount> { }
                    
        public class ChildSUTProcedureTotalAmountCollection : TTObject.TTChildObjectCollection<SUTProcedureTotalAmount>
        {
            public ChildSUTProcedureTotalAmountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSUTProcedureTotalAmountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SUTProcedureTotalAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SUTProcedureTotalAmount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SUTProcedureTotalAmount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SUTProcedureTotalAmount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SUTProcedureTotalAmount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUTPROCEDURETOTALAMOUNT", dataRow) { }
        protected SUTProcedureTotalAmount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUTPROCEDURETOTALAMOUNT", dataRow, isImported) { }
        public SUTProcedureTotalAmount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SUTProcedureTotalAmount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SUTProcedureTotalAmount() : base() { }

    }
}