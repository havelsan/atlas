
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnitDefinition")] 

    /// <summary>
    /// Malzemelerin Birim tanımları için kullanılan sınıftır
    /// </summary>
    public  partial class UnitDefinition : TerminologyManagerDef
    {
        public class UnitDefinitionList : TTObjectCollection<UnitDefinition> { }
                    
        public class ChildUnitDefinitionCollection : TTObject.TTChildObjectCollection<UnitDefinition>
        {
            public ChildUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<UnitDefinition> GetUnitDefinitionByVademecumUnitID(TTObjectContext objectContext, long VADEMECUMUNITID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITDEFINITION"].QueryDefs["GetUnitDefinitionByVademecumUnitID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("VADEMECUMUNITID", VADEMECUMUNITID);

            return ((ITTQuery)objectContext).QueryObjects<UnitDefinition>(queryDef, paramList);
        }

        public static BindingList<UnitDefinition> GetUnitDefbyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITDEFINITION"].QueryDefs["GetUnitDefbyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<UnitDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Maddenin Hali
    /// </summary>
        public PhysicalConditionTypeEnum? PhysicalCondition
        {
            get { return (PhysicalConditionTypeEnum?)(int?)this["PHYSICALCONDITION"]; }
            set { this["PHYSICALCONDITION"] = value; }
        }

        public long? VademecumUnitID
        {
            get { return (long?)this["VADEMECUMUNITID"]; }
            set { this["VADEMECUMUNITID"] = value; }
        }

    /// <summary>
    /// Kısa Açıklama
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected UnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNITDEFINITION", dataRow) { }
        protected UnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNITDEFINITION", dataRow, isImported) { }
        public UnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnitDefinition() : base() { }

    }
}