
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
    public partial class HyperbarikOxygenTreatmentOrderDetailCancelledForm : SubactionProcedureFlowableForm
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
        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox TreatmentDepth;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel ttlabelDescription;
        protected ITTLabel labelReasonOfReject;
        protected ITTLabel labelTreatmentDepth;
        override protected void InitializeControls()
        {
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("85afdc10-445e-4671-83f6-6d5ad2332886"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("c59c9c4a-ee06-4c14-8681-b7f1632ac0a9"));
            Note = (ITTTextBox)AddControl(new Guid("180cd160-0f6d-4d5b-bd2e-bf3d668e651d"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("9ba9b353-2582-41f7-b4bb-8681dc1d0006"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("6e5f6a1c-5097-47f2-86a7-8ed33d9921bc"));
            labelNote = (ITTLabel)AddControl(new Guid("8780cc68-83bf-42cd-bbeb-6184f7eb9329"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("4f432aa2-033b-4a2a-87be-09f53391d0fd"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("b6aff7c9-cd6f-46d8-aabc-b098fa204484"));
            labelProcedure = (ITTLabel)AddControl(new Guid("1c5236de-9e91-4f92-acb7-6c2ec627bc24"));
            labelActionDate = (ITTLabel)AddControl(new Guid("bc78c697-62fb-4155-a48c-26a5a1884588"));
            Emergency = (ITTCheckBox)AddControl(new Guid("7ddf10dd-520f-4d7c-8e38-9773e96696c0"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("9b18a80c-8e93-4d89-88c5-d2cf99315851"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("a6da43ed-1900-4f9e-b842-89875c2240a1"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("2720312f-f018-4fd8-b44d-bb9291e01d86"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("f1cdc566-0ae5-478b-ae59-0fc32dd56e01"));
            TreatmentMaterialTab = (ITTTabControl)AddControl(new Guid("3570fa71-944c-4747-a9ea-cfe8ef6e7bab"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("c0e54524-8d20-4f02-ae1a-3006a80b22c6"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("49c5c46e-73d5-4dae-a953-85bf09b89be9"));
            MactionDate = (ITTDateTimePickerColumn)AddControl(new Guid("364a0d0c-6731-48d8-b69f-b86ed47b2eff"));
            Material = (ITTListBoxColumn)AddControl(new Guid("1ad83389-2d32-49e9-bc45-9d5064687ef8"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("dfc9ce4c-64ad-4ecf-8ef7-8f74f3ca4bd4"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b3078c49-955c-4132-83ff-af227cbdc13b"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("f2cd009a-eee0-4b1c-9784-69a37946060e"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("0a444cb9-1246-427d-bc14-171805202701"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("42f9c15f-8654-4103-8b75-272984bc73f3"));
            TreatmentDepth = (ITTTextBox)AddControl(new Guid("7aa2ec50-d3ca-4e5e-8ff0-300dcc80917e"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("508e411f-3551-4ff9-87c4-3d069be1361a"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f99213b9-d749-48cd-9b9c-f97ef44b84fe"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("daa23009-87b4-41da-a6a0-a5c15aecf54f"));
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("aa9e0796-5a01-4d22-b543-2d10c1c3681d"));
            labelTreatmentDepth = (ITTLabel)AddControl(new Guid("ed6604aa-63f3-45e9-9591-f3a41d58348a"));
            base.InitializeControls();
        }

        public HyperbarikOxygenTreatmentOrderDetailCancelledForm() : base("HYPERBARIKOXYGENTREATMENTORDERDETAIL", "HyperbarikOxygenTreatmentOrderDetailCancelledForm")
        {
        }

        protected HyperbarikOxygenTreatmentOrderDetailCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}