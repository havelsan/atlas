
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
    /// Loj.Şb./İkmal Md.İBF Giriş
    /// </summary>
    public partial class AR_LogBrIBFRegistryForm : AR_BaseForm
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
        protected ITTEnumComboBox IBFType;
        protected ITTLabel ttlabel2;
        protected ITTButton cmdList;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTTextBox Description;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e9ce84f4-b496-45a8-b88b-600c63bd2e4a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0162f4e5-688d-4436-a781-f49e773c2a7f"));
            labelDescription = (ITTLabel)AddControl(new Guid("d669df35-37c0-48c0-83ca-3786506e5070"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("a3c566d6-09c8-401a-b4de-b725e1d2c0cd"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("4de49d89-07be-462a-bdfe-adfeea6dd2cf"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("c679dc36-a077-492e-9446-fe4d9c26cb79"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("30d24294-ad88-45f8-bf54-443844b6a53e"));
            cmdList = (ITTButton)AddControl(new Guid("279d8013-195c-4e3e-ae42-fd38cfc5e998"));
            RequestNO = (ITTTextBox)AddControl(new Guid("29aead9c-f589-4f5c-9048-58dd07e3aa88"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("19c97133-7f04-4c0c-bc63-f79fca1e5ea8"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("ceed230f-706a-4893-b9d2-d7ced221ace3"));
            Description = (ITTTextBox)AddControl(new Guid("18ebf4e8-1bcd-496d-b8b6-8cdba6f75c6c"));
            labelActionDate = (ITTLabel)AddControl(new Guid("1eec4d83-d64b-417e-be4e-c2cdd43b5d1a"));
            labelID = (ITTLabel)AddControl(new Guid("0b56dfd0-cbca-4743-9f8e-ac7e0577fe96"));
            base.InitializeControls();
        }

        public AR_LogBrIBFRegistryForm() : base("ANNUALREQUIREMENT", "AR_LogBrIBFRegistryForm")
        {
        }

        protected AR_LogBrIBFRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}