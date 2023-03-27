
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
    public partial class IlacRaporuKaydetForm : BaseIlacRaporuKaydetForm
    {
        protected TTObjectClasses.IlacRaporuKaydet _IlacRaporuKaydet
        {
            get { return (TTObjectClasses.IlacRaporuKaydet)_ttObject; }
        }

        protected ITTTabPage hakSahibiBilgisiTabpage;
        protected ITTLabel labeltckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelsoyadiHakSahibiBilgisiDVO;
        protected ITTTextBox karneNoHakSahibiBilgisiDVO;
        protected ITTTextBox sosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTipiHakSahibiBilgisiDVO;
        protected ITTTextBox soyadiHakSahibiBilgisiDVO;
        protected ITTLabel labelyakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox provizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTLabel labelkarneNoHakSahibiBilgisiDVO;
        protected ITTTextBox yakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsigortaliTuruHakSahibiBilgisiDVO;
        protected ITTDateTimePicker provizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox tckimlikNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox devredilenKurumHakSahibiBilgisiDVO;
        protected ITTListDefComboBox sigortaliTuruHakSahibiBilgisiDVO;
        protected ITTLabel labeladiHakSahibiBilgisiDVO;
        protected ITTTextBox adiHakSahibiBilgisiDVO;
        protected ITTLabel labeldevredilenKurumHakSahibiBilgisiDVO;
        override protected void InitializeControls()
        {
            hakSahibiBilgisiTabpage = (ITTTabPage)AddControl(new Guid("678c47a6-9e48-4db3-9fae-991f31a38a08"));
            labeltckimlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("dfbe1298-9775-478a-817f-a61be232617c"));
            labelsoyadiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("11e93207-fdf7-427f-9912-76fdb3a8b60f"));
            karneNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("e7f9e7bc-1972-467a-93c2-3dbd41bd5f21"));
            sosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("a136ed33-4044-4674-866a-57834f7c76ad"));
            labelprovizyonTipiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("86ddf374-e009-48ed-a862-f33df32669bb"));
            soyadiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("9a50925f-1534-40c6-b209-f537e96f141d"));
            labelyakinlikKoduHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("2d487426-65eb-4a5f-b6b1-c3669f4195b5"));
            labelsosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("228f36b7-503f-43c6-89c7-b6cdc433e65e"));
            provizyonTipiHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("5e502015-a937-4b97-aaa9-f593484dcf48"));
            labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("cc5865d5-33bd-4c42-a4b4-e1df4289e9db"));
            labelkarneNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("23aed6df-661b-4f13-a9c2-1bf455d5a252"));
            yakinlikKoduHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("d315d688-def7-459e-93d7-50612f22e514"));
            labelsigortaliTuruHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("d5c5be1c-6042-4c15-b4cf-ba435f6b2412"));
            provizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("add56cd7-3167-4b39-b1eb-c041ad90c710"));
            tckimlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("1dc97863-5ba9-4504-ba95-c5cef960c3a8"));
            devredilenKurumHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("79d1250b-c689-4ea6-8e5f-4132290b8f16"));
            sigortaliTuruHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("48cb36da-3ad8-417f-81e3-ed647cffab80"));
            labeladiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("3bcdf732-a1b2-4e1f-817d-0ef4d0d148b4"));
            adiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("1c7d2406-6191-41eb-ad2e-8de0320be0c9"));
            labeldevredilenKurumHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("f65bd12a-f9fa-4607-84af-159efd21056b"));
            base.InitializeControls();
        }

        public IlacRaporuKaydetForm() : base("ILACRAPORUKAYDET", "IlacRaporuKaydetForm")
        {
        }

        protected IlacRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}