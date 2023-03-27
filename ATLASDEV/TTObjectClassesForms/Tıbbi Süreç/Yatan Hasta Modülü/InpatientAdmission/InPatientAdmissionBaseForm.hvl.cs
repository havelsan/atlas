
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
    /// New Form
    /// </summary>
    public partial class InPatientAdmissionBaseForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.InpatientAdmission _InpatientAdmission
        {
            get { return (TTObjectClasses.InpatientAdmission)_ttObject; }
        }

        protected ITTTextBox BaseNumberOfEmptyBeds;
        override protected void InitializeControls()
        {
            BaseNumberOfEmptyBeds = (ITTTextBox)AddControl(new Guid("ce6a5b76-1547-4e28-8a24-7b0a622ae7e8"));
            base.InitializeControls();
        }

        public InPatientAdmissionBaseForm() : base("INPATIENTADMISSION", "InPatientAdmissionBaseForm")
        {
        }

        protected InPatientAdmissionBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}