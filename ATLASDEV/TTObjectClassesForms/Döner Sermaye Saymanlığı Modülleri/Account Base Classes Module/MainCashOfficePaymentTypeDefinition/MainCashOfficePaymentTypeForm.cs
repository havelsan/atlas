
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
    /// Vezne Tahsilat Türü Tanımı
    /// </summary>
    public partial class MainCashOfficePaymentTypeForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            AccountEntegration.CheckedChanged += new TTControlEventDelegate(AccountEntegration_CheckedChanged);
            IsBankOperation.CheckedChanged += new TTControlEventDelegate(IsBankOperation_CheckedChanged);
            IsSubCashOfficePayment.CheckedChanged += new TTControlEventDelegate(IsSubCashOfficePayment_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AccountEntegration.CheckedChanged -= new TTControlEventDelegate(AccountEntegration_CheckedChanged);
            IsBankOperation.CheckedChanged -= new TTControlEventDelegate(IsBankOperation_CheckedChanged);
            IsSubCashOfficePayment.CheckedChanged -= new TTControlEventDelegate(IsSubCashOfficePayment_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void AccountEntegration_CheckedChanged()
        {
#region MainCashOfficePaymentTypeForm_AccountEntegration_CheckedChanged
   if(this.AccountEntegration.Value == true)
            {
                this.RevenueSubAccountCode.ReadOnly = false;
                this.RevenueSubAccountCode.Required = true;
                 
            }
            else
            {
                this.RevenueSubAccountCode.Text = "";
                this.RevenueSubAccountCode.ReadOnly = true;
                this.RevenueSubAccountCode.Required = false;
                 
            }
#endregion MainCashOfficePaymentTypeForm_AccountEntegration_CheckedChanged
        }

        private void IsBankOperation_CheckedChanged()
        {
#region MainCashOfficePaymentTypeForm_IsBankOperation_CheckedChanged
   this.AccountEntegration.Value = false;
            this.IsSubCashOfficePayment.Value = false;
            this.IsChattel.Value = false;
            this.SubCashierCanDo.Value = false;
            
            this.RevenueSubAccountCode.Text = "";
            this.RevenueSubAccountCode.ReadOnly = true;
            this.RevenueSubAccountCode.Required = false;
             
            
            if (this.IsBankOperation.Value == true)
            {
                this.AccountEntegration.ReadOnly = true;
                this.IsSubCashOfficePayment.ReadOnly = true;
                this.IsChattel.ReadOnly = true;
                this.SubCashierCanDo.ReadOnly = true;
            }
            else
            {
                this.AccountEntegration.ReadOnly = false;
                this.IsSubCashOfficePayment.ReadOnly = false;
                this.IsChattel.ReadOnly = false;
                this.SubCashierCanDo.ReadOnly = false;
            }
#endregion MainCashOfficePaymentTypeForm_IsBankOperation_CheckedChanged
        }

        private void IsSubCashOfficePayment_CheckedChanged()
        {
#region MainCashOfficePaymentTypeForm_IsSubCashOfficePayment_CheckedChanged
   if(this.IsSubCashOfficePayment.Value == true)
            {
                this.AccountEntegration.Value = true;
                this.AccountEntegration.ReadOnly = true;
                this.IsBankOperation.ReadOnly = true;
                this.IsChattel.ReadOnly = true;
                this.SubCashierCanDo.ReadOnly = true;
            }
            else
            {
                this.AccountEntegration.Value = false;
                this.AccountEntegration.ReadOnly = false;
                this.IsBankOperation.ReadOnly = false;
                this.IsChattel.ReadOnly = false;
                this.SubCashierCanDo.ReadOnly = false;
            }
            
            this.IsBankOperation.Value = false;
            this.IsChattel.Value = false;
            this.SubCashierCanDo.Value = false;
            
            this.RevenueSubAccountCode.Text = "";
            this.RevenueSubAccountCode.ReadOnly = true;
            this.RevenueSubAccountCode.Required = false;
             
#endregion MainCashOfficePaymentTypeForm_IsSubCashOfficePayment_CheckedChanged
        }

        protected override void PreScript()
        {
#region MainCashOfficePaymentTypeForm_PreScript
    base.PreScript();
            
            Guid SiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if(Sites.SiteMerkezSagKom.Equals(SiteGuid))
            {
                if (this.IsSubCashOfficePayment.Value == true)
                {
                    this.IsBankOperation.Value = false;
                    this.IsChattel.Value = false;
                    this.AccountEntegration.Value = true;
                    this.SubCashierCanDo.Value = false;
                    
                    this.AccountEntegration.ReadOnly = true;
                    this.IsBankOperation.ReadOnly = true;
                    this.IsChattel.ReadOnly = true;
                    this.SubCashierCanDo.ReadOnly = true;
                    this.IsSubCashOfficePayment.ReadOnly = false;

                    this.RevenueSubAccountCode.ReadOnly = true;
                    this.RevenueSubAccountCode.Required = false;
                     
                }
                else if (this.IsBankOperation.Value == true)
                {
                    this.AccountEntegration.Value = false;
                    this.IsSubCashOfficePayment.Value = false;
                    this.IsChattel.Value = false;
                    this.SubCashierCanDo.Value = false;

                    this.AccountEntegration.ReadOnly = true;
                    this.IsSubCashOfficePayment.ReadOnly = true;
                    this.IsChattel.ReadOnly = true;
                    this.SubCashierCanDo.ReadOnly = true;
                    this.IsBankOperation.ReadOnly = false;

                    this.RevenueSubAccountCode.ReadOnly = true;
                    this.RevenueSubAccountCode.Required = false;
                     
                }
                else
                {
                    this.AccountEntegration.ReadOnly = false;
                    this.IsSubCashOfficePayment.ReadOnly = false;
                    this.IsChattel.ReadOnly = false;
                    this.IsBankOperation.ReadOnly = false;
                    this.SubCashierCanDo.ReadOnly = false;
                    
                    if (this.AccountEntegration.Value == true)
                    {
                        this.RevenueSubAccountCode.ReadOnly = false;
                        this.RevenueSubAccountCode.Required = true;
                         
                    }
                    else
                    {
                        this.RevenueSubAccountCode.ReadOnly = true;
                        this.RevenueSubAccountCode.Required = false;
                         
                    }
                }
            }
#endregion MainCashOfficePaymentTypeForm_PreScript

            }
                }
}