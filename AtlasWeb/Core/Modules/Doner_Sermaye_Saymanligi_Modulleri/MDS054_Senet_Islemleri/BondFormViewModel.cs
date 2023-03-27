//$136B114A
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Reflection;

namespace Core.Controllers
{
    public partial class BondServiceController
    {
        partial void PreScript_BondForm(BondFormViewModel viewModel, Bond bond, TTObjectContext objectContext)
        {
            if (((ITTObject)bond).IsNew)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    viewModel._Bond.Episode = episode;
                    viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                }

                viewModel.OutPatientBondDayVariable = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("BONDDAYFOROUTPATIENT", "7"));
                viewModel.InPatientBondDayVariable = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("BONDDAYFORINPATIENT", "11"));
                viewModel._Bond.PrepareNewBond();
                ContextToViewModel(viewModel, objectContext);
                viewModel.AdvanceDocs = objectContext.LocalQuery<AdvanceDocument>().Where(x => x.Used == false && x.CurrentStateDefID == AdvanceDocument.States.Paid).ToArray();
            }
            else
            {
                foreach (BondDetail bondDetail in bond.BondDetails)
                {
                    bondDetail.Status = bondDetail.CurrentStateDef.DisplayText;
                }
            }
        }

        partial void PostScript_BondForm(BondFormViewModel viewModel, Bond bond, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            bond.CheckBondPersons();
            if (viewModel.AdvanceDocs != null)
            {
                foreach (AdvanceDocument item in viewModel.AdvanceDocs)
                {
                    objectContext.AddObject(item);
                }
            }
        }

        partial void AfterContextSaveScript_BondForm(BondFormViewModel viewModel, Bond bond, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (bond.RestructuredBonds != null && bond.RestructuredBonds.Count > 0)
                viewModel.RestructuredBondID = bond.RestructuredBonds.FirstOrDefault(x => x.CurrentStateDefID != Bond.States.Cancelled).ObjectID;
        }
    }
}

namespace Core.Models
{
    public partial class BondFormViewModel
    {
        public int NumberOfPayments
        {
            get;
            set;
        }

        public Episode[] Episodes
        {
            get;
            set;
        }

        public int OutPatientBondDayVariable
        {
            get;
            set;
        }

        public int InPatientBondDayVariable
        {
            get;
            set;
        }

        public AdvanceDocument[] AdvanceDocs
        {
            get;
            set;
        }

        public Guid RestructuredBondID
        {
            get;
            set;
        }
    }
}