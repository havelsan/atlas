
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
    /// Muvakkaten Sayım Düzeltme Belgesi
    /// </summary>
    public partial class ConsignedCensusFixedForm : BaseConsignedCensusFixed
    {
        protected override void PreScript()
        {
#region ConsignedCensusFixedForm_PreScript
    base.PreScript();

            if (this._ConsignedCensusFixed.CurrentStateDefID == ConsignedCensusFixed.States.New)
                ((ITTListBoxColumn)((ITTGridColumn)this.StockActionOutDetails.Columns[MaterialOut.Name])).ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._ConsignedCensusFixed.Store.ObjectID) + " AND STOCKS.INHELD>0";


            if (_StockAction.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_StockAction.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_StockAction.DestinationStore).GoodsAccountant;

                stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_StockAction.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_StockAction.DestinationStore).GoodsResponsible;

                stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_StockAction.DestinationStore is MainStoreDefinition)
                {
                    ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    if (user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                        stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                }

                stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;
                stockActionSignDetail.SignUser = null;
            }
#endregion ConsignedCensusFixedForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsignedCensusFixedForm_PostScript
    base.PostScript(transDef);

            if (this._ConsignedCensusFixed.CurrentStateDefID == ConsignedCensusFixed.States.New && transDef != null)
                if (this._ConsignedCensusFixed.ConsignedCensusFixedInMaterials.Count == 0 && this._ConsignedCensusFixed.ConsignedCensusFixedOutMaterials.Count == 0)
                    throw new TTUtils.TTException("Sayım Düzeltme Belgesi en az bir tane Arttırılanlar yada Eksiltilenler içermelidir");


            string errorMessage = string.Empty;
            foreach (ConsignedCensusFixedMaterialIn consignedCensusFixedMaterialIn in _ConsignedCensusFixed.ConsignedCensusFixedInMaterials)
            {
                if (consignedCensusFixedMaterialIn.CensusAmount <= consignedCensusFixedMaterialIn.CardAmount)
                {
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Sayılan Miktar, Stok Kayıt Kart Nevi'nden küçük olamaz.\r\n";
                    errorMessage += "İlaç/Malzeme : " + consignedCensusFixedMaterialIn.Material.StockCard.NATOStockNO + " " + consignedCensusFixedMaterialIn.Material.Name + "\r\nSayılan Miktar : " + consignedCensusFixedMaterialIn.CensusAmount + "\r\nStok Kayıt Kart Nevi : " + consignedCensusFixedMaterialIn.CardAmount;
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);

            errorMessage = string.Empty;
            foreach (ConsignedCensusFixedMaterialOut consignedCensusFixedMaterialOut in _ConsignedCensusFixed.ConsignedCensusFixedOutMaterials)
            {
                if (consignedCensusFixedMaterialOut.CensusAmount >= consignedCensusFixedMaterialOut.CardAmount)
                {
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Sayılan Miktar, Stok Kayıt Kart Nevi'nden büyük olamaz.\r\n";
                    errorMessage += "İlaç/Malzeme : " + consignedCensusFixedMaterialOut.Material.StockCard.NATOStockNO + " " + consignedCensusFixedMaterialOut.Material.Name + "\r\nSayılan Miktar : " + consignedCensusFixedMaterialOut.CensusAmount + "\r\nStok Kayıt Kart Nevi : " + consignedCensusFixedMaterialOut.CardAmount;
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);
#endregion ConsignedCensusFixedForm_PostScript

            }
                }
}