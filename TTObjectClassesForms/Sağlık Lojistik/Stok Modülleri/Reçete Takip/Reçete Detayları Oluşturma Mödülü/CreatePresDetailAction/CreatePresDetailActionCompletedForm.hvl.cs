
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
    /// Reçete Detayları Oluşturma
    /// </summary>
    public partial class CreatePresDetailActionCompletedForm : TTForm
    {
        protected TTObjectClasses.CreatePresDetailAction _CreatePresDetailAction
        {
            get { return (TTObjectClasses.CreatePresDetailAction)_ttObject; }
        }

        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTTextBox ID;
        protected ITTTextBox seriNo;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox5;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        protected ITTGrid PrescriptionPaperInDetails;
        protected ITTTextBoxColumn SerialNoPrescriptionPaperInDetail;
        protected ITTTextBoxColumn VolumeNoPrescriptionPaperInDetail;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTButton ttbuttonSorgula;
        protected ITTLabel ttCiltno;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox bitNo;
        protected ITTTextBox basNo;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            labelAmount = (ITTLabel)AddControl(new Guid("faedf32a-007d-4cf4-9665-d3f28a8bf8b2"));
            Amount = (ITTTextBox)AddControl(new Guid("bf2ff9e6-8f77-4386-aa37-fb61f1150fe7"));
            ID = (ITTTextBox)AddControl(new Guid("699f743c-3865-4e2d-9f8a-b8f7312a9485"));
            seriNo = (ITTTextBox)AddControl(new Guid("974ca145-a696-4975-bc8b-c0a43a21622c"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("152d9103-7010-475d-8c30-fba7b651c1d4"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("2d21d383-2eb4-479c-933b-f7863d5abf96"));
            labelMaterial = (ITTLabel)AddControl(new Guid("fc3528dd-2fb6-4d0f-8cdc-fc9588eea169"));
            Material = (ITTObjectListBox)AddControl(new Guid("ae2ef0cc-05d0-498c-8974-e6fcd91ea263"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("1f98e1b2-3473-4b81-a15b-98d8399ec996"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("c91007cc-08b7-4f57-a2b3-b42568b8c286"));
            PrescriptionPaperInDetails = (ITTGrid)AddControl(new Guid("0e83b153-156a-4e66-93ff-a453b2f893e6"));
            SerialNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("1849bdfd-7344-4ffb-82b3-99550aa6b14b"));
            VolumeNoPrescriptionPaperInDetail = (ITTTextBoxColumn)AddControl(new Guid("9dbee2e0-ee0e-485b-9d42-eaa53bdabcb9"));
            labelID = (ITTLabel)AddControl(new Guid("c0470eba-6beb-4b13-bfa5-8fd2510af8bd"));
            labelActionDate = (ITTLabel)AddControl(new Guid("cc55ad38-ff78-4049-b842-397708d54330"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2e2f9c60-6a2b-4c5b-8794-4bc5ac4a71df"));
            ttbuttonSorgula = (ITTButton)AddControl(new Guid("272affe5-ad80-4c88-aa77-56c8cd859086"));
            ttCiltno = (ITTLabel)AddControl(new Guid("299dd57f-a0b6-4e92-a543-8da3287bc710"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("3657f075-a9c6-4c93-941b-346f1f9e32cb"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b296dfcd-3842-46f7-9657-f594aac25a27"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("680b30c9-073f-4169-8382-fa6e43477c60"));
            bitNo = (ITTTextBox)AddControl(new Guid("f16bc29d-5a9e-4bfb-851a-b03f424b985e"));
            basNo = (ITTTextBox)AddControl(new Guid("a8fc4ba7-6de6-43a9-9bb1-1d4ae8c29ae5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("220fd4a6-603b-4667-b664-24689ca77683"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("caaacd77-3f1e-4a3f-a2ac-714ff403c74e"));
            base.InitializeControls();
        }

        public CreatePresDetailActionCompletedForm() : base("CREATEPRESDETAILACTION", "CreatePresDetailActionCompletedForm")
        {
        }

        protected CreatePresDetailActionCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}