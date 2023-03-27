
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSFinancialStatements")] 

    /// <summary>
    /// Mali Tablolar
    /// </summary>
    public  partial class MhSFinancialStatements : TTObject
    {
        public class MhSFinancialStatementsList : TTObjectCollection<MhSFinancialStatements> { }
                    
        public class ChildMhSFinancialStatementsCollection : TTObject.TTChildObjectCollection<MhSFinancialStatements>
        {
            public ChildMhSFinancialStatementsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSFinancialStatementsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("90ae3da5-a9d8-488b-a536-0820446360bf"); } }
            public static Guid Edit { get { return new Guid("04c5f28c-5d59-4bc6-bf0e-6d7e2d58954e"); } }
            public static Guid Complete { get { return new Guid("5d290bda-faf8-4406-b9fb-ac64e6757d0a"); } }
        }

    /// <summary>
    /// Başlangıç
    /// </summary>
        public int? Start
        {
            get { return (int?)this["START"]; }
            set { this["START"] = value; }
        }

    /// <summary>
    /// Tablo Türü
    /// </summary>
        public MhSFinancialStatementTypeEnum? StatementType
        {
            get { return (MhSFinancialStatementTypeEnum?)(int?)this["STATEMENTTYPE"]; }
            set { this["STATEMENTTYPE"] = value; }
        }

    /// <summary>
    /// Döküm Alınacak Ay
    /// </summary>
        public MhSAccountingMonths? Month
        {
            get { return (MhSAccountingMonths?)(int?)this["MONTH"]; }
            set { this["MONTH"] = value; }
        }

    /// <summary>
    /// Değeri Sıfır Olan Satırlar Gösterilsin
    /// </summary>
        public bool? ShowEmptyLines
        {
            get { return (bool?)this["SHOWEMPTYLINES"]; }
            set { this["SHOWEMPTYLINES"] = value; }
        }

    /// <summary>
    /// Bitiş
    /// </summary>
        public int? Finish
        {
            get { return (int?)this["FINISH"]; }
            set { this["FINISH"] = value; }
        }

    /// <summary>
    /// Önceki Ayların Yekünleri Dahil Edilsin
    /// </summary>
        public bool? FromStart
        {
            get { return (bool?)this["FROMSTART"]; }
            set { this["FROMSTART"] = value; }
        }

    /// <summary>
    /// Yaratılma Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Tutar Ölçeği
    /// </summary>
        public MhSAmountScales? Scale
        {
            get { return (MhSAmountScales?)(int?)this["SCALE"]; }
            set { this["SCALE"] = value; }
        }

    /// <summary>
    /// Tablo Başlığı
    /// </summary>
        public string Header
        {
            get { return (string)this["HEADER"]; }
            set { this["HEADER"] = value; }
        }

    /// <summary>
    /// Dipnot
    /// </summary>
        public string Footnote
        {
            get { return (string)this["FOOTNOTE"]; }
            set { this["FOOTNOTE"] = value; }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? Year
        {
            get { return (int?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// Çalışma Yılı
    /// </summary>
        public MhSPeriod Period
        {
            get { return (MhSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önceki Değerlerin Alınacağı Dönem
    /// </summary>
        public MhSAccount PreviousPeriod
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("PREVIOUSPERIOD"); }
            set { this["PREVIOUSPERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mali Tablo Tanımı
    /// </summary>
        public MhSFinancialStatementDefinition Definition
        {
            get { return (MhSFinancialStatementDefinition)((ITTObject)this).GetParent("DEFINITION"); }
            set { this["DEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateLinesCollection()
        {
            _Lines = new MhSFinancialStatementLine.ChildMhSFinancialStatementLineCollection(this, new Guid("3660dac9-79f6-4c6b-a059-3b1527f1a562"));
            ((ITTChildObjectCollection)_Lines).GetChildren();
        }

        protected MhSFinancialStatementLine.ChildMhSFinancialStatementLineCollection _Lines = null;
    /// <summary>
    /// Child collection for Tablo
    /// </summary>
        public MhSFinancialStatementLine.ChildMhSFinancialStatementLineCollection Lines
        {
            get
            {
                if (_Lines == null)
                    CreateLinesCollection();
                return _Lines;
            }
        }

        protected MhSFinancialStatements(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSFinancialStatements(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSFinancialStatements(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSFinancialStatements(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSFinancialStatements(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSFINANCIALSTATEMENTS", dataRow) { }
        protected MhSFinancialStatements(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSFINANCIALSTATEMENTS", dataRow, isImported) { }
        public MhSFinancialStatements(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSFinancialStatements(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSFinancialStatements() : base() { }

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