//$A64F5AEF
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text;
using Newtonsoft.Json;
using TTUtils;
using TTStorageManager.Security;
using System.Web.Script.Serialization;
using RenkliEncryption;
using Core.Security;
using System.Diagnostics;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugOrderRequirementServiceController : Controller
    {
        [HttpPost]
        public DrugOrderRequirement_Output DrugOrderRequirement(ControlOfActiveIngredient_Input input)
        {
            DrugOrderRequirement_Output output = new DrugOrderRequirement_Output();
            output.OverDoseMessage = TotalDoseOfKscheduleGridItems(input);
            output.ActiveIngredientMessage = ControlOfActiveIngredientPharmacy(input);
            return output;
        }
        public string TotalDoseOfKscheduleGridItems(ControlOfActiveIngredient_Input input)
        {
            //List<KScheduleMaterial> kScheduleMaterials = kSchedule.KScheduleMaterials.ToList();
            List<DoseControlOfKscheduleMaterial> doseControlOfKscheduleMaterialList = new List<DoseControlOfKscheduleMaterial>();
            List<Guid> totalDoseAddedMaterial = new List<Guid>();
            //İkinci kez doz aşımına eklenmemesi için hesaba dahil edilmiş aynı etken maddeli drugorder ları tutar. 
            Dictionary<Guid, List<Guid>> comparedActiveDrugOrderAndIngredient = new Dictionary<Guid, List<Guid>>();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                //Listede bulunan ilaçlarda dönüp kendisi hariç diğer ilaçların dozu ile toplar. 
                //Eğer daha önce hesaplanmış aynı etken maddeli bir drugorder var ise
                //toplanmış bir doz varsa onu eklemez.
                foreach (ControlOfActiveIngredientMaterialModel materialModel in input.materialModelList)
                {
                    DoseControlOfKscheduleMaterial doseControlOfKscheduleMaterial1 = new DoseControlOfKscheduleMaterial();

                    DrugDefinition drugDefinitionGrid = objectContext.GetObject<DrugDefinition>(materialModel.ObjectID);
                    List<DrugActiveIngredient> parentIngredient1 = drugDefinitionGrid.DrugActiveIngredients.Where(t => t.IsParentIngredient == true).ToList();

                    if (parentIngredient1.Count > 0)
                    {
                        ActiveIngredientDefinition activeIngredient1 = parentIngredient1[0].ActiveIngredient;

                        /*if (activeIngredient1.MaxDose.HasValue)
                        {
                            doseControlOfKscheduleMaterial1.ErrorMessage.Append(drugDefinitionGrid.Name + " ilacının " + activeIngredient1.Name + " isimli etken maddesinin maksimum dozu tanımlı değildir! Etken madde doz aşımı uyarısı almak için tanımları yapınız.</br>");
                            doseControlOfKscheduleMaterialList.Add(doseControlOfKscheduleMaterial1);
                        }*/
                        if (activeIngredient1.MaxDose.HasValue)
                        {
                            double totalDose1 = (double)materialModel.Amount * (double)parentIngredient1[0].Value;
                            DateTime startDate1 = materialModel.PlannedStartTime;
                            DateTime endDate1 = materialModel.PlannedEndTime;
                            double totalDay1 = (endDate1 - startDate1).TotalDays;
                            if (totalDay1 > 1)
                                totalDose1 = totalDose1 / totalDay1;

                            doseControlOfKscheduleMaterial1.ComparedMaterialObjectID = materialModel.ObjectID;
                            doseControlOfKscheduleMaterial1.MaxDoseValueOfIngredient = activeIngredient1.MaxDose.Value;
                            if (activeIngredient1.MaxDoseUnit != null)
                                doseControlOfKscheduleMaterial1.MaxDoseUnit = activeIngredient1.MaxDoseUnit.Name;
                            doseControlOfKscheduleMaterial1.ParentIngredientObjectID = activeIngredient1.ObjectID;
                            doseControlOfKscheduleMaterial1.ParentIngredientName = activeIngredient1.Name;
                            doseControlOfKscheduleMaterial1.DoseOfMaterial = totalDose1;

                            if (doseControlOfKscheduleMaterialList.Count(x => x.ParentIngredientObjectID == activeIngredient1.ObjectID) == 0)//&& totalDose1 > activeIngredient1.MaxDose.Value)
                            {
                                if (!totalDoseAddedMaterial.Contains(materialModel.ObjectID))
                                    doseControlOfKscheduleMaterial1.TotalDoseOfGridItems += totalDose1;
                                doseControlOfKscheduleMaterialList.Add(doseControlOfKscheduleMaterial1);
                                totalDoseAddedMaterial.Add(materialModel.ObjectID);
                            }
                            else
                            {
                                DoseControlOfKscheduleMaterial doseControl = doseControlOfKscheduleMaterialList.FirstOrDefault(x => x.ParentIngredientObjectID == activeIngredient1.ObjectID);
                                doseControl.TotalDoseOfGridItems += totalDose1;
                                doseControl.ComparedMaterialList.Add(doseControlOfKscheduleMaterial1);
                            }

                            DateTime StartDate = Convert.ToDateTime(materialModel.PlannedStartTime.ToShortDateString() + " 00:00:00");
                            DateTime EndDate = Convert.ToDateTime(materialModel.PlannedStartTime.ToShortDateString() + " 23:59:59");
                            //Gün içerisinde verilen orderlar.
                            List<DrugOrderDetail.GetActiveDrugOrdersByEpisode_Class> activeDrugOrder = DrugOrderDetail.GetActiveDrugOrdersByEpisode(input.episode.ObjectID, StartDate, EndDate).ToList();
                            //List<DrugOrderDetail> drugOrderDetails = kSchedule.KScheduleMaterials.SelectMany(x => x.KScheduleCollectedOrder.DrugOrderDetails).ToList();
                            //List<Guid> drugOrderObjectIDList = drugOrderDetails.Select(item => item.DrugOrder.ObjectID).ToList();
                            string gridDrugObjectIDs = Common.CreateFilterExpressionOfGuidList("", "MATERIAL", input.materialModelList.Select(x => x.ObjectID).ToList());
                            List<Guid> drugOrderObjectIDList = objectContext.QueryObjects<DrugOrder>(gridDrugObjectIDs + " AND PLANNEDSTARTTIME BETWEEN TODATE('" + StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND TODATE('" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "')").Select(x => x.ObjectID).ToList();
                            activeDrugOrder = activeDrugOrder.Where(x => drugOrderObjectIDList.Contains(x.Drugorderobjectid.Value) == false).ToList();
                            if (activeDrugOrder.Count > 0)
                            {
                                foreach (DrugOrderDetail.GetActiveDrugOrdersByEpisode_Class order in activeDrugOrder)
                                {
                                    List<Guid> comparedDrugOrderObjectIDList = new List<Guid>();

                                    DrugDefinition drugDef1 = (DrugDefinition)objectContext.GetObject<Material>(order.Material.Value);
                                    if (drugDef1.DrugActiveIngredients.Count(x => x.IsParentIngredient == true) > 0)
                                    {
                                        ActiveIngredientDefinition orderMaterialActiveIng = drugDef1.DrugActiveIngredients.FirstOrDefault(x => x.IsParentIngredient == true).ActiveIngredient;

                                        DrugActiveIngredient orderDrugActiveIngredient = drugDef1.DrugActiveIngredients.FirstOrDefault(x => x.IsParentIngredient == true);

                                        DoseControlOfKscheduleMaterial doseControlOfKscheduleMaterial = new DoseControlOfKscheduleMaterial();

                                        if (!orderMaterialActiveIng.MaxDose.HasValue)
                                        {
                                            doseControlOfKscheduleMaterial.ErrorMessage.Append(drugDef1.Name + " ilacının " + orderMaterialActiveIng.Name + " isimli etken maddesinin maksimum dozu tanımlı değildir! Etken madde doz aşımı uyarısı almak için tanımları yapınız.</br>");
                                        }
                                        else if (orderMaterialActiveIng.ObjectID == activeIngredient1.ObjectID)
                                        {
                                            List<DrugOrderDetail> drugOrderDetails = objectContext.QueryObjects<DrugOrderDetail>(" MATERIAL = '" + order.Material + "' AND OrderPlannedDate BETWEEN TODATE('" + StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND TODATE('" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND CURRENTSTATEDEFID NOT IN ('" +DrugOrderDetail.States.Stop + "')").ToList();
                                            //drugOrderDetails = drugOrderDetails.Where(x => x.OrderPlannedDate >= StartDate && x.OrderPlannedDate <= EndDate).ToList();
                                            double totalDoseActiveDrugOrder = CalculateOrderDose(drugOrderDetails.Sum(x => x.DoseAmount), orderDrugActiveIngredient, order.Frequency.Value);
                                            doseControlOfKscheduleMaterial.ComparedMaterialObjectID = order.Material.Value;
                                            doseControlOfKscheduleMaterial.MaterialName = drugDef1.Name;
                                            doseControlOfKscheduleMaterial.MaxDoseValueOfIngredient = orderMaterialActiveIng.MaxDose.Value;
                                            if (orderDrugActiveIngredient.MaxDoseUnit != null)
                                                doseControlOfKscheduleMaterial.MaxDoseUnit = orderDrugActiveIngredient.MaxDoseUnit.Name;
                                            doseControlOfKscheduleMaterial.ParentIngredientObjectID = orderMaterialActiveIng.ObjectID;
                                            doseControlOfKscheduleMaterial.ParentIngredientName = orderMaterialActiveIng.Name;
                                            doseControlOfKscheduleMaterial.DoseOfMaterial = totalDoseActiveDrugOrder;
                                            doseControlOfKscheduleMaterial.IsOrderMaterial = true;
                                            DoseControlOfKscheduleMaterial doseControl = doseControlOfKscheduleMaterialList.FirstOrDefault(x => x.ParentIngredientObjectID == activeIngredient1.ObjectID);
                                            //Eğer bu drugorder'ın ilacının etken maddesi daha önce hiç hesaba dahil edilmemiş ise 
                                            if (comparedActiveDrugOrderAndIngredient.ContainsKey(activeIngredient1.ObjectID) == false)
                                            {
                                                doseControl.TotalDoseOfGridItems += totalDoseActiveDrugOrder;
                                                doseControl.ComparedMaterialList.Add(doseControlOfKscheduleMaterial);
                                                comparedDrugOrderObjectIDList.Add(order.Drugorderobjectid.Value);
                                                comparedActiveDrugOrderAndIngredient.Add(activeIngredient1.ObjectID, comparedDrugOrderObjectIDList);
                                            }
                                            else
                                            {
                                                //Etken madde daha önce bir hesaba dahil edilmiş fakat drugorder'ı farklı ise toplam doza ekler.
                                                //Yani aynı etken maddeye sahip farklı bir drugorder ilacını toplam doza ekler.
                                                if (comparedActiveDrugOrderAndIngredient[activeIngredient1.ObjectID].Contains(order.Drugorderobjectid.Value) == false)
                                                {
                                                    doseControl.TotalDoseOfGridItems += totalDoseActiveDrugOrder;
                                                    doseControl.ComparedMaterialList.Add(doseControlOfKscheduleMaterial);
                                                    comparedActiveDrugOrderAndIngredient[activeIngredient1.ObjectID].Add(order.Drugorderobjectid.Value);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                StringBuilder overDoseMaterials = new StringBuilder();
                List<Guid> warnedIngredientList = new List<Guid>();
                List<Guid> warnedDrugObjectIDList = new List<Guid>();
                foreach (DoseControlOfKscheduleMaterial doseControlItem in doseControlOfKscheduleMaterialList)
                {
                    DrugDefinition drugDefinition = objectContext.GetObject<DrugDefinition>(doseControlItem.ComparedMaterialObjectID);//(DrugDefinition)KScheduleMaterials.Select(x => x.Material).FirstOrDefault(x => x.ObjectID == doseControlItem.ComparedMaterialObjectID);

                    if (doseControlItem != null && doseControlItem.MaxDoseValueOfIngredient != null && doseControlItem.MaxDoseValueOfIngredient > 0)
                    {
                        //İlaç tek başına doz aşımı yaratıyorsa direkt olarak mesaj oluştur. (ComparedMaterialList) aynı etken maddeye sahip başka ilaç yok ise.
                        if (doseControlItem.ComparedMaterialList.Count == 0 && doseControlItem.DoseOfMaterial > doseControlItem.MaxDoseValueOfIngredient)
                        {
                            overDoseMaterials.Append("<b>-" + doseControlItem.ParentIngredientName + "-</b></br>");
                            overDoseMaterials.AppendLine("<b>Maksimum Doz :</b> " + doseControlItem.MaxDoseValueOfIngredient + " " + doseControlItem.MaxDoseUnit + "</br>");
                            overDoseMaterials.AppendLine("<b>Gün İçerisindeki Toplam Doz :</b> " + (doseControlItem.TotalDoseOfGridItems) + " " + doseControlItem.MaxDoseUnit + "</br>");
                            overDoseMaterials.AppendLine("<b>İlaç Adı : </b>" + drugDefinition.Name + "</br>");

                            //Bu etken madde daha önce mesaj olarak yazıldıysa aşağıda diğer etken maddeler ile toplarken mesajın tekrar etmemesi için kontrol edilecek liste.
                            warnedIngredientList.Add(doseControlItem.ParentIngredientObjectID);
                            warnedDrugObjectIDList.Add(doseControlItem.ComparedMaterialObjectID);
                        }
                        //Aynı etken maddeye sahip gruplanmış diğer ilaçlar. (İlk ilacın (doseControlItem) altında bulunan aynı etken maddeli ilaçlar.)
                        foreach (DoseControlOfKscheduleMaterial innerDoseControlItem in doseControlItem.ComparedMaterialList)
                        {
                            DrugDefinition innerDrugDefinition = objectContext.GetObject<DrugDefinition>(innerDoseControlItem.ComparedMaterialObjectID);
                            // (DrugDefinition)kSchedule.KScheduleMaterials.Select(x => x.Material).FirstOrDefault(x => x.ObjectID == innerDoseControlItem.ComparedMaterialObjectID);
                            //Eğer ilk ilacın dozu (DoseOfMaterial) ya da aynı etken maddeye sahip malzeme ya da bu malzemerlin toplam dozu (TotalDoseOfGridItems) 
                            //doz aşımı yaratıyor ise mesajı oluştur.
                            if (doseControlItem.DoseOfMaterial > doseControlItem.MaxDoseValueOfIngredient || innerDoseControlItem.DoseOfMaterial > doseControlItem.MaxDoseValueOfIngredient || doseControlItem.TotalDoseOfGridItems > doseControlItem.MaxDoseValueOfIngredient)
                            {
                                //İlacın etken madde doz aşımı uyarısı yukarıda ki koşulda oluşturulmamış ise mesaj başlğını oluştur.
                                if (warnedIngredientList.Count == 0)
                                {
                                    overDoseMaterials.AppendLine("<b></br>Maksimum Dozu Aşan Etken Maddeler</b></br>");
                                }
                                //Eğer bu etken madde doz aşımı uyarısı daha önce mesaja eklenmemiş ise ekle.
                                if (!warnedIngredientList.Contains(doseControlItem.ParentIngredientObjectID))
                                {
                                    overDoseMaterials.Append("<b>-" + doseControlItem.ParentIngredientName + "-</b></br>");
                                    overDoseMaterials.AppendLine("<b>Maksimum Doz :</b> " + doseControlItem.MaxDoseValueOfIngredient + " " + doseControlItem.MaxDoseUnit + "</br>");
                                    overDoseMaterials.AppendLine("<b>Gün İçerisindeki Toplam Doz :</b> " + (doseControlItem.TotalDoseOfOrders + doseControlItem.TotalDoseOfGridItems) + " " + doseControlItem.MaxDoseUnit + "</br>");
                                    overDoseMaterials.AppendLine("<b>İlaç Adı : </b>" + drugDefinition.Name + "</br>");
                                    warnedIngredientList.Add(doseControlItem.ParentIngredientObjectID);
                                    warnedDrugObjectIDList.Add(doseControlItem.ComparedMaterialObjectID);
                                }
                                if (innerDrugDefinition != null && !warnedDrugObjectIDList.Contains(innerDrugDefinition.ObjectID))
                                {
                                    overDoseMaterials.AppendLine("<b>İlaç Adı : </b>" + innerDrugDefinition.Name + "</br>");
                                    warnedDrugObjectIDList.Add(innerDrugDefinition.ObjectID);
                                }
                                //else
                                //    overDoseMaterials.AppendLine("<b>İlaç Adı : </b>" + innerDoseControlItem.MaterialName + "</br>");
                                if (innerDoseControlItem.ErrorMessage.Length > 0)
                                    overDoseMaterials.Append(innerDoseControlItem.ErrorMessage);
                            }
                        }
                        if (doseControlItem.ErrorMessage.Length > 0)
                            overDoseMaterials.Append(doseControlItem.ErrorMessage);
                    }
                }
                return overDoseMaterials.ToString();
            }
        }

        public string ControlOfActiveIngredientPharmacy(ControlOfActiveIngredient_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<ControlOfActiveIngredientForRepeat_Output> crossDrugList = new List<ControlOfActiveIngredientForRepeat_Output>();

                string drugObjectIDs = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.materialModelList.Select(x => x.ObjectID).ToList());
                //Griddeki ilaçlar
                List<DrugDefinition> selectedDrugDefinitions;
                if (!string.IsNullOrEmpty(drugObjectIDs))
                    selectedDrugDefinitions = objectContext.QueryObjects<DrugDefinition>(drugObjectIDs).ToList();
                else
                    throw new TTException("İlaç seçimi yapılmadı!"); //Bu hata client tan bir ilaç gelmediği zaman olur.

                //Gün içerisinde episode'a ait order listesi. Griddekiler hariç.
                List<DrugOrder> drugOrderList = DailyEpisodeDrugOrderList(objectContext, input.episode.ObjectID, input.materialModelList.FirstOrDefault().PlannedStartTime);
                drugOrderList = drugOrderList.Where(x => !selectedDrugDefinitions.Contains(x.Material)).ToList();

                List<CompareActiveIngredientClass> compareActiveIngredientList = new List<CompareActiveIngredientClass>();

                foreach (DrugOrder drugOrder in drugOrderList)
                {
                    List<ActiveIngredientDefinition> drugOrderMaterialActiveIngredientList = new List<ActiveIngredientDefinition>();
                    drugOrderMaterialActiveIngredientList.AddRange(((DrugDefinition)drugOrder.Material).DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient));

                    foreach (DrugDefinition drugDefinition in selectedDrugDefinitions)
                    {
                        var activeIngredientCross = drugOrderMaterialActiveIngredientList.Where(x => drugDefinition.DrugActiveIngredients.Select("").Select(y => y.ActiveIngredient).Contains(x));

                        if (activeIngredientCross.Count() > 0)
                        {
                            foreach (var item in activeIngredientCross)
                            {
                                if (compareActiveIngredientList.Count(x => x.ActiveIngredientObjectID != item.ObjectID) == 0)
                                {
                                    CompareActiveIngredientClass compareActiveIngredientClass = new CompareActiveIngredientClass();
                                    compareActiveIngredientClass.ActiveIngredientObjectID = item.ObjectID;
                                    compareActiveIngredientClass.ActiveIngredientName = item.Name;
                                    compareActiveIngredientClass.MaterialObjectIDList.Add(drugDefinition.ObjectID);
                                    compareActiveIngredientClass.MaterialNames.Add(drugDefinition.Name);
                                    compareActiveIngredientClass.MaterialObjectIDList.Add(drugOrder.Material.ObjectID);
                                    compareActiveIngredientClass.MaterialNames.Add(drugOrder.Material.Name);
                                    compareActiveIngredientList.Add(compareActiveIngredientClass);
                                }
                                else
                                {
                                    if (compareActiveIngredientList.SelectMany(x => x.MaterialObjectIDList).Contains(drugDefinition.ObjectID) == false)
                                    {
                                        compareActiveIngredientList.FirstOrDefault(x => x.ActiveIngredientObjectID == item.ObjectID).MaterialObjectIDList.Add(drugDefinition.ObjectID);
                                        compareActiveIngredientList.FirstOrDefault(x => x.ActiveIngredientObjectID == item.ObjectID).MaterialNames.Add(drugDefinition.Name);
                                    }
                                    if (compareActiveIngredientList.SelectMany(x => x.MaterialObjectIDList).Contains(drugOrder.Material.ObjectID) == false)
                                    {
                                        compareActiveIngredientList.FirstOrDefault(x => x.ActiveIngredientObjectID == item.ObjectID).MaterialObjectIDList.Add(drugOrder.Material.ObjectID);
                                        compareActiveIngredientList.FirstOrDefault(x => x.ActiveIngredientObjectID == item.ObjectID).MaterialNames.Add(drugOrder.Material.Name);
                                    }
                                }
                            }


                            ControlOfActiveIngredientForRepeat activeIngredientCrossForRepeat = new ControlOfActiveIngredientForRepeat();
                            activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugName = drugOrder.Material.Name;
                            activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugObjectID = drugOrder.Material.ObjectID;
                            activeIngredientCrossForRepeat.IsRequestedInDay = true;
                            List<ControlOfActiveIngredientForRepeat> crossDrugOutput = new List<ControlOfActiveIngredientForRepeat>();
                            crossDrugOutput.Add(activeIngredientCrossForRepeat);
                            ControlOfActiveIngredientForRepeat_Output output;
                            if (crossDrugList.Count > 0 && crossDrugList.Count(x => x.ComparedDrugDef.ObjectID == drugDefinition.ObjectID) > 0)
                                crossDrugList.FirstOrDefault(x => x.ComparedDrugDef.ObjectID == drugDefinition.ObjectID).CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                            else
                            {
                                output = new ControlOfActiveIngredientForRepeat_Output();
                                output.CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                                output.ComparedDrugDef = drugDefinition;
                                output.CrossActiveIngridientNames = string.Join(",", activeIngredientCross.Select(x => x.Name));
                                crossDrugList.Add(output);
                            }
                        }
                    }
                }

                if (input.materialModelList != null && input.materialModelList.Count >= 1)
                {
                    string filterExpression = string.Empty;
                    filterExpression = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", input.materialModelList.Select(x => x.ObjectID).ToList());
                    //Griddeki ilaçlar /Client side dan gelen)
                    List<DrugDefinition> drugDefinitionGridList = objectContext.QueryObjects<DrugDefinition>(filterExpression).ToList();

                    foreach (DrugDefinition drugDef1 in drugDefinitionGridList)
                    {
                        List<ActiveIngredientDefinition> drugActiveIngredient1 = new List<ActiveIngredientDefinition>();
                        drugActiveIngredient1.AddRange(drugDef1.DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient));

                        foreach (DrugDefinition drugDef2 in drugDefinitionGridList.Where(x => x.ObjectID != drugDef1.ObjectID))
                        {
                            List<ActiveIngredientDefinition> drugActiveIngredient2 = new List<ActiveIngredientDefinition>();
                            drugActiveIngredient2.AddRange(drugDef2.DrugActiveIngredients.Select("").Select(x => x.ActiveIngredient));

                            List<ActiveIngredientDefinition> activeIngredientCross = drugActiveIngredient2.Where(x => drugActiveIngredient1.Contains(x)).ToList();

                            if (activeIngredientCross.Count > 0)
                            {
                                string activeIngredients = string.Empty;
                                if (activeIngredientCross.Count > 1)
                                    activeIngredients = string.Join(",", activeIngredientCross.Select(x => x.Name));
                                else
                                    activeIngredients = activeIngredientCross.Select(x => x.Name).FirstOrDefault();

                                ControlOfActiveIngredientForRepeat activeIngredientCrossForRepeat = new ControlOfActiveIngredientForRepeat();
                                activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugName = drugDef2.Name;
                                activeIngredientCrossForRepeat.ActiveIngridientCrossedDrugObjectID = drugDef2.ObjectID;
                                List<ControlOfActiveIngredientForRepeat> crossDrugOutput = new List<ControlOfActiveIngredientForRepeat>();
                                crossDrugOutput.Add(activeIngredientCrossForRepeat);
                                ControlOfActiveIngredientForRepeat_Output output;

                                if (crossDrugList.Count > 0 && crossDrugList.Count(x => x.ComparedDrugDef.ObjectID == drugDef1.ObjectID) > 0)
                                    crossDrugList.FirstOrDefault(x => x.ComparedDrugDef.ObjectID == drugDef1.ObjectID).CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                                else if (crossDrugList.SelectMany(x => x.CrossedActiveIngridientDrugs).Count(y => y.ActiveIngridientCrossedDrugObjectID != drugDef1.ObjectID) == 0)
                                {
                                    output = new ControlOfActiveIngredientForRepeat_Output();
                                    output.CrossedActiveIngridientDrugs.Add(activeIngredientCrossForRepeat);
                                    output.ComparedDrugDef = drugDef1;
                                    output.CrossActiveIngridientNames = string.Join(",", activeIngredientCross.Select(x => x.Name));
                                    crossDrugList.Add(output);
                                }
                            }
                        }
                    }
                }
                StringBuilder messageActiveIngredientCorss = new StringBuilder();

                foreach (var activeDrugIngredient in crossDrugList)
                {
                    messageActiveIngredientCorss.Append("<b>" + activeDrugIngredient.CrossActiveIngridientNames + "</b> etken maddeye sahip ");
                    messageActiveIngredientCorss.Append(activeDrugIngredient.ComparedDrugDef.Name + " isimli ilaç");

                    int isRequestedInDayTrueCount = 0;
                    int isRequestedInDayFalseCount = 0;

                    foreach (var item in activeDrugIngredient.CrossedActiveIngridientDrugs.Where(x => x.IsRequestedInDay == true))
                    {
                        if (isRequestedInDayTrueCount == 0)
                        {
                            messageActiveIngredientCorss.Append(" bugün içerisinde istenmiş ");
                            isRequestedInDayTrueCount++;
                        }

                        messageActiveIngredientCorss.Append(item.ActiveIngridientCrossedDrugName + "</b>, ");
                    }
                    foreach (var item in activeDrugIngredient.CrossedActiveIngridientDrugs.Where(x => x.IsRequestedInDay == false))
                    {
                        if (isRequestedInDayFalseCount == 0)
                        {
                            messageActiveIngredientCorss.Append(" listede bulunan ");
                            isRequestedInDayFalseCount++;
                        }
                        messageActiveIngredientCorss.Append(item.ActiveIngridientCrossedDrugName + ", ");
                    }

                    messageActiveIngredientCorss.AppendLine(" isimli ilaç/ilaçlar ile aynı etken maddeye sahiptir. Bilginize.</br></br>");
                }
                return messageActiveIngredientCorss.ToString();
            }
        }


        public double CalculateOrderDose(double? doseAmount, DrugActiveIngredient drugActiveIngredient, FrequencyEnum orderFrequency)
        {
            double orderDose = 0;
            return orderDose = ((double)doseAmount * drugActiveIngredient.Value.Value);
            switch (orderFrequency)
            {
                case FrequencyEnum.Q24H:
                    {
                        orderDose = ((double)doseAmount * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q12H:
                    {
                        orderDose = ((2 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q8H:
                    {
                        orderDose = ((3 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q6H:
                    {
                        orderDose = ((4 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q4H:
                    {
                        orderDose = ((6 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q3H:
                    {
                        orderDose = ((8 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q2H:
                    {
                        orderDose = ((12 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                case FrequencyEnum.Q1H:
                    {
                        orderDose = ((24 * (double)doseAmount) * drugActiveIngredient.Value.Value);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            return orderDose;
        }

        //Doz aşımı uyarısı için.
        public List<DrugOrder> DailyEpisodeDrugOrderList(TTObjectContext objectContext, Guid episodeObjectID, DateTime plannedStartTime)
        {
            DateTime StartDate = Convert.ToDateTime(plannedStartTime.ToShortDateString() + " 00:00:00");
            DateTime EndDate = Convert.ToDateTime(plannedStartTime.ToShortDateString() + " 23:59:59");

            return DrugOrder.GetDrugOrderForPatient(objectContext, episodeObjectID.ToString()).Where(x => x.CreationDate > StartDate && x.CreationDate < EndDate && x.CurrentStateDefID != DrugOrder.States.Stopped && x.CurrentStateDefID != DrugOrder.States.Cancelled).ToList();
        }
    }

}

public class ControlOfActiveIngredientMaterialModel
{
    public double? Amount { get; set; }
    public Guid ObjectID { get; set; }
    public DateTime PlannedStartTime { get; set; }
    public DateTime PlannedEndTime { get; set; }
}

public class ControlOfActiveIngredient_Input
{
    //public List<KScheduleMaterial> KScheduleMaterials { get; set; }

    //public Guid drug
    //{
    //    get;
    //    set;
    //}
    public Episode episode
    {
        get;
        set;
    }
    //Eklenen malzemenin ObjectID si ve Amount'u
    public List<ControlOfActiveIngredientMaterialModel> materialModelList { get; set; }
}
public class DoseControlOfKscheduleMaterial
{
    public Guid ComparedMaterialObjectID { get; set; }
    public List<DoseControlOfKscheduleMaterial> ComparedMaterialList = new List<DoseControlOfKscheduleMaterial>();
    public string MaterialName { get; set; }
    public Guid ParentIngredientObjectID { get; set; }
    public string ParentIngredientName { get; set; }
    public double? MaxDoseValueOfIngredient { get; set; }
    public double? DoseOfMaterial { get; set; }
    public double TotalDoseOfGridItems = 0;
    public double TotalDoseOfOrders = 0;
    public bool IsOrderMaterial { get; set; }
    public string MaxDoseUnit { get; set; }
    public StringBuilder ErrorMessage = new StringBuilder();
}

public class CompareActiveIngredientClass
{
    public List<Guid> MaterialObjectIDList = new List<Guid>();
    public List<string> MaterialNames = new List<string>();
    public Guid ActiveIngredientObjectID { get; set; }
    public string ActiveIngredientName { get; set; }
}

public class ControlOfActiveIngredientForRepeat
{
    public string ActiveIngridientCrossedDrugName;
    public Guid ActiveIngridientCrossedDrugObjectID { get; set; }
    public string CrossedMaterialName { get; set; }
    public bool IsRequestedInDay { get; set; }
}

public class ControlOfActiveIngredientForRepeat_Output
{
    public DrugDefinition ComparedDrugDef;
    public string CrossActiveIngridientNames { get; set; }
    public List<ControlOfActiveIngredientForRepeat> CrossedActiveIngridientDrugs = new List<ControlOfActiveIngredientForRepeat>();
}

public class DrugOrderRequirement_Output
{
    public string OverDoseMessage { get; set; }
    public string ActiveIngredientMessage { get; set; }
}