
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
    public partial class EvdeSaglikIzlemForm : TTForm
    {
    /// <summary>
    /// Evde Sağlık İzlem Veri Seti
    /// </summary>
        protected TTObjectClasses.EvdeSaglikIzlemVeriSeti _EvdeSaglikIzlemVeriSeti
        {
            get { return (TTObjectClasses.EvdeSaglikIzlemVeriSeti)_ttObject; }
        }

        protected ITTGrid BirSonrakiHizmetIhtiyaci;
        protected ITTListBoxColumn SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci;
        protected ITTGrid VerilenEgitimler;
        protected ITTListBoxColumn SKRSVerilenEgitimlerVerilenEgitimler;
        protected ITTGrid PsikolojikDurum;
        protected ITTListBoxColumn SKRSPsikolojikDurumPsikolojikDurum;
        protected ITTLabel labelSKRSIl;
        protected ITTObjectListBox SKRSIl;
        protected ITTLabel labelSKRSHastaNakli;
        protected ITTObjectListBox SKRSHastaNakli;
        protected ITTLabel labelSKRSHizmetinSonlandirilmasi;
        protected ITTObjectListBox SKRSHizmetinSonlandirilmasi;
        protected ITTLabel labelSKRSBeslenme;
        protected ITTObjectListBox SKRSBeslenme;
        protected ITTLabel labelSKRSBasiDegerlendirmesi;
        protected ITTObjectListBox SKRSBasiDegerlendirmesi;
        protected ITTLabel labelSKRSAgri;
        protected ITTObjectListBox SKRSAgri;
        override protected void InitializeControls()
        {
            BirSonrakiHizmetIhtiyaci = (ITTGrid)AddControl(new Guid("4ea47ca1-8e3a-4389-a94c-46630cd32e50"));
            SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci = (ITTListBoxColumn)AddControl(new Guid("3875bc15-24ae-4944-8da3-3ef46600ddb9"));
            VerilenEgitimler = (ITTGrid)AddControl(new Guid("5f5b630f-a51c-4f9f-b857-8863b2a8f0ae"));
            SKRSVerilenEgitimlerVerilenEgitimler = (ITTListBoxColumn)AddControl(new Guid("d65c71a1-d5bd-484b-9fb4-ff7dac242e7b"));
            PsikolojikDurum = (ITTGrid)AddControl(new Guid("20988fc3-bd56-4410-9969-805b2f16b964"));
            SKRSPsikolojikDurumPsikolojikDurum = (ITTListBoxColumn)AddControl(new Guid("8089bfbf-ec0b-4dcc-ad39-ac5a0f4119a9"));
            labelSKRSIl = (ITTLabel)AddControl(new Guid("07675036-03df-4cf1-8fb0-1c77f72ff7c7"));
            SKRSIl = (ITTObjectListBox)AddControl(new Guid("3b27cdb2-6335-4af2-bb9a-9de86322fac7"));
            labelSKRSHastaNakli = (ITTLabel)AddControl(new Guid("efa70250-8937-47ab-bdcc-7e21e38bc5db"));
            SKRSHastaNakli = (ITTObjectListBox)AddControl(new Guid("f6da7692-be27-4521-a609-509ac30e37f1"));
            labelSKRSHizmetinSonlandirilmasi = (ITTLabel)AddControl(new Guid("bbf975b7-9261-4740-9794-3b64e4d36e7c"));
            SKRSHizmetinSonlandirilmasi = (ITTObjectListBox)AddControl(new Guid("f78f408b-c9e6-4cd9-b5d0-ffda0dfc7ca5"));
            labelSKRSBeslenme = (ITTLabel)AddControl(new Guid("c1d260fa-a0c9-4f53-af90-ab6e75c79a80"));
            SKRSBeslenme = (ITTObjectListBox)AddControl(new Guid("4755934c-32d6-4dc8-8650-9358e35ceb32"));
            labelSKRSBasiDegerlendirmesi = (ITTLabel)AddControl(new Guid("995d3d09-560f-41c0-9d29-41fe1573fe17"));
            SKRSBasiDegerlendirmesi = (ITTObjectListBox)AddControl(new Guid("ca2d96a9-1f37-48fa-abd3-2eaa8bf49183"));
            labelSKRSAgri = (ITTLabel)AddControl(new Guid("e426dae9-06c1-4638-948a-7107b139b522"));
            SKRSAgri = (ITTObjectListBox)AddControl(new Guid("4eb0a659-a770-4580-974a-7e38e7d58491"));
            base.InitializeControls();
        }

        public EvdeSaglikIzlemForm() : base("EVDESAGLIKIZLEMVERISETI", "EvdeSaglikIzlemForm")
        {
        }

        protected EvdeSaglikIzlemForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}