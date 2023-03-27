
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSSlip")] 

    /// <summary>
    /// Fiş
    /// </summary>
    public  partial class MhSSlip : TTObject
    {
        public class MhSSlipList : TTObjectCollection<MhSSlip> { }
                    
        public class ChildMhSSlipCollection : TTObject.TTChildObjectCollection<MhSSlip>
        {
            public ChildMhSSlipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSSlipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Definite { get { return new Guid("9dfa84ab-6079-4f40-993f-9e7dbb826774"); } }
            public static Guid New { get { return new Guid("11a25e76-b4d5-48a8-afe8-9735fa640435"); } }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Gönderme Emri No
    /// </summary>
        public string SendOrderNo
        {
            get { return (string)this["SENDORDERNO"]; }
            set { this["SENDORDERNO"] = value; }
        }

    /// <summary>
    /// Yevmiye Numarası
    /// </summary>
        public int? JournalNo
        {
            get { return (int?)this["JOURNALNO"]; }
            set { this["JOURNALNO"] = value; }
        }

    /// <summary>
    /// İlgili
    /// </summary>
        public string Related
        {
            get { return (string)this["RELATED"]; }
            set { this["RELATED"] = value; }
        }

    /// <summary>
    /// Borç Toplam
    /// </summary>
        public double? Debit
        {
            get { return (double?)this["DEBIT"]; }
            set { this["DEBIT"] = value; }
        }

    /// <summary>
    /// Belge Düzenleme Nedeni
    /// </summary>
        public string WhyCreated
        {
            get { return (string)this["WHYCREATED"]; }
            set { this["WHYCREATED"] = value; }
        }

    /// <summary>
    /// Çek No
    /// </summary>
        public string ChequeNo
        {
            get { return (string)this["CHEQUENO"]; }
            set { this["CHEQUENO"] = value; }
        }

    /// <summary>
    /// Dönem
    /// </summary>
        public MhSAccountingMonths? Month
        {
            get { return (MhSAccountingMonths?)(int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

    /// <summary>
    /// Fiş No
    /// </summary>
        public int? SlipNo
        {
            get { return (int?)this["SLIPNO"]; }
            set { this["SLIPNO"] = value; }
        }

    /// <summary>
    /// Yevmiye Tarihi
    /// </summary>
        public DateTime? JournalDate
        {
            get { return (DateTime?)this["JOURNALDATE"]; }
            set { this["JOURNALDATE"] = value; }
        }

    /// <summary>
    /// Vezne Alındı No
    /// </summary>
        public string CashDeskTakenNo
        {
            get { return (string)this["CASHDESKTAKENNO"]; }
            set { this["CASHDESKTAKENNO"] = value; }
        }

    /// <summary>
    /// Bakiye
    /// </summary>
        public double? Balance
        {
            get { return (double?)this["BALANCE"]; }
            set { this["BALANCE"] = value; }
        }

    /// <summary>
    /// Men.Kıy.Alındı No
    /// </summary>
        public string CreditTakenNo
        {
            get { return (string)this["CREDITTAKENNO"]; }
            set { this["CREDITTAKENNO"] = value; }
        }

    /// <summary>
    /// Alacak Toplam
    /// </summary>
        public double? Credit
        {
            get { return (double?)this["CREDIT"]; }
            set { this["CREDIT"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public MhSSlipTypesEnum? Type
        {
            get { return (MhSSlipTypesEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Fiş Etiket 2
    /// </summary>
        public MhSSlipGroup Group2
        {
            get { return (MhSSlipGroup)((ITTObject)this).GetParent("GROUP2"); }
            set { this["GROUP2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Şablon
    /// </summary>
        public MhSTemplate Template
        {
            get { return (MhSTemplate)((ITTObject)this).GetParent("TEMPLATE"); }
            set { this["TEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fiş Etiket 1
    /// </summary>
        public MhSSlipGroup Group1
        {
            get { return (MhSSlipGroup)((ITTObject)this).GetParent("GROUP1"); }
            set { this["GROUP1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateJournalEntriesCollection()
        {
            _JournalEntries = new MhSJournalEntry.ChildMhSJournalEntryCollection(this, new Guid("1ea4e231-55d7-4e61-a152-29fb1df270bf"));
            ((ITTChildObjectCollection)_JournalEntries).GetChildren();
        }

        protected MhSJournalEntry.ChildMhSJournalEntryCollection _JournalEntries = null;
    /// <summary>
    /// Child collection for Fiş Maddeleri
    /// </summary>
        public MhSJournalEntry.ChildMhSJournalEntryCollection JournalEntries
        {
            get
            {
                if (_JournalEntries == null)
                    CreateJournalEntriesCollection();
                return _JournalEntries;
            }
        }

        protected MhSSlip(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSSlip(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSSlip(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSSlip(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSSlip(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSSLIP", dataRow) { }
        protected MhSSlip(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSSLIP", dataRow, isImported) { }
        public MhSSlip(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSSlip(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSSlip() : base() { }

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