
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
    /// Banka Teslimat Müzekkeresi
    /// </summary>
    public partial class BankDeliveryForm : TTForm
    {
    /// <summary>
    /// Banka Teslim Müzekkeresi
    /// </summary>
        protected TTObjectClasses.MhSBankDelivery _MhSBankDelivery
        {
            get { return (TTObjectClasses.MhSBankDelivery)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTLabel labelSlipType;
        protected ITTTextBox Comment;
        protected ITTLabel labelComment;
        protected ITTTextBox Amount;
        protected ITTListDefComboBox Trustee;
        protected ITTLabel labelBank;
        protected ITTTextBox No;
        protected ITTListDefComboBox Bank;
        protected ITTTextBox SlipNo;
        protected ITTLabel labelDate;
        protected ITTLabel labelDivision;
        protected ITTDateTimePicker Date;
        protected ITTEnumComboBox SlipType;
        protected ITTLabel labelSlipNo;
        protected ITTTextBox Division;
        protected ITTLabel labelNo;
        protected ITTLabel labelTrustee;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("5762e120-bf0b-4a61-8a75-0498108f0386"));
            labelSlipType = (ITTLabel)AddControl(new Guid("dd514e03-74fc-4f2f-8c1c-fb24c090c884"));
            Comment = (ITTTextBox)AddControl(new Guid("2610ea18-beed-4271-a7e1-e769c2a93f78"));
            labelComment = (ITTLabel)AddControl(new Guid("d98d3073-bcad-4125-89e0-bc3963903d64"));
            Amount = (ITTTextBox)AddControl(new Guid("dbcd8aa3-9706-4fad-ae56-8b1563708cc1"));
            Trustee = (ITTListDefComboBox)AddControl(new Guid("497af6a2-bdf7-456a-b110-9f5c0d2781bd"));
            labelBank = (ITTLabel)AddControl(new Guid("d12e6ce0-ee97-4520-9f92-ab96e35084fd"));
            No = (ITTTextBox)AddControl(new Guid("2e1180f2-114a-4b6f-9b0e-7e25ea07c30b"));
            Bank = (ITTListDefComboBox)AddControl(new Guid("1e0e4c15-0b40-43ee-9cba-a23526fb4c51"));
            SlipNo = (ITTTextBox)AddControl(new Guid("4e17a142-4325-4a5a-816c-8695aad2eb1d"));
            labelDate = (ITTLabel)AddControl(new Guid("0e59520b-2fef-4836-a901-6fc9063eb50f"));
            labelDivision = (ITTLabel)AddControl(new Guid("b6642b9d-3e72-44bb-b43d-5b57e0e94b0d"));
            Date = (ITTDateTimePicker)AddControl(new Guid("72e42a43-d8bb-40ab-963e-36b7bc4129cc"));
            SlipType = (ITTEnumComboBox)AddControl(new Guid("054c390f-f496-4fcd-8865-3e3cb6478e3d"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("d3ecef0c-59a6-4795-9a6b-181b57863769"));
            Division = (ITTTextBox)AddControl(new Guid("0b3b5a06-1d6e-4cfa-945b-0b42dd1039e6"));
            labelNo = (ITTLabel)AddControl(new Guid("f14d5878-ca9c-4dd6-a228-f589724af608"));
            labelTrustee = (ITTLabel)AddControl(new Guid("c8a908c5-b3b7-4dd4-b7bb-dfaaa47f9d06"));
            base.InitializeControls();
        }

        public BankDeliveryForm() : base("MHSBANKDELIVERY", "BankDeliveryForm")
        {
        }

        protected BankDeliveryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}