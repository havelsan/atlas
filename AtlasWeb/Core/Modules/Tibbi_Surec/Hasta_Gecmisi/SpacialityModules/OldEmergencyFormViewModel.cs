//$EDE9A3EE
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;

namespace Core.Controllers
{
    public partial class EmergencySpecialityObjectServiceController
    {
        partial void PreScript_OldEmergencyForm(OldEmergencyFormViewModel viewModel, EmergencySpecialityObject emergencySpecialityObject, TTObjectContext objectContext)
        {
            StringBuilder strGeneralValuation = new StringBuilder();
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationGood == true ? "�yi, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationMedium == true ? "Orta, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationBad == true ? "K�t�, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationPainly == true ? "A�r�l�, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationDispneic == true ? "Dispneik, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationDehidrate == true ? "Dehidrate, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationSweaty == true ? "Terli, " : "");
            strGeneralValuation.Append(viewModel._EmergencySpecialityObject.GeneralEvaluationCold == true ? "So�uk " : "");
            viewModel.GeneralValuation = strGeneralValuation.ToString();

            StringBuilder strPsychologicalEvaluation = new StringBuilder();
            strPsychologicalEvaluation.Append(viewModel._EmergencySpecialityObject.PsychologicalEvaluationNormal == true ? "Normal, " : "");
            strPsychologicalEvaluation.Append(viewModel._EmergencySpecialityObject.PsychologicalEvaluationAngry == true ? "�fkeli, " : "");
            strPsychologicalEvaluation.Append(viewModel._EmergencySpecialityObject.PsychologicalEvaluationSad == true ? "�z�nt�l�, " : "");
            strPsychologicalEvaluation.Append(viewModel._EmergencySpecialityObject.PsychologicalEvalWorried == true ? "Endi�eli, " : "");
            strPsychologicalEvaluation.Append(viewModel._EmergencySpecialityObject.PsychologicalEvalIrrelevant == true ? "Kay�ts�z, " : "");
            strPsychologicalEvaluation.Append(viewModel._EmergencySpecialityObject.PsychologicalEvaluationOther != null ? viewModel._EmergencySpecialityObject.PsychologicalEvaluationOther : "");
            viewModel.PsychologicalEvaluation = strPsychologicalEvaluation.ToString();
                     

            viewModel.GlaskowEye = viewModel._EmergencySpecialityObject.Eyes!=null?viewModel._EmergencySpecialityObject.Eyes.Name:"";
            viewModel.GlaskowOralAnswer = viewModel._EmergencySpecialityObject.OralAnswer!=null?viewModel._EmergencySpecialityObject.OralAnswer.Name:"";
            viewModel.GlaskowMotorAnswer = viewModel._EmergencySpecialityObject.MotorAnswer!=null?viewModel._EmergencySpecialityObject.MotorAnswer.Name:"";
            viewModel.GlaskowTotal = viewModel._EmergencySpecialityObject.TotalScore!=null? Common.GetDisplayTextOfDataTypeEnum(viewModel._EmergencySpecialityObject.TotalScore):"";

            viewModel.AgriYeri = viewModel._EmergencySpecialityObject.PainPlaces == null ? "" : viewModel._EmergencySpecialityObject.PainPlaces.Name;
            viewModel.AgriSikligi = viewModel._EmergencySpecialityObject.PainFrequency == null ? "" : viewModel._EmergencySpecialityObject.PainFrequency.Name;
            viewModel.AgriNiteligi = viewModel._EmergencySpecialityObject.PainQuality == null ? "" : viewModel._EmergencySpecialityObject.PainQuality.Name;
            viewModel.YuzSkalasi = viewModel._EmergencySpecialityObject.PainFaceScale == null ? "" : Common.GetDisplayTextOfEnumValue("PainFaceScaleEnum", Convert.ToInt32(viewModel._EmergencySpecialityObject.PainFaceScale.Value)); 
        }
    }
}

namespace Core.Models
{
    public partial class OldEmergencyFormViewModel
    {
        public string GeneralValuation { get; set; }//Genel Durum
        public string PsychologicalEvaluation { get; set; }//Ruhsal De�erlendirme
        public string General { get; set; }//Genel
        public string HeadNeckEye { get; set; }//Ba� Boyun/G�z
        public string KVS { get; set; }//KVS
        public string Breath { get; set; }//Solunum
        public string GIS { get; set; }//G�S
        public string Eye { get; set; }//G�z
        public string Woman { get; set; }//Kad�n
        public string Breast { get; set; }//Meme
        public string PsychologicalInfo { get; set; }//Ruhsal Durum
        public string Man { get; set; }//Erkek
        public string Hormon { get; set; }//Hormonal
        public string Neural { get; set; }//Sinir
        public string Musculoskeletal { get; set; }//Kas �skelet

        public string AgriYeri { get; set; }
        public string AgriSikligi { get; set; }
        public string AgriNiteligi { get; set; }
        public string YuzSkalasi { get; set; }


        //Glasgow Koma De�erlendirme
        public string GlaskowEye { get; set; }
        public string GlaskowOralAnswer { get; set; }
        public string GlaskowMotorAnswer { get; set; }
        public string GlaskowTotal { get; set; }
    }
}
