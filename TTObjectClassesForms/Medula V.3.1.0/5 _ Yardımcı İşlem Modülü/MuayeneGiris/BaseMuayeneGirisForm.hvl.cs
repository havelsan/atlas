
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
    public partial class BaseMuayeneGirisForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.MuayeneGiris _MuayeneGiris
        {
            get { return (TTObjectClasses.MuayeneGiris)_ttObject; }
        }

        protected ITTButton YeniReferansNumarasiAl;
        protected ITTLabel labelreferansNoMuayeneGirisDVO;
        protected ITTTextBox referansNoMuayeneGirisDVO;
        protected ITTLabel labelsutKoduMuayeneGirisDVO;
        protected ITTValueListBox sutKoduMuayeneGirisDVO;
        protected ITTLabel labelmuayeneTarihiDateTimeMuayeneGirisDVO;
        protected ITTDateTimePicker muayeneTarihiDateTimeMuayeneGirisDVO;
        protected ITTCheckBox gizliTutulsunmuMuayeneGirisDVO;
        protected ITTLabel labeldrTescilNoMuayeneGirisDVO;
        protected ITTValueListBox drTescilNoMuayeneGirisDVO;
        protected ITTLabel labelbransKoduMuayeneGirisDVO;
        protected ITTValueListBox bransKoduMuayeneGirisDVO;
        protected ITTLabel labelsaglikTesisKodu;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTGroupBox groupboxHastaBilgileri;
        protected ITTDateTimePicker HastaDogumTarihi;
        protected ITTLabel labelhastaTCKimlikNo;
        protected ITTTextBox hastaTCKimlikNo;
        protected ITTLabel labelHastaAd;
        protected ITTListDefComboBox HastaCinsiyet;
        protected ITTTextBox HastaAd;
        protected ITTListDefComboBox HastaSigortaliTuru;
        protected ITTLabel labelHastaSigortaliTuru;
        protected ITTTextBox HastaSoyad;
        protected ITTLabel labelHastaCinsiyet;
        protected ITTLabel labelHastaSoyad;
        protected ITTLabel labelHastaDogumTarihi;
        override protected void InitializeControls()
        {
            YeniReferansNumarasiAl = (ITTButton)AddControl(new Guid("7de5f5c7-7f94-4fc2-98d4-4ec8b5614b52"));
            labelreferansNoMuayeneGirisDVO = (ITTLabel)AddControl(new Guid("4c469cb9-08d1-4854-8c20-c02a4c1ff6b2"));
            referansNoMuayeneGirisDVO = (ITTTextBox)AddControl(new Guid("d6d575ea-0a6d-458c-9fc7-ddad54d6805f"));
            labelsutKoduMuayeneGirisDVO = (ITTLabel)AddControl(new Guid("d1cdbd83-bceb-45d0-a1b3-77d0077de622"));
            sutKoduMuayeneGirisDVO = (ITTValueListBox)AddControl(new Guid("a7aa75b3-5cb1-4a74-b1bf-b1548010d0d7"));
            labelmuayeneTarihiDateTimeMuayeneGirisDVO = (ITTLabel)AddControl(new Guid("1499b6e5-0d14-40a5-a45c-a81e87f2f0f8"));
            muayeneTarihiDateTimeMuayeneGirisDVO = (ITTDateTimePicker)AddControl(new Guid("f4719e59-f9fd-488b-a364-4d532191abcd"));
            gizliTutulsunmuMuayeneGirisDVO = (ITTCheckBox)AddControl(new Guid("302360ab-d67d-42da-b632-bba20903acf3"));
            labeldrTescilNoMuayeneGirisDVO = (ITTLabel)AddControl(new Guid("bf806d83-8eab-4f8b-b057-29fa7bb416a2"));
            drTescilNoMuayeneGirisDVO = (ITTValueListBox)AddControl(new Guid("3184283d-4a61-4aab-ab95-09230bf83a72"));
            labelbransKoduMuayeneGirisDVO = (ITTLabel)AddControl(new Guid("e5886cfb-59b1-48d5-ad35-92b2c2091edf"));
            bransKoduMuayeneGirisDVO = (ITTValueListBox)AddControl(new Guid("c8123d7b-f3c7-4e77-a13d-2d6ceb58fb0d"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("f0529cf0-dd98-451d-8cdb-62cb1ca70dd4"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("56700f6e-38ae-42a9-9b9f-9648394ec851"));
            groupboxHastaBilgileri = (ITTGroupBox)AddControl(new Guid("3b14d6f2-9c4b-4ca4-baba-bd08c6b16195"));
            HastaDogumTarihi = (ITTDateTimePicker)AddControl(new Guid("616707ab-cde4-4209-b1b1-20e34b40e807"));
            labelhastaTCKimlikNo = (ITTLabel)AddControl(new Guid("c01e991e-29ce-4acc-a434-e3217f74a9c5"));
            hastaTCKimlikNo = (ITTTextBox)AddControl(new Guid("97f41d4e-e521-43a2-8532-944dc0822421"));
            labelHastaAd = (ITTLabel)AddControl(new Guid("0854c1f9-3e90-42de-a958-4bbab67f3771"));
            HastaCinsiyet = (ITTListDefComboBox)AddControl(new Guid("fed6e5bf-7715-4739-99f8-f56d531ce85a"));
            HastaAd = (ITTTextBox)AddControl(new Guid("3afbd39b-ccde-4e88-b2d3-b26e5bb9ac2b"));
            HastaSigortaliTuru = (ITTListDefComboBox)AddControl(new Guid("48c1a7f2-956d-402f-b59c-36d2c75fdaf7"));
            labelHastaSigortaliTuru = (ITTLabel)AddControl(new Guid("7e01dcb7-d3bf-4766-97e8-5ec0ffa22570"));
            HastaSoyad = (ITTTextBox)AddControl(new Guid("05fb2389-3413-4369-bf1a-963edee547dc"));
            labelHastaCinsiyet = (ITTLabel)AddControl(new Guid("8b66d01d-0431-485f-8504-62383a896818"));
            labelHastaSoyad = (ITTLabel)AddControl(new Guid("b6aa0f7e-5dad-43ad-a6b5-1648de855205"));
            labelHastaDogumTarihi = (ITTLabel)AddControl(new Guid("a4c6750e-dcbd-4830-8204-c6581a2cb74b"));
            base.InitializeControls();
        }

        public BaseMuayeneGirisForm() : base("MUAYENEGIRIS", "BaseMuayeneGirisForm")
        {
        }

        protected BaseMuayeneGirisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}