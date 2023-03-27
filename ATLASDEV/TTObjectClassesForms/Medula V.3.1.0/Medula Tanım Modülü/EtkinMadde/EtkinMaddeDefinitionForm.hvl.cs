
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
    public partial class EtkinMaddeDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.EtkinMadde _EtkinMadde
        {
            get { return (TTObjectClasses.EtkinMadde)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid TeshisEtkinMaddeGrid;
        protected ITTListBoxColumn TeshisTeshisEtkinMaddeGrid;
        protected ITTCheckBox hastaGvnlikveIzlemFrmGerek;
        protected ITTLabel labeletkinMaddeLatinceAdi;
        protected ITTTextBox etkinMaddeLatinceAdi;
        protected ITTTextBox icerikMiktari;
        protected ITTTextBox adetMiktar;
        protected ITTTextBox form;
        protected ITTTextBox etkinMaddeKodu;
        protected ITTTextBox etkinMaddeAdi;
        protected ITTLabel labelbitisTarihi;
        protected ITTDateTimePicker bitisTarihi;
        protected ITTLabel labelbaslangicTarihi;
        protected ITTDateTimePicker baslangicTarihi;
        protected ITTButton btnEtkinMaddeSutListesiSorgula;
        protected ITTRichTextBoxControl txtSUTList;
        protected ITTLabel labelSUTList;
        protected ITTLabel labelicerikMiktari;
        protected ITTLabel labeladetMiktar;
        protected ITTLabel labelform;
        protected ITTLabel labeletkinMaddeKodu;
        protected ITTLabel labeletkinMaddeAdi;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("a4bc4b70-4b52-4043-b486-e8e7989fa704"));
            TeshisEtkinMaddeGrid = (ITTGrid)AddControl(new Guid("4ee5547c-1af5-434a-9018-dd76d515b226"));
            TeshisTeshisEtkinMaddeGrid = (ITTListBoxColumn)AddControl(new Guid("dd210701-11e0-4691-bda9-a500a3c19707"));
            hastaGvnlikveIzlemFrmGerek = (ITTCheckBox)AddControl(new Guid("986ad916-94a9-4b9d-93ed-d1c908832d49"));
            labeletkinMaddeLatinceAdi = (ITTLabel)AddControl(new Guid("832f059b-e9d1-4801-88bd-3224925a712d"));
            etkinMaddeLatinceAdi = (ITTTextBox)AddControl(new Guid("a792f970-837d-43f5-90e7-a95a90a55448"));
            icerikMiktari = (ITTTextBox)AddControl(new Guid("debb9aba-e5eb-4d28-b788-1fced7beda1c"));
            adetMiktar = (ITTTextBox)AddControl(new Guid("2a4d9512-b228-4dea-878f-eccff93d717d"));
            form = (ITTTextBox)AddControl(new Guid("3a2faf55-da95-4777-96ad-10a735bc5c14"));
            etkinMaddeKodu = (ITTTextBox)AddControl(new Guid("1f8901e0-1a2d-4e29-842f-9e5467fe1f27"));
            etkinMaddeAdi = (ITTTextBox)AddControl(new Guid("85bd7599-624e-4356-be57-be6c1ab6cb4a"));
            labelbitisTarihi = (ITTLabel)AddControl(new Guid("1736c676-e343-4ddc-834d-92b22978f660"));
            bitisTarihi = (ITTDateTimePicker)AddControl(new Guid("631229a7-e945-454f-9f65-c6826938a279"));
            labelbaslangicTarihi = (ITTLabel)AddControl(new Guid("7328d661-0d45-4846-b312-9e13463c7f17"));
            baslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("addf006a-d313-429a-b7aa-826b0a96ec1a"));
            btnEtkinMaddeSutListesiSorgula = (ITTButton)AddControl(new Guid("55fa4faf-5356-454d-b4d5-bc38a03a1ccb"));
            txtSUTList = (ITTRichTextBoxControl)AddControl(new Guid("d047e066-e8ed-452b-8ba3-b6e5a91d6868"));
            labelSUTList = (ITTLabel)AddControl(new Guid("94f940ed-a5ce-485f-9ae1-d59434c9d870"));
            labelicerikMiktari = (ITTLabel)AddControl(new Guid("099b810e-351d-42e4-91d0-94ea1ddce815"));
            labeladetMiktar = (ITTLabel)AddControl(new Guid("c0960dc3-26eb-4e00-9abc-e31de68c004d"));
            labelform = (ITTLabel)AddControl(new Guid("77d94c2d-e6c2-4943-b001-45acd8050f01"));
            labeletkinMaddeKodu = (ITTLabel)AddControl(new Guid("8d4eb3dd-cf71-40ab-b096-2b1125c469e9"));
            labeletkinMaddeAdi = (ITTLabel)AddControl(new Guid("2b97f66c-bf5f-46f7-90b8-c002fe312e42"));
            base.InitializeControls();
        }

        public EtkinMaddeDefinitionForm() : base("ETKINMADDE", "EtkinMaddeDefinitionForm")
        {
        }

        protected EtkinMaddeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}