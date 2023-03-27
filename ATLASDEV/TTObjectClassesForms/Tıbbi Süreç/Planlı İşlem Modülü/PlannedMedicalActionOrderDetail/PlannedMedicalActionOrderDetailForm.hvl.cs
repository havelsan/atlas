
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
    /// Planlı Tıbbi İşlem Uygulaması
    /// </summary>
    public partial class PlannedMedicalActionOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem Uygulama
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionOrderDetail _PlannedMedicalActionOrderDetail
        {
            get { return (TTObjectClasses.PlannedMedicalActionOrderDetail)_ttObject; }
        }

        protected ITTCheckBox Emergency;
        protected ITTRichTextBoxControl Note;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ProcedureDoctor;
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
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListBoxColumn MalzemeBilgisi_OzelDurum;
        protected ITTTextBox tttextboxDescription;
        protected ITTLabel labelTreatmentUnit;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTDateTimePicker WorklistDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelDoctor;
        protected ITTLabel labelSDateTime;
        protected ITTObjectListBox TreatmentUnit;
        protected ITTLabel ttlabelDescription;
        protected ITTRichTextBoxControl CancelRequestDescription;
        protected ITTLabel labelCancelRequestDescription;
        protected ITTRichTextBoxControl DoctorReturnDescription;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTCheckBox chkInPatientBed;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelBed;
        protected ITTRichTextBoxControl templateRTF;
        override protected void InitializeControls()
        {
            Emergency = (ITTCheckBox)AddControl(new Guid("06aa9b67-12b8-437d-8a58-666cfddfdd98"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("6166fd8e-8485-41ad-be49-4750e82997c1"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("f95fc30a-8c83-45e9-8aee-7abcf31e0ff6"));
            labelProcedure = (ITTLabel)AddControl(new Guid("1901dad3-a161-4434-a08a-bdbc248dbb11"));
            labelActionDate = (ITTLabel)AddControl(new Guid("99dc917e-cbff-4b67-91c1-79e8bc7eb4ab"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("df5e69b2-dd55-4698-aa60-d1527dc55a6a"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("576bf190-9474-46f1-8b61-e0555c64bcef"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("ef633762-dc0b-4059-b680-794cc71a5602"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("7e3dd30b-b603-40d6-82be-8432e7cf21c3"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("3c751a5e-896c-4149-9e12-c134f0cecbbe"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("15c74ca9-1129-40db-9d2d-79a214cc298b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("215e8778-7a4d-4983-bc98-750314b27459"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("63836be2-3e05-4d40-9aa1-5a249e04914c"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("10693cb8-7897-4e29-b138-55f565160592"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("8d91563e-e43c-470b-9c19-987e03547f84"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("89f3cbc4-3edb-4684-8d15-6e0bc3f4ccc9"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("27b9fbde-4fb7-481b-aee6-98c52074bbff"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("17edede7-5dfb-402b-84b5-f967115f89e3"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("724478b1-884b-4771-835b-93da6188cea6"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("fbcecb3a-3516-4b62-82a5-d7b39dc0523b"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("071c59f2-09e9-4253-9b67-6f2ce2dec479"));
            MalzemeBilgisi_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("be966917-13e8-40c0-b8a0-9d61a8f8a401"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("ff994c38-4b37-47c6-89a5-859654ec9494"));
            labelTreatmentUnit = (ITTLabel)AddControl(new Guid("2a3dbd5e-6892-4bc9-8a42-c9577847f131"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("8b51bc3c-266d-4282-9c42-21867bf30f04"));
            WorklistDate = (ITTDateTimePicker)AddControl(new Guid("f7ce76d8-0a71-40da-a262-f0e2bebc0fcd"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("1a59a656-cdf2-4264-8f66-a81eeb5df611"));
            labelDoctor = (ITTLabel)AddControl(new Guid("64c0e748-992a-4867-b905-1a83a163a40c"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("24346156-332e-42af-9e07-cab6e7c7a5fd"));
            TreatmentUnit = (ITTObjectListBox)AddControl(new Guid("a68136fa-2d3f-47c6-933b-0a96450d0c97"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("d56ca722-ec3d-45fa-898e-2ad47ecdaf6c"));
            CancelRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("ba0e88a2-22b9-46eb-b9f8-031c9f2a8fe4"));
            labelCancelRequestDescription = (ITTLabel)AddControl(new Guid("668be3ad-7475-4a72-93d1-5e096c74f6e6"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("93855b3d-6f34-4a74-bebb-29f7a049d64e"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("fdd556db-4670-4196-82b7-95ef87b39392"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("36381e58-6e0a-49c4-85ba-138d7acf194e"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("d1593c66-de02-4c45-bdc0-bb3621460568"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("df8b807c-7510-4d45-889d-c30a141fff6d"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("d4543bee-63f5-4a96-b7c3-37776ab4bea3"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("98b607f9-c794-4817-8fbc-3c5b339f45f9"));
            Room = (ITTObjectListBox)AddControl(new Guid("09134818-5611-4e40-80ab-11bb391a1e6d"));
            labelRoom = (ITTLabel)AddControl(new Guid("5335f6c6-7f57-4722-9197-6192fd2db26e"));
            Bed = (ITTObjectListBox)AddControl(new Guid("79f23a9a-d668-4bbf-9622-3789b93f985d"));
            labelBed = (ITTLabel)AddControl(new Guid("7fa929d2-54d0-467d-8daa-d30bcc23b52b"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("7bcf80d1-5980-41eb-8fd6-147f8b809370"));
            base.InitializeControls();
        }

        public PlannedMedicalActionOrderDetailForm() : base("PLANNEDMEDICALACTIONORDERDETAIL", "PlannedMedicalActionOrderDetailForm")
        {
        }

        protected PlannedMedicalActionOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}