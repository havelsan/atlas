
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DpRuleScript")] 

    public  partial class DpRuleScript : TTDefinitionSet
    {
        public class DpRuleScriptList : TTObjectCollection<DpRuleScript> { }
                    
        public class ChildDpRuleScriptCollection : TTObject.TTChildObjectCollection<DpRuleScript>
        {
            public ChildDpRuleScriptCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDpRuleScriptCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gil Kodu
    /// </summary>
        public string Master
        {
            get { return (string)this["MASTER"]; }
            set { this["MASTER"] = value; }
        }

    /// <summary>
    /// Script
    /// </summary>
        public string Script
        {
            get { return (string)this["SCRIPT"]; }
            set { this["SCRIPT"] = value; }
        }

    /// <summary>
    /// Puan Yüzdeliği
    /// </summary>
        public int? PointPercentage
        {
            get { return (int?)this["POINTPERCENTAGE"]; }
            set { this["POINTPERCENTAGE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Kuıral Adı
    /// </summary>
        public string RuleName
        {
            get { return (string)this["RULENAME"]; }
            set { this["RULENAME"] = value; }
        }

        public DPRuleMaster DPRuleMaster
        {
            get { return (DPRuleMaster)((ITTObject)this).GetParent("DPRULEMASTER"); }
            set { this["DPRULEMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DpRuleScript(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DpRuleScript(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DpRuleScript(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DpRuleScript(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DpRuleScript(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPRULESCRIPT", dataRow) { }
        protected DpRuleScript(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPRULESCRIPT", dataRow, isImported) { }
        public DpRuleScript(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DpRuleScript(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DpRuleScript() : base() { }

    }
}