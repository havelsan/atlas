//$8C785785
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class InfluenzaResultServiceController
    {

        partial void PreScript_InfluenzaResultForm(InfluenzaResultFormViewModel viewModel, InfluenzaResult influenzaResult, TTObjectContext objectContext)
        {
        }

        partial void PostScript_InfluenzaResultForm(InfluenzaResultFormViewModel viewModel, InfluenzaResult influenzaResult, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            //Episode episode = objectContext.GetObject<Episode>(influenzaResult.Episode[0].ObjectID);

            InfluenzaResult irr = new InfluenzaResult();

            InfluenzaServis.WebMethods.InfluenzaTaniBilgisi i = new InfluenzaServis.WebMethods.InfluenzaTaniBilgisi();
            i.aileHekimligindeMi = false;
            i.AntijenTesti = influenzaResult.InfluenzaResultProp == 0 ? InfluenzaServis.WebMethods.AntijenTestiSonuclari.Negatif : InfluenzaServis.WebMethods.AntijenTestiSonuclari.Pozitif;
            i.HastaTC = influenzaResult.Episode.Select("1=1")[0].Patient.UniqueRefNo.ToString();
            i.HekimTC = influenzaResult.ResponsibleDoctor.UniqueNo;
            i.ICD10Kodu = influenzaResult.ICD10Kodu;
            i.IslemGuid = influenzaResult.IslemGuid;

            string _siteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

            InfluenzaServis.WebMethods.ServiceResult sr = InfluenzaServis.WebMethods.SaveInfluenzaTaniTestSync(new Guid(_siteId), i);

            influenzaResult.ControlReturnResult(sr.State, sr.Message);

            influenzaResult.ErrorMessage = sr.Message;
        }

        [HttpGet]
        public string IsExistingInfluenzaDiagnosis(Guid EpisodeID)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("INFLUENZASERVICEACTIVE", "FALSE") == "TRUE")
            {
                DiagnosisGrid.GetInfluenzaDiagByEpisode_Class[] _influenza = DiagnosisGrid.GetInfluenzaDiagByEpisode(EpisodeID).ToArray();

                if (_influenza != null && _influenza.Length > 0)
                    return _influenza[0].Influenza.ToString();
            }

            return null;
        }

        [HttpGet]
        public bool IsInfluenzaDiagnosis(Guid DiagnosisObjectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if(DiagnosisObjectID != Guid.Empty ){
                    var selectedDiagnosis = objectContext.GetObject(DiagnosisObjectID, "DiagnosisDefinition") as DiagnosisDefinition;

                    if (selectedDiagnosis != null)
                    {
                        var diagnosis = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, selectedDiagnosis.Code, "");

                        if (diagnosis[0].IsInfluenzaDiagnos.HasValue && diagnosis[0].IsInfluenzaDiagnos.Value)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}

namespace Core.Models
{
    public partial class InfluenzaResultFormViewModel: BaseViewModel
    {
        
    }
}
