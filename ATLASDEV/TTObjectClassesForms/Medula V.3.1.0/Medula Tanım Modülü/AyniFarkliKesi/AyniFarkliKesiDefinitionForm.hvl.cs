
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
    /// Aynı Farklı Kesi Tanımlama
    /// </summary>
    public partial class AyniFarkliKesiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Aynı Farklı Kesi
    /// </summary>
        protected TTObjectClasses.AyniFarkliKesi _AyniFarkliKesi
        {
            get { return (TTObjectClasses.AyniFarkliKesi)_ttObject; }
        }

        protected ITTLabel labelayniFarkliKesiKodu;
        protected ITTTextBox ayniFarkliKesiKodu;
        protected ITTLabel labelayniFarkliKesiAdi;
        protected ITTTextBox ayniFarkliKesiAdi;
        override protected void InitializeControls()
        {
            labelayniFarkliKesiKodu = (ITTLabel)AddControl(new Guid("5091fd32-3a7f-45b3-ba84-24c0d5d50049"));
            ayniFarkliKesiKodu = (ITTTextBox)AddControl(new Guid("7a36ccbf-ab02-49d4-b955-a14e44e20bde"));
            labelayniFarkliKesiAdi = (ITTLabel)AddControl(new Guid("27fb0d27-d5f5-4f8f-b5e4-f4fcf0d4ef9d"));
            ayniFarkliKesiAdi = (ITTTextBox)AddControl(new Guid("20078d92-a692-4cea-a133-e9e8b7158d93"));
            base.InitializeControls();
        }

        public AyniFarkliKesiDefinitionForm() : base("AYNIFARKLIKESI", "AyniFarkliKesiDefinitionForm")
        {
        }

        protected AyniFarkliKesiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}