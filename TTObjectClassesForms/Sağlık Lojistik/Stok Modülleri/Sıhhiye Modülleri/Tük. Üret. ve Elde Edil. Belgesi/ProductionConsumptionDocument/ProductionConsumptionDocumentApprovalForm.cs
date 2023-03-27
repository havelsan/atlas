
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi
    /// </summary>
    public partial class ProductionConsumptionDocumentApprovalForm : BaseProductionConsumptionDocumentForm
    {
        protected override void PreScript()
        {
#region ProductionConsumptionDocumentApprovalForm_PreScript
    base.PreScript();
            this.DropStateButton (ProductionConsumptionDocument.States.Completed);
            if (_ProductionConsumptionDocument.ProductionDepStoreObjectID != null)
            {
                this.DropStateButton (ProductionConsumptionDocument.States.New);
                this.DropStateButton (ProductionConsumptionDocument.States.Cancelled);
            }
            
            if (_ProductionConsumptionDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;

                stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_ProductionConsumptionDocument.DestinationStore).GoodsAccountant;

                stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                {
                    ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                        stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                }

                stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikMalSorumlusu;
                if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_ProductionConsumptionDocument.DestinationStore).GoodsResponsible;

                stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_ProductionConsumptionDocument.Store is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_ProductionConsumptionDocument.Store).StoreResponsible;
                else if (_ProductionConsumptionDocument.Store is PharmacyStoreDefinition)
                    stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_ProductionConsumptionDocument.Store).StoreResponsible;
            }
#endregion ProductionConsumptionDocumentApprovalForm_PreScript

            }
                }
}