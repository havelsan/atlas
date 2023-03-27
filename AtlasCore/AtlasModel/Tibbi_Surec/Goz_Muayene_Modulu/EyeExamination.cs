using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EyeExamination
    {
        public Guid ObjectId { get; set; }
        public string RightEyeBiomicroscopy { get; set; }
        public double? GlassVisSharpLeftNearAxis { get; set; }
        public double? GlassVisSharpRightFarSPH { get; set; }
        public double? GlassVisSharpRightFarCYL { get; set; }
        public double? GlassVisSharpRightFarAxis { get; set; }
        public double? GlassVisSharpRightNearSPH { get; set; }
        public double? GlassVisSharpRightNearCYL { get; set; }
        public double? GlassVisSharpRightNearAxis { get; set; }
        public double? NoGlassVisSharpLeftFarSPH { get; set; }
        public double? NoGlassVisSharpLeftFarCYL { get; set; }
        public double? NoGlassVisSharpLeftFarAxis { get; set; }
        public double? NoGlassVisSharpLeftNearSPH { get; set; }
        public double? NoGlassVisSharpLeftNearCYL { get; set; }
        public double? NoGlassVisSharpLeftNearAxis { get; set; }
        public double? CyclAutorefRightMeasureCYL { get; set; }
        public double? CyclAutorefRightMeasureAxis { get; set; }
        public double? GlassVisSharpLeftFarSPH { get; set; }
        public double? GlassVisSharpLeftFarCYL { get; set; }
        public double? GlassVisSharpLeftFarAxis { get; set; }
        public double? GlassVisSharpLeftNearSPH { get; set; }
        public double? GlassVisSharpLeftNearCYL { get; set; }
        public string LeftEyeBiomicroscopy { get; set; }
        public double? RightEyePressure { get; set; }
        public double? LeftEyePressure { get; set; }
        public string LeftEyeMovements { get; set; }
        public string RightEyeMovements { get; set; }
        public string RightEyeFundus { get; set; }
        public string LeftEyeFundus { get; set; }
        public double? AutorefLeftEyeMeasureSPH { get; set; }
        public double? AutorefLeftEyeMeasureCYL { get; set; }
        public double? AutorefLeftEyeMeasureAxis { get; set; }
        public double? AutorefRightEyeMeasureSPH { get; set; }
        public double? AutorefRightEyeMeasureCYL { get; set; }
        public double? AutorefRightEyeMeasureAxis { get; set; }
        public double? CyclAutorefLeftMeasureSPH { get; set; }
        public double? CyclAutorefLeftMeasureCYL { get; set; }
        public double? CyclAutorefLeftMeasureAxis { get; set; }
        public double? CyclAutorefRightMeasureSPH { get; set; }
        public double? NoGlassVisSharpRightFarSPH { get; set; }
        public double? NoGlassVisSharpRightFarCYL { get; set; }
        public double? NoGlassVisSharpRightFarAxis { get; set; }
        public double? NoGlassVisSharpRightNearSPH { get; set; }
        public double? NoGlassVisSharpRightNearCYL { get; set; }
        public double? NoGlassVisSharpRightNearAxis { get; set; }
        public double? PatientGlassesRightFarSPH { get; set; }
        public double? PatientGlassesRightFarCYL { get; set; }
        public double? PatientGlassesRightFarAxis { get; set; }
        public double? PatientGlassesRightNearAxis { get; set; }
        public double? PatientGlassesRightNearCYL { get; set; }
        public double? PatientGlassesRightNearSPH { get; set; }
        public double? PatientGlassesLeftNearSPH { get; set; }
        public double? PatientGlassesLeftNearCYL { get; set; }
        public double? PatientGlassesLeftNearAxis { get; set; }
        public double? PatientGlassesLeftFarAxis { get; set; }
        public double? PatientGlassesLeftFarCYL { get; set; }
        public double? PatientGlassesLeftFarSPH { get; set; }

        #region Base Object Navigation Property
        public virtual SpecialityBasedObject SpecialityBasedObject { get; set; }
        #endregion Base Object Navigation Property
    }
}