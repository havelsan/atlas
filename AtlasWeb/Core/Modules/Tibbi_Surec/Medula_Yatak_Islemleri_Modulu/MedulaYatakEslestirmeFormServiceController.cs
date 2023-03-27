//$A58E80DD
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class MedulaYatakEslestirmeFormServiceController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Yatak_Eslestirme)]
        public MedulaYatakEslestirmeModel getViewModel()
        {
            MedulaYatakEslestirmeModel viewModel = new MedulaYatakEslestirmeModel();
            var MedulaBedList = new List<MedulaYardimciIslemler.tesisYatakBilgiDVO>();
            var UnMatchedMedulaBedList = new List<MedulaYardimciIslemler.tesisYatakBilgiDVO>();
            var UnMatchedBedList = new List<BedModel>();
            var MatchedBedList = new List<BedModel>();

            MedulaYardimciIslemler.tesisYatakSorguGirisDVO tesisYatakSorguGirisDVO = new MedulaYardimciIslemler.tesisYatakSorguGirisDVO();

            tesisYatakSorguGirisDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
            tesisYatakSorguGirisDVO.tarih = Common.RecTime().ToString("dd.MM.yyyy");

            MedulaYardimciIslemler.tesisYatakSorguCevapDVO response = MedulaYardimciIslemler.WebMethods.tesisYatakSorguSync(Sites.SiteLocalHost, tesisYatakSorguGirisDVO);
            if (response != null && response.yataklar != null && response.yataklar.Length > 0)
            {
                foreach (var yatak in response.yataklar)
                {
                    MedulaBedList.Add(yatak);
                    UnMatchedMedulaBedList.Add(yatak);
                }
            }

            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var existBedList = ResBed.GetAllActiveBeds(objectContext).ToList();
                var filteredBedList = existBedList.Where(t => t.Room.IsActive == true && t.Room.RoomGroup.IsActive == true && t.Room.RoomGroup.Ward.IsActive == true && t.BedProcedure != null && t.BedProcedure.Code != "510120").ToList();
                foreach (var bed in filteredBedList)
                {
                    BedModel bedModel = new BedModel();
                    bedModel.BedObjectId = bed.ObjectID;
                    bedModel.BedNumber = bed.Name;
                    bedModel.Room = bed.Room.Name;
                    bedModel.Ward = bed.Room.RoomGroup.Ward.Name;
                    //bedModel.BedType = bed.BedProcedureType != null ? Common.GetDisplayTextOfDataTypeEnum(bed.BedProcedureType) : "Standart Yatak";
                    if (bed.BedProcedure != null && bed.BedProcedure.Code == "P552001")
                    {
                        bedModel.BedType = "Yo�un Bak�m";
                        bedModel.BedLevel = "1";
                    }
                    else if (bed.BedProcedure != null && bed.BedProcedure.Code == "P552002")
                    {
                        bedModel.BedType = "Yo�un Bak�m";
                        bedModel.BedLevel = "2";
                    }
                    else if (bed.BedProcedure != null && bed.BedProcedure.Code == "P552003")
                    {
                        bedModel.BedType = "Yo�un Bak�m";
                        bedModel.BedLevel = "3";
                    }
                    else if (bed.BedProcedure != null && bed.BedProcedure.Code == "P560000")
                    {
                        bedModel.BedType = "Palyatif";
                        bedModel.BedLevel = "0";
                    }
                    else
                    {
                        bedModel.BedType = "Standart";
                        bedModel.BedLevel = "0";
                    }
                    if (!String.IsNullOrEmpty(bed.BedCodeForMedula))
                    {
                        bedModel.MedulaBedCode = bed.BedCodeForMedula;
                        MatchedBedList.Add(bedModel);
                        UnMatchedMedulaBedList = UnMatchedMedulaBedList.Where(t => t.yatakKodu != bed.BedCodeForMedula).ToList();
                    }
                    else
                    {
                        UnMatchedBedList.Add(bedModel);
                    }
                }
            }
            viewModel.MedulaBedList = MedulaBedList;
            viewModel.UnMatchedMedulaBedList = UnMatchedMedulaBedList;
            viewModel.MatchedBedList = MatchedBedList;
            viewModel.UnMatchedBedList = UnMatchedBedList;

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Yatak_Eslestirme)]
        public bool MatchMedulaBed(Guid bedObjectId, string bedCodeForMedula)
        {
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    ResBed bedObj = objectContext.GetObject<ResBed>(bedObjectId);
                    bedObj.BedCodeForMedula = bedCodeForMedula;
                    objectContext.Save();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Medula_Yatak_Eslestirme)]
        public bool DeleteMedulaMatchFromBed(Guid bedObjectId)
        {
            try
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    ResBed bedObj = objectContext.GetObject<ResBed>(bedObjectId);
                    bedObj.BedCodeForMedula = null;
                    objectContext.Save();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
    }
}

namespace Core.Models
{
    public class MedulaYatakEslestirmeModel
    {
        public List<MedulaYardimciIslemler.tesisYatakBilgiDVO> MedulaBedList { get; set; }
        public List<MedulaYardimciIslemler.tesisYatakBilgiDVO> UnMatchedMedulaBedList { get; set; }
        public List<BedModel> UnMatchedBedList { get; set; }
        public List<BedModel> MatchedBedList { get; set; }
    }

    public class BedModel
    {
        public Guid BedObjectId { get; set; }
        public string Ward { get; set; }
        public string Room { get; set; }
        public string BedNumber { get; set; }
        public string BedType { get; set; }
        public string BedLevel { get; set; }
        public string MedulaBedCode { get; set; }
    }
}