
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
    public partial class AmputeeAssessmentForm : TTForm
    {
    /// <summary>
    /// Ampute değerlendirmesi
    /// </summary>
        protected TTObjectClasses.AmputeeAssessmentForm _AmputeeAssessmentForm
        {
            get { return (TTObjectClasses.AmputeeAssessmentForm)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTLabel labelMGFCScale;
        protected ITTTextBox MGFCScale;
        protected ITTTextBox GroningenScale;
        protected ITTTextBox TheSicknessImpactProfile;
        protected ITTTextBox ProstheticIpperExtremityIndex;
        protected ITTTextBox TrinityExperienceScale;
        protected ITTLabel labelGroningenScale;
        protected ITTLabel labelTheSicknessImpactProfile;
        protected ITTLabel labelProstheticIpperExtremityIndex;
        protected ITTLabel labelTrinityExperienceScale;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("0ebde425-402e-4e09-b396-a509e1f9038f"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("bc73123c-f8ce-4623-81db-b99dbe2ce6dc"));
            labelCode = (ITTLabel)AddControl(new Guid("4ab40fd3-c202-40a7-baaf-42e74c354f75"));
            Code = (ITTTextBox)AddControl(new Guid("7010db12-f760-463b-b771-22c8327aba61"));
            labelMGFCScale = (ITTLabel)AddControl(new Guid("ed0738ac-4cab-4445-b00b-aaa1a109f065"));
            MGFCScale = (ITTTextBox)AddControl(new Guid("004ee64c-a6cb-44b6-9d20-262db2502c81"));
            GroningenScale = (ITTTextBox)AddControl(new Guid("7ca47498-6c5e-46b5-8312-a42f6fbdb384"));
            TheSicknessImpactProfile = (ITTTextBox)AddControl(new Guid("e8034799-9147-471a-b89f-edbc236d40da"));
            ProstheticIpperExtremityIndex = (ITTTextBox)AddControl(new Guid("c74dc9dd-d4ba-4537-b533-55c183bb28ee"));
            TrinityExperienceScale = (ITTTextBox)AddControl(new Guid("b4847eff-bfc9-410f-ab2e-0119e0284dae"));
            labelGroningenScale = (ITTLabel)AddControl(new Guid("858a3acf-81e4-4031-a508-42852c35d807"));
            labelTheSicknessImpactProfile = (ITTLabel)AddControl(new Guid("8beb42ea-f5d4-4075-b589-580eaaf44f14"));
            labelProstheticIpperExtremityIndex = (ITTLabel)AddControl(new Guid("b31cc7eb-fdfd-4672-be2d-4926dc8d0781"));
            labelTrinityExperienceScale = (ITTLabel)AddControl(new Guid("cc8235f1-db08-495a-8bf1-7f4e051eea84"));
            base.InitializeControls();
        }

        public AmputeeAssessmentForm() : base("AMPUTEEASSESSMENTFORM", "AmputeeAssessmentForm")
        {
        }

        protected AmputeeAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}