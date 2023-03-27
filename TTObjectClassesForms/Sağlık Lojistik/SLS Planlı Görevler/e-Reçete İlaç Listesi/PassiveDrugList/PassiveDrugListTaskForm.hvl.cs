
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
    /// e-Reçete Pasif İlaç Listesi
    /// </summary>
    public partial class PassiveDrugListTaskForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Geri ödeme kapsamında olmayan ilaç listesi
    /// </summary>
        protected TTObjectClasses.PassiveDrugList _PassiveDrugList
        {
            get { return (TTObjectClasses.PassiveDrugList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("1c68c45f-9eda-45c5-9b90-0dfe1dfc6582"));
            btnChoose = (ITTButton)AddControl(new Guid("96318c4c-9822-425d-8f2a-2cb500fdd320"));
            labelFilePath = (ITTLabel)AddControl(new Guid("2ab4e4df-abcb-4990-ae91-d1e4a0f38c05"));
            base.InitializeControls();
        }

        public PassiveDrugListTaskForm() : base("PASSIVEDRUGLIST", "PassiveDrugListTaskForm")
        {
        }

        protected PassiveDrugListTaskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}