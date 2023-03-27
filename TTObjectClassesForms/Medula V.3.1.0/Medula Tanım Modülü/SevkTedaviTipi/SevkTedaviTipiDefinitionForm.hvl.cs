
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
    public partial class SevkTedaviTipiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sevk Tedavi Tipi
    /// </summary>
        protected TTObjectClasses.SevkTedaviTipi _SevkTedaviTipi
        {
            get { return (TTObjectClasses.SevkTedaviTipi)_ttObject; }
        }

        protected ITTLabel labelsevkTedaviTipiKodu;
        protected ITTTextBox sevkTedaviTipiKodu;
        protected ITTLabel labelsevkTedaviTipiAdi;
        protected ITTTextBox sevkTedaviTipiAdi;
        override protected void InitializeControls()
        {
            labelsevkTedaviTipiKodu = (ITTLabel)AddControl(new Guid("0119c9f4-c945-429b-9520-752e4e6954bb"));
            sevkTedaviTipiKodu = (ITTTextBox)AddControl(new Guid("aa3748ab-9130-4f18-a797-ec9f6c688de4"));
            labelsevkTedaviTipiAdi = (ITTLabel)AddControl(new Guid("c4092164-37d5-4879-a208-5fa9b141fe55"));
            sevkTedaviTipiAdi = (ITTTextBox)AddControl(new Guid("635c963c-a85d-48c5-bf3a-db21f4b8ecea"));
            base.InitializeControls();
        }

        public SevkTedaviTipiDefinitionForm() : base("SEVKTEDAVITIPI", "SevkTedaviTipiDefinitionForm")
        {
        }

        protected SevkTedaviTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}