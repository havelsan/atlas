
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
    /// Randevu Bilgileri
    /// </summary>
    public partial class SubactionProcedureAppointmentForm : TTForm
    {
        protected TTObjectClasses.SubactionProcedureFlowable _SubactionProcedureFlowable
        {
            get { return (TTObjectClasses.SubactionProcedureFlowable)_ttObject; }
        }

        protected ITTTextBox tttextboxDescription;
        override protected void InitializeControls()
        {
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("d72f7a98-7c67-4659-aac2-c100898886cf"));
            base.InitializeControls();
        }

        public SubactionProcedureAppointmentForm() : base("SUBACTIONPROCEDUREFLOWABLE", "SubactionProcedureAppointmentForm")
        {
        }

        protected SubactionProcedureAppointmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}