
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
    /// Hiperbarik Oksijen Tedavi Uygulamaları
    /// </summary>
    public partial class HyperbarikOxygenTreatmentOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavisi Emrinin  Uygulamasının Gerçekleştirildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.HyperbarikOxygenTreatmentOrderDetail _HyperbarikOxygenTreatmentOrderDetail
        {
            get { return (TTObjectClasses.HyperbarikOxygenTreatmentOrderDetail)_ttObject; }
        }

        protected ITTLabel labelTreatmentProperties;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox Note;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox TreatmentEquipment;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelSDateTime;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelActionDate;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelTreatmentEquipment;
        protected ITTObjectListBox ProcedureObject;
        protected ITTDateTimePicker WorkListDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTTabControl TreatmentMaterialTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MactionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox TreatmentDepth;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel ttlabelDescription;
        protected ITTLabel labelTreatmentDepth;
        override protected void InitializeControls()
        {
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("5fa600e1-c091-4b59-98d0-04ac4f9cf36d"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("3c45fe22-5431-4034-a1e9-9c380a3195b2"));
            Note = (ITTTextBox)AddControl(new Guid("30a77fa1-3abd-4a1e-ab05-42859809d0a3"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("ed9f4a7a-7cba-497b-8363-0654c06500df"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("81088ff5-405d-42c1-b1a5-1196820293b8"));
            labelNote = (ITTLabel)AddControl(new Guid("5f46bdd5-345b-4631-8891-2312e806a575"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("f403c474-f88d-46e2-a1d6-29a471086142"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("1faa0d3e-aa99-4747-bbc1-3a2c4ddb6c30"));
            labelProcedure = (ITTLabel)AddControl(new Guid("99c8f031-a3d5-4191-94ff-45b78b27d8e1"));
            labelActionDate = (ITTLabel)AddControl(new Guid("bdd7b7c1-69e6-433d-8512-670bee6b6f9d"));
            Emergency = (ITTCheckBox)AddControl(new Guid("d07fce3b-2419-485d-8405-7c322af13f5e"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("9e44d302-87a2-431a-beac-96d53f6fa6b3"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("35bdddb1-6c32-4fb8-935b-bd7b812bef11"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("aedd9ba9-0075-4103-86d1-c9fbe985c8ae"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("162354d4-73b5-46aa-9ee0-e4d6bfe5cc46"));
            TreatmentMaterialTab = (ITTTabControl)AddControl(new Guid("e15ae930-78bf-4dfc-bb3f-e90af904bd06"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("635ddf6d-7302-47a5-b190-424fe401c15c"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("51a6e67c-a221-49b4-9bbe-9531c0c39480"));
            MactionDate = (ITTDateTimePickerColumn)AddControl(new Guid("03026fe4-d196-4f19-b2ec-229b36e86776"));
            Material = (ITTListBoxColumn)AddControl(new Guid("73fc5879-374e-4db7-aa59-d2428784c28b"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("a33454e8-cc6c-421b-91a0-22bae6fdf21d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d8be5350-6ecd-41af-8c4b-4cbef5a783f6"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("adf49aca-7964-44a6-a0a9-2ef033b85a14"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("5206ca1e-ff1a-474e-bd78-36c51371d180"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("25f16cd0-f6b2-4fc9-b056-6fe0b1cc89d2"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("e3c4c3da-002d-4998-b760-1da1f1bc158d"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("6e90fdb1-5e8b-4fa1-9677-e405845f5716"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("c0473409-1f32-4b3b-867b-96b897e371ee"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("72acfdca-e7bd-4fa9-91e6-37f2479e758d"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("a74ee87c-46ed-4cd7-83e3-80406fced41b"));
            TreatmentDepth = (ITTTextBox)AddControl(new Guid("bf1439ea-1fa5-4a96-90ab-d3a9c9744673"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("a6194684-8040-42c7-aaef-fc6014ab3af9"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("dd6e43e7-5a39-4527-bfac-fdb73b45296d"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("33c9c7db-fa07-4445-8d72-93e38efae506"));
            labelTreatmentDepth = (ITTLabel)AddControl(new Guid("9e0b67a4-a887-443f-b5ec-b37799294765"));
            base.InitializeControls();
        }

        public HyperbarikOxygenTreatmentOrderDetailForm() : base("HYPERBARIKOXYGENTREATMENTORDERDETAIL", "HyperbarikOxygenTreatmentOrderDetailForm")
        {
        }

        protected HyperbarikOxygenTreatmentOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}