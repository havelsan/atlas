
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
    public partial class DispensaryApprovalForm : EpisodeActionForm
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
        protected ITTLabel labelNumberOfLastStayDays;
        protected ITTTextBox DoctorNote;
        protected ITTTextBox ReasonForStay;
        protected ITTTextBox GhaziDiagnosis;
        protected ITTLabel labelReasonForStay;
        protected ITTTextBox NumberOfStayDays;
        protected ITTLabel labelNumberOfStayDays;
        protected ITTLabel labelGhaziDiagnosis;
        protected ITTLabel labelDoctorNote;
        protected ITTTextBox NumberOfLastStayDays;
        protected ITTCheckBox IsCompanionNeeded;
        protected ITTRichTextBoxControl ReasonOfReject;
        protected ITTLabel labelReasonOfReject;
        protected ITTRichTextBoxControl LastEvents;
        override protected void InitializeControls()
        {
            txtProtocolNo = (ITTTextBox)AddControl(new Guid("78143914-f249-457f-8d8c-7ee86e73400f"));
            lblProtocolNo = (ITTLabel)AddControl(new Guid("3255a1d5-e5ce-4fd1-90e1-f917c0598518"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("6e76ab61-f61f-4b1b-b7b5-3b0c9675defb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("97da584c-177f-4394-bad5-1ed3cf56ccc1"));
            labelNumberOfLastStayDays = (ITTLabel)AddControl(new Guid("5f34a425-f5d7-4a87-a5f7-0986e62484f6"));
            DoctorNote = (ITTTextBox)AddControl(new Guid("b8364933-1132-4fca-8b0a-13c582b5905f"));
            ReasonForStay = (ITTTextBox)AddControl(new Guid("04a9c79e-949b-4ff2-b0b0-16aa2957def1"));
            GhaziDiagnosis = (ITTTextBox)AddControl(new Guid("883e0034-3643-4fed-b9d1-2b8bc6155381"));
            labelReasonForStay = (ITTLabel)AddControl(new Guid("7f834a85-bcb2-4f8b-a0f1-89e4e1a32a4f"));
            NumberOfStayDays = (ITTTextBox)AddControl(new Guid("aa4cdc1f-31ad-419a-a20d-991556cbbe68"));
            labelNumberOfStayDays = (ITTLabel)AddControl(new Guid("cb4ebf59-9135-4c15-8b78-a24d25c9b71b"));
            labelGhaziDiagnosis = (ITTLabel)AddControl(new Guid("5d0663d0-54c8-49e8-9bec-b64a733aeabd"));
            labelDoctorNote = (ITTLabel)AddControl(new Guid("e9dece6d-b89b-453c-93d8-b895950f47ee"));
            NumberOfLastStayDays = (ITTTextBox)AddControl(new Guid("9f007541-9525-45f7-bceb-eaa1ccf5cb4a"));
            IsCompanionNeeded = (ITTCheckBox)AddControl(new Guid("4564b0b6-b431-4c31-8f5f-f075cfab3c44"));
            ReasonOfReject = (ITTRichTextBoxControl)AddControl(new Guid("4d0f6e8b-1fa4-4c4c-9e5e-9eb91e296bbe"));
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("f12bd3c5-d868-43de-a8b8-b83c0e0c935e"));
            LastEvents = (ITTRichTextBoxControl)AddControl(new Guid("12f9c3b4-29bd-40d4-b341-07ede70dd716"));
            base.InitializeControls();
        }

        public DispensaryApprovalForm() : base("DISPENSARY", "DispensaryApprovalForm")
        {
        }

        protected DispensaryApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}