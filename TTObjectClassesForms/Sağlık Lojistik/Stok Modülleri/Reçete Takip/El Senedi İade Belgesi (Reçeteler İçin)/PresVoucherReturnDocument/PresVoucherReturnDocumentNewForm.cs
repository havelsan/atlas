
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
    /// El Senedi İade Belgesi (Reçeteler İçin) 
    /// </summary>
    public partial class PresVoucherReturnDocumentNewForm : BasePresVoucherReturnDocumentForm
    {
        protected override void PreScript()
        {
#region PresVoucherReturnDocumentNewForm_PreScript
    base.PreScript();
            
            ((ITTListBoxColumn)((ITTGridColumn)this.PresVoucherReturnDocumentMaterials.Columns["MaterialPresVoucherReturnDocMat"])).ListFilterExpression = "STOCKS.STORE='" + this._VoucherReturnDocument.Store.ObjectID.ToString() + "' AND STOCKS.INHELD>0";

            if (_VoucherReturnDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _VoucherReturnDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_VoucherReturnDocument.DestinationStore is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_VoucherReturnDocument.DestinationStore).StoreResponsible ;
                
                stockActionSignDetail = _VoucherReturnDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden ;
                if (_VoucherReturnDocument.Store is RoomStoreDefinition)
                    stockActionSignDetail.SignUser = ((RoomStoreDefinition)_VoucherReturnDocument.Store).StoreResponsible;
            }
#endregion PresVoucherReturnDocumentNewForm_PreScript

            }
                }
}