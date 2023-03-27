
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
    /// Astsubay Ailesi Kabulü
    /// </summary>
    public partial class NoncommissionedOfficerFamily : PatientAdmissionForm
    {
    /// <summary>
    /// Astsubay Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_NoncommissionedOfficerFamily _PA_NoncommissionedOfficerFamily
        {
            get { return (TTObjectClasses.PA_NoncommissionedOfficerFamily)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelDocumentNumber;
        protected ITTGroupBox FamilyInfo;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ForcesCommand;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel133;
        protected ITTLabel ttlabel833;
        protected ITTLabel labelRank;
        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox Rank;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel labelRetirementFundID;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7d09c914-223b-4698-a403-697bd50e748b"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("ae102e44-0c4c-4ef2-a648-dc31a79c670c"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("1f148ce0-b88b-4e0f-bb6e-021c1009b724"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("77fdf41d-aa02-4d06-bc8c-db76ec504786"));
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("ce5bb3f4-ed56-4df0-8a1c-fa785660c889"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("dc4bc741-e9e2-46a4-8d89-64e18cf500ea"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("7be0e0ae-2cbf-473e-b0d7-785c47a4e02b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("252aad5f-6759-4f4e-a301-6ea98121d963"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("44bd650d-fee6-4d6a-a3df-2ecfd0cc5e62"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("eb381cd9-b34e-4b01-bd67-a8c8cd5718f3"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("5032a619-a1f1-453f-a14f-09f39b8640a9"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("0c5f29b1-e142-42fe-bba0-d1cf0ac037fa"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("cce15baf-e452-4481-a630-fc8281cdb134"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("a181a2a2-5ff1-4b88-98db-c9709c8c76a8"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("ae6f64e1-bd96-4bda-87f4-c94404ee8574"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f3618680-c807-4c7f-8fc7-2af9baed83f2"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("822bc78d-1f16-47d6-b855-08573ab5c83e"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("7debd2c0-22c5-49f3-97c7-91c2ce5a21bd"));
            labelRank = (ITTLabel)AddControl(new Guid("6e7481b9-50ef-420f-8804-9a7bd37b32a5"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("f3f352df-a4a4-4314-969a-6bbcd02230a9"));
            Rank = (ITTObjectListBox)AddControl(new Guid("2a52ee7e-9fa8-4c3e-b18e-feca5a3f70ce"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("bf428335-6712-4446-8767-c0c1373a825a"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("844ee3cb-279b-468d-a959-240e875be7ab"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("05c1b3ac-6f3f-40cf-9ca0-a8d1dbc01112"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("a9ccc20e-5f12-42dd-bfc9-c96587c858cd"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("e5d5c548-ec94-423d-b300-45fe4e9f9d26"));
            labelRelationship = (ITTLabel)AddControl(new Guid("2a37e660-0712-4ad8-9751-d75e7110e26f"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("5f4c7caa-1810-4788-839c-c1f60d62ef67"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("c53eadcf-7874-4cd0-b34d-ffefee437511"));
            base.InitializeControls();
        }

        public NoncommissionedOfficerFamily() : base("PA_NONCOMMISSIONEDOFFICERFAMILY", "NoncommissionedOfficerFamily")
        {
        }

        protected NoncommissionedOfficerFamily(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}