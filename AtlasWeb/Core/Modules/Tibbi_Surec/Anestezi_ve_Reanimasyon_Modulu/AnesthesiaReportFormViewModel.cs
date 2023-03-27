//$B97D6359
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class AnesthesiaAndReanimationServiceController
    {
        partial void PreScript_AnesthesiaReportForm(AnesthesiaReportFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTObjectContext objectContext)
        {
            //if (this.Owner is SurgeryPricingForm)
            //    this.SetFormReadOnly();
            if (anesthesiaAndReanimation.MainSurgery != null)
            {
                if (anesthesiaAndReanimation.MainSurgery.CurrentStateDefID == Surgery.States.Rejected)
                {
                    string[] hataParamList = new string[]{anesthesiaAndReanimation.MainSurgery.ReasonOfReject.ToString()};
                    String message = SystemMessage.GetMessageV3(209, hataParamList);
                    throw new Exception(message); // Önceden InfoBoxMış belki yine Info yapılır Clienta taşınır
                //InfoBox.Show("Ameliyat Yapılamaz. Sebebi :\n\r " + _AnesthesiaAndReanimation.MainSurgery.ReasonOfReject.ToString());
                }
            }

            if (anesthesiaAndReanimation.CurrentStateDefID == AnesthesiaAndReanimation.States.AnesthesiaReport)
            {
                if (anesthesiaAndReanimation.AnesthesiaReportDate == null)
                {
                    anesthesiaAndReanimation.AnesthesiaReportDate = Common.RecTime();
                }

                anesthesiaAndReanimation.SetProcedureDoctorAsCurrentResource();
            }

            if (anesthesiaAndReanimation.AnesthesiaReportDate == null)
                anesthesiaAndReanimation.AnesthesiaReportDate = Common.RecTime();

            // Sorumlu Anestezist işlemleri
            viewModel.OnlyOneProcedureDoctor = true;
            if (anesthesiaAndReanimation.IsSecondDoctorNeededByGILPoint())
            {
                var selectedResponsibleDoctorList = new List<ResUser>();
                viewModel.ResponsibleDoctor_DataSource = ResUser.GetSpecialistDoctorByResource(objectContext, anesthesiaAndReanimation.MasterResource.ObjectID).ToArray();
                viewModel.OnlyOneProcedureDoctor = false;
                foreach (var anesthesiaResponsibleDoctor in anesthesiaAndReanimation.AnesthesiaResponsibleDoctors)
                {
                    selectedResponsibleDoctorList.Add(anesthesiaResponsibleDoctor.ResponsibleDoctor);
                }
                viewModel.SelectedResponsibleDoctorList = selectedResponsibleDoctorList.ToArray();
            }

            //viewModel.TreatmentMaterialListFilter = anesthesiaAndReanimation.GetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["AnesthesiaAndReanimationTreatmentMaterial"]);
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı
            viewModel.GridAnesthesiaExpendsGridList = viewModel.GridAnesthesiaExpendsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
        }

        partial void PostScript_AnesthesiaReportForm(AnesthesiaReportFormViewModel viewModel, AnesthesiaAndReanimation anesthesiaAndReanimation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            // <Sorumlu Anestezi Uzmanı Kaydetme
            //if (viewModel.OnlyOneProcedureDoctor)
            //{
            //    if (anesthesiaAndReanimation.ProcedureDoctor == null)
            //    {
            //        string[] hataParamList = new string[] { "'Sorumlu Anestezi Uzmanı'" };
            //        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList))
            //    }
            //    var selectedResponsibleDoctorList = new List<ResUser>();
            //    selectedResponsibleDoctorList.Add(anesthesiaAndReanimation.ProcedureDoctor);
            //    viewModel.SelectedResponsibleDoctorList = selectedResponsibleDoctorList.ToArray();

            //}
            //int doctorCount = viewModel.SelectedResponsibleDoctorList.Count();
            //int oldDoctorCount = anesthesiaAndReanimation.AnesthesiaResponsibleDoctors.Count;

            //while (doctorCount < oldDoctorCount)
            //{
            //    ((ITTObject)anesthesiaAndReanimation.AnesthesiaResponsibleDoctors[oldDoctorCount - 1]).Delete();
            //    oldDoctorCount--;
            //}

            //doctorCount = 0;
            //oldDoctorCount = anesthesiaAndReanimation.AnesthesiaResponsibleDoctors.Count - 1;
            //foreach (var responsibleDoctor in viewModel.SelectedResponsibleDoctorList)
            //{
            //    if (doctorCount == 0 && !viewModel.OnlyOneProcedureDoctor)
            //    { anesthesiaAndReanimation.ProcedureDoctor = responsibleDoctor; }

            //    // eskiden girilenin doktor sayısı yeni girilene eşitse yada büyükse günceller
            //    if (doctorCount <= oldDoctorCount)
            //    {
            //        anesthesiaAndReanimation.AnesthesiaResponsibleDoctors[doctorCount].ResponsibleDoctor = responsibleDoctor;
            //    }
            //    else // eskiden girilenin doktor sayısı yeni girilenden küçükse yeni yaratır
            //    {
            //        AnesthesiaResponsibleDoctor anesthesiaResponsibleDoctors = new AnesthesiaResponsibleDoctor(objectContext);
            //        anesthesiaResponsibleDoctors.ResponsibleDoctor = responsibleDoctor;
            //        anesthesiaAndReanimation.AnesthesiaResponsibleDoctors.Add(anesthesiaResponsibleDoctors);
            //    }
            //    doctorCount++;
            //}

            //if (anesthesiaAndReanimation.ProcedureDoctor == null)
            //{
            //    string[] hataParamList = new string[] { "'Sorumlu Anestezi Uzmanı'" };
            //    throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList))
            //}


            anesthesiaAndReanimation.ArrangeProcedureDoctorAndAddContext(viewModel.OnlyOneProcedureDoctor, viewModel.SelectedResponsibleDoctorList);
            // Sorumlu Anestezi Uzmanı Kaydetme>

            if (transDef != null)
            {
                if (transDef.ToStateDef.StateDefID == AnesthesiaAndReanimation.States.Completed)
                {
                    anesthesiaAndReanimation.CheckAnesthesiaTime();
                    if (anesthesiaAndReanimation.AnesthesiaTechnique == null)
                    {
                        string[] hataParamList = new string[] { "'Anestezi Tekniği'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new Exception("'Gerçekleşen Anestezi Tekniği' girilmeden işlem tamamlanamaz.");
                    }

                    if (anesthesiaAndReanimation.AnesthesiaPersonnels.Count < 1)
                    {
                        string[] hataParamList = new string[] { "'Anestezi Ekibi'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new Exception("'Anestezi Ekibi' girilmeden işlem tamamlanamaz.");
                    }
                    //if (anesthesiaAndReanimation.IsTreatmentMaterialEmpty != true)
                    //{
                    //    if (anesthesiaAndReanimation.TreatmentMaterials.Count < 1)
                    //    {
                    //        throw new TTUtils.TTException(SystemMessage.GetMessage(207));
                    //    // throw new Exception("Sarf Girişi yapılmadan işlem tamamlanamaz.");
                    //    }
                    //}
                }
            }


        }
    }
}

namespace Core.Models
{
    public partial class AnesthesiaReportFormViewModel
    {
        public TTObjectClasses.ResUser[] ResponsibleDoctor_DataSource { get; set; }
        public TTObjectClasses.ResUser[] SelectedResponsibleDoctorList { get; set; }

        public Boolean OnlyOneProcedureDoctor;
    }
}