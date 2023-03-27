
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaCutTransactionDetail")] 

    /// <summary>
    /// Kesinti Yapılmış İşlemler Detay
    /// </summary>
    public  partial class MedulaCutTransactionDetail : TTObject
    {
        public class MedulaCutTransactionDetailList : TTObjectCollection<MedulaCutTransactionDetail> { }
                    
        public class ChildMedulaCutTransactionDetailCollection : TTObject.TTChildObjectCollection<MedulaCutTransactionDetail>
        {
            public ChildMedulaCutTransactionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaCutTransactionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Medula Takip No
    /// </summary>
        public string ProvisionNo
        {
            get { return (string)this["PROVISIONNO"]; }
            set { this["PROVISIONNO"] = value; }
        }

    /// <summary>
    /// İşlem Sıra No
    /// </summary>
        public string ProcessNo
        {
            get { return (string)this["PROCESSNO"]; }
            set { this["PROCESSNO"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string SUTCode
        {
            get { return (string)this["SUTCODE"]; }
            set { this["SUTCODE"] = value; }
        }

    /// <summary>
    /// SUT Adı
    /// </summary>
        public string SUTName
        {
            get { return (string)this["SUTNAME"]; }
            set { this["SUTNAME"] = value; }
        }

    /// <summary>
    /// İşlem Tutarı
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Kesinti Tutarı
    /// </summary>
        public double? CutPrice
        {
            get { return (double?)this["CUTPRICE"]; }
            set { this["CUTPRICE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Grup Türü
    /// </summary>
        public string GroupType
        {
            get { return (string)this["GROUPTYPE"]; }
            set { this["GROUPTYPE"] = value; }
        }

    /// <summary>
    /// Grup Adı
    /// </summary>
        public string GroupName
        {
            get { return (string)this["GROUPNAME"]; }
            set { this["GROUPNAME"] = value; }
        }

    /// <summary>
    /// Medula Kesinti Yapılmış İşlemler
    /// </summary>
        public MedulaCutTransaction MedulaCutTransaction
        {
            get { return (MedulaCutTransaction)((ITTObject)this).GetParent("MEDULACUTTRANSACTION"); }
            set { this["MEDULACUTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaCutTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaCutTransactionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaCutTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaCutTransactionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaCutTransactionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULACUTTRANSACTIONDETAIL", dataRow) { }
        protected MedulaCutTransactionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULACUTTRANSACTIONDETAIL", dataRow, isImported) { }
        public MedulaCutTransactionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaCutTransactionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaCutTransactionDetail() : base() { }

    }
}