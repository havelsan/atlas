
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
    /// Doğrudan Malzeme Tedarik 22F
    /// </summary>
    public partial class DirectMaterialSupplyNewForm : BaseDirectMaterialSupplyForm
    {

        protected override void ClientSidePreScript()
        {
            #region DirectMaterialSupplyNewForm_ClientSidePreScript()
            base.ClientSidePreScript();

           

            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Boş", "Boş", SupplyRequestTypeEnum.None);
            mSelectForm.AddMSItem("İlaç", "İlaç", SupplyRequestTypeEnum.Ilac);
            mSelectForm.AddMSItem("Sarf Malzeme", "Sarf Malzeme", SupplyRequestTypeEnum.sarfMalzeme);
            mSelectForm.AddMSItem("Demirbaş", "Demirbaş", SupplyRequestTypeEnum.demirbas);
           


            string mkey = mSelectForm.GetMSItem(this, "Malzeme türünü seçiniz. ", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme türünü seçmeden işleme devam edemezsiniz."));
            this._DirectMaterialSupplyAction.RequestType = (SupplyRequestTypeEnum)mSelectForm.MSSelectedItemObject;


            if (_DirectMaterialSupplyAction.RequestType == SupplyRequestTypeEnum.demirbas || _DirectMaterialSupplyAction.RequestType == SupplyRequestTypeEnum.Ilac || _DirectMaterialSupplyAction.RequestType == SupplyRequestTypeEnum.sarfMalzeme)
            {


                if (_DirectMaterialSupplyAction.RequestType == SupplyRequestTypeEnum.demirbas)
                    this.Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));
                if (_DirectMaterialSupplyAction.RequestType == SupplyRequestTypeEnum.Ilac)
                    this.Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));
                if (_DirectMaterialSupplyAction.RequestType == SupplyRequestTypeEnum.sarfMalzeme)
                    this.Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            }

            if (this._DirectMaterialSupplyAction.MasterResource.Store != null)
            {
                this._DirectMaterialSupplyAction.Store = this._DirectMaterialSupplyAction.MasterResource.Store;
            }
            else
            {
                throw new TTException(this._DirectMaterialSupplyAction.MasterResource.Store.Name + " biriminin bağlı olduğu depo bilgisine ulaşılamadı.");
            }



            #endregion DirectMaterialSupplyNewForm_ClientSidePreScript()
        }

        #region DirectMaterialSupplyNewForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {

            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == DirectMaterialSupplyAction.States.Request)
                {
                    this._DirectMaterialSupplyAction.Send22F_SupplyRequestToXXXXXX(this._DirectMaterialSupplyAction);
                }
            }

            _DirectMaterialSupplyAction.ObjectContext.Save();
        }

        #endregion DirectMaterialSupplyNewForm_Methods


    }
}