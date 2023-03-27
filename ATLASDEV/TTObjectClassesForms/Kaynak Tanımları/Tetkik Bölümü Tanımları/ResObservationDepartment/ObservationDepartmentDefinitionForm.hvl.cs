
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
    /// Laboratuvar Tanımı
    /// </summary>
    public partial class ObservationDepartmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Tetkik Bölümü
    /// </summary>
        protected TTObjectClasses.ResObservationDepartment _ResObservationDepartment
        {
            get { return (TTObjectClasses.ResObservationDepartment)_ttObject; }
        }

        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox textContactAddress;
        protected ITTTextBox textContactPhone;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTObjectListBox Store;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelQref = (ITTLabel)AddControl(new Guid("b2171b4b-6a2b-4adc-a87f-58f77d74caf2"));
            Qref = (ITTTextBox)AddControl(new Guid("8f0cefff-a799-4926-bca7-d0ab40794526"));
            Name = (ITTTextBox)AddControl(new Guid("1bd41cc0-958d-48d2-a26a-4b4722858c09"));
            textContactAddress = (ITTTextBox)AddControl(new Guid("1985effb-fd76-40a6-b5f5-63f084b125fb"));
            textContactPhone = (ITTTextBox)AddControl(new Guid("e2aa41cb-1540-46f4-b383-9c52cc183a2c"));
            Location = (ITTTextBox)AddControl(new Guid("2ba2b091-9d2a-4dbf-b28f-8a87fecf04d5"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("56d4b8f6-d7f3-466e-ac3b-1b505b407d9f"));
            labelName = (ITTLabel)AddControl(new Guid("1a373278-0688-4000-88e1-498a5fbf1238"));
            IsActive = (ITTCheckBox)AddControl(new Guid("1e13f574-31a1-4547-ba03-bf2bc9963aea"));
            Store = (ITTObjectListBox)AddControl(new Guid("d2ac314f-c858-44b2-8287-f6bbb6ef1952"));
            labelStore = (ITTLabel)AddControl(new Guid("8ff703e3-5f9c-4908-8cde-db9a6b871b0d"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("03bbe321-d102-4df1-b201-536f0f693777"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("70968b5d-8ad9-4625-9d75-6de4c2bfac90"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("281da5e1-70e2-48e9-9d29-29d9cbc3a922"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b20625d4-7a44-4387-b524-9a235ff39c8c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("844ae037-6825-418c-a538-dd8a5e2993d7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("24951696-1e0b-48ca-b1f5-4f18e3bc4397"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("3812b742-ceec-47df-b632-f630d3bfa8fe"));
            labelLocation = (ITTLabel)AddControl(new Guid("bea51824-0965-4967-abf0-22d08173ea7f"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("4d2df25e-8666-41e6-b2fc-95c1d3fc5a40"));
            base.InitializeControls();
        }

        public ObservationDepartmentDefinitionForm() : base("RESOBSERVATIONDEPARTMENT", "ObservationDepartmentDefinitionForm")
        {
        }

        protected ObservationDepartmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}