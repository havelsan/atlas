
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
    /// Hemodiyaliz Eğitim Formu
    /// </summary>
    public partial class HemodialysisInstructionForm : BaseMultipleDataEntryForm
    {
    /// <summary>
    /// Hemodiyaliz Eğitimleri
    /// </summary>
        protected TTObjectClasses.HemodialysisInstruction _HemodialysisInstruction
        {
            get { return (TTObjectClasses.HemodialysisInstruction)_ttObject; }
        }

        protected ITTLabel labelDuration;
        protected ITTTextBox Duration;
        protected ITTTextBox Purpose;
        protected ITTTextBox Subject;
        protected ITTLabel labelPurpose;
        protected ITTLabel labelSubject;
        protected ITTLabel labelInstructionDate;
        protected ITTDateTimePicker InstructionDate;
        override protected void InitializeControls()
        {
            labelDuration = (ITTLabel)AddControl(new Guid("c30c114b-f298-4036-a08a-8d65a50ed67b"));
            Duration = (ITTTextBox)AddControl(new Guid("182f0c38-8b1f-4b1f-ad26-4935a22126c0"));
            Purpose = (ITTTextBox)AddControl(new Guid("07dac008-ead1-4d50-a7a7-aa71d3cd6757"));
            Subject = (ITTTextBox)AddControl(new Guid("10c79a9f-1922-4e70-94b5-7a6847c912bf"));
            labelPurpose = (ITTLabel)AddControl(new Guid("447098d9-b1c9-4fce-adff-9421b0952933"));
            labelSubject = (ITTLabel)AddControl(new Guid("573b071c-eb8d-4301-88ce-e0677278d666"));
            labelInstructionDate = (ITTLabel)AddControl(new Guid("35002e4d-7851-4bf2-b7a8-978bbec8f9ea"));
            InstructionDate = (ITTDateTimePicker)AddControl(new Guid("b9dc7b38-ee5d-4561-a540-7d62fb8bcd73"));
            base.InitializeControls();
        }

        public HemodialysisInstructionForm() : base("HEMODIALYSISINSTRUCTION", "HemodialysisInstructionForm")
        {
        }

        protected HemodialysisInstructionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}