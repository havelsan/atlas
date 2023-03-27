
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingNutritionAssessment")] 

    /// <summary>
    /// Beslenme Değerlendirme
    /// </summary>
    public  partial class NursingNutritionAssessment : BaseNursingDataEntry
    {
        public class NursingNutritionAssessmentList : TTObjectCollection<NursingNutritionAssessment> { }
                    
        public class ChildNursingNutritionAssessmentCollection : TTObject.TTChildObjectCollection<NursingNutritionAssessment>
        {
            public ChildNursingNutritionAssessmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingNutritionAssessmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// kilo
    /// </summary>
        public string WeightChange
        {
            get { return (string)this["WEIGHTCHANGE"]; }
            set { this["WEIGHTCHANGE"] = value; }
        }

        public string WeightChangeNote
        {
            get { return (string)this["WEIGHTCHANGENOTE"]; }
            set { this["WEIGHTCHANGENOTE"] = value; }
        }

        public int? AbdominalCircle
        {
            get { return (int?)this["ABDOMINALCIRCLE"]; }
            set { this["ABDOMINALCIRCLE"] = value; }
        }

        public bool? Gastronomy
        {
            get { return (bool?)this["GASTRONOMY"]; }
            set { this["GASTRONOMY"] = value; }
        }

        public int? LeftLegCircle
        {
            get { return (int?)this["LEFTLEGCIRCLE"]; }
            set { this["LEFTLEGCIRCLE"] = value; }
        }

        public int? RightLegCircle
        {
            get { return (int?)this["RIGHTLEGCIRCLE"]; }
            set { this["RIGHTLEGCIRCLE"] = value; }
        }

        public bool? NasogastricTube
        {
            get { return (bool?)this["NASOGASTRICTUBE"]; }
            set { this["NASOGASTRICTUBE"] = value; }
        }

    /// <summary>
    /// Genel Görünüm
    /// </summary>
        public PanoramaDefinition Panorama
        {
            get { return (PanoramaDefinition)((ITTObject)this).GetParent("PANORAMA"); }
            set { this["PANORAMA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yutkunma
    /// </summary>
        public SwallowDefinition Swallow
        {
            get { return (SwallowDefinition)((ITTObject)this).GetParent("SWALLOW"); }
            set { this["SWALLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İştah
    /// </summary>
        public UrgeDefinition Urge
        {
            get { return (UrgeDefinition)((ITTObject)this).GetParent("URGE"); }
            set { this["URGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diş Yapısı
    /// </summary>
        public ToothDefinition Tooth
        {
            get { return (ToothDefinition)((ITTObject)this).GetParent("TOOTH"); }
            set { this["TOOTH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Perhiz
    /// </summary>
        public NursingDietDefinition NursingDiet
        {
            get { return (NursingDietDefinition)((ITTObject)this).GetParent("NURSINGDIET"); }
            set { this["NURSINGDIET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingNutritionAssessment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingNutritionAssessment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingNutritionAssessment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingNutritionAssessment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingNutritionAssessment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGNUTRITIONASSESSMENT", dataRow) { }
        protected NursingNutritionAssessment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGNUTRITIONASSESSMENT", dataRow, isImported) { }
        public NursingNutritionAssessment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingNutritionAssessment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingNutritionAssessment() : base() { }

    }
}