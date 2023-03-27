
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugRelation")] 

    /// <summary>
    /// Ek2 Eşdeğerleri
    /// </summary>
    public  partial class DrugRelation : TTObject
    {
        public class DrugRelationList : TTObjectCollection<DrugRelation> { }
                    
        public class ChildDrugRelationCollection : TTObject.TTChildObjectCollection<DrugRelation>
        {
            public ChildDrugRelationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugRelationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? DrugSPTSID
        {
            get { return (int?)this["DRUGSPTSID"]; }
            set { this["DRUGSPTSID"] = value; }
        }

        public DrugDefinition RelationDrug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("RELATIONDRUG"); }
            set { this["RELATIONDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugRelation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugRelation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugRelation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugRelation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGRELATION", dataRow) { }
        protected DrugRelation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGRELATION", dataRow, isImported) { }
        public DrugRelation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugRelation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugRelation() : base() { }

    }
}