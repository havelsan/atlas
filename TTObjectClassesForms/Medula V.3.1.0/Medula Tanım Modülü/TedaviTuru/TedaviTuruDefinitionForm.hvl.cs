
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
    /// Tedavi Türü Tanımlama
    /// </summary>
    public partial class TedaviTuruDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Tedavi Türü
    /// </summary>
        protected TTObjectClasses.TedaviTuru _TedaviTuru
        {
            get { return (TTObjectClasses.TedaviTuru)_ttObject; }
        }

        protected ITTLabel labeltedaviTuruKodu;
        protected ITTTextBox tedaviTuruKodu;
        protected ITTTextBox tedaviTuruAdi;
        protected ITTLabel labeltedaviTuruAdi;
        override protected void InitializeControls()
        {
            labeltedaviTuruKodu = (ITTLabel)AddControl(new Guid("e9ea6493-f9b7-4c48-b644-6a9fd70f7803"));
            tedaviTuruKodu = (ITTTextBox)AddControl(new Guid("921ce37f-e9f0-4360-bf06-c3a52a61146f"));
            tedaviTuruAdi = (ITTTextBox)AddControl(new Guid("5ae11055-0abb-4490-9465-0a4f995c0827"));
            labeltedaviTuruAdi = (ITTLabel)AddControl(new Guid("72cd2afd-ea3b-4f92-9d37-e8411293810e"));
            base.InitializeControls();
        }

        public TedaviTuruDefinitionForm() : base("TEDAVITURU", "TedaviTuruDefinitionForm")
        {
        }

        protected TedaviTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}