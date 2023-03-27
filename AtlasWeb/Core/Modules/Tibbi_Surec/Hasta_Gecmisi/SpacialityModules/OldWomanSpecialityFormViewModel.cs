//$73C579A6
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Text;

namespace Core.Controllers
{
    public partial class WomanSpecialityObjectServiceController
    {
        partial void PreScript_OldWomanSpecialityForm(OldWomanSpecialityFormViewModel viewModel, WomanSpecialityObject womanSpecialityObject, TTObjectContext objectContext)
        {
            viewModel.BloodGroup = womanSpecialityObject.PhysicianApplication.Episode.Patient.BloodGroupType != null ? womanSpecialityObject.PhysicianApplication.Episode.Patient.BloodGroupType.KODU : "";
            viewModel.HusbandBloodGroup = womanSpecialityObject.HusbandBloodGroup != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.HusbandBloodGroup) : "";
            viewModel.DegreeOfRelationship = womanSpecialityObject.DegreeOfRelationship != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.DegreeOfRelationship) : "";
            viewModel.RhIncompatibility = womanSpecialityObject.RhIncompatibility != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.RhIncompatibility) : "";
            //Jinekoloji
            viewModel.PreviousBirthControlMethod = womanSpecialityObject.Gynecology.PreviousBirthControlMethod != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.Gynecology.PreviousBirthControlMethod) : "";
            viewModel.CurrentBirthControlMethod = womanSpecialityObject.Gynecology.CurrentBirthControlMethod != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.Gynecology.CurrentBirthControlMethod) : "";
            viewModel.GenitalAbnormalities = womanSpecialityObject.Gynecology.GenitalAbnormalities != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.Gynecology.GenitalAbnormalities) : "";
            viewModel.MenstrualCycleAbnormalities = womanSpecialityObject.Gynecology.MenstrualCycleAbnormalities != null ? Common.GetDisplayTextOfDataTypeEnum(womanSpecialityObject.Gynecology.MenstrualCycleAbnormalities) : "";
            viewModel.ReproductiveAbnormality = womanSpecialityObject.Gynecology.ReproductiveAbnormality != null ? womanSpecialityObject.Gynecology.ReproductiveAbnormality.Name : "";
            viewModel.Dysuria = womanSpecialityObject.Gynecology.Dysuria == true ? "Var" : TTUtils.CultureService.GetText("M24703", "Yok");
            viewModel.Dyspareunia = womanSpecialityObject.Gynecology.Dyspareunia == true ? "Var" : TTUtils.CultureService.GetText("M24703", "Yok");
            viewModel.Hirsutism = womanSpecialityObject.Gynecology.Hirsutism == true ? "Var" : TTUtils.CultureService.GetText("M24703", "Yok");
            viewModel.VaginalDischarge = womanSpecialityObject.Gynecology.VaginalDischarge == true ? "Var" : TTUtils.CultureService.GetText("M24703", "Yok");
            //Hasta Bazlı İnfertilite
            if (womanSpecialityObject.PhysicianApplication.Episode.Patient.InfertilityPatientInformation != null)
            {
                viewModel._InfertilityPatientInformation = womanSpecialityObject.PhysicianApplication.Episode.Patient.InfertilityPatientInformation;
            }

            if (viewModel._WomanSpecialityObject.PregnancyFollow != null)
            {
                StringBuilder str = new StringBuilder();
                str.Append(viewModel._WomanSpecialityObject.PregnancyFollow.Tension == true ? "Tansiyon, " : "");
                str.Append(viewModel._WomanSpecialityObject.PregnancyFollow.GestationalDiabetes == true ? "Gebelik Şekeri, " : "");
                str.Append(viewModel._WomanSpecialityObject.PregnancyFollow.CardiovascularDiseases == true ? "Damar Hastalıkları, " : "");
                str.Append(viewModel._WomanSpecialityObject.PregnancyFollow.Anemia == true ? "Anemi, " : "");
                str.Append(viewModel._WomanSpecialityObject.PregnancyFollow.Nausea == true ? "Bulantı, " : "");
                str.Append(viewModel._WomanSpecialityObject.PregnancyFollow.Bleeding == true ? "Kanama, " : "");
                viewModel.PregnancyDiseases = str.ToString();
            }
        }
    }
}

namespace Core.Models
{
    public partial class OldWomanSpecialityFormViewModel
    {
        public string BloodGroup
        {
            get;
            set;
        }
        public string HusbandBloodGroup { get; set; }
        public string DegreeOfRelationship { get; set; }
        public string RhIncompatibility { get; set; }

        //Jinekoloji
        public string PreviousBirthControlMethod
        {
            get;
            set;
        }

        public string CurrentBirthControlMethod
        {
            get;
            set;
        }

        public string GenitalAbnormalities
        {
            get;
            set;
        }

        public string MenstrualCycleAbnormalities
        {
            get;
            set;
        }

        public string ReproductiveAbnormality
        {
            get;
            set;
        }

        public string Dysuria
        {
            get;
            set;
        }

        public string Dyspareunia
        {
            get;
            set;
        }

        public string Hirsutism
        {
            get;
            set;
        }

        public string VaginalDischarge
        {
            get;
            set;
        }

        //Hasta Bazlı İnfertilite
        public TTObjectClasses.InfertilityPatientInformation _InfertilityPatientInformation
        {
            get;
            set;
        }

        //Gebe İzlem
        public string PregnancyDiseases
        {
            get;
            set;
        }
    }
}