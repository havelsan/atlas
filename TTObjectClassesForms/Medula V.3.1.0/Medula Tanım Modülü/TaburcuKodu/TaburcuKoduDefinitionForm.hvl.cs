
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
    /// Taburcu Kodu Tanımlama
    /// </summary>
    public partial class TaburcuKoduDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Taburcu Kodu
    /// </summary>
        protected TTObjectClasses.TaburcuKodu _TaburcuKodu
        {
            get { return (TTObjectClasses.TaburcuKodu)_ttObject; }
        }

        protected ITTLabel labeltaburcuAdi;
        protected ITTTextBox taburcuAdi;
        protected ITTLabel labeltaburcuKodu;
        protected ITTTextBox taburcuKodu;
        override protected void InitializeControls()
        {
            labeltaburcuAdi = (ITTLabel)AddControl(new Guid("98b03964-eabe-48d4-ba75-53ff6b5b8ace"));
            taburcuAdi = (ITTTextBox)AddControl(new Guid("2ef6d896-bc69-4a46-a52c-a00660d6d4e5"));
            labeltaburcuKodu = (ITTLabel)AddControl(new Guid("1b130bfd-87ca-4a5c-9176-e35266c74488"));
            taburcuKodu = (ITTTextBox)AddControl(new Guid("8af8e887-6e4e-4d8b-b8b4-f1b7c9e07bc7"));
            base.InitializeControls();
        }

        public TaburcuKoduDefinitionForm() : base("TABURCUKODU", "XXXXXX")
        {
        }

        protected TaburcuKoduDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}