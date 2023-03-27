
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
    /// Devir Teslim Belgesi
    /// </summary>
    public partial class HandoverDocumentForm : BaseHandoverDocumentForm
    {
        protected override void PreScript()
        {
#region HandoverDocumentForm_PreScript
    base.PreScript();

            if (((ITTObject)_HandoverDocument).IsNew)
            {
                if (_StockAction.StockActionSignDetails.Count == 0)
                {
                    StockActionSignDetail stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.Baskan;
                    stockActionSignDetail.SignUser = null;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.Uye;
                    stockActionSignDetail.SignUser = null;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.Uye;
                    stockActionSignDetail.SignUser = null;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                    stockActionSignDetail.SignUser = null;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                    stockActionSignDetail.SignUser = null;
                }

            }
#endregion HandoverDocumentForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region HandoverDocumentForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (((ITTObject)_HandoverDocument).IsNew)
            {
                HandoverTypeForm handoverTypeForm = new HandoverTypeForm();
                //handoverTypeForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                DialogResult dialogResult = handoverTypeForm.ShowEdit(this, _HandoverDocument, true);
                if (dialogResult == DialogResult.Cancel)
                    throw new Exception("Devir Teslim İşlemi İptal Edildi.");
                GetHandoverDetails();
            }
#endregion HandoverDocumentForm_ClientSidePreScript

        }

#region HandoverDocumentForm_Methods
        private void GetHandoverDetails()
        {
            string filterExpression = string.Empty;

            if (this._HandoverDocument.CensusOrderType == CensusOrderTypeEnum.HaveInheld)
                filterExpression = "AND INHELD > 0";
            else
                filterExpression = "AND INHELD > 0 AND CONSIGNED > 0";

            TTObjectContext objectContext = new TTObjectContext(false);

            IList stocks = Stock.GetCensusOrderStocks(objectContext, this._HandoverDocument.Store.ObjectID, this._HandoverDocument.CardDrawer.ObjectID, filterExpression);
            if (stocks.Count > 0)
            {
                foreach (Stock stock in stocks)
                {
                    HandoverDocumentDetail handoverDocumentDetail = new HandoverDocumentDetail(_HandoverDocument.ObjectContext);
                    handoverDocumentDetail.Material = stock.Material;
                    handoverDocumentDetail.Inheld = stock.Inheld;
                   _HandoverDocument.HandoverDocumentDetails.Add(handoverDocumentDetail);
                }
            }
        }
        
#endregion HandoverDocumentForm_Methods
    }
}