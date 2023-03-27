
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
    /// Fizyoterapi Uygulaması
    /// </summary>
    public partial class PhysiotherapyOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// F.T.R. Emrinin  Uygulamasının Gerçekleştirildiği NEsnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrderDetail _PhysiotherapyOrderDetail
        {
            get { return (TTObjectClasses.PhysiotherapyOrderDetail)_ttObject; }
        }

        protected ITTCheckBox Emergency;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox Physiotherapist;
        protected ITTObjectListBox ProcedureObject;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBox tttextboxDescription;
        protected ITTLabel labelTreatmentRoom;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTDateTimePicker WorklistDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelPhysiotherapyDoctor;
        protected ITTLabel labelSDateTime;
        protected ITTObjectListBox TreatmentRoom;
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
        override protected void InitializeControls()
        {
            Emergency = (ITTCheckBox)AddControl(new Guid("c49f696a-7e3a-47aa-970c-d06be836d26d"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("fa678506-f251-4796-b7bb-022e0a5a9380"));
            labelProcedure = (ITTLabel)AddControl(new Guid("b28de563-aaf9-4e35-89c2-1eff4b3bb1f1"));
            labelActionDate = (ITTLabel)AddControl(new Guid("bb2ccd7c-c1b5-4147-8e0f-45a4dfc82015"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("5f44fb6f-8048-44cb-bbe3-4df3cb899e6e"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("55e37302-70c6-4657-b39d-8127033f95f3"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("ec67b554-a8cf-4a93-9946-9cd58012d4c1"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("e3b0be23-13e0-4510-9a47-7a7c01f2247a"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("8fb96bb6-5a97-4ca4-84dd-c1d8fa42f362"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("661733a8-65c0-413b-97ac-4bb7b5fe6384"));
            Material = (ITTListBoxColumn)AddControl(new Guid("cbb7c523-e72c-450b-a66d-32ef8c845be3"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("bff715e4-8dcd-42b0-a164-64d0f4fb3da6"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("3edceafa-4317-4aae-9e24-c1843333813f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("ddf25427-fa07-4c28-a99c-cde3f688e472"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("07856518-6ca1-461f-9390-b92d2633f1a6"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("fac2520a-93f1-4f3a-b65e-8dd87acadde1"));
            labelTreatmentRoom = (ITTLabel)AddControl(new Guid("9628b75d-a774-4c1d-ae33-9f3e7925c021"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("1d5955eb-72e5-4128-9eb9-b7db170ef119"));
            WorklistDate = (ITTDateTimePicker)AddControl(new Guid("f20695eb-cd29-450c-ab29-c551708d5ea2"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("0e6af9e0-ace2-4408-9a92-d352f6fa49c4"));
            labelPhysiotherapyDoctor = (ITTLabel)AddControl(new Guid("80b86853-07b7-4c74-8f94-e1d505cb717f"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("ac580d17-fc97-4aa1-a521-fb0e8235cc28"));
            TreatmentRoom = (ITTObjectListBox)AddControl(new Guid("0b673570-28b4-43dc-8445-ff6fe3c2c12a"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("ae0a537e-3095-4752-948d-6094b00adeeb"));
            CancelRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("10648adf-dda1-4f60-b331-6c45df97abc8"));
            labelCancelRequestDescription = (ITTLabel)AddControl(new Guid("4340574c-223c-46e5-87b3-22e79402a76c"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("c06d2c06-ae3d-4e7a-9fa4-25df7ef49a63"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("b38e6c61-ea1c-4a51-9c38-0bfb061f8bb6"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("d2955848-1821-4704-9326-08a8cfa0a614"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("c63c6b47-a96c-4857-86c2-299c046f3d08"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("74ad1363-f8ab-4258-b596-f6911eb5b01e"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("47f2eb39-291c-4119-b536-3d8c8089ff07"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("a1c39d3e-6235-4626-9642-d92a6d6b4b12"));
            Room = (ITTObjectListBox)AddControl(new Guid("3b03c576-2356-49f9-8e5e-15818c21533d"));
            labelRoom = (ITTLabel)AddControl(new Guid("6c9d3f14-1706-4980-a1fc-e281c119c23c"));
            Bed = (ITTObjectListBox)AddControl(new Guid("853561f5-1e9e-4de8-8595-3e66f4766e90"));
            labelBed = (ITTLabel)AddControl(new Guid("d7c3517a-1923-4610-bf93-fe214cf146f4"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderDetailForm() : base("PHYSIOTHERAPYORDERDETAIL", "PhysiotherapyOrderDetailForm")
        {
        }

        protected PhysiotherapyOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}