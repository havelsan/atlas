
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
    public partial class LaboratoryProcedureLongReportForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Test
    /// </summary>
        protected TTObjectClasses.LaboratoryProcedure _LaboratoryProcedure
        {
            get { return (TTObjectClasses.LaboratoryProcedure)_ttObject; }
        }

        protected ITTRichTextBoxControl rtfLongReport;
        override protected void InitializeControls()
        {
            rtfLongReport = (ITTRichTextBoxControl)AddControl(new Guid("6db818b2-94d6-4020-85bc-172041468ce6"));
            base.InitializeControls();
        }

        public LaboratoryProcedureLongReportForm() : base("LABORATORYPROCEDURE", "LaboratoryProcedureLongReportForm")
        {
        }

        protected LaboratoryProcedureLongReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}