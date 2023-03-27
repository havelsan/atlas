
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
    /// Fiyat Tanımı
    /// </summary>
    public partial class PricingDetailForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            PRICELIST.SelectedObjectChanged += new TTControlEventDelegate(PRICELIST_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PRICELIST.SelectedObjectChanged -= new TTControlEventDelegate(PRICELIST_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void PRICELIST_SelectedObjectChanged()
        {
#region PricingDetailForm_PRICELIST_SelectedObjectChanged
   PricingListDefinition selectedPriceList = _PricingDetailDefinition.PricingList;
            string priceGroupList = null;

            _PricingDetailDefinition.PricingListGroup = null;

            if (selectedPriceList != null)
            {
                foreach (PricingListGroupDefinition pListGroup in selectedPriceList.PricingListGroups)
                {
                    priceGroupList = priceGroupList + "OBJECTID = '" + pListGroup.ObjectID.ToString() + "' OR ";
                }

                if (priceGroupList != null)
                {
                    priceGroupList = priceGroupList.Substring(0, (priceGroupList.Length - 3));
                    this.PRICEGROUP.ListFilterExpression = priceGroupList;
                }
                else
                    this.PRICEGROUP.ListFilterExpression = "OBJECTID is null ";
            }
#endregion PricingDetailForm_PRICELIST_SelectedObjectChanged
        }
    }
}