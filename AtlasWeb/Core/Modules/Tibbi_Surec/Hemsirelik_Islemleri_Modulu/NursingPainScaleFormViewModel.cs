//$97B3F9D0
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
    public partial class NursingPainScaleServiceController
    {
        partial void PreScript_NursingPainScaleForm(NursingPainScaleFormViewModel viewModel, NursingPainScale nursingPainScale, TTObjectContext objectContext)
        {
            viewModel.SelectedChangingSituationIncreaseList = new List<PainChangingSituationDefinition>();
            viewModel.SelectedChangingSituationDecreaseList = new List<PainChangingSituationDefinition>();
            viewModel.SelectedNursingInitiatives = new List<NursingInitiativeDefinition>();
            if (nursingPainScale.ApplicationUser == null)
                nursingPainScale.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingPainScale).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingPainScale);
                }
            }
            viewModel.PainChangingSituationDefinitions = PainChangingSituationDefinition.GetPainChangingSituationDef(objectContext, "").ToArray();
            viewModel.NursingInitiativeDefinitions = NursingInitiativeDefinition.GetNursingInitiativeDefinition(objectContext, "").ToArray();
            var i = 0;
            foreach (var data in viewModel._NursingPainScale.PainScaleIncreaseGrids)
            {
                var item = new PainChangingSituationDefinition();
                item = data.PainChangingSituation;
                viewModel.SelectedChangingSituationIncreaseList.Add(item);
            }
            i = 0;
            foreach (var data in viewModel._NursingPainScale.PainScaleDecreaseGrid)
            {
                var item = new PainChangingSituationDefinition();
                item = data.PainChangingSituation;
                viewModel.SelectedChangingSituationDecreaseList.Add(item);
            }            
            foreach (var data in viewModel._NursingPainScale.NursingInitiatives)
            {
                var item = new NursingInitiativeDefinition();
                item = data.NursingInitiatives;
                viewModel.SelectedNursingInitiatives.Add(item);
            }
        }


        partial void PostScript_NursingPainScaleForm(NursingPainScaleFormViewModel viewModel, NursingPainScale nursingPainScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            while (viewModel.SelectedChangingSituationDecreaseList.Count != nursingPainScale.PainScaleDecreaseGrid.Count)
            {
                if (viewModel.SelectedChangingSituationDecreaseList.Count < nursingPainScale.PainScaleDecreaseGrid.Count)
                    ((ITTObject)nursingPainScale.PainScaleDecreaseGrid[0]).Delete();
                else
                {
                    var painScaleDecreaseItem = new PainScaleDecreaseGrid(objectContext);
                    nursingPainScale.PainScaleDecreaseGrid.Add(painScaleDecreaseItem);
                }
            }

            while(viewModel.SelectedChangingSituationIncreaseList.Count != nursingPainScale.PainScaleIncreaseGrids.Count)
            {
                if (viewModel.SelectedChangingSituationIncreaseList.Count < nursingPainScale.PainScaleIncreaseGrids.Count)
                    ((ITTObject)nursingPainScale.PainScaleIncreaseGrids[0]).Delete();
                else
                {
                    var painScaleIncreaseItem = new PainScaleIncreaseGrid(objectContext);
                    nursingPainScale.PainScaleIncreaseGrids.Add(painScaleIncreaseItem);
                }
            }
            while (viewModel.SelectedNursingInitiatives.Count != nursingPainScale.NursingInitiatives.Count)
            {
                if (viewModel.SelectedNursingInitiatives.Count < nursingPainScale.NursingInitiatives.Count)
                    ((ITTObject)nursingPainScale.NursingInitiatives[0]).Delete();
                else
                {
                    var nursingInitiative = new NursingInitiative(objectContext);
                    nursingPainScale.NursingInitiatives.Add(nursingInitiative);
                }
            }
            var i = 0;
            foreach (var item in viewModel.SelectedChangingSituationDecreaseList)
            {
                nursingPainScale.PainScaleDecreaseGrid[i++].PainChangingSituation = item;
            }

            i = 0;
            foreach (var item in viewModel.SelectedChangingSituationIncreaseList)
            {
                nursingPainScale.PainScaleIncreaseGrids[i++].PainChangingSituation = item;
            }

            i = 0;
            foreach (var item in viewModel.SelectedNursingInitiatives)
            {
                nursingPainScale.NursingInitiatives[i++].NursingInitiatives = item;
            }

        }

    }
}

namespace Core.Models
{
    public partial class NursingPainScaleFormViewModel
    {
        public IList<PainChangingSituationDefinition> PainChangingSituationDefinitions { get; set; }
        public IList<PainChangingSituationDefinition> SelectedChangingSituationIncreaseList { get; set; }
        public IList<PainChangingSituationDefinition> SelectedChangingSituationDecreaseList { get; set; }
        public IList<NursingInitiativeDefinition> NursingInitiativeDefinitions { get; set; }
        public IList<NursingInitiativeDefinition> SelectedNursingInitiatives { get; set; }

    }
}