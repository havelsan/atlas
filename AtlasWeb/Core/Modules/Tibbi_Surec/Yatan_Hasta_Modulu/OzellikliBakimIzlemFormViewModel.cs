//$2F3A726C
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ComTypes;

namespace Core.Controllers
{
    [HvlResult]
    public partial class OzellikliBakimIzlemFormServiceController
    {
        [HttpPost]
        public OzellikliBakimIzlemFormViewModel GetOzellikliIzlemFormViewModel(OzellikliBakimIzlemParameterModel input)
        {
            OzellikliBakimIzlemFormViewModel viewModel = new OzellikliBakimIzlemFormViewModel();
            var id = input.id;
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                viewModel.ProgressDate = Common.RecTime();
                viewModel.SKRSDurumList = SKRSDurum.GetSKRSDurum(objectContext, "WHERE AKTIF=1").ToList().Select(t => new DataModel() { Id = (Guid)t.ObjectID, Name = t.ADI }).ToList();
                viewModel.SKRSGenelDurumList = SKRSGenelDurum.GetSKRSGenelDurumList(objectContext, "WHERE AKTIF=1").ToList().Select(t => new DataModel() { Id = (Guid)t.ObjectID, Name = t.ADI }).ToList();
                viewModel.SKRSBtCekimDurumuList = SKRSBtCekimDurumu.GetSKRSBtCekimDurumuList(objectContext, "WHERE AKTIF=1").ToList().Select(t => new DataModel() { Id = (Guid)t.ObjectID, Name = t.ADI }).ToList();

                if (id.HasValue && id != Guid.Empty)
                {
                    OzellikliIzlemVeriSeti ozellikliIzlem = objectContext.GetObject<OzellikliIzlemVeriSeti>((Guid)id);
                    viewModel.ObjectID = ozellikliIzlem.ObjectID;
                    viewModel.InpatientPhysicianProgressesID = ozellikliIzlem.InPatientPhysicianProgresses.ObjectID;
                    if (ozellikliIzlem.IsIntensiveCare != null)
                    {
                        viewModel.IsIntensiveCare = ozellikliIzlem.IsIntensiveCare.ObjectID;
                    }

                    if (ozellikliIzlem.IsIsolatedInpatient != null)
                    {
                        viewModel.IsIsolatedInpatient = ozellikliIzlem.IsIsolatedInpatient.ObjectID;
                    }

                    if (ozellikliIzlem.NonCovidInpatient != null)
                    {
                        viewModel.NonCovidInpatient = ozellikliIzlem.NonCovidInpatient.ObjectID;
                    }

                    if (ozellikliIzlem.HasClinicalFinding != null)
                    {
                        viewModel.HasClinicalFinding = ozellikliIzlem.HasClinicalFinding.ObjectID;
                    }

                    if (ozellikliIzlem.HasCT != null)
                    {
                        viewModel.HasCT = ozellikliIzlem.HasCT.ObjectID;
                    }

                    if (ozellikliIzlem.CTResult != null)
                    {
                        viewModel.CTResult = ozellikliIzlem.CTResult.ObjectID;
                    }

                    if (ozellikliIzlem.HasPneumonia != null)
                    {
                        viewModel.HasPneumonia = ozellikliIzlem.HasPneumonia.ObjectID;
                    }

                    if (ozellikliIzlem.HasIntubation != null)
                    {
                        viewModel.HasIntubation = ozellikliIzlem.HasIntubation.ObjectID;
                    }

                    if (ozellikliIzlem.GeneralStatus != null)
                    {
                        viewModel.GeneralStatus = ozellikliIzlem.GeneralStatus.ObjectID;
                    }

                    if (ozellikliIzlem.HighDoseCvitamin != null)
                    {
                        viewModel.HighDoseCvitamin = ozellikliIzlem.HighDoseCvitamin.ObjectID;
                    }

                    if (ozellikliIzlem.Hydroxychloroquine != null)
                    {
                        viewModel.Hydroxychloroquine = ozellikliIzlem.Hydroxychloroquine.ObjectID;
                    }
                    if (ozellikliIzlem.Kaletra != null)
                    {
                        viewModel.Kaletra = ozellikliIzlem.Kaletra.ObjectID;
                    }
                    if (ozellikliIzlem.Oseltamivir != null)
                    {
                        viewModel.Oseltamivir = ozellikliIzlem.Oseltamivir.ObjectID;
                    }
                    if (ozellikliIzlem.Azitromisin != null)
                    {
                        viewModel.Azitromisin = ozellikliIzlem.Azitromisin.ObjectID;
                    }
                    if (ozellikliIzlem.FavipavirAvigan != null)
                    {
                        viewModel.FavipavirAvigan = ozellikliIzlem.FavipavirAvigan.ObjectID;
                    }

                    if (ozellikliIzlem.InPatientPhysicianProgresses != null)
                    {
                        viewModel.Description = ozellikliIzlem.InPatientPhysicianProgresses.Description;
                        viewModel.InpatientPhysicianProgressesID = ozellikliIzlem.InPatientPhysicianProgresses.ObjectID;
                    }

                    viewModel.PaoFioRatio = ozellikliIzlem.PaoFioRatio;

                    viewModel.ProgressDate = ozellikliIzlem.ProgressDate;
                    viewModel.InpatientPhysicianAppId = ozellikliIzlem.InPatientPhysicianProgresses.EntryEpisodeAction.ObjectID;
                }
                else if (input.physicianAppId.HasValue && input.physicianAppId != Guid.Empty)
                {
                    var physicianApplication = objectContext.GetObject<InPatientPhysicianApplication>((Guid)input.physicianAppId);
                    if (physicianApplication != null)
                    {

                        var SKRSDurumEvetGuid = viewModel.SKRSDurumList.Where(t => t.Name == "EVET").FirstOrDefault().Id;
                        var SKRSDurumHayirGuid = viewModel.SKRSDurumList.Where(t => t.Name == "HAYIR").FirstOrDefault().Id;

                        if (((ResClinic)physicianApplication.MasterResource).IsIntensiveCare == true)
                        {
                            viewModel.IsIntensiveCare = SKRSDurumEvetGuid;
                        }else
                        {
                            viewModel.IsIntensiveCare = SKRSDurumHayirGuid;
                        }

                        viewModel.IsIsolatedInpatient = SKRSDurumEvetGuid;
                        viewModel.HasClinicalFinding = SKRSDurumEvetGuid;
                        viewModel.NonCovidInpatient = SKRSDurumHayirGuid;

                        var hasCT = physicianApplication.SubEpisode.SubActionProcedures.Where(t => t is RadiologyTest && t.CurrentStateDefID == RadiologyTest.States.Completed && t.ProcedureObject.Code == "804070").FirstOrDefault();
                        
                        if (hasCT != null)
                        {
                            viewModel.HasCT = SKRSDurumEvetGuid;
                        }
                        else
                        {
                            viewModel.HasCT = SKRSDurumHayirGuid;
                        }
                        viewModel.HasIntubation = physicianApplication.VentilatorStatus != null ? physicianApplication.VentilatorStatus.ObjectID : SKRSDurumHayirGuid;

                        var drugOrderList = physicianApplication.Episode.DrugOrders.ToList();
                        viewModel.Hydroxychloroquine = SKRSDurumHayirGuid;
                        viewModel.FavipavirAvigan = SKRSDurumHayirGuid;
                        viewModel.Azitromisin = SKRSDurumHayirGuid;
                        viewModel.Kaletra = SKRSDurumHayirGuid;
                        viewModel.Oseltamivir = SKRSDurumHayirGuid;
                        viewModel.HighDoseCvitamin = SKRSDurumHayirGuid;

                        if (drugOrderList.Count > 0)
                        {
                            if (this.hasHydroxychloroquine(objectContext, Common.RecTime(), drugOrderList) == true)
                                viewModel.Hydroxychloroquine = SKRSDurumEvetGuid;
                            if (this.hasFavipiravir(objectContext, Common.RecTime(), drugOrderList) == true)
                                viewModel.FavipavirAvigan = SKRSDurumEvetGuid;
                            if (this.hasAzitromisin(objectContext, Common.RecTime(), drugOrderList) == true)
                                viewModel.Azitromisin = SKRSDurumEvetGuid;
                            if (this.hasKaletra(objectContext, Common.RecTime(), drugOrderList) == true)
                                viewModel.Kaletra = SKRSDurumEvetGuid;
                            if (this.hXXXXXXeltamivir(objectContext, Common.RecTime(), drugOrderList) == true)
                                viewModel.Oseltamivir = SKRSDurumEvetGuid;
                        }
                    }
                }



            }
            return viewModel;
        }

        public bool hasHydroxychloroquine(TTObjectContext objectContext, DateTime applyDate, List<DrugOrder> drugOrderList)
        {
            var gradientDef = ActiveIngredientDefinition.GetAllActiveIngredientDefinitions(objectContext, " WHERE NAME_SHADOW LIKE 'HIDROKSIKLOR%' ")
                                .ToList().Select(t => t.ObjectID).ToList();

            var hydroxycloroquineOrder = drugOrderList.Where(t => ((DrugDefinition)t.Material).DrugActiveIngredients.Where(x => gradientDef.Contains(x.ActiveIngredient.ObjectID)).ToList().Count > 0).ToList();
            if (hydroxycloroquineOrder.Count>0)
            {
                var detail = hydroxycloroquineOrder.Where(t => t.DrugOrderDetails.Where(x => x.OrderPlannedDate.HasValue && x.OrderPlannedDate.Value.Date == applyDate.Date && x.CurrentStateDefID == DrugOrderDetail.States.Apply).ToList().Count > 0).FirstOrDefault();
                if (detail != null)
                    return true;
            }
            return false;
        }

        public bool hXXXXXXeltamivir(TTObjectContext objectContext, DateTime applyDate, List<DrugOrder> drugOrderList)
        {
            var gradientDef = ActiveIngredientDefinition.GetAllActiveIngredientDefinitions(objectContext, " WHERE NAME_SHADOW LIKE '%OSELTAMIVIR%' ")
                                .ToList().Select(t => t.ObjectID).ToList();

            var oseltamivirOrder = drugOrderList.Where(t => ((DrugDefinition)t.Material).DrugActiveIngredients.Where(x => gradientDef.Contains(x.ActiveIngredient.ObjectID)).ToList().Count > 0);
            if (oseltamivirOrder != null)
            {
                var detail = oseltamivirOrder.Where(t => t.DrugOrderDetails.Where(x => x.OrderPlannedDate.HasValue && x.OrderPlannedDate.Value.Date == applyDate.Date && x.CurrentStateDefID == DrugOrderDetail.States.Apply).ToList().Count > 0).FirstOrDefault();
                if (detail != null)
                    return true;
            }
            return false;
        }

        public bool hasAzitromisin(TTObjectContext objectContext, DateTime applyDate, List<DrugOrder> drugOrderList)
        {
            var gradientDef = ActiveIngredientDefinition.GetAllActiveIngredientDefinitions(objectContext, " WHERE NAME_SHADOW LIKE '%AZITROMISIN%' ")
                                .ToList().Select(t => t.ObjectID).ToList();

            var azitromisineOrder = drugOrderList.Where(t => ((DrugDefinition)t.Material).DrugActiveIngredients.Where(x => gradientDef.Contains(x.ActiveIngredient.ObjectID)).ToList().Count > 0);
            if (azitromisineOrder != null)
            {
                var detail = azitromisineOrder.Where(t => t.DrugOrderDetails.Where(x => x.OrderPlannedDate.HasValue && x.OrderPlannedDate.Value.Date == applyDate.Date && x.CurrentStateDefID == DrugOrderDetail.States.Apply).ToList().Count > 0).FirstOrDefault();
                if (detail != null)
                    return true;
            }
            return false;
        }

        public bool hasFavipiravir(TTObjectContext objectContext, DateTime applyDate, List<DrugOrder> drugOrderList)
        {
            List<Guid> favipiravirDrugGuidList = new List<Guid>();

            var drugDet = DrugDefinition.GetDrugDefinition(objectContext, " WHERE NAME_SHADOW LIKE '%FAVIPIRA%'").ToList();
            if (drugDet.Count > 0)
            {
                foreach (var drug in drugDet)
                {
                    favipiravirDrugGuidList.Add(drug.ObjectID);
                    foreach (var eqDrug in drug.ManuelEquivalentDrugs)
                    {
                        if (!favipiravirDrugGuidList.Contains(eqDrug.ObjectID))
                            favipiravirDrugGuidList.Add(eqDrug.ObjectID);
                    }
                }
            }

            var favipiravirOrder = drugOrderList.Where(t => favipiravirDrugGuidList.Contains(t.Material.ObjectID));
            if (favipiravirOrder != null)
            {
                var detail = favipiravirOrder.Where(t => t.DrugOrderDetails.Where(x => x.OrderPlannedDate.HasValue && x.OrderPlannedDate.Value.Date == applyDate.Date && x.CurrentStateDefID == DrugOrderDetail.States.Apply).ToList().Count > 0).FirstOrDefault();
                if (detail != null)
                    return true;
            }
            return false;
        }

        public bool hasKaletra(TTObjectContext objectContext, DateTime applyDate, List<DrugOrder> drugOrderList)
        {
            List<Guid> kaletraDrugGuidList = new List<Guid>();

            var drugDet = DrugDefinition.GetDrugDefinition(objectContext, " WHERE NAME_SHADOW LIKE '%KALETRA%'").ToList();
            if (drugDet.Count > 0)
            {
                foreach (var drug in drugDet)
                {
                    kaletraDrugGuidList.Add(drug.ObjectID);
                    foreach (var eqDrug in drug.ManuelEquivalentDrugs)
                    {
                        if (!kaletraDrugGuidList.Contains(eqDrug.ObjectID))
                            kaletraDrugGuidList.Add(eqDrug.ObjectID);
                    }
                }
            }

            var kaletraOrder = drugOrderList.Where(t => kaletraDrugGuidList.Contains(t.Material.ObjectID));
            if (kaletraOrder != null)
            {
                var detail = kaletraOrder.Where(t => t.DrugOrderDetails.Where(x => x.OrderPlannedDate.HasValue && x.OrderPlannedDate.Value.Date == applyDate.Date && x.CurrentStateDefID == DrugOrderDetail.States.Apply).ToList().Count > 0).FirstOrDefault();
                if (detail != null)
                    return true;
            }
            return false;
        }
        [HttpPost]
        public OzellikliBakimIzlemFormViewModel SaveOzellikliIzlemFormViewModel(OzellikliBakimIzlemFormViewModel inputModel)
        {
            OzellikliBakimIzlemFormViewModel viewModel = new OzellikliBakimIzlemFormViewModel();

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                OzellikliIzlemVeriSeti ozellikliIzlem;
                if (inputModel.ObjectID != Guid.Empty)
                    ozellikliIzlem = objectContext.GetObject<OzellikliIzlemVeriSeti>(inputModel.ObjectID);
                else
                    ozellikliIzlem = new OzellikliIzlemVeriSeti(objectContext);
                viewModel.InpatientPhysicianAppId = inputModel.InpatientPhysicianAppId;
                var inpatientPhysicianApplication = objectContext.GetObject<InPatientPhysicianApplication>(inputModel.InpatientPhysicianAppId);

                if (inputModel.IsIntensiveCare != Guid.Empty)
                {
                    ozellikliIzlem.IsIntensiveCare = objectContext.GetObject<SKRSDurum>(inputModel.IsIntensiveCare);
                }

                if (inputModel.IsIsolatedInpatient != Guid.Empty)
                {
                    ozellikliIzlem.IsIsolatedInpatient = objectContext.GetObject<SKRSDurum>(inputModel.IsIsolatedInpatient);
                }

                if (inputModel.NonCovidInpatient != Guid.Empty)
                {
                    ozellikliIzlem.NonCovidInpatient = objectContext.GetObject<SKRSDurum>(inputModel.NonCovidInpatient);
                }

                if (inputModel.HasClinicalFinding != Guid.Empty)
                {
                    ozellikliIzlem.HasClinicalFinding = objectContext.GetObject<SKRSDurum>(inputModel.HasClinicalFinding);
                }

                if (inputModel.HasCT != Guid.Empty)
                {
                    ozellikliIzlem.HasCT = objectContext.GetObject<SKRSDurum>(inputModel.HasCT);
                }

                if (inputModel.CTResult != Guid.Empty)
                {
                    ozellikliIzlem.CTResult = objectContext.GetObject<SKRSBtCekimDurumu>(inputModel.CTResult);
                }

                if (inputModel.HasPneumonia != Guid.Empty)
                {
                    ozellikliIzlem.HasPneumonia = objectContext.GetObject<SKRSDurum>(inputModel.HasPneumonia);
                }

                if (inputModel.HasIntubation != Guid.Empty)
                {
                    ozellikliIzlem.HasIntubation = objectContext.GetObject<SKRSDurum>(inputModel.HasIntubation);
                }

                if (inputModel.HasPneumonia != Guid.Empty)
                {
                    ozellikliIzlem.HasPneumonia = objectContext.GetObject<SKRSDurum>(inputModel.HasPneumonia);
                }
                if (inputModel.GeneralStatus != Guid.Empty)
                {
                    ozellikliIzlem.GeneralStatus = objectContext.GetObject<SKRSGenelDurum>(inputModel.GeneralStatus);
                }
                if (inputModel.HighDoseCvitamin != Guid.Empty)
                {
                    ozellikliIzlem.HighDoseCvitamin = objectContext.GetObject<SKRSDurum>(inputModel.HighDoseCvitamin);
                }

                if (inputModel.Hydroxychloroquine != Guid.Empty)
                {
                    ozellikliIzlem.Hydroxychloroquine = objectContext.GetObject<SKRSDurum>(inputModel.Hydroxychloroquine);
                }

                if (inputModel.Kaletra != Guid.Empty)
                {
                    ozellikliIzlem.Kaletra = objectContext.GetObject<SKRSDurum>(inputModel.Kaletra);
                }
                if (inputModel.Oseltamivir != Guid.Empty)
                {
                    ozellikliIzlem.Oseltamivir = objectContext.GetObject<SKRSDurum>(inputModel.Oseltamivir);
                }
                if (inputModel.Azitromisin != Guid.Empty)
                {
                    ozellikliIzlem.Azitromisin = objectContext.GetObject<SKRSDurum>(inputModel.Azitromisin);
                }
                if (inputModel.FavipavirAvigan != Guid.Empty)
                {
                    ozellikliIzlem.FavipavirAvigan = objectContext.GetObject<SKRSDurum>(inputModel.FavipavirAvigan);
                }
                ozellikliIzlem.PaoFioRatio = Convert.ToInt32(inputModel.PaoFioRatio);
                ozellikliIzlem.ProgressDate = inputModel.ProgressDate;
                ozellikliIzlem.Description = inputModel.Description;
                ozellikliIzlem.ProgressUser = Common.CurrentResource;
                ozellikliIzlem.EpisodeAction = inpatientPhysicianApplication;
                ozellikliIzlem.SubEpisode = inpatientPhysicianApplication.SubEpisode;

                if (inputModel.InpatientPhysicianProgressesID == Guid.Empty)
                {
                    var inPatientPhysicianProgresses = new InPatientPhysicianProgresses(objectContext);
                    inPatientPhysicianProgresses.ProgressDate = inputModel.ProgressDate;
                    inPatientPhysicianProgresses.Description = inputModel.Description;
                    inPatientPhysicianProgresses.ProcedureDoctor = Common.CurrentResource;
                    inPatientPhysicianProgresses.EntryEpisodeAction = inpatientPhysicianApplication;
                    inPatientPhysicianProgresses.SubEpisode = inpatientPhysicianApplication.SubEpisode;
                    ozellikliIzlem.InPatientPhysicianProgresses = inPatientPhysicianProgresses;
                }
                else
                {
                    ozellikliIzlem.InPatientPhysicianProgresses.ProgressDate = inputModel.ProgressDate;
                    ozellikliIzlem.InPatientPhysicianProgresses.Description = inputModel.Description;
                }

                objectContext.Save();

                new SendToENabiz(objectContext, ozellikliIzlem.SubEpisode, ozellikliIzlem.ObjectID, ozellikliIzlem.ObjectDef.Name, "244", Common.RecTime());
                objectContext.Save();
                SendToENabiz s = new SendToENabiz();
                s.ENABIZSend244(ozellikliIzlem.ObjectID.ToString());

            }


            return viewModel;

        }

        [HttpPost]
        public ProgressMedicineValues GetProgressMedicineValues(ProgressMedicineParameter input)
        {
            ProgressMedicineValues viewModel = new ProgressMedicineValues();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var SKRSDurumList = SKRSDurum.GetSKRSDurum(objectContext, "WHERE AKTIF=1").ToList().Select(t => new DataModel() { Id = (Guid)t.ObjectID, Name = t.ADI }).ToList();
                var physicianApplication = objectContext.GetObject<InPatientPhysicianApplication>(input.physicianAppId);
                var SKRSDurumEvetGuid = SKRSDurumList.Where(t => t.Name == "EVET").FirstOrDefault().Id;
                var SKRSDurumHayirGuid = SKRSDurumList.Where(t => t.Name == "HAYIR").FirstOrDefault().Id;

                var drugOrderList = physicianApplication.Episode.DrugOrders.ToList();
                viewModel.Hydroxychloroquine = SKRSDurumHayirGuid;
                viewModel.FavipavirAvigan = SKRSDurumHayirGuid;
                viewModel.Azitromisin = SKRSDurumHayirGuid;
                viewModel.Kaletra = SKRSDurumHayirGuid;
                viewModel.Oseltamivir = SKRSDurumHayirGuid;
                viewModel.HighDoseCvitamin = SKRSDurumHayirGuid;
                if (drugOrderList.Count > 0)
                {
                    if (this.hasHydroxychloroquine(objectContext, input.progressDate, drugOrderList) == true)
                        viewModel.Hydroxychloroquine = SKRSDurumEvetGuid;
                    if (this.hasFavipiravir(objectContext, input.progressDate, drugOrderList) == true)
                        viewModel.FavipavirAvigan = SKRSDurumEvetGuid;
                    if (this.hasAzitromisin(objectContext, input.progressDate, drugOrderList) == true)
                        viewModel.Azitromisin = SKRSDurumEvetGuid;
                    if (this.hasKaletra(objectContext, input.progressDate, drugOrderList) == true)
                        viewModel.Kaletra = SKRSDurumEvetGuid;
                    if (this.hXXXXXXeltamivir(objectContext, input.progressDate, drugOrderList) == true)
                        viewModel.Oseltamivir = SKRSDurumEvetGuid;

                }
            }

            return viewModel;
        }
    }
}

namespace Core.Models
{
    public partial class OzellikliBakimIzlemFormViewModel : BaseViewModel
    {
        public Guid ObjectID { get; set; }
        public Guid InpatientPhysicianProgressesID { get; set; }
        public Guid InpatientPhysicianAppId { get; set; }
        public List<DataModel> SKRSDurumList { get; set; }
        public List<DataModel> SKRSBtCekimDurumuList { get; set; }
        public List<DataModel> SKRSGenelDurumList { get; set; }
        public Guid Azitromisin { get; set; }
        public Guid CTResult { get; set; }
        public Guid FavipavirAvigan { get; set; }
        public Guid GeneralStatus { get; set; }
        public Guid HasClinicalFinding { get; set; }
        public Guid HasCT { get; set; }
        public Guid HasIntubation { get; set; }
        public Guid HasPneumonia { get; set; }
        public Guid HighDoseCvitamin { get; set; }
        public Guid Hydroxychloroquine { get; set; }
        public Guid IsIntensiveCare { get; set; }
        public Guid IsIsolatedInpatient { get; set; }
        public Guid Kaletra { get; set; }
        public Guid NonCovidInpatient { get; set; }
        public Guid Oseltamivir { get; set; }
        public object Description { get; set; }
        public int? PaoFioRatio { get; set; }
        public DateTime? ProgressDate { get; set; }
    }

    public class DataModel
    {
        public DataModel()
        {
        }

        public DataModel(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class OzellikliBakimIzlemParameterModel
    {
        public Guid? id { get; set; }
        public Guid? physicianAppId { get; set; }
    }

    public class ProgressMedicineValues
    {
        public Guid Azitromisin { get; set; }
        public Guid FavipavirAvigan { get; set; }
        public Guid HighDoseCvitamin { get; set; }
        public Guid Hydroxychloroquine { get; set; }
        public Guid Kaletra { get; set; }
        public Guid Oseltamivir { get; set; }

    }

    public class ProgressMedicineParameter
    {
        public Guid physicianAppId { get; set; }
        public DateTime progressDate { get; set; }
    }
}
