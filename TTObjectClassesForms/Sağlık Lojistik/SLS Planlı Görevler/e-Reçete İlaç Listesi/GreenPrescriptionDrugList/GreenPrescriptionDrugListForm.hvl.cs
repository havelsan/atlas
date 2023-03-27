
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
    /// e-Reçete Yeşil İlaç Listesi
    /// </summary>
    public partial class GreenPrescriptionDrugListForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Yeşil  Reçete İlaç Listesi
    /// </summary>
        protected TTObjectClasses.GreenPrescriptionDrugList _GreenPrescriptionDrugList
        {
            get { return (TTObjectClasses.GreenPrescriptionDrugList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("feba6f74-2e81-41e4-8025-abbf69d7822c"));
            btnChoose = (ITTButton)AddControl(new Guid("426032c2-1ff3-4452-88e1-1d5047ac2a16"));
            labelFilePath = (ITTLabel)AddControl(new Guid("45fcf437-5ad8-4d06-96c3-c08da526494e"));
            base.InitializeControls();
        }

        public GreenPrescriptionDrugListForm() : base("GREENPRESCRIPTIONDRUGLIST", "GreenPrescriptionDrugListForm")
        {
        }

        protected GreenPrescriptionDrugListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}