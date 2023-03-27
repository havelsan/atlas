
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReadyToCollectedInvoice")] 

    /// <summary>
    /// Toplu Faturaya Hazırlama İşlemi
    /// </summary>
    public  partial class ReadyToCollectedInvoice : BaseAction, IWorkListBaseAction
    {
        public class ReadyToCollectedInvoiceList : TTObjectCollection<ReadyToCollectedInvoice> { }
                    
        public class ChildReadyToCollectedInvoiceCollection : TTObject.TTChildObjectCollection<ReadyToCollectedInvoice>
        {
            public ChildReadyToCollectedInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReadyToCollectedInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fe225997-c74a-4363-ad84-df4c3a5c2cdc"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("b7c5746b-fa90-4f7c-a0e9-3ba9ae8df4d3"); } }
        }

    /// <summary>
    /// Hizmet Grubu
    /// </summary>
        public CollectedInvoiceProcedureGroupEnum? ProcedureGroup
        {
            get { return (CollectedInvoiceProcedureGroupEnum?)(int?)this["PROCEDUREGROUP"]; }
            set { this["PROCEDUREGROUP"] = value; }
        }

        public PayerInvoicePatientStatusEnum? PayerInvoicePatientStatus
        {
            get { return (PayerInvoicePatientStatusEnum?)(int?)this["PAYERINVOICEPATIENTSTATUS"]; }
            set { this["PAYERINVOICEPATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Hastanın Durumu
    /// </summary>
        public OutPatientInPatientEnum? PATIENTSTATUS
        {
            get { return (OutPatientInPatientEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? STARTDATE
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? ENDDATE
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public CashierLog CashierLog
        {
            get { return (CashierLog)((ITTObject)this).GetParent("CASHIERLOG"); }
            set { this["CASHIERLOG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReadyToCollectedInvoiceDetailsCollection()
        {
            _ReadyToCollectedInvoiceDetails = new ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection(this, new Guid("48ae4690-2235-40af-99e8-6a24f05f9405"));
            ((ITTChildObjectCollection)_ReadyToCollectedInvoiceDetails).GetChildren();
        }

        protected ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection _ReadyToCollectedInvoiceDetails = null;
        public ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection ReadyToCollectedInvoiceDetails
        {
            get
            {
                if (_ReadyToCollectedInvoiceDetails == null)
                    CreateReadyToCollectedInvoiceDetailsCollection();
                return _ReadyToCollectedInvoiceDetails;
            }
        }

        protected ReadyToCollectedInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReadyToCollectedInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReadyToCollectedInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReadyToCollectedInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReadyToCollectedInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "READYTOCOLLECTEDINVOICE", dataRow) { }
        protected ReadyToCollectedInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "READYTOCOLLECTEDINVOICE", dataRow, isImported) { }
        public ReadyToCollectedInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReadyToCollectedInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReadyToCollectedInvoice() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}