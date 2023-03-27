
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
    /// Diyaliz Uygulamaları
    /// </summary>
    public partial class DialysisOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
        protected TTObjectClasses.DialysisOrderDetail _DialysisOrderDetail
        {
            get { return (TTObjectClasses.DialysisOrderDetail)_ttObject; }
        }

        protected ITTObjectListBox TreatmentEquipment;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelDialysisNurse;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTTextBox Note;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelNote;
        protected ITTLabel labelTreatmentEquipment;
        protected ITTLabel labelSDateTime;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBox tttextboxDescription;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelProcedure;
        protected ITTObjectListBox Nurse;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabelDescription;
        protected ITTRichTextBoxControl CancelRequestDescription;
        protected ITTLabel labelCancelRequestDescription;
        protected ITTRichTextBoxControl DoctorReturnDescription;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTRichTextBoxControl templateRTF;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelBed;
        protected ITTCheckBox chkInPatientBed;
        override protected void InitializeControls()
        {
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("1d75a417-b7b6-4498-a167-0af9b2be25f4"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("52e04631-6985-4d75-8542-0e91d87018ab"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e5a1860c-66af-42e2-bc1f-1294c194cac8"));
            labelDialysisNurse = (ITTLabel)AddControl(new Guid("2fefe906-8835-437e-a807-1cd54710fdba"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("be6c657f-7092-4e28-8d70-23a56e9d4894"));
            Note = (ITTTextBox)AddControl(new Guid("d525ea5c-7d66-4fe1-8c5b-2923ee4782bd"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("dc961ed3-fb50-4992-b844-373dc5eb014b"));
            labelNote = (ITTLabel)AddControl(new Guid("f379a8a7-8bf8-4fa0-a9f2-3856256f6912"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("1b9fd46c-cec2-44cc-8ca4-55ac9aa2f1fd"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("798a6b0e-f7c6-48e6-90ba-58e5f9d52ade"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("1825423e-d5aa-424b-b085-6b6e3b6ee2ac"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("0aff4c1d-9daf-4b8c-bd7c-c8bb09196ae3"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("c90a423d-be95-473e-b61a-d1c2e8cbfdee"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("90374534-d157-40a7-af1d-13586fd5c503"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a85545a2-36c1-4f8b-b378-3782b1a78dee"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("83d373e3-b78f-4e23-9929-ac120d7af445"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("6cac8ff0-8f17-465e-8cb9-3d20b6d4cf21"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("07b5619f-a288-4535-af68-09c5656872e4"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("a5a978bb-b2d3-4ac1-82da-0ffbd980f0cd"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("81aa995e-e8ea-432e-b6e6-a836815c7260"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("fa2662af-04a8-4643-8ff3-824d8c25b50e"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("cbd1daa9-dc3f-4769-9635-569aaa45b845"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("624ccebc-3882-4723-a098-a308ec76e7d1"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("1f13e2f5-0764-425c-9a1a-105e161b6044"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("fafa6eae-142d-40da-b856-1d57250c7cee"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("2e691233-51b4-4f33-a53a-0094655d2a89"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("7570e312-b914-4a07-9993-8903e7619a7a"));
            labelProcedure = (ITTLabel)AddControl(new Guid("70976b70-4c60-4bfa-9e12-985b5a934bde"));
            Nurse = (ITTObjectListBox)AddControl(new Guid("946bec46-fe2f-4050-a0e7-b7f13168c0c2"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("267e1d30-4985-4d88-b3af-c3c1b7da3cdf"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("172c070d-eb5c-4dad-8197-44d1a1e5397a"));
            CancelRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("574c6de9-586f-4c35-95e7-9c5e3fe4bb68"));
            labelCancelRequestDescription = (ITTLabel)AddControl(new Guid("0fb3670a-6d00-4540-81c5-6de3f4f49392"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("11a83aee-42bc-496a-b2a8-d2953eb7af97"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("6c5518ea-b058-4b1f-806e-80ce6532d7e1"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("0dcebd1d-5b94-4465-8914-dd767a3f2fe9"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("a942a4bd-6ede-4b89-b615-07fe6b6b7eaa"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("8ef02b1c-ce6a-4cb5-93fe-b14ef63f6b76"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("449b502f-5649-40e5-b43f-a3dd400a4e38"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("60b87b7a-817d-400a-a5a9-5a49d139e4d8"));
            Room = (ITTObjectListBox)AddControl(new Guid("7c55401c-6390-4ebe-8fc0-f9cc37cfcf0d"));
            labelRoom = (ITTLabel)AddControl(new Guid("eb63ca8d-243e-4d56-9ebf-bfbbe2bf15bc"));
            Bed = (ITTObjectListBox)AddControl(new Guid("7ccc4c48-4ad7-4391-a933-cd6037010ecf"));
            labelBed = (ITTLabel)AddControl(new Guid("4eb2da4e-8f6d-4396-b004-2cd9c62d2cf7"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("0a2bcf1f-30cb-417f-954d-8443c1ee58ba"));
            base.InitializeControls();
        }

        public DialysisOrderDetailForm() : base("DIALYSISORDERDETAIL", "DialysisOrderDetailForm")
        {
        }

        protected DialysisOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}