
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
    public partial class PhysiotherapyOrderDetailCancelledForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// F.T.R. Emrinin  Uygulamasının Gerçekleştirildiği NEsnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrderDetail _PhysiotherapyOrderDetail
        {
            get { return (TTObjectClasses.PhysiotherapyOrderDetail)_ttObject; }
        }

        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox PhysiotherapyDoctor;
        protected ITTObjectListBox ProcedureObject;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelTreatmentRoom;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTDateTimePicker WorklistDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelPhysiotherapyDoctor;
        protected ITTLabel labelSDateTime;
        protected ITTObjectListBox TreatmentRoom;
        protected ITTLabel ttlabelDescription;
        protected ITTLabel labelReasonOfReject;
        override protected void InitializeControls()
        {
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("14e92daa-8e73-46c1-9527-edc1457d06cd"));
            labelProcedure = (ITTLabel)AddControl(new Guid("8a6aebed-0377-4731-9ebe-fa08ff496a27"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c151e4d7-3e3b-4dc3-a78d-fffb1b5d283e"));
            PhysiotherapyDoctor = (ITTObjectListBox)AddControl(new Guid("e156db0e-2a21-40fa-9b0e-1ab7afd064d1"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("9526bcfd-fa7d-4af2-b715-dea0bda04413"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("2cc544c1-4440-4f82-a4a5-056379026f25"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("772d8b26-c501-4401-bb85-fdf9c4c10cb5"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("cdbf7e8c-c809-480d-947d-d7cc64bfaa34"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("95ccc655-7fd9-4d5a-b913-2818891325e6"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a6a7c0c7-25cc-459c-8333-286c99c90cf7"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("1ae13db4-da76-4d25-89db-360e427549b5"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("80ab6690-456e-46ae-95d0-3a16d3bb3b09"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("12ad5fdc-d310-4871-ab22-223150aa3653"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("74d83e44-1f5a-4d7c-b0bd-52933995ad06"));
            labelTreatmentRoom = (ITTLabel)AddControl(new Guid("b1f1983f-3b9d-4476-8a81-2586f95fb40e"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("afe99c5b-7a4f-4a3d-9038-5b9d9c81538a"));
            WorklistDate = (ITTDateTimePicker)AddControl(new Guid("bdcc58f4-caea-4ed9-a963-d5b53891bb77"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("5569fef1-6359-43e2-9fdc-7605bd7632e3"));
            labelPhysiotherapyDoctor = (ITTLabel)AddControl(new Guid("3a69f74f-054a-47bf-8f4d-357a13da1887"));
            labelSDateTime = (ITTLabel)AddControl(new Guid("6e859bb5-3b47-4cad-b535-32176a1d994c"));
            TreatmentRoom = (ITTObjectListBox)AddControl(new Guid("e5071f42-a54d-4f1d-9d38-95625907fa39"));
            ttlabelDescription = (ITTLabel)AddControl(new Guid("6b0af246-1ecc-453b-bc8e-35349edd20ac"));
            labelReasonOfReject = (ITTLabel)AddControl(new Guid("668689de-d42f-4661-bc99-029af8fd4167"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderDetailCancelledForm() : base("PHYSIOTHERAPYORDERDETAIL", "PhysiotherapyOrderDetailCancelledForm")
        {
        }

        protected PhysiotherapyOrderDetailCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}