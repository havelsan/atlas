
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PrescriptionConsumptionDocumentApprovalForm : BasePrescriptionConsumptionDocumentForm
    {
        protected override void PreScript()
        {
#region PrescriptionConsumptionDocumentApprovalForm_PreScript
    base.PreScript();
           
            this.DropStateButton (PrescriptionConsumptionDocument.States.Completed);
            if (_PrescriptionConsumptionDocument.ProductionDepStoreObjectID != null)
            {
                this.DropStateButton(PrescriptionConsumptionDocument.States.New);
                this.DropStateButton(PrescriptionConsumptionDocument.States.Cancelled);
            }

            if (_PrescriptionConsumptionDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;

                stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_PrescriptionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PrescriptionConsumptionDocument.DestinationStore).GoodsAccountant;

                stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_PrescriptionConsumptionDocument.DestinationStore is MainStoreDefinition)
                {
                    ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                        stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                }

                stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikMalSorumlusu;
                if (_PrescriptionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_PrescriptionConsumptionDocument.DestinationStore).GoodsResponsible;

                stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_PrescriptionConsumptionDocument.Store is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_PrescriptionConsumptionDocument.Store).StoreResponsible;
                else if (_PrescriptionConsumptionDocument.Store is PharmacyStoreDefinition)
                    stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_PrescriptionConsumptionDocument.Store).StoreResponsible;
            }
#endregion PrescriptionConsumptionDocumentApprovalForm_PreScript

            }
                }
}