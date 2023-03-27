
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
    public partial class VeremVeriSetiForm : TTForm
    {
        protected TTObjectClasses.VeremVeriSeti _VeremVeriSeti
        {
            get { return (TTObjectClasses.VeremVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSYaymaSonucu;
        protected ITTObjectListBox SKRSYaymaSonucu;
        protected ITTLabel labelSKRSVeremOlguTanimi;
        protected ITTObjectListBox SKRSVeremOlguTanimi;
        protected ITTLabel labelSKRSVeremHastasiTedaviYontemi;
        protected ITTObjectListBox SKRSVeremHastasiTedaviYontemi;
        protected ITTLabel labelSKRSKulturSonucu;
        protected ITTObjectListBox SKRSKulturSonucu;
        protected ITTLabel labelSKRSHastaninTedaviyeUyumu;
        protected ITTObjectListBox SKRSHastaninTedaviyeUyumu;
        protected ITTLabel labelSKRSDGTUygulamasiniYapanKisi;
        protected ITTObjectListBox SKRSDGTUygulamasiniYapanKisi;
        protected ITTLabel labelSKRSDGTUygulamaYeri;
        protected ITTObjectListBox SKRSDGTUygulamaYeri;
        protected ITTGrid VeremTedaviSonucBilgisi;
        protected ITTListBoxColumn SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi;
        protected ITTGrid VeremKlinikOrnegi;
        protected ITTListBoxColumn SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi;
        protected ITTGrid VeremIlacBilgisi;
        protected ITTListBoxColumn SKRSIlacAdiVeremVeremIlacBilgisi;
        protected ITTListBoxColumn SKRSIlacDirenciVeremVeremIlacBilgisi;
        protected ITTGrid VeremHastalikTutumYeri;
        protected ITTListBoxColumn SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri;
        protected ITTLabel labelTuberkulinDeriTestiSonuc;
        protected ITTTextBox TuberkulinDeriTestiSonuc;
        protected ITTTextBox BcgSkarSayisi;
        protected ITTLabel labelBcgSkarSayisi;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        override protected void InitializeControls()
        {
            labelSKRSYaymaSonucu = (ITTLabel)AddControl(new Guid("3fa08d0f-db3b-4e23-a8a5-34adf287dc37"));
            SKRSYaymaSonucu = (ITTObjectListBox)AddControl(new Guid("837be236-ae02-4f70-857d-610d69af0b32"));
            labelSKRSVeremOlguTanimi = (ITTLabel)AddControl(new Guid("eb5b2485-e7fe-4572-8806-015a1284f6c1"));
            SKRSVeremOlguTanimi = (ITTObjectListBox)AddControl(new Guid("953a8118-b658-4be3-bcd8-9eaf53292521"));
            labelSKRSVeremHastasiTedaviYontemi = (ITTLabel)AddControl(new Guid("253e8468-a8b5-4aa3-8506-3371a7bb93e5"));
            SKRSVeremHastasiTedaviYontemi = (ITTObjectListBox)AddControl(new Guid("3417755e-8148-47b0-9e55-3dce8c00f973"));
            labelSKRSKulturSonucu = (ITTLabel)AddControl(new Guid("a9d11859-291f-407b-8498-f5c64db1f1ad"));
            SKRSKulturSonucu = (ITTObjectListBox)AddControl(new Guid("bebb646b-4b6d-41fe-bff1-cb5af240f4da"));
            labelSKRSHastaninTedaviyeUyumu = (ITTLabel)AddControl(new Guid("fb5e3e5e-5094-47d6-9341-3a11fcf783f3"));
            SKRSHastaninTedaviyeUyumu = (ITTObjectListBox)AddControl(new Guid("70193461-3cbc-4cd1-bc62-04c51c986dde"));
            labelSKRSDGTUygulamasiniYapanKisi = (ITTLabel)AddControl(new Guid("5a0f86d8-7738-434e-9e0c-475d35a58555"));
            SKRSDGTUygulamasiniYapanKisi = (ITTObjectListBox)AddControl(new Guid("f3243f77-5d34-46f9-a2ab-379f1ae5f346"));
            labelSKRSDGTUygulamaYeri = (ITTLabel)AddControl(new Guid("d15e3e0c-aba5-4d7e-92a4-dfbc2775ad83"));
            SKRSDGTUygulamaYeri = (ITTObjectListBox)AddControl(new Guid("26a2c222-af8a-4e97-887f-0b473df66c0b"));
            VeremTedaviSonucBilgisi = (ITTGrid)AddControl(new Guid("fb98d47b-5126-4d03-bd03-66d96e405ed7"));
            SKRSVeremTedaviSonucuVeremTedaviSonucBilgisi = (ITTListBoxColumn)AddControl(new Guid("1d5c2a85-d569-4a8f-b801-3fc11dbd747b"));
            VeremKlinikOrnegi = (ITTGrid)AddControl(new Guid("6e98e394-78df-4f11-90bf-04e22f6df75c"));
            SKRSVeremHastasiKlinikOrnegiVeremKlinikOrnegi = (ITTListBoxColumn)AddControl(new Guid("998df967-8169-4156-981a-356b471d4364"));
            VeremIlacBilgisi = (ITTGrid)AddControl(new Guid("97a58971-821f-4842-985b-d351923562d1"));
            SKRSIlacAdiVeremVeremIlacBilgisi = (ITTListBoxColumn)AddControl(new Guid("a9dc6a37-e886-46eb-b898-68c4a54b65d5"));
            SKRSIlacDirenciVeremVeremIlacBilgisi = (ITTListBoxColumn)AddControl(new Guid("0af249f2-e5a2-43bd-80ed-fdb8b8882635"));
            VeremHastalikTutumYeri = (ITTGrid)AddControl(new Guid("902257b1-c8b9-40d3-9fce-18111599bde3"));
            SKRSVeremHastaligiTutulumYeriVeremHastalikTutumYeri = (ITTListBoxColumn)AddControl(new Guid("e31365ea-7ab0-4393-bbc1-becc5d444bf6"));
            labelTuberkulinDeriTestiSonuc = (ITTLabel)AddControl(new Guid("c9d224e6-8d7d-43b3-b452-c53ff117f067"));
            TuberkulinDeriTestiSonuc = (ITTTextBox)AddControl(new Guid("068f6d38-4a8e-46ca-88f4-36f0a7ee6f35"));
            BcgSkarSayisi = (ITTTextBox)AddControl(new Guid("39e98c40-e9c4-49af-a40e-185ad2700e03"));
            labelBcgSkarSayisi = (ITTLabel)AddControl(new Guid("e2ba0efe-5be1-4ab3-9072-1e8be6a67ade"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("98033337-931b-48e8-8227-ca953316f230"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("64ed91bf-d53e-41c9-8af1-9ed3e0778341"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("cbdab824-f46d-4f8c-8e2b-118b20abf08b"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("c00157f2-bfea-4e5b-9cb1-c11a365fef9b"));
            base.InitializeControls();
        }

        public VeremVeriSetiForm() : base("VEREMVERISETI", "VeremVeriSetiForm")
        {
        }

        protected VeremVeriSetiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}