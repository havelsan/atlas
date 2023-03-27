
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
    public partial class LaboratorySubProcedureLongReportForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Alt Test
    /// </summary>
        protected TTObjectClasses.LaboratorySubProcedure _LaboratorySubProcedure
        {
            get { return (TTObjectClasses.LaboratorySubProcedure)_ttObject; }
        }

        protected ITTRichTextBoxControl rtfLongReport;
        override protected void InitializeControls()
        {
            rtfLongReport = (ITTRichTextBoxControl)AddControl(new Guid("7b08a110-da11-4082-9a19-c3bcde7a329c"));
            base.InitializeControls();
        }

        public LaboratorySubProcedureLongReportForm() : base("LABORATORYSUBPROCEDURE", "LaboratorySubProcedureLongReportForm")
        {
        }

        protected LaboratorySubProcedureLongReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}