//$205EEB5B
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class CensusFixedServiceController
    {
    /*partial void AfterContextSaveScript(BaseCensusFixedFormViewModel viewModel, CensusFixed censusFixed)
 {
 if (viewModel._CensusFixed.TransDef.ToStateDefID == CensusFixed.States.Completed)
                {
                    if ((viewModel._CensusFixed.OutMkysControl == null || viewModel._CensusFixed.OutMkysControl == false) && viewModel._CensusFixed.StockActionOutDetails.Count > 0)
                    {
                        censusFixed.SendMKYSForOutputDocument();
                        if ((viewModel._CensusFixed.InMkysControl == null || viewModel._CensusFixed.InMkysControl == false) && viewModel._CensusFixed.StockActionInDetails.Count > 0)
                        {
                            censusFixed.SendMKYSForInputDocument();
                        }
                    }
                    else if ((viewModel._CensusFixed.InMkysControl == null || viewModel._CensusFixed.InMkysControl == false) && viewModel._CensusFixed.StockActionInDetails.Count > 0)
                    {
                        censusFixed.SendMKYSForInputDocument();
                    }
                }
 }*/
    }
}

namespace Core.Models
{
    public partial class CensusFixedFormStockCardRegistryFormViewModel
    {
    }
}