
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
    /// Hizmet Kayıt Cevap
    /// </summary>
    public partial class HizmetKayitCevapForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hizmet Kayıt
    /// </summary>
        protected TTObjectClasses.HizmetKayit _HizmetKayit
        {
            get { return (TTObjectClasses.HizmetKayit)_ttObject; }
        }

        protected ITTValueListBox saglikTesisKoduHizmetKayitGirisDVO;
        protected ITTLabel labelsaglikTesisKoduHizmetKayitGirisDVO;
        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage islemBilgileriTabpage;
        protected ITTGrid islemBilgileriKayitliIslemBilgisiDVO;
        protected ITTTextBoxColumn islemSiraNoKayitliIslemBilgisiDVO;
        protected ITTTextBoxColumn hizmetSunucuRefNoKayitliIslemBilgisiDVO;
        protected ITTDateTimePickerColumn CreationDateKayitliIslemBilgisiDVO;
        protected ITTTabPage hataliKayitlarTabpage;
        protected ITTGrid hataliKayitlarHataliIslemBilgisiDVO;
        protected ITTTextBoxColumn hataKoduHataliIslemBilgisiDVO;
        protected ITTTextBoxColumn hataMesajiHataliIslemBilgisiDVO;
        protected ITTTextBoxColumn islemAdedi;
        protected ITTTextBoxColumn islemTarihi;
        protected ITTTextBoxColumn saglikTesisKodu;
        protected ITTTextBoxColumn tesisAdi;
        protected ITTTextBoxColumn hizmetSunucuRefNoHataliIslemBilgisiDVO;
        protected ITTDateTimePickerColumn CreationDateHataliIslemBilgisiDVO;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labeltakipNoCevap;
        protected ITTLabel labelhastaBasvuruNoHizmetKayitGirisDVO;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox hastaBasvuruNoHizmetKayitGirisDVO;
        protected ITTTextBox sonucKodu;
        protected ITTTextBox takipNoCevap;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            saglikTesisKoduHizmetKayitGirisDVO = (ITTValueListBox)AddControl(new Guid("b14673a3-6749-4a59-86a0-cfa9459ec5ad"));
            labelsaglikTesisKoduHizmetKayitGirisDVO = (ITTLabel)AddControl(new Guid("bed418af-28a7-4dbd-aaaf-48813d056a42"));
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("f73df25f-0dfa-42f9-abff-7c95bcbdab86"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("cf59a558-0b78-4801-a5df-9057762d9b61"));
            islemBilgileriTabpage = (ITTTabPage)AddControl(new Guid("4202f7a7-b2fd-4093-aa55-3be22f7947ef"));
            islemBilgileriKayitliIslemBilgisiDVO = (ITTGrid)AddControl(new Guid("f6bbc2a8-91d6-4e65-8c9d-8385dc28e538"));
            islemSiraNoKayitliIslemBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("3c33c8e2-36d2-473b-b7c2-ae3fb9e22df2"));
            hizmetSunucuRefNoKayitliIslemBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("660f4091-73bf-41e1-98db-fb3bf40742c2"));
            CreationDateKayitliIslemBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("e11ac004-d27f-449d-8f2a-f4c4172d5f9a"));
            hataliKayitlarTabpage = (ITTTabPage)AddControl(new Guid("e0c86e50-c38e-4abc-8a41-39ee43f7ccf1"));
            hataliKayitlarHataliIslemBilgisiDVO = (ITTGrid)AddControl(new Guid("2f55ba85-47f4-41a6-9c77-c448f6ee707f"));
            hataKoduHataliIslemBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("1988a880-cbc3-456f-bd49-629433c6b219"));
            hataMesajiHataliIslemBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("60004141-498e-42e5-8fb2-0e8544ab2f5a"));
            islemAdedi = (ITTTextBoxColumn)AddControl(new Guid("2c42dd56-5094-483c-8540-d1d51ff0c95c"));
            islemTarihi = (ITTTextBoxColumn)AddControl(new Guid("bf94c12d-f324-41ae-a7bc-2c7e120123ba"));
            saglikTesisKodu = (ITTTextBoxColumn)AddControl(new Guid("b3a65f4a-2a86-42d3-8658-eba296c1d708"));
            tesisAdi = (ITTTextBoxColumn)AddControl(new Guid("38a7d6cb-affd-40e6-b655-fa399906bd26"));
            hizmetSunucuRefNoHataliIslemBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("460ee477-969b-405c-a6d9-4c76adadf904"));
            CreationDateHataliIslemBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("07ee3dd9-759e-4e75-98c7-b3cc3bdad9b7"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("9ce1aa68-e5d9-4b59-b55c-411e9c287e5f"));
            labeltakipNoCevap = (ITTLabel)AddControl(new Guid("70c28d5e-a46f-4f37-a5eb-76196e43f68e"));
            labelhastaBasvuruNoHizmetKayitGirisDVO = (ITTLabel)AddControl(new Guid("94b2cf40-d879-43c1-aea9-8b52d877e19d"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("498d8d7c-d3ad-4537-902c-1cc4ff7b25c2"));
            hastaBasvuruNoHizmetKayitGirisDVO = (ITTTextBox)AddControl(new Guid("93d1914f-7010-489f-85b6-523ec64fdd0d"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("c35308f1-8fc1-49de-9da9-91df269b31ce"));
            takipNoCevap = (ITTTextBox)AddControl(new Guid("5fc1a120-6d2c-4237-b552-c33f6747e17b"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("94aa1232-2bf0-408b-9fda-0344fa1e9538"));
            base.InitializeControls();
        }

        public HizmetKayitCevapForm() : base("HIZMETKAYIT", "HizmetKayitCevapForm")
        {
        }

        protected HizmetKayitCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}