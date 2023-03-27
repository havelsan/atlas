//$FCFFB79A
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using static Core.Controllers.KScheduleServiceController;

namespace Core.Controllers
{
    public partial class KScheduleServiceController
    {
        partial void PreScript_KScheduleCompletedForm(KScheduleCompletedFormViewModel viewModel, KSchedule kSchedule, TTObjectContext objectContext)
        {

            var kScheduleMaterialRowViewModelList = new List<KScheduleMaterialRowViewModel>();
            //KScheduleMaterialRowViewModelList doldurmaca 
            //kScheduleMaterial ile doldurma


            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                KScheduleMaterialRowViewModel kScheduleMaterialRowViewModel = new KScheduleMaterialRowViewModel();

                kScheduleMaterialRowViewModel.RowObjectId = kScheduleMaterial.ObjectID;
                kScheduleMaterialRowViewModel.KScheduleMaterialRowType = KScheduleMaterialRowType.KScheduleMaterial;
                kScheduleMaterialRowViewModel.Material = kScheduleMaterial.Material;
                kScheduleMaterialRowViewModel.BarcodeVerifyCounter = kScheduleMaterial.BarcodeVerifyCounter;

                kScheduleMaterialRowViewModel.IsImmediate = kScheduleMaterial.IsImmediate;
                kScheduleMaterialRowViewModel.RequestAmount = kScheduleMaterial.RequestAmount; // kScheduleMaterial  RequestAmount  KSchedulePatienOwnDrug için DrugAmount olmalý 
                kScheduleMaterialRowViewModel.ReceivedAmount = kScheduleMaterial.Amount;
                kScheduleMaterialRowViewModel.StoreInheld = StockLevel.StockInheldWithStockLevel(kScheduleMaterial.Material.ObjectID, kSchedule.Store.ObjectID, kScheduleMaterial.StockLevelType.ObjectID);
                kScheduleMaterialRowViewModel.Description = kScheduleMaterial.Description;
                kScheduleMaterialRowViewModel.PrescriptionNo = kScheduleMaterial.PrescriptionNO;

                if ((StockActionDetailStatusEnum)kScheduleMaterial.Status == StockActionDetailStatusEnum.Cancelled)
                {
                    kScheduleMaterialRowViewModel.Status = StockActionDetailStatusEnum.Cancelled;
                    if (kScheduleMaterial.DrugOrderStartDate != null)
                        kScheduleMaterialRowViewModel.DrugOrderStartDate = kScheduleMaterial.DrugOrderStartDate.Value;
                }
                else
                {
                    foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                    {
                        kScheduleMaterialRowViewModel.UsageNote = Common.GetDisplayTextOfEnumValue("DrugUsageTypeEnum", (int)stateDrugOrderDetail.DrugOrder.DrugUsageType);
                        kScheduleMaterialRowViewModel.DrugOrderStartDate = stateDrugOrderDetail.DrugOrder.PlannedStartTime.Value;

                        if (kScheduleMaterial.Status != null)
                            kScheduleMaterialRowViewModel.Status = (StockActionDetailStatusEnum)kScheduleMaterial.Status;
                        //kScheduleMaterialRowViewModel.IsNarcotic = ((DrugDefinition)kScheduleMaterial.Material).IsNarcotic == null ? false : (bool)((DrugDefinition)kScheduleMaterial.Material).IsNarcotic;
                        //kScheduleMaterialRowViewModel.IsPsychotropic = ((DrugDefinition)kScheduleMaterial.Material).IsPsychotropic == null ? false : (bool)((DrugDefinition)kScheduleMaterial.Material).IsPsychotropic;

                        // Bunlar kScheduleMaterial için mevcut deðil
                        //kScheduleMaterialRowViewModel.ExpirationDate = 


                        break;
                    }
                }

                StockTransaction outTRX = kScheduleMaterial.StockTransactions.Select(string.Empty, "EXPIRATIONDATE").FirstOrDefault();
                if (outTRX != null)
                    kScheduleMaterialRowViewModel.ExpirationDate = outTRX.ExpirationDate;
                kScheduleMaterialRowViewModelList.Add(kScheduleMaterialRowViewModel);

            }


            //KSchedulePatienOwnDrugs ile doldurma
            foreach (KSchedulePatienOwnDrug ownDrug in kSchedule.KSchedulePatienOwnDrugs)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in ownDrug.DrugOrderDetails)
                {
                    KScheduleMaterialRowViewModel kScheduleMaterialRowViewModel = new KScheduleMaterialRowViewModel();

                    kScheduleMaterialRowViewModel.RowObjectId = ownDrug.ObjectID;
                    kScheduleMaterialRowViewModel.KScheduleMaterialRowType = KScheduleMaterialRowType.KSchedulePatienOwnDrug;
                    kScheduleMaterialRowViewModel.Material = ownDrug.Material;
                    kScheduleMaterialRowViewModel.BarcodeVerifyCounter = ownDrug.BarcodeVerifyCounter;

                    if (ownDrug.StockActionStatus != null)
                        kScheduleMaterialRowViewModel.Status = (StockActionDetailStatusEnum)ownDrug.StockActionStatus;

                    kScheduleMaterialRowViewModel.IsImmediate = false;

                    kScheduleMaterialRowViewModel.DrugOrderStartDate = stateDrugOrderDetail.DrugOrder.PlannedStartTime.Value;
                    kScheduleMaterialRowViewModel.RequestAmount = ownDrug.DrugAmount; // kScheduleMaterial  RequestAmount  KSchedulePatienOwnDrug için DrugAmount olmalý 
                                                                                      // Bunlar KSchedulePatienOwnDrug için mevcut deðil
                                                                                      // kScheduleMaterialRowViewModel.ReceivedAmount ;
                                                                                      // kScheduleMaterialRowViewModel.StoreInheld
                                                                                      //kScheduleMaterialRowViewModel.Description = 
                    kScheduleMaterialRowViewModel.UsageNote = Common.GetDisplayTextOfEnumValue("DrugUsageTypeEnum", (int)stateDrugOrderDetail.DrugOrder.DrugUsageType);
                    kScheduleMaterialRowViewModel.ExpirationDate = ownDrug.ExpirationDate;

                    //kScheduleMaterialRowViewModel.IsNarcotic = ((DrugDefinition)ownDrug.Material).IsNarcotic == null ? false : (bool)((DrugDefinition)ownDrug.Material).IsNarcotic;
                    //kScheduleMaterialRowViewModel.IsPsychotropic = ((DrugDefinition)ownDrug.Material).IsPsychotropic == null ? false : (bool)((DrugDefinition)ownDrug.Material).IsPsychotropic;

                    kScheduleMaterialRowViewModelList.Add(kScheduleMaterialRowViewModel);

                    break;


                }
            }

            foreach (KScheduleInfectionDrug infectionDrug in kSchedule.KScheduleInfectionDrugs)
            {
                KScheduleMaterialRowViewModel kScheduleMaterialRowViewModel = new KScheduleMaterialRowViewModel();

                kScheduleMaterialRowViewModel.RowObjectId = infectionDrug.ObjectID;
                kScheduleMaterialRowViewModel.KScheduleMaterialRowType = KScheduleMaterialRowType.KScheduleInfection;
                kScheduleMaterialRowViewModel.Material = infectionDrug.Material;
                kScheduleMaterialRowViewModel.BarcodeVerifyCounter = infectionDrug.BarcodeVerifyCounter;
                if (infectionDrug.StockActionStatus != null)
                    kScheduleMaterialRowViewModel.Status = (StockActionDetailStatusEnum)infectionDrug.StockActionStatus;
                kScheduleMaterialRowViewModel.IsImmediate = false;

                kScheduleMaterialRowViewModel.RequestAmount = infectionDrug.DrugAmount;
                kScheduleMaterialRowViewModel.ExpirationDate = infectionDrug.ExpirationDate;

                kScheduleMaterialRowViewModelList.Add(kScheduleMaterialRowViewModel);
            }

            viewModel.KScheduleMaterialRowViewModelList = kScheduleMaterialRowViewModelList.OrderBy(dr => dr.DrugOrderStartDate).ToArray();

        }
    }
}

namespace Core.Models
{
    public partial class KScheduleCompletedFormViewModel
    {
        public KScheduleMaterialRowViewModel[] KScheduleMaterialRowViewModelList { get; set; }
    }
}