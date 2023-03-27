using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using TTConnectionManager;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class SubStoreDefinitionController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetSubStoreDefinition getAllSubStoreDefinition()
        {
            GetSubStoreDefinition subStoreDefinition = new GetSubStoreDefinition();
            subStoreDefinition.subStoreDefinitionListDTOs = new List<SubStoreDefinitionListDTO>();
            subStoreDefinition.ResUserDataSources = new List<ResUserDataSource>();

            subStoreDefinition.subStoreDefinitionListDTOs = SubStoreDefinition.GetSubStoreDefinition(string.Empty).Select(x => new SubStoreDefinitionListDTO()
            {
                Name = x.Name,
                ObjectID = x.ObjectID.Value,
                IsActive = x.IsActive.Value,

            }).ToList();

            BindingList<ResUser.GetAllUserReportNQL_Class> users = ResUser.GetAllUserReportNQL("ORDER BY NAME");
            foreach (ResUser.GetAllUserReportNQL_Class user in users)
            {
                ResUserDataSource userItem = new ResUserDataSource();
                userItem.ObjectID = user.ObjectID.Value;
                userItem.ResUserName = user.Name;
                subStoreDefinition.ResUserDataSources.Add(userItem);
            }
            return subStoreDefinition;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SubStoreDefinitionOutputItem getSubStoreDefinitionItem(GetSubStoreDefinition_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                SubStoreDefinitionOutputItem outputItem = new SubStoreDefinitionOutputItem();

                SubStoreDefinition subStoreDefinition = objectContect.GetObject<SubStoreDefinition>(input.ObjectID);
                outputItem.ObjectID = subStoreDefinition.ObjectID;
                outputItem.Name = subStoreDefinition.Name;
                outputItem.Qref = subStoreDefinition.QREF;
                outputItem.AutoReturningDocumentCreat = subStoreDefinition.AutoReturningDocumentCreat;
                outputItem.UnitCode = subStoreDefinition.UnitCode;
                outputItem.UnitRegistryNo = subStoreDefinition.UnitRegistryNo;
                outputItem.IsActive = subStoreDefinition.IsActive;
                outputItem.DependantUnitID = subStoreDefinition.DependantUnitID;
                outputItem.IsEmergencyStore = subStoreDefinition.IsEmergencyStore;
                outputItem.Status = subStoreDefinition.Status;

                if (subStoreDefinition.SubStoreMKYS != null)
                {
                    outputItem.SubStoreMKYS = subStoreDefinition.SubStoreMKYS.ObjectID;
                    outputItem.SubStoreMKYSName = subStoreDefinition.SubStoreMKYS.birimAdi;
                }
                outputItem.MKYS_CikisHareketTuru = subStoreDefinition.MKYS_CikisHareketTuru;
                if (subStoreDefinition.StoreResponsible != null)
                {
                    outputItem.StoreResponsible = new StoreResponsibleDTO();
                    outputItem.StoreResponsible.ReUserObjectID = subStoreDefinition.StoreResponsible.ObjectID;
                    outputItem.StoreResponsible.ResUserName = subStoreDefinition.StoreResponsible.Name;
                }

                return outputItem;
            }
        }

        [HttpPost]
        public string saveObject(SubStoreDefinitionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                SubStoreDefinition subStoreDefinition = null;
                if (input.isNew == true)
                {
                    subStoreDefinition = new SubStoreDefinition(objectContext);
                }
                else
                {
                    subStoreDefinition = objectContext.GetObject<SubStoreDefinition>(input.ObjectID);
                 
                }

                subStoreDefinition.Name = input.Name;
                subStoreDefinition.QREF = input.Qref;
                subStoreDefinition.AutoReturningDocumentCreat = input.AutoReturningDocumentCreat;
                subStoreDefinition.UnitCode = input.UnitCode;
                subStoreDefinition.UnitRegistryNo = input.UnitRegistryNo;
                subStoreDefinition.IsActive = input.IsActive;
                subStoreDefinition.DependantUnitID = input.DependantUnitID;
                subStoreDefinition.IsEmergencyStore = input.IsEmergencyStore;
                subStoreDefinition.Status = input.Status;
                subStoreDefinition.MKYS_CikisHareketTuru = input.MKYS_CikisHareketTuru;

                if(input.StoreResponsible.ReUserObjectID != Guid.Empty)
                {
                    ResUser resUser = (ResUser)objectContext.GetObject(input.StoreResponsible.ReUserObjectID, typeof(ResUser));
                    subStoreDefinition.StoreResponsible = resUser;
                }

                objectContext.Save();
                objectContext.Dispose();
                return "Cep Depo Kayıt İşlemi Yapılmıştır";
            }
            catch (Exception ex)
            {
                return ex.Message + "-- Cep Depo Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }


        [HttpPost]
        public string CreatToMkys(SubStoreDefinitionOutputItem input)
        {
            if (input.isNew == false)
            {
                TTObjectContext objectContect = new TTObjectContext(false);
                MkysServis.birimInsertItem item = new MkysServis.birimInsertItem();
                SubStoreDefinition subStoreDefinition = objectContect.GetObject<SubStoreDefinition>(input.ObjectID);
                item.birimKisaAdi = subStoreDefinition.Name;
                MkysServis.birimKayitIslemleriSonuc t = MkysServis.WebMethods.birimInsertSync(Sites.SiteLocalHost, item);
                if (t.basariDurumu == true)
                {
                    MKYS_ServisDepo.AddMKYSServisDepo();
                    BindingList<MKYS_ServisDepo> servisDepo = objectContect.QueryObjects<MKYS_ServisDepo>(" birimKayitNo = '+" + t.birimKayitNo + "'");
                    subStoreDefinition.SubStoreMKYS = servisDepo[0];
                    objectContect.Save();
                    objectContect.Dispose();
                    return "Kayıt Tamamlandı.";
                }
                else
                    return "MKYS Birim Kayıt Yapılamadı.";
            }
            else
            {
                return "Önce Sisteme Kaydediniz.!";
            }
        }

        public class SubStoreDefinitionListDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }

        public class GetSubStoreDefinition
        {
            public List<SubStoreDefinitionListDTO> subStoreDefinitionListDTOs { get; set; }
            public List<ResUserDataSource> ResUserDataSources { get; set; }
        }
        public class GetSubStoreDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        public class SubStoreDefinitionOutputItem
        {
            public bool? isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public StoreResponsibleDTO StoreResponsible { get; set; }
            public string Qref { get; set; }
            public bool? IsActive { get; set; }
            public bool? AutoReturningDocumentCreat { get; set; }
            public bool? IsEmergencyStore { get; set; }
            public string UnitCode { get; set; }
            public int? UnitRegistryNo { get; set; }
            public int? DependantUnitID { get; set; }
            public OpenCloseEnum? Status { get; set; }
            public Guid? SubStoreMKYS { get; set; }
            public string SubStoreMKYSName { get; set; }
            public MKYS_ECikisStokHareketTurEnum? MKYS_CikisHareketTuru { get; set; }


        }

        public class StoreResponsibleDTO
        {

            public Guid ReUserObjectID { get; set; }
            public string ResUserName { get; set; }
        }

        public class ResUserDataSource
        {

            public Guid ObjectID { get; set; }
            public string ResUserName { get; set; }
        }
    }
}
