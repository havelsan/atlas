//$A10B256D
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;
using System.Collections.Generic;
using static Core.Controllers.KScheduleServiceController;
using static Core.Controllers.StockLevelServiceController;
using static Core.Controllers.DrugOrderIntroductionServiceController;
using TTDataDictionary;
using System.Text;

namespace Core.Controllers
{
    public partial class KScheduleServiceController
    {
        partial void PreScript_KScheduleApprovalForm(KScheduleApprovalFormViewModel viewModel, KSchedule kSchedule, TTObjectContext objectContext)
        {
            var kScheduleMaterialRowViewModelList = new List<KScheduleMaterialRowViewModel>();
            //KScheduleMaterialRowViewModelList doldurmaca 
            //kScheduleMaterial ile doldurma

            List<DrugDefinition> ksmDrugDefinitionGridList = new List<DrugDefinition>();
            List<Guid> ksmDrugOrderObjectIDs = new List<Guid>();
            List<Guid> allDrugDefinitionObjectIDs = new List<Guid>();

            DrugOrderIntroductionServiceController drugOrderIntroductionServiceController = new DrugOrderIntroductionServiceController();
            var ageDifferenceValidateMessage = string.Empty;
            var drugNutrientInteractionMessage = string.Empty;
            var doctorDescriptionOnDrug = string.Empty;
            var drugDescriptionMessage = string.Empty;
            var repeatDayWarning = string.Empty;

            List<PatientLastUseDrugDVO> drugDVOs = new List<PatientLastUseDrugDVO>();
            BindingList<PatientLastUseDrug.GetPatientLastUseDrugs_Class> getPatientLasts = PatientLastUseDrug.GetPatientLastUseDrugs(kSchedule.InPatientPhysicianApplication.SubEpisode.ObjectID);
            foreach (PatientLastUseDrug.GetPatientLastUseDrugs_Class lastDrug in getPatientLasts)
            {
                PatientLastUseDrugDVO drugDVO = new PatientLastUseDrugDVO();
                drugDVO.DrugName = lastDrug.Drugname;
                drugDVO.Amount = lastDrug.Amount.Value;
                drugDVOs.Add(drugDVO);
            }
            viewModel.patientLastUseDrugs = drugDVOs.ToArray();

            foreach (KScheduleMaterial kScheduleMaterial in kSchedule.StockActionOutDetails)
            {
                foreach (DrugOrderDetail stateDrugOrderDetail in kScheduleMaterial.KScheduleCollectedOrder.DrugOrderDetails)
                {
                    KScheduleMaterialRowViewModel kScheduleMaterialRowViewModel = new KScheduleMaterialRowViewModel();

                    kScheduleMaterialRowViewModel.RowObjectId = kScheduleMaterial.ObjectID;
                    kScheduleMaterialRowViewModel.KScheduleMaterialRowType = KScheduleMaterialRowType.KScheduleMaterial;
                    kScheduleMaterialRowViewModel.Material = kScheduleMaterial.Material;
                    kScheduleMaterialRowViewModel.BarcodeVerifyCounter = kScheduleMaterial.BarcodeVerifyCounter;

                    if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                    {
                        kScheduleMaterialRowViewModel.Status = StockActionDetailStatusEnum.Cancelled;
                    }
                    else if (kScheduleMaterial.Status != null)
                    {
                        kScheduleMaterialRowViewModel.Status = (StockActionDetailStatusEnum)kScheduleMaterial.Status;
                    }
                    kScheduleMaterialRowViewModel.IsImmediate = kScheduleMaterial.IsImmediate;
                    kScheduleMaterialRowViewModel.IsCV = kScheduleMaterial.IsCV;

                    kScheduleMaterialRowViewModel.DrugOrderStartDate = stateDrugOrderDetail.DrugOrder.PlannedStartTime.Value;
                    kScheduleMaterialRowViewModel.RequestAmount = kScheduleMaterial.RequestAmount; // kScheduleMaterial  RequestAmount  KSchedulePatienOwnDrug için DrugAmount olmalý 
                    kScheduleMaterialRowViewModel.ReceivedAmount = kScheduleMaterial.Amount;
                    kScheduleMaterialRowViewModel.StoreInheld = kScheduleMaterial.Material.StockInheld(kSchedule.Store);


                    kScheduleMaterialRowViewModel.Description = kScheduleMaterial.Description;
                    kScheduleMaterialRowViewModel.PrescriptionNo = kScheduleMaterial.PrescriptionNO;
                    kScheduleMaterialRowViewModel.UsageNote = Common.GetDisplayTextOfEnumValue("DrugUsageTypeEnum", (int)stateDrugOrderDetail.DrugOrder.DrugUsageType);

                    //kScheduleMaterialRowViewModel.IsNarcotic = ((DrugDefinition)kScheduleMaterial.Material).IsNarcotic == null ? false : (bool)((DrugDefinition)kScheduleMaterial.Material).IsNarcotic;
                    //kScheduleMaterialRowViewModel.IsPsychotropic = ((DrugDefinition)kScheduleMaterial.Material).IsPsychotropic == null ? false : (bool)((DrugDefinition)kScheduleMaterial.Material).IsPsychotropic;

                    kScheduleMaterialRowViewModelList.Add(kScheduleMaterialRowViewModel);
                    // Bunlar kScheduleMaterial için mevcut deðil
                    //kScheduleMaterialRowViewModel.ExpirationDate = 

                    Stock s = kScheduleMaterial.Material.Stocks.Select("STORE=" + TTConnectionManager.ConnectionManager.GuidToString(kSchedule.Store.ObjectID)).FirstOrDefault();
                    BindingList<StockTransaction.LOTOutableStockTransactions_Class> expDates = StockTransaction.LOTOutableStockTransactions(s.ObjectID);
                    if (expDates.Count > 0)
                        kScheduleMaterialRowViewModel.ExpirationDate = expDates[0].ExpirationDate;



                    // overDoseMessage için kullanmak üzere
                    if (kScheduleMaterial.Material is DrugDefinition && ksmDrugDefinitionGridList.FirstOrDefault(dr => dr.ObjectID == kScheduleMaterial.Material.ObjectID) == null)
                        ksmDrugDefinitionGridList.Add((DrugDefinition)kScheduleMaterial.Material);

                    if (!ksmDrugOrderObjectIDs.Contains(kScheduleMaterial.ObjectID))
                        ksmDrugOrderObjectIDs.Add(kScheduleMaterial.ObjectID);

                    if (!allDrugDefinitionObjectIDs.Contains(kScheduleMaterial.Material.ObjectID))
                        allDrugDefinitionObjectIDs.Add(kScheduleMaterial.Material.ObjectID);

                    var drugDefinition = (DrugDefinition)kScheduleMaterial.Material;

                    var MaterialMaxAge = 999;
                    var MaterialMinAge = -1;

                    var patientAge = kSchedule.Episode.Patient.Age.Value;
                    if (drugDefinition.MaxPatientAge != null)
                        MaterialMaxAge = drugDefinition.MaxPatientAge.Value;

                    if (drugDefinition.MinPatientAge != null)
                        MaterialMinAge = drugDefinition.MinPatientAge.Value;

                    if (MaterialMaxAge < patientAge || MaterialMinAge > patientAge)
                    {
                        ageDifferenceValidateMessage += "Karþýladýðýnýz ilaç hastanýn yaþ aralýðý için uygun deðildir. Hastanýz " + patientAge
                          + " yaþýnda, ilaç için tavsiye edilen yaþ aralýðý (" + MaterialMinAge + ")-(" + MaterialMaxAge + ")";

                    }

                    if (!String.IsNullOrEmpty(drugDefinition.DrugNutrientInteraction))
                    {
                        drugNutrientInteractionMessage += " Karþýladýðýnýz " + drugDefinition.Name + " ilacýnda besin etkileþimi vardýr! " + drugDefinition.DrugNutrientInteraction;
                    }

                    if (!String.IsNullOrEmpty(stateDrugOrderDetail.DrugOrder.Description))
                    {
                        doctorDescriptionOnDrug += " Karþýladýðýnýz " + drugDefinition.Name + " ilaca dair girilen açýklama " + stateDrugOrderDetail.DrugOrder.Description;
                    }

                    if (!string.IsNullOrEmpty(drugDefinition.Description))
                    {
                        if (drugDefinition.MaterialDescriptionShowType != null)
                        {
                            if (drugDefinition.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Kschedule || drugDefinition.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                drugDescriptionMessage += " Karþýladýðýnýz " + drugDefinition.Name + " ilacýn açýklamasý: " + drugDefinition.Description;
                        }
                        else
                            drugDescriptionMessage += " Karþýladýðýnýz " + drugDefinition.Name + " ilacýn açýklamasý: " + drugDefinition.Description;
                    }

                    if (string.IsNullOrEmpty(stateDrugOrderDetail.DrugOrder.RepeatDayWarning) == false)
                        repeatDayWarning += stateDrugOrderDetail.DrugOrder.RepeatDayWarning;

                    break;
                    //if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                    //{
                    //    kScheduleMaterial.Status = StockActionDetailStatusEnum.Cancelled;
                    //}
                    //kScheduleMaterial.DrugOrderStartDate = stateDrugOrderDetail.DrugOrder.PlannedStartTime.Value;
                    //kScheduleMaterial.DrugOrderObjectID = stateDrugOrderDetail.DrugOrder.ObjectID;
                    //kScheduleMaterial.TimesInADay = (int)(stateDrugOrderDetail.DrugOrder.Amount.Value / stateDrugOrderDetail.DrugOrder.DoseAmount.Value);
                    //kScheduleMaterial.UsageNote = Common.GetDisplayTextOfEnumValue("DrugUsageTypeEnum", (int)stateDrugOrderDetail.DrugOrder.DrugUsageType);
                }
            }

            viewModel.ageDifferenceValidateMessage = ageDifferenceValidateMessage;
            viewModel.drugNutrientInteractionMessage = drugNutrientInteractionMessage;
            viewModel.doctorDescriptionOnDrug = doctorDescriptionOnDrug;
            viewModel.repeatDayWarning = repeatDayWarning;
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
                    kScheduleMaterialRowViewModel.IsCV = ownDrug.IsCV;

                    if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                    {
                        kScheduleMaterialRowViewModel.Status = StockActionDetailStatusEnum.Cancelled;
                    }
                    else if (ownDrug.StockActionStatus != null)
                    {
                        kScheduleMaterialRowViewModel.Status = (StockActionDetailStatusEnum)ownDrug.StockActionStatus;
                    }
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

                    if (!allDrugDefinitionObjectIDs.Contains(ownDrug.Material.ObjectID))
                        allDrugDefinitionObjectIDs.Add(ownDrug.Material.ObjectID);
                    if (ksmDrugDefinitionGridList.Count(x => x.ObjectID == ownDrug.Material.ObjectID) == 0)
                        ksmDrugDefinitionGridList.Add((DrugDefinition)ownDrug.Material);

                    if (TTObjectClasses.SystemParameter.GetParameterValue("HIMSSINTEGRATED", "FALSE") == "TRUE")
                    {
                        if (kScheduleMaterialRowViewModel.Status != StockActionDetailStatusEnum.Cancelled && kScheduleMaterialRowViewModel.Status != StockActionDetailStatusEnum.Deleted)
                            kScheduleMaterialRowViewModel.Status = StockActionDetailStatusEnum.New;
                        kScheduleMaterialRowViewModel.ReceivedAmount = kScheduleMaterialRowViewModel.RequestAmount;
                        kScheduleMaterialRowViewModel.BarcodeVerifyCounter = kScheduleMaterialRowViewModel.RequestAmount;
                    }


                    if (!string.IsNullOrEmpty(ownDrug.Material.Description))
                    {
                        if (ownDrug.Material.MaterialDescriptionShowType != null)
                        {
                            if (ownDrug.Material.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Kschedule || ownDrug.Material.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                drugDescriptionMessage += " Karþýladýðýnýz " + ownDrug.Material.Name + " ilacýn açýklamasý: " + ownDrug.Material.Description;
                        }
                        else
                            drugDescriptionMessage += " Karþýladýðýnýz " + ownDrug.Material.Name + " ilacýn açýklamasý: " + ownDrug.Material.Description;
                    }
                    break;
                }
            }

            //KSchedulePatienOwnDrugs ile doldurma
            foreach (KScheduleInfectionDrug infectionDrug in kSchedule.KScheduleInfectionDrugs)
            {
                if (infectionDrug.IsApproved == false)
                {
                    KScheduleMaterialRowViewModel kScheduleMaterialRowViewModel = new KScheduleMaterialRowViewModel();

                    kScheduleMaterialRowViewModel.RowObjectId = infectionDrug.ObjectID;
                    kScheduleMaterialRowViewModel.KScheduleMaterialRowType = KScheduleMaterialRowType.KScheduleInfection;
                    kScheduleMaterialRowViewModel.Material = infectionDrug.Material;
                    kScheduleMaterialRowViewModel.BarcodeVerifyCounter = infectionDrug.BarcodeVerifyCounter;
                    if (infectionDrug.StockActionStatus != null)
                        kScheduleMaterialRowViewModel.Status = (StockActionDetailStatusEnum)infectionDrug.StockActionStatus;
                    kScheduleMaterialRowViewModel.IsImmediate = false;

                    //kScheduleMaterialRowViewModel.DrugOrderStartDate = stateDrugOrderDetail.DrugOrder.PlannedStartTime.Value;
                    kScheduleMaterialRowViewModel.RequestAmount = infectionDrug.DrugAmount; // kScheduleMaterial  RequestAmount  KSchedulePatienOwnDrug için DrugAmount olmalý 
                                                                                            // Bunlar KSchedulePatienOwnDrug için mevcut deðil
                                                                                            // kScheduleMaterialRowViewModel.ReceivedAmount ;
                                                                                            // kScheduleMaterialRowViewModel.StoreInheld
                                                                                            //kScheduleMaterialRowViewModel.Description = 
                                                                                            //kScheduleMaterialRowViewModel.UsageNote = Common.GetDisplayTextOfEnumValue("DrugUsageTypeEnum", (int)stateDrugOrderDetail.DrugOrder.DrugUsageType);
                    kScheduleMaterialRowViewModel.ExpirationDate = infectionDrug.ExpirationDate;

                    //kScheduleMaterialRowViewModel.IsNarcotic = ((DrugDefinition)ownDrug.Material).IsNarcotic == null ? false : (bool)((DrugDefinition)ownDrug.Material).IsNarcotic;
                    //kScheduleMaterialRowViewModel.IsPsychotropic = ((DrugDefinition)ownDrug.Material).IsPsychotropic == null ? false : (bool)((DrugDefinition)ownDrug.Material).IsPsychotropic;

                    kScheduleMaterialRowViewModelList.Add(kScheduleMaterialRowViewModel);

                    if (!allDrugDefinitionObjectIDs.Contains(infectionDrug.Material.ObjectID))
                        allDrugDefinitionObjectIDs.Add(infectionDrug.Material.ObjectID);
                    if (ksmDrugDefinitionGridList.Count(x => x.ObjectID == infectionDrug.Material.ObjectID) == 0)
                        ksmDrugDefinitionGridList.Add((DrugDefinition)infectionDrug.Material);


                    if (!string.IsNullOrEmpty(infectionDrug.Material.Description))
                    {
                        if (infectionDrug.Material.MaterialDescriptionShowType != null)
                        {
                            if (infectionDrug.Material.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.Kschedule || infectionDrug.Material.MaterialDescriptionShowType == MaterialDescriptionShowTypeEnum.All)
                                drugDescriptionMessage += " Karþýladýðýnýz " + infectionDrug.Material.Name + " ilacýn açýklamasý: " + infectionDrug.Material.Description;
                        }
                        else
                            drugDescriptionMessage += " Karþýladýðýnýz " + infectionDrug.Material.Name + " ilacýn açýklamasý: " + infectionDrug.Material.Description;
                    }
                    break;

                    //if (stateDrugOrderDetail.DrugOrder.CurrentStateDefID == DrugOrder.States.Stopped)
                    //{
                    //    ownDrug.StockActionStatus = StockActionDetailStatusEnum.Cancelled;

                    //}

                }
            }

            viewModel.KScheduleMaterialRowViewModelList = kScheduleMaterialRowViewModelList.OrderBy(dr => dr.DrugOrderStartDate).ToArray();
            viewModel.drugDescriptionMessage = drugDescriptionMessage;

            // Form ClientPreScriptdeki kdolar buraya taþýndý
            KScheduleServiceController kScheduleServiceController = new KScheduleServiceController();

            KScheduleIsImmediatle_Input kScheduleIsImmediatle_Input = new KScheduleIsImmediatle_Input();
            kScheduleIsImmediatle_Input.KScheduleObjID = kSchedule.ObjectID;

            //let retMessage: string = await KScheduleService.IsImmadiatleControl(this._KSchedule.ObjectID);
            //if (retMessage !== "")
            //{
            //    TTVisual.InfoBox.Alert("ACÝL ÝLAÇLAR", retMessage + ' ilaçlar acil olarak iþaretlenmiþtir.', MessageIconEnum.WarningMessage);
            //}
            var retMessage = kScheduleServiceController.IsImmadiatleControl(kScheduleIsImmediatle_Input);
            if (!string.IsNullOrEmpty(retMessage))
                viewModel.retMessage = retMessage + " ilaçlar acil olarak iþaretlenmiþtir.";


            //    let alletMessage: string = await KScheduleService.StoppedDrugOrderCheck(this._KSchedule.ObjectID);
            //    if (alletMessage !== "")
            //    {
            //        TTVisual.InfoBox.Alert("DURDURULAN ÝLAÇLAR", alletMessage + ' ÝLAÇLAR DOKTOR TARAFINDAN DURDURULMUÞTUR.', MessageIconEnum.WarningMessage);
            //    }
            var alletMessage = kScheduleServiceController.StoppedDrugOrderCheck(kScheduleIsImmediatle_Input);
            if (!string.IsNullOrEmpty(alletMessage))
                viewModel.alletMessage = alletMessage + " ÝLAÇLAR DOKTOR TARAFINDAN DURDURULMUÞTUR.";





            //    let input = { 'KScheduleMaterials': this._KSchedule.KScheduleMaterials, 'episode': this._KSchedule.Episode, 'newMaterialObjectIDList': this._KSchedule.KScheduleMaterials.map(x => x.Material.ObjectID) };
            //this.httpService.post<string>('api/DrugOrderIntroductionService/ControlOfActiveIngredientPharmacy', input).then(message => {
            //    if (message != "")
            //    {
            //        this.showOverDosePopup = true;
            //        //TTVisual.InfoBox.Alert("UYARI !", message, MessageIconEnum.WarningMessage);
            //        this.overDoseMessage = message;
            //    }
            //});


            //<overDoseMessage set etemek içinn DrugOrderIntroductionService/ControlOfActiveIngredientPharmacy burada simule edildi
            ControlOfActiveIngredient_Input input = new ControlOfActiveIngredient_Input();
            input.materialModelList = new List<ControlOfActiveIngredientMaterialModel>();
            Dictionary<Guid, ActiveIngredientDefinition> ingredients = new Dictionary<Guid, ActiveIngredientDefinition>();

            foreach (var item in kSchedule.KSchedulePatienOwnDrugs)
            {
                ControlOfActiveIngredientMaterialModel materialModel = new ControlOfActiveIngredientMaterialModel();
                materialModel.ObjectID = item.Material.ObjectID;
                materialModel.Amount = item.DrugAmount.Value;
                materialModel.PlannedStartTime = kSchedule.StartDate.Value;
                input.materialModelList.Add(materialModel);
                DrugDefinition drugDefinition = (DrugDefinition)item.Material;
                foreach (DrugActiveIngredient drugActiveIngredient in drugDefinition.DrugActiveIngredients)
                {
                    if (ingredients.ContainsKey(drugActiveIngredient.ActiveIngredient.ObjectID) == false)
                        ingredients.Add(drugActiveIngredient.ActiveIngredient.ObjectID, drugActiveIngredient.ActiveIngredient);
                }
            }

            foreach (var item in kSchedule.KScheduleInfectionDrugs)
            {
                ControlOfActiveIngredientMaterialModel materialModel = new ControlOfActiveIngredientMaterialModel();
                materialModel.ObjectID = item.Material.ObjectID;
                materialModel.Amount = item.DrugAmount.Value;
                materialModel.PlannedStartTime = kSchedule.StartDate.Value;
                input.materialModelList.Add(materialModel);
                DrugDefinition drugDefinition = (DrugDefinition)item.Material;
                foreach (DrugActiveIngredient drugActiveIngredient in drugDefinition.DrugActiveIngredients)
                {
                    if (ingredients.ContainsKey(drugActiveIngredient.ActiveIngredient.ObjectID) == false)
                        ingredients.Add(drugActiveIngredient.ActiveIngredient.ObjectID, drugActiveIngredient.ActiveIngredient);
                }
            }

            foreach (var item in kSchedule.KScheduleMaterials)
            {
                ControlOfActiveIngredientMaterialModel materialModel = new ControlOfActiveIngredientMaterialModel();
                materialModel.ObjectID = item.Material.ObjectID;
                materialModel.Amount = item.Amount;
                materialModel.PlannedStartTime = kSchedule.StartDate.Value;
                input.materialModelList.Add(materialModel);
                DrugDefinition drugDefinition = (DrugDefinition)item.Material;
                foreach (DrugActiveIngredient drugActiveIngredient in drugDefinition.DrugActiveIngredients)
                {
                    if (ingredients.ContainsKey(drugActiveIngredient.ActiveIngredient.ObjectID) == false)
                        ingredients.Add(drugActiveIngredient.ActiveIngredient.ObjectID, drugActiveIngredient.ActiveIngredient);
                }
            }

            input.episode = kSchedule.Episode;
            DrugOrderRequirementServiceController drugOrderRequirementServiceController = new DrugOrderRequirementServiceController();

            //List<ControlOfActiveIngredientForRepeat_Output> controlOfActiveIngredient = ControlOfActiveIngredientPharmacy(input);

            viewModel.overDoseMessage = drugOrderRequirementServiceController.ControlOfActiveIngredientPharmacy(input); //messageActiveIngredientCorss.ToString();

            //overDoseMessage>


            // Etken Madde Doz aþýmý kontrolu için yapýlmýþtýr. SS

            //List<DoseControlOfKscheduleMaterial> totalDoseOfActiveIngKscheduleGridItems = TotalDoseOfKscheduleGridItems(input);


            #region Eski doz kontrolü
            //System.Text.StringBuilder ingredientMessage = new System.Text.StringBuilder();
            //string drugName = string.Empty;
            //foreach (KScheduleMaterial detail in kSchedule.KScheduleMaterials)
            //{
            //    DrugDefinition drugDefinition = (DrugDefinition)detail.Material;
            //    List<DrugActiveIngredient> parentIngredient = drugDefinition.DrugActiveIngredients.Where(t => t.IsParentIngredient == true).ToList();
            //    if (parentIngredient.Count > 0)
            //    {
            //        ActiveIngredientDefinition activeIngredient = parentIngredient[0].ActiveIngredient;
            //        string unit = string.Empty;
            //        if (activeIngredient.MaxDoseUnit != null)
            //            unit = activeIngredient.MaxDoseUnit.Name;

            //        if (activeIngredient.MaxDose != null && activeIngredient.MaxDose > 0)
            //        {
            //            double totalDose = (double)detail.Amount * (double)parentIngredient[0].Value;
            //            DateTime startDate = (DateTime)((KSchedule)detail.StockAction).StartDate;
            //            DateTime endDate = (DateTime)((KSchedule)detail.StockAction).EndDate;
            //            double totalDay = (endDate - startDate).TotalDays;
            //            if (totalDay > 1)
            //                totalDose = totalDose / totalDay;

            //            if (totalDose > activeIngredient.MaxDose)
            //            {
            //                ingredientMessage.AppendLine("<b></br>Order ile Maksimum Dozu Aþan Ýlaç</b></br>");
            //                ingredientMessage.AppendLine("(" + detail.Material.Name + ") " + activeIngredient.Name + " etken maddesinin bir günlük maksimum doz aþýldý. Maksimum Doz: " + activeIngredient.MaxDose.ToString() + " " + unit + " Verilen Doz: " + totalDose.ToString() + " " + unit);
            //            }
            //            else
            //            {
            //                BindingList<DrugActiveIngredient.GetAllDrugByParentActiveIng_Class> anotherDrug = DrugActiveIngredient.GetAllDrugByParentActiveIng(activeIngredient.ObjectID, drugDefinition.ObjectID);
            //                if (anotherDrug.Count > 0)
            //                {
            //                    Dictionary<Guid, double> anotherIngredients = new Dictionary<Guid, double>();
            //                    foreach (DrugActiveIngredient.GetAllDrugByParentActiveIng_Class d in anotherDrug)
            //                    {
            //                        anotherIngredients.Add((Guid)d.Drugdefinition, (double)d.Value);
            //                    }

            //                    /* foreach (KScheduleMaterial anotherDetail in kSchedule.KScheduleMaterials.Where(t => t.ObjectID != detail.ObjectID).ToList())
            //                     {
            //                         if (anotherIngredients.ContainsKey(anotherDetail.Material.ObjectID) == true)
            //                         {
            //                             totalDose = totalDose + ((double)anotherDetail.Amount * anotherIngredients[anotherDetail.Material.ObjectID]);
            //                             if (drugName == string.Empty)
            //                                 drugName = detail.Material.Name;
            //                             else
            //                                 drugName = drugName + ", " + detail.Material.Name;
            //                         }
            //                     }*/

            //                    IBindingList activeDrugOrder = objectContext.QueryObjects("DRUGORDER", "EPISODE = " + TTConnectionManager.ConnectionManager.GuidToString(kSchedule.Episode.ObjectID));
            //                    if (activeDrugOrder.Count > 0)
            //                    {
            //                        foreach (DrugOrder order in activeDrugOrder)
            //                        {
            //                            if (anotherIngredients.ContainsKey(order.Material.ObjectID) == true)
            //                            {
            //                                if (DrugOrder.GetContinueDrugOrder(kSchedule.Episode.ObjectID, order.Material.ObjectID, Common.RecTime()) == false)
            //                                {
            //                                    switch (order.Frequency)
            //                                    {
            //                                        case FrequencyEnum.Q24H:
            //                                            {
            //                                                totalDose = totalDose + ((double)order.DoseAmount * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q12H:
            //                                            {
            //                                                totalDose = totalDose + ((2 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q8H:
            //                                            {
            //                                                totalDose = totalDose + ((3 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q6H:
            //                                            {
            //                                                totalDose = totalDose + ((4 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q4H:
            //                                            {
            //                                                totalDose = totalDose + ((6 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q3H:
            //                                            {
            //                                                totalDose = totalDose + ((8 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q2H:
            //                                            {
            //                                                totalDose = totalDose + ((12 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        case FrequencyEnum.Q1H:
            //                                            {
            //                                                totalDose = totalDose + ((24 * (double)order.DoseAmount) * anotherIngredients[order.Material.ObjectID]);
            //                                                break;
            //                                            }

            //                                        default:
            //                                            {
            //                                                break;
            //                                            }
            //                                    }
            //                                    if (drugName == string.Empty)
            //                                        drugName = order.Material.Name;
            //                                    else
            //                                        drugName = drugName + ", " + order.Material.Name;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                if (totalDose > activeIngredient.MaxDose)
            //                {
            //                    ingredientMessage.AppendLine("<b></br>Diðer Order(lar) ile Maksimum Dozu Aþan Ýlaç</b></br>");
            //                    ingredientMessage.AppendLine(activeIngredient.Name + " etken maddesinin bir günlük maksimum doz aþýldý. Maksimum Doz: " + activeIngredient.MaxDose.ToString() + " " + unit + " Verilen Doz: " + totalDose.ToString() + " " + unit + " (" + drugName + ") ");
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
            viewModel.ingredientsOverDoseMessage = drugOrderRequirementServiceController.TotalDoseOfKscheduleGridItems(input); ;



            DateTime StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 00:00:00");
            DateTime EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59");
            BindingList<DrugOrder.GetStoppedDrugOrderByDate_Class> stoppedOrders = DrugOrder.GetStoppedDrugOrderByDate(StartDate, EndDate, kSchedule.Episode.ObjectID);
            Dictionary<Guid, ActiveIngredientDefinition> stopIngredients = new Dictionary<Guid, ActiveIngredientDefinition>();
            foreach (DrugOrder.GetStoppedDrugOrderByDate_Class stopOrder in stoppedOrders)
            {
                TTObjectContext readonlyContext = new TTObjectContext(true);
                DrugDefinition drugDefinition = readonlyContext.GetObject<DrugDefinition>(stopOrder.Material.Value);
                foreach (DrugActiveIngredient drugActiveIngredient in drugDefinition.DrugActiveIngredients)
                {
                    if (stopIngredients.ContainsKey(drugActiveIngredient.ActiveIngredient.ObjectID) == false)
                        stopIngredients.Add(drugActiveIngredient.ActiveIngredient.ObjectID, drugActiveIngredient.ActiveIngredient);
                }
            }


            foreach (KeyValuePair<Guid, ActiveIngredientDefinition> activeIngredientDefinition in ingredients)
            {
                if (stopIngredients.ContainsKey(activeIngredientDefinition.Key))
                    viewModel.stopSameIngredientMessage = viewModel.stopSameIngredientMessage + " " + activeIngredientDefinition.Value.Name + " isimli etken maddeli ilaç bugün içerisinde durdurulmuþtur.";
            }

            if (viewModel.stopSameIngredientMessage != null)
                viewModel.stopSameIngredientMessage = viewModel.stopSameIngredientMessage + " Bilginize.";


            //let url = '/api/DrugOrderIntroductionService/ControlOfDrugSpecificationPharmacy';

            //let drugObjectIDs: Array<Guid> = new Array<Guid>();

            //if (this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs != null && this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs.length > 0) 
            //    drugObjectIDs =drugObjectIDs.concat(this.kScheduleApprovalFormViewModel._KSchedule.KSchedulePatienOwnDrugs.map(x => x.Material.ObjectID));

            //if (this._KSchedule.KScheduleMaterials != null && this._KSchedule.KScheduleMaterials.length > 0) 
            //    drugObjectIDs=  drugObjectIDs.concat(this._KSchedule.KScheduleMaterials.map(x => x.Material.ObjectID));

            //if (drugObjectIDs.length > 0) {
            //    let drugSpecificationControlInputDVO = { 'drugObjectIDs': drugObjectIDs, 'patientObjectID': this._KSchedule.Episode.Patient.ObjectID };
            //    this.httpService.post<string>(url, drugSpecificationControlInputDVO).then(message => {
            //    if (!String.isNullOrEmpty(message))
            //    {
            //        this.showDrugSpecPopup = true;
            //        this.drugSpecMessage = message;
            //    }
            //}).catch(error => {
            //        this.messageService.showError(error);
            //    });
            //}

            DrugOrderIntroductionServiceController drugOrderIntroductionService = new DrugOrderIntroductionServiceController();
            DrugSpecificationControlInputDVO drugSpecificationControlInputDVO = new DrugSpecificationControlInputDVO();
            drugSpecificationControlInputDVO.drugObjectIDs = allDrugDefinitionObjectIDs;
            drugSpecificationControlInputDVO.patientObjectID = kSchedule.Episode.Patient.ObjectID;
            viewModel.drugSpecMessage = drugOrderIntroductionService.ControlOfDrugSpecificationPharmacy(drugSpecificationControlInputDVO);

        }


        partial void PostScript_KScheduleApprovalForm(KScheduleApprovalFormViewModel viewModel, KSchedule kSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            foreach (KScheduleMaterialRowViewModel kScheduleMaterialRowViewModel in viewModel.KScheduleMaterialRowViewModelList)
            {
                if (kScheduleMaterialRowViewModel.KScheduleMaterialRowType == KScheduleMaterialRowType.KScheduleMaterial)
                {
                    var kScheduleMaterial = (KScheduleMaterial)objectContext.GetObject(kScheduleMaterialRowViewModel.RowObjectId, "KScheduleMaterial");

                    // deðiþme imkaný yok zaten
                    //kScheduleMaterial.Material = kScheduleMaterialRowViewModel.Material ;
                    //kScheduleMaterialRowViewModel.IsImmediate = kScheduleMaterial.IsImmediate;

                    //kScheduleMaterial da boþdu eskiden Prede set ediliyordu þimdi burda set ediliyor 
                    kScheduleMaterial.BarcodeVerifyCounter = kScheduleMaterialRowViewModel.BarcodeVerifyCounter;
                    kScheduleMaterial.DrugOrderStartDate = kScheduleMaterialRowViewModel.DrugOrderStartDate;
                    kScheduleMaterial.RequestAmount = kScheduleMaterialRowViewModel.RequestAmount; // kScheduleMaterial  RequestAmount  KSchedulePatienOwnDrug için DrugAmount olmalý 
                    kScheduleMaterial.StoreInheld = kScheduleMaterialRowViewModel.StoreInheld;
                    kScheduleMaterial.UsageNote = kScheduleMaterialRowViewModel.UsageNote;

                    // deðiþiyor 
                    kScheduleMaterial.Status = kScheduleMaterialRowViewModel.Status;
                    kScheduleMaterialRowViewModel.Description = kScheduleMaterial.Description;
                    kScheduleMaterial.Amount = kScheduleMaterialRowViewModel.ReceivedAmount;
                    kScheduleMaterial.PrescriptionNO = kScheduleMaterialRowViewModel.PrescriptionNo;

                }
                else if (kScheduleMaterialRowViewModel.KScheduleMaterialRowType == KScheduleMaterialRowType.KSchedulePatienOwnDrug)
                {
                    var kSchedulePatienOwnDrug = (KSchedulePatienOwnDrug)objectContext.GetObject(kScheduleMaterialRowViewModel.RowObjectId, "KSchedulePatienOwnDrug");
                    kSchedulePatienOwnDrug.StockActionStatus = kScheduleMaterialRowViewModel.Status;
                }
            }



            foreach (KScheduleMaterial detail in kSchedule.StockActionDetails)
            {
                if (detail.UserSelectedOutableTrx != true)
                {
                    foreach (OuttableLot oldLot in detail.OuttableLots)
                    {
                        oldLot.isUse = false;
                    }

                    BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = null;
                    BindingList<StockTransaction.LOTOutableStockTransactionsBudgetType_Class> outableStockTransactionsByBudgetType = null;
                    Stock stock = kSchedule.Store.GetStock(detail.Material);
                    if (kSchedule.Store is PharmacySubStoreDefinition)
                    {
                        outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                    }
                    else
                    {
                        if (((MainStoreDefinition)(kSchedule.Store)).MKYS_ButceTuru != null)
                        {
                            Guid budgetGuid = Guid.Empty;

                            if (((MainStoreDefinition)kSchedule.Store).MKYS_ButceTuru != null)
                            {
                                List<BudgetTypeDefinition> budgetTypeDefList = objectContext.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(kSchedule.Store)).MKYS_ButceTuru.Value).Value).ToList();
                                if (budgetTypeDefList.Count == 1)
                                {
                                    budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                                }
                                else if (budgetTypeDefList.Count > 1)
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25075", "1 den fazla bütçe tipi tanýmlanmýþtýr. Bilgi iþleme haber veriniz.!"));
                                }
                                else
                                {
                                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27039", "Tanýmlý bütçe tipi bulunamamýþtýr. Bilgi iþleme haber veriniz.!"));
                                }
                            }


                            outableStockTransactionsByBudgetType = StockTransaction.LOTOutableStockTransactionsBudgetType(stock.ObjectID, budgetGuid);
                        }
                        else
                        {
                            outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                        }
                    }


                    if (outableStockTransactions != null)
                    {
                        foreach (StockTransaction.LOTOutableStockTransactions_Class lot in outableStockTransactions)
                        {
                            OuttableLot outtableLot = new OuttableLot(objectContext);
                            outtableLot.LotNo = lot.LotNo;
                            if (lot.ExpirationDate == null)
                                outtableLot.ExpirationDate = DateTime.MinValue;
                            else
                                outtableLot.ExpirationDate = lot.ExpirationDate;
                            outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                            outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                            outtableLot.isUse = true;
                            outtableLot.StockActionDetailOut = detail;
                        }
                    }
                    if (outableStockTransactionsByBudgetType != null)
                    {
                        foreach (StockTransaction.LOTOutableStockTransactionsBudgetType_Class lot in outableStockTransactionsByBudgetType)
                        {
                            OuttableLot outtableLot = new OuttableLot(objectContext);
                            outtableLot.LotNo = lot.LotNo;
                            if (lot.ExpirationDate == null)
                                outtableLot.ExpirationDate = DateTime.MinValue;
                            else
                                outtableLot.ExpirationDate = lot.ExpirationDate;
                            outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                            outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                            outtableLot.isUse = true;
                            outtableLot.StockActionDetailOut = detail;
                        }
                    }
                }
            }
        }
        partial void AfterContextSaveScript_KScheduleApprovalForm(KScheduleApprovalFormViewModel viewModel, KSchedule kSchedule, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null && transDef.ToStateDefID == KSchedule.States.RequestFulfilled)
            {
                List<StockActionDetail> deletedMaterials = kSchedule.StockActionDetails.Where(t => t.Status == StockActionDetailStatusEnum.Deleted).ToList();
                if (deletedMaterials.Count > 0)
                {
                    TTObjectContext context = new TTObjectContext(false);

                    KSchedule splitKSchedule = new KSchedule(context);
                    splitKSchedule.StartDate = kSchedule.StartDate;
                    splitKSchedule.EndDate = kSchedule.EndDate;
                    splitKSchedule.Store = kSchedule.Store;
                    splitKSchedule.DestinationStore = kSchedule.DestinationStore;
                    splitKSchedule.Episode = kSchedule.Episode;
                    splitKSchedule.DailyDrugSchedule = kSchedule.DailyDrugSchedule;
                    splitKSchedule.InPatientPhysicianApplication = kSchedule.InPatientPhysicianApplication;
                    splitKSchedule.MKYS_TeslimAlanObjID = kSchedule.MKYS_TeslimAlanObjID;
                    splitKSchedule.MKYS_TeslimAlan = kSchedule.MKYS_TeslimAlan;

                    foreach (KScheduleMaterial order in deletedMaterials)
                    {
                        KScheduleMaterial ksmaterial = new KScheduleMaterial(context);
                        ksmaterial.RequestAmount = order.RequestAmount;
                        ksmaterial.Amount = order.RequestAmount;
                        ksmaterial.Material = order.Material;
                        ksmaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                        splitKSchedule.KScheduleMaterials.Add(ksmaterial);
                        List<DrugOrderDetail> changeDrugOrderDetail = new List<DrugOrderDetail>();
                        foreach (DrugOrderDetail d in order.KScheduleCollectedOrder.DrugOrderDetails)
                        {
                            if (changeDrugOrderDetail.Contains(d) == false)
                                changeDrugOrderDetail.Add(d);
                        }

                        KScheduleCollectedOrder kScheduleCollectedOrder = new KScheduleCollectedOrder(context);
                        foreach (DrugOrderDetail detail in changeDrugOrderDetail)
                        {
                            DrugOrderDetail updateDetail = (DrugOrderDetail)context.GetObject(detail.ObjectID, typeof(DrugOrderDetail));
                            updateDetail.KScheduleCollectedOrder = null;
                            kScheduleCollectedOrder.DrugOrderDetails.Add(updateDetail);
                        }
                        ksmaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                    }
                    splitKSchedule.CurrentStateDefID = KSchedule.States.New;
                    splitKSchedule.Update();
                    splitKSchedule.CurrentStateDefID = KSchedule.States.Approval;
                    splitKSchedule.Update();
                    splitKSchedule.CurrentStateDefID = KSchedule.States.RequestPreparation;

                    context.Save();
                }

                foreach (KScheduleMaterial mat in kSchedule.StockActionDetails)
                {
                    //TODO Bakýlmasý gerekiyor, iptal edilen orderlar istek karþýlamadan karþýlanýrken hata alýyor.
                    if (mat.KScheduleCollectedOrder.DrugOrderDetails != null && mat.KScheduleCollectedOrder.DrugOrderDetails.Count > 0)
                    {
                        DrugOrder order = mat.KScheduleCollectedOrder.DrugOrderDetails[0].DrugOrder;
                        if (order.Material != mat.Material)
                        {
                            TTObjectContext drugOrderContext = new TTObjectContext(false);
                            DrugOrder changeDrugOrder = (DrugOrder)drugOrderContext.GetObject(order.ObjectID, typeof(DrugOrder));
                            changeDrugOrder.Material = mat.Material;
                            IBindingList drugOrderIntroductionDetails = drugOrderContext.QueryObjects("DRUGORDERINTRODUCTIONDET", "DRUGORDER=" + TTConnectionManager.ConnectionManager.GuidToString(changeDrugOrder.ObjectID));
                            if (drugOrderIntroductionDetails.Count > 0)
                            {
                                DrugOrderIntroductionDet drugOrderIntroductionDet = (DrugOrderIntroductionDet)drugOrderContext.GetObject(((DrugOrderIntroductionDet)drugOrderIntroductionDetails[0]).ObjectID, typeof(DrugOrderIntroductionDet));
                                drugOrderIntroductionDet.Material = mat.Material;
                            }
                            foreach (DrugOrderDetail detail in mat.KScheduleCollectedOrder.DrugOrderDetails)
                            {
                                DrugOrderDetail changeDrugOrderDetail = (DrugOrderDetail)drugOrderContext.GetObject(detail.ObjectID, typeof(DrugOrderDetail));
                                changeDrugOrderDetail.Material = mat.Material;
                            }
                            drugOrderContext.Save();
                            //drugOrderContext.Dispose();
                        }
                    }
                }
            }
        }

        partial void PreMatch_KScheduleApprovalForm(KScheduleApprovalFormViewModel viewModel, Guid objectID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                KSchedule schedule = objectContext.GetObject<KSchedule>(objectID);
                if (viewModel.StockActionOutDetailsGridList.Count() < schedule.StockActionDetails.Count())
                    throw new Exception("Doktor tarafýndan yeni order edilmiþ ilaçlar bulunmaktadýr. Lütfen iþlemi kapatýp bir daha açýnýz!");

                foreach (KScheduleMaterial sourceMaterial in viewModel.StockActionOutDetailsGridList)
                {
                    KScheduleMaterial targetMaterial = (KScheduleMaterial)schedule.StockActionDetails.Where(x => x.ObjectID == sourceMaterial.ObjectID).FirstOrDefault();
                    if (targetMaterial.Status == StockActionDetailStatusEnum.Cancelled)
                    {
                        if (sourceMaterial.Status != targetMaterial.Status)
                            throw new Exception("Order içinde iptal edilmiþ veya durdurulmuþ ilaçlar bulunmaktadýr. Lütfen iþlemi kapatýp bir daha açýnýz!");
                    }
                    if (targetMaterial.IsImmediate != sourceMaterial.IsImmediate)
                        throw new Exception("Order içinde bazý ilaçlar Acil olarak güncellenmiþtir. Lütfen iþlemi kapatýp bir daha açýnýz!");
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class KScheduleApprovalFormViewModel
    {
        public KScheduleMaterialRowViewModel[] KScheduleMaterialRowViewModelList { get; set; }

        public string retMessage { get; set; }
        public string alletMessage { get; set; }
        public string overDoseMessage { get; set; }
        public string drugSpecMessage { get; set; }
        public string ageDifferenceValidateMessage { get; set; }
        public string drugNutrientInteractionMessage { get; set; }
        public string doctorDescriptionOnDrug { get; set; }
        public string ingredientsOverDoseMessage { get; set; }
        public string stopSameIngredientMessage { get; set; }
        public string drugDescriptionMessage { get; set; }
        public string repeatDayWarning { get; set; }
        public PatientLastUseDrugDVO[] patientLastUseDrugs { get; set; }
        public OuttableLotDTO[] OuttableLotList { get; set; }
    }

    public class PatientLastUseDrugDVO
    {
        public string DrugName { get; set; }
        public double Amount { get; set; }
    }
}