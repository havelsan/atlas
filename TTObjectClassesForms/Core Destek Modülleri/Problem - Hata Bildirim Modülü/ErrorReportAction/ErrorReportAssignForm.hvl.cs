
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
    /// Problem / Hata Bildirimi
    /// </summary>
    public partial class ErrorReportAssignForm : ErrorReportApproveForm
    {
    /// <summary>
    /// Problem / Hata Bildirimi
    /// </summary>
        protected TTObjectClasses.ErrorReportAction _ErrorReportAction
        {
            get { return (TTObjectClasses.ErrorReportAction)_ttObject; }
        }

        protected ITTLabel labelSolutionMaterialCost;
        protected ITTTextBox SolutionMaterialCost;
        protected ITTLabel labelSolutionWorkHours;
        protected ITTTextBox SolutionWorkHours;
        protected ITTLabel labelSolutionBuilding;
        protected ITTTextBox SolutionBuilding;
        protected ITTLabel labelSolutionDescription;
        protected ITTRichTextBoxControl SolutionDescription;
        protected ITTLabel labelSolutionStartDateTime;
        protected ITTDateTimePicker SolutionStartDateTime;
        protected ITTLabel labelSolutionEndDateTime;
        protected ITTDateTimePicker SolutionEndDateTime;
        override protected void InitializeControls()
        {
            labelSolutionMaterialCost = (ITTLabel)AddControl(new Guid("00d4e033-459e-45c1-9f83-908ffc96c336"));
            SolutionMaterialCost = (ITTTextBox)AddControl(new Guid("fdbfc402-2d11-49ae-904e-7092da5d3edd"));
            labelSolutionWorkHours = (ITTLabel)AddControl(new Guid("55fd4fca-039f-4f61-a425-866359c3aab6"));
            SolutionWorkHours = (ITTTextBox)AddControl(new Guid("0774b914-f134-4369-bc70-c072738e7ea9"));
            labelSolutionBuilding = (ITTLabel)AddControl(new Guid("cb5aefec-444b-4368-9242-f5f7dfa219e4"));
            SolutionBuilding = (ITTTextBox)AddControl(new Guid("e9df3837-e66e-4184-abd3-d4aaeb6f62fb"));
            labelSolutionDescription = (ITTLabel)AddControl(new Guid("3dc69d37-d0b5-4af8-a8ff-93e30e3e1e2e"));
            SolutionDescription = (ITTRichTextBoxControl)AddControl(new Guid("0ffde773-27f5-480c-85b3-a184e16f3d71"));
            labelSolutionStartDateTime = (ITTLabel)AddControl(new Guid("016d524c-8e5e-4d60-b424-34b7f7cd9709"));
            SolutionStartDateTime = (ITTDateTimePicker)AddControl(new Guid("0dc615cc-8a77-4896-9475-fc8843f59dc1"));
            labelSolutionEndDateTime = (ITTLabel)AddControl(new Guid("abd1c9ba-eb25-42e7-9f32-43402a9e23b5"));
            SolutionEndDateTime = (ITTDateTimePicker)AddControl(new Guid("1a7493ac-eba8-4433-b93e-fa2b9a96c150"));
            base.InitializeControls();
        }

        public ErrorReportAssignForm() : base("ERRORREPORTACTION", "ErrorReportAssignForm")
        {
        }

        protected ErrorReportAssignForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}