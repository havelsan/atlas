
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
    /// Saymanlık Onay
    /// </summary>
    public partial class AR_AccountancyApprovalForm : AR_BaseForm
    {
    /// <summary>
    /// İhtiyaç Bildirim Formu
    /// </summary>
        protected TTObjectClasses.AnnualRequirement _AnnualRequirement
        {
            get { return (TTObjectClasses.AnnualRequirement)_ttObject; }
        }

        protected ITTButton ttbutton1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdApproveAll;
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
            ttbutton1 = (ITTButton)AddControl(new Guid("185e266f-4fce-42a6-91b6-02148cd5330b"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e9f8c8a7-a7b2-45bd-be74-47a7e1a74993"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("8a75e6c5-95b4-4698-a94c-edb93ace32b3"));
            labelActionDate = (ITTLabel)AddControl(new Guid("22c72d51-2d03-4c5a-9b38-ed92071e8566"));
            labelID = (ITTLabel)AddControl(new Guid("ed8c8827-c244-4961-9f5f-0188d9c45b14"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("cf4192be-4351-4a09-ba31-a26723a79b66"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("465bb687-6772-488c-a060-dc101d871894"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("632b3634-b014-469a-83c2-ad204517279d"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("010c4e2a-fddc-4c79-975c-1a48124eb364"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("be926ab3-ab75-4182-99b1-b39a25234b43"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("33308cbf-d10b-49ef-a0f7-cb145a871291"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("74cfdc27-d36b-4b6c-aa38-49e9bc12d593"));
            labelDescription = (ITTLabel)AddControl(new Guid("b64ce9b2-297e-4aaf-a87f-2893f5d85236"));
            Description = (ITTTextBox)AddControl(new Guid("e8e0ed25-1c8d-4c16-a2d1-898912e6731a"));
            RequestNO = (ITTTextBox)AddControl(new Guid("dca3dda1-6fd1-41b5-9e1d-4514920c8771"));
            base.InitializeControls();
        }

        public AR_AccountancyApprovalForm() : base("ANNUALREQUIREMENT", "AR_AccountancyApprovalForm")
        {
        }

        protected AR_AccountancyApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}