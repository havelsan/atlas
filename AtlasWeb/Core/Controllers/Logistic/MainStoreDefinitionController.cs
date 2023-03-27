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
    public class MainStoreDefinitionController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetMainStoreDefinition getAllMainStoreDefinition()
        {
            GetMainStoreDefinition mainStoreDefinition = new GetMainStoreDefinition();
            mainStoreDefinition.mainStoreDefinitionListDTOs = new List<MainStoreDefinitionListDTO>();
            mainStoreDefinition.ResUserDataSources = new List<ResUserDataSource>();
            mainStoreDefinition.AccotuntancyDataSource = new List<AccoutancyDataSource>();

            mainStoreDefinition.mainStoreDefinitionListDTOs = MainStoreDefinition.GetMainStoreDefinition(string.Empty).Select(x => new MainStoreDefinitionListDTO()
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
                mainStoreDefinition.ResUserDataSources.Add(userItem);
            }

            mainStoreDefinition.AccotuntancyDataSource = Accountancy.GetAccountancyList(string.Empty).Select(ac => new AccoutancyDataSource()
            {
                ObjectID = ac.ObjectID.Value,
                AccountancyName = ac.Name,
            }).ToList();

            return mainStoreDefinition;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MainStoreDefinitionOutputItem getMainStoreDefinitionItem(GetMainStoreDefinition_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                MainStoreDefinitionOutputItem outputItem = new MainStoreDefinitionOutputItem();

                MainStoreDefinition mainStoreDefinition = objectContect.GetObject<MainStoreDefinition>(input.ObjectID);
                outputItem.ObjectID = mainStoreDefinition.ObjectID;
                outputItem.Name = mainStoreDefinition.Name;
                outputItem.Qref = mainStoreDefinition.QREF;
                outputItem.IsActive = mainStoreDefinition.IsActive;
                outputItem.Status = mainStoreDefinition.Status;
                outputItem.StoreCode = mainStoreDefinition.StoreCode;
                outputItem.Accountancy = mainStoreDefinition.Accountancy.ObjectID;
                outputItem.IntegrationScope = mainStoreDefinition.IntegrationScope;
                outputItem.StoreRecordNo = mainStoreDefinition.StoreRecordNo;
                outputItem.UnitRecordNo = mainStoreDefinition.UnitRecordNo;
                outputItem.MKYS_ButceTuru = mainStoreDefinition.MKYS_ButceTuru;

                if (mainStoreDefinition.StoreSMSUsers != null)
                {
                    outputItem.StoreSMSUsers = new List<SmsUserDTO>();
                    var StoreSMSUsers = mainStoreDefinition.StoreSMSUsers.ToList();
                    foreach (StoreSMSUser user in StoreSMSUsers)
                    {
                        SmsUserDTO smsUserDTO = new SmsUserDTO();
                        smsUserDTO.StoreSmsUserObjectID = user.ObjectID;
                        smsUserDTO.ResUserObjectID = user.ResUser.ObjectID;
                        smsUserDTO.ResUserName = user.ResUser.Name;
                        outputItem.StoreSMSUsers.Add(smsUserDTO);
                    }
                }



                if (mainStoreDefinition.GoodsAccountant != null)
                {
                    outputItem.GoodsAccountant = new StoreResponsibleDTO();
                    outputItem.GoodsAccountant.ReUserObjectID = mainStoreDefinition.GoodsAccountant.ObjectID;
                    outputItem.GoodsAccountant.ResUserName = mainStoreDefinition.GoodsAccountant.Name;
                }
                if (mainStoreDefinition.GoodsResponsible != null)
                {
                    outputItem.GoodsResponsible = new StoreResponsibleDTO();
                    outputItem.GoodsResponsible.ReUserObjectID = mainStoreDefinition.GoodsResponsible.ObjectID;
                    outputItem.GoodsResponsible.ResUserName = mainStoreDefinition.GoodsResponsible.Name;
                }
                if (mainStoreDefinition.AccountManager != null)
                {
                    outputItem.AccountManager = new StoreResponsibleDTO();
                    outputItem.AccountManager.ReUserObjectID = mainStoreDefinition.AccountManager.ObjectID;
                    outputItem.AccountManager.ResUserName = mainStoreDefinition.AccountManager.Name;
                }


                return outputItem;
            }
        }

        [HttpPost]
        public string saveObject(MainStoreDefinitionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                MainStoreDefinition mainStoreDefinition = null;
                if (input.isNew == true)
                {
                    mainStoreDefinition = new MainStoreDefinition(objectContext);
                }
                else
                {
                    mainStoreDefinition = objectContext.GetObject<MainStoreDefinition>(input.ObjectID);
                }

                mainStoreDefinition.Name = input.Name;
                mainStoreDefinition.QREF = input.Qref;
                mainStoreDefinition.IsActive = input.IsActive;
                mainStoreDefinition.Status = input.Status;
                mainStoreDefinition.StoreCode = input.StoreCode;
                //mainStoreDefinition.Accountancy = input.Accountancy;
                mainStoreDefinition.IntegrationScope = input.IntegrationScope;
                mainStoreDefinition.StoreRecordNo = input.StoreRecordNo;
                mainStoreDefinition.UnitRecordNo = input.UnitRecordNo;
                mainStoreDefinition.MKYS_ButceTuru = input.MKYS_ButceTuru;

                if (input.AccountManager.ReUserObjectID != Guid.Empty)
                {
                    ResUser resUser = (ResUser)objectContext.GetObject(input.AccountManager.ReUserObjectID, typeof(ResUser));
                    mainStoreDefinition.AccountManager = resUser;
                }
                if (input.GoodsAccountant.ReUserObjectID != Guid.Empty)
                {
                    ResUser resUser = (ResUser)objectContext.GetObject(input.GoodsAccountant.ReUserObjectID, typeof(ResUser));
                    mainStoreDefinition.GoodsAccountant = resUser;
                }
                if (input.GoodsResponsible.ReUserObjectID != Guid.Empty)
                {
                    ResUser resUser = (ResUser)objectContext.GetObject(input.GoodsResponsible.ReUserObjectID, typeof(ResUser));
                    mainStoreDefinition.GoodsResponsible = resUser;
                }


                foreach (StoreSMSUser item in mainStoreDefinition.StoreSMSUsers.Select(string.Empty))
                {
                    ((ITTObject)item).Delete();
                }
                foreach (SmsUserDTO smsUser in input.StoreSMSUsers)
                {
                    StoreSMSUser storeSMSUser = new StoreSMSUser(objectContext);
                    storeSMSUser.ResUser = objectContext.GetObject<ResUser>(smsUser.ResUserObjectID);
                    storeSMSUser.Store = mainStoreDefinition;
                }


                objectContext.Save();
                objectContext.Dispose();
                return "Ana Depo Kayıt İşlemi Yapılmıştır";
            }
            catch (Exception ex)
            {
                return ex.Message + "-- Ana Depo Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }




        public class MainStoreDefinitionListDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }

        public class GetMainStoreDefinition
        {
            public List<MainStoreDefinitionListDTO> mainStoreDefinitionListDTOs { get; set; }
            public List<ResUserDataSource> ResUserDataSources { get; set; }
            public List<AccoutancyDataSource> AccotuntancyDataSource { get; set; }
        }
        public class GetMainStoreDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        public class MainStoreDefinitionOutputItem
        {
            public bool? isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public string Qref { get; set; }
            public bool? IsActive { get; set; }
            public string StoreCode { get; set; }
            public Guid Accountancy { get; set; }
            public MKYS_EEntegrasyonDurumuEnum? IntegrationScope { get; set; }
            public int? StoreRecordNo { get; set; }
            public int? UnitRecordNo { get; set; }
            public MKYS_EButceTurEnum? MKYS_ButceTuru { get; set; }
            public OpenCloseEnum? Status { get; set; }
            public StoreResponsibleDTO GoodsAccountant { get; set; }
            public StoreResponsibleDTO GoodsResponsible { get; set; }
            public StoreResponsibleDTO AccountManager { get; set; }
            public List<SmsUserDTO> StoreSMSUsers { get; set; }
        }

        public class SmsUserDTO
        {
            public Guid StoreSmsUserObjectID { get; set; }
            public Guid ResUserObjectID { get; set; }
            public string ResUserName { get; set; }
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

        public class AccoutancyDataSource
        {
            public Guid ObjectID { get; set; }
            public string AccountancyName { get; set; }
        }
    }
}
