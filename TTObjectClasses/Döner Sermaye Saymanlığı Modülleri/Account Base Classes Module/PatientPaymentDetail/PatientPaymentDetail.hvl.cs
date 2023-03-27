
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientPaymentDetail")] 

    /// <summary>
    /// Parçalı ödeme detayı
    /// </summary>
    public  partial class PatientPaymentDetail : TTObject
    {
        public class PatientPaymentDetailList : TTObjectCollection<PatientPaymentDetail> { }
                    
        public class ChildPatientPaymentDetailCollection : TTObject.TTChildObjectCollection<PatientPaymentDetail>
        {
            public ChildPatientPaymentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientPaymentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İade
    /// </summary>
        public bool? IsBack
        {
            get { return (bool?)this["ISBACK"]; }
            set { this["ISBACK"] = value; }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? IsCancel
        {
            get { return (bool?)this["ISCANCEL"]; }
            set { this["ISCANCEL"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Ödenen Tutar
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

    /// <summary>
    /// Ödeme Tipi
    /// </summary>
        public PaymentTypeEnum? PaymentType
        {
            get { return (PaymentTypeEnum?)(int?)this["PAYMENTTYPE"]; }
            set { this["PAYMENTTYPE"] = value; }
        }

    /// <summary>
    /// Katılım Payı Ödemesi
    /// </summary>
        public bool? IsParticipationShare
        {
            get { return (bool?)this["ISPARTICIPATIONSHARE"]; }
            set { this["ISPARTICIPATIONSHARE"] = value; }
        }

    /// <summary>
    /// Ödeme detayı accounttransaction ilişkisi
    /// </summary>
        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountDocument AccountDocument
        {
            get { return (AccountDocument)((ITTObject)this).GetParent("ACCOUNTDOCUMENT"); }
            set { this["ACCOUNTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientPaymentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientPaymentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientPaymentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientPaymentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientPaymentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTPAYMENTDETAIL", dataRow) { }
        protected PatientPaymentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTPAYMENTDETAIL", dataRow, isImported) { }
        public PatientPaymentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientPaymentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientPaymentDetail() : base() { }

    }
}