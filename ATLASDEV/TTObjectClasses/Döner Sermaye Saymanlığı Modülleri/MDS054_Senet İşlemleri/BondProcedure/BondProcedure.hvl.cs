
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondProcedure")] 

    public  partial class BondProcedure : TTObject
    {
        public class BondProcedureList : TTObjectCollection<BondProcedure> { }
                    
        public class ChildBondProcedureCollection : TTObject.TTChildObjectCollection<BondProcedure>
        {
            public ChildBondProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
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
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Kalan Tutar
    /// </summary>
        public Currency? RemainingPrice
        {
            get { return (Currency?)this["REMAININGPRICE"]; }
            set { this["REMAININGPRICE"] = value; }
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
    /// Birim Fiyat
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

        public Bond Bond
        {
            get { return (Bond)((ITTObject)this).GetParent("BOND"); }
            set { this["BOND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BondProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDPROCEDURE", dataRow) { }
        protected BondProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDPROCEDURE", dataRow, isImported) { }
        public BondProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondProcedure() : base() { }

    }
}