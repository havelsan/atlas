
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SohaRule")] 

    /// <summary>
    /// SUT Kural Tanımları
    /// </summary>
    public  partial class SohaRule : TTObject
    {
        public class SohaRuleList : TTObjectCollection<SohaRule> { }
                    
        public class ChildSohaRuleCollection : TTObject.TTChildObjectCollection<SohaRule>
        {
            public ChildSohaRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSohaRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string ProcedureCode
        {
            get { return (string)this["PROCEDURECODE"]; }
            set { this["PROCEDURECODE"] = value; }
        }

    /// <summary>
    /// Kural Xml
    /// </summary>
        public string Content
        {
            get { return (string)this["CONTENT"]; }
            set { this["CONTENT"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Performans
    /// </summary>
        public bool? Performance
        {
            get { return (bool?)this["PERFORMANCE"]; }
            set { this["PERFORMANCE"] = value; }
        }

    /// <summary>
    /// Silindi
    /// </summary>
        public bool? IsDeleted
        {
            get { return (bool?)this["ISDELETED"]; }
            set { this["ISDELETED"] = value; }
        }

    /// <summary>
    /// Hizmet Giriş Uyarı/Blokla
    /// </summary>
        public bool? BlockRequest
        {
            get { return (bool?)this["BLOCKREQUEST"]; }
            set { this["BLOCKREQUEST"] = value; }
        }

    /// <summary>
    /// Kural Grubu
    /// </summary>
        public SohaRuleGroup RuleGroup
        {
            get { return (SohaRuleGroup)((ITTObject)this).GetParent("RULEGROUP"); }
            set { this["RULEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSohaRuleLogsCollection()
        {
            _SohaRuleLogs = new SohaRuleLog.ChildSohaRuleLogCollection(this, new Guid("1b308848-b561-4b99-a690-16bf78863d12"));
            ((ITTChildObjectCollection)_SohaRuleLogs).GetChildren();
        }

        protected SohaRuleLog.ChildSohaRuleLogCollection _SohaRuleLogs = null;
        public SohaRuleLog.ChildSohaRuleLogCollection SohaRuleLogs
        {
            get
            {
                if (_SohaRuleLogs == null)
                    CreateSohaRuleLogsCollection();
                return _SohaRuleLogs;
            }
        }

        protected SohaRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SohaRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SohaRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SohaRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SohaRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOHARULE", dataRow) { }
        protected SohaRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOHARULE", dataRow, isImported) { }
        public SohaRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SohaRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SohaRule() : base() { }

    }
}