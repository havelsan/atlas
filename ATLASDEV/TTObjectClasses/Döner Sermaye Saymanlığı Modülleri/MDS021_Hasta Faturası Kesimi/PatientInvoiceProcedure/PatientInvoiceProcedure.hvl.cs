
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientInvoiceProcedure")] 

    public  partial class PatientInvoiceProcedure : TTObject
    {
        public class PatientInvoiceProcedureList : TTObjectCollection<PatientInvoiceProcedure> { }
                    
        public class ChildPatientInvoiceProcedureCollection : TTObject.TTChildObjectCollection<PatientInvoiceProcedure>
        {
            public ChildPatientInvoiceProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientInvoiceProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Ödenecek
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
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
    /// Toplam Tutar
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
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
    /// Hasta Faturası İşlemiyle İlişki
    /// </summary>
        public PatientInvoice PatientInvoice
        {
            get { return (PatientInvoice)((ITTObject)this).GetParent("PATIENTINVOICE"); }
            set { this["PATIENTINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("47a0b1db-2cbb-4ca4-af2f-85b6f8e51257"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Hasta faturası hizmet bilgisine ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransaction
        {
            get
            {
                if (_AccountTransaction == null)
                    CreateAccountTransactionCollection();
                return _AccountTransaction;
            }
        }

        protected PatientInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTINVOICEPROCEDURE", dataRow) { }
        protected PatientInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTINVOICEPROCEDURE", dataRow, isImported) { }
        public PatientInvoiceProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientInvoiceProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientInvoiceProcedure() : base() { }

    }
}