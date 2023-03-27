
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CourseDefinition")] 

    /// <summary>
    /// Yemek Tanımları
    /// </summary>
    public  partial class CourseDefinition : TerminologyManagerDef
    {
        public class CourseDefinitionList : TTObjectCollection<CourseDefinition> { }
                    
        public class ChildCourseDefinitionCollection : TTObject.TTChildObjectCollection<CourseDefinition>
        {
            public ChildCourseDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCourseDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCourseDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public AmountTypeEnum? AmountType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["AMOUNTTYPE"].DataType;
                    return (AmountTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string TotalCalories
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCALORIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["TOTALCALORIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TotalFatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALFATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["TOTALFATRATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TotalCarbohydrateRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCARBOHYDRATERATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["TOTALCARBOHYDRATERATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TotalProteinRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPROTEINRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["TOTALPROTEINRATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCourseDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCourseDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCourseDefinition_Class() : base() { }
        }

        public static BindingList<CourseDefinition.GetCourseDefinition_Class> GetCourseDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].QueryDefs["GetCourseDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CourseDefinition.GetCourseDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CourseDefinition.GetCourseDefinition_Class> GetCourseDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COURSEDEFINITION"].QueryDefs["GetCourseDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CourseDefinition.GetCourseDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Miktar Türü
    /// </summary>
        public AmountTypeEnum? AmountType
        {
            get { return (AmountTypeEnum?)(int?)this["AMOUNTTYPE"]; }
            set { this["AMOUNTTYPE"] = value; }
        }

    /// <summary>
    /// Toplam Kalori Oranı
    /// </summary>
        public string TotalCalories
        {
            get { return (string)this["TOTALCALORIES"]; }
            set { this["TOTALCALORIES"] = value; }
        }

    /// <summary>
    /// Toplam Yağ Oranı
    /// </summary>
        public string TotalFatRate
        {
            get { return (string)this["TOTALFATRATE"]; }
            set { this["TOTALFATRATE"] = value; }
        }

    /// <summary>
    /// Toplam Karbonhidrat Oranı
    /// </summary>
        public string TotalCarbohydrateRate
        {
            get { return (string)this["TOTALCARBOHYDRATERATE"]; }
            set { this["TOTALCARBOHYDRATERATE"] = value; }
        }

    /// <summary>
    /// Toplam Protein Oranı
    /// </summary>
        public string TotalProteinRate
        {
            get { return (string)this["TOTALPROTEINRATE"]; }
            set { this["TOTALPROTEINRATE"] = value; }
        }

    /// <summary>
    /// Yemek Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public string Amount
        {
            get { return (string)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        virtual protected void CreateCourseGridCollection()
        {
            _CourseGrid = new CourseGrid.ChildCourseGridCollection(this, new Guid("22ec54e4-a73b-4829-b82f-055fe0cfbb2d"));
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

        virtual protected void CreateDietMaterialGridCollection()
        {
            _DietMaterialGrid = new DietMaterialGrid.ChildDietMaterialGridCollection(this, new Guid("90916664-05f2-4fab-a0f1-ff31b6222267"));
            ((ITTChildObjectCollection)_DietMaterialGrid).GetChildren();
        }

        protected DietMaterialGrid.ChildDietMaterialGridCollection _DietMaterialGrid = null;
        public DietMaterialGrid.ChildDietMaterialGridCollection DietMaterialGrid
        {
            get
            {
                if (_DietMaterialGrid == null)
                    CreateDietMaterialGridCollection();
                return _DietMaterialGrid;
            }
        }

        protected CourseDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CourseDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CourseDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CourseDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CourseDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COURSEDEFINITION", dataRow) { }
        protected CourseDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COURSEDEFINITION", dataRow, isImported) { }
        public CourseDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CourseDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CourseDefinition() : base() { }

    }
}