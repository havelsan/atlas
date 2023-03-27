
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
    /// Temel Hasta Kabul
    /// </summary>
    public partial class BaseHastaKabulForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hasta Kabul
    /// </summary>
        protected TTObjectClasses.BaseHastaKabul _BaseHastaKabul
        {
            get { return (TTObjectClasses.BaseHastaKabul)_ttObject; }
        }

        protected ITTTabControl tabControlHastaKabul;
        protected ITTTabPage tabpageProvizyon;
        protected ITTGroupBox groupboxProvizyon;
        protected ITTLabel labelprovizyonTarihi;
        protected ITTDateTimePicker provizyonTarihiDateTimePicker;
        protected ITTListDefComboBox devredilenKurum;
        protected ITTListDefComboBox provizyonTipi;
        protected ITTLabel labeldevredilenKurum;
        protected ITTLabel labelprovizyonTipi;
        protected ITTListDefComboBox tedaviTipi;
        protected ITTLabel labelbransKodu;
        protected ITTListDefComboBox sigortaliTuru;
        protected ITTListDefComboBox tedaviTuru;
        protected ITTLabel labelsigortaliTuru;
        protected ITTLabel labeltedaviTipi;
        protected ITTLabel labeltakipTipi;
        protected ITTLabel labeltedaviTuru;
        protected ITTValueListBox bransKodu;
        protected ITTListDefComboBox takipTipi;
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
        protected ITTTextBox provizyonTarihi;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelsaglikTesisKodu;
        override protected void InitializeControls()
        {
            tabControlHastaKabul = (ITTTabControl)AddControl(new Guid("be335288-e4bd-47ca-a67f-624b888d71e0"));
            tabpageProvizyon = (ITTTabPage)AddControl(new Guid("ecf178c6-de60-4e1c-96cc-17dbcf431b05"));
            groupboxProvizyon = (ITTGroupBox)AddControl(new Guid("ea9df30a-b9e0-478a-9586-952c9123b0f1"));
            labelprovizyonTarihi = (ITTLabel)AddControl(new Guid("241b265f-f0a0-472f-8ab3-ca23b840a614"));
            provizyonTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("b9acf6ab-ea1d-4403-8d18-a032e46190e1"));
            devredilenKurum = (ITTListDefComboBox)AddControl(new Guid("2304dda2-0d65-4309-8ab4-7c59a9c96aa2"));
            provizyonTipi = (ITTListDefComboBox)AddControl(new Guid("a64a8381-9d27-4014-9ef0-92457fdff83f"));
            labeldevredilenKurum = (ITTLabel)AddControl(new Guid("dde6dcd2-0d65-4b3c-b6ea-ea10e96959cb"));
            labelprovizyonTipi = (ITTLabel)AddControl(new Guid("fb84f022-42f1-4d01-ae7a-b47eaea34151"));
            tedaviTipi = (ITTListDefComboBox)AddControl(new Guid("4c0fcf36-2780-4ca4-a6e5-3136e2003e7c"));
            labelbransKodu = (ITTLabel)AddControl(new Guid("2a2eeb74-12f0-48b0-9f1b-954a781e7da9"));
            sigortaliTuru = (ITTListDefComboBox)AddControl(new Guid("74a1de22-59f1-4e32-9892-64c3f8fa0849"));
            tedaviTuru = (ITTListDefComboBox)AddControl(new Guid("e1964341-1ada-42a9-b5a2-01c0497335aa"));
            labelsigortaliTuru = (ITTLabel)AddControl(new Guid("8da35a6f-09fc-434d-8f81-45f56a078c2d"));
            labeltedaviTipi = (ITTLabel)AddControl(new Guid("e2523a19-b5f9-4998-a8be-7fa26c994a45"));
            labeltakipTipi = (ITTLabel)AddControl(new Guid("f5194d4f-3bbe-4faf-8d59-f69e467e06e3"));
            labeltedaviTuru = (ITTLabel)AddControl(new Guid("051a294a-2858-46d0-acd4-87636de3a6c3"));
            bransKodu = (ITTValueListBox)AddControl(new Guid("00798230-6cd2-409d-8457-b83a337ca58f"));
            takipTipi = (ITTListDefComboBox)AddControl(new Guid("811de31d-7bef-4b6e-b8e6-5ae55ffba7ed"));
            groupboxHastaBilgileri = (ITTGroupBox)AddControl(new Guid("0d995867-686d-45ae-95f9-4b686cda5387"));
            HastaDogumTarihi = (ITTDateTimePicker)AddControl(new Guid("c1e5ccf3-8d1c-4553-b41f-d09687b0ba19"));
            labelhastaTCKimlikNo = (ITTLabel)AddControl(new Guid("be25e9fc-45d9-4c98-87b5-461780968e85"));
            hastaTCKimlikNo = (ITTTextBox)AddControl(new Guid("4e1dfbf9-7cb6-4ee5-98ca-a61d440d44e7"));
            labelHastaAd = (ITTLabel)AddControl(new Guid("d27db45a-d8bb-4cdb-a4d0-4e7e50864fe6"));
            HastaCinsiyet = (ITTListDefComboBox)AddControl(new Guid("b445eca4-7671-4205-925d-93c1c708546e"));
            HastaAd = (ITTTextBox)AddControl(new Guid("1d73dfbf-efca-4085-97a3-518e39c9a81c"));
            HastaSigortaliTuru = (ITTListDefComboBox)AddControl(new Guid("3bdc9e40-7cbb-403b-ac43-93050e85d67c"));
            labelHastaSigortaliTuru = (ITTLabel)AddControl(new Guid("a3c2b455-b2a4-4009-9863-26093783ff67"));
            HastaSoyad = (ITTTextBox)AddControl(new Guid("a0c1f4f0-5e3e-4ede-8ccc-b91e72308791"));
            labelHastaCinsiyet = (ITTLabel)AddControl(new Guid("9f972c44-fe85-4a05-b6b1-530d61d69e84"));
            labelHastaSoyad = (ITTLabel)AddControl(new Guid("8077dcdd-cbef-4f83-875e-d7990701e60f"));
            labelHastaDogumTarihi = (ITTLabel)AddControl(new Guid("46f5ddfc-9e58-43d8-bc5d-006b9cb8cec2"));
            provizyonTarihi = (ITTTextBox)AddControl(new Guid("407212e7-4b95-4712-aaa8-cd359837d724"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("de5bcb47-ebb4-4fbd-933f-e37c40c05e05"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("b35677ab-6708-4751-81cc-3e119a79e2b1"));
            base.InitializeControls();
        }

        public BaseHastaKabulForm() : base("BASEHASTAKABUL", "BaseHastaKabulForm")
        {
        }

        protected BaseHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}