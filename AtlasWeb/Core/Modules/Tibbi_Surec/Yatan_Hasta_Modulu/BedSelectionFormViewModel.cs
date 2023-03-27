//$9442AB96
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using System.Collections;

using Infrastructure.Filters;
using TTStorageManager.Security;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class BedSelectionFormServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yatak_Secimi)]
        public BedSelectionFormViewModel BedSelectionForm(BedSelectionForm_InputParam bedSelectionForm_InputParam)
        {
            var viewModel = new BedSelectionFormViewModel();
            if (bedSelectionForm_InputParam != null && bedSelectionForm_InputParam.selectedPhysicalStateClinic != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var BedsPropertysByResWardList = ResBed.GetBedsPropertysByResWard(objectContext, bedSelectionForm_InputParam.isOnlyEmptyBeds, bedSelectionForm_InputParam.selectedPhysicalStateClinic.ObjectID);
                    viewModel.BedsPropertysByResWardList = BedsPropertysByResWardList.ToArray();

                    foreach (ResBed.GetBedsPropertysByResWard_Class bed in BedsPropertysByResWardList)
                    {
                        if(bed.Usedstatus.ToString() == "1" && bed.Sex == "1")
                        {
                            viewModel.usedBedsMan += 1;
                        }
                        if (bed.Usedstatus.ToString() == "1" && bed.Sex == "2")
                        {
                            viewModel.usedBedsWoman += 1;
                        }
                        if (bed.Usedstatus.ToString() == "0" && (bed.IsClean == true || bed.IsClean == null))
                        {
                            viewModel.emptyBeds += 1;
                        }
                        if(bed.IsClean == false && bed.Usedstatus.ToString() == "0")
                        {
                            viewModel.cleaningStatusBeds += 1;
                        }
                        if(bed.Usedstatus.ToString() == "3" && bed.Sex == "1")
                        {
                            viewModel.reservedToUseMan += 1;
                        }
                        if (bed.Usedstatus.ToString() == "3" && bed.Sex == "2")
                        {
                            viewModel.reservedToUseWoman += 1;
                        }
                    }

                }
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatak_Secimi)]
        public SelectedBedViewModel GetSelectedBedOutPut([FromQuery] Guid selectedBedObjectId)
        {
            var selectedBedViewModel = new SelectedBedViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                if (selectedBedObjectId == null || selectedBedObjectId == Guid.Empty)
                {
                    selectedBedViewModel.Bed = null;
                    selectedBedViewModel.Room = null;
                    selectedBedViewModel.RoomGroup = null;
                    selectedBedViewModel.PhysicalStateClinic = null;
                }
                else
                {
                    ResBed bed = objectContext.GetObject(selectedBedObjectId, typeof(ResBed)) as ResBed;
                    if (bed != null)
                    {
                        selectedBedViewModel.Bed = bed;
                        selectedBedViewModel.Room = bed.Room;
                        selectedBedViewModel.RoomGroup = bed.Room.RoomGroup;
                        selectedBedViewModel.PhysicalStateClinic = bed.Room.RoomGroup.Ward;       
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
            }

            return selectedBedViewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Yatak_Secimi)]
        public BindingList<ResSection.GetAllResWardListWithEmtyBedCount_Class> GetAllResWardListWithEmtyBedCount()
        {
           return  ResSection.GetAllResWardListWithEmtyBedCount();
        }
    }

    
    //[HttpGet]
    //   [AtlasRequiredRoles(TTRoleNames.Yatak_Secimi)]
    //public IList<ResBed.GetResWardListWithEmtyBedCount> GetResWardListWithEmtyBedCount()
    //{
    //    var resWardListWithEmtyBedCount = ResBed.GetResWardListWithEmtyBedCount();
    //    return resWardListWithEmtyBedCount.ToList();
    //}
}

namespace Core.Models
{
    public class BedSelectionFormViewModel
    {
        public ResWard selectedPhysicalStateClinic
        {
            get;
            set;
        }

        public ResRoomGroup selectedRoomGroup
        {
            get;
            set;
        }

        public ResRoom selectedRoom
        {
            get;
            set;
        }

        public ResBed selectedBed
        {
            get;
            set;
        }

        public TTObjectClasses.ResBed.GetBedsPropertysByResWard_Class[] BedsPropertysByResWardList
        {
            get;
            set;
        }

        public bool isOnlyEmptyBeds
        {
            get;
            set;
        }

        public ResBed.GetResWardListWithEmtyBedCount_Class[] physicalStateClinicList
        {
            get;
            set;
        }
        public int emptyBeds = 0;
        public int usedBedsWoman = 0;
        public int usedBedsMan = 0;
        public int cleaningStatusBeds = 0; //temizlenecek ve temizlenmemiş yataklar
        public int isolatedRoom = 0;
        public int isolatedBed = 0;
        public int reservedToUseMan = 0;
        public int reservedToUseWoman = 0;

    }

    public class BedSelectionForm_InputParam
    {
        public ResWard selectedPhysicalStateClinic
        {
            get;
            set;
        }

        public bool isOnlyEmptyBeds
        {
            get;
            set;
        }
    }

    public class SelectedBedViewModel
    {
        public ResWard PhysicalStateClinic;
        public ResRoomGroup RoomGroup;
        public ResRoom Room;
        public ResBed Bed;
    }
}