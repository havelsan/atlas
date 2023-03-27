
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
    /// Bakımevi
    /// </summary>
    public partial class DispensaryForm : EpisodeActionForm
    {
    /// <summary>
    /// Bakımevi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Dispensary _Dispensary
        {
            get { return (TTObjectClasses.Dispensary)_ttObject; }
        }

        protected ITTTextBox txtProtocolNo;
        protected ITTLabel lblProtocolNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox NumberOfStayDays;
        protected ITTLabel labelStayingDate;
        protected ITTLabel labelNumberOfStayDays;
        protected ITTCheckBox IsCompanionNeeded;
        protected ITTLabel labelRoom;
        protected ITTDateTimePicker StayingDate;
        protected ITTObjectListBox Room;
        protected ITTTextBox NumberOfLastStayDays;
        protected ITTDateTimePicker DepartureDate;
        protected ITTLabel labelNumberOfLastStayDays;
        protected ITTGroupBox groupboxNotes;
        protected ITTLabel labelNurseNote;
        protected ITTLabel labelSocialNote;
        protected ITTTextBox SocialNote;
        protected ITTTextBox DoctorNote;
        protected ITTTextBox NurseNote;
        protected ITTLabel labelDoctorNote;
        protected ITTLabel labelReasonForDeparture;
        protected ITTTextBox ReasonForDeparture;
        protected ITTGroupBox groupboxStayingInfo;
        protected ITTLabel ttlabel8;
        protected ITTTextBox txtGhaziDiagnosis;
        protected ITTTextBox txtEvents;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel7;
        protected ITTTextBox txtReasonForStay;
        protected ITTTextBox txtStayingInfo;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DebitInfo;
        protected ITTGrid DispensaryDebits;
        protected ITTDateTimePickerColumn DebitDateTime;
        protected ITTTextBoxColumn Debit;
        protected ITTTabPage DrugInfo;
        protected ITTGrid DispensaryDrugs;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Drug;
        protected ITTTabPage BehaviorInfo;
        protected ITTGrid DispensaryGhaziBehaviors;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTTextBoxColumn Explanation;
        protected ITTTextBoxColumn Place;
        protected ITTLabel labelDepartureDate;
        protected ITTRichTextBoxControl LastEvents;
        override protected void InitializeControls()
        {
            txtProtocolNo = (ITTTextBox)AddControl(new Guid("7502b2b4-9f2c-4918-af21-ec5e897ab235"));
            lblProtocolNo = (ITTLabel)AddControl(new Guid("93d66438-68e2-4132-8aab-f5c944452e7a"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("6a15dcfe-36d7-4fbb-806c-3268a2dc3f63"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e22de551-69f7-4458-af88-628fce09e8d6"));
            NumberOfStayDays = (ITTTextBox)AddControl(new Guid("22afa26c-2289-4672-82c2-07b1cb97a6e0"));
            labelStayingDate = (ITTLabel)AddControl(new Guid("ec21fa0d-0d6b-4023-ad23-1b580e0c947d"));
            labelNumberOfStayDays = (ITTLabel)AddControl(new Guid("31976f5f-537c-4f28-871e-425e72a1d826"));
            IsCompanionNeeded = (ITTCheckBox)AddControl(new Guid("6c5f65a0-a150-44fa-a208-578ca579944e"));
            labelRoom = (ITTLabel)AddControl(new Guid("0acb4eb0-cb3c-4afe-bccf-5b7bcf6227cd"));
            StayingDate = (ITTDateTimePicker)AddControl(new Guid("75d42fee-b848-4311-b084-5befb4df4cfa"));
            Room = (ITTObjectListBox)AddControl(new Guid("d71ec4dc-f6f5-4535-982a-7a89c65d6a1a"));
            NumberOfLastStayDays = (ITTTextBox)AddControl(new Guid("d92554f6-c868-465f-a5fb-80343fca0e8f"));
            DepartureDate = (ITTDateTimePicker)AddControl(new Guid("baa35ee1-62ff-4d44-8689-9bcf33a72b18"));
            labelNumberOfLastStayDays = (ITTLabel)AddControl(new Guid("2ab3ff17-5b09-43dc-825d-9f87f25bb2db"));
            groupboxNotes = (ITTGroupBox)AddControl(new Guid("cd07c434-1bc3-49b9-af22-bbb6790ee30c"));
            labelNurseNote = (ITTLabel)AddControl(new Guid("a728e50f-1ba0-4d1c-91a6-cb90d1dcbb14"));
            labelSocialNote = (ITTLabel)AddControl(new Guid("9bde59bd-71f6-4e77-b6af-d830b0835786"));
            SocialNote = (ITTTextBox)AddControl(new Guid("0169d54b-ea8b-47ac-87de-f2f919b29051"));
            DoctorNote = (ITTTextBox)AddControl(new Guid("567b40be-4f27-47d7-bb8e-03bcb66bd2f4"));
            NurseNote = (ITTTextBox)AddControl(new Guid("9bf903ad-477f-4cc6-971d-21451d3b73b4"));
            labelDoctorNote = (ITTLabel)AddControl(new Guid("22737699-70ee-4305-97b4-2f59375564a4"));
            labelReasonForDeparture = (ITTLabel)AddControl(new Guid("bc63681a-62d9-4a28-abc3-5e611515a038"));
            ReasonForDeparture = (ITTTextBox)AddControl(new Guid("e58d1bd6-388d-4281-89f7-6799bcf60b0d"));
            groupboxStayingInfo = (ITTGroupBox)AddControl(new Guid("4f2a0150-9f23-4fd2-8eec-d600a48e6687"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1aba204e-46d7-42db-bcc9-dd50062c3f4a"));
            txtGhaziDiagnosis = (ITTTextBox)AddControl(new Guid("7752113d-d232-4584-80d8-01bb97aad62a"));
            txtEvents = (ITTTextBox)AddControl(new Guid("2d98d951-ed48-4687-99f4-0e5e2fa9a351"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("65dcee0b-ca9a-410d-95f3-23dc413accb6"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("767379fe-17f8-48b1-8721-3127ca396731"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("c5b0f5e3-868f-4ec5-9b5f-8e2dd1e48831"));
            txtReasonForStay = (ITTTextBox)AddControl(new Guid("bcf49615-3977-449e-aca8-90132af47787"));
            txtStayingInfo = (ITTTextBox)AddControl(new Guid("40adb99a-6253-4daf-ac3c-b49695d60551"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("5fbff3aa-bcec-4cab-91b3-e2af1ac82d5f"));
            DebitInfo = (ITTTabPage)AddControl(new Guid("790a2120-6bd2-4c5d-88c2-32c44180c310"));
            DispensaryDebits = (ITTGrid)AddControl(new Guid("cb4b4753-aa4a-48d6-bf06-6489cf903b1e"));
            DebitDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("9104f742-5eba-4b7f-9bef-ea99a69a06b0"));
            Debit = (ITTTextBoxColumn)AddControl(new Guid("b6193c92-716d-44b1-95ce-28c5df951441"));
            DrugInfo = (ITTTabPage)AddControl(new Guid("031d4349-6376-4bad-8f02-97327cc3210c"));
            DispensaryDrugs = (ITTGrid)AddControl(new Guid("9cbb13b0-8e3b-4ed5-bf96-96c3df0636a1"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("4a58a2d4-f6ec-42c7-b70d-411c7de6fd1a"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("56805b37-3d8a-4e12-ab56-d97a46ec95d8"));
            BehaviorInfo = (ITTTabPage)AddControl(new Guid("a92be822-886f-4090-a9e1-a97c20bfe028"));
            DispensaryGhaziBehaviors = (ITTGrid)AddControl(new Guid("73a44abc-e8b1-49f9-8fad-9947bd59e7f1"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("3e4496c0-1bb1-42f3-bb40-39cb6c256f8b"));
            Explanation = (ITTTextBoxColumn)AddControl(new Guid("2aa4ffec-e3d8-4f8b-b143-a975d50d921c"));
            Place = (ITTTextBoxColumn)AddControl(new Guid("3e351766-ecca-4209-9ade-770e30a708d0"));
            labelDepartureDate = (ITTLabel)AddControl(new Guid("edf71145-d7de-4ed1-838a-f81452c07c16"));
            LastEvents = (ITTRichTextBoxControl)AddControl(new Guid("6ea303c0-8c46-4953-a697-7ca6a7d513f5"));
            base.InitializeControls();
        }

        public DispensaryForm() : base("DISPENSARY", "DispensaryForm")
        {
        }

        protected DispensaryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}