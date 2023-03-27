
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
    /// Diş Laboratuar İşlemleri
    /// </summary>
    public partial class DentalLaboratoryForm : EpisodeActionForm
    {
    /// <summary>
    /// Diş Laboratuar Kontrol
    /// </summary>
        protected TTObjectClasses.DentalLaboratoryProcedure _DentalLaboratoryProcedure
        {
            get { return (TTObjectClasses.DentalLaboratoryProcedure)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTEnumComboBox enumTechType;
        protected ITTGrid gridTechnician;
        protected ITTCheckBoxColumn chose;
        protected ITTTextBoxColumn Ad;
        protected ITTEnumComboBoxColumn TECHNICIANTYPE;
        protected ITTTextBoxColumn TotalWorksNum;
        protected ITTTextBoxColumn CurrentWorksNum;
        protected ITTTextBoxColumn TechnicianObjectId;
        protected ITTButton ttbutton1;
        protected ITTGrid gridProcedures;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTDateTimePickerColumn date;
        protected ITTListBoxColumn ProsProc;
        protected ITTEnumComboBoxColumn DisNo;
        protected ITTListBoxColumn TECHNICIAN;
        protected ITTEnumComboBoxColumn Durum;
        protected ITTTextBoxColumn color;
        protected ITTTextBoxColumn ExternalLab;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MaterialAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn Note;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSAtinAlisTarihi;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTListBoxColumn MalzemeBilgisi_OzelDurum;
        protected ITTTabPage tttabpage1;
        protected ITTObjectListBox TTListBoxExternalLab;
        protected ITTButton ttbutton2;
        protected ITTLabel labelDoctor;
        protected ITTObjectListBox Doctor;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("347a7cef-8b48-46a7-b028-3b0b73235ca6"));
            enumTechType = (ITTEnumComboBox)AddControl(new Guid("224f2e68-a1e5-45a9-91e4-d30fe0f28f00"));
            gridTechnician = (ITTGrid)AddControl(new Guid("f8e48728-0909-446e-9bd1-09ef6a4cf7ca"));
            chose = (ITTCheckBoxColumn)AddControl(new Guid("7dcf41ef-0826-4180-8c5b-8af4ee02a71e"));
            Ad = (ITTTextBoxColumn)AddControl(new Guid("74a86905-66f6-490c-a477-e04320413ff9"));
            TECHNICIANTYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("f5798efd-6cb4-4693-a6e8-175bf5d650a8"));
            TotalWorksNum = (ITTTextBoxColumn)AddControl(new Guid("95b789a5-c6f5-4833-915e-c0c6fd325021"));
            CurrentWorksNum = (ITTTextBoxColumn)AddControl(new Guid("5c8fa20b-e468-4336-ac5b-95eec9efb4c6"));
            TechnicianObjectId = (ITTTextBoxColumn)AddControl(new Guid("3a54398f-69e9-4c93-aaa3-5581fcd51535"));
            ttbutton1 = (ITTButton)AddControl(new Guid("9003fc4a-fc39-4900-a14d-e4cc13833aff"));
            gridProcedures = (ITTGrid)AddControl(new Guid("745d52cc-9a01-4bf6-9a1c-7810c2470a9e"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("376f32b1-f71e-4837-9dab-6866c2adbc05"));
            date = (ITTDateTimePickerColumn)AddControl(new Guid("147d733d-ac83-490a-b407-a2121acca6c5"));
            ProsProc = (ITTListBoxColumn)AddControl(new Guid("c7136126-426d-4ccf-a414-8effbf6e9df3"));
            DisNo = (ITTEnumComboBoxColumn)AddControl(new Guid("2fb6bbc8-a8e0-4171-82cb-ae5dad47f7f9"));
            TECHNICIAN = (ITTListBoxColumn)AddControl(new Guid("baa2d903-cb9e-47a1-8952-e065f0612a26"));
            Durum = (ITTEnumComboBoxColumn)AddControl(new Guid("5ec27b1c-4463-4a8c-8f1f-0c2c085675a7"));
            color = (ITTTextBoxColumn)AddControl(new Guid("7904fd20-d607-48d7-8599-6475f2f3d32c"));
            ExternalLab = (ITTTextBoxColumn)AddControl(new Guid("db2966bf-a4d3-4186-88b9-ed5d28c9b4b9"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("ea6659a7-455f-4cd4-9633-7cb9ba86027b"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("6139af65-ccae-49be-8465-27cc7cd85376"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("18e020fb-7fe7-404c-8303-85f18f99e60a"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("142383ed-094e-4a04-806b-b4b57454d851"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("98e2c174-2f95-4b65-b6db-77ba11a18471"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b400b052-a3c6-4295-a985-18d9d499e675"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2c4cbde6-fb2c-4668-8b7d-f14779292712"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("d0d8816f-aed0-4d5b-9bfe-1edb020522f2"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("4e92c7b3-0f76-45b9-9574-174314667055"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("e75af40f-ca5f-4b51-be6c-b988f7018a9c"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("4aabae7b-41e0-49c9-a064-940384af3468"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("3695dfc6-930a-44c8-9384-8b0fe4aab4bb"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("df97d2bd-5778-4f5a-9029-f19fb0a9bc2d"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("387c0683-4c59-46ef-a0a1-864d13962bfe"));
            MalzemeSAtinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("5a5d0a0b-3c9a-4d1b-8bf8-94b2a0aec40e"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("8be7f025-2ddc-40be-a9e3-46e9e5914f3b"));
            MalzemeBilgisi_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("a18611c9-78f4-45f0-9fbc-8b78340f7348"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("fe389e73-d934-44b2-88c7-15c1de4af13d"));
            TTListBoxExternalLab = (ITTObjectListBox)AddControl(new Guid("66e354a5-9ad2-478d-bf2d-f10e1776d9fb"));
            ttbutton2 = (ITTButton)AddControl(new Guid("50875f98-8834-4798-912d-38666e979849"));
            labelDoctor = (ITTLabel)AddControl(new Guid("1c411d43-cbe3-423f-9b8e-e3c51d841f0a"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("ab2bb668-29f9-4847-a155-0c4d2c4f05ac"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f7765790-2f72-4378-9074-60454c1975a5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d29a94b9-9056-4052-bbdd-b9b42094c11d"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4e5e299f-69cc-4c09-a7b0-e5c9031c4a44"));
            base.InitializeControls();
        }

        public DentalLaboratoryForm() : base("DENTALLABORATORYPROCEDURE", "DentalLaboratoryForm")
        {
        }

        protected DentalLaboratoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}