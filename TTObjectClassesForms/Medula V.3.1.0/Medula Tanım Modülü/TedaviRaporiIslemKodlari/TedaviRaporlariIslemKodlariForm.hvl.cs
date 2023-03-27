
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
    /// Tedavi Raporları İşlem Kodları Tanımlama
    /// </summary>
    public partial class TedaviRaporlariIslemKodlariForm : TTDefinitionForm
    {
    /// <summary>
    /// Tedavi Raporları İşlem Kodları
    /// </summary>
        protected TTObjectClasses.TedaviRaporiIslemKodlari _TedaviRaporiIslemKodlari
        {
            get { return (TTObjectClasses.TedaviRaporiIslemKodlari)_ttObject; }
        }

        protected ITTLabel labelTedaviRaporuTuruKodu;
        protected ITTTextBox TedaviRaporuTuruKodu;
        protected ITTTextBox TedaviRaporuTuru;
        protected ITTTextBox TedaviRaporuIslemKodu;
        protected ITTTextBox TedaviRaporuIslemi;
        protected ITTLabel labelTedaviRaporuTuru;
        protected ITTLabel labelTedaviRaporuIslemKodu;
        protected ITTLabel labelTedaviRaporuIslemi;
        override protected void InitializeControls()
        {
            labelTedaviRaporuTuruKodu = (ITTLabel)AddControl(new Guid("04736ea9-49d2-4ea9-bbd9-53f2bd7d4506"));
            TedaviRaporuTuruKodu = (ITTTextBox)AddControl(new Guid("fbb23ae2-e76c-429a-87d5-455043cb8f61"));
            TedaviRaporuTuru = (ITTTextBox)AddControl(new Guid("5c7d1843-ab04-4bde-9b8b-ea4d30eaf582"));
            TedaviRaporuIslemKodu = (ITTTextBox)AddControl(new Guid("8264b4ef-62ff-4c82-bd75-6844ea54c034"));
            TedaviRaporuIslemi = (ITTTextBox)AddControl(new Guid("d34a6c2d-1cc9-4893-b754-8b0c8b4356d9"));
            labelTedaviRaporuTuru = (ITTLabel)AddControl(new Guid("0c9bad47-b6b7-47b6-9a21-c0b483a0dced"));
            labelTedaviRaporuIslemKodu = (ITTLabel)AddControl(new Guid("bda80e45-d1f5-4afe-a238-74bedbd1afb4"));
            labelTedaviRaporuIslemi = (ITTLabel)AddControl(new Guid("e345f157-8bb3-4842-a98d-35c93ec982fd"));
            base.InitializeControls();
        }

        public TedaviRaporlariIslemKodlariForm() : base("TEDAVIRAPORIISLEMKODLARI", "TedaviRaporlariIslemKodlariForm")
        {
        }

        protected TedaviRaporlariIslemKodlariForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}