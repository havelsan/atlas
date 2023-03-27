
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAccountTransaction")] 

    /// <summary>
    /// Fiyatlar
    /// </summary>
    public  partial class ehrAccountTransaction : BaseEhr
    {
        public class ehrAccountTransactionList : TTObjectCollection<ehrAccountTransaction> { }
                    
        public class ChildehrAccountTransactionCollection : TTObject.TTChildObjectCollection<ehrAccountTransaction>
        {
            public ChildehrAccountTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAccountTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public ehrAccountTransactionStateEnum? State
        {
            get { return (ehrAccountTransactionStateEnum?)(int?)this["STATE"]; }
            set { this["STATE"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Birim fiyat
    /// </summary>
        public double? UnitPrice
        {
            get { return (double?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

        public ehrSubactionProcedure ehrSubactionProcedure
        {
            get { return (ehrSubactionProcedure)((ITTObject)this).GetParent("EHRSUBACTIONPROCEDURE"); }
            set { this["EHRSUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ehrSubactionFlowable ehrSubactionProcedureFlowable
        {
            get { return (ehrSubactionFlowable)((ITTObject)this).GetParent("EHRSUBACTIONPROCEDUREFLOWABLE"); }
            set { this["EHRSUBACTIONPROCEDUREFLOWABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket
    /// </summary>
        public PackageDefinition PackageDefinition
        {
            get { return (PackageDefinition)((ITTObject)this).GetParent("PACKAGEDEFINITION"); }
            set { this["PACKAGEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ehrSubactionMaterial ehrSubactionMaterial
        {
            get { return (ehrSubactionMaterial)((ITTObject)this).GetParent("EHRSUBACTIONMATERIAL"); }
            set { this["EHRSUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrAccountTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAccountTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAccountTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAccountTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAccountTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRACCOUNTTRANSACTION", dataRow) { }
        protected ehrAccountTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRACCOUNTTRANSACTION", dataRow, isImported) { }
        public ehrAccountTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAccountTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAccountTransaction() : base() { }

    }
}