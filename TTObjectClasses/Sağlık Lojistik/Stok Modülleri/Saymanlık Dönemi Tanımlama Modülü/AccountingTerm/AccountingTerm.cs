
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
    /// Saymanlık Dönemi Tanımları
    /// </summary>
    public  partial class AccountingTerm : TTObject, IAccountingTerm
    {
        public int? TermYear
        {
            get
            {
                try
                {
#region TermYear_GetScript                    
                    int retValue = 0;
                    if (EndDate.HasValue)
                        return EndDate.Value.Year;
                    return retValue;
#endregion TermYear_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TermYear") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            

            //TODO: Açık ve Yarık açık hesap dönemlerinin açılıp açılmaması durumunu kontrol etmektedir.
            DateTime openStartDate = new DateTime();
            DateTime halfOpenStartDate = new DateTime();
            bool termcontrol = true;

            IList accountingTerms = Accountancy.AccountingTerms.Select("OBJECTID <> " + ConnectionManager.GuidToString(ObjectID) + " AND STATUS IN(1,2)");
            foreach (AccountingTerm accountingTerm in accountingTerms)
            {
                switch (Status)
                {
                    case AccountingTermStatusEnum.Open:
                        openStartDate = (DateTime)StartDate;
                        if (accountingTerm.Status == AccountingTermStatusEnum.HalfOpen)
                        {
                            termcontrol = false;
                            if (openStartDate <= accountingTerm.EndDate)
                                throw new TTException(SystemMessage.GetMessageV3(949, new string[] { accountingTerm.Accountancy.Name.ToString(), accountingTerm.StartDate.ToString(),accountingTerm.EndDate.ToString() })); 
                        }
                        if (openStartDate <= accountingTerm.EndDate)
                            throw new TTException(SystemMessage.GetMessageV3(949, new string[] { accountingTerm.Accountancy.Name.ToString(), accountingTerm.StartDate.ToString(), accountingTerm.EndDate.ToString() })); 
                        break;
                    case AccountingTermStatusEnum.HalfOpen:
                        halfOpenStartDate = (DateTime)StartDate;
                        if (accountingTerm.Status == AccountingTermStatusEnum.Open)
                        {
                            termcontrol = false;
                            if (halfOpenStartDate <= accountingTerm.EndDate)
                                throw new TTException(SystemMessage.GetMessageV3(949, new string[] { accountingTerm.Accountancy.Name.ToString(), accountingTerm.StartDate.ToString(), accountingTerm.EndDate.ToString() })); 
                        }
                        else if (halfOpenStartDate <= accountingTerm.EndDate && termcontrol == true)
                            throw new TTException(SystemMessage.GetMessageV3(949, new string[] { accountingTerm.Accountancy.Name.ToString(), accountingTerm.StartDate.ToString(), accountingTerm.EndDate.ToString() })); 
                        break;
                    default:
                        break;
                }
            }


#endregion PreInsert
        }

#region Methods
        #region IAccountingTerm Members

        IAccountancy IAccountingTerm.GetAccountancy()
        {
             return (IAccountancy)Accountancy; 
        }
        DateTime? IAccountingTerm.GetStartDate()
        {
            return StartDate;
        }
        DateTime? IAccountingTerm.GetEndDate()
        {
            return EndDate;
        }
        #endregion

        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion
        public override string ToString()
        {
            return "Saymanlık: " + Accountancy.Name.ToString() + "      Durum: " + Status.ToString() + "      Tarih: " + StartDate.ToString() + "   -   " + EndDate.ToString();
        }
        
#endregion Methods

    }
}