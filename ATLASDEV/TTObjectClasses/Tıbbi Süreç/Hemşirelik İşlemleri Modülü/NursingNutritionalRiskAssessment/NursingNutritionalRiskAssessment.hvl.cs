
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingNutritionalRiskAssessment")] 

    /// <summary>
    /// Nutrisyonel Risk Skoru Değerlendirme Formu
    /// </summary>
    public  partial class NursingNutritionalRiskAssessment : BaseNursingDataEntry
    {
        public class NursingNutritionalRiskAssessmentList : TTObjectCollection<NursingNutritionalRiskAssessment> { }
                    
        public class ChildNursingNutritionalRiskAssessmentCollection : TTObject.TTChildObjectCollection<NursingNutritionalRiskAssessment>
        {
            public ChildNursingNutritionalRiskAssessmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingNutritionalRiskAssessmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingNutritionalRiskAssessment_Class : TTReportNqlObject 
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

            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["ENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? SevereDiseaseInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVEREDISEASEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["SEVEREDISEASEINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["BMI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ThreeMonthWeightLoss
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THREEMONTHWEIGHTLOSS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["THREEMONTHWEIGHTLOSS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WeeklyIntakeDecrease
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYINTAKEDECREASE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["WEEKLYINTAKEDECREASE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? TotalScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALSCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["TOTALSCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public NutritionIntakeAssessmentEnum? NutritionIntake
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUTRITIONINTAKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["NUTRITIONINTAKE"].DataType;
                    return (NutritionIntakeAssessmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelNormal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELNORMAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELNORMAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelLow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELLOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELLOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelMedium
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELMEDIUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELMEDIUM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelHigh
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELHIGH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELHIGH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? Height
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetNursingNutritionalRiskAssessment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingNutritionalRiskAssessment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingNutritionalRiskAssessment_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRiskAssesment_Class : TTReportNqlObject 
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

            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["ENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? SevereDiseaseInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVEREDISEASEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["SEVEREDISEASEINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BMI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["BMI"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ThreeMonthWeightLoss
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THREEMONTHWEIGHTLOSS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["THREEMONTHWEIGHTLOSS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WeeklyIntakeDecrease
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYINTAKEDECREASE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["WEEKLYINTAKEDECREASE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? TotalScore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALSCORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["TOTALSCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public NutritionIntakeAssessmentEnum? NutritionIntake
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUTRITIONINTAKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["NUTRITIONINTAKE"].DataType;
                    return (NutritionIntakeAssessmentEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelNormal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELNORMAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELNORMAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelLow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELLOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELLOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelMedium
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELMEDIUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELMEDIUM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DiseaseLevelHigh
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASELEVELHIGH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["DISEASELEVELHIGH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? Height
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["HEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetRiskAssesment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRiskAssesment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRiskAssesment_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class> GetNursingNutritionalRiskAssessment(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].QueryDefs["GetNursingNutritionalRiskAssessment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class> GetNursingNutritionalRiskAssessment(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].QueryDefs["GetNursingNutritionalRiskAssessment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingNutritionalRiskAssessment.GetRiskAssesment_Class> GetRiskAssesment(IList<string> Objects, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].QueryDefs["GetRiskAssesment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTS", Objects);

            return TTReportNqlObject.QueryObjects<NursingNutritionalRiskAssessment.GetRiskAssesment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingNutritionalRiskAssessment.GetRiskAssesment_Class> GetRiskAssesment(TTObjectContext objectContext, IList<string> Objects, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGNUTRITIONALRISKASSESSMENT"].QueryDefs["GetRiskAssesment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTS", Objects);

            return TTReportNqlObject.QueryObjects<NursingNutritionalRiskAssessment.GetRiskAssesment_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta ileri derecede hasta mı? (Örneğin yoğun bakımda mı?)
    /// </summary>
        public bool? SevereDiseaseInfo
        {
            get { return (bool?)this["SEVEREDISEASEINFO"]; }
            set { this["SEVEREDISEASEINFO"] = value; }
        }

    /// <summary>
    /// Vücut Kitle İndeksi (VKİ) < 20,5 kg/m2 mi?
    /// </summary>
        public bool? BMI
        {
            get { return (bool?)this["BMI"]; }
            set { this["BMI"] = value; }
        }

    /// <summary>
    /// Hasta son 3 ayda kilo kaybetti mi?
    /// </summary>
        public bool? ThreeMonthWeightLoss
        {
            get { return (bool?)this["THREEMONTHWEIGHTLOSS"]; }
            set { this["THREEMONTHWEIGHTLOSS"] = value; }
        }

    /// <summary>
    /// Geçen Hafta Gıda Alımında Azalma Oldu Mu?
    /// </summary>
        public bool? WeeklyIntakeDecrease
        {
            get { return (bool?)this["WEEKLYINTAKEDECREASE"]; }
            set { this["WEEKLYINTAKEDECREASE"] = value; }
        }

    /// <summary>
    /// Toplam Skor
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

    /// <summary>
    /// Beslenme Durumundaki Bozulma
    /// </summary>
        public NutritionIntakeAssessmentEnum? NutritionIntake
        {
            get { return (NutritionIntakeAssessmentEnum?)(int?)this["NUTRITIONINTAKE"]; }
            set { this["NUTRITIONINTAKE"] = value; }
        }

    /// <summary>
    /// Yok
    /// </summary>
        public bool? DiseaseLevelNormal
        {
            get { return (bool?)this["DISEASELEVELNORMAL"]; }
            set { this["DISEASELEVELNORMAL"] = value; }
        }

    /// <summary>
    /// Hafif
    /// </summary>
        public bool? DiseaseLevelLow
        {
            get { return (bool?)this["DISEASELEVELLOW"]; }
            set { this["DISEASELEVELLOW"] = value; }
        }

    /// <summary>
    /// Orta
    /// </summary>
        public bool? DiseaseLevelMedium
        {
            get { return (bool?)this["DISEASELEVELMEDIUM"]; }
            set { this["DISEASELEVELMEDIUM"] = value; }
        }

    /// <summary>
    /// Şiddetli
    /// </summary>
        public bool? DiseaseLevelHigh
        {
            get { return (bool?)this["DISEASELEVELHIGH"]; }
            set { this["DISEASELEVELHIGH"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

        virtual protected void CreateNutritionalRiskAssessmentCollection()
        {
            _NutritionalRiskAssessment = new NutritionalRiskAssessment.ChildNutritionalRiskAssessmentCollection(this, new Guid("eed4a139-d4e0-4554-a94c-365ade39fea5"));
            ((ITTChildObjectCollection)_NutritionalRiskAssessment).GetChildren();
        }

        protected NutritionalRiskAssessment.ChildNutritionalRiskAssessmentCollection _NutritionalRiskAssessment = null;
        public NutritionalRiskAssessment.ChildNutritionalRiskAssessmentCollection NutritionalRiskAssessment
        {
            get
            {
                if (_NutritionalRiskAssessment == null)
                    CreateNutritionalRiskAssessmentCollection();
                return _NutritionalRiskAssessment;
            }
        }

        protected NursingNutritionalRiskAssessment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingNutritionalRiskAssessment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingNutritionalRiskAssessment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingNutritionalRiskAssessment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingNutritionalRiskAssessment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGNUTRITIONALRISKASSESSMENT", dataRow) { }
        protected NursingNutritionalRiskAssessment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGNUTRITIONALRISKASSESSMENT", dataRow, isImported) { }
        public NursingNutritionalRiskAssessment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingNutritionalRiskAssessment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingNutritionalRiskAssessment() : base() { }

    }
}