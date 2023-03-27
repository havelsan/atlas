
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
    /// Devredilen Kurum Tanımlama
    /// </summary>
    public partial class DevredilenKurumDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Devredilen Kurum
    /// </summary>
        protected TTObjectClasses.DevredilenKurum _DevredilenKurum
        {
            get { return (TTObjectClasses.DevredilenKurum)_ttObject; }
        }

        protected ITTLabel labeldevredilenKurumKodu;
        protected ITTTextBox devredilenKurumKodu;
        protected ITTLabel labeldevredilenKurumAdi;
        protected ITTTextBox devredilenKurumAdi;
        override protected void InitializeControls()
        {
            labeldevredilenKurumKodu = (ITTLabel)AddControl(new Guid("f64f2e5e-db2e-429c-9467-920e7e10e877"));
            devredilenKurumKodu = (ITTTextBox)AddControl(new Guid("fb22e801-c606-4ed5-a6de-808f263404f4"));
            labeldevredilenKurumAdi = (ITTLabel)AddControl(new Guid("a1402150-9903-424c-9829-e0da5682df0a"));
            devredilenKurumAdi = (ITTTextBox)AddControl(new Guid("1a00ae67-c7df-44fb-a30b-47a1fcb92248"));
            base.InitializeControls();
        }

        public DevredilenKurumDefinitionForm() : base("DEVREDILENKURUM", "DevredilenKurumDefinitionForm")
        {
        }

        protected DevredilenKurumDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}