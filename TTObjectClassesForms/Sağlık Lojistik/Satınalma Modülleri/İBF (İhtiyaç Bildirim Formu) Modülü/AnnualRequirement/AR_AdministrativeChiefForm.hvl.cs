
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
    /// İdari Amir Onay
    /// </summary>
    public partial class AR_AdministrativeChiefForm : AR_BaseForm
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
        protected ITTMaskedTextBox IBFYear;
        protected ITTLabel labelAccountancy;
        protected ITTLabel IBFYearLabel;
        protected ITTEnumComboBox IBFType;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("a438ea36-563a-43a1-8844-e43e95172bed"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e8e78029-d1d7-45ca-9144-15e48e0908ad"));
            labelID = (ITTLabel)AddControl(new Guid("e18a0dfe-4764-4850-92af-fc2294cda6ea"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("aa6240fe-2067-4861-91c6-a6666f40bbce"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("6ab7673a-469c-4fd9-bdaf-ee18818d3a67"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("8eb006ba-61e9-4ba1-9907-494bc84463f1"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("d83930a5-7bd8-4c5b-866e-3f6ccbaa23ef"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("eee92243-48c0-40de-bdef-33184cedcf95"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c7eed112-ba0e-41cf-94eb-745bf928472d"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("0e7cb496-6255-4753-90f9-82b4a24a1796"));
            labelDescription = (ITTLabel)AddControl(new Guid("dd28dd55-0eac-4240-8d7b-7ce0cc6afa31"));
            Description = (ITTTextBox)AddControl(new Guid("681f709d-fad1-4b2f-93b2-6f58b6c59b40"));
            RequestNO = (ITTTextBox)AddControl(new Guid("4b676b87-6de7-41c4-be58-2c08cd45a507"));
            base.InitializeControls();
        }

        public AR_AdministrativeChiefForm() : base("ANNUALREQUIREMENT", "AR_AdministrativeChiefForm")
        {
        }

        protected AR_AdministrativeChiefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}