
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
    /// Lojistik Daire İnceleme Onay
    /// </summary>
    public partial class AR_LDApprovalForm : AR_BaseForm
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
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("a88c140f-bc22-4d3e-8875-f174122933e9"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6dbb7b73-5d85-4808-a3bb-a22a944ebbf3"));
            labelID = (ITTLabel)AddControl(new Guid("ed260108-9a6c-4a12-821d-47f89ec31882"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("dc3e671f-dfac-4b60-92c3-a8686b3eada0"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("25c0d365-9fb4-470d-8634-bffd26100a88"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("eaa8ba27-604e-4464-81f9-c4eb3b1c0b9f"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("16965c86-d2e9-469e-b93e-1546c6b86b66"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("ed1871bf-f667-4a67-847f-abf810fd111e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("cb6cf708-1c8c-49d5-834c-a9aba6070834"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8cf862f7-96fb-4f78-be94-dab4d0722354"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("0b50965c-5a61-406b-a6d0-f0dfb11aa2c4"));
            labelDescription = (ITTLabel)AddControl(new Guid("59b48a27-1d8d-4c37-8401-7b920a04c750"));
            Description = (ITTTextBox)AddControl(new Guid("49de5318-5aee-4cad-8a08-20780ac2daf5"));
            RequestNO = (ITTTextBox)AddControl(new Guid("3368db85-b5d6-4b96-bda2-0a3f6c84659d"));
            base.InitializeControls();
        }

        public AR_LDApprovalForm() : base("ANNUALREQUIREMENT", "AR_LDApprovalForm")
        {
        }

        protected AR_LDApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}