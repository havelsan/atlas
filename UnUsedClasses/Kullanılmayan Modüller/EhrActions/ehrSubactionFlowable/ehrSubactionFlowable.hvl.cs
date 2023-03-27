
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrSubactionFlowable")] 

    public  partial class ehrSubactionFlowable : ehrEpisodeAction
    {
        public class ehrSubactionFlowableList : TTObjectCollection<ehrSubactionFlowable> { }
                    
        public class ChildehrSubactionFlowableCollection : TTObject.TTChildObjectCollection<ehrSubactionFlowable>
        {
            public ChildehrSubactionFlowableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrSubactionFlowableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public long? Amount
        {
            get { return (long?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ehrEpisodeAction ehrEpisodeAction
        {
            get { return (ehrEpisodeAction)((ITTObject)this).GetParent("EHREPISODEACTION"); }
            set { this["EHREPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlem Adı
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrAccountTransactionsCollection()
        {
            _ehrAccountTransactions = new ehrAccountTransaction.ChildehrAccountTransactionCollection(this, new Guid("6905b7f1-5bea-4365-9e1c-08197e4df129"));
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

        virtual protected void CreateehrSFBaseNursingOrderCollection()
        {
            _ehrSFBaseNursingOrder = new ehrBaseNursingOrder.ChildehrBaseNursingOrderCollection(this, new Guid("653d13f9-37da-415a-9ba3-6fc5ba725f09"));
            ((ITTChildObjectCollection)_ehrSFBaseNursingOrder).GetChildren();
        }

        protected ehrBaseNursingOrder.ChildehrBaseNursingOrderCollection _ehrSFBaseNursingOrder = null;
    /// <summary>
    /// Child collection for İstek Yapılan İşlem-Hemşire Talimatları
    /// </summary>
        public ehrBaseNursingOrder.ChildehrBaseNursingOrderCollection ehrSFBaseNursingOrder
        {
            get
            {
                if (_ehrSFBaseNursingOrder == null)
                    CreateehrSFBaseNursingOrderCollection();
                return _ehrSFBaseNursingOrder;
            }
        }

        protected ehrSubactionFlowable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrSubactionFlowable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrSubactionFlowable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrSubactionFlowable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrSubactionFlowable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRSUBACTIONFLOWABLE", dataRow) { }
        protected ehrSubactionFlowable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRSUBACTIONFLOWABLE", dataRow, isImported) { }
        public ehrSubactionFlowable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrSubactionFlowable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrSubactionFlowable() : base() { }

    }
}