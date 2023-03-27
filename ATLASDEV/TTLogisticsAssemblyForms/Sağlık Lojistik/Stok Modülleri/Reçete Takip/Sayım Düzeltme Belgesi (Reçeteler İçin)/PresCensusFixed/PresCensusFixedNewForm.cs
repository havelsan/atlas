
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresCensusFixedNewForm : BasePresCensusFixedForm
    {
        protected override void PreScript()
        {
#region PresCensusFixedNewForm_PreScript
    base.PreScript();

            this.DropStateButton(CensusFixed.States.Completed);
            
            if (string.IsNullOrEmpty(_PresCensusFixed.Description))
            {
                _PresCensusFixed.Description = _PresCensusFixed.TransactionDate.Value.ToShortDateString() + " tarihinde yapılan sayım neticesi ile stok kayıt kartlarında kayıtlı bulunan mevcutlar arasındaki farktan dolayı yukarıdaki düzeltmenin yapılması gerektiğini beyan ederim.";
            }

            if (_PresCensusFixed.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _PresCensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_PresCensusFixed.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresCensusFixed.Store).GoodsAccountant;

                stockActionSignDetail = _PresCensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_PresCensusFixed.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresCensusFixed.Store).GoodsResponsible;

                stockActionSignDetail = _PresCensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_PresCensusFixed.Store is MainStoreDefinition)
                {
                    if (((MainStoreDefinition)_PresCensusFixed.Store).AccountManager != null)
                    {
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_PresCensusFixed.Store).AccountManager;
                    }
                    else
                    {
                        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                        if (user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                    }
                }

                stockActionSignDetail = _PresCensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;
                stockActionSignDetail.SignUser = null;
            }
#endregion PresCensusFixedNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PresCensusFixedNewForm_PostScript
    base.PostScript(transDef);
            
            if (this._PresCensusFixed.CurrentStateDefID == PresCensusFixed.States.New && transDef != null)
                if (this._PresCensusFixed.PresCensusFixedInMaterials.Count == 0 && this._PresCensusFixed.PresCensusFixedOutMaterials.Count == 0)
                throw new TTUtils.TTException("Sayım Düzeltme Belgesi en az bir tane Arttırılanlar yada Eksiltilenler içermelidir");


            string errorMessage = string.Empty;
            foreach (PresCensusFixedMaterialIn censusFixedMaterialIn in _PresCensusFixed.PresCensusFixedInMaterials)
            {
                if (censusFixedMaterialIn.CensusAmount <= censusFixedMaterialIn.CardAmount)
                {
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Sayılan Miktar, Stok Kayıt Kart Nevi'nden küçük olamaz.\r\n";
                    errorMessage += "İlaç/Malzeme : " + censusFixedMaterialIn.Material.StockCard.NATOStockNO + " " + censusFixedMaterialIn.Material.Name + "\r\nSayılan Miktar : " + censusFixedMaterialIn.CensusAmount + "\r\nStok Kayıt Kart Nevi : " + censusFixedMaterialIn.CardAmount;
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);

            errorMessage = string.Empty;
            foreach (PresCensusFixedMaterialOut censusFixedMaterialOut in _PresCensusFixed.PresCensusFixedOutMaterials)
            {
                if (censusFixedMaterialOut.CensusAmount >= censusFixedMaterialOut.CardAmount)
                {
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Sayılan Miktar, Stok Kayıt Kart Nevi'nden büyük olamaz.\r\n";
                    errorMessage += "İlaç/Malzeme : " + censusFixedMaterialOut.Material.StockCard.NATOStockNO + " " + censusFixedMaterialOut.Material.Name + "\r\nSayılan Miktar : " + censusFixedMaterialOut.CensusAmount + "\r\nStok Kayıt Kart Nevi : " + censusFixedMaterialOut.CardAmount;
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);
#endregion PresCensusFixedNewForm_PostScript

            }
                }
}