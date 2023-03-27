
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
    /// Vezne İade Türü Tanımı
    /// </summary>
    public partial class MainCashOfficeBackTypeForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            AccountEntegration.CheckedChanged += new TTControlEventDelegate(AccountEntegration_CheckedChanged);
            IsBankOperation.CheckedChanged += new TTControlEventDelegate(IsBankOperation_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AccountEntegration.CheckedChanged -= new TTControlEventDelegate(AccountEntegration_CheckedChanged);
            IsBankOperation.CheckedChanged -= new TTControlEventDelegate(IsBankOperation_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void AccountEntegration_CheckedChanged()
        {
#region MainCashOfficeBackTypeForm_AccountEntegration_CheckedChanged
   if(this.AccountEntegration.Value == true)
            {
                this.ACCOUNTCODE.ReadOnly = false;
                this.ACCOUNTCODE.Required = true;
                
                this.DEBTACCOUNTCODE.ReadOnly = false;
                this.DEBTACCOUNTCODE.Required = true;
            }
            else
            {
                this.ACCOUNTCODE.Text = "";
                this.ACCOUNTCODE.ReadOnly = true;
                this.ACCOUNTCODE.Required = false;
                
                this.DEBTACCOUNTCODE.Text = "";
                this.DEBTACCOUNTCODE.ReadOnly = true;
                this.DEBTACCOUNTCODE.Required = false;
            }
#endregion MainCashOfficeBackTypeForm_AccountEntegration_CheckedChanged
        }

        private void IsBankOperation_CheckedChanged()
        {
#region MainCashOfficeBackTypeForm_IsBankOperation_CheckedChanged
   if(this.IsBankOperation.Value == true)
            {
                this.AccountEntegration.ReadOnly = true;
                this.AccountEntegration.Value = true;
                
                this.ACCOUNTCODE.Text = "";
                this.DEBTACCOUNTCODE.Text = "";
            }
            else
            {
                this.AccountEntegration.ReadOnly = false;
                this.AccountEntegration.Value = false;
            }
            
            this.ACCOUNTCODE.ReadOnly = true;
            this.ACCOUNTCODE.Required = false;
            
            this.DEBTACCOUNTCODE.ReadOnly = true;
            this.DEBTACCOUNTCODE.Required = false;
#endregion MainCashOfficeBackTypeForm_IsBankOperation_CheckedChanged
        }

        protected override void PreScript()
        {
#region MainCashOfficeBackTypeForm_PreScript
    base.PreScript();
            
            Guid SiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if(Sites.SiteMerkezSagKom.Equals(SiteGuid))
            {
                if (this.IsBankOperation.Value == true)
                {
                    this.AccountEntegration.ReadOnly = true;
                    this.AccountEntegration.Value = true;
                    
                    this.ACCOUNTCODE.ReadOnly = true;
                    this.ACCOUNTCODE.Required = false;
                    
                    this.DEBTACCOUNTCODE.ReadOnly = true;
                    this.DEBTACCOUNTCODE.Required = false;
                }
                else
                {
                    this.AccountEntegration.ReadOnly = false;
                    
                    if (this.AccountEntegration.Value == true)
                    {
                        this.ACCOUNTCODE.ReadOnly = false;
                        this.ACCOUNTCODE.Required = true;
                        
                        this.DEBTACCOUNTCODE.ReadOnly = false;
                        this.DEBTACCOUNTCODE.Required = true;
                    }
                    else
                    {
                        this.ACCOUNTCODE.ReadOnly = true;
                        this.ACCOUNTCODE.Required = false;
                        
                        this.DEBTACCOUNTCODE.ReadOnly = true;
                        this.DEBTACCOUNTCODE.Required = false;
                    }
                }
            }
#endregion MainCashOfficeBackTypeForm_PreScript

            }
                }
}