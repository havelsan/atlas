
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
    /// Bölge XXXXXX İnceleme Onay
    /// </summary>
    public partial class AR_RegionalCommandLogBureauApproveForm : AR_BaseForm
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
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("75f8b0e8-1a61-4475-ae94-dadcda2c76bb"));
            labelActionDate = (ITTLabel)AddControl(new Guid("8714f3a6-2a14-46dd-a5d1-ea4f16c69f7d"));
            labelID = (ITTLabel)AddControl(new Guid("1aa6b5da-bd9f-41f7-8bab-5235b618fa02"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("bf9f71e4-d09f-4f06-a9c5-d41e5e9e651b"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("31a324ad-fa64-4886-9052-67f42d09279a"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("56084ba4-6a03-4344-8e6c-e361c098de5a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("910aa5e4-5560-4e54-9395-e929db7f0b4f"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("8e0a2b49-41c0-4af8-864a-ca1401bef4cb"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("461bd2f8-89a6-482b-be6e-fdfdd6fd81ef"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9a26efbb-9ea8-4630-89f6-1e656af9c94f"));
            labelDescription = (ITTLabel)AddControl(new Guid("981c0149-0ad1-4c2d-b641-f3956fa345ca"));
            Description = (ITTTextBox)AddControl(new Guid("6da2f9dc-4482-4ff0-b35a-dc8216aeaf6b"));
            RequestNO = (ITTTextBox)AddControl(new Guid("7ceee65f-c580-4120-881f-29589de6cba2"));
            base.InitializeControls();
        }

        public AR_RegionalCommandLogBureauApproveForm() : base("ANNUALREQUIREMENT", "AR_RegionalCommandLogBureauApproveForm")
        {
        }

        protected AR_RegionalCommandLogBureauApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}