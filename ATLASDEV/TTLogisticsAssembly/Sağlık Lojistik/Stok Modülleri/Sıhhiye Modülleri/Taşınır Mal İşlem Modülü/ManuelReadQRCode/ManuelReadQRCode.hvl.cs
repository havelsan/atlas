
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManuelReadQRCode")] 

    public  partial class ManuelReadQRCode : TTObject
    {
        public class ManuelReadQRCodeList : TTObjectCollection<ManuelReadQRCode> { }
                    
        public class ChildManuelReadQRCodeCollection : TTObject.TTChildObjectCollection<ManuelReadQRCode>
        {
            public ChildManuelReadQRCodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManuelReadQRCodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Barkod
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

        public ChattelDocumentOutputDetailWithAccountancy ChattelDocumentOutputDetail
        {
            get { return (ChattelDocumentOutputDetailWithAccountancy)((ITTObject)this).GetParent("CHATTELDOCUMENTOUTPUTDETAIL"); }
            set { this["CHATTELDOCUMENTOUTPUTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManuelReadQRCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManuelReadQRCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManuelReadQRCode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManuelReadQRCode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManuelReadQRCode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANUELREADQRCODE", dataRow) { }
        protected ManuelReadQRCode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANUELREADQRCODE", dataRow, isImported) { }
        public ManuelReadQRCode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManuelReadQRCode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManuelReadQRCode() : base() { }

    }
}