
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
    /// Başhekim/XXXXXX İnceleme Onay
    /// </summary>
    public partial class AR_HeadDoctorApprovalForm : AR_BaseForm
    {
    /// <summary>
    /// İhtiyaç Bildirim Formu
    /// </summary>
        protected TTObjectClasses.AnnualRequirement _AnnualRequirement
        {
            get { return (TTObjectClasses.AnnualRequirement)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelID;
        protected ITTEnumComboBox IBFType;
        protected ITTLabel labelAccountancy;
        protected ITTLabel IBFYearLabel;
        protected ITTDateTimePicker ActionDate;
        protected ITTMaskedTextBox IBFYear;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("2d84b348-c27c-48e6-aefb-a3bf22cfc943"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e7123a03-baea-4609-85f9-5a36aece4a58"));
            labelID = (ITTLabel)AddControl(new Guid("4abb5e43-ddf4-4aec-8c35-e80f8de2d2d1"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("46658e0f-21e1-4fee-b1bb-0a8853b8faf6"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("a06e0cfe-2aec-466d-aba8-6d7c5a7012e7"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("03e7150e-c64c-4492-b9a0-5228a2c7e0d9"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4d697477-5455-4753-b5f4-77a94c254581"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("73ca775b-4ba0-4288-bd9f-b8d8386c8dd1"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("f3c952e2-48c1-4f0d-bc3a-d841770cc3c8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bfd9311a-021d-45b8-afc2-ead677ec2925"));
            labelDescription = (ITTLabel)AddControl(new Guid("38ae28fe-811e-4081-85ef-eaf9c083ccb3"));
            Description = (ITTTextBox)AddControl(new Guid("5f80d31e-c609-4b86-acff-6b687521fbe6"));
            RequestNO = (ITTTextBox)AddControl(new Guid("217f5a98-af0e-4369-957e-6725327ea63a"));
            base.InitializeControls();
        }

        public AR_HeadDoctorApprovalForm() : base("ANNUALREQUIREMENT", "AR_HeadDoctorApprovalForm")
        {
        }

        protected AR_HeadDoctorApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}