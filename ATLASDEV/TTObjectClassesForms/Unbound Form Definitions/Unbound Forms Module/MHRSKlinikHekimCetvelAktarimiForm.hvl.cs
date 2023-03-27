
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
    /// MHRS Klinik-Hekim-Cetvel Aktarımı
    /// </summary>
    public partial class MHRSKlinikHekimCetvelAktarimi : TTUnboundForm
    {
        protected ITTButton btnPlanAktar;
        protected ITTButton btnAltKlinikAktar;
        override protected void InitializeControls()
        {
            btnPlanAktar = (ITTButton)AddControl(new Guid("9f6ba54d-e4dd-4862-b1ce-96e6eab39778"));
            btnAltKlinikAktar = (ITTButton)AddControl(new Guid("7b21e567-df25-4e02-bdf6-eb22fb489f75"));
            base.InitializeControls();
        }

        public MHRSKlinikHekimCetvelAktarimi() : base("MHRSKlinikHekimCetvelAktarimi")
        {
        }

        protected MHRSKlinikHekimCetvelAktarimi(string formDefName) : base(formDefName)
        {
        }
    }
}