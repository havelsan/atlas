//$BAC972AA
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class GrantMaterialServiceController : Controller
    {
        public class InputForReGeneration
        {
            public string ActionID
            {
                get;
                set;
            }
        }

        public class OutputForReGeneration
        {
            public string OutputMessage
            {
                get;
                set;
            }
            public bool IsTheActionGenerated
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OutputForReGeneration ReGenerateMyGrantMaterial(InputForReGeneration input)
        {

            OutputForReGeneration outputObject = new OutputForReGeneration();
            try
            {
                BindingList<StockAction.GetClonedStockAction_Class> otherClonedActions = StockAction.GetClonedStockAction(new Guid(input.ActionID));
                if (otherClonedActions.Count > 0)
                {
                    outputObject.IsTheActionGenerated = false;
                    outputObject.OutputMessage = " Bu işlem daha önce " + otherClonedActions[0].StockActionID.ToString() + " işlem olarak kopyanalmış bir daha kopyalamak istiyorsanız bu işlemi iptal etmeniz gerekmektedir.";
                    return outputObject;
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    GrantMaterial currentAction = (GrantMaterial)context.GetObject(new Guid(input.ActionID), typeof(GrantMaterial));

                    if (currentAction != null && currentAction.CurrentStateDefID == GrantMaterial.States.Cancelled)
                    {

                        GrantMaterial newAction = (GrantMaterial)currentAction.Clone();

                        newAction.CurrentStateDefID = GrantMaterial.States.New;
                        newAction.Description += " (İptal edilmiş " + currentAction.StockActionID.ToString() + " numaralı işlem üzerinden tekrar oluşturulmuştur!)";
                        newAction.ClonedObjectID = currentAction.ObjectID;

                        TTSequence.allowSetSequenceValue = true;
                        newAction.StockActionID.SetSequenceValue(0);

                        newAction.StockActionID.GetNextValue();

                        foreach (GrantMaterialDetail item in currentAction.GrantMaterialDetails)
                        {
                            GrantMaterialDetail detail = (GrantMaterialDetail)item.Clone();
                            detail.StockAction = newAction;
                            detail.Status = StockActionDetailStatusEnum.New;
                        }


                        context.Save();

                        outputObject.IsTheActionGenerated = true;
                        outputObject.OutputMessage = newAction.StockActionID.ToString() + " numaralı işlem başarıyla oluşturulmuştur! İş listesinden kontrol ediniz!";
                    }
                    else
                    {
                        outputObject.IsTheActionGenerated = false;
                        outputObject.OutputMessage = TTUtils.CultureService.GetText("M26181", "İşlem kopyası oluşturma başarısız!");
                    }

                    return outputObject;
                }

            }
            catch (Exception ex)
            {
                outputObject.IsTheActionGenerated = false;
                outputObject.OutputMessage = ex.ToString();
                return outputObject;
            }

        }
    }
}