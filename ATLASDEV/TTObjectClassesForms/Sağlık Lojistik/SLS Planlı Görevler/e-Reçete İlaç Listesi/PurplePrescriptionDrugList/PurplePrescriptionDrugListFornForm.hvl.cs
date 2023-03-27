
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
    /// e-Reçete Mor İlaç Listesi
    /// </summary>
    public partial class PurplePrescriptionDrugListForn : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Mor Reçete İlaç Listesi
    /// </summary>
        protected TTObjectClasses.PurplePrescriptionDrugList _PurplePrescriptionDrugList
        {
            get { return (TTObjectClasses.PurplePrescriptionDrugList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("8011b559-47e0-4dfa-b0ad-e328fbde31d7"));
            btnChoose = (ITTButton)AddControl(new Guid("89c5fdae-18c6-42fb-a95e-90c7a70090e4"));
            labelFilePath = (ITTLabel)AddControl(new Guid("dd49c1ca-786e-46ca-b9bc-e83fedfea080"));
            base.InitializeControls();
        }

        public PurplePrescriptionDrugListForn() : base("PURPLEPRESCRIPTIONDRUGLIST", "PurplePrescriptionDrugListForn")
        {
        }

        protected PurplePrescriptionDrugListForn(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}