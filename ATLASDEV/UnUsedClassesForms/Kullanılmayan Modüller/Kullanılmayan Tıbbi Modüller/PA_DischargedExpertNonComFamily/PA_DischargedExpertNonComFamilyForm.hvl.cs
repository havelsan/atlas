
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
    /// Ayrılmış Uzman Erbaş Ailesi Kabulü
    /// </summary>
    public partial class PA_DischargedExpertNonComFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Ayrılmış Uzman Erbaş Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_DischargedExpertNonComFamily _PA_DischargedExpertNonComFamily
        {
            get { return (TTObjectClasses.PA_DischargedExpertNonComFamily)_ttObject; }
        }

        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        protected ITTGroupBox Family;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTTextBox EmploymentRecordID;
        protected ITTObjectListBox ttobjectlistboxForcesCommand;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelRank;
        protected ITTObjectListBox MilitaryClass;
        protected ITTTextBox HOFHealtSlipNumber;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel ttlabel9;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelRetirementFundID;
        override protected void InitializeControls()
        {
            Relationship = (ITTObjectListBox)AddControl(new Guid("54ac325e-09cb-4a64-bc86-0cd5107b527d"));
            labelRelationship = (ITTLabel)AddControl(new Guid("0db31f5e-7cd6-494e-ad05-38b335a3d2b9"));
            Family = (ITTGroupBox)AddControl(new Guid("fbc02f4b-1fd3-4d90-9363-a3902a94de26"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("dffec7a2-12c5-4468-b708-d8185985fa15"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("40229d9c-66d4-42a1-b50e-2f5417819b2c"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("efdb3111-8eb9-4f5b-84af-8df6f2853b64"));
            ttobjectlistboxForcesCommand = (ITTObjectListBox)AddControl(new Guid("329c37bc-a30b-4ff8-8c61-d9b886d53ced"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("f0b61b47-1044-4c00-81f9-034e2b9bf186"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1dfe73a2-7764-44d9-8ccb-0bad9405c2c6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("38ad7fa7-ae6f-4a28-af8d-22bf7d4bf9ff"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("35c73bb9-8eb3-4016-b516-146e5610454f"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("c00330c3-7b7c-4ac9-8d1e-3be5dff4b53b"));
            labelRank = (ITTLabel)AddControl(new Guid("a4351d2f-3d99-4726-8d9f-c7eb8c560628"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("628fd13c-1fbf-4142-a3d3-b877d17f76eb"));
            HOFHealtSlipNumber = (ITTTextBox)AddControl(new Guid("96d51cf1-3511-4cca-b75d-09fe05c311f3"));
            Rank = (ITTObjectListBox)AddControl(new Guid("a3e97e37-51b9-410f-ad05-980ece493f1e"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("e7811f76-8bf2-4aba-814a-76a317e1b921"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("e239008c-89e1-4718-a3ec-3f05d4bbf61d"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("2d674c6d-44b3-4ce3-a6cb-d3e111d9233b"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("433ad36f-34bd-4ce5-b373-896835129bfa"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("44df048b-01b6-4429-a140-b11ff563054d"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("7081dfc5-35b2-4663-86ed-fa67e6f03dd5"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("5ff624c1-21e5-4c9f-8269-c93ef110afd1"));
            base.InitializeControls();
        }

        public PA_DischargedExpertNonComFamilyForm() : base("PA_DISCHARGEDEXPERTNONCOMFAMILY", "PA_DischargedExpertNonComFamilyForm")
        {
        }

        protected PA_DischargedExpertNonComFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}