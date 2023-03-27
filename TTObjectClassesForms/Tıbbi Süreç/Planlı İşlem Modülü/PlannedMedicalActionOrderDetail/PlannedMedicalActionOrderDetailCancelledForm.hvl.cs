
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
    public partial class PlannedMedicalActionOrderDetailCancelledForm : SubactionProcedureFlowableForm
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
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelTreatmentUnit;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTDateTimePicker WorklistDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelDoctor;
        protected ITTLabel labelSDateTime;
        protected ITTObjectListBox TreatmentUnit;
        protected ITTLabel ttlabelDescription;
        protected ITTLabel labelReasonOfReject;
        override protected void InitializeControls()
        {
            Emergency = (ITTCheckBox)AddControl(new Guid("03130435-fbbb-463c-bc03-b123e655f8ee"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("4cc182b3-777a-4486-a94a-d7512389fb77"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("206ebe89-84b9-4341-90fb-493178e27c4a"));
            labelProcedure = (ITTLabel)AddControl(new Guid("e8a53291-8901-4f54-bb7d-5d13d9a8659c"));
            labelActionDate = (ITTLabel)AddControl(new Guid("97d67fe1-461b-4386-8010-25a2a747a34f"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("959e421d-7836-42ca-948a-e4f4ec5b3fcb"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("ad624f67-2a00-4e95-aedc-2eda6c7d63a8"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("2255fd00-8586-4997-a347-151b32d1ab6e"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("1d853f9c-94d4-4ebe-80ee-e07a27fa55e2"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("a3822d86-5eb4-4ce0-a690-34bf4a01500d"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("0b222100-f0c5-4bd3-b034-796b713dbe8e"));
            Material = (ITTListBoxColumn)AddControl(new Guid("0fab8009-2745-4058-8062-5dca59a3d927"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("5c6f9f7b-4483-4e39-95ff-bd2572bf003a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("323b1dad-911c-4b7e-ac8c-3fa68c79dbbf"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("25a32b19-5ca1-4d83-8a3f-684a6c40d015"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("67d8661f-1b12-4a78-a6c5-b386c88ba732"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("caeeabab-f733-4772-8118-c62fdf73e00e"));
            labelTreatmentUnit = (ITTLabel)AddControl(new Guid("eb9ee944-b02a-401c-b373-fd2c994f206e"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("fd333fdb-8d1f-43e9-8398-28b19fba5b25"));
            WorklistDate = (ITTDateTimePicker)AddControl(new Guid("04d0d7cf-c321-41d7-b9ed-404e6e53549b"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("04026610-0f28-4afc-b263-b77b6b298b32"));
            labelDoctor = (ITTLabel)AddControl(new Guid("37f6d1b0-02d2-4435-92c9-253f25b35908"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("69c4997d-4904-4d35-9b92-d3790545c97e"));
            TreatmentUnit = (ITTObjectListBox)AddControl(new Guid("4e96b6df-25db-4abe-9d9d-8afcc56e43e8"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("b4a7dd86-d332-441b-98dd-b0c0527a7ba5"));
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("f09321a0-da15-4284-a589-7f359162cc60"));
            base.InitializeControls();
        }

        public PlannedMedicalActionOrderDetailCancelledForm() : base("PLANNEDMEDICALACTIONORDERDETAIL", "PlannedMedicalActionOrderDetailCancelledForm")
        {
        }

        protected PlannedMedicalActionOrderDetailCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}