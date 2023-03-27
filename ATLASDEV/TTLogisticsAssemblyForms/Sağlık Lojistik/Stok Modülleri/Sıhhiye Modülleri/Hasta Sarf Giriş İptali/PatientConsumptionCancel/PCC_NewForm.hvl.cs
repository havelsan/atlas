
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
    public partial class PCC_NewForm : TTForm
    {
    /// <summary>
    /// Hasta Sarf Giriş İptali
    /// </summary>
        protected TTObjectClasses.PatientConsumptionCancel _PatientConsumptionCancel
        {
            get { return (TTObjectClasses.PatientConsumptionCancel)_ttObject; }
        }

        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTButton cmdFindPatients;
        protected ITTGrid grdPatients;
        protected ITTTextBoxColumn UniqueRefNo;
        protected ITTTextBoxColumn ForeignUniqueRefNo;
        protected ITTButtonColumn Choose;
        protected ITTTextBoxColumn Id;
        protected ITTLabel lblMaterial_NSN;
        protected ITTObjectListBox txtMaterial;
        protected ITTGrid grdConsumptions;
        protected ITTTextBoxColumn EpisodeProtocolNo_Desc;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn CancelPC;
        protected ITTButton cmdSearchPatient;
        protected ITTButton cmdSearchSubactionMaterials;
        protected ITTObjectListBox txtStore;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelEndDate = (ITTLabel)AddControl(new Guid("713e4728-130e-4073-ad38-496676af17fd"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("637709a8-2193-48f1-a40b-ae342fd71523"));
            labelStartDate = (ITTLabel)AddControl(new Guid("d7890267-be78-4ffe-9010-39c1035616f8"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("4804f3bb-4057-4f7c-8360-6d6bb9410327"));
            cmdFindPatients = (ITTButton)AddControl(new Guid("198d0ee8-9588-43c3-859b-a3a9044b719b"));
            grdPatients = (ITTGrid)AddControl(new Guid("4cae0262-f8ae-422e-a4aa-18be2cd4cad5"));
            UniqueRefNo = (ITTTextBoxColumn)AddControl(new Guid("b601dd01-0b5e-4b3d-be17-45139a96e55f"));
            ForeignUniqueRefNo = (ITTTextBoxColumn)AddControl(new Guid("bd8572f9-be5c-4b4e-b1c2-582644d22fd0"));
            Choose = (ITTButtonColumn)AddControl(new Guid("ff46f041-0f89-47d7-ae8d-a0ffc9a2602c"));
            Id = (ITTTextBoxColumn)AddControl(new Guid("93f13a40-ca29-4576-a490-5704ad6b928d"));
            lblMaterial_NSN = (ITTLabel)AddControl(new Guid("6f949164-8594-41ee-a6a1-3b2bc1864c21"));
            txtMaterial = (ITTObjectListBox)AddControl(new Guid("58558c59-80b8-44b8-8840-376997213b1f"));
            grdConsumptions = (ITTGrid)AddControl(new Guid("978baf03-a1ce-4d08-8da0-50d84eef0473"));
            EpisodeProtocolNo_Desc = (ITTTextBoxColumn)AddControl(new Guid("4ead5763-797f-40c8-a97b-a95e06d309a7"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a459e471-821d-4c9d-90d0-817789f6abff"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("22d4e203-81bf-448c-90ed-0001477cb212"));
            CancelPC = (ITTCheckBoxColumn)AddControl(new Guid("d4859788-19f7-4272-919f-a2f295dbe0a1"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("10457891-6405-41b6-a5d4-dd6e1d0d5b0d"));
            cmdSearchSubactionMaterials = (ITTButton)AddControl(new Guid("f3fcd59c-f095-44cb-a80a-5d9ce4edd263"));
            txtStore = (ITTObjectListBox)AddControl(new Guid("41d2ee45-fc7f-4960-9fb0-c53dcc823d3c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5073d7ec-20d6-49b4-b6a3-3a73fb1cf8d5"));
            base.InitializeControls();
        }

        public PCC_NewForm() : base("PATIENTCONSUMPTIONCANCEL", "PCC_NewForm")
        {
        }

        protected PCC_NewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}