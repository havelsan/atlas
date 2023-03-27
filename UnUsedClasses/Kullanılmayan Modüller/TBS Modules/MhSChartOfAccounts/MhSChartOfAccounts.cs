
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
    /// Hesap Planı
    /// </summary>
    public  partial class MhSChartOfAccounts : TTObject
    {
#region Methods
        public MhSChartOfAccounts CreateACopy(){
            MhSChartOfAccounts cChrt = new MhSChartOfAccounts(ObjectContext);
            
            cChrt.Comment = Comment;
            cChrt.Firm = Firm;
            cChrt.Name = Name;
            
            foreach(MhSAccount acc in Accounts){
                if(acc.ParentAccount == null){
                    MhSAccount copiedParent = acc.CreateACopyAccount();
                    cChrt.Accounts.Add(copiedParent);
                }
            }
            return cChrt;
        }
        public MhSAccount GetAccountByAccountCode(string code){
            foreach(MhSAccount account in Accounts){
                if(account.Code.Equals(code))
                    return account;
            }
            return null;
        }
        
#endregion Methods

    }
}