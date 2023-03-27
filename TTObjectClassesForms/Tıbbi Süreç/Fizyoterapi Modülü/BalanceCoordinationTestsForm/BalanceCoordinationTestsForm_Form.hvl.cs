
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
    public partial class BalanceCoordinationTestsForm : TTForm
    {
    /// <summary>
    /// Denge / Koordinasyon Testleri
    /// </summary>
        protected TTObjectClasses.BalanceCoordinationTestsForm _BalanceCoordinationTestsForm
        {
            get { return (TTObjectClasses.BalanceCoordinationTestsForm)_ttObject; }
        }

        protected ITTLabel labelFiveTimesSitToStandTest;
        protected ITTTextBox FiveTimesSitToStandTest;
        protected ITTTextBox FourSquareStepTest;
        protected ITTTextBox LieDownTest;
        protected ITTTextBox FallsEfficacyScale;
        protected ITTTextBox BergBalanceTest;
        protected ITTTextBox StandUpWalkTest;
        protected ITTTextBox StandingOnOneLeg;
        protected ITTTextBox Code;
        protected ITTLabel labelFourSquareStepTest;
        protected ITTLabel labelLieDownTest;
        protected ITTLabel labelFallsEfficacyScale;
        protected ITTLabel labelBergBalanceTest;
        protected ITTLabel labelStandUpWalkTest;
        protected ITTLabel labelStandingOnOneLeg;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelFiveTimesSitToStandTest = (ITTLabel)AddControl(new Guid("85c8c8df-28f9-43ee-80aa-bbc27b45df1d"));
            FiveTimesSitToStandTest = (ITTTextBox)AddControl(new Guid("ae979d30-e946-4ad9-bedd-395c05099a0a"));
            FourSquareStepTest = (ITTTextBox)AddControl(new Guid("5e0d41c2-129c-4a70-8be4-00a400aa4db6"));
            LieDownTest = (ITTTextBox)AddControl(new Guid("f4216768-9848-47de-84dc-09551c3e481b"));
            FallsEfficacyScale = (ITTTextBox)AddControl(new Guid("2a1be082-ff52-4170-aa76-1649a76a6ada"));
            BergBalanceTest = (ITTTextBox)AddControl(new Guid("68d06229-336f-454b-9c6a-fa537bd59ae3"));
            StandUpWalkTest = (ITTTextBox)AddControl(new Guid("b98c6786-22b3-49b6-8e2d-ae07a8cc63e0"));
            StandingOnOneLeg = (ITTTextBox)AddControl(new Guid("507211f4-c596-4344-b790-c7c639faa31e"));
            Code = (ITTTextBox)AddControl(new Guid("f6cb4b25-5dcd-4e37-9e7a-840f83a3b907"));
            labelFourSquareStepTest = (ITTLabel)AddControl(new Guid("0fcab0d3-034d-460c-b866-9c749fc80cce"));
            labelLieDownTest = (ITTLabel)AddControl(new Guid("f3ed5583-878f-4d65-b657-ab7f6250c48d"));
            labelFallsEfficacyScale = (ITTLabel)AddControl(new Guid("809e8742-5013-4077-b86f-53c754f2bd9d"));
            labelBergBalanceTest = (ITTLabel)AddControl(new Guid("2d5085bb-23fc-44cc-b9f5-2d7b0a9a6fab"));
            labelStandUpWalkTest = (ITTLabel)AddControl(new Guid("f44b3e02-5d1a-45b5-8f03-ff15ed4ba863"));
            labelStandingOnOneLeg = (ITTLabel)AddControl(new Guid("6099f021-ca8c-4b74-8185-b424e45bca67"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("806ce0ac-cee7-4250-a986-bc220b73a45c"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("98d621d3-d1b8-4883-b9c4-769863bbfecd"));
            labelCode = (ITTLabel)AddControl(new Guid("7e5b83ee-d4df-48db-ac7c-9bd9993e5c96"));
            base.InitializeControls();
        }

        public BalanceCoordinationTestsForm() : base("BALANCECOORDINATIONTESTSFORM", "BalanceCoordinationTestsForm")
        {
        }

        protected BalanceCoordinationTestsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}