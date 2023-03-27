
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
    /// Kemoterapi Radyoterapi Formu
    /// </summary>
    public partial class ChemotherapyRadiotherapyForm : TTForm
    {
    /// <summary>
    /// Kemoterapi ve Radyoterapi için kullanılacak temel nesne
    /// </summary>
        protected TTObjectClasses.ChemotherapyRadiotherapy _ChemotherapyRadiotherapy
        {
            get { return (TTObjectClasses.ChemotherapyRadiotherapy)_ttObject; }
        }

        protected ITTLabel labelCureStartDate;
        protected ITTDateTimePicker CureStartDate;
        override protected void InitializeControls()
        {
            labelCureStartDate = (ITTLabel)AddControl(new Guid("096b053e-33fc-483c-953b-bef8ff8faaf1"));
            CureStartDate = (ITTDateTimePicker)AddControl(new Guid("cf0dbb4f-a505-4aca-a160-e09d4cecfdb2"));
            base.InitializeControls();
        }

        public ChemotherapyRadiotherapyForm() : base("CHEMOTHERAPYRADIOTHERAPY", "ChemotherapyRadiotherapyForm")
        {
        }

        protected ChemotherapyRadiotherapyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}