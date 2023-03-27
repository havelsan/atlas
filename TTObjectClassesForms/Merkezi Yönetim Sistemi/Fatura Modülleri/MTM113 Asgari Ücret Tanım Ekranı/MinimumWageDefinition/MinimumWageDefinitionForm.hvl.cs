
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
    /// Asgari Ücret Tanım Ekranı
    /// </summary>
    public partial class MinimumWageDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Asgari Ücret Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.MinimumWageDefinition _MinimumWageDefinition
        {
            get { return (TTObjectClasses.MinimumWageDefinition)_ttObject; }
        }

        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelGrossWage;
        protected ITTTextBox GrossWage;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        override protected void InitializeControls()
        {
            labelStartDate = (ITTLabel)AddControl(new Guid("075368f7-be83-4171-97a4-a1f00cc5eaf3"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("57628b20-8b04-4cf6-85d3-048b667d0ae5"));
            labelGrossWage = (ITTLabel)AddControl(new Guid("2aa196c2-66ec-45a3-b7b9-622e38a1972b"));
            GrossWage = (ITTTextBox)AddControl(new Guid("8db499cc-4a1d-4827-a036-bfb17bdd02d1"));
            labelEndDate = (ITTLabel)AddControl(new Guid("d4dcdd87-8c5f-42d1-91c9-f3c2b4df75df"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("8761739e-0152-466e-ace6-0ac7ed225a64"));
            base.InitializeControls();
        }

        public MinimumWageDefinitionForm() : base("MINIMUMWAGEDEFINITION", "MinimumWageDefinitionForm")
        {
        }

        protected MinimumWageDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}