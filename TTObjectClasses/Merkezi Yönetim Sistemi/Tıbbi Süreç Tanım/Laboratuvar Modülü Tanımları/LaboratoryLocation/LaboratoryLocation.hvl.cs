
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryLocation")] 

    public  partial class LaboratoryLocation : TTObject
    {
        public class LaboratoryLocationList : TTObjectCollection<LaboratoryLocation> { }
                    
        public class ChildLaboratoryLocationCollection : TTObject.TTChildObjectCollection<LaboratoryLocation>
        {
            public ChildLaboratoryLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<LaboratoryLocation> GetByTab(TTObjectContext objectContext, string PARAMTAB)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYLOCATION"].QueryDefs["GetByTab"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryLocation>(queryDef, paramList);
        }

        public static BindingList<LaboratoryLocation> GetByTest(TTObjectContext objectContext, string PARAMTEST)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYLOCATION"].QueryDefs["GetByTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTEST", PARAMTEST);

            return ((ITTQuery)objectContext).QueryObjects<LaboratoryLocation>(queryDef, paramList);
        }

    /// <summary>
    /// Sıra Numarası
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Tetkik Adı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition Test
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("TEST"); }
            set { this["TEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bulunduğu Tab İlişkisi
    /// </summary>
        public LaboratoryRequestFormTabDefinition Tab
        {
            get { return (LaboratoryRequestFormTabDefinition)((ITTObject)this).GetParent("TAB"); }
            set { this["TAB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYLOCATION", dataRow) { }
        protected LaboratoryLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYLOCATION", dataRow, isImported) { }
        public LaboratoryLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryLocation() : base() { }

    }
}