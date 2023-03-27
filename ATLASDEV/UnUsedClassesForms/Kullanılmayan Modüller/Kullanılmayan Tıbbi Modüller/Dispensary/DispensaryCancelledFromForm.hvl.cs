
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
    public partial class DispensaryCancelledFrom : EpisodeActionForm
    {
    /// <summary>
    /// Bakımevi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Dispensary _Dispensary
        {
            get { return (TTObjectClasses.Dispensary)_ttObject; }
        }

        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelReasonOfCancel;
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
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("3293c19e-8a99-405b-93dc-da4349edaef9"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("79fd5e8d-4916-411c-aced-9072c5118a45"));
            txtProtocolNo = (ITTTextBox)AddControl(new Guid("3838465d-2e0c-48bd-8c98-60fe1175cbf7"));
            lblProtocolNo = (ITTLabel)AddControl(new Guid("d00a875c-d64f-4e86-8e85-304b30502511"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("6b21603c-2f4f-4e6a-8911-fa82bf317ed1"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8fe6f069-7c32-4aa6-b9c0-dda7733f1744"));
            NumberOfStayDays = (ITTTextBox)AddControl(new Guid("784bc4ae-06d6-4adc-8af0-dd0a49854110"));
            labelStayingDate = (ITTLabel)AddControl(new Guid("51c35ac0-77a0-47f1-8571-4bd1bf41b51e"));
            labelNumberOfStayDays = (ITTLabel)AddControl(new Guid("0f97c214-b88f-4625-a048-c876c1430727"));
            IsCompanionNeeded = (ITTCheckBox)AddControl(new Guid("5996062f-165a-48d2-937d-eeea773324a5"));
            labelRoom = (ITTLabel)AddControl(new Guid("c536c453-103d-44ee-8070-d5110f2e1e92"));
            StayingDate = (ITTDateTimePicker)AddControl(new Guid("a3de58b3-5111-4610-b9f1-6015f8fa5b50"));
            Room = (ITTObjectListBox)AddControl(new Guid("937ce6fc-2b9b-44cc-b979-213b7e089928"));
            NumberOfLastStayDays = (ITTTextBox)AddControl(new Guid("66b4c189-8104-4e17-b892-eb17dc73aa6d"));
            DepartureDate = (ITTDateTimePicker)AddControl(new Guid("5f81bcf9-dd67-4bb9-85bf-14de6b96fba7"));
            labelNumberOfLastStayDays = (ITTLabel)AddControl(new Guid("5c60b22e-cdfc-4f43-9ad9-0866c37eaa13"));
            groupboxNotes = (ITTGroupBox)AddControl(new Guid("7ceaf3ad-1477-4168-b59a-90efb6988832"));
            labelNurseNote = (ITTLabel)AddControl(new Guid("8fe30c63-2389-4f17-bd0e-43886b1aeae7"));
            labelSocialNote = (ITTLabel)AddControl(new Guid("060af664-98f8-42a2-a917-cbb67d4d20a2"));
            SocialNote = (ITTTextBox)AddControl(new Guid("d08c1034-e76a-4d87-a7f4-258e426827be"));
            DoctorNote = (ITTTextBox)AddControl(new Guid("ae66191d-2687-48b5-b434-cc88ad2e6136"));
            NurseNote = (ITTTextBox)AddControl(new Guid("0d8fcbb5-41dd-4913-9ff3-43e2e7985ed8"));
            labelDoctorNote = (ITTLabel)AddControl(new Guid("7015e3ff-8477-4d69-9353-b714f92b4417"));
            labelReasonForDeparture = (ITTLabel)AddControl(new Guid("bc1745b9-9b3b-4a23-9c6e-8530a81d057b"));
            ReasonForDeparture = (ITTTextBox)AddControl(new Guid("53b1cd13-370f-444f-89c0-6cddf47e67aa"));
            groupboxStayingInfo = (ITTGroupBox)AddControl(new Guid("b94000c5-59f5-477b-b8fa-83548a9e15a7"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("164b15bc-6276-45fb-b1b6-3b72fa23b6d3"));
            txtGhaziDiagnosis = (ITTTextBox)AddControl(new Guid("d2507aa0-5bfb-4e0c-a9b8-18ac35348791"));
            txtEvents = (ITTTextBox)AddControl(new Guid("0370751b-cce9-44aa-b790-78b74b493d63"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3c347404-e982-4375-b9ba-42ff5252f5b8"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d6f4b5b5-cc95-4336-9aed-a70ea05cfd20"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("49ea8023-a3c7-4b51-96f2-87820a92161f"));
            txtReasonForStay = (ITTTextBox)AddControl(new Guid("09a9448d-7bc5-4120-bcda-0042fa2ea221"));
            txtStayingInfo = (ITTTextBox)AddControl(new Guid("e459697d-585a-4b50-8c6b-69ce72982722"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("72e0028b-747f-4c4e-873d-faad5cebe52c"));
            DebitInfo = (ITTTabPage)AddControl(new Guid("59882044-c183-4938-abb0-78c04b683f87"));
            DispensaryDebits = (ITTGrid)AddControl(new Guid("1504006c-0399-48d0-b39f-336d14f6930d"));
            DebitDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("b1ab6c7b-f37d-4c7c-a583-48a5cfd7d259"));
            Debit = (ITTTextBoxColumn)AddControl(new Guid("8347c7c6-9080-4d28-9ac0-919c8502a23a"));
            DrugInfo = (ITTTabPage)AddControl(new Guid("685728c2-8f78-4fe3-9971-48feaffaa995"));
            DispensaryDrugs = (ITTGrid)AddControl(new Guid("bf8ea9cd-5589-4614-a179-761f320fb1c4"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("4005f715-06c2-4376-8748-ad93904c6566"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("1a96de4c-0e89-4282-ba14-be4b2e54aba1"));
            BehaviorInfo = (ITTTabPage)AddControl(new Guid("6890b8e6-2a26-4f79-8d80-d875efed9394"));
            DispensaryGhaziBehaviors = (ITTGrid)AddControl(new Guid("aa19e7dd-c3f4-4057-99c8-6ce028249e1e"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("450b9382-ba00-4767-9059-8a13b6be5776"));
            Explanation = (ITTTextBoxColumn)AddControl(new Guid("8522274b-6f73-4651-8cfd-662b015cfac0"));
            Place = (ITTTextBoxColumn)AddControl(new Guid("7e7f8f32-28fb-45f7-a411-f7fccf8c19b9"));
            labelDepartureDate = (ITTLabel)AddControl(new Guid("0e423aed-6429-4ee9-a26d-48f286340ae3"));
            LastEvents = (ITTRichTextBoxControl)AddControl(new Guid("54e9d8b4-830a-4d03-b7a6-fcea0c1d4ba9"));
            base.InitializeControls();
        }

        public DispensaryCancelledFrom() : base("DISPENSARY", "DispensaryCancelledFrom")
        {
        }

        protected DispensaryCancelledFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}