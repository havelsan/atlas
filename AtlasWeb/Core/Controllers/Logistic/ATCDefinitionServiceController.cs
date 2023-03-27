using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class ATCDefinitionServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<ATCList> listATC()
        {
            List<ATCList> atcList = new List<ATCList>();

            atcList = DrugATC.GetDrugATCListRQ().Select(p => new ATCList()
            {
                AtcCodeAndName = p.Atccode + " - " + p.Atcname,
                Barcode = p.Drugbarcode,
                DrugName = p.Drugname,
                IsActive = p.IsActive,
                ObjectID = p.ObjectID.Value
            }).ToList();

            return atcList;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<UpdateListOfSKRS> getUpdateSKRSList()
        {
            TTObjectContext context = new TTObjectContext(false);
            List<UpdateListOfSKRS> updateListOfSKRS = new List<UpdateListOfSKRS>();

            var skrsList = SKRSIlac.GetSKRSIlac(string.Empty).ToList();
            var atcList = ATC.GetATCListQuery(string.Empty).ToList();
            var drugDefList = DrugDefinition.GetDrugDefinition(context, string.Empty).ToList();

          
            var notExistSKRS = from skrs in skrsList
                               join atc in atcList
                               on skrs.ATCKODU equals atc.Code into t
                               from od in t.DefaultIfEmpty()
                               where od == null
                               select skrs;

            var existAtcSkrs = notExistSKRS.ToList();
            var notDrugExistSKRS = from notexistDrug in existAtcSkrs
                                   join drugDef in drugDefList
                                   on notexistDrug.BARKODU equals drugDef.Barcode into t
                                   from od in t.DefaultIfEmpty()
                                   where od != null
                                   select notexistDrug;

            var listofSkrs = notDrugExistSKRS.ToList();

            foreach (var item in listofSkrs)
            {
                if (updateListOfSKRS.Where(x => x.AtcCode == item.ATCKODU && x.Barcode == item.BARKODU && x.AtcName == item.ATCADI).Any() == false)
                {
                    UpdateListOfSKRS updateList = new UpdateListOfSKRS();
                    updateList.AtcName = item.ATCADI;
                    updateList.AtcCode = item.ATCKODU;
                    updateList.Barcode = item.BARKODU;
                    updateList.DrugName = item.ADI;
                    updateList.IsActive = item.AKTIF == "0" ? false : true;
                    updateList.SKRSIlacObjectID = item.ObjectID.Value;
                    updateListOfSKRS.Add(updateList);
                }
            }


            context.Dispose();
            return updateListOfSKRS;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string UpdateSKRSList(UpdateInputDTO input)
        {
            string ReturnMessage = string.Empty;
            if (input.updateListOfSKRS.Count == 0)
                throw new TTException("Güncellenecek Liste Bulunamadı.");

            var atcList = ATC.GetATCListQuery(string.Empty).ToList();

            try
            {
                foreach (UpdateListOfSKRS item in input.updateListOfSKRS)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    DrugDefinition drugDefinition = context.QueryObjects<DrugDefinition>("Barcode = '" + item.Barcode + "'").FirstOrDefault();
                   
                    if(atcList.Where(x => x.Code == item.AtcCode && x.Name == item.AtcName).Any() == true)
                    {
                        Guid atcGet = (Guid)atcList.Where(x => x.Code == item.AtcCode && x.Name == item.AtcName).FirstOrDefault().ObjectID;
                        ATC atc = context.GetObject<ATC>(atcGet);
                        DrugATC drugATC = new DrugATC(context);
                        drugATC.DrugDefinition = drugDefinition;
                        drugATC.ATC = atc;
                        drugATC.IsActive = item.IsActive;
                    }
                    else
                    {
                        ATC newAtC = new ATC(context);
                        newAtC.Code = item.AtcCode;
                        newAtC.Name = item.AtcName;
                        newAtC.IsActive = item.IsActive;

                        DrugATC drugATC = new DrugATC(context);
                        drugATC.DrugDefinition = drugDefinition;
                        drugATC.ATC = newAtC;
                        drugATC.IsActive = item.IsActive;
                    }

                    context.Save();
                    context.Dispose();
                }
                ReturnMessage = " SKRS Güncellemesi Tamamlandı.";
            }

            catch (Exception ex)
            {
                ReturnMessage += ex.Message + " , ";
            }
            return ReturnMessage;
        }
    }

    public class UpdateInputDTO
    {
        public List<UpdateListOfSKRS> updateListOfSKRS { get; set; }
    }

    public class UpdateListOfSKRS
    {
        public Guid SKRSIlacObjectID { get; set; }
        public string DrugName { get; set; }
        public string AtcName { get; set; }
        public string AtcCode { get; set; }
        public string Barcode { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ATCList
    {
        public Guid ObjectID { get; set; }
        public string DrugName { get; set; }
        public string Barcode { get; set; }
        public string AtcCodeAndName { get; set; }
        public bool? IsActive { get; set; }
    }
}
