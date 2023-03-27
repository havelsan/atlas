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
    public class DistributionDefinitionServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DistributionDefList> listDistributionDef()
        {
            List<DistributionDefList> distDefList = new List<DistributionDefList>();

            distDefList = DistributionTypeDefinition.GetDistributionDefinitionRQ().Select(p => new DistributionDefList()
            {
                Name = p.DistributionType,
                EnumNo = p.MKYSDistributionID.Value,
                Value = p.QRef,
                IsActive = p.IsActive,
                ObjectID = p.ObjectID.Value
            }).ToList();

            return distDefList;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<UpdateListOfMKYS> getUpdateMKYSList()
        {
            TTObjectContext context = new TTObjectContext(false);
            List<UpdateListOfMKYS> updateListOfMKYS = new List<UpdateListOfMKYS>();

            var mkysDistList = context.QueryObjects<MKYSKod>(string.Format("KODADI LIKE 'OLCU_BIRIMI_ID' AND AKTIF = 1 AND ENUMNO <> 0 ")).ToList();
            var distListList = DistributionTypeDefinition.GetDistributionDefinitionRQ().ToList();

            var notExistMKYS = from mkys in mkysDistList
                               join dist in distListList
                               on mkys.EnumNo equals dist.MKYSDistributionID into t
                               from od in t.DefaultIfEmpty()
                               where od == null
                               select mkys;

            var existAtcSkrs = notExistMKYS.ToList();

            updateListOfMKYS = existAtcSkrs.Select(p => new UpdateListOfMKYS()
            {
                Name = p.Aciklama,
                EnumNo = p.EnumNo.Value,
                Value = p.Degeri,
                IsActive = p.Aktif,
                MKYSObjectID = p.ObjectID
            }).ToList();

            context.Dispose();
            return updateListOfMKYS;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string UpdateMKYSList(UpdateMKYSInputDTO input)
        {
            string ReturnMessage = string.Empty;
            if (input.updateListOfMKYS.Count == 0)
                throw new TTException("Güncellenecek Liste Bulunamadı.");

            try
            {
                foreach (UpdateListOfMKYS item in input.updateListOfMKYS)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    DistributionTypeDefinition objListForDist = new DistributionTypeDefinition(context);
                    objListForDist.QRef = item.Value;
                    objListForDist.DistributionType = item.Name;
                    objListForDist.IsActive = item.IsActive;
                    objListForDist.MKYSDistributionID = item.EnumNo;
                    if (item.EnumNo > 0 && item.EnumNo < 61)
                        objListForDist.MKYS_DistType = (MKYS_EOlcuBirimEnum)(item.EnumNo - 1);

                    context.Save();
                    context.Dispose();
                }
                ReturnMessage = " MKYS Güncellemesi Tamamlandı.";
            }

            catch (Exception ex)
            {
                ReturnMessage += ex.Message + " , ";
            }
            return ReturnMessage;
        }
    }

    public class UpdateMKYSInputDTO
    {
        public List<UpdateListOfMKYS> updateListOfMKYS { get; set; }
    }

    public class UpdateListOfMKYS
    {
        public Guid MKYSObjectID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int EnumNo { get; set; }
        public bool? IsActive { get; set; }
    }

    public class DistributionDefList
    {
        public Guid ObjectID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int EnumNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
