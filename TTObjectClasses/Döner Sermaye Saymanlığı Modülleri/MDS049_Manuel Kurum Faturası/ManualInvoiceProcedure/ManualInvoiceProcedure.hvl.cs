
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManualInvoiceProcedure")] 

    public  partial class ManualInvoiceProcedure : TTObject
    {
        public class ManualInvoiceProcedureList : TTObjectCollection<ManualInvoiceProcedure> { }
                    
        public class ChildManualInvoiceProcedureCollection : TTObject.TTChildObjectCollection<ManualInvoiceProcedure>
        {
            public ChildManualInvoiceProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManualInvoiceProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
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
    /// Hizmet
    /// </summary>
        public string Procedure
        {
            get { return (string)this["PROCEDURE"]; }
            set { this["PROCEDURE"] = value; }
        }

    /// <summary>
    /// ManualInvoice ile ilişki
    /// </summary>
        public ManualInvoice ManualInvoice
        {
            get { return (ManualInvoice)((ITTObject)this).GetParent("MANUALINVOICE"); }
            set { this["MANUALINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManualInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManualInvoiceProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManualInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManualInvoiceProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManualInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANUALINVOICEPROCEDURE", dataRow) { }
        protected ManualInvoiceProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANUALINVOICEPROCEDURE", dataRow, isImported) { }
        public ManualInvoiceProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManualInvoiceProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManualInvoiceProcedure() : base() { }

    }
}