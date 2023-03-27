
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
    /// Veznenin açılış kapanış izini tutar
    /// </summary>
    public  partial class CashierLog : TTObject
    {
#region Methods
        override protected void OnConstruct()
        {
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                if (CurrentStateDefID == null)
                    CurrentStateDefID = CashierLog.States.Opened;
            }
        }
        
        public bool CashPaymentExists()
        {
            IList accDocs = AccountDocument.GetAllAccDocsByCashierLog(ObjectContext, ObjectID.ToString());
            foreach(AccountDocument accDoc in accDocs)
            {
                if(accDoc.GetCalculatedCashPayment(Convert.ToDateTime(accDoc.DocumentDate)) > 0)
                    return true;
            }
            
            return false;
        }
        
        public bool CreditCardPaymentExists()
        {
            IList accDocs = AccountDocument.GetAllAccDocsByCashierLog(ObjectContext, ObjectID.ToString());
            foreach(AccountDocument accDoc in accDocs)
            {
                if(accDoc.GetCalculatedCreditCardPayment() > 0)
                    return true;
            }
            
            return false;
        }
        
#endregion Methods

    }
}