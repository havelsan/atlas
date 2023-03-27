
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
    public partial class TedaviRaporuKaydetForm : BaseTedaviRaporuKaydetForm
    {
        protected TTObjectClasses.TedaviRaporuKaydet _TedaviRaporuKaydet
        {
            get { return (TTObjectClasses.TedaviRaporuKaydet)_ttObject; }
        }

        protected ITTTabPage hakSahibiBilgisiTabpage;
        protected ITTTextBox tckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labelyakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsoyadiHakSahibiBilgisiDVO;
        protected ITTTextBox soyadiHakSahibiBilgisiDVO;
        protected ITTLabel labelsosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labeldevredilenKurumHakSahibiBilgisiDVO;
        protected ITTListDefComboBox provizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labeladiHakSahibiBilgisiDVO;
        protected ITTTextBox adiHakSahibiBilgisiDVO;
        protected ITTListDefComboBox sigortaliTuruHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox karneNoHakSahibiBilgisiDVO;
        protected ITTLabel labelkarneNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox devredilenKurumHakSahibiBilgisiDVO;
        protected ITTTextBox yakinlikKoduHakSahibiBilgisiDVO;
        protected ITTTextBox sosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelsigortaliTuruHakSahibiBilgisiDVO;
        protected ITTDateTimePicker provizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTLabel labeltckimlikNoHakSahibiBilgisiDVO;
        override protected void InitializeControls()
        {
            hakSahibiBilgisiTabpage = (ITTTabPage)AddControl(new Guid("7000853c-ccbf-4601-bf71-4b2925ef60f0"));
            tckimlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("1b693f2d-7566-4bc5-ba8a-5f35cf436c83"));
            labelprovizyonTipiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("a28c28dc-b853-4116-8562-6a8aca6f4f80"));
            labelyakinlikKoduHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("f58afaa1-b6fc-4d95-8a5f-7a48b89e8b6b"));
            labelsoyadiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("7d40b995-a150-4003-9227-e2850cda46f5"));
            soyadiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("c0d39adf-05a0-4a97-a700-f68a6eeb5f78"));
            labelsosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("7aeaef01-df50-4674-8d53-4aac6f4a04cd"));
            labeldevredilenKurumHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("2a6bf355-af48-4d44-9171-7fc7492230c9"));
            provizyonTipiHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("a877b6a2-c8d8-4179-a11c-fb55e3a48bd8"));
            labeladiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("6b3e9c58-a6ab-4cbf-92ab-af1b1db33925"));
            adiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("e719db1b-d918-41ed-9cc6-e5eb2c8bedf9"));
            sigortaliTuruHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("24644ee6-40db-4d01-963e-8fbe7e043d50"));
            labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("8e2b0dea-0a5a-44ac-9b67-554541068622"));
            karneNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("500bfde2-88b4-4ffd-a42d-c523f5150880"));
            labelkarneNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("733dd53e-5f69-4344-8f29-e65d347e9d8c"));
            devredilenKurumHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("91daadf9-2856-4062-bf68-8d6bb4f862c1"));
            yakinlikKoduHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("0a419cd7-8663-4cf9-8064-281f3d0b4fd4"));
            sosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("13931967-1145-4ec1-92ec-d65a907d0729"));
            labelsigortaliTuruHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("73fdff0b-d321-4e57-bce4-e4e27dc40034"));
            provizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("8794bf2c-f6f1-41e2-89db-57deb3c4aa3f"));
            labeltckimlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("64179d2e-38b6-4451-9e60-0f2433dc09b5"));
            base.InitializeControls();
        }

        public TedaviRaporuKaydetForm() : base("TEDAVIRAPORUKAYDET", "TedaviRaporuKaydetForm")
        {
        }

        protected TedaviRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}