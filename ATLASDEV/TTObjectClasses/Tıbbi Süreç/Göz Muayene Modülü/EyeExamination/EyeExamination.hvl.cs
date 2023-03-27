
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EyeExamination")] 

    /// <summary>
    /// Eye Examination Object
    /// </summary>
    public  partial class EyeExamination : SpecialityBasedObject
    {
        public class EyeExaminationList : TTObjectCollection<EyeExamination> { }
                    
        public class ChildEyeExaminationCollection : TTObject.TTChildObjectCollection<EyeExamination>
        {
            public ChildEyeExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEyeExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sağ Göz Biyomikroskopi
    /// </summary>
        public string RightEyeBiomicroscopy
        {
            get { return (string)this["RIGHTEYEBIOMICROSCOPY"]; }
            set { this["RIGHTEYEBIOMICROSCOPY"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Yakın AKS
    /// </summary>
        public double? GlassVisSharpLeftNearAxis
        {
            get { return (double?)this["GLASSVISSHARPLEFTNEARAXIS"]; }
            set { this["GLASSVISSHARPLEFTNEARAXIS"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Uzak SPH
    /// </summary>
        public double? GlassVisSharpRightFarSPH
        {
            get { return (double?)this["GLASSVISSHARPRIGHTFARSPH"]; }
            set { this["GLASSVISSHARPRIGHTFARSPH"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Uzak CYL
    /// </summary>
        public double? GlassVisSharpRightFarCYL
        {
            get { return (double?)this["GLASSVISSHARPRIGHTFARCYL"]; }
            set { this["GLASSVISSHARPRIGHTFARCYL"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Uzak AKS
    /// </summary>
        public double? GlassVisSharpRightFarAxis
        {
            get { return (double?)this["GLASSVISSHARPRIGHTFARAXIS"]; }
            set { this["GLASSVISSHARPRIGHTFARAXIS"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Yakın SPH
    /// </summary>
        public double? GlassVisSharpRightNearSPH
        {
            get { return (double?)this["GLASSVISSHARPRIGHTNEARSPH"]; }
            set { this["GLASSVISSHARPRIGHTNEARSPH"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Yakın CYL
    /// </summary>
        public double? GlassVisSharpRightNearCYL
        {
            get { return (double?)this["GLASSVISSHARPRIGHTNEARCYL"]; }
            set { this["GLASSVISSHARPRIGHTNEARCYL"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Yakın AKS
    /// </summary>
        public double? GlassVisSharpRightNearAxis
        {
            get { return (double?)this["GLASSVISSHARPRIGHTNEARAXIS"]; }
            set { this["GLASSVISSHARPRIGHTNEARAXIS"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Uzak SPH
    /// </summary>
        public double? NoGlassVisSharpLeftFarSPH
        {
            get { return (double?)this["NOGLASSVISSHARPLEFTFARSPH"]; }
            set { this["NOGLASSVISSHARPLEFTFARSPH"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Uzak CYL
    /// </summary>
        public double? NoGlassVisSharpLeftFarCYL
        {
            get { return (double?)this["NOGLASSVISSHARPLEFTFARCYL"]; }
            set { this["NOGLASSVISSHARPLEFTFARCYL"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Uzak AKS
    /// </summary>
        public double? NoGlassVisSharpLeftFarAxis
        {
            get { return (double?)this["NOGLASSVISSHARPLEFTFARAXIS"]; }
            set { this["NOGLASSVISSHARPLEFTFARAXIS"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Yakın SPH
    /// </summary>
        public double? NoGlassVisSharpLeftNearSPH
        {
            get { return (double?)this["NOGLASSVISSHARPLEFTNEARSPH"]; }
            set { this["NOGLASSVISSHARPLEFTNEARSPH"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Yakın CYL
    /// </summary>
        public double? NoGlassVisSharpLeftNearCYL
        {
            get { return (double?)this["NOGLASSVISSHARPLEFTNEARCYL"]; }
            set { this["NOGLASSVISSHARPLEFTNEARCYL"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Yakın AKS
    /// </summary>
        public double? NoGlassVisSharpLeftNearAxis
        {
            get { return (double?)this["NOGLASSVISSHARPLEFTNEARAXIS"]; }
            set { this["NOGLASSVISSHARPLEFTNEARAXIS"] = value; }
        }

    /// <summary>
    /// Sikloplejili Otoref Sağ Göz Ölçümü CYL
    /// </summary>
        public double? CyclAutorefRightMeasureCYL
        {
            get { return (double?)this["CYCLAUTOREFRIGHTMEASURECYL"]; }
            set { this["CYCLAUTOREFRIGHTMEASURECYL"] = value; }
        }

    /// <summary>
    /// Sikloplejili Otoref Sağ Göz Ölçümü AKS
    /// </summary>
        public double? CyclAutorefRightMeasureAxis
        {
            get { return (double?)this["CYCLAUTOREFRIGHTMEASUREAXIS"]; }
            set { this["CYCLAUTOREFRIGHTMEASUREAXIS"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Uzak SPH
    /// </summary>
        public double? GlassVisSharpLeftFarSPH
        {
            get { return (double?)this["GLASSVISSHARPLEFTFARSPH"]; }
            set { this["GLASSVISSHARPLEFTFARSPH"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Uzak CYL
    /// </summary>
        public double? GlassVisSharpLeftFarCYL
        {
            get { return (double?)this["GLASSVISSHARPLEFTFARCYL"]; }
            set { this["GLASSVISSHARPLEFTFARCYL"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Uzak AKS
    /// </summary>
        public double? GlassVisSharpLeftFarAxis
        {
            get { return (double?)this["GLASSVISSHARPLEFTFARAXIS"]; }
            set { this["GLASSVISSHARPLEFTFARAXIS"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Yakın SPH
    /// </summary>
        public double? GlassVisSharpLeftNearSPH
        {
            get { return (double?)this["GLASSVISSHARPLEFTNEARSPH"]; }
            set { this["GLASSVISSHARPLEFTNEARSPH"] = value; }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Yakın CYL
    /// </summary>
        public double? GlassVisSharpLeftNearCYL
        {
            get { return (double?)this["GLASSVISSHARPLEFTNEARCYL"]; }
            set { this["GLASSVISSHARPLEFTNEARCYL"] = value; }
        }

    /// <summary>
    /// Sol Göz Biyomikroskopi
    /// </summary>
        public string LeftEyeBiomicroscopy
        {
            get { return (string)this["LEFTEYEBIOMICROSCOPY"]; }
            set { this["LEFTEYEBIOMICROSCOPY"] = value; }
        }

    /// <summary>
    /// Sağ Göz Basıncı
    /// </summary>
        public double? RightEyePressure
        {
            get { return (double?)this["RIGHTEYEPRESSURE"]; }
            set { this["RIGHTEYEPRESSURE"] = value; }
        }

    /// <summary>
    /// Sol Göz Basıncı
    /// </summary>
        public double? LeftEyePressure
        {
            get { return (double?)this["LEFTEYEPRESSURE"]; }
            set { this["LEFTEYEPRESSURE"] = value; }
        }

    /// <summary>
    /// Sol Göz Hareketleri
    /// </summary>
        public string LeftEyeMovements
        {
            get { return (string)this["LEFTEYEMOVEMENTS"]; }
            set { this["LEFTEYEMOVEMENTS"] = value; }
        }

    /// <summary>
    /// Sağ Göz Hareketleri
    /// </summary>
        public string RightEyeMovements
        {
            get { return (string)this["RIGHTEYEMOVEMENTS"]; }
            set { this["RIGHTEYEMOVEMENTS"] = value; }
        }

    /// <summary>
    /// Sağ Göz Fundus
    /// </summary>
        public string RightEyeFundus
        {
            get { return (string)this["RIGHTEYEFUNDUS"]; }
            set { this["RIGHTEYEFUNDUS"] = value; }
        }

    /// <summary>
    /// Sol Göz Fundus
    /// </summary>
        public string LeftEyeFundus
        {
            get { return (string)this["LEFTEYEFUNDUS"]; }
            set { this["LEFTEYEFUNDUS"] = value; }
        }

    /// <summary>
    /// Otoref Sol Göz Ölçümü SPH
    /// </summary>
        public double? AutorefLeftEyeMeasureSPH
        {
            get { return (double?)this["AUTOREFLEFTEYEMEASURESPH"]; }
            set { this["AUTOREFLEFTEYEMEASURESPH"] = value; }
        }

    /// <summary>
    /// Otoref Sol Göz Ölçümü CYL
    /// </summary>
        public double? AutorefLeftEyeMeasureCYL
        {
            get { return (double?)this["AUTOREFLEFTEYEMEASURECYL"]; }
            set { this["AUTOREFLEFTEYEMEASURECYL"] = value; }
        }

    /// <summary>
    /// Otoref Sol Göz Ölçümü AKS
    /// </summary>
        public double? AutorefLeftEyeMeasureAxis
        {
            get { return (double?)this["AUTOREFLEFTEYEMEASUREAXIS"]; }
            set { this["AUTOREFLEFTEYEMEASUREAXIS"] = value; }
        }

    /// <summary>
    /// Otoref Sağ Göz Ölçümü SPH
    /// </summary>
        public double? AutorefRightEyeMeasureSPH
        {
            get { return (double?)this["AUTOREFRIGHTEYEMEASURESPH"]; }
            set { this["AUTOREFRIGHTEYEMEASURESPH"] = value; }
        }

    /// <summary>
    /// Otoref Sağ Göz Ölçümü CYL
    /// </summary>
        public double? AutorefRightEyeMeasureCYL
        {
            get { return (double?)this["AUTOREFRIGHTEYEMEASURECYL"]; }
            set { this["AUTOREFRIGHTEYEMEASURECYL"] = value; }
        }

    /// <summary>
    /// Otoref Sağ Göz Ölçümü AKS
    /// </summary>
        public double? AutorefRightEyeMeasureAxis
        {
            get { return (double?)this["AUTOREFRIGHTEYEMEASUREAXIS"]; }
            set { this["AUTOREFRIGHTEYEMEASUREAXIS"] = value; }
        }

    /// <summary>
    /// Sikloplejili Otoref Sol Göz Ölçümü SPH
    /// </summary>
        public double? CyclAutorefLeftMeasureSPH
        {
            get { return (double?)this["CYCLAUTOREFLEFTMEASURESPH"]; }
            set { this["CYCLAUTOREFLEFTMEASURESPH"] = value; }
        }

    /// <summary>
    /// Sikloplejili Otoref Sol Göz Ölçümü CYL
    /// </summary>
        public double? CyclAutorefLeftMeasureCYL
        {
            get { return (double?)this["CYCLAUTOREFLEFTMEASURECYL"]; }
            set { this["CYCLAUTOREFLEFTMEASURECYL"] = value; }
        }

    /// <summary>
    /// Sikloplejili Otoref Sol Göz Ölçümü AKS
    /// </summary>
        public double? CyclAutorefLeftMeasureAxis
        {
            get { return (double?)this["CYCLAUTOREFLEFTMEASUREAXIS"]; }
            set { this["CYCLAUTOREFLEFTMEASUREAXIS"] = value; }
        }

    /// <summary>
    /// Sikloplejili Otoref Sağ Göz Ölçümü SPH
    /// </summary>
        public double? CyclAutorefRightMeasureSPH
        {
            get { return (double?)this["CYCLAUTOREFRIGHTMEASURESPH"]; }
            set { this["CYCLAUTOREFRIGHTMEASURESPH"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sağ Uzak SPH
    /// </summary>
        public double? NoGlassVisSharpRightFarSPH
        {
            get { return (double?)this["NOGLASSVISSHARPRIGHTFARSPH"]; }
            set { this["NOGLASSVISSHARPRIGHTFARSPH"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sağ Uzak CYL
    /// </summary>
        public double? NoGlassVisSharpRightFarCYL
        {
            get { return (double?)this["NOGLASSVISSHARPRIGHTFARCYL"]; }
            set { this["NOGLASSVISSHARPRIGHTFARCYL"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sağ Uzak AKS
    /// </summary>
        public double? NoGlassVisSharpRightFarAxis
        {
            get { return (double?)this["NOGLASSVISSHARPRIGHTFARAXIS"]; }
            set { this["NOGLASSVISSHARPRIGHTFARAXIS"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sağ Yakın SPH
    /// </summary>
        public double? NoGlassVisSharpRightNearSPH
        {
            get { return (double?)this["NOGLASSVISSHARPRIGHTNEARSPH"]; }
            set { this["NOGLASSVISSHARPRIGHTNEARSPH"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sağ Yakın CYL
    /// </summary>
        public double? NoGlassVisSharpRightNearCYL
        {
            get { return (double?)this["NOGLASSVISSHARPRIGHTNEARCYL"]; }
            set { this["NOGLASSVISSHARPRIGHTNEARCYL"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sağ Yakın AKS
    /// </summary>
        public double? NoGlassVisSharpRightNearAxis
        {
            get { return (double?)this["NOGLASSVISSHARPRIGHTNEARAXIS"]; }
            set { this["NOGLASSVISSHARPRIGHTNEARAXIS"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sağ Uzak Cam Numarası SPH
    /// </summary>
        public double? PatientGlassesRightFarSPH
        {
            get { return (double?)this["PATIENTGLASSESRIGHTFARSPH"]; }
            set { this["PATIENTGLASSESRIGHTFARSPH"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sağ Uzak Cam Numarası CYL
    /// </summary>
        public double? PatientGlassesRightFarCYL
        {
            get { return (double?)this["PATIENTGLASSESRIGHTFARCYL"]; }
            set { this["PATIENTGLASSESRIGHTFARCYL"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sağ Uzak Cam Numarası AKS
    /// </summary>
        public double? PatientGlassesRightFarAxis
        {
            get { return (double?)this["PATIENTGLASSESRIGHTFARAXIS"]; }
            set { this["PATIENTGLASSESRIGHTFARAXIS"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sağ Yakın Cam Numarası AKS
    /// </summary>
        public double? PatientGlassesRightNearAxis
        {
            get { return (double?)this["PATIENTGLASSESRIGHTNEARAXIS"]; }
            set { this["PATIENTGLASSESRIGHTNEARAXIS"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sağ Yakın Cam Numarası CYL
    /// </summary>
        public double? PatientGlassesRightNearCYL
        {
            get { return (double?)this["PATIENTGLASSESRIGHTNEARCYL"]; }
            set { this["PATIENTGLASSESRIGHTNEARCYL"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sağ Yakın Cam Numarası SPH
    /// </summary>
        public double? PatientGlassesRightNearSPH
        {
            get { return (double?)this["PATIENTGLASSESRIGHTNEARSPH"]; }
            set { this["PATIENTGLASSESRIGHTNEARSPH"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sol Yakın Cam Numarası SPH
    /// </summary>
        public double? PatientGlassesLeftNearSPH
        {
            get { return (double?)this["PATIENTGLASSESLEFTNEARSPH"]; }
            set { this["PATIENTGLASSESLEFTNEARSPH"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sol Yakın Cam Numarası CYL
    /// </summary>
        public double? PatientGlassesLeftNearCYL
        {
            get { return (double?)this["PATIENTGLASSESLEFTNEARCYL"]; }
            set { this["PATIENTGLASSESLEFTNEARCYL"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sol Yakın Cam Numarası AKS
    /// </summary>
        public double? PatientGlassesLeftNearAxis
        {
            get { return (double?)this["PATIENTGLASSESLEFTNEARAXIS"]; }
            set { this["PATIENTGLASSESLEFTNEARAXIS"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sol Uzak Cam Numarası AKS
    /// </summary>
        public double? PatientGlassesLeftFarAxis
        {
            get { return (double?)this["PATIENTGLASSESLEFTFARAXIS"]; }
            set { this["PATIENTGLASSESLEFTFARAXIS"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sol Uzak Cam Numarası CYL
    /// </summary>
        public double? PatientGlassesLeftFarCYL
        {
            get { return (double?)this["PATIENTGLASSESLEFTFARCYL"]; }
            set { this["PATIENTGLASSESLEFTFARCYL"] = value; }
        }

    /// <summary>
    /// Hasta Gözlüğü Sol Uzak Cam Numarası SPH
    /// </summary>
        public double? PatientGlassesLeftFarSPH
        {
            get { return (double?)this["PATIENTGLASSESLEFTFARSPH"]; }
            set { this["PATIENTGLASSESLEFTFARSPH"] = value; }
        }

    /// <summary>
    /// Camsız Görme Keskinliği Sol Göz Değeri
    /// </summary>
        public VisualSharpnessDefinitionNew NoGlassVisSharpLeftVal
        {
            get { return (VisualSharpnessDefinitionNew)((ITTObject)this).GetParent("NOGLASSVISSHARPLEFTVAL"); }
            set { this["NOGLASSVISSHARPLEFTVAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Göz Değeri
    /// </summary>
        public VisualSharpnessDefinitionNew NoGlassVisSharpRightVal
        {
            get { return (VisualSharpnessDefinitionNew)((ITTObject)this).GetParent("NOGLASSVISSHARPRIGHTVAL"); }
            set { this["NOGLASSVISSHARPRIGHTVAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sağ Göz Değeri
    /// </summary>
        public VisualSharpnessDefinitionNew GlassVisSharpRightVal
        {
            get { return (VisualSharpnessDefinitionNew)((ITTObject)this).GetParent("GLASSVISSHARPRIGHTVAL"); }
            set { this["GLASSVISSHARPRIGHTVAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Camlı Görme Keskinliği Sol Göz Değeri
    /// </summary>
        public VisualSharpnessDefinitionNew GlassVisSharpLeftVal
        {
            get { return (VisualSharpnessDefinitionNew)((ITTObject)this).GetParent("GLASSVISSHARPLEFTVAL"); }
            set { this["GLASSVISSHARPLEFTVAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EyeExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EyeExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EyeExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EyeExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EyeExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EYEEXAMINATION", dataRow) { }
        protected EyeExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EYEEXAMINATION", dataRow, isImported) { }
        public EyeExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EyeExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EyeExamination() : base() { }

    }
}