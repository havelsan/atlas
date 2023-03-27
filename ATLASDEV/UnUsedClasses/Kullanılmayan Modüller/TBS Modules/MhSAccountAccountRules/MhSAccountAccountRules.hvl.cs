
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSAccountAccountRules")] 

    /// <summary>
    /// Hesap Kuralları
    /// </summary>
    public  partial class MhSAccountAccountRules : TTObject
    {
        public class MhSAccountAccountRulesList : TTObjectCollection<MhSAccountAccountRules> { }
                    
        public class ChildMhSAccountAccountRulesCollection : TTObject.TTChildObjectCollection<MhSAccountAccountRules>
        {
            public ChildMhSAccountAccountRulesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSAccountAccountRulesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Paremetre Değeri
    /// </summary>
        public int? PrameterValue
        {
            get { return (int?)this["PRAMETERVALUE"]; }
            set { this["PRAMETERVALUE"] = value; }
        }

    /// <summary>
    /// Hesap Kuralları Kural
    /// </summary>
        public MhSAcccountRule Rule
        {
            get { return (MhSAcccountRule)((ITTObject)this).GetParent("RULE"); }
            set { this["RULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hesap Kuralları
    /// </summary>
        public MhSAccount Hesap
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("HESAP"); }
            set { this["HESAP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSAccountAccountRules(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSAccountAccountRules(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSAccountAccountRules(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSAccountAccountRules(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSAccountAccountRules(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSACCOUNTACCOUNTRULES", dataRow) { }
        protected MhSAccountAccountRules(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSACCOUNTACCOUNTRULES", dataRow, isImported) { }
        public MhSAccountAccountRules(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSAccountAccountRules(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSAccountAccountRules() : base() { }

    }
}