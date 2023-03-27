
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
    public partial class DispensaryCheckInForm : EpisodeActionForm
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
        protected ITTLabel labelNumberOfLastStayDays;
        protected ITTGroupBox groupboxStayingInfo;
        protected ITTTextBox txtGhaziDiagnosis;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel7;
        protected ITTTextBox txtReasonForStay;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DebitInfo;
        protected ITTGrid DispensaryDebits;
        protected ITTDateTimePickerColumn DebitDateTime;
        protected ITTTextBoxColumn Debit;
        protected ITTTabPage DrugInfo;
        protected ITTGrid DispensaryDrugs;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Drug;
        protected ITTRichTextBoxControl LastEvents;
        override protected void InitializeControls()
        {
            txtProtocolNo = (ITTTextBox)AddControl(new Guid("6f849aa9-6c7d-4874-901f-9d2988e2120c"));
            lblProtocolNo = (ITTLabel)AddControl(new Guid("0d69add1-ee82-4786-9858-e7ddf023ecf6"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("bcc812c4-71fc-499e-b653-3d2858621163"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f2001d0a-9198-48b4-8fe0-6f6f6d74c2ea"));
            NumberOfStayDays = (ITTTextBox)AddControl(new Guid("91d00259-3de7-4780-88e5-37743702e248"));
            labelStayingDate = (ITTLabel)AddControl(new Guid("b98a01f7-07b9-4f95-9cc1-2a0a571d9dfa"));
            labelNumberOfStayDays = (ITTLabel)AddControl(new Guid("6c508b19-b04a-4ab6-8593-71700c5b452b"));
            IsCompanionNeeded = (ITTCheckBox)AddControl(new Guid("07dbdd80-73e6-4a65-86a1-86ffa0e5a71b"));
            labelRoom = (ITTLabel)AddControl(new Guid("b90ae417-9d16-4ec0-9155-5aeb1eb9e520"));
            StayingDate = (ITTDateTimePicker)AddControl(new Guid("3f734fd5-836b-49bf-a31b-4ff87f7f8462"));
            Room = (ITTObjectListBox)AddControl(new Guid("405524a3-240a-4f75-bf7d-10f89b4b6fe4"));
            NumberOfLastStayDays = (ITTTextBox)AddControl(new Guid("71e3426b-189a-4c13-978f-183c32f859c4"));
            labelNumberOfLastStayDays = (ITTLabel)AddControl(new Guid("3d27bfa6-a752-40e5-9a91-f8a647a12068"));
            groupboxStayingInfo = (ITTGroupBox)AddControl(new Guid("c932fcb0-be74-4b67-bdd4-c1ead5d0ecd2"));
            txtGhaziDiagnosis = (ITTTextBox)AddControl(new Guid("70e2ada8-efe2-4945-b368-cffe8ee461d2"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3ae44397-4c69-4411-b2fa-68cff9105f32"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("c30633c1-4bc8-43cb-9da5-79da2d3d7e67"));
            txtReasonForStay = (ITTTextBox)AddControl(new Guid("218195d3-bc33-4f0b-95b4-675e21a8fe4d"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("6ad182fc-fd24-41ae-a766-ea704bd144be"));
            DebitInfo = (ITTTabPage)AddControl(new Guid("48142d28-0674-4d05-bb22-4623bf88b9b0"));
            DispensaryDebits = (ITTGrid)AddControl(new Guid("92f2ac85-ce3e-473f-aebe-90bdb782aec3"));
            DebitDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("5aca883d-1071-4ff0-b171-f233cb143126"));
            Debit = (ITTTextBoxColumn)AddControl(new Guid("7baecbd0-1434-4971-a4f3-477a7c7c961a"));
            DrugInfo = (ITTTabPage)AddControl(new Guid("5189cf81-394b-45e8-bbe7-3c9c662344c8"));
            DispensaryDrugs = (ITTGrid)AddControl(new Guid("b8d5c38c-58fe-4c27-a998-bf3143c7de5e"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b3c5d9ca-6cd7-4dc5-b486-8bf5ba092f47"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("64fc6403-e168-4936-8822-8374504452b8"));
            LastEvents = (ITTRichTextBoxControl)AddControl(new Guid("f92c82d0-fb37-4f18-a011-bcd624bc410e"));
            base.InitializeControls();
        }

        public DispensaryCheckInForm() : base("DISPENSARY", "DispensaryCheckInForm")
        {
        }

        protected DispensaryCheckInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}