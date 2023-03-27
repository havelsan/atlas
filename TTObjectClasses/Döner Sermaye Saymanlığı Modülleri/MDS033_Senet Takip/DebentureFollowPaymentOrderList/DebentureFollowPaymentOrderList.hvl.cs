
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureFollowPaymentOrderList")] 

    /// <summary>
    /// Ödeme Emri Listesi
    /// </summary>
    public  partial class DebentureFollowPaymentOrderList : TTObject
    {
        public class DebentureFollowPaymentOrderListList : TTObjectCollection<DebentureFollowPaymentOrderList> { }
                    
        public class ChildDebentureFollowPaymentOrderListCollection : TTObject.TTChildObjectCollection<DebentureFollowPaymentOrderList>
        {
            public ChildDebentureFollowPaymentOrderListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureFollowPaymentOrderListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ödeme Emri Tarihi
    /// </summary>
        public DateTime? PaymentOrderDate
        {
            get { return (DateTime?)this["PAYMENTORDERDATE"]; }
            set { this["PAYMENTORDERDATE"] = value; }
        }

    /// <summary>
    /// Rapor oluşturuldu
    /// </summary>
        public bool? Reported
        {
            get { return (bool?)this["REPORTED"]; }
            set { this["REPORTED"] = value; }
        }

    /// <summary>
    /// Hasta Dosyasıyla İlişkisi 
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Senetle İlişkisi
    /// </summary>
        public Debenture Debenture
        {
            get { return (Debenture)((ITTObject)this).GetParent("DEBENTURE"); }
            set { this["DEBENTURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Senet Takip İşlemiyle İlişkisi
    /// </summary>
        public DebentureFollow DebentureFollow
        {
            get { return (DebentureFollow)((ITTObject)this).GetParent("DEBENTUREFOLLOW"); }
            set { this["DEBENTUREFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDebenturesCollection()
        {
            _Debentures = new Debenture.ChildDebentureCollection(this, new Guid("f3cdada3-ebb9-471e-9aa5-fd40a508de15"));
            ((ITTChildObjectCollection)_Debentures).GetChildren();
        }

        protected Debenture.ChildDebentureCollection _Debentures = null;
    /// <summary>
    /// Child collection for murat silinecek
    /// </summary>
        public Debenture.ChildDebentureCollection Debentures
        {
            get
            {
                if (_Debentures == null)
                    CreateDebenturesCollection();
                return _Debentures;
            }
        }

        protected DebentureFollowPaymentOrderList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureFollowPaymentOrderList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureFollowPaymentOrderList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureFollowPaymentOrderList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureFollowPaymentOrderList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREFOLLOWPAYMENTORDERLIST", dataRow) { }
        protected DebentureFollowPaymentOrderList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREFOLLOWPAYMENTORDERLIST", dataRow, isImported) { }
        public DebentureFollowPaymentOrderList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureFollowPaymentOrderList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureFollowPaymentOrderList() : base() { }

    }
}