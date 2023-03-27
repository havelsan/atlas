
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
    /// Ameliyat Sonrası Yoğun Bakım
    /// </summary>
    public partial class IntensiveCareAfterSurgeryProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat Sonrası  Derlenme İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.IntensiveCareAfterSurgery _IntensiveCareAfterSurgery
        {
            get { return (TTObjectClasses.IntensiveCareAfterSurgery)_ttObject; }
        }

        protected ITTObjectListBox TreatmentClinic;
        protected ITTLabel labelTreatmentClinic;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox LastBed;
        protected ITTObjectListBox LastRoomGroup;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox LastRoom;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage BedsTabPage;
        protected ITTGrid BedGrid;
        protected ITTEnumComboBoxColumn UsedStatus;
        protected ITTDateTimePickerColumn BedInPatientDate;
        protected ITTDateTimePickerColumn BedDischargeDate;
        protected ITTListBoxColumn RoomGroup;
        protected ITTListBoxColumn Room;
        protected ITTListBoxColumn Bed;
        protected ITTTextBoxColumn BedAmount;
        protected ITTTabPage EpDiagTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel ttlabel6;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage EstimatingTab;
        protected ITTGrid IntensiveCareEstimatings;
        protected ITTDateTimePickerColumn DateTime;
        protected ITTEnumComboBoxColumn Activite;
        protected ITTEnumComboBoxColumn Respiration;
        protected ITTEnumComboBoxColumn Circulation;
        protected ITTEnumComboBoxColumn Wakefulness;
        protected ITTEnumComboBoxColumn Color;
        protected ITTTextBoxColumn TotalScore;
        protected ITTTabPage NursingProcedureTab;
        protected ITTGrid NursingProceduresGrid;
        protected ITTDateTimePickerColumn npActionDate;
        protected ITTListBoxColumn npProcedureObject;
        protected ITTTextBoxColumn npResult;
        protected ITTTextBoxColumn ntNote;
        protected ITTTabPage MaterialExpend;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn SMActionDate;
        protected ITTListBoxColumn SMMaterial;
        protected ITTTextBoxColumn SMAmount;
        protected ITTTextBoxColumn UBBCode;
        override protected void InitializeControls()
        {
            TreatmentClinic = (ITTObjectListBox)AddControl(new Guid("66e30be6-e791-4c9d-9833-b1b4ce14bd0a"));
            labelTreatmentClinic = (ITTLabel)AddControl(new Guid("266d0286-936b-423d-802c-67b5842e04ba"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("b394e358-2d6e-4286-94a8-560c3034fbc9"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d1c00cea-1d06-4c02-9e03-ee782c5af5b8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("280d3fa6-1d7a-4114-8ba0-5b2469b8f1ff"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("00dff99e-87cf-4211-be4c-1367219584f7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0da3989c-9dd5-409e-be06-389920971259"));
            LastBed = (ITTObjectListBox)AddControl(new Guid("6abf5f86-de84-4f19-a1aa-6c3bd0fe1bbb"));
            LastRoomGroup = (ITTObjectListBox)AddControl(new Guid("2773dc2e-90f7-4761-81a9-737e9da7596b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b901720c-8c17-407d-862d-aadd6078db2f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("253d13a2-1fdf-4d22-934f-bf6787aad918"));
            LastRoom = (ITTObjectListBox)AddControl(new Guid("48e18b89-5020-4bf9-9ddf-df9e6b0ae258"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("2dfcb3b9-ad98-4323-9da7-f0195d402e2c"));
            BedsTabPage = (ITTTabPage)AddControl(new Guid("1b963e33-dd02-4084-b4c3-5623ce335134"));
            BedGrid = (ITTGrid)AddControl(new Guid("be19a709-ee18-4e06-9c42-a04ec5e8239f"));
            UsedStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("c824ac1e-509e-4a90-ac83-96aeede6c927"));
            BedInPatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("1c5efcc6-18ec-4d12-a3c7-0b1d2730a290"));
            BedDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("94bf70bc-85ae-4844-910a-0d5d63428ad7"));
            RoomGroup = (ITTListBoxColumn)AddControl(new Guid("7cc0084c-90c3-4a51-93c4-1d9d63974f7f"));
            Room = (ITTListBoxColumn)AddControl(new Guid("811b382c-8524-482c-8db6-14d9c8a509cd"));
            Bed = (ITTListBoxColumn)AddControl(new Guid("4d1be8be-fd65-47cd-96e9-6032e9f2457e"));
            BedAmount = (ITTTextBoxColumn)AddControl(new Guid("5d9ba9dc-0e68-4285-a873-0ad989c21da1"));
            EpDiagTab = (ITTTabPage)AddControl(new Guid("c4e7f8c8-d6f3-4a27-bb48-ee6fcbe55697"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("8590566d-de29-40af-8315-b65260f4591a"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("013df26b-142e-4186-8bdd-79f632c7f50d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("563608f1-a050-4f12-8cbc-aeb040e6eb2f"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0f6a69f4-e899-40c3-b236-36c59b9a6f6b"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b9e8ef69-ec04-4d1d-b926-c2d28250be0f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("21d3e9b0-17e1-49e0-b33f-4c4262000f93"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8dfb5c30-9599-4f48-9202-53dbeebeae10"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("d1c04e5a-ec5d-4afa-8071-e16c848917d4"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("5e688688-b10b-4239-b78e-ea5caf28b3b2"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("5a5c2386-ef2d-4c9b-9e7b-0d730a030832"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f6a82a35-ce00-4ab6-96f7-05054b4e0da2"));
            EstimatingTab = (ITTTabPage)AddControl(new Guid("c4ca22ae-7883-4023-b661-1865db44586d"));
            IntensiveCareEstimatings = (ITTGrid)AddControl(new Guid("37e2ff73-0e7a-4eda-b7a6-3cffc52c26fa"));
            DateTime = (ITTDateTimePickerColumn)AddControl(new Guid("06d1846b-22ec-4896-ab7f-df235f4ce699"));
            Activite = (ITTEnumComboBoxColumn)AddControl(new Guid("f67a8d5c-a281-46e0-a273-608ef0ce6fb2"));
            Respiration = (ITTEnumComboBoxColumn)AddControl(new Guid("225f7ab4-d298-4eca-9c1d-17796a721349"));
            Circulation = (ITTEnumComboBoxColumn)AddControl(new Guid("d5d4c3b9-bb0d-4361-901f-a16650c5252b"));
            Wakefulness = (ITTEnumComboBoxColumn)AddControl(new Guid("dcdb69c5-13fd-4c0e-81d4-eea066e21eef"));
            Color = (ITTEnumComboBoxColumn)AddControl(new Guid("487736a8-d6cc-4849-b60a-95dbe2cb17ea"));
            TotalScore = (ITTTextBoxColumn)AddControl(new Guid("d61e2c4c-8e7e-4dcb-a8d7-0acda7f49398"));
            NursingProcedureTab = (ITTTabPage)AddControl(new Guid("eea0439e-bbf5-4994-9d3a-137cbdf11f56"));
            NursingProceduresGrid = (ITTGrid)AddControl(new Guid("50ce5139-f032-45c7-8498-8b00ca241d03"));
            npActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("80fb5b20-2547-4d88-9495-d33595f5c76a"));
            npProcedureObject = (ITTListBoxColumn)AddControl(new Guid("91189c71-a526-47ef-bebc-339c67bfa80b"));
            npResult = (ITTTextBoxColumn)AddControl(new Guid("889aac49-de0d-47bd-b348-5e4a7bf83bad"));
            ntNote = (ITTTextBoxColumn)AddControl(new Guid("b026bd04-47de-49f6-98cd-8ac64e636877"));
            MaterialExpend = (ITTTabPage)AddControl(new Guid("9dd14053-4915-4cc6-b5ff-d5e033f9f5bd"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("78c3c28d-9a37-42e6-8350-4ef8e4ed2054"));
            SMActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("fd8e5730-cb66-497d-aa0b-f38079c8acac"));
            SMMaterial = (ITTListBoxColumn)AddControl(new Guid("d56c294c-0e18-4f68-b87b-b44c531d81f5"));
            SMAmount = (ITTTextBoxColumn)AddControl(new Guid("4ee9f9bd-6df1-4d51-813a-19523a542372"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("67263c72-ef1d-4434-9062-1a77c35ce834"));
            base.InitializeControls();
        }

        public IntensiveCareAfterSurgeryProcedureForm() : base("INTENSIVECAREAFTERSURGERY", "IntensiveCareAfterSurgeryProcedureForm")
        {
        }

        protected IntensiveCareAfterSurgeryProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}