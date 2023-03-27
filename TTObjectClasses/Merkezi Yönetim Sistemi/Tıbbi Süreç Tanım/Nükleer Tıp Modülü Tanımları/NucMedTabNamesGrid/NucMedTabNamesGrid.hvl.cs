
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NucMedTabNamesGrid")] 

    public  partial class NucMedTabNamesGrid : TTDefinitionSet
    {
        public class NucMedTabNamesGridList : TTObjectCollection<NucMedTabNamesGrid> { }
                    
        public class ChildNucMedTabNamesGridCollection : TTObject.TTChildObjectCollection<NucMedTabNamesGrid>
        {
            public ChildNucMedTabNamesGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNucMedTabNamesGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<NucMedTabNamesGrid> GetByTabNames(TTObjectContext objectContext, string PARAMTAB)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDTABNAMESGRID"].QueryDefs["GetByTabNames"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMTAB", PARAMTAB);

            return ((ITTQuery)objectContext).QueryObjects<NucMedTabNamesGrid>(queryDef, paramList);
        }

    /// <summary>
    /// Tab Order
    /// </summary>
        public string TabOrder
        {
            get { return (string)this["TABORDER"]; }
            set { this["TABORDER"] = value; }
        }

        public NuclearMedicineTestDefinition NuclearMedicineTest
        {
            get { return (NuclearMedicineTestDefinition)((ITTObject)this).GetParent("NUCLEARMEDICINETEST"); }
            set { this["NUCLEARMEDICINETEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NucMedTestGroupDef NuclearMedicineTestGroup
        {
            get { return (NucMedTestGroupDef)((ITTObject)this).GetParent("NUCLEARMEDICINETESTGROUP"); }
            set { this["NUCLEARMEDICINETESTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NucMedTabNamesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NucMedTabNamesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NucMedTabNamesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NucMedTabNamesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NucMedTabNamesGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCMEDTABNAMESGRID", dataRow) { }
        protected NucMedTabNamesGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCMEDTABNAMESGRID", dataRow, isImported) { }
        public NucMedTabNamesGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NucMedTabNamesGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NucMedTabNamesGrid() : base() { }

    }
}