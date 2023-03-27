
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaCutTransaction")] 

    /// <summary>
    /// Kesinti Yapılmış İşlemler
    /// </summary>
    public  partial class MedulaCutTransaction : TTObject
    {
        public class MedulaCutTransactionList : TTObjectCollection<MedulaCutTransaction> { }
                    
        public class ChildMedulaCutTransactionCollection : TTObject.TTChildObjectCollection<MedulaCutTransaction>
        {
            public ChildMedulaCutTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaCutTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Muayene Katılım Payı Tutarı
    /// </summary>
        public double? ExaminationParticipationPrice
        {
            get { return (double?)this["EXAMINATIONPARTICIPATIONPRICE"]; }
            set { this["EXAMINATIONPARTICIPATIONPRICE"] = value; }
        }

    /// <summary>
    /// Malzeme Katılım Payı Tutarı
    /// </summary>
        public double? MaterialParticipationPrice
        {
            get { return (double?)this["MATERIALPARTICIPATIONPRICE"]; }
            set { this["MATERIALPARTICIPATIONPRICE"] = value; }
        }

    /// <summary>
    /// Tüp Bebek Katılım Payı Tutarı
    /// </summary>
        public double? TubeBabyParticipationPrice
        {
            get { return (double?)this["TUBEBABYPARTICIPATIONPRICE"]; }
            set { this["TUBEBABYPARTICIPATIONPRICE"] = value; }
        }

    /// <summary>
    /// Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDefinition MedulaInvoiceTerm
        {
            get { return (MedulaInvoiceTermDefinition)((ITTObject)this).GetParent("MEDULAINVOICETERM"); }
            set { this["MEDULAINVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaCutTransactionDetailsCollection()
        {
            _MedulaCutTransactionDetails = new MedulaCutTransactionDetail.ChildMedulaCutTransactionDetailCollection(this, new Guid("80c98c6c-8854-47ca-9c9c-b36a5d93e994"));
            ((ITTChildObjectCollection)_MedulaCutTransactionDetails).GetChildren();
        }

        protected MedulaCutTransactionDetail.ChildMedulaCutTransactionDetailCollection _MedulaCutTransactionDetails = null;
    /// <summary>
    /// Child collection for Medula Kesinti Yapılmış İşlemler
    /// </summary>
        public MedulaCutTransactionDetail.ChildMedulaCutTransactionDetailCollection MedulaCutTransactionDetails
        {
            get
            {
                if (_MedulaCutTransactionDetails == null)
                    CreateMedulaCutTransactionDetailsCollection();
                return _MedulaCutTransactionDetails;
            }
        }

        protected MedulaCutTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaCutTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaCutTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaCutTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaCutTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULACUTTRANSACTION", dataRow) { }
        protected MedulaCutTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULACUTTRANSACTION", dataRow, isImported) { }
        public MedulaCutTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaCutTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaCutTransaction() : base() { }

    }
}