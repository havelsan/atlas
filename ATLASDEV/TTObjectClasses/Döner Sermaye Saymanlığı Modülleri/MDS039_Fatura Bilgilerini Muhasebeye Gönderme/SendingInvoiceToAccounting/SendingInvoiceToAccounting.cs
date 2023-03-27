
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
    /// Fatura Bilgilerini Muhasebeye Gönderme
    /// </summary>
    public  partial class SendingInvoiceToAccounting : AccountAction, IWorkListBaseAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                IList<AccountDocument.InvoiceInfo> InvoiceList = new List<AccountDocument.InvoiceInfo>();
                AccountDocument.InvoiceInfo II;
                
                foreach(SendingInvoiceDetails sendingInvDets in SendingInvoiceDetails)
                {
                    if(sendingInvDets.Send == true)
                    {
                        II = null;
                        if(sendingInvDets.PayerInvoiceDocument != null)
                        {
                            //II = sendingInvDets.PayerInvoiceDocument.CreateInvoiceInfoForAccounting();
                            if (II != null)
                            {
                                InvoiceList.Add(II);
                                sendingInvDets.PayerInvoiceDocument.SendToAccounting = true;
                            }
                        }
                        else if(sendingInvDets.CollectedInvoiceDocument != null)
                        {
                            II = sendingInvDets.CollectedInvoiceDocument.CreateInvoiceInfoForAccounting();
                            if (II != null)
                            {
                                InvoiceList.Add(II);
                                sendingInvDets.CollectedInvoiceDocument.SendToAccounting = true;
                            }
                        }
                        else if(sendingInvDets.GeneralInvoiceDocument != null)
                        {
                            II = sendingInvDets.GeneralInvoiceDocument.CreateInvoiceInfoForAccounting();
                            if (II != null)
                            {
                                InvoiceList.Add(II);
                                sendingInvDets.GeneralInvoiceDocument.SendToAccounting = true;
                            }
                        }
                    }
                }
                
                if (InvoiceList.Count > 0)
                {
                    //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateInvoice", null, InvoiceList);
                    //TTMessageFactory.SyncCall(Sites.SiteLocalHost, "Invoice.Integration", "InvoiceUtils", "CreateInvoice", InvoiceList);
                }
            }
            else
                throw new TTException(SystemMessage.GetMessage(134));

#endregion PostTransition_New2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SendingInvoiceToAccounting).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SendingInvoiceToAccounting.States.New && toState == SendingInvoiceToAccounting.States.Completed)
                PostTransition_New2Completed();
        }

    }
}