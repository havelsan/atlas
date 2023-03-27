
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugSymptomRelationDef")] 

    public  partial class DrugSymptomRelationDef : TerminologyManagerDef
    {
        public class DrugSymptomRelationDefList : TTObjectCollection<DrugSymptomRelationDef> { }
                    
        public class ChildDrugSymptomRelationDefCollection : TTObject.TTChildObjectCollection<DrugSymptomRelationDef>
        {
            public ChildDrugSymptomRelationDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugSymptomRelationDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugSymptomRelationDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDrugSymptomRelationDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugSymptomRelationDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugSymptomRelationDefList_Class() : base() { }
        }

        public static BindingList<DrugSymptomRelationDef.GetDrugSymptomRelationDefList_Class> GetDrugSymptomRelationDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGSYMPTOMRELATIONDEF"].QueryDefs["GetDrugSymptomRelationDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugSymptomRelationDef.GetDrugSymptomRelationDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugSymptomRelationDef.GetDrugSymptomRelationDefList_Class> GetDrugSymptomRelationDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGSYMPTOMRELATIONDEF"].QueryDefs["GetDrugSymptomRelationDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugSymptomRelationDef.GetDrugSymptomRelationDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public SymptomDefinition Symptom
        {
            get { return (SymptomDefinition)((ITTObject)this).GetParent("SYMPTOM"); }
            set { this["SYMPTOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugSymptomRelationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugSymptomRelationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugSymptomRelationDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugSymptomRelationDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugSymptomRelationDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGSYMPTOMRELATIONDEF", dataRow) { }
        protected DrugSymptomRelationDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGSYMPTOMRELATIONDEF", dataRow, isImported) { }
        public DrugSymptomRelationDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugSymptomRelationDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugSymptomRelationDef() : base() { }

    }
}