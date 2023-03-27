
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
    /// Tetkik Birimi Tanımı
    /// </summary>
    public partial class DepartmentObservationUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// Tetkik Birimi
    /// </summary>
        protected TTObjectClasses.ResObservationUnit _ResObservationUnit
        {
            get { return (TTObjectClasses.ResObservationUnit)_ttObject; }
        }

        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox textContactPhone;
        protected ITTTextBox textContactAddress;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelName;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox Department;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox NotChargeHCExaminationPrice;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelQref = (ITTLabel)AddControl(new Guid("7dd20e54-8664-4611-a9f1-4ecce388cbe7"));
            Qref = (ITTTextBox)AddControl(new Guid("7ab37c44-1461-4521-ad7b-9ae739015d12"));
            Name = (ITTTextBox)AddControl(new Guid("c7b529be-c77d-48b9-88c5-66b370f5e1eb"));
            textContactPhone = (ITTTextBox)AddControl(new Guid("356491d3-5888-4ca4-8267-f1ee166ae7ff"));
            textContactAddress = (ITTTextBox)AddControl(new Guid("90ef9ab2-c05e-498d-b7a7-3de41f6f1dde"));
            Location = (ITTTextBox)AddControl(new Guid("bb42bf9a-eb9d-4ad2-ad3a-1cda35e9ae27"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("ed105c60-2059-4972-8d8f-6ad9ce959edb"));
            labelName = (ITTLabel)AddControl(new Guid("1ede055c-9094-4516-818f-ff7bf1550515"));
            labelStore = (ITTLabel)AddControl(new Guid("14fe166c-e704-48d6-a77c-d40703784598"));
            Store = (ITTObjectListBox)AddControl(new Guid("4ca86f87-8825-4236-941b-5e5f9f46eeab"));
            IsActive = (ITTCheckBox)AddControl(new Guid("84868687-4bd0-4fe1-bdef-b64e61f55c63"));
            labelDepartment = (ITTLabel)AddControl(new Guid("25d1d886-fd06-4be2-be27-ad039be134be"));
            Department = (ITTObjectListBox)AddControl(new Guid("12fb0fb7-3dbc-450f-864c-df48425979b8"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("26f37754-8858-4ff6-8b2e-5a548fef9ef6"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("862e1815-3cec-46dc-88e8-8724126d582c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("258e3247-1bde-4f84-868d-1938b6a82a40"));
            NotChargeHCExaminationPrice = (ITTCheckBox)AddControl(new Guid("7bfce4c8-7d69-4c61-bb80-7d614f26c6c4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f5b8c52e-7999-4c3d-8b30-33a7e7e0eab4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("43069c5c-b7ac-4bf1-bc52-d5d7311f2813"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("8ac16b4a-e206-4fad-af7c-c2d5cddabe71"));
            labelLocation = (ITTLabel)AddControl(new Guid("f1195e2e-2e90-4dde-bd99-00b0d2c20557"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("0033501d-5a60-4ef6-a84f-71ee16520c6a"));
            base.InitializeControls();
        }

        public DepartmentObservationUnitDefinitionForm() : base("RESOBSERVATIONUNIT", "DepartmentObservationUnitDefinitionForm")
        {
        }

        protected DepartmentObservationUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}