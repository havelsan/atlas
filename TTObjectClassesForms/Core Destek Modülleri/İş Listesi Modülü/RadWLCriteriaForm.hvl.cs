
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
    /// Radyoloji Kriter Formu
    /// </summary>
    public partial class RadWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        protected ITTTextBox txtAccessionNo;
        protected ITTLabel lblEquipment;
        protected ITTComboBox cboEquipments;
        protected ITTLabel lblAccessionNo;
        protected ITTCheckBox checkEmergency;
        override protected void InitializeControls()
        {
            txtAccessionNo = (ITTTextBox)AddControl(new Guid("bba89b69-4dea-458f-8d62-585aa99e63c8"));
            lblEquipment = (ITTLabel)AddControl(new Guid("91d5a504-870f-4a4e-85af-17c11e90e490"));
            cboEquipments = (ITTComboBox)AddControl(new Guid("d67b8eec-7d0c-4246-8a97-d072276f0dc8"));
            lblAccessionNo = (ITTLabel)AddControl(new Guid("51247182-ed09-400c-87f8-d79836fa7f48"));
            checkEmergency = (ITTCheckBox)AddControl(new Guid("932a86b0-f769-4c90-b8b8-e2b305e713c9"));
            base.InitializeControls();
        }

        public RadWLCriteriaForm() : base("RadWLCriteriaForm")
        {
        }

        protected RadWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}