
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DietLabTestRelationDefiniton")] 

    /// <summary>
    /// Diyette Gösterilecek Testler
    /// </summary>
    public  partial class DietLabTestRelationDefiniton : TerminologyManagerDef
    {
        public class DietLabTestRelationDefinitonList : TTObjectCollection<DietLabTestRelationDefiniton> { }
                    
        public class ChildDietLabTestRelationDefinitonCollection : TTObject.TTChildObjectCollection<DietLabTestRelationDefiniton>
        {
            public ChildDietLabTestRelationDefinitonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDietLabTestRelationDefinitonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDietLabList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDietLabList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietLabList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietLabList_Class() : base() { }
        }

        public static BindingList<DietLabTestRelationDefiniton.GetDietLabList_Class> GetDietLabList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETLABTESTRELATIONDEFINITON"].QueryDefs["GetDietLabList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietLabTestRelationDefiniton.GetDietLabList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietLabTestRelationDefiniton.GetDietLabList_Class> GetDietLabList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETLABTESTRELATIONDEFINITON"].QueryDefs["GetDietLabList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietLabTestRelationDefiniton.GetDietLabList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public LaboratoryTestDefinition DietLaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("DIETLABORATORYTEST"); }
            set { this["DIETLABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DietLabTestRelationDefiniton(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DietLabTestRelationDefiniton(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DietLabTestRelationDefiniton(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DietLabTestRelationDefiniton(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DietLabTestRelationDefiniton(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIETLABTESTRELATIONDEFINITON", dataRow) { }
        protected DietLabTestRelationDefiniton(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIETLABTESTRELATIONDEFINITON", dataRow, isImported) { }
        public DietLabTestRelationDefiniton(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DietLabTestRelationDefiniton(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DietLabTestRelationDefiniton() : base() { }

    }
}