
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QRCodeInDetail")] 

    public  partial class QRCodeInDetail : QRCodeDetail
    {
        public class QRCodeInDetailList : TTObjectCollection<QRCodeInDetail> { }
                    
        public class ChildQRCodeInDetailCollection : TTObject.TTChildObjectCollection<QRCodeInDetail>
        {
            public ChildQRCodeInDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQRCodeInDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bağ Nu.
    /// </summary>
        public string BunchNo
        {
            get { return (string)this["BUNCHNO"]; }
            set { this["BUNCHNO"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpireDate
        {
            get { return (DateTime?)this["EXPIREDATE"]; }
            set { this["EXPIREDATE"] = value; }
        }

    /// <summary>
    /// Palet Nu.
    /// </summary>
        public string PalletNo
        {
            get { return (string)this["PALLETNO"]; }
            set { this["PALLETNO"] = value; }
        }

    /// <summary>
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

    /// <summary>
    /// Sıra Nu.
    /// </summary>
        public string OrderNo
        {
            get { return (string)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Koli Nu.
    /// </summary>
        public string PackageNo
        {
            get { return (string)this["PACKAGENO"]; }
            set { this["PACKAGENO"] = value; }
        }

    /// <summary>
    /// Küçük Bağ Nu.
    /// </summary>
        public string SmallBunchNo
        {
            get { return (string)this["SMALLBUNCHNO"]; }
            set { this["SMALLBUNCHNO"] = value; }
        }

    /// <summary>
    /// Barkod
    /// </summary>
        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

    /// <summary>
    /// Koli İçi Kutu
    /// </summary>
        public string BoxNo
        {
            get { return (string)this["BOXNO"]; }
            set { this["BOXNO"] = value; }
        }

        protected QRCodeInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QRCodeInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QRCodeInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QRCodeInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QRCodeInDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QRCODEINDETAIL", dataRow) { }
        protected QRCodeInDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QRCODEINDETAIL", dataRow, isImported) { }
        public QRCodeInDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QRCodeInDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QRCodeInDetail() : base() { }

    }
}