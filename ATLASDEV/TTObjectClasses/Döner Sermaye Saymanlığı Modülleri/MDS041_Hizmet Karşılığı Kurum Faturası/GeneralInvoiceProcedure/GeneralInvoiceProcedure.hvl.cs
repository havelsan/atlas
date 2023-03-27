
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralInvoiceProcedure")] 

    public  partial class GeneralInvoiceProcedure : TTObject
    {
        public class GeneralInvoiceProcedureList : TTObjectCollection<GeneralInvoiceProcedure> { }
                    
        public class ChildGeneralInvoiceProcedureCollection : TTObject.TTChildObjectCollection<GeneralInvoiceProcedure>
        {
            public ChildGeneralInvoiceProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralInvoiceProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Toplam Fiyat
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
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
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// GeneralInvoice e ilişki
    /// </summary>
        public GeneralInvoice GeneralInvoice
        {
            get { return (GeneralInvoice)((ITTObject)this).GetParent("GENERALINVOICE"); }
            set { this["GENERALINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// GeneralInvoiceDocumentDetail e ilişki
    /// </summary>
        public GeneralInvoiceDocumentDetail GeneralInvoiceDocumentDetail
        {
            get { return (GeneralInvoiceDocumentDetail)((ITTObject)this).GetParent("GENERALINVOICEDOCUMENTDETAIL"); }
            set { this["GENERALINVOICEDOCUMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiyatla ilişki
    /// </summary>
        public PricingDetailDefinition Price
        {
            get { return (PricingDetailDefinition)((ITTObject)this).GetParent("PRICE"); }
            set { this["PRICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmetle ilişki
    /// </summary>
        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneralInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALINVOICEPROCEDURE", dataRow) { }
        protected GeneralInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALINVOICEPROCEDURE", dataRow, isImported) { }
        public GeneralInvoiceProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralInvoiceProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralInvoiceProcedure() : base() { }

    }
}