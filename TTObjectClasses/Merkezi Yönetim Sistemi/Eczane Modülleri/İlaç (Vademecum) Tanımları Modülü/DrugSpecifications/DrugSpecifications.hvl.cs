
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugSpecifications")] 

    /// <summary>
    /// İlaç Özellikleri
    /// </summary>
    public  partial class DrugSpecifications : TTObject
    {
        public class DrugSpecificationsList : TTObjectCollection<DrugSpecifications> { }
                    
        public class ChildDrugSpecificationsCollection : TTObject.TTChildObjectCollection<DrugSpecifications>
        {
            public ChildDrugSpecificationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugSpecificationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTypeOfDrugDefinition_Class : TTReportNqlObject 
        {
            public DrugSpecificationEnum? DrugSpecification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGSPECIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGSPECIFICATIONS"].AllPropertyDefs["DRUGSPECIFICATION"].DataType;
                    return (DrugSpecificationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetTypeOfDrugDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTypeOfDrugDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTypeOfDrugDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefIDBySpesifications_Class : TTReportNqlObject 
        {
            public Guid? DrugDefinition
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGDEFINITION"]);
                }
            }

            public GetDrugDefIDBySpesifications_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefIDBySpesifications_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefIDBySpesifications_Class() : base() { }
        }

        public static BindingList<DrugSpecifications.GetTypeOfDrugDefinition_Class> GetTypeOfDrugDefinition(Guid DRUGDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGSPECIFICATIONS"].QueryDefs["GetTypeOfDrugDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGDEFINITION", DRUGDEFINITION);

            return TTReportNqlObject.QueryObjects<DrugSpecifications.GetTypeOfDrugDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugSpecifications.GetTypeOfDrugDefinition_Class> GetTypeOfDrugDefinition(TTObjectContext objectContext, Guid DRUGDEFINITION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGSPECIFICATIONS"].QueryDefs["GetTypeOfDrugDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGDEFINITION", DRUGDEFINITION);

            return TTReportNqlObject.QueryObjects<DrugSpecifications.GetTypeOfDrugDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugSpecifications.GetDrugDefIDBySpesifications_Class> GetDrugDefIDBySpesifications(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGSPECIFICATIONS"].QueryDefs["GetDrugDefIDBySpesifications"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugSpecifications.GetDrugDefIDBySpesifications_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugSpecifications.GetDrugDefIDBySpesifications_Class> GetDrugDefIDBySpesifications(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGSPECIFICATIONS"].QueryDefs["GetDrugDefIDBySpesifications"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugSpecifications.GetDrugDefIDBySpesifications_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İlaç Özelliği
    /// </summary>
        public DrugSpecificationEnum? DrugSpecification
        {
            get { return (DrugSpecificationEnum?)(int?)this["DRUGSPECIFICATION"]; }
            set { this["DRUGSPECIFICATION"] = value; }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DrugSpecifications(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugSpecifications(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugSpecifications(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugSpecifications(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugSpecifications(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGSPECIFICATIONS", dataRow) { }
        protected DrugSpecifications(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGSPECIFICATIONS", dataRow, isImported) { }
        public DrugSpecifications(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugSpecifications(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugSpecifications() : base() { }

    }
}