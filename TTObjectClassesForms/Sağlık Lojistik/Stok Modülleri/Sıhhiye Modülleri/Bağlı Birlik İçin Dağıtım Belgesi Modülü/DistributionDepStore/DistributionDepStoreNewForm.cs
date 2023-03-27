
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
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
    public partial class DistributionDepStoreNewForm : BaseDistributionDepStoreFrom
    {
        protected override void PreScript()
        {
#region DistributionDepStoreNewForm_PreScript
    base.PreScript();

            _DistributionDepStore.IsEntryOldMaterial = true;
            
            this.DropStateButton(DistributionDepStore.States.Completed);
            
            
            IList terms = _DistributionDepStore.ObjectContext.QueryObjects("ACCOUNTINGTERM", "STATUS = 1");
            if (terms.Count > 0)
            {
                if (terms.Count == 1)
                {
                    _DistributionDepStore.AccountingTerm = (AccountingTerm)terms[0];
                }
                else
                {
                    throw new TTException("Birden fazla açık hesap dönemi bulunmaktadır işleme devam edemezsiniz!");
                }
            }
            else
            {
                throw new TTException("Hiç açık hesap dönemi bulunmaktadır işleme devam edemezsiniz!");
            }
            if (_DistributionDepStore.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _DistributionDepStore.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_DistributionDepStore.DestinationStore is IUnitStoreDefinition)
                    stockActionSignDetail.SignUser = ((IUnitStoreDefinition)_DistributionDepStore.DestinationStore).GetStoreResponsible();
            }
#endregion DistributionDepStoreNewForm_PreScript

            }
                }
}