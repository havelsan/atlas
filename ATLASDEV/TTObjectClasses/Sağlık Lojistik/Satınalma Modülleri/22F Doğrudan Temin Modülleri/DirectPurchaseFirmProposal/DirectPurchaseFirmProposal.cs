
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Doğrudan Temin Teklifi Veren Firma
    /// </summary>
    public  partial class DirectPurchaseFirmProposal : TTObject
    {
        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();
            IList<DPADetailFirmPriceOffer> priceOffersList = new List<DPADetailFirmPriceOffer>();
            foreach(DPADetailFirmPriceOffer priceOffer in DPADetailFirmPriceOffers)
            {
                priceOffersList.Add((DPADetailFirmPriceOffer)priceOffer);
            }
            
            foreach(DPADetailFirmPriceOffer deletedPriceOffer in priceOffersList)
            {
                ((ITTObject)deletedPriceOffer).Delete();
            }
#endregion PreDelete
        }

    }
}