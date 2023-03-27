
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManuelEquivalentDrug")] 

    public  partial class ManuelEquivalentDrug : TerminologyManagerDef
    {
        public class ManuelEquivalentDrugList : TTObjectCollection<ManuelEquivalentDrug> { }
                    
        public class ChildManuelEquivalentDrugCollection : TTObject.TTChildObjectCollection<ManuelEquivalentDrug>
        {
            public ChildManuelEquivalentDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManuelEquivalentDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetManuelEquivalentDrugs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? EquivalentDrug
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EQUIVALENTDRUG"]);
                }
            }

            public GetManuelEquivalentDrugs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManuelEquivalentDrugs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManuelEquivalentDrugs_Class() : base() { }
        }

        public static BindingList<ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class> GetManuelEquivalentDrugs(Guid DRUG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUELEQUIVALENTDRUG"].QueryDefs["GetManuelEquivalentDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUG", DRUG);

            return TTReportNqlObject.QueryObjects<ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class> GetManuelEquivalentDrugs(TTObjectContext objectContext, Guid DRUG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUELEQUIVALENTDRUG"].QueryDefs["GetManuelEquivalentDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUG", DRUG);

            return TTReportNqlObject.QueryObjects<ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class>(objectContext, queryDef, paramList, pi);
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition EquivalentDrug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("EQUIVALENTDRUG"); }
            set { this["EQUIVALENTDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManuelEquivalentDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManuelEquivalentDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManuelEquivalentDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManuelEquivalentDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManuelEquivalentDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANUELEQUIVALENTDRUG", dataRow) { }
        protected ManuelEquivalentDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANUELEQUIVALENTDRUG", dataRow, isImported) { }
        public ManuelEquivalentDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManuelEquivalentDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManuelEquivalentDrug() : base() { }

    }
}