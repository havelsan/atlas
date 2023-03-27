
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
    /// Tanı Tedavi Ünitesi Tanımı
    /// </summary>
    public partial class DepartmentTreatmentDiagnosisUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// Tanı Tedavi Birimi
    /// </summary>
        protected TTObjectClasses.ResTreatmentDiagnosisUnit _ResTreatmentDiagnosisUnit
        {
            get { return (TTObjectClasses.ResTreatmentDiagnosisUnit)_ttObject; }
        }

        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
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
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTEnumComboBox ResSectionTypeResSection;
        protected ITTLabel labelResSectionTypeResSection;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelQref = (ITTLabel)AddControl(new Guid("680aec57-a2ec-442d-a8e4-970f1431a072"));
            Qref = (ITTTextBox)AddControl(new Guid("2786cfde-37e7-42e6-9b1e-6f65136552cf"));
            Name = (ITTTextBox)AddControl(new Guid("6f73d542-f206-40e9-b7ac-b4ea3dc5312d"));
            Location = (ITTTextBox)AddControl(new Guid("ca197b3f-0c1e-47ab-b3fb-a71afa563f57"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("22e9e8f5-7d8b-4fef-83fc-e54d974cf93c"));
            labelName = (ITTLabel)AddControl(new Guid("8783895b-5e04-4837-8e46-bfa925dde1e2"));
            labelStore = (ITTLabel)AddControl(new Guid("2391b39a-3b14-44b2-a9ad-e86b64c815d1"));
            Store = (ITTObjectListBox)AddControl(new Guid("902c2c4f-c7e7-429f-a5f5-33f1aa91a75d"));
            IsActive = (ITTCheckBox)AddControl(new Guid("29052c34-3111-4744-afea-7f93b64b15f4"));
            labelDepartment = (ITTLabel)AddControl(new Guid("5eb5001f-3c5e-4895-8d1e-f056cd284f2d"));
            Department = (ITTObjectListBox)AddControl(new Guid("c0fbaa6d-39f7-41d6-acbf-e5121637f3ea"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("93dbe196-739d-4c82-8f4b-d2d69ac48377"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("7f79bd50-1341-49fe-a3d9-17dcd6112990"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e116c208-4df6-4fff-94c0-30fb9d1ccd03"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("0369233f-cdf8-4361-bab6-fea574904226"));
            ResSectionTypeResSection = (ITTEnumComboBox)AddControl(new Guid("289ccc2b-e89f-4902-9012-464d7f9c3c6c"));
            labelResSectionTypeResSection = (ITTLabel)AddControl(new Guid("cb9b040c-d5f2-4db7-bef5-153908f6ca50"));
            labelLocation = (ITTLabel)AddControl(new Guid("edfb38f6-23da-40e5-886f-75ad5bc2b606"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("81405c18-26e6-456f-9a7f-9a6ca14d499e"));
            base.InitializeControls();
        }

        public DepartmentTreatmentDiagnosisUnitDefinitionForm() : base("RESTREATMENTDIAGNOSISUNIT", "DepartmentTreatmentDiagnosisUnitDefinitionForm")
        {
        }

        protected DepartmentTreatmentDiagnosisUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}