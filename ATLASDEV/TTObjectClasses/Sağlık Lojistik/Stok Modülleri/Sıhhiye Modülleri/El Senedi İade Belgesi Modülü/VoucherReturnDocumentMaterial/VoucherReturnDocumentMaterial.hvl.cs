
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VoucherReturnDocumentMaterial")] 

    /// <summary>
    /// El Senedi Dağıtım Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class VoucherReturnDocumentMaterial : StockActionDetailOut
    {
        public class VoucherReturnDocumentMaterialList : TTObjectCollection<VoucherReturnDocumentMaterial> { }
                    
        public class ChildVoucherReturnDocumentMaterialCollection : TTObject.TTChildObjectCollection<VoucherReturnDocumentMaterial>
        {
            public ChildVoucherReturnDocumentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVoucherReturnDocumentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Existing
        {
            get { return (Currency?)this["EXISTING"]; }
            set { this["EXISTING"] = value; }
        }

    /// <summary>
    /// İade Miktarı
    /// </summary>
        public Currency? RequireAmount
        {
            get { return (Currency?)this["REQUIREAMOUNT"]; }
            set { this["REQUIREAMOUNT"] = value; }
        }

        protected VoucherReturnDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VoucherReturnDocumentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VoucherReturnDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VoucherReturnDocumentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VoucherReturnDocumentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VOUCHERRETURNDOCUMENTMATERIAL", dataRow) { }
        protected VoucherReturnDocumentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VOUCHERRETURNDOCUMENTMATERIAL", dataRow, isImported) { }
        public VoucherReturnDocumentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VoucherReturnDocumentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VoucherReturnDocumentMaterial() : base() { }

    }
}