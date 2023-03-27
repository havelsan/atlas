
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
    public partial class DialysisOrderDetailCancelledForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
        protected TTObjectClasses.DialysisOrderDetail _DialysisOrderDetail
        {
            get { return (TTObjectClasses.DialysisOrderDetail)_ttObject; }
        }

        protected ITTLabel labelReasonOfReject;
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
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox ReasonOfCancel;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelProcedure;
        protected ITTObjectListBox Nurse;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabelDescription;
        override protected void InitializeControls()
        {
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("4cef2b4d-ba2b-4843-a453-5c57f151e118"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("890c19aa-7158-43d8-b9b6-62b5b6eda949"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("34523849-6fbf-4804-8c50-d7978de24f2e"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5a167d44-4827-4543-b583-f455f241bbbe"));
            labelDialysisNurse = (ITTLabel)AddControl(new Guid("d8f99a90-491d-40dc-a3fd-448b0e8b6ba0"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("45da4b62-61ef-4bdf-a49f-76434a76c04a"));
            Note = (ITTTextBox)AddControl(new Guid("49b97a8a-73a9-42f1-a1af-b7f9cdeebbd7"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("40be81fc-1a2d-4f3f-aeba-6f44eb224132"));
            labelNote = (ITTLabel)AddControl(new Guid("816b3998-cb69-44d3-b9e4-e9b324efb16e"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("89082f02-2bcf-4792-ac2a-583e79cb9b6b"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("3c71e86b-b8a1-43c2-ad52-4b5ce83d987d"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("df9f952d-d1d2-4738-80fe-0c66aabcdd25"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("86c67e87-203b-45fc-8ddd-4e733f6c3b1d"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("afe6e6ed-7b53-41a9-aaf8-1d5b3cffca26"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("4d2821cb-5765-4f66-b806-bedddb715528"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f150373a-9344-44f0-b60e-5859fcc94011"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("cf078296-0bb9-4c05-9171-21bad489696d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3e358aff-191e-42ac-8701-8977bc0d64fd"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("f8a0c649-237e-467a-b330-88d406475b2e"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("f1c11753-4533-45bf-abf9-718b0cc69e5a"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("c7343d69-ad0c-4344-ba6b-9ccd489f274f"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("aca89130-198f-4871-9d24-f030549a4351"));
            labelProcedure = (ITTLabel)AddControl(new Guid("79211070-3f7e-4ca1-aced-727119e6fa82"));
            Nurse = (ITTObjectListBox)AddControl(new Guid("01f6ddc8-b979-48e3-ae03-a0fafc0cf955"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("3a721e24-56ca-452a-b32e-3fb28711815b"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("3ffcd7c1-004a-4326-9909-1d5266b7b6db"));
            base.InitializeControls();
        }

        public DialysisOrderDetailCancelledForm() : base("DIALYSISORDERDETAIL", "DialysisOrderDetailCancelledForm")
        {
        }

        protected DialysisOrderDetailCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}