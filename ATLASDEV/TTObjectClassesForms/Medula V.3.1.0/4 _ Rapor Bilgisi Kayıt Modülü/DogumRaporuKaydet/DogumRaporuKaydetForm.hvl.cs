
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
    public partial class DogumRaporuKaydetForm : BaseDogumRaporuKaydetForm
    {
        protected TTObjectClasses.DogumRaporuKaydet _DogumRaporuKaydet
        {
            get { return (TTObjectClasses.DogumRaporuKaydet)_ttObject; }
        }

        protected ITTTabPage halSahibiBilgisiTabpage;
        protected ITTLabel labeltckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labelyakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsoyadiHakSahibiBilgisiDVO;
        protected ITTTextBox yakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labeldevredilenKurumHakSahibiBilgisiDVO;
        protected ITTListDefComboBox provizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labeladiHakSahibiBilgisiDVO;
        protected ITTTextBox adiHakSahibiBilgisiDVO;
        protected ITTListDefComboBox sigortaliTuruHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox karneNoHakSahibiBilgisiDVO;
        protected ITTTextBox tckimlikNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox devredilenKurumHakSahibiBilgisiDVO;
        protected ITTLabel labelkarneNoHakSahibiBilgisiDVO;
        protected ITTTextBox sosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelsigortaliTuruHakSahibiBilgisiDVO;
        protected ITTDateTimePicker provizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox soyadiHakSahibiBilgisiDVO;
        override protected void InitializeControls()
        {
            halSahibiBilgisiTabpage = (ITTTabPage)AddControl(new Guid("614b2f50-b389-44de-9bb5-7dfc42df69cb"));
            labeltckimlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("d737421a-b69d-4272-a4b1-05b46dd98a9e"));
            labelprovizyonTipiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("c594f039-9b61-4f83-902b-01a7d6ccd2b5"));
            labelyakinlikKoduHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("93395f96-ebfb-4b9a-abc4-e81de7494d25"));
            labelsoyadiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("9e541b9f-b2be-4845-93bf-205f417daf19"));
            yakinlikKoduHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("0e93ae32-bab7-4996-899e-e9396ec6e9c6"));
            labelsosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("3a82e279-42cc-4efe-bdf2-0f52edfd4928"));
            labeldevredilenKurumHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("00f98b18-147d-41e5-972d-c3875334cb15"));
            provizyonTipiHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("df9c79f2-2e05-47cb-8e6f-6999aad7e598"));
            labeladiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("bd6626ed-aad0-41c2-8e19-e83d561e34f4"));
            adiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("1572c6ea-00ae-4af3-92ce-3502c6ab64e5"));
            sigortaliTuruHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("3469a029-2710-4eef-af35-dabb9b0dfdd1"));
            labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("51045e7d-0c8c-4557-95a9-3edaf3407dd9"));
            karneNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("3dd62761-fece-4aaf-9ae7-35fde8f6b435"));
            tckimlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("19b52f65-185b-44de-94ab-de7434d1452e"));
            devredilenKurumHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("c28332eb-c673-49d1-b2f9-3c54aa21d386"));
            labelkarneNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("39e4bd0c-63fa-44a3-944c-348b179122db"));
            sosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("9ab072e6-cdcd-42b8-9f2c-29f996adf9de"));
            labelsigortaliTuruHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("a81ca58e-9d45-4d93-a1c6-4f6c08e9286b"));
            provizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("350adde0-bd5b-41f3-94c0-53ccde4cdcd7"));
            soyadiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("69595a4c-04a2-4c46-8e27-48f2c533fbd7"));
            base.InitializeControls();
        }

        public DogumRaporuKaydetForm() : base("DOGUMRAPORUKAYDET", "DogumRaporuKaydetForm")
        {
        }

        protected DogumRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}