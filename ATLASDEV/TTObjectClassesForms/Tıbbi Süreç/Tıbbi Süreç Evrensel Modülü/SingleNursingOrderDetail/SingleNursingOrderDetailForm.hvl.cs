
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
    public partial class SingleNursingOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Hemşire Takip Gözlem Uygulaması (Ayaktan Hasta)
    /// </summary>
        protected TTObjectClasses.SingleNursingOrderDetail _SingleNursingOrderDetail
        {
            get { return (TTObjectClasses.SingleNursingOrderDetail)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker WorkListDate;
        protected ITTTextBox Result;
        protected ITTTextBox Note;
        protected ITTLabel labelExacutionDate;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker ExecutionDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelResult;
        protected ITTObjectListBox ProcedureObject;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid UsedMaterial;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn MNotes;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("14a69785-1c45-444a-9fb2-abc1e73ca008"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("65f36199-eb4c-4b67-b215-1d7e82ed9596"));
            Result = (ITTTextBox)AddControl(new Guid("c9dec5e6-ed7c-4cb8-b482-dfa07e624c80"));
            Note = (ITTTextBox)AddControl(new Guid("b1015aed-0e72-4ea7-817e-75cabf49dd53"));
            labelExacutionDate = (ITTLabel)AddControl(new Guid("34c484c9-4f06-41f1-88e3-0d927c8b758e"));
            labelNote = (ITTLabel)AddControl(new Guid("201739aa-c926-4a35-8894-19875c8240b0"));
            ExecutionDate = (ITTDateTimePicker)AddControl(new Guid("2bf192f5-af7b-4e83-bb68-89aa5f2a2434"));
            labelProcedure = (ITTLabel)AddControl(new Guid("23fe913a-274a-4141-a623-50f9b3ebe3f7"));
            labelResult = (ITTLabel)AddControl(new Guid("49474a50-f21a-4f7f-a6ba-0125bafee26e"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("be4af487-d0db-4296-bded-b5ffde2aa00f"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("f86170c7-b3eb-4c4a-b133-a3f48aabd6db"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("db554a53-46b9-4ebb-9aad-5ad25c77dc05"));
            UsedMaterial = (ITTGrid)AddControl(new Guid("a84ae16e-f356-4131-a6d0-3ec38abe606d"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("95004fb0-6325-4f69-90e5-9d08b28bb5ae"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("ed111bca-2cc6-419a-ae39-13e514dfba21"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("5f8616fd-0261-48d2-979d-4a094236d90e"));
            MNotes = (ITTTextBoxColumn)AddControl(new Guid("5cc72a2a-7915-4967-825e-c473b5797a22"));
            base.InitializeControls();
        }

        public SingleNursingOrderDetailForm() : base("SINGLENURSINGORDERDETAIL", "SingleNursingOrderDetailForm")
        {
        }

        protected SingleNursingOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}