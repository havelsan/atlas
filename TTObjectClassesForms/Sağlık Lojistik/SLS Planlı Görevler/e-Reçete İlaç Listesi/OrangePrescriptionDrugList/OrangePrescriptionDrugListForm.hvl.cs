
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
    /// e-Reçete Turuncu İlaç Listesi
    /// </summary>
    public partial class OrangePrescriptionDrugListForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Turuncu Reçete İlaç Listesi
    /// </summary>
        protected TTObjectClasses.OrangePrescriptionDrugList _OrangePrescriptionDrugList
        {
            get { return (TTObjectClasses.OrangePrescriptionDrugList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("2d6434a4-a960-49ea-a924-762b7a0672ee"));
            btnChoose = (ITTButton)AddControl(new Guid("146f78c0-2b19-4743-a40e-c654a71f9cee"));
            labelFilePath = (ITTLabel)AddControl(new Guid("14f81220-aad7-4386-a7c5-ea7dcb312191"));
            base.InitializeControls();
        }

        public OrangePrescriptionDrugListForm() : base("ORANGEPRESCRIPTIONDRUGLIST", "OrangePrescriptionDrugListForm")
        {
        }

        protected OrangePrescriptionDrugListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}