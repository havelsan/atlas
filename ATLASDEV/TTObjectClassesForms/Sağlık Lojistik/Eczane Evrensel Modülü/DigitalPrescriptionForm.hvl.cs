
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
    /// E-İmzalı Reçete Detayı
    /// </summary>
    public partial class DigitalPrescriptionForm : TTUnboundForm
    {
        protected ITTGroupBox SignedPrescriptionGroupBox;
        protected ITTLabel labelSignedFillingDate;
        protected ITTLabel labelSignedProcedureDoctor;
        protected ITTGrid SignedPrescriptionGrid;
        protected ITTListBoxColumn SignedDrug;
        protected ITTEnumComboBoxColumn SignedFrequency;
        protected ITTTextBoxColumn SignedDoseAmount;
        protected ITTTextBoxColumn SignedDay;
        protected ITTObjectListBox SignedProcedureDoctor;
        protected ITTEnumComboBox SignedPrescriptionType;
        protected ITTDateTimePicker SignedFillingDate;
        protected ITTLabel labelSignedPrescriptionType;
        protected ITTTextBox SignedPrescriptionNO;
        protected ITTLabel labelSignedPrescriptionNO;
        protected ITTGroupBox ExistPrescriptionGroupBox;
        protected ITTGrid ExistPrescriptionGrid;
        protected ITTListBoxColumn ExistDrug;
        protected ITTEnumComboBoxColumn ExistFrequency;
        protected ITTTextBoxColumn ExistDoseAmount;
        protected ITTTextBoxColumn ExistDay;
        protected ITTLabel labelExistFillingDate;
        protected ITTLabel labelExistProcedureDoctor;
        protected ITTTextBox ExistPrescriptionNO;
        protected ITTObjectListBox ExistProcedureDoctor;
        protected ITTDateTimePicker ExistFillingDate;
        protected ITTLabel labelExistPrescriptionType;
        protected ITTLabel labelExistPrescriptionNO;
        protected ITTEnumComboBox ExistPrescriptionType;
        override protected void InitializeControls()
        {
            SignedPrescriptionGroupBox = (ITTGroupBox)AddControl(new Guid("a533cd57-f00b-414f-b442-e6e48d29da19"));
            labelSignedFillingDate = (ITTLabel)AddControl(new Guid("8aee84af-5797-4801-952f-bd9004178cc5"));
            labelSignedProcedureDoctor = (ITTLabel)AddControl(new Guid("7bd94628-cee1-4399-9b7a-655efffbf88d"));
            SignedPrescriptionGrid = (ITTGrid)AddControl(new Guid("da03aed2-237e-47e6-9904-5204da595a5e"));
            SignedDrug = (ITTListBoxColumn)AddControl(new Guid("235fd161-8b94-48e6-8a59-938bd410b68c"));
            SignedFrequency = (ITTEnumComboBoxColumn)AddControl(new Guid("41872ce0-7dfb-4101-95e6-b57aea38f444"));
            SignedDoseAmount = (ITTTextBoxColumn)AddControl(new Guid("2576fe18-515d-4c06-9ca8-31752f25023e"));
            SignedDay = (ITTTextBoxColumn)AddControl(new Guid("28dc85bb-3fb5-4761-a80c-e7b3e6c8ea81"));
            SignedProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("31a1b0ec-d206-4ba6-b588-3a937132a7b6"));
            SignedPrescriptionType = (ITTEnumComboBox)AddControl(new Guid("ab72229a-a843-4e7d-9560-bde650760bb5"));
            SignedFillingDate = (ITTDateTimePicker)AddControl(new Guid("5f591963-be2f-49c4-8dcc-6fb98ada86a9"));
            labelSignedPrescriptionType = (ITTLabel)AddControl(new Guid("0f586272-e472-4df9-889a-35d9d468f656"));
            SignedPrescriptionNO = (ITTTextBox)AddControl(new Guid("a8e7e96d-c90b-4d98-935d-fcc059ed5814"));
            labelSignedPrescriptionNO = (ITTLabel)AddControl(new Guid("ac62407f-48b9-4952-8dee-80b6853508c3"));
            ExistPrescriptionGroupBox = (ITTGroupBox)AddControl(new Guid("7b0fed37-6c52-4103-bac7-90f293d4dab9"));
            ExistPrescriptionGrid = (ITTGrid)AddControl(new Guid("99ba7731-7d1b-437c-a6be-dca67d23d514"));
            ExistDrug = (ITTListBoxColumn)AddControl(new Guid("b97abdc4-6ee5-4697-bd4e-d29954696fc4"));
            ExistFrequency = (ITTEnumComboBoxColumn)AddControl(new Guid("fa224d07-60ae-46d5-89e2-54a105bec542"));
            ExistDoseAmount = (ITTTextBoxColumn)AddControl(new Guid("664c0dc9-624d-4129-9d75-77073f3ebba3"));
            ExistDay = (ITTTextBoxColumn)AddControl(new Guid("be1548c5-659e-4649-aa01-097cae552eb1"));
            labelExistFillingDate = (ITTLabel)AddControl(new Guid("6a8959b0-3826-4f89-846d-3acd74779115"));
            labelExistProcedureDoctor = (ITTLabel)AddControl(new Guid("eb796d92-984a-458c-aff5-6a8acaef22dd"));
            ExistPrescriptionNO = (ITTTextBox)AddControl(new Guid("d84e314c-30ee-4e6e-9d9d-aed8e5d886bb"));
            ExistProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("91a35434-3ab9-4e4a-8112-6e2c19182844"));
            ExistFillingDate = (ITTDateTimePicker)AddControl(new Guid("322939db-db73-49ea-a759-98a527c165b4"));
            labelExistPrescriptionType = (ITTLabel)AddControl(new Guid("8a407217-a474-4933-bac9-44976fe778d1"));
            labelExistPrescriptionNO = (ITTLabel)AddControl(new Guid("1ad22742-2578-4a0d-8a80-cba832722da4"));
            ExistPrescriptionType = (ITTEnumComboBox)AddControl(new Guid("ac251fc7-c114-43dd-9278-66daa7d35601"));
            base.InitializeControls();
        }

        public DigitalPrescriptionForm() : base("DigitalPrescriptionForm")
        {
        }

        protected DigitalPrescriptionForm(string formDefName) : base(formDefName)
        {
        }
    }
}