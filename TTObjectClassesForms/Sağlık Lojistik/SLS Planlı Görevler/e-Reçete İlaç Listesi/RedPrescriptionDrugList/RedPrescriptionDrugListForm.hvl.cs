
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
    /// e-Reçete Kırmızı İlaç Listesi
    /// </summary>
    public partial class RedPrescriptionDrugListForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Kırmızı Reçete İlaç Listesi
    /// </summary>
        protected TTObjectClasses.RedPrescriptionDrugList _RedPrescriptionDrugList
        {
            get { return (TTObjectClasses.RedPrescriptionDrugList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("404acb10-2674-49ad-a957-7acda0bdc72c"));
            btnChoose = (ITTButton)AddControl(new Guid("bdf1fb70-311d-4c69-8b9a-122ccfa17caf"));
            labelFilePath = (ITTLabel)AddControl(new Guid("e2971e33-3a10-4ef0-a52e-27eb5717cfd1"));
            base.InitializeControls();
        }

        public RedPrescriptionDrugListForm() : base("REDPRESCRIPTIONDRUGLIST", "RedPrescriptionDrugListForm")
        {
        }

        protected RedPrescriptionDrugListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}