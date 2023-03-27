
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
    /// Gebelik Takvimi Tanım Formu
    /// </summary>
    public partial class PregnancyCalendarDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.PregnancyCalendarDefinition _PregnancyCalendarDefinition
        {
            get { return (TTObjectClasses.PregnancyCalendarDefinition)_ttObject; }
        }

        protected ITTLabel labelStartDate;
        protected ITTTextBox StartDate;
        protected ITTTextBox PeriodName;
        protected ITTTextBox FinishDate;
        protected ITTLabel labelPregnancyType;
        protected ITTEnumComboBox PregnancyType;
        protected ITTLabel labelPeriodName;
        protected ITTLabel labelFinishDate;
        override protected void InitializeControls()
        {
            labelStartDate = (ITTLabel)AddControl(new Guid("206e54a9-63f1-4b78-99bd-defb7d8d903e"));
            StartDate = (ITTTextBox)AddControl(new Guid("d0a9cd4a-e7e5-4916-a058-397a9d09c0cf"));
            PeriodName = (ITTTextBox)AddControl(new Guid("0087fe05-493d-430c-8d4c-2f288646e75e"));
            FinishDate = (ITTTextBox)AddControl(new Guid("bafb3160-7b1f-4a30-beee-998344d42639"));
            labelPregnancyType = (ITTLabel)AddControl(new Guid("10cbdb90-7f53-46b0-baab-ba221ae908d0"));
            PregnancyType = (ITTEnumComboBox)AddControl(new Guid("b4516103-1e42-4206-b90b-68a012cdaba7"));
            labelPeriodName = (ITTLabel)AddControl(new Guid("c305b84d-4dee-48aa-88b1-e2bde3534e6b"));
            labelFinishDate = (ITTLabel)AddControl(new Guid("c668380b-2d61-42a7-bb4e-dfc2740e7a5b"));
            base.InitializeControls();
        }

        public PregnancyCalendarDefinitionForm() : base("PREGNANCYCALENDARDEFINITION", "PregnancyCalendarDefinitionForm")
        {
        }

        protected PregnancyCalendarDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}