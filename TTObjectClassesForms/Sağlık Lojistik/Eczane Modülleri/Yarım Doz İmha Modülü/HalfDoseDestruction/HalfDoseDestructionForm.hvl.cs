
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
    /// Yarım Doz İmha
    /// </summary>
    public partial class HalfDoseDestructionForm : TTForm
    {
    /// <summary>
    /// Yarım Doz İmha İşlemi
    /// </summary>
        protected TTObjectClasses.HalfDoseDestruction _HalfDoseDestruction
        {
            get { return (TTObjectClasses.HalfDoseDestruction)_ttObject; }
        }

        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelProcedureByUser;
        protected ITTObjectListBox ProcedureByUser;
        protected ITTLabel labelPharmacyStoreDefinition;
        protected ITTObjectListBox PharmacyStoreDefinition;
        protected ITTGrid HalfDoseDestructionDetails;
        protected ITTTextBoxColumn DrugNameHalfDoseDestructionDetail;
        protected ITTTextBoxColumn AmountHalfDoseDestructionDetail;
        protected ITTListBoxColumn UnitDefinitionHalfDoseDestructionDetail;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelEndDate = (ITTLabel)AddControl(new Guid("7df2dae5-f726-4082-83c3-343664cb91a0"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("a51d83ac-b846-4a0e-b616-854bf1058db2"));
            labelStartDate = (ITTLabel)AddControl(new Guid("e1f6108b-f8fb-4a0a-8b05-8e8d33dc85ab"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("a7672a09-4d10-41c4-adf3-7d9a9758dc3b"));
            labelProcedureByUser = (ITTLabel)AddControl(new Guid("c991d2f4-9fca-44fc-a851-32d4922aebf3"));
            ProcedureByUser = (ITTObjectListBox)AddControl(new Guid("8cb70844-deae-465a-abb0-ccb5a6ac2b7a"));
            labelPharmacyStoreDefinition = (ITTLabel)AddControl(new Guid("4ba5d880-a7d2-47d4-b7e5-3678399ae0ae"));
            PharmacyStoreDefinition = (ITTObjectListBox)AddControl(new Guid("0638af7a-e054-4564-a09d-b75bd0588c59"));
            HalfDoseDestructionDetails = (ITTGrid)AddControl(new Guid("3e352c0c-d189-4f38-8812-06c6d6ff3867"));
            DrugNameHalfDoseDestructionDetail = (ITTTextBoxColumn)AddControl(new Guid("63d930d5-5420-4668-9c4f-6d3e805d6fe6"));
            AmountHalfDoseDestructionDetail = (ITTTextBoxColumn)AddControl(new Guid("ed800a9c-e40f-4227-b04d-9e375c4efca4"));
            UnitDefinitionHalfDoseDestructionDetail = (ITTListBoxColumn)AddControl(new Guid("8c1a48a3-aaf4-4a1e-8a05-3f3f119655bd"));
            labelID = (ITTLabel)AddControl(new Guid("a8aed235-5c35-4503-80fe-ea2a7bf8ac7a"));
            ID = (ITTTextBox)AddControl(new Guid("5553c351-1a9d-4aca-bdaf-fdb573f04b33"));
            labelActionDate = (ITTLabel)AddControl(new Guid("27007b78-2d72-4fbb-8562-b2917fdf2165"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("3c15f1b5-7c2c-4a0a-9ae5-dc6770ff852e"));
            base.InitializeControls();
        }

        public HalfDoseDestructionForm() : base("HALFDOSEDESTRUCTION", "HalfDoseDestructionForm")
        {
        }

        protected HalfDoseDestructionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}