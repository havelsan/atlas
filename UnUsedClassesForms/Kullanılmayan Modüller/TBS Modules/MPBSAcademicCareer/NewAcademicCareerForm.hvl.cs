
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
    /// Akademik Kariyer
    /// </summary>
    public partial class NewAcademicCareerForm : TTForm
    {
    /// <summary>
    /// Akademik Kariyer
    /// </summary>
        protected TTObjectClasses.MPBSAcademicCareer _MPBSAcademicCareer
        {
            get { return (TTObjectClasses.MPBSAcademicCareer)_ttObject; }
        }

        protected ITTLabel labelInternship;
        protected ITTObjectListBox PermanentTurkishPersonnel;
        protected ITTDateTimePicker StartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelPromotionDate;
        protected ITTLabel labelEndDate;
        protected ITTLabel labelScienceBranch;
        protected ITTTextBox ScienceBranch;
        protected ITTTextBox Internship;
        protected ITTTextBox Duration;
        protected ITTLabel labelPermanentTurkishPersonnel;
        protected ITTDateTimePicker PromotionDate;
        protected ITTLabel labelDuration;
        protected ITTLabel labelStartDate;
        override protected void InitializeControls()
        {
            labelInternship = (ITTLabel)AddControl(new Guid("d39f3dad-0cb6-4e11-a690-156b10440c8e"));
            PermanentTurkishPersonnel = (ITTObjectListBox)AddControl(new Guid("a4eb87e9-118b-4fd6-a8e2-3b6e98de667c"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("46a46a51-722c-487f-8288-286d311c018f"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("12c020ab-c376-4008-afbf-95911dcda3bb"));
            labelPromotionDate = (ITTLabel)AddControl(new Guid("6c5b0117-8603-4585-a31e-7a4080c7dae8"));
            labelEndDate = (ITTLabel)AddControl(new Guid("37aa455c-d4be-45fb-8901-b303bd60c10c"));
            labelScienceBranch = (ITTLabel)AddControl(new Guid("8c5d7f48-337b-4ab5-a2c8-b26b6fb6812d"));
            ScienceBranch = (ITTTextBox)AddControl(new Guid("fd37a343-ac83-45c8-8d05-8cc2ccd0d3e4"));
            Internship = (ITTTextBox)AddControl(new Guid("fbfc83a2-34c2-4a4a-a20c-9ee859ebe925"));
            Duration = (ITTTextBox)AddControl(new Guid("1852da03-c2c7-42c3-a2d5-ae05229ad4a5"));
            labelPermanentTurkishPersonnel = (ITTLabel)AddControl(new Guid("42f5e17b-17e8-4fe7-8cfc-e768143b3aab"));
            PromotionDate = (ITTDateTimePicker)AddControl(new Guid("dd55044a-8b6e-47c7-afdb-e860541873e8"));
            labelDuration = (ITTLabel)AddControl(new Guid("29d9a3cc-cd88-428c-b1cc-ffca1b9c9f8a"));
            labelStartDate = (ITTLabel)AddControl(new Guid("b888fb12-04e8-4b5e-87bb-d3fdd27438a4"));
            base.InitializeControls();
        }

        public NewAcademicCareerForm() : base("MPBSACADEMICCAREER", "NewAcademicCareerForm")
        {
        }

        protected NewAcademicCareerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}