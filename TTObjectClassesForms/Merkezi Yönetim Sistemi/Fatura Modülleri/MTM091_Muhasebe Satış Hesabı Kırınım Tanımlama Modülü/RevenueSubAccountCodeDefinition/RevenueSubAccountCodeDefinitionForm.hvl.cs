
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Muhasebe Satış Hesabı Kırınım Tanımı
    /// </summary>
    public partial class RevenueSubAccountCodeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Muhasebe Satış Hesabı Kırınım Tanımlama Modülü
    /// </summary>
        protected TTObjectClasses.RevenueSubAccountCodeDefinition _RevenueSubAccountCodeDefinition
        {
            get { return (TTObjectClasses.RevenueSubAccountCodeDefinition)_ttObject; }
        }

        protected ITTLabel labelAccountType;
        protected ITTEnumComboBox AccountType;
        protected ITTLabel labelSubAccountType;
        protected ITTEnumComboBox SubAccountType;
        protected ITTLabel lblMasterRevenueSubAccount;
        protected ITTObjectListBox MasterRevenueSubAccount;
        protected ITTLabel DesciptionLbl;
        protected ITTLabel AccountCodeLbl;
        protected ITTTextBox DESCRIPTION;
        protected ITTTextBox ACCOUNTCODE;
        protected ITTLabel lblRelatedRevenueSubAccount;
        protected ITTObjectListBox RelatedRevenueSubAccount;
        override protected void InitializeControls()
        {
            labelAccountType = (ITTLabel)AddControl(new Guid("8994ccd7-47e1-40e0-8de4-7e004eddce7a"));
            AccountType = (ITTEnumComboBox)AddControl(new Guid("f5188d01-a277-4f92-8012-e2b5a5af9212"));
            labelSubAccountType = (ITTLabel)AddControl(new Guid("3067f56e-2b28-4503-99a0-9727b1d49cbe"));
            SubAccountType = (ITTEnumComboBox)AddControl(new Guid("7cfdc0dc-c91c-4394-9bd7-6c6068cb7476"));
            lblMasterRevenueSubAccount = (ITTLabel)AddControl(new Guid("f196db9f-8409-4060-9635-b30b9df1725f"));
            MasterRevenueSubAccount = (ITTObjectListBox)AddControl(new Guid("58e2d0e8-09c0-40d5-b381-17a7fe18d93f"));
            DesciptionLbl = (ITTLabel)AddControl(new Guid("99ca5c5d-0865-400a-bc39-4cfbe4b047ce"));
            AccountCodeLbl = (ITTLabel)AddControl(new Guid("9ef3ced8-ee84-436d-a49d-30729ae98956"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("fc004862-6102-4ea0-9676-400e560caa86"));
            ACCOUNTCODE = (ITTTextBox)AddControl(new Guid("8e452d56-bae1-47b5-bdf0-a50a8d7fc968"));
            lblRelatedRevenueSubAccount = (ITTLabel)AddControl(new Guid("b65c8c71-24ee-4c97-97b9-709208fa3e67"));
            RelatedRevenueSubAccount = (ITTObjectListBox)AddControl(new Guid("e48c8255-9a28-4769-9c1b-1390d2628df7"));
            base.InitializeControls();
        }

        public RevenueSubAccountCodeDefinitionForm() : base("REVENUESUBACCOUNTCODEDEFINITION", "RevenueSubAccountCodeDefinitionForm")
        {
        }

        protected RevenueSubAccountCodeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}