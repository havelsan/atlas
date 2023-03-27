
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSAcccountRule")] 

    /// <summary>
    /// Hesap Kural
    /// </summary>
    public  partial class MhSAcccountRule : TTObject
    {
        public class MhSAcccountRuleList : TTObjectCollection<MhSAcccountRule> { }
                    
        public class ChildMhSAcccountRuleCollection : TTObject.TTChildObjectCollection<MhSAcccountRule>
        {
            public ChildMhSAcccountRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSAcccountRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kural
    /// </summary>
        public string Formula
        {
            get { return (string)this["FORMULA"]; }
            set { this["FORMULA"] = value; }
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
    /// Parametre
    /// </summary>
        public string Parameter
        {
            get { return (string)this["PARAMETER"]; }
            set { this["PARAMETER"] = value; }
        }

        virtual protected void CreateRulesCollection()
        {
            _Rules = new MhSAccount.ChildMhSAccountCollection(this, new Guid("15c420a2-7402-42d7-b0f8-978db4377e4c"));
            ((ITTChildObjectCollection)_Rules).GetChildren();
        }

        protected MhSAccount.ChildMhSAccountCollection _Rules = null;
    /// <summary>
    /// Child collection for Hesap Kuralları
    /// </summary>
        public MhSAccount.ChildMhSAccountCollection Rules
        {
            get
            {
                if (_Rules == null)
                    CreateRulesCollection();
                return _Rules;
            }
        }

        protected MhSAcccountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSAcccountRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSAcccountRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSAcccountRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSAcccountRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSACCCOUNTRULE", dataRow) { }
        protected MhSAcccountRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSACCCOUNTRULE", dataRow, isImported) { }
        public MhSAcccountRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSAcccountRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSAcccountRule() : base() { }

    }
}