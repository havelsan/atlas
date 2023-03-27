
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubCashOfficeReceiptDocGroup")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Tahsilat Döküman Grubu
    /// </summary>
    public  partial class SubCashOfficeReceiptDocGroup : AccountDocumentGroup
    {
        public class SubCashOfficeReceiptDocGroupList : TTObjectCollection<SubCashOfficeReceiptDocGroup> { }
                    
        public class ChildSubCashOfficeReceiptDocGroupCollection : TTObject.TTChildObjectCollection<SubCashOfficeReceiptDocGroup>
        {
            public ChildSubCashOfficeReceiptDocGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubCashOfficeReceiptDocGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected SubCashOfficeReceiptDocGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubCashOfficeReceiptDocGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubCashOfficeReceiptDocGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubCashOfficeReceiptDocGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubCashOfficeReceiptDocGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBCASHOFFICERECEIPTDOCGROUP", dataRow) { }
        protected SubCashOfficeReceiptDocGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBCASHOFFICERECEIPTDOCGROUP", dataRow, isImported) { }
        public SubCashOfficeReceiptDocGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubCashOfficeReceiptDocGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubCashOfficeReceiptDocGroup() : base() { }

    }
}