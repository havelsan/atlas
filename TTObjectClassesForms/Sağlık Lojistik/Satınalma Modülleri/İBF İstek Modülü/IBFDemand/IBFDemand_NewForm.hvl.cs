
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
    /// İBF İstek Kayıt
    /// </summary>
    public partial class IBFDemand_NewForm : IBFDemand_BaseForm
    {
    /// <summary>
    /// İBF İstek Modülü ana sınıfıdır
    /// </summary>
        protected TTObjectClasses.IBFDemand _IBFDemand
        {
            get { return (TTObjectClasses.IBFDemand)_ttObject; }
        }

        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTTextBoxColumn tttextboxcolumn5;
        protected ITTTextBoxColumn tttextboxcolumn7;
        protected ITTTextBoxColumn tttextboxcolumn8;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdList;
        protected ITTEnumComboBox IBFType;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTMaskedTextBox IBFYear;
        protected ITTLabel IBFYearLabel;
        protected ITTLabel labelActionDate;
        protected ITTLabel IBFTypeLabel;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("d9d6ef98-dd17-4418-9151-df56725fcd63"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("0b6284cd-6395-4842-a0e1-01ccd97b3643"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("c6051900-4f7c-4f62-9eb2-b4e8dec934a2"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("13c0eb2c-c03c-4600-90cf-4c519d88b57b"));
            tttextboxcolumn5 = (ITTTextBoxColumn)AddControl(new Guid("b60f5ce0-cb19-4913-bef4-0b4b214c1b05"));
            tttextboxcolumn7 = (ITTTextBoxColumn)AddControl(new Guid("2de413ff-e6e7-431d-83df-f043d33691f9"));
            tttextboxcolumn8 = (ITTTextBoxColumn)AddControl(new Guid("63d52fbd-fe27-4342-a943-46c13488ebda"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("89abcd58-1992-4185-87d9-89d4c44e9f90"));
            cmdList = (ITTButton)AddControl(new Guid("b0654d16-75fd-4c12-9efa-ce750f31bc8a"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("2a1a7438-3744-41f0-afd8-a2af931863b7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("c9b7b6fb-e553-47dd-9fef-35e259c9f1da"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b993b796-361f-4e8f-86b1-a7f76aaea695"));
            labelDescription = (ITTLabel)AddControl(new Guid("0439c484-2166-40b6-a324-d21b8e55322e"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("535527e4-908e-4efd-bb87-94d8a700ae07"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("8ada534b-309e-4351-b4d5-c4c34c5750ad"));
            labelActionDate = (ITTLabel)AddControl(new Guid("157dcf7d-7a9f-4868-a816-ce932cd1c33a"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("b6eae029-6bb4-4924-aeb8-963cbb8a231e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("9e5dfb9c-c405-446d-98f5-c045df82c5b3"));
            labelID = (ITTLabel)AddControl(new Guid("9e8115cc-f036-40b5-8d33-1c0a5e5dcadc"));
            Description = (ITTTextBox)AddControl(new Guid("3d5bf849-f0c3-4e7c-9ace-4fdacac97431"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c90a2672-810e-42e3-9a00-f36672bdcaab"));
            base.InitializeControls();
        }

        public IBFDemand_NewForm() : base("IBFDEMAND", "IBFDemand_NewForm")
        {
        }

        protected IBFDemand_NewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}