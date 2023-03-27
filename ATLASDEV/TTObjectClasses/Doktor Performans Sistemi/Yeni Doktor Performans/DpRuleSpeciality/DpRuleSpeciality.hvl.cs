
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DpRuleSpeciality")] 

    public  partial class DpRuleSpeciality : TTDefinitionSet
    {
        public class DpRuleSpecialityList : TTObjectCollection<DpRuleSpeciality> { }
                    
        public class ChildDpRuleSpecialityCollection : TTObject.TTChildObjectCollection<DpRuleSpeciality>
        {
            public ChildDpRuleSpecialityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDpRuleSpecialityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// YasaklıZorunlu Branş
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Yasaklı Zorunlu
    /// </summary>
        public int? BannOrMustType
        {
            get { return (int?)this["BANNORMUSTTYPE"]; }
            set { this["BANNORMUSTTYPE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public DPRuleMaster DPRuleMaster
        {
            get { return (DPRuleMaster)((ITTObject)this).GetParent("DPRULEMASTER"); }
            set { this["DPRULEMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DpRuleSpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DpRuleSpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DpRuleSpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DpRuleSpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DpRuleSpeciality(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPRULESPECIALITY", dataRow) { }
        protected DpRuleSpeciality(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPRULESPECIALITY", dataRow, isImported) { }
        public DpRuleSpeciality(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DpRuleSpeciality(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DpRuleSpeciality() : base() { }

    }
}