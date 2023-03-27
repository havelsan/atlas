
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
    /// Laboratuvar Tetkik Formu
    /// </summary>
    public partial class LaboratoryProcedureForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Test
    /// </summary>
        protected TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure
        {
            get { return (TTObjectClasses.LaboratoryProcedure)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tpTest;
        protected ITTLabel lblResult;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel13;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel11;
        protected ITTDateTimePicker dtApproveDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid GridSubProcedures;
        protected ITTListBoxColumn TestName;
        protected ITTTextBoxColumn result;
        protected ITTEnumComboBoxColumn Warning;
        protected ITTTextBoxColumn Reference;
        protected ITTTextBoxColumn unit;
        protected ITTRichTextBoxControlColumn SpecialReference;
        protected ITTTextBoxColumn objId;
        protected ITTLabel ttlabel8;
        protected ITTTextBox txtProcessNote;
        protected ITTRichTextBoxControl rtfReport;
        protected ITTDateTimePicker dtRequestDate;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel6;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTTextBox TestTechnicianNote;
        protected ITTLabel ttlabel7;
        protected ITTTabPage tpGeneral;
        protected ITTValueListBox Department;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTValueListBox Equipment;
        protected ITTTabPage tpMaterial;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBox OwnerType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4d79e348-be65-4ed3-aa38-398a3aae1037"));
            tpTest = (ITTTabPage)AddControl(new Guid("5549eb7c-c3f2-4ab2-afcc-1871b997425e"));
            lblResult = (ITTLabel)AddControl(new Guid("3a92c5a4-5461-4cd7-8afa-cbd2cea35e76"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("b518946f-f539-4a83-95e1-cf31536ed792"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("ccd89ecb-b991-4095-95cb-a0784d09c4f4"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("56f214cb-42ef-476b-bd8c-aa18356a5d56"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("5f4fa55e-7672-4748-9932-58149f99c861"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("c886122c-f3a9-41fe-8dbd-34ec028b4b4f"));
            dtApproveDate = (ITTDateTimePicker)AddControl(new Guid("1509232c-945e-4f3c-a37e-3e269ebdb494"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("8f976a7f-3af1-464e-8bda-5091aab6cf51"));
            GridSubProcedures = (ITTGrid)AddControl(new Guid("95c955d6-6957-4b38-a02d-04a8ebc2b9ea"));
            TestName = (ITTListBoxColumn)AddControl(new Guid("f798fc5d-1731-4f89-b5db-6983f11a5b67"));
            result = (ITTTextBoxColumn)AddControl(new Guid("2c465410-6cc2-4778-b588-88893a7c07c2"));
            Warning = (ITTEnumComboBoxColumn)AddControl(new Guid("fb0c55c5-2548-47a0-8f5f-20d2dee17724"));
            Reference = (ITTTextBoxColumn)AddControl(new Guid("5ac6a0fc-f5a5-4d0b-bfb4-c0b197150c85"));
            unit = (ITTTextBoxColumn)AddControl(new Guid("99ac4c72-33d2-4bf7-8a0e-37439e73a4f9"));
            SpecialReference = (ITTRichTextBoxControlColumn)AddControl(new Guid("513fb3f4-e825-4937-b334-5c82a6838542"));
            objId = (ITTTextBoxColumn)AddControl(new Guid("6ee0b946-df2d-4ad8-83cd-6616870d6a8e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("9a784bb8-d208-424a-8772-8c1bfe702be6"));
            txtProcessNote = (ITTTextBox)AddControl(new Guid("b0eedfbe-593f-45c9-a15c-419d9f29dcc5"));
            rtfReport = (ITTRichTextBoxControl)AddControl(new Guid("7308ab46-a05d-419e-817d-77be15e06f50"));
            dtRequestDate = (ITTDateTimePicker)AddControl(new Guid("fe4765b5-dd5b-407f-9ba3-811a791b887e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("65b303c2-3c48-4e47-8fe6-d7bac514210a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("590f0288-4822-4d88-af58-685f54ff320b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("bcb2b01e-f998-4a94-bab7-66b457edec2c"));
            Description = (ITTTextBox)AddControl(new Guid("62a28541-7681-4c8d-b861-db626dcf2a4c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f388692e-94c0-4f84-a67c-f9b3528db50d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("64b1cb09-ec6c-4514-a532-c5ab3e89e41a"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("1ed81f67-8792-419c-b962-0fd2f38c54af"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("200a23ea-2998-4349-9606-edc2cca5ed83"));
            tpGeneral = (ITTTabPage)AddControl(new Guid("f29e9c5e-b621-458e-998d-43139f9b6ee4"));
            Department = (ITTValueListBox)AddControl(new Guid("cce2a834-d89e-49a6-b4b0-d896b1ded5ec"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d98c7aab-3203-491e-b5b3-21d53424cad5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d8fe0d3e-da4b-42df-aac1-90a67e983d8b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0ed849f5-e80f-4533-93ee-6faca73e6f66"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cbdb63ee-eb80-450a-8a63-e8064fc7e662"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8f9b5aad-3448-4ac3-9634-e34033b0e99c"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7541ed01-f15a-4e3d-aa3f-c6aceecc87b3"));
            Equipment = (ITTValueListBox)AddControl(new Guid("9981be76-f430-4f5f-9792-0fbdda44472f"));
            tpMaterial = (ITTTabPage)AddControl(new Guid("e90cf07f-b50a-4a14-95e1-7f6264f0a1d9"));
            Materials = (ITTGrid)AddControl(new Guid("d63f74cb-4473-4939-8f83-c0eb51cffa09"));
            Material = (ITTListBoxColumn)AddControl(new Guid("77b27438-6fb5-4c40-9f30-83226464125c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3d17d853-2fb2-49fd-83fc-f86417d9acfb"));
            OwnerType = (ITTTextBox)AddControl(new Guid("757e80cb-7d7f-4c6f-ae92-4e8be1e15ece"));
            base.InitializeControls();
        }

        public LaboratoryProcedureForm() : base("LABORATORYPROCEDURE", "LaboratoryProcedureForm")
        {
        }

        protected LaboratoryProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}