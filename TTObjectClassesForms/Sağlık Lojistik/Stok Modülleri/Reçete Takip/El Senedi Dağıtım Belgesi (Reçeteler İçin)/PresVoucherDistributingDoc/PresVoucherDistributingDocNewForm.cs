
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
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresVoucherDistributingDocNewForm : BasePresVoucherDistributingDocForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region PresVoucherDistributingDocNewForm_PreScript
    base.PreScript();
            ((ITTListBoxColumn)((ITTGridColumn)this.PresVoucherDistDocMaterials.Columns[MaterialPresVoucherDistDocMaterial.Name])).ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._VoucherDistributingDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0";

            if (_VoucherDistributingDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _VoucherDistributingDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                if (_VoucherDistributingDocument.Store is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition )_VoucherDistributingDocument.Store).StoreResponsible;

                stockActionSignDetail = _VoucherDistributingDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_VoucherDistributingDocument.Store is RoomStoreDefinition)
                    stockActionSignDetail.SignUser = ((RoomStoreDefinition)_VoucherDistributingDocument.DestinationStore).StoreResponsible;
            }
#endregion PresVoucherDistributingDocNewForm_PreScript

            }
                }
}