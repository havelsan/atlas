
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
    /// Dönem Açma / Kapatma
    /// </summary>
    public partial class TermOpenCloseActionForm : TTForm
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
#region TermOpenCloseActionForm_PreScript
    base.PreScript();
#endregion TermOpenCloseActionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region TermOpenCloseActionForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (((ITTObject)_TermOpenCloseAction).IsNew && _TermOpenCloseAction.CurrentStateDefID == TermOpenCloseAction.States.New)
            {
                MainStoreDefinition mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
                if (mainStore == null)
                    throw new Exception(SystemMessage.GetMessage(713));
                
                AccountingTerm halfOpenTerm = mainStore.Accountancy.GetHalfOpenAccountingTerm();
                if(halfOpenTerm == null)
                {
                    AccountingTerm closingTerm = mainStore.Accountancy.GetOpenAccountingTerm();
                    if (closingTerm != null)
                    {
                        _TermOpenCloseAction.CloseTerm = closingTerm;
                        _TermOpenCloseAction.OpenTerm = new AccountingTerm(_TermOpenCloseAction.ObjectContext);
                        _TermOpenCloseAction.OpenTerm.CostingMethod = _TermOpenCloseAction.CloseTerm.CostingMethod;
                        _TermOpenCloseAction.OpenTerm.Accountancy = _TermOpenCloseAction.CloseTerm.Accountancy;
                        _TermOpenCloseAction.OpenTerm.StartDate = ((DateTime)_TermOpenCloseAction.CloseTerm.EndDate).AddDays(1);
                        _TermOpenCloseAction.OpenTerm.IsFirstTerm = false;
                    }
                    else
                    {
                        if (mainStore.Accountancy.AccountingTerms.Count > 0)
                        {
                            foreach (AccountingTerm accountingTerm in mainStore.Accountancy.AccountingTerms)
                                if (accountingTerm.IsFirstTerm.HasValue && accountingTerm.IsFirstTerm.Value == true)
                                throw new Exception(SystemMessage.GetMessage(926));
                        }
                        _TermOpenCloseAction.OpenTerm = new AccountingTerm(_TermOpenCloseAction.ObjectContext);
                        _TermOpenCloseAction.OpenTerm.Accountancy = mainStore.Accountancy;
                        _TermOpenCloseAction.OpenTerm.CostingMethod = CostingMethodEnum.FIFO;
                        _TermOpenCloseAction.OpenTerm.IsFirstTerm = true;
                    }
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(927));
                }
            }
#endregion TermOpenCloseActionForm_ClientSidePreScript

        }
    }
}