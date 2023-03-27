
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
    public partial class ActiveIngredientPrescriptionSUTRuleDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Etken Madde Reçete SUT Kuralları
    /// </summary>
        protected TTObjectClasses.ActiveIngredientPrescriptionSUTRuleDef _ActiveIngredientPrescriptionSUTRuleDef
        {
            get { return (TTObjectClasses.ActiveIngredientPrescriptionSUTRuleDef)_ttObject; }
        }

        protected ITTLabel labeletkinMaddeKoduEtkinMadde;
        protected ITTTextBox etkinMaddeKoduEtkinMadde;
        protected ITTTextBox Aciklamalar;
        protected ITTTextBox OzelTeshis;
        protected ITTTextBox ReceteEdebilenHekimler;
        protected ITTTextBox OdemeDurumu;
        protected ITTTextBox Formu;
        protected ITTLabel labelEtkinMadde;
        protected ITTObjectListBox EtkinMadde;
        protected ITTLabel labelAciklamalar;
        protected ITTLabel labelOzelTeshis;
        protected ITTLabel labelReceteEdebilenHekimler;
        protected ITTLabel labelOdemeDurumu;
        protected ITTLabel labelFormu;
        override protected void InitializeControls()
        {
            labeletkinMaddeKoduEtkinMadde = (ITTLabel)AddControl(new Guid("fe8aa9f2-c36b-4647-9f6b-78be8f0297e5"));
            etkinMaddeKoduEtkinMadde = (ITTTextBox)AddControl(new Guid("e829834e-e4d7-4a5c-a906-4732af03cd80"));
            Aciklamalar = (ITTTextBox)AddControl(new Guid("7aee1577-f73c-484e-ba29-e6d71d2cbc1b"));
            OzelTeshis = (ITTTextBox)AddControl(new Guid("cf3d5fa4-8f8e-435e-9110-6fa7d8252312"));
            ReceteEdebilenHekimler = (ITTTextBox)AddControl(new Guid("73cda67b-cd10-480a-b0b5-74565d3f08d9"));
            OdemeDurumu = (ITTTextBox)AddControl(new Guid("1f8e785a-2ae3-490f-a243-29c45818922d"));
            Formu = (ITTTextBox)AddControl(new Guid("0313c143-dae9-4175-a867-b33a6443b968"));
            labelEtkinMadde = (ITTLabel)AddControl(new Guid("77102bdc-22d3-48f0-a6a1-c9c606763b83"));
            EtkinMadde = (ITTObjectListBox)AddControl(new Guid("fa83a76e-7ddc-4d8e-a291-32fc2050a24d"));
            labelAciklamalar = (ITTLabel)AddControl(new Guid("4dd81268-406d-49d9-af84-141592fc9b1f"));
            labelOzelTeshis = (ITTLabel)AddControl(new Guid("6be48b3c-c436-4e36-ba2b-411b9e645f98"));
            labelReceteEdebilenHekimler = (ITTLabel)AddControl(new Guid("03f8928f-a0e9-46b6-a214-141365014b61"));
            labelOdemeDurumu = (ITTLabel)AddControl(new Guid("d2ed973c-66c4-41aa-960a-e6b3fa2ae0ee"));
            labelFormu = (ITTLabel)AddControl(new Guid("2100ec1d-0bbb-415a-904b-5cf814460d88"));
            base.InitializeControls();
        }

        public ActiveIngredientPrescriptionSUTRuleDefForm() : base("ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF", "ActiveIngredientPrescriptionSUTRuleDefForm")
        {
        }

        protected ActiveIngredientPrescriptionSUTRuleDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}