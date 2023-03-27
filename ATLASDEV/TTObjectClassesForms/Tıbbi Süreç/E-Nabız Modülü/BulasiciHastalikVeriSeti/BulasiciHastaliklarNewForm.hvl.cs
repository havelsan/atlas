
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
    public partial class BulasiciHastaliklarNewForm : TTForm
    {
        protected TTObjectClasses.BulasiciHastalikVeriSeti _BulasiciHastalikVeriSeti
        {
            get { return (TTObjectClasses.BulasiciHastalikVeriSeti)_ttObject; }
        }

        protected ITTLabel labelVakaDurum;
        protected ITTEnumComboBox VakaDurum;
        protected ITTGrid BulasiciHastalikTelefon;
        protected ITTListBoxColumn SKRSTelefonTipiBulasiciHastalikTelefon;
        protected ITTTextBoxColumn TelefonNumarasiBulasiciHastalikTelefon;
        protected ITTLabel labelBeyan_CSBM;
        protected ITTObjectListBox Beyan_CSBM;
        protected ITTLabel labelIkamet_CSBM;
        protected ITTObjectListBox Ikamet_CSBM;
        protected ITTLabel labelBeyan_Mahalle;
        protected ITTObjectListBox Beyan_Mahalle;
        protected ITTLabel labelIkamet_Mahalle;
        protected ITTObjectListBox Ikamet_Mahalle;
        protected ITTLabel labelBeyan_Koy;
        protected ITTObjectListBox Beyan_Koy;
        protected ITTLabel labelIkamet_Koy;
        protected ITTObjectListBox Ikamet_Koy;
        protected ITTLabel labelBeyan_Bucak;
        protected ITTObjectListBox Beyan_Bucak;
        protected ITTLabel labelIkamet_Bucak;
        protected ITTObjectListBox Ikamet_Bucak;
        protected ITTLabel labelResponsibleDoctor;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTLabel labelSKRSICD;
        protected ITTObjectListBox SKRSICD;
        protected ITTLabel labelSKRSVakaTipi;
        protected ITTObjectListBox SKRSVakaTipi;
        protected ITTLabel labelBeyan_Ilce;
        protected ITTObjectListBox Beyan_Ilce;
        protected ITTLabel labelIkamet_Ilce;
        protected ITTObjectListBox Ikamet_Ilce;
        protected ITTLabel labelBeyan_Il;
        protected ITTObjectListBox Beyan_Il;
        protected ITTLabel labelIkamet_Il;
        protected ITTObjectListBox Ikamet_Il;
        protected ITTLabel labelIcKapiNoBeyan;
        protected ITTTextBox IcKapiNoBeyan;
        protected ITTTextBox DisKapiNoBeyan;
        protected ITTTextBox IcKapiNoIkamet;
        protected ITTTextBox DisKapiNoIkamet;
        protected ITTLabel labelDisKapiNoBeyan;
        protected ITTLabel labelIcKapiNoIkamet;
        protected ITTLabel labelDisKapiNoIkamet;
        protected ITTLabel labelPaketeAitIslemZamani;
        protected ITTDateTimePicker PaketeAitIslemZamani;
        protected ITTLabel labelBelirtilerinBaslamaTarihi;
        protected ITTDateTimePicker BelirtilerinBaslamaTarihi;
        override protected void InitializeControls()
        {
            labelVakaDurum = (ITTLabel)AddControl(new Guid("cf756c1d-2044-4b5a-a4c7-acf134450aca"));
            VakaDurum = (ITTEnumComboBox)AddControl(new Guid("b74b4920-f8f5-4a9b-a924-51a71cd6b9bf"));
            BulasiciHastalikTelefon = (ITTGrid)AddControl(new Guid("702df0cb-ad2f-406e-a506-d7c76287166c"));
            SKRSTelefonTipiBulasiciHastalikTelefon = (ITTListBoxColumn)AddControl(new Guid("71ddf3b1-fabf-43e6-bb47-a5d84a9fa064"));
            TelefonNumarasiBulasiciHastalikTelefon = (ITTTextBoxColumn)AddControl(new Guid("fe902bea-a089-44ea-8f35-fcc2359dff1d"));
            labelBeyan_CSBM = (ITTLabel)AddControl(new Guid("6a1ba64a-fd8b-4531-b64d-9710ac274310"));
            Beyan_CSBM = (ITTObjectListBox)AddControl(new Guid("28220fa5-8420-44d9-ba7a-83a37690e6e6"));
            labelIkamet_CSBM = (ITTLabel)AddControl(new Guid("5f5bf3ec-0d29-414f-8f08-51256c61df77"));
            Ikamet_CSBM = (ITTObjectListBox)AddControl(new Guid("f3dfab32-1ba6-4151-b07c-7bedab611583"));
            labelBeyan_Mahalle = (ITTLabel)AddControl(new Guid("f4281e74-4dbb-4729-8fc3-573d5658c53a"));
            Beyan_Mahalle = (ITTObjectListBox)AddControl(new Guid("f9644bee-d271-4a60-a6af-2f555199a5ce"));
            labelIkamet_Mahalle = (ITTLabel)AddControl(new Guid("879f1848-0a6c-4b05-9d0d-b19812c590d8"));
            Ikamet_Mahalle = (ITTObjectListBox)AddControl(new Guid("7e67b219-a50c-4656-807f-60ecea54515a"));
            labelBeyan_Koy = (ITTLabel)AddControl(new Guid("4273458b-bfae-4165-a742-83bdaffeeff9"));
            Beyan_Koy = (ITTObjectListBox)AddControl(new Guid("ad0c7c5b-a5b7-4770-ac48-829f8336ccd9"));
            labelIkamet_Koy = (ITTLabel)AddControl(new Guid("a9d2499d-68d0-4632-9d7c-9fce05c86f69"));
            Ikamet_Koy = (ITTObjectListBox)AddControl(new Guid("9357d8a5-56c2-423e-95af-c0f7c6923dca"));
            labelBeyan_Bucak = (ITTLabel)AddControl(new Guid("c4aeace9-8c3a-460f-946c-c1484db0a92c"));
            Beyan_Bucak = (ITTObjectListBox)AddControl(new Guid("d9d1a4f7-f121-4b42-8e1c-f3187a253f81"));
            labelIkamet_Bucak = (ITTLabel)AddControl(new Guid("cd5a9165-f8ac-4e6a-9802-1a57dffdbeb8"));
            Ikamet_Bucak = (ITTObjectListBox)AddControl(new Guid("6abe3eb2-8975-433c-a17d-d3d5812299d5"));
            labelResponsibleDoctor = (ITTLabel)AddControl(new Guid("18c1086c-ea7d-4c78-a2a2-2dbb3f5f4022"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("89822193-532a-458a-b596-78dff34f2f07"));
            labelSKRSICD = (ITTLabel)AddControl(new Guid("29aaa75d-d7d1-4f55-a231-f3848e2b5cab"));
            SKRSICD = (ITTObjectListBox)AddControl(new Guid("2a9f846f-7c3b-4ef5-afe4-f41a63c40850"));
            labelSKRSVakaTipi = (ITTLabel)AddControl(new Guid("b5ae2305-089e-4baf-a207-e0cec2ae3988"));
            SKRSVakaTipi = (ITTObjectListBox)AddControl(new Guid("3a663871-9711-47b3-bf2a-6e606fc853c8"));
            labelBeyan_Ilce = (ITTLabel)AddControl(new Guid("3cd91e80-cd11-49e9-aa8a-43ce1f752c76"));
            Beyan_Ilce = (ITTObjectListBox)AddControl(new Guid("408ec784-3a12-490a-a6dc-3b400f6c8ae4"));
            labelIkamet_Ilce = (ITTLabel)AddControl(new Guid("c2504e9e-ea7d-4581-842f-6ad827b3b132"));
            Ikamet_Ilce = (ITTObjectListBox)AddControl(new Guid("bc3a24a1-b895-49bc-865f-095d1391f552"));
            labelBeyan_Il = (ITTLabel)AddControl(new Guid("4b752d47-0dc6-4513-a65c-4d2de537f2a0"));
            Beyan_Il = (ITTObjectListBox)AddControl(new Guid("fbc1962e-ffb4-4953-afca-e53300ad8374"));
            labelIkamet_Il = (ITTLabel)AddControl(new Guid("1ba524f5-f3dc-4439-af7a-6145169e348d"));
            Ikamet_Il = (ITTObjectListBox)AddControl(new Guid("0780eacf-4e33-47c3-a8a1-ba9bb3e5ffbe"));
            labelIcKapiNoBeyan = (ITTLabel)AddControl(new Guid("20ab1139-81ef-4f8e-88e3-a2983481a512"));
            IcKapiNoBeyan = (ITTTextBox)AddControl(new Guid("1831f07f-9b9c-44e3-a22f-859933250dc1"));
            DisKapiNoBeyan = (ITTTextBox)AddControl(new Guid("a1ac68ad-1ae8-4f88-9061-fc82f4d7cc6f"));
            IcKapiNoIkamet = (ITTTextBox)AddControl(new Guid("e321a19d-b26c-405a-b328-b4799694db72"));
            DisKapiNoIkamet = (ITTTextBox)AddControl(new Guid("a92c6df4-7470-4597-a300-be4dbade385c"));
            labelDisKapiNoBeyan = (ITTLabel)AddControl(new Guid("2dd28a6f-f4a9-4ae3-b7e5-2ccbe4dce0e1"));
            labelIcKapiNoIkamet = (ITTLabel)AddControl(new Guid("ec028c4e-0487-4988-acf7-b924ccd4214a"));
            labelDisKapiNoIkamet = (ITTLabel)AddControl(new Guid("6508733e-8789-41e3-a5f1-6269b0860177"));
            labelPaketeAitIslemZamani = (ITTLabel)AddControl(new Guid("c8776b59-48c6-4314-98d4-42aacbddeaac"));
            PaketeAitIslemZamani = (ITTDateTimePicker)AddControl(new Guid("eafaef5a-9e10-4fd6-8f5b-3f34d53dbfd7"));
            labelBelirtilerinBaslamaTarihi = (ITTLabel)AddControl(new Guid("551bc4ea-90e0-42a5-a22f-424dc0f35233"));
            BelirtilerinBaslamaTarihi = (ITTDateTimePicker)AddControl(new Guid("7c59a337-47ee-425a-a3c0-2dcdd494c5df"));
            base.InitializeControls();
        }

        public BulasiciHastaliklarNewForm() : base("BULASICIHASTALIKVERISETI", "BulasiciHastaliklarNewForm")
        {
        }

        protected BulasiciHastaliklarNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}