
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CompleteBloodProducts")] 

    public  partial class CompleteBloodProducts : BaseScheduledTask
    {
        public class CompleteBloodProductsList : TTObjectCollection<CompleteBloodProducts> { }
                    
        public class ChildCompleteBloodProductsCollection : TTObject.TTChildObjectCollection<CompleteBloodProducts>
        {
            public ChildCompleteBloodProductsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCompleteBloodProductsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CompleteBloodProducts(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CompleteBloodProducts(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CompleteBloodProducts(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CompleteBloodProducts(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CompleteBloodProducts(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMPLETEBLOODPRODUCTS", dataRow) { }
        protected CompleteBloodProducts(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMPLETEBLOODPRODUCTS", dataRow, isImported) { }
        public CompleteBloodProducts(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CompleteBloodProducts(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CompleteBloodProducts() : base() { }

    }
}