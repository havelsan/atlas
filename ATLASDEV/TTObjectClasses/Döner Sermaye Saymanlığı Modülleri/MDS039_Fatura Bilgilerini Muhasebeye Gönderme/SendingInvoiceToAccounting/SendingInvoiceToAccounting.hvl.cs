
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendingInvoiceToAccounting")] 

    /// <summary>
    /// Fatura Bilgilerini Muhasebeye Gönderme
    /// </summary>
    public  partial class SendingInvoiceToAccounting : AccountAction, IWorkListBaseAction
    {
        public class SendingInvoiceToAccountingList : TTObjectCollection<SendingInvoiceToAccounting> { }
                    
        public class ChildSendingInvoiceToAccountingCollection : TTObject.TTChildObjectCollection<SendingInvoiceToAccounting>
        {
            public ChildSendingInvoiceToAccountingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendingInvoiceToAccountingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("12275c9b-693e-4f1e-8349-7e21cf5b7ed5"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("b055fed1-05e4-4e7d-914e-baa437b858ba"); } }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        virtual protected void CreateSendingInvoiceDetailsCollection()
        {
            _SendingInvoiceDetails = new SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection(this, new Guid("ee845bda-dc6a-4d38-a9f9-c844fe788ca1"));
            ((ITTChildObjectCollection)_SendingInvoiceDetails).GetChildren();
        }

        protected SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection _SendingInvoiceDetails = null;
    /// <summary>
    /// Child collection for Fatura bilgilerini muhasebeye gönderme işlemi ile ilişki
    /// </summary>
        public SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection SendingInvoiceDetails
        {
            get
            {
                if (_SendingInvoiceDetails == null)
                    CreateSendingInvoiceDetailsCollection();
                return _SendingInvoiceDetails;
            }
        }

        protected SendingInvoiceToAccounting(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendingInvoiceToAccounting(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendingInvoiceToAccounting(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendingInvoiceToAccounting(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendingInvoiceToAccounting(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDINGINVOICETOACCOUNTING", dataRow) { }
        protected SendingInvoiceToAccounting(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDINGINVOICETOACCOUNTING", dataRow, isImported) { }
        public SendingInvoiceToAccounting(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendingInvoiceToAccounting(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendingInvoiceToAccounting() : base() { }

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