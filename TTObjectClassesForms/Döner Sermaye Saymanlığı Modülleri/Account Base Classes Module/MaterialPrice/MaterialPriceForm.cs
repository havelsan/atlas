
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
    /// Malzeme Fiyat Eşleştirme
    /// </summary>
    public partial class MaterialPriceForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            PricingDetailDefinitionList.SelectedObjectChanged += new TTControlEventDelegate(PricingDetailDefinitionList_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PricingDetailDefinitionList.SelectedObjectChanged -= new TTControlEventDelegate(PricingDetailDefinitionList_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void PricingDetailDefinitionList_SelectedObjectChanged()
        {
#region MaterialPriceForm_PricingDetailDefinitionList_SelectedObjectChanged
   if (this.PricingDetailDefinitionList.SelectedObjectID != null)
            {
                PricingDetailDefinition priceDet = (PricingDetailDefinition) PricingDetailDefinition.GetPricingDetailDefinitionByObjectID(this._MaterialPrice.ObjectContext, this.PricingDetailDefinitionList.SelectedObjectID.ToString())[0];
                if (priceDet != null && priceDet.PricingList != null)
                {
                    this.PRICELIST.ControlValue = priceDet.PricingList.Code + " " +  priceDet.PricingList.Name;
                    this.PRICELISTGROUP.ControlValue = priceDet.PricingListGroup.ExternalCode + " " + priceDet.PricingListGroup.Description;
                    this.STARTDATE.ControlValue = priceDet.DateStart;
                    this.ENDDATE.ControlValue = priceDet.DateEnd;
                    this.PRICE.ControlValue = priceDet.Price + " " + priceDet.CurrencyType.Qref;
                }
                else
                {
                    this.PRICELIST.ControlValue = "";
                    this.PRICELISTGROUP.ControlValue = "";
                    this.STARTDATE.ControlValue = null;
                    this.ENDDATE.ControlValue = null;
                    this.PRICE.ControlValue = "";
                }
            }
#endregion MaterialPriceForm_PricingDetailDefinitionList_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region MaterialPriceForm_PreScript
    base.PreScript();
            
            this.PRICELIST.ControlValue = string.Empty;
            this.PRICELISTGROUP.ControlValue = string.Empty;
            this.STARTDATE.ControlValue = null;
            this.ENDDATE.ControlValue = null;
            this.PRICE.ControlValue = string.Empty;
            
            if (this.PricingDetailDefinitionList.SelectedObjectID != null)
            {
                PricingDetailDefinition priceDet = (PricingDetailDefinition) PricingDetailDefinition.GetPricingDetailDefinitionByObjectID(this._MaterialPrice.ObjectContext, this.PricingDetailDefinitionList.SelectedObjectID.ToString())[0];
                if (priceDet != null)
                {
                    if(priceDet.PricingList != null)
                        this.PRICELIST.ControlValue = priceDet.PricingList.Code + " " +  priceDet.PricingList.Name;
                    
                    if(priceDet.PricingListGroup != null)
                        this.PRICELISTGROUP.ControlValue = priceDet.PricingListGroup.ExternalCode + " " + priceDet.PricingListGroup.Description;
                    
                    this.STARTDATE.ControlValue = priceDet.DateStart;
                    this.ENDDATE.ControlValue = priceDet.DateEnd;
                    
                    if(priceDet.CurrencyType != null)
                        this.PRICE.ControlValue = priceDet.Price + " " + priceDet.CurrencyType.Qref;
                    else
                        this.PRICE.ControlValue = priceDet.Price;
                }
            }
#endregion MaterialPriceForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MaterialPriceForm_PostScript
    base.PostScript(transDef);
            // Malzeme ve ilacın aynı fiyatla ikinci kez eşleştirilmemesi için kontrol
            TTObjectContext context = new TTObjectContext(true);
            BindingList<MaterialPrice> prices = MaterialPrice.GetMaterialPriceByMaterial(context, _MaterialPrice.Material.ObjectID.ToString());
            foreach (MaterialPrice mp in prices)
            {
                if (Common.RecTime() >= mp.PricingDetail.DateStart && Common.RecTime() <= mp.PricingDetail.DateEnd && _MaterialPrice.PricingDetail.ObjectID == mp.PricingDetail.ObjectID && _MaterialPrice.ObjectID != mp.ObjectID)
                    throw new TTException(SystemMessage.GetMessage(1268));
            }
#endregion MaterialPriceForm_PostScript

            }
                }
}