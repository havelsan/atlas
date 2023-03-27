
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DpRuleProcedure")] 

    public  partial class DpRuleProcedure : TTDefinitionSet
    {
        public class DpRuleProcedureList : TTObjectCollection<DpRuleProcedure> { }
                    
        public class ChildDpRuleProcedureCollection : TTObject.TTChildObjectCollection<DpRuleProcedure>
        {
            public ChildDpRuleProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDpRuleProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<DpRuleProcedure> GetDPRuleProcedureWithParameters(TTObjectContext objectContext, string CODE, string MASTER, int BANNORMUST, int TIMETYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DPRULEPROCEDURE"].QueryDefs["GetDPRuleProcedureWithParameters"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);
            paramList.Add("MASTER", MASTER);
            paramList.Add("BANNORMUST", BANNORMUST);
            paramList.Add("TIMETYPE", TIMETYPE);

            return ((ITTQuery)objectContext).QueryObjects<DpRuleProcedure>(queryDef, paramList);
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
    /// YasaklıZorunlu Kod
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
    /// Aynı Farklı Gün
    /// </summary>
        public int? TimeType
        {
            get { return (int?)this["TIMETYPE"]; }
            set { this["TIMETYPE"] = value; }
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

        protected DpRuleProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DpRuleProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DpRuleProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DpRuleProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DpRuleProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DPRULEPROCEDURE", dataRow) { }
        protected DpRuleProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DPRULEPROCEDURE", dataRow, isImported) { }
        public DpRuleProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DpRuleProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DpRuleProcedure() : base() { }

    }
}