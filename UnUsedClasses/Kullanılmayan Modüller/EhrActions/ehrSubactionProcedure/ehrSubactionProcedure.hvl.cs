
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrSubactionProcedure")] 

    /// <summary>
    /// Hizmetler
    /// </summary>
    public  partial class ehrSubactionProcedure : BaseEhr
    {
        public class ehrSubactionProcedureList : TTObjectCollection<ehrSubactionProcedure> { }
                    
        public class ChildehrSubactionProcedureCollection : TTObject.TTChildObjectCollection<ehrSubactionProcedure>
        {
            public ChildehrSubactionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrSubactionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
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
        public long? Amount
        {
            get { return (long?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrAccountTransactionsCollection()
        {
            _ehrAccountTransactions = new ehrAccountTransaction.ChildehrAccountTransactionCollection(this, new Guid("d67ff632-118b-4d3e-ad91-655a98d0e9ca"));
            ((ITTChildObjectCollection)_ehrAccountTransactions).GetChildren();
        }

        protected ehrAccountTransaction.ChildehrAccountTransactionCollection _ehrAccountTransactions = null;
        public ehrAccountTransaction.ChildehrAccountTransactionCollection ehrAccountTransactions
        {
            get
            {
                if (_ehrAccountTransactions == null)
                    CreateehrAccountTransactionsCollection();
                return _ehrAccountTransactions;
            }
        }

        protected ehrSubactionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrSubactionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrSubactionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrSubactionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrSubactionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRSUBACTIONPROCEDURE", dataRow) { }
        protected ehrSubactionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRSUBACTIONPROCEDURE", dataRow, isImported) { }
        public ehrSubactionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrSubactionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrSubactionProcedure() : base() { }

    }
}