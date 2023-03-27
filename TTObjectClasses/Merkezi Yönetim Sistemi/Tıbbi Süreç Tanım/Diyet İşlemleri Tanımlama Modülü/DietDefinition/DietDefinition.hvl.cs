
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DietDefinition")] 

    /// <summary>
    /// Diyet İşlemleri Tanımlama
    /// </summary>
    public  partial class DietDefinition : ProcedureDefinition
    {
        public class DietDefinitionList : TTObjectCollection<DietDefinition> { }
                    
        public class ChildDietDefinitionCollection : TTObject.TTChildObjectCollection<DietDefinition>
        {
            public ChildDietDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDietDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDietDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDietDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDietMaterialsByDefID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDietMaterialsByDefID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietMaterialsByDefID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietMaterialsByDefID_Class() : base() { }
        }

        public static BindingList<DietDefinition.GetDietDefinition_Class> GetDietDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].QueryDefs["GetDietDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietDefinition.GetDietDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietDefinition.GetDietDefinition_Class> GetDietDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].QueryDefs["GetDietDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietDefinition.GetDietDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietDefinition> GetDietDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].QueryDefs["GetDietDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DietDefinition>(queryDef, paramList);
        }

        public static BindingList<DietDefinition> GetAllDietDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].QueryDefs["GetAllDietDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DietDefinition>(queryDef, paramList);
        }

        public static BindingList<DietDefinition.GetDietMaterialsByDefID_Class> GetDietMaterialsByDefID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].QueryDefs["GetDietMaterialsByDefID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DietDefinition.GetDietMaterialsByDefID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DietDefinition.GetDietMaterialsByDefID_Class> GetDietMaterialsByDefID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETDEFINITION"].QueryDefs["GetDietMaterialsByDefID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DietDefinition.GetDietMaterialsByDefID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sabah
    /// </summary>
        public bool? Breakfast
        {
            get { return (bool?)this["BREAKFAST"]; }
            set { this["BREAKFAST"] = value; }
        }

    /// <summary>
    /// Öğle
    /// </summary>
        public bool? Lunch
        {
            get { return (bool?)this["LUNCH"]; }
            set { this["LUNCH"] = value; }
        }

    /// <summary>
    /// Akşam
    /// </summary>
        public bool? Dinner
        {
            get { return (bool?)this["DINNER"]; }
            set { this["DINNER"] = value; }
        }

    /// <summary>
    /// Ara 2
    /// </summary>
        public bool? Snack2
        {
            get { return (bool?)this["SNACK2"]; }
            set { this["SNACK2"] = value; }
        }

    /// <summary>
    /// Gece Kahvaltısı
    /// </summary>
        public bool? NightBreakfast
        {
            get { return (bool?)this["NIGHTBREAKFAST"]; }
            set { this["NIGHTBREAKFAST"] = value; }
        }

    /// <summary>
    /// Ara 1
    /// </summary>
        public bool? Snack1
        {
            get { return (bool?)this["SNACK1"]; }
            set { this["SNACK1"] = value; }
        }

    /// <summary>
    /// Ara 3
    /// </summary>
        public bool? Snack3
        {
            get { return (bool?)this["SNACK3"]; }
            set { this["SNACK3"] = value; }
        }

    /// <summary>
    /// Hasta Türü
    /// </summary>
        public OutPatientInPatientBothEnum? PatientType
        {
            get { return (OutPatientInPatientBothEnum?)(int?)this["PATIENTTYPE"]; }
            set { this["PATIENTTYPE"] = value; }
        }

        virtual protected void CreateCourseGridCollection()
        {
            _CourseGrid = new CourseGrid.ChildCourseGridCollection(this, new Guid("7e58651a-77bd-4b93-9e46-1a7b7832c7bb"));
            ((ITTChildObjectCollection)_CourseGrid).GetChildren();
        }

        protected CourseGrid.ChildCourseGridCollection _CourseGrid = null;
        public CourseGrid.ChildCourseGridCollection CourseGrid
        {
            get
            {
                if (_CourseGrid == null)
                    CreateCourseGridCollection();
                return _CourseGrid;
            }
        }

        protected DietDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DietDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DietDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DietDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DietDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIETDEFINITION", dataRow) { }
        protected DietDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIETDEFINITION", dataRow, isImported) { }
        public DietDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DietDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DietDefinition() : base() { }

    }
}