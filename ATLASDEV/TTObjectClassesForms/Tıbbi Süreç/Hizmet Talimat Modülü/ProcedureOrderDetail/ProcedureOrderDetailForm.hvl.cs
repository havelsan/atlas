
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
    /// Hizmet Talimat Detayı
    /// </summary>
    public partial class ProcedureOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Hizmet Talimat/İstek Detayı
    /// </summary>
        protected TTObjectClasses.ProcedureOrderDetail _ProcedureOrderDetail
        {
            get { return (TTObjectClasses.ProcedureOrderDetail)_ttObject; }
        }

        protected ITTTabControl TabSubaction;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid UsedMaterial;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn MNotes;
        protected ITTTextBox Result;
        protected ITTTextBox Note;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelExacutionDate;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker ExecutionDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelResult;
        protected ITTObjectListBox ProcedureObject;
        override protected void InitializeControls()
        {
            TabSubaction = (ITTTabControl)AddControl(new Guid("0207f924-0d8f-4bbb-b5eb-6e88c48e4727"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("b1928802-e252-4dac-a924-60403100358e"));
            UsedMaterial = (ITTGrid)AddControl(new Guid("554d69da-81d3-454d-bcd6-8dc7c8376b1c"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("812bdedf-7203-4652-9aab-2d39eb71e7b7"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("d8117d75-4f6e-4f84-a00a-1adbf533f0a6"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("dcd532f5-793b-40e9-b165-c482d29b79d6"));
            MNotes = (ITTTextBoxColumn)AddControl(new Guid("162011d3-6b46-407f-bb53-9dcaa32f468a"));
            Result = (ITTTextBox)AddControl(new Guid("f31b06af-d5ec-4a82-94ba-d7dc481ba7e6"));
            Note = (ITTTextBox)AddControl(new Guid("664d5c09-9afe-4cbd-a391-9d7ebbaccce1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d94895f6-2fe1-4f90-8885-cb6251249fc1"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("9ed6972e-2f11-4d13-9a35-449ad42e2635"));
            labelExacutionDate = (ITTLabel)AddControl(new Guid("7dd1c0ff-6d39-4ca1-b3e7-e06a8265be9c"));
            labelNote = (ITTLabel)AddControl(new Guid("eed0ce90-1cf6-4296-b5e8-5673209d83be"));
            ExecutionDate = (ITTDateTimePicker)AddControl(new Guid("b295a835-2eb5-4385-bf5a-2b159d9c3332"));
            labelProcedure = (ITTLabel)AddControl(new Guid("d974d2d4-beeb-4833-8ef3-e3d266f3a32c"));
            labelResult = (ITTLabel)AddControl(new Guid("fca7f702-96d3-4fbf-a11d-0a6fc65f2ef2"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("8fe1fe01-a23b-432e-8c98-736af42b04a7"));
            base.InitializeControls();
        }

        public ProcedureOrderDetailForm() : base("PROCEDUREORDERDETAIL", "ProcedureOrderDetailForm")
        {
        }

        protected ProcedureOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}