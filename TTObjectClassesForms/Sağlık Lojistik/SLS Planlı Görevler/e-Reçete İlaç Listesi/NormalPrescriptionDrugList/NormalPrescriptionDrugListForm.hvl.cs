
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
    /// e-Reçete Normal İlaç Listesi
    /// </summary>
    public partial class NormalPrescriptionDrugListForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Normal Reçete İlaç Listesi
    /// </summary>
        protected TTObjectClasses.NormalPrescriptionDrugList _NormalPrescriptionDrugList
        {
            get { return (TTObjectClasses.NormalPrescriptionDrugList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("38252bbf-df2a-45e3-8016-70fc2ef82d0a"));
            btnChoose = (ITTButton)AddControl(new Guid("69550d7c-7785-4a7b-8a61-7a39c353a42f"));
            labelFilePath = (ITTLabel)AddControl(new Guid("d19c7a0b-5585-4810-bd03-a9075ec5ba36"));
            base.InitializeControls();
        }

        public NormalPrescriptionDrugListForm() : base("NORMALPRESCRIPTIONDRUGLIST", "NormalPrescriptionDrugListForm")
        {
        }

        protected NormalPrescriptionDrugListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}