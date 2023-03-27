
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NutritionIntakeAssessmentDef")] 

    /// <summary>
    /// Beslenme Durumundaki Bozulma
    /// </summary>
    public  partial class NutritionIntakeAssessmentDef : TerminologyManagerDef
    {
        public class NutritionIntakeAssessmentDefList : TTObjectCollection<NutritionIntakeAssessmentDef> { }
                    
        public class ChildNutritionIntakeAssessmentDefCollection : TTObject.TTChildObjectCollection<NutritionIntakeAssessmentDef>
        {
            public ChildNutritionIntakeAssessmentDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNutritionIntakeAssessmentDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNutritionIntakeAssessmentDef_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONINTAKEASSESSMENTDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Score
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONINTAKEASSESSMENTDEF"].AllPropertyDefs["SCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetNutritionIntakeAssessmentDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNutritionIntakeAssessmentDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNutritionIntakeAssessmentDef_Class() : base() { }
        }

        public static BindingList<NutritionIntakeAssessmentDef.GetNutritionIntakeAssessmentDef_Class> GetNutritionIntakeAssessmentDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONINTAKEASSESSMENTDEF"].QueryDefs["GetNutritionIntakeAssessmentDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NutritionIntakeAssessmentDef.GetNutritionIntakeAssessmentDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NutritionIntakeAssessmentDef.GetNutritionIntakeAssessmentDef_Class> GetNutritionIntakeAssessmentDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONINTAKEASSESSMENTDEF"].QueryDefs["GetNutritionIntakeAssessmentDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NutritionIntakeAssessmentDef.GetNutritionIntakeAssessmentDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Risk Puanı
    /// </summary>
        public int? Score
        {
            get { return (int?)this["SCORE"]; }
            set { this["SCORE"] = value; }
        }

        protected NutritionIntakeAssessmentDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NutritionIntakeAssessmentDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NutritionIntakeAssessmentDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NutritionIntakeAssessmentDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NutritionIntakeAssessmentDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUTRITIONINTAKEASSESSMENTDEF", dataRow) { }
        protected NutritionIntakeAssessmentDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUTRITIONINTAKEASSESSMENTDEF", dataRow, isImported) { }
        public NutritionIntakeAssessmentDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NutritionIntakeAssessmentDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NutritionIntakeAssessmentDef() : base() { }

    }
}