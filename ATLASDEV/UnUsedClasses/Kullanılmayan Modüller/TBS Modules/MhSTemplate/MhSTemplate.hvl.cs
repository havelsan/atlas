
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTemplate")] 

    /// <summary>
    /// Fiş Şablon
    /// </summary>
    public  partial class MhSTemplate : TTObject
    {
        public class MhSTemplateList : TTObjectCollection<MhSTemplate> { }
                    
        public class ChildMhSTemplateCollection : TTObject.TTChildObjectCollection<MhSTemplate>
        {
            public ChildMhSTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birim Kodu
    /// </summary>
        public int? Unit
        {
            get { return (int?)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

    /// <summary>
    /// Başlangıç Dönemi
    /// </summary>
        public MhSAccountingMonths? OperationMonthStart
        {
            get { return (MhSAccountingMonths?)(int?)this["OPERATIONMONTHSTART"]; }
            set { this["OPERATIONMONTHSTART"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
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
    /// Fiş Tutarı
    /// </summary>
        public double? TotalAmount
        {
            get { return (double?)this["TOTALAMOUNT"]; }
            set { this["TOTALAMOUNT"] = value; }
        }

    /// <summary>
    /// Bitiş Dönemi
    /// </summary>
        public MhSAccountingMonths? OperationMonthFinish
        {
            get { return (MhSAccountingMonths?)(int?)this["OPERATIONMONTHFINISH"]; }
            set { this["OPERATIONMONTHFINISH"] = value; }
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
    /// Saymanlık Kodu
    /// </summary>
        public int? PayrollDivision
        {
            get { return (int?)this["PAYROLLDIVISION"]; }
            set { this["PAYROLLDIVISION"] = value; }
        }

    /// <summary>
    /// Tip
    /// </summary>
        public MhSTemplateTypes? Type
        {
            get { return (MhSTemplateTypes?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
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
    /// Yevmiye Tarihi
    /// </summary>
        public DateTime? JournalDate
        {
            get { return (DateTime?)this["JOURNALDATE"]; }
            set { this["JOURNALDATE"] = value; }
        }

    /// <summary>
    /// Belge No
    /// </summary>
        public string DocumentNo
        {
            get { return (string)this["DOCUMENTNO"]; }
            set { this["DOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Departman Kodu
    /// </summary>
        public int? Department
        {
            get { return (int?)this["DEPARTMENT"]; }
            set { this["DEPARTMENT"] = value; }
        }

    /// <summary>
    /// İkincil Fiş Etiketi
    /// </summary>
        public MhSSlipGroup Group2
        {
            get { return (MhSSlipGroup)((ITTObject)this).GetParent("GROUP2"); }
            set { this["GROUP2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birincil Fiş Etiketi
    /// </summary>
        public MhSSlipGroup Group1
        {
            get { return (MhSSlipGroup)((ITTObject)this).GetParent("GROUP1"); }
            set { this["GROUP1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTemplateLinesCollection()
        {
            _TemplateLines = new MhSTemplateLine.ChildMhSTemplateLineCollection(this, new Guid("c3477267-0c55-46a5-8e92-1133de4cd30b"));
            ((ITTChildObjectCollection)_TemplateLines).GetChildren();
        }

        protected MhSTemplateLine.ChildMhSTemplateLineCollection _TemplateLines = null;
    /// <summary>
    /// Child collection for Şablon Satırları
    /// </summary>
        public MhSTemplateLine.ChildMhSTemplateLineCollection TemplateLines
        {
            get
            {
                if (_TemplateLines == null)
                    CreateTemplateLinesCollection();
                return _TemplateLines;
            }
        }

        virtual protected void CreateRulesCollection()
        {
            _Rules = new MhSTemplateRule.ChildMhSTemplateRuleCollection(this, new Guid("8e673299-cfec-43b3-a520-d1b1e6e35c24"));
            ((ITTChildObjectCollection)_Rules).GetChildren();
        }

        protected MhSTemplateRule.ChildMhSTemplateRuleCollection _Rules = null;
    /// <summary>
    /// Child collection for Kurallar
    /// </summary>
        public MhSTemplateRule.ChildMhSTemplateRuleCollection Rules
        {
            get
            {
                if (_Rules == null)
                    CreateRulesCollection();
                return _Rules;
            }
        }

        protected MhSTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTEMPLATE", dataRow) { }
        protected MhSTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTEMPLATE", dataRow, isImported) { }
        public MhSTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTemplate() : base() { }

    }
}