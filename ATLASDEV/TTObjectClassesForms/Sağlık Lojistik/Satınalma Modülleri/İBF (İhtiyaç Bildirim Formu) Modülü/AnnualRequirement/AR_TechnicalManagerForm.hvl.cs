
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
    /// Teknik Müdür
    /// </summary>
    public partial class AR_TechnicalManagerForm : AR_BaseForm
    {
    /// <summary>
    /// İhtiyaç Bildirim Formu
    /// </summary>
        protected TTObjectClasses.AnnualRequirement _AnnualRequirement
        {
            get { return (TTObjectClasses.AnnualRequirement)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelDescription;
        protected ITTMaskedTextBox IBFYear;
        protected ITTLabel IBFYearLabel;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox IBFType;
        protected ITTButton cmdList;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTTextBox Description;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("9716506f-80eb-4bb8-a2be-b4e1519a9f9e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("25e617b3-9fd7-4093-b3c8-dead8ca3f36e"));
            labelDescription = (ITTLabel)AddControl(new Guid("8f34ed69-1d3f-4939-8550-e7d5b02a37c5"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("0536ccf9-b725-4d0d-a568-2c903f4b1711"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("98311500-dfdc-4a62-a748-f94b2bb34671"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("141f204b-2162-474f-9228-92c79a428957"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("b71de25a-e195-4b4c-a0f8-48e726c034a1"));
            cmdList = (ITTButton)AddControl(new Guid("7cc07867-1ab7-4cb3-9509-0828f5cb251b"));
            RequestNO = (ITTTextBox)AddControl(new Guid("e786ea6b-d6b7-4c7f-a3dd-78fea2bc3e33"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("a6050dea-6425-4ef5-8bee-898707dbfd62"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("f9e666f7-ad8c-4789-97fe-1d863c74dcdf"));
            Description = (ITTTextBox)AddControl(new Guid("32db4bc6-32d7-42a3-8bc1-71e8dba54049"));
            labelActionDate = (ITTLabel)AddControl(new Guid("f24ac0bb-0d6b-483e-8f33-04e0a3dba50f"));
            labelID = (ITTLabel)AddControl(new Guid("d2c892eb-97bd-4b4e-ab33-f56508b85f6b"));
            base.InitializeControls();
        }

        public AR_TechnicalManagerForm() : base("ANNUALREQUIREMENT", "AR_TechnicalManagerForm")
        {
        }

        protected AR_TechnicalManagerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}