
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
    /// Fiyat Çarpanı Tanım Ekranı
    /// </summary>
    public partial class PriceMultiplierDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Fiyat Çarpanı Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.PriceMultiplierDefinition _PriceMultiplierDefinition
        {
            get { return (TTObjectClasses.PriceMultiplierDefinition)_ttObject; }
        }

        protected ITTLabel labelNewMultiplier;
        protected ITTTextBox NewMultiplier;
        protected ITTTextBox OldMultiplier;
        protected ITTTextBox Name;
        protected ITTLabel labelOldMultiplier;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelNewMultiplier = (ITTLabel)AddControl(new Guid("36bc6506-9a3a-4270-8a0a-7ba144beba5d"));
            NewMultiplier = (ITTTextBox)AddControl(new Guid("b99b3c56-70ea-4627-bcaa-1b06f0904843"));
            OldMultiplier = (ITTTextBox)AddControl(new Guid("9bf9847a-ffb9-4722-94fa-ec018aeaa6cf"));
            Name = (ITTTextBox)AddControl(new Guid("abb69ac7-f5e4-4b1d-8af1-07b31b94e394"));
            labelOldMultiplier = (ITTLabel)AddControl(new Guid("dadad16f-5f64-4851-ad26-2ede1c5355ec"));
            labelName = (ITTLabel)AddControl(new Guid("8d0e3260-e20f-4952-b0fb-54c2624bda19"));
            base.InitializeControls();
        }

        public PriceMultiplierDefinitionForm() : base("PRICEMULTIPLIERDEFINITION", "PriceMultiplierDefinitionForm")
        {
        }

        protected PriceMultiplierDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}