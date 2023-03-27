
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
    /// Radyoloji Tetkik İstek Formu
    /// </summary>
    public partial class RadiologyRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTLabel labelDisTaahhutNo;
        protected ITTTextBox DisTaahhutNo;
        protected ITTLabel labelToothNumber;
        protected ITTEnumComboBox cmbToothNumber;
        protected ITTButton ttbuttonToothSchema;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabPagePreDiagnosis;
        protected ITTTextBox txtPreDiagnosis;
        protected ITTTabPage tabPageDescription;
        protected ITTTextBox tttextbox2;
        protected ITTTabControl TabGridConrol;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel4;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTButton btnCreateTemplate;
        protected ITTButton btnEditTemplate;
        protected ITTButton btnSelectTemplate;
        override protected void InitializeControls()
        {
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("4728f6b3-59b6-4baa-b5a9-ea014a42b8f1"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("b61c0828-4a74-41fe-b4f3-40c9cc3a25b5"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("2aed768d-09fd-4420-8c2b-132cbb12832c"));
            cmbToothNumber = (ITTEnumComboBox)AddControl(new Guid("f52f5590-538e-4d2e-a433-546c56a2906d"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("b0d9232e-d9d9-44c0-b17b-c49e35d3f678"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("189fd0af-de44-4e47-b994-5ea70f57b470"));
            tabPagePreDiagnosis = (ITTTabPage)AddControl(new Guid("b9229410-d557-49b8-980f-687994818e50"));
            txtPreDiagnosis = (ITTTextBox)AddControl(new Guid("e10cf744-ade5-4a9c-ac57-0aedf6cdd891"));
            tabPageDescription = (ITTTabPage)AddControl(new Guid("b4c17e6a-07da-4137-8add-93b6cfb144d8"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("fef6faff-252b-4b99-bb5e-9837e3b781a0"));
            TabGridConrol = (ITTTabControl)AddControl(new Guid("d0e9c9e0-b4cf-4050-84d1-e7b22801d793"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9e32ddb3-bccb-4501-b57e-f9cb103f4b01"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8611cb70-efe0-4d88-916e-25a079034b6e"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("d1927fc0-ab3a-4e83-9aed-9b15f79a6866"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f7d73a07-e343-43b2-814d-7c4d18e42a00"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c982d6a2-8a0b-40fe-839d-cebe1de93c41"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("f02cd3c6-cdfb-4af4-99ff-56a1927824cc"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ceecbaa6-c781-44ce-a9a0-4c4b951dd346"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("39dec31f-e39a-417c-912b-bc44a6cd19ef"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c0937b04-ac9c-4ed8-9744-97e14bdeb6aa"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d2a76d94-23e8-4427-9d10-0faf99ada5b7"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("6ee1d4a5-304b-4625-b6e9-072cfd559f3f"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("fdf20bee-9dc5-44b7-ae7b-ea0b0f2d6f30"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("fcca4302-376a-4449-b40d-0142d44e1fe8"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7f5b5258-d3e4-4e37-8cb9-796a7d62f063"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("d54868ba-ca66-4cad-b061-c9d1209b7b52"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("27bfa92d-bb8d-43bb-81ef-29e37719719b"));
            btnCreateTemplate = (ITTButton)AddControl(new Guid("0c4c1a7b-1092-4b3c-97fc-0fcb6c66ba3f"));
            btnEditTemplate = (ITTButton)AddControl(new Guid("d4ef545c-dcad-45cf-903f-444b9278ca17"));
            btnSelectTemplate = (ITTButton)AddControl(new Guid("43b4efb9-9c8f-44a2-b732-e1c80df98d3e"));
            base.InitializeControls();
        }

        public RadiologyRequestForm() : base("RADIOLOGY", "RadiologyRequestForm")
        {
        }

        protected RadiologyRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}