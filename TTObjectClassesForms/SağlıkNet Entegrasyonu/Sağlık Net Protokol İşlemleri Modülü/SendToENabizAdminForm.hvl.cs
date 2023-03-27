
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
    public partial class SendToENabizAdminForm : TTUnboundForm
    {
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PackageCount;
        protected ITTGrid ErrorGrid;
        protected ITTTextBoxColumn ErrorCode;
        protected ITTTextBoxColumn ErrorMessage;
        protected ITTTextBoxColumn Count;
        protected ITTButtonColumn retryError;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTGrid PackageCountGrid;
        protected ITTTextBoxColumn PackageType;
        protected ITTTextBoxColumn Pending;
        protected ITTTextBoxColumn Success;
        protected ITTTextBoxColumn Unsuccess;
        protected ITTTextBoxColumn NotAbleToSend;
        protected ITTButton query;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker dtpickerLast;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker dtpickerFirst;
        protected ITTTabPage SendPackageOfPatient;
        protected ITTLabel selectedEpisodeLabel;
        protected ITTMaskedTextBox tbTC;
        protected ITTGrid packageListGrid;
        protected ITTTextBoxColumn internalObjectID;
        protected ITTTextBoxColumn packageCode;
        protected ITTTextBoxColumn name;
        protected ITTTextBoxColumn Status;
        protected ITTButtonColumn sendOnGrid;
        protected ITTLabel ttLabelBirthDate;
        protected ITTLabel ttLableNameAndSurname;
        protected ITTLabel ttlabel6;
        protected ITTGrid episodeListGrid;
        protected ITTTextBoxColumn episodeObjectID;
        protected ITTTextBoxColumn startDate;
        protected ITTTextBoxColumn protocolNo;
        protected ITTTextBoxColumn receptionType;
        protected ITTTextBoxColumn branch;
        protected ITTLabel ttlabel5;
        protected ITTTabPage SendAllPackage;
        protected ITTButton sendPackageBase;
        protected ITTLabel ttlabel7;
        protected ITTEnumComboBox packageTypeCombo;
        protected ITTTabPage SendXMLTabPage;
        protected ITTLabel ttlabel12;
        protected ITTButton sysGonder;
        protected ITTLabel ttlabel11;
        protected ITTRichTextBoxControl txtSendXML;
        protected ITTRichTextBoxControl txtResponceXML;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("c97c9fd4-40ca-40e1-970d-e0e95499e83c"));
            PackageCount = (ITTTabPage)AddControl(new Guid("f58f1a8c-013b-4590-b0e2-c1aa5dd58e44"));
            ErrorGrid = (ITTGrid)AddControl(new Guid("4bbcf388-675f-4db7-b1a6-3160cf2fb98b"));
            ErrorCode = (ITTTextBoxColumn)AddControl(new Guid("0c45791e-a385-44eb-9acc-be6fd0682dc1"));
            ErrorMessage = (ITTTextBoxColumn)AddControl(new Guid("0b484666-77de-45b1-9727-dd343e714c53"));
            Count = (ITTTextBoxColumn)AddControl(new Guid("86ea2d3e-45e6-4edd-862d-f5afeaf5d5b2"));
            retryError = (ITTButtonColumn)AddControl(new Guid("713ec65b-ff16-4d2c-8caa-b860fda97485"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cd8b3c5a-e60b-4128-8d7e-c7b7cd99eddd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ced64972-bb76-4136-9933-918e6ba89a67"));
            PackageCountGrid = (ITTGrid)AddControl(new Guid("c1358954-aacf-4864-a209-97cf4a1a1a82"));
            PackageType = (ITTTextBoxColumn)AddControl(new Guid("5b99a114-f6c9-410b-ab53-a77d097ef6c3"));
            Pending = (ITTTextBoxColumn)AddControl(new Guid("3b4c31ca-92f1-4624-ad08-67b3895f976c"));
            Success = (ITTTextBoxColumn)AddControl(new Guid("3c4100d7-ce24-48fa-8e2c-88ef585c8ecd"));
            Unsuccess = (ITTTextBoxColumn)AddControl(new Guid("ac4c5949-17ef-4d9e-b58f-aeb75e4a1460"));
            NotAbleToSend = (ITTTextBoxColumn)AddControl(new Guid("c17844dd-d7d5-4771-830f-c1ad46c44e4c"));
            query = (ITTButton)AddControl(new Guid("4c5d376d-856e-4300-bcc6-0741981013bd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9a0b7776-0c88-4cbd-bbf0-e76bd0fb19ce"));
            dtpickerLast = (ITTDateTimePicker)AddControl(new Guid("cc4e1e21-e934-40fe-9baa-5d1b54ef8d29"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("32fbf71b-161a-4443-8e3b-342f1f40cf0b"));
            dtpickerFirst = (ITTDateTimePicker)AddControl(new Guid("b965be5b-3d1b-4db1-979d-0348ed5f9735"));
            SendPackageOfPatient = (ITTTabPage)AddControl(new Guid("da1f4f82-6df5-4fff-988e-9bd6dbe9fa2a"));
            selectedEpisodeLabel = (ITTLabel)AddControl(new Guid("cfaaaf69-c3a0-4630-90b4-fd5cebe69b69"));
            tbTC = (ITTMaskedTextBox)AddControl(new Guid("738cc37d-953d-4221-8a85-23c25b69c6dd"));
            packageListGrid = (ITTGrid)AddControl(new Guid("67a27a14-081c-4117-b877-856d17f3a33a"));
            internalObjectID = (ITTTextBoxColumn)AddControl(new Guid("d1b42c3a-aab7-4c53-8cfe-93382d971bb6"));
            packageCode = (ITTTextBoxColumn)AddControl(new Guid("1d2f35aa-2bda-41dd-9110-d279bf01e087"));
            name = (ITTTextBoxColumn)AddControl(new Guid("419975ba-64db-4bd6-9c1d-811a07f70205"));
            Status = (ITTTextBoxColumn)AddControl(new Guid("722cfb94-dc26-42ef-a289-e2f4b5dafd7a"));
            sendOnGrid = (ITTButtonColumn)AddControl(new Guid("075ffeae-eee1-4b54-997c-f62e675dad9d"));
            ttLabelBirthDate = (ITTLabel)AddControl(new Guid("ff0cee7b-e2e0-4a3d-94bf-c6fbef14ca5a"));
            ttLableNameAndSurname = (ITTLabel)AddControl(new Guid("d4e29124-1a16-4f66-be30-fd731cd841a0"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("5034714c-1c18-4318-85d7-95bd91781980"));
            episodeListGrid = (ITTGrid)AddControl(new Guid("dde62f8d-ff64-4334-8e35-7bf31b515001"));
            episodeObjectID = (ITTTextBoxColumn)AddControl(new Guid("c1f6c916-5313-4d49-8ce8-fb8444bb862c"));
            startDate = (ITTTextBoxColumn)AddControl(new Guid("cbd35d58-3817-4e01-96fc-dbfdd61e8b3c"));
            protocolNo = (ITTTextBoxColumn)AddControl(new Guid("d0bd5543-7adc-450b-853f-18cba5894741"));
            receptionType = (ITTTextBoxColumn)AddControl(new Guid("2b1858a9-868b-46b9-9676-1c62df420188"));
            branch = (ITTTextBoxColumn)AddControl(new Guid("502bb046-b264-4b83-a3bd-9917463e31ba"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("74a516f7-ea4d-4bea-be05-4179d20d95df"));
            SendAllPackage = (ITTTabPage)AddControl(new Guid("5fcfe3dc-1c61-4ae5-968f-6802440c4d29"));
            sendPackageBase = (ITTButton)AddControl(new Guid("81280997-a759-44a4-9530-3f8b468d1828"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("bbc466f4-8670-4a67-bf2d-fee0ca9a2a8c"));
            packageTypeCombo = (ITTEnumComboBox)AddControl(new Guid("83e8c86b-6a6b-4233-8889-fc5d0205423b"));
            SendXMLTabPage = (ITTTabPage)AddControl(new Guid("833708e5-d295-4b57-a943-2f54b4b24ed7"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("0fa7232d-c0c9-4372-b512-737218d6637e"));
            sysGonder = (ITTButton)AddControl(new Guid("84c8a099-a982-4d26-8db6-1695952f8ba9"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("ffcc839a-e7e1-420e-a0a5-165a4988f5b4"));
            txtSendXML = (ITTRichTextBoxControl)AddControl(new Guid("7fa67cad-3be8-4728-b613-ae4444909307"));
            txtResponceXML = (ITTRichTextBoxControl)AddControl(new Guid("848e7afb-d32b-493e-852c-493ceb75e8e8"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c1ba365c-92d9-45cd-a3ac-21a848aa046a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("8bc02679-8ba4-4b06-9096-e8972a998c33"));
            base.InitializeControls();
        }

        public SendToENabizAdminForm() : base("SendToENabizAdminForm")
        {
        }

        protected SendToENabizAdminForm(string formDefName) : base(formDefName)
        {
        }
    }
}