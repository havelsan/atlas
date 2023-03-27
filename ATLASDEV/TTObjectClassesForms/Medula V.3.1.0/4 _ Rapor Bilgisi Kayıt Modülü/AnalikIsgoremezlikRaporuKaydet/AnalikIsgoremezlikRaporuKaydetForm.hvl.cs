
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
    public partial class AnalikIsgoremezlikRaporuKaydetForm : BaseAnalikIsgoremezlikRaporuKaydetForm
    {
        protected TTObjectClasses.AnalikIsgoremezlikRaporuKaydet _AnalikIsgoremezlikRaporuKaydet
        {
            get { return (TTObjectClasses.AnalikIsgoremezlikRaporuKaydet)_ttObject; }
        }

        protected ITTTabPage HakSahibiBilgisiDVOTabpage;
        protected ITTLabel labeltckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labeldevredilenKurumHakSahibiBilgisiDVO;
        protected ITTLabel labeladiHakSahibiBilgisiDVO;
        protected ITTListDefComboBox sigortaliTuruHakSahibiBilgisiDVO;
        protected ITTTextBox karneNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox devredilenKurumHakSahibiBilgisiDVO;
        protected ITTTextBox sosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTDateTimePicker provizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox soyadiHakSahibiBilgisiDVO;
        protected ITTLabel labelsigortaliTuruHakSahibiBilgisiDVO;
        protected ITTTextBox yakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelkarneNoHakSahibiBilgisiDVO;
        protected ITTTextBox tckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox adiHakSahibiBilgisiDVO;
        protected ITTListDefComboBox provizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labelsosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelsoyadiHakSahibiBilgisiDVO;
        protected ITTLabel labelyakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTipiHakSahibiBilgisiDVO;
        override protected void InitializeControls()
        {
            HakSahibiBilgisiDVOTabpage = (ITTTabPage)AddControl(new Guid("3221bf64-3474-4542-a54f-5c259c09f7a8"));
            labeltckimlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("20b4c482-923d-4071-8ed5-e792eddeb5ee"));
            labeldevredilenKurumHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("778d7dcd-17c5-43dc-8546-ad89c977adca"));
            labeladiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("619d06d7-4ad3-4ac7-9020-e2ffb737e56b"));
            sigortaliTuruHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("4dbea7fe-875f-45f1-b287-d7760b295e65"));
            karneNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("ba7819b6-aab9-4fcf-bd11-31dfc988dd6d"));
            devredilenKurumHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("88c9e3b5-054f-4890-8889-265ff63f81ad"));
            sosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("2746c9a4-896d-4a85-b798-22bdf8234ec2"));
            provizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("317eda2a-ec8f-4a7a-b1fe-1c1f2dc61b4b"));
            soyadiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("8bb3fb59-a012-4b50-a1cc-7d50776d8bff"));
            labelsigortaliTuruHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("3ab770c4-0562-458e-89fe-595432a097cd"));
            yakinlikKoduHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("ef01ca5c-487c-4020-b117-995d78dbba0f"));
            labelkarneNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("d0361952-49de-46ac-8b25-496fc29b225d"));
            tckimlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("2dc093d0-650e-441c-951b-0820111be155"));
            labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("814cd263-970a-4898-bdc9-9460e734927f"));
            adiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("ba7fb82b-8b51-47e5-acef-782507550f71"));
            provizyonTipiHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("82f41785-33b1-4356-82ca-964db0b9aedb"));
            labelsosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("ff036c26-b42f-426d-a7d2-454a3f2d1c19"));
            labelsoyadiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("251585cd-fab8-46a7-b0bb-a2c5db1a6546"));
            labelyakinlikKoduHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("6d2fd540-b02e-49a1-bec5-4399f060faa8"));
            labelprovizyonTipiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("27edf25b-a470-4471-92e3-17ffeec6de77"));
            base.InitializeControls();
        }

        public AnalikIsgoremezlikRaporuKaydetForm() : base("ANALIKISGOREMEZLIKRAPORUKAYDET", "AnalikIsgoremezlikRaporuKaydetForm")
        {
        }

        protected AnalikIsgoremezlikRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}