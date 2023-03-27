
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralReceiptProcedure")] 

    /// <summary>
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı Hizmetleri
    /// </summary>
    public  partial class GeneralReceiptProcedure : TTObject
    {
        public class GeneralReceiptProcedureList : TTObjectCollection<GeneralReceiptProcedure> { }
                    
        public class ChildGeneralReceiptProcedureCollection : TTObject.TTChildObjectCollection<GeneralReceiptProcedure>
        {
            public ChildGeneralReceiptProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralReceiptProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Birim Fiyat
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
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
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// GeneralReceipt e ilişki
    /// </summary>
        public GeneralReceipt GeneralReceipt
        {
            get { return (GeneralReceipt)((ITTObject)this).GetParent("GENERALRECEIPT"); }
            set { this["GENERALRECEIPT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmetle ilişki
    /// </summary>
        public ProcedureDefinition Procedure
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDURE"); }
            set { this["PROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// GeneralReceiptDocumentDetail e ilişki
    /// </summary>
        public GeneralReceiptDocumentDetail GeneralReceiptDocumentDetail
        {
            get { return (GeneralReceiptDocumentDetail)((ITTObject)this).GetParent("GENERALRECEIPTDOCUMENTDETAIL"); }
            set { this["GENERALRECEIPTDOCUMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneralReceiptProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralReceiptProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralReceiptProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralReceiptProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralReceiptProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALRECEIPTPROCEDURE", dataRow) { }
        protected GeneralReceiptProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALRECEIPTPROCEDURE", dataRow, isImported) { }
        public GeneralReceiptProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralReceiptProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralReceiptProcedure() : base() { }

    }
}