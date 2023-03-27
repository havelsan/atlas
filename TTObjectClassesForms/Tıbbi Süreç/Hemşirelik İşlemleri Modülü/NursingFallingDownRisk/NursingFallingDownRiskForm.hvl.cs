
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
    /// Düşme Riski
    /// </summary>
    public partial class NursingFallingDownRiskForm : TTForm
    {
        protected TTObjectClasses.NursingFallingDownRisk _NursingFallingDownRisk
        {
            get { return (TTObjectClasses.NursingFallingDownRisk)_ttObject; }
        }

        protected ITTLabel labelRiskFactor;
        protected ITTObjectListBox RiskFactor;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelRiskFactor = (ITTLabel)AddControl(new Guid("22e98f2f-d4cb-4ed1-b301-1b38984d2ebe"));
            RiskFactor = (ITTObjectListBox)AddControl(new Guid("35ea754a-0c62-4863-9c20-20fdf27ee3b7"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5828e7f9-edc3-47a0-83d0-61e69e6ae50b"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4dc765ed-db2b-4121-ad8d-4da845fb8b7b"));
            base.InitializeControls();
        }

        public NursingFallingDownRiskForm() : base("NURSINGFALLINGDOWNRISK", "NursingFallingDownRiskForm")
        {
        }

        protected NursingFallingDownRiskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}