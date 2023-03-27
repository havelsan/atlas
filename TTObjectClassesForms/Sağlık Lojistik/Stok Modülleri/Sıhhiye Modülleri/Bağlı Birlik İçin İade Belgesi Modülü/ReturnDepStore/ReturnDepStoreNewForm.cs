
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
    /// Bağlı Birlik İçin İade Belgesi
    /// </summary>
    public partial class ReturnDepStoreNewForm : BaseReturnDepStoreForm
    {
        protected override void PreScript()
        {
#region ReturnDepStoreNewForm_PreScript
    base.PreScript();
            this.DropStateButton(ReturnDepStore.States.Completed);
            Material.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._ReturnDepStore.Store.ObjectID) + " AND STOCKS.INHELD > 0";

            IList terms = _ReturnDepStore.ObjectContext.QueryObjects("ACCOUNTINGTERM", "STATUS = 1");
            if (terms.Count > 0)
            {
                if (terms.Count == 1)
                {
                    _ReturnDepStore.AccountingTerm = (AccountingTerm)terms[0];
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
            if (_ReturnDepStore.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _ReturnDepStore.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                if (_ReturnDepStore.DestinationStore is IUnitStoreDefinition)
                    stockActionSignDetail.SignUser = ((IUnitStoreDefinition)_ReturnDepStore.DestinationStore).GetStoreResponsible();
            }
#endregion ReturnDepStoreNewForm_PreScript

            }
                }
}