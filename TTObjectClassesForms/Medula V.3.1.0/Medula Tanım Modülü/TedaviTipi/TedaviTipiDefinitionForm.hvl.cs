
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
    /// Tedavi Tipi Tanımlama
    /// </summary>
    public partial class TedaviTipiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Tedavi Tipi
    /// </summary>
        protected TTObjectClasses.TedaviTipi _TedaviTipi
        {
            get { return (TTObjectClasses.TedaviTipi)_ttObject; }
        }

        protected ITTLabel labeltedaviTipiKodu;
        protected ITTTextBox tedaviTipiKodu;
        protected ITTLabel labeltedaviTipiAdi;
        protected ITTTextBox tedaviTipiAdi;
        override protected void InitializeControls()
        {
            labeltedaviTipiKodu = (ITTLabel)AddControl(new Guid("93ff7e38-e1df-499d-a883-6688966ebda0"));
            tedaviTipiKodu = (ITTTextBox)AddControl(new Guid("0092ddbb-f7dd-42cb-9155-b084dd0f5c1d"));
            labeltedaviTipiAdi = (ITTLabel)AddControl(new Guid("3da794e3-b234-4adc-af9f-4c9e30b67006"));
            tedaviTipiAdi = (ITTTextBox)AddControl(new Guid("fd2afd52-c8f5-4f8d-9779-b4188f744fc4"));
            base.InitializeControls();
        }

        public TedaviTipiDefinitionForm() : base("TEDAVITIPI", "TedaviTipiDefinitionForm")
        {
        }

        protected TedaviTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}