//$8D578745
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class SubSurgeryServiceController
    {
        partial void PreScript_SubSurgeryForm(SubSurgeryFormViewModel viewModel, SubSurgery subSurgery, TTObjectContext objectContext)
        {
            // Postta set edilyor
            //if (subSurgery.SurgeryReportDate == null)
            //{
            //    subSurgery.SurgeryReportDate = Common.RecTime();
            //}

            viewModel.vitalSingsViewModel = subSurgery.Surgery.GetVitalSingsFormViewModel(objectContext);

            viewModel.SurgeryProcedureFormViewModelList = SurgeryProcedureServiceController.GetSurgeryProcedureFormViewModelList(subSurgery.SubSurgeryProcedures.ToList<SurgeryProcedure>());

            viewModel.IsRequiredPathology = false;//Ameliyat hizmeti patoloji gerektiriyor ise patoloji istek yapmaya zorlanacak!
            var pathologyOperationNeededProcedure = viewModel.SurgeryProcedureFormViewModelList.Where(c => c.ProcedureDefinitions.FirstOrDefault().PathologyOperationNeeded == true);
            if (pathologyOperationNeededProcedure.Count() > 0 && subSurgery.SubEpisode != null)
            {
                var pathologyExist = PathologyRequest.GetPathologyRequestBySubEpisode(subSurgery.SubEpisode.ObjectID.ToString());
                if (pathologyExist.Count() == 0)//patoloji gerektirdi�i halde subepisode'da patoloji yok ise uyar� verilecek
                {
                    viewModel.IsRequiredPathology = true;
                }
            }

            // Di�er Bran�lara ait ameliyat �zeti
            viewModel.OtherSurgerySummaryFormViewModellList = SurgeryServiceController.GetOtherSurgerySummaryFormViewModellList(subSurgery.Surgery, subSurgery);

            // SARF GRIDINDE Cancelledlar gelmemesi  i�in  Bu koddan sonra ContextToViewModel �al��mamal�
            viewModel.GridSurgeryExpendsGridList = viewModel.GridSurgeryExpendsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
            //ContextToViewModel den sonra �a��r�lmal� //TANI i�in
            viewModel.GridEpisodeDiagnosisGridList = subSurgery.DiagnosisGrid_PreScript();
        }
        partial void PostScript_SubSurgeryForm(SubSurgeryFormViewModel viewModel, SubSurgery subSurgery, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            // Serverdan gelen SurgeryProcedureleri  Contexte add etmeden serverdaki Surgeryprocedure contexte eklenirse (ki bu . mainprocedure Kodu �al��t���nda oluyor) clientdakiler tekrar eklenemiyor O y�zden Bu kod en tepeye �ekildi
            SurgeryProcedureServiceController.SaveSurgeryProcedureFormViewModelList(objectContext, viewModel.SurgeryProcedureFormViewModelList);
            if (subSurgery.SurgeryReport != null && !string.IsNullOrEmpty(subSurgery.SurgeryReport.ToString()) && subSurgery.SurgeryReportDate == null)
            {
                subSurgery.SurgeryReportDate = Common.RecTime();
            }
            if (transDef != null && transDef.ToStateDefID == SubSurgery.States.Completed)
            {
                subSurgery.SubSurgeryProceduresIsResquired();
            }
            //TANI i�in
            subSurgery.DiagnosisGrid_PostScript(viewModel.GridEpisodeDiagnosisGridList);
            subSurgery.Surgery.SetVitalSingsFormViewModel(viewModel.vitalSingsViewModel);
            if (transDef != null)
            {
                if ((transDef.ToStateDefID == Surgery.States.Completed || transDef.ToStateDefID == Surgery.States.WaitingForSubSurgeries) && viewModel.IsRequiredPathology == true)
                {
                    var pathologyExist = PathologyRequest.GetPathologyRequestBySubEpisode(subSurgery.SubEpisode.ObjectID.ToString());
                    if (pathologyExist.Count() == 0)
                    {
                        throw new Exception("Patoloji i�lemi gerektiren bir ameliyat se�ildi! Ameliyat�n tamamlanmas� i�in l�tfen ekran� �nce 'Patoloji iste�i' yap�p daha sonra 'Kaydet/Tamamla' butonuna bas�n�z");
                    }

                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class SubSurgeryFormViewModel
    {
        public TTObjectClasses.EpisodeAction.VitalSingsFormViewModel vitalSingsViewModel;
        public object _selectedSurgeryProcedure
        {
            get;
            set;
        }
        public SurgeryProcedureFormViewModel[] SurgeryProcedureFormViewModelList { get; set; }

        public SurgerySummaryFormViewModel[] OtherSurgerySummaryFormViewModellList { get; set; }

        public Boolean IsRequiredPathology { get; set; }
    }
}
