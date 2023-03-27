
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
    /// Birlik/Loj.Şb.İnceleme Onay
    /// </summary>
    public partial class AR_LogBrApproveForm : AR_BaseForm
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
        protected ITTButton cmdApproveAll;
        protected ITTEnumComboBox IBFType;
        protected ITTLabel IBFYearLabel;
        protected ITTLabel labelAccountancy;
        protected ITTMaskedTextBox IBFYear;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("941f3f05-b25b-4b16-9e37-ae0de3fc8e6a"));
            labelActionDate = (ITTLabel)AddControl(new Guid("17c4f47c-f4f5-40bf-bd1e-202f6414d93d"));
            labelID = (ITTLabel)AddControl(new Guid("5efbda71-6086-4d5f-bc93-dca815f13611"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("be143942-013d-4812-9fd9-e73b7c596b55"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("3821ba08-f482-461b-a04a-a428e0c1ac2a"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("b7b3cd3d-d9d5-4075-b871-0d568ee059a0"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("91fcfa8e-a9b4-4830-98cb-26c26a817ae2"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("9432377e-7866-4bd0-b4b2-c70a9a954666"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0766383c-dc38-44ad-9741-8d357b6dda61"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f461997a-471b-4ae1-83c1-2fa217e8a975"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("885ab78b-c055-4092-beb5-7dc7264417c4"));
            labelDescription = (ITTLabel)AddControl(new Guid("6bcdd288-0277-4245-8f7d-93adbd66ef60"));
            Description = (ITTTextBox)AddControl(new Guid("d4eb3830-4f68-4283-aed2-3f998d2dcdb9"));
            RequestNO = (ITTTextBox)AddControl(new Guid("662924eb-1817-4607-9d12-981f1387b92a"));
            base.InitializeControls();
        }

        public AR_LogBrApproveForm() : base("ANNUALREQUIREMENT", "AR_LogBrApproveForm")
        {
        }

        protected AR_LogBrApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}