
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
    /// İhale Tarih ve Kayıt No Güncelleme
    /// </summary>
    public partial class tenderDateUpdateNewForm : BaseDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            ttbutton.Click += new TTControlEventDelegate(ttbutton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton.Click -= new TTControlEventDelegate(ttbutton_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton_Click()
        {
#region tenderDateUpdateNewForm_ttbutton_Click
   if(!string.IsNullOrEmpty(StockActionIDStockAction.Text))
            {
                IList <StockAction> stockaction = StockAction.GetTenderUpdateNQL(_TenderDateUpdate.ObjectContext,StockActionIDStockAction.Text);
                
                if(stockaction.Count > 0)
                {
                    
                    if(stockaction[0] is ChattelDocumentWithPurchase)
                    {
                        if(((ChattelDocumentWithPurchase)stockaction[0]).CurrentStateDefID != ChattelDocumentWithPurchase.States.Completed)
                        {
                            string message ="Girilen İşlem Numarasındaki Taşınır Mal Satınalma Yoluyla Giriş işlemi Tamamlandı durumunda değildir. İşlemi tekrar kontrol ediniz.!";
                            InfoBox.Show(message);
                        }
                        else
                        {
                            _TenderDateUpdate.StockAction = (StockAction)stockaction[0];
                            ChattelDocumentWithPurchase chattelDoc = (ChattelDocumentWithPurchase)stockaction[0];
                            if (chattelDoc.AuctionDate == null)
                            {
                                this.AuctionDate.ReadOnly = false;
                                this.AuctionDate.Required = true;

                            }
                            else
                                this._TenderDateUpdate.AuctionDate = ((DateTime)chattelDoc.AuctionDate);
                            
                            if(chattelDoc.RegistrationAuctionNo == null)
                            {
                                this.RegistrationAuctionNo.ReadOnly = false;
                                this.RegistrationAuctionNo.Required = true;
                            }
                            else
                                this._TenderDateUpdate.RegistrationAuctionNo = chattelDoc.RegistrationAuctionNo;
                        }
                        
                    }
                    else
                    {
                        string message ="Girilen İşlem Numarası, Taşınır Mal Satın Alma Yoluyla Giriş İşlemi Numarası Değildir !";
                        InfoBox.Show(message);
                    }
                }
            }
#endregion tenderDateUpdateNewForm_ttbutton_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region tenderDateUpdateNewForm_PostScript
    base.PostScript(transDef);
//            if(transDef != null)
//            {
//                if (_TenderDateUpdate.StockAction != null)
//                {
//                    if (_TenderDateUpdate.StockAction is ChattelDocumentWithPurchase)
//                    {
//                        ((ChattelDocumentWithPurchase)_TenderDateUpdate.StockAction).AuctionDate = _TenderDateUpdate.AuctionDate;
//                        ((ChattelDocumentWithPurchase)_TenderDateUpdate.StockAction).RegistrationAuctionNo  = _TenderDateUpdate.RegistrationAuctionNo;
//                        
//                    }
//                }
//            }
#endregion tenderDateUpdateNewForm_PostScript

            }
                }
}