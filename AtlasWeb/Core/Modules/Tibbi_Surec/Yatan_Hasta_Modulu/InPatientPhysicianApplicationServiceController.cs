//$A7356FB2
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using TTUtils;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class InPatientPhysicianApplicationServiceController : Controller
    {
        public class GetActiveInPatientPhysicianApplication_Input
        {
            public System.Guid episodeID { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public TTObjectClasses.InPatientPhysicianApplication GetActiveInPatientPhysicianApplication(GetActiveInPatientPhysicianApplication_Input input)
        {
            var ret = InPatientPhysicianApplication.GetActiveInPatientPhysicianApplication(input.episodeID);
            return ret;
        }

        public bool CancelDailyInpatient(InPatientPhysicianApplication inPatientPhysicianApplication)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(inPatientPhysicianApplication.ObjectID);
                InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = null;
                inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
                TreatmentDischarge treatmentDischarge = null;
                treatmentDischarge = inPatientTreatmentClinicApp.TreatmentDischarge;
                NursingApplication nursingApp = null;
                nursingApp = inPatientTreatmentClinicApp.NursingApplications[0];

                List<SubActionProcedure> dailyProcList = inPatientTreatmentClinicApp.SubEpisode.SubActionProcedures.Where(x => x is DailyBedProcedure && !x.IsCancelled).ToList();
                foreach (SubActionProcedure dailyProc in dailyProcList)
                    dailyProc.CurrentStateDefID = SubActionProcedure.States.Cancelled; 
                //?


                if (treatmentDischarge != null && treatmentDischarge.CurrentStateDefID != TreatmentDischarge.States.Cancelled)
                    treatmentDischarge.CurrentStateDefID = TreatmentDischarge.States.Cancelled;

                objectContext.Update();


                if (inPatientTreatmentClinicApp.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled)
                    inPatientTreatmentClinicApp.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Cancelled;



                objectContext.Save();

            }
            return true;
        }

        [HttpPost]
        public DepartmentOccupancyRateViewModel CreateViewModel()
        {
            using (var objectContext = new TTObjectContext(false)) {

                DepartmentOccupancyRateViewModel viewModel = new DepartmentOccupancyRateViewModel();
                List<ResBuilding> buildingList = ResBuilding.GetAllBuildings(objectContext).ToList();
                List<ResBuildingWing> wingList = ResBuildingWing.GetWingDefinitionObject(objectContext, "").ToList();
                List<ResFloor> floorList = ResFloor.GetFloorDefinitionObject(objectContext, "").ToList();

                /*select-box'larý olusturmak icin */
                viewModel.BuildingList = buildingList.ToArray();
                viewModel.WingList = wingList.ToArray();
                viewModel.FloorList = floorList.ToArray();

                List<ResBed> allActiveBeds = ResBed.GetAllActiveBeds(objectContext).ToList();
                List<FloorSectionsModel> FloorSectionModelList = new List<FloorSectionsModel>();
                List<WingModel> WingModelList = new List<WingModel>();
                List<BuildingModel> BuildingModelList = new List<BuildingModel>();
                List<FloorOccupancyModel> FloorOccupancyList = new List<FloorOccupancyModel>();



                foreach (ResBed bed in allActiveBeds)
                {
                    if (bed.Room != null && bed.Room.RoomGroup != null && bed.Room.RoomGroup.Ward != null && bed.Room.RoomGroup.Ward.ResFloor != null)
                    {
                        var sectionExist = FloorSectionModelList.Where(section => section.SectionID == bed.Room.RoomGroup.Ward.ObjectID).FirstOrDefault(); //yataðýn olduðu birim bulunur
                        if (sectionExist == null)
                        { //yataðýn olduðu birim hiç eklenmediyse
                            sectionExist = new FloorSectionsModel();
                            sectionExist.SectionName = bed.Room.RoomGroup.Ward.Name;
                            sectionExist.SectionID = bed.Room.RoomGroup.Ward.ObjectID;
                            if (bed.Room.RoomGroup.Ward.ResFloor != null)
                            {
                                sectionExist.FloorName = bed.Room.RoomGroup.Ward.ResFloor.Name;
                                sectionExist.FloorObjectID = bed.Room.RoomGroup.Ward.ResFloor.ObjectID;
                                sectionExist.WhichFloor = bed.Room.RoomGroup.Ward.ResFloor.FloorNumber;
                                if (bed.Room.RoomGroup.Ward.ResFloor.ResBuildingWing != null)
                                    sectionExist.WingObjectID = bed.Room.RoomGroup.Ward.ResFloor.ResBuildingWing.ObjectID;

                                sectionExist.BuildingObjectID = bed.Room.RoomGroup.Ward.ResFloor.ResBuilding.ObjectID;
                            }

                            if (bed.UsedByBedProcedure == null)
                            {
                                sectionExist.EmptyBed++;
                            }
                            else
                                sectionExist.UsedBed++;
                            if (bed.IsClean == false)
                            {
                                sectionExist.DirtyBed++;
                            }

                            sectionExist.FloorSectionName = sectionExist.FloorName + " / " + sectionExist.SectionName;
                            FloorSectionModelList.Add(sectionExist);

         
                            var wingExist = WingModelList.Where(wing => wing.WingID == sectionExist.WingObjectID).FirstOrDefault();
                            if (wingExist == null) //bu kanat bilgisi hiç eklenmediyse 
                            {
                                wingExist = new WingModel();
                                wingExist.WingID = sectionExist.WingObjectID;
                                wingExist.WingName = wingList.Where(wing => wing.ObjectID == wingExist.WingID).FirstOrDefault().Name;
                                wingExist.Floors = new List<FloorSectionsModel>();
                                wingExist.FloorOccupancyDataList = new List<FloorOccupancyModel>();
                                wingExist.BuildingObjectID = sectionExist.BuildingObjectID;
                                WingModelList.Add(wingExist);
                            }

                            wingExist.Floors.Add(sectionExist); //kanat tanýmýna kat bilgisi eklenir


                            var buildingExist = BuildingModelList.Where(building => building.BuildingID == sectionExist.BuildingObjectID).FirstOrDefault();
                            if (buildingExist == null)
                            {
                                buildingExist = new BuildingModel();
                                buildingExist.BuildingID = sectionExist.BuildingObjectID;
                                buildingExist.BuildingName = buildingList.Where(building => building.ObjectID == buildingExist.BuildingID).FirstOrDefault().Name;
                                buildingExist.Wings = new List<WingModel>();
                                BuildingModelList.Add(buildingExist);
                            }

                            var buildingWingExist = buildingExist.Wings.Where(wing => wing.WingID == wingExist.WingID).FirstOrDefault();
                            if(buildingWingExist == null)
                                buildingExist.Wings.Add(wingExist);

                        }

                        else //birim daha önceden eklendiyse sadece boþ / dolu sayýsýný güncelle
                        {

                            if (bed.UsedByBedProcedure == null)
                            {
                                sectionExist.EmptyBed++;
                            }
                            else
                                sectionExist.UsedBed++;
                            if(bed.IsClean == false)
                            {
                                sectionExist.DirtyBed++;
                            }
                        }
                        sectionExist.TotalNumberOfBeds = sectionExist.EmptyBed + sectionExist.UsedBed;
                    }
                }
                foreach (BuildingModel building in BuildingModelList)
                {
                    foreach(WingModel wing in building.Wings)
                    {
                        foreach(FloorSectionsModel floor in wing.Floors)
                        {
                            var floorExist = FloorOccupancyList.Where(floorModel => floorModel.WhichFloor == floor.WhichFloor && floorModel.WingObjectID == floor.WingObjectID).FirstOrDefault();
                            if(floorExist == null)
                            {
                                FloorOccupancyModel occupancyModel = new FloorOccupancyModel();
                                occupancyModel.FloorName = floor.FloorName;
                                occupancyModel.ObjectID = floor.FloorObjectID;
                                occupancyModel.WhichFloor = floor.WhichFloor;
                                occupancyModel.UsedBed = floor.UsedBed;
                                occupancyModel.EmptyBed = floor.EmptyBed;
                                occupancyModel.TotalNumberOfBeds = floor.TotalNumberOfBeds;
                                occupancyModel.WingObjectID = floor.WingObjectID;
                                occupancyModel.BuildingObjectID = floor.BuildingObjectID;
                                wing.FloorOccupancyDataList.Add(occupancyModel);
                                FloorOccupancyList.Add(occupancyModel);
                            }
                            else
                            {
                                floorExist.UsedBed += floor.UsedBed;
                                floorExist.EmptyBed += floor.EmptyBed;
                                floorExist.TotalNumberOfBeds += floor.TotalNumberOfBeds;
                            }
                        }
                    }
                }

            

                foreach (FloorSectionsModel item in FloorSectionModelList)
                {
                    double rate = (double)item.UsedBed / item.TotalNumberOfBeds;
                    rate = rate * 100;
                    item.OccupancyRate = "%" + ((int)rate).ToString();
                }
                foreach (FloorOccupancyModel item in FloorOccupancyList)
                {
                    double rate = (double)item.UsedBed / item.TotalNumberOfBeds;
                    rate = rate * 100;
                    item.OccupancyRate = "%" + ((int)rate).ToString();
                }

                /*Datagridleri olusturmak icin */

                viewModel.FloorSectionModelList = FloorSectionModelList.ToArray();
                viewModel.BuildingModelList = BuildingModelList.ToArray();
                viewModel.WingModelList = WingModelList.ToArray();
                viewModel.FloorOccupancyDataList = FloorOccupancyList.ToArray();


                return viewModel;
            }

        }
    }
}

namespace Core.Models
{
    public class DepartmentOccupancyRateViewModel
    {
        public ResBuilding[] BuildingList { get; set; }
        public ResBuildingWing[] WingList { get; set; }
        public ResFloor[] FloorList { get; set; }
        public FloorSectionsModel[] FloorSectionModelList { get; set; }
        public WingModel[] WingModelList { get; set; }
        public BuildingModel[] BuildingModelList { get; set; }
        public FloorOccupancyModel[] FloorOccupancyDataList { get; set; }

    }

    public class FloorSectionsModel
    {
        public Guid BuildingObjectID { get; set; }
        public Guid? WingObjectID { get; set; }
        public Guid? FloorObjectID { get; set; }
        public string FloorName { get; set; }
        public Guid SectionID { get; set; }
        public string SectionName { get; set; }
        public int EmptyBed { get; set; }
        public int UsedBed { get; set; }
        public string OccupancyRate { get; set; }
        public string FloorSectionName { get; set; }
        public int TotalNumberOfBeds { get; set; }
        public int DirtyBed { get; set; }
        public int? WhichFloor { get; set; }
    }

    public class BuildingModel
    {
        public Guid BuildingID { get; set; }
        public string BuildingName { get; set; }
        public List<WingModel> Wings { get; set; }

    }

    public class WingModel
    {
        public Guid? WingID { get; set; }
        public string WingName { get; set; }
        public List <FloorSectionsModel> Floors { get; set; }
        public Guid BuildingObjectID { get; set; }
        public List<FloorOccupancyModel> FloorOccupancyDataList { get; set; }


    }
    public class FloorOccupancyModel
    {
        public string FloorName { get; set; }
        public int? WhichFloor { get; set; }
        public Guid? ObjectID { get; set; }
        public int EmptyBed { get; set; }
        public int UsedBed { get; set; }
        public string OccupancyRate { get; set; }
        public int TotalNumberOfBeds { get; set; }
        public Guid? WingObjectID { get; set; }
        public Guid? BuildingObjectID { get; set; }

    }

}