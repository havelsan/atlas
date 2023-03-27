using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using TTDataDictionary;
using System.Drawing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class MainViewController : Controller
    {

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool CheckSecurity()
        {
            TTStorageManager.Security.TTUser currentUser = TTStorageManager.Security.TTUser.CurrentUser;
            return currentUser.HasRole(TTRoleNames.MKYS_Entegrasyon_Yonetimi);
        }


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MainViewModel GetRoleControlMain()
        {
            MainViewModel model = new MainViewModel();
            if (TTUser.CurrentUser.HasRole(TTRoleNames.Stok_Is_Listesi) != true)
            {
                model.hasRoleStockWorkList = false;
            }
            else
            {
                model.hasRoleStockWorkList = true;
            }
            if (TTUser.CurrentUser.HasRole(TTRoleNames.Ilac_Vademecum_Tanimlari) != true)
            {
                model.hasRoleDefinitions = false;
            }
            else
            {
                model.hasRoleDefinitions = true;
            }
            if (TTUser.CurrentUser.HasRole(TTRoleNames.Dashboard_Ana_Ekran) != true)
            {
                model.hasRoleDashboard = false;
            }
            else
            {
                model.hasRoleDashboard = true;
            }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.MKYS_Entegrasyon_Yonetimi) != true)
            {
                model.hasRoleMkysIntegration = false;
            }
            else
            {
                model.hasRoleMkysIntegration = true;
            }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.Satinalma_Yonetimi) != true)
            {
                model.hasRoleSupplyRequestManager = false;
            }
            else
            {
                model.hasRoleSupplyRequestManager = true;
            }

            if (HasSpecialRole(TTRoleNames.Lojistik_Veri_Duzeltme_Yetkisi)) // Lojistik Veri Düzeltme Yetkisi
            {
                model.hasRoleLogisticAddAndUpdate = true;
            }
            else
            {
                model.hasRoleLogisticAddAndUpdate = false;
            }


            return model;
        }

        public bool HasSpecialRole(string roleID)
        {
            var id = Guid.Parse(roleID);
            return ((TTUser)Common.CurrentUser).AllRoles.ContainsKey(id);
        }

        [HttpPost]
        public int GetUserOptionStockMenuValue()
        {
            using (var context = new TTObjectContext(false))
            {
                ResUser resUser = (ResUser)context.GetObject(TTUser.CurrentUser.TTObjectID.Value, typeof(ResUser));
                var ret = Common.GetUserOptionValue(context, resUser, UserOptionType.StockMenu);
                context.FullPartialllyLoadedObjects();
                if (ret != null)
                    return Convert.ToInt32(ret);
                else
                    return 2;
            }
        }

        [HttpPost]
        public void SaveUserOptionStockMenuValue(string userOptionValue)
        {
            ResUser myUser = Common.CurrentResource;
            myUser.SaveUserOption(UserOptionType.StockMenu, userOptionValue);
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ControlOfDefinitionRole GetRoleControlDefinitionSet()
        {
            ControlOfDefinitionRole role = new ControlOfDefinitionRole();
            if (TTUser.CurrentUser.HasRole(TTRoleNames.Ilac_Vademecum_Tanimlari) != true)  { role.DrugDefinitionNewAdd = false; }
            else { role.DrugDefinitionNewAdd = true; }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.Sarf_Edilebilen_Malzeme_Tanimlari) != true) { role.ConsumableMaterialNewAdd = false; }
            else { role.ConsumableMaterialNewAdd = true; }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.Firma_Tanimlama) != true) { role.SupplierAndProducreNewAdd = false; }
            else { role.SupplierAndProducreNewAdd = true; }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.Malzeme_Grup_Tanimlari) != true) { role.MaterialTreeDefinitionAdd = false; }
            else { role.MaterialTreeDefinitionAdd = true; }


            return role;
        }

        public class ControlOfDefinitionRole
        {
            public bool DrugDefinitionNewAdd { get; set; }
            public bool ConsumableMaterialNewAdd { get; set; }
            public bool SupplierAndProducreNewAdd { get; set; }
            public bool MaterialTreeDefinitionAdd { get; set; }
        }
    }
}