
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
    /// Fatura Bilgilerini Muhasebeye Gönderme
    /// </summary>
    public partial class SendingInvToAccountingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            CLEARALL.Click += new TTControlEventDelegate(CLEARALL_Click);
            SELECTALL.Click += new TTControlEventDelegate(SELECTALL_Click);
            LIST.Click += new TTControlEventDelegate(LIST_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CLEARALL.Click -= new TTControlEventDelegate(CLEARALL_Click);
            SELECTALL.Click -= new TTControlEventDelegate(SELECTALL_Click);
            LIST.Click -= new TTControlEventDelegate(LIST_Click);
            base.UnBindControlEvents();
        }

        private void CLEARALL_Click()
        {
#region SendingInvToAccountingForm_CLEARALL_Click
   if(this._SendingInvoiceToAccounting.CurrentStateDefID == SendingInvoiceToAccounting.States.New)
            {
                foreach(SendingInvoiceDetails sendingInvDets in this._SendingInvoiceToAccounting.SendingInvoiceDetails)
                {
                   sendingInvDets.Send = false ;
                }
            }
#endregion SendingInvToAccountingForm_CLEARALL_Click
        }

        private void SELECTALL_Click()
        {
#region SendingInvToAccountingForm_SELECTALL_Click
   if(this._SendingInvoiceToAccounting.CurrentStateDefID == SendingInvoiceToAccounting.States.New)
            {
                foreach(SendingInvoiceDetails sendingInvDets in this._SendingInvoiceToAccounting.SendingInvoiceDetails)
                {
                   sendingInvDets.Send = true ;
                }
            }
#endregion SendingInvToAccountingForm_SELECTALL_Click
        }

        private void LIST_Click()
        {
#region SendingInvToAccountingForm_LIST_Click
   if (this._SendingInvoiceToAccounting.CurrentStateDefID == SendingInvoiceToAccounting.States.New)
            {
                DateTime sDate;
                DateTime eDate;
                if(this._SendingInvoiceToAccounting.StartDate == null || this._SendingInvoiceToAccounting.EndDate == null)
                {
                    TTVisual.InfoBox.Show("Başlangıç ve Bitiş tarihlerini seçmelisiniz!", MessageIconEnum.ErrorMessage);
                }
                else
                {
                    this._SendingInvoiceToAccounting.SendingInvoiceDetails.DeleteChildren();
                    sDate = Convert.ToDateTime(this._SendingInvoiceToAccounting.StartDate.Value.ToString("yyyy-MM-dd 00:00:00")) ;
                    eDate = Convert.ToDateTime(this._SendingInvoiceToAccounting.EndDate.Value.ToString("yyyy-MM-dd 23:59:59")) ;
                    IList payerDocumentList = null;
                    IList collectedDocumentList = null;
                    IList generalDocumentList = null;
                    
                    payerDocumentList = PayerInvoiceDocument.GetByDate(_SendingInvoiceToAccounting.ObjectContext,(DateTime)sDate,(DateTime)eDate);
                    collectedDocumentList = CollectedInvoiceDocument.GetByDate(_SendingInvoiceToAccounting.ObjectContext,(DateTime)sDate,(DateTime)eDate);
                    generalDocumentList = GeneralInvoiceDocument.GetByDate(_SendingInvoiceToAccounting.ObjectContext,(DateTime)sDate,(DateTime)eDate);
                    
                    foreach(CollectedInvoiceDocument colInvDoc in collectedDocumentList)
                    {
                        SendingInvoiceDetails sendingInvDets = new SendingInvoiceDetails(_SendingInvoiceToAccounting.ObjectContext);
                        sendingInvDets.InvoiceDate = (DateTime)colInvDoc.DocumentDate;
                        sendingInvDets.InvoiceNo = colInvDoc.DocumentNo;
                        sendingInvDets.InvoicePrice = colInvDoc.TotalPrice;
                        sendingInvDets.Send = false;
                        sendingInvDets.PayerDefinition = colInvDoc.Payer;
                        
                        sendingInvDets.CollectedInvoiceDocument = colInvDoc;
                        this._SendingInvoiceToAccounting.SendingInvoiceDetails.Add(sendingInvDets);
                    }
                    
                    foreach(PayerInvoiceDocument payInvDoc in payerDocumentList)
                    {
                        SendingInvoiceDetails sendingInvDets = new SendingInvoiceDetails(_SendingInvoiceToAccounting.ObjectContext);
                        sendingInvDets.InvoiceDate = (DateTime)payInvDoc.DocumentDate;
                        sendingInvDets.InvoiceNo = payInvDoc.DocumentNo;
                        sendingInvDets.InvoicePrice = payInvDoc.GeneralTotalPrice;
                        sendingInvDets.Send = false;
                        sendingInvDets.PayerDefinition = payInvDoc.Payer;
                        sendingInvDets.Episode = payInvDoc.EpisodeAccountAction.Episode;
                        
                        sendingInvDets.PayerInvoiceDocument = payInvDoc;
                        this._SendingInvoiceToAccounting.SendingInvoiceDetails.Add(sendingInvDets);
                    }

                    foreach(GeneralInvoiceDocument genInvDoc in generalDocumentList)
                    {
                        SendingInvoiceDetails sendingInvDets = new SendingInvoiceDetails(_SendingInvoiceToAccounting.ObjectContext);
                        sendingInvDets.InvoiceDate = (DateTime)genInvDoc.DocumentDate;
                        sendingInvDets.InvoiceNo = genInvDoc.DocumentNo;
                        sendingInvDets.InvoicePrice = genInvDoc.TotalPrice;
                        sendingInvDets.Send = false;
                        sendingInvDets.PayerDefinition = ((GeneralInvoice)genInvDoc.AccountAction).Payer;
                        
                        sendingInvDets.GeneralInvoiceDocument = genInvDoc;
                        this._SendingInvoiceToAccounting.SendingInvoiceDetails.Add(sendingInvDets);
                    }
                }

            }
#endregion SendingInvToAccountingForm_LIST_Click
        }

        protected override void PreScript()
        {
#region SendingInvToAccountingForm_PreScript
    base.PreScript();
            if(this._SendingInvoiceToAccounting.CurrentStateDefID == SendingInvoiceToAccounting.States.New)
            {
                this.cmdOK.Visible = false;
                this._SendingInvoiceToAccounting.StartDate = DateTime.Now;
                this._SendingInvoiceToAccounting.EndDate = DateTime.Now;
            }
#endregion SendingInvToAccountingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SendingInvToAccountingForm_PostScript
    base.PostScript(transDef);
            bool checkedFound = false;
            foreach(SendingInvoiceDetails sendingInvDets in this._SendingInvoiceToAccounting.SendingInvoiceDetails)
            {
                if(sendingInvDets.Send == true)
                {
                    checkedFound = true;
                    break;
                }
            }
            if (!checkedFound)
                throw new TTException(SystemMessage.GetMessage(472));
#endregion SendingInvToAccountingForm_PostScript

            }
                }
}