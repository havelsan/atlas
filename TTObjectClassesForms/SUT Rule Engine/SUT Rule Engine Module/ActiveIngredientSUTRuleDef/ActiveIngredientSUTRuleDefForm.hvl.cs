
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
    public partial class ActiveIngredientSUTRuleDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Etken Madde SUT Kuralları
    /// </summary>
        protected TTObjectClasses.ActiveIngredientSUTRuleDef _ActiveIngredientSUTRuleDef
        {
            get { return (TTObjectClasses.ActiveIngredientSUTRuleDef)_ttObject; }
        }

        protected ITTLabel labelEtkinMadde;
        protected ITTObjectListBox EtkinMadde;
        protected ITTLabel labelMaksimumYasi;
        protected ITTTextBox MaksimumYasi;
        protected ITTTextBox MinimumYasi;
        protected ITTTextBox Cinsiyeti;
        protected ITTTextBox MaksimumRaporSuresi;
        protected ITTTextBox Brans;
        protected ITTTextBox Uzman_Heyet;
        protected ITTTextBox Rapor_ICD10Kodu;
        protected ITTTextBox Formu;
        protected ITTTextBox Icerik;
        protected ITTTextBox OzelAciklama;
        protected ITTLabel labelMinimumYasi;
        protected ITTLabel labelCinsiyeti;
        protected ITTLabel labelMaksimumRaporSuresi;
        protected ITTLabel labelBrans;
        protected ITTLabel labelUzman_Heyet;
        protected ITTLabel labelRapor_ICD10Kodu;
        protected ITTLabel labelFormu;
        protected ITTLabel labelIcerik;
        protected ITTLabel labelOzelAciklama;
        override protected void InitializeControls()
        {
            labelEtkinMadde = (ITTLabel)AddControl(new Guid("932f4a85-8a94-4f2d-a9f3-4cd29a71e876"));
            EtkinMadde = (ITTObjectListBox)AddControl(new Guid("98869cbe-0a3d-4d4f-8636-2c434ee6025f"));
            labelMaksimumYasi = (ITTLabel)AddControl(new Guid("de503ec1-3fa5-443e-ad00-5766d9bdb22e"));
            MaksimumYasi = (ITTTextBox)AddControl(new Guid("8f914d93-ae31-4900-a087-af26ad7b01c4"));
            MinimumYasi = (ITTTextBox)AddControl(new Guid("8c0c37a0-488e-42a8-8cf2-85654826a108"));
            Cinsiyeti = (ITTTextBox)AddControl(new Guid("10b22274-eff7-4e70-bf60-12c988ccdc68"));
            MaksimumRaporSuresi = (ITTTextBox)AddControl(new Guid("0743633d-fa42-4076-9c19-9df953eca84f"));
            Brans = (ITTTextBox)AddControl(new Guid("86ef83b2-c556-4bbe-9dd8-935da0744c37"));
            Uzman_Heyet = (ITTTextBox)AddControl(new Guid("53ccbfbd-c7c0-4ef4-9bea-d6872c4f2c0a"));
            Rapor_ICD10Kodu = (ITTTextBox)AddControl(new Guid("df09a9ce-149c-4947-8aec-83f86a20c238"));
            Formu = (ITTTextBox)AddControl(new Guid("26746d44-8b60-428e-91b2-36dddc3a2d08"));
            Icerik = (ITTTextBox)AddControl(new Guid("fabc7045-928c-4d24-bbfc-a22a0543916d"));
            OzelAciklama = (ITTTextBox)AddControl(new Guid("d06456f9-5faa-4279-a11b-678ad292051d"));
            labelMinimumYasi = (ITTLabel)AddControl(new Guid("6118752b-f02b-46be-976f-0e47ef251ded"));
            labelCinsiyeti = (ITTLabel)AddControl(new Guid("4dd0b6d2-4838-4e02-86c5-e2603cd2b27f"));
            labelMaksimumRaporSuresi = (ITTLabel)AddControl(new Guid("5a6ce277-7984-4d98-8c28-b096f9d8ca5a"));
            labelBrans = (ITTLabel)AddControl(new Guid("1c57e9d6-97ab-4bd9-a41b-ebe517caaaac"));
            labelUzman_Heyet = (ITTLabel)AddControl(new Guid("17212411-5749-4a44-8339-a36220de3600"));
            labelRapor_ICD10Kodu = (ITTLabel)AddControl(new Guid("c26dcc4e-d99e-4627-be3a-f7c9cbb82f73"));
            labelFormu = (ITTLabel)AddControl(new Guid("8f825317-6b9b-47cd-9cbf-23a355ded79b"));
            labelIcerik = (ITTLabel)AddControl(new Guid("99df96d7-f612-4b8e-9830-37cbce03e032"));
            labelOzelAciklama = (ITTLabel)AddControl(new Guid("270bf315-b51f-463f-a272-acf3a6ca9eea"));
            base.InitializeControls();
        }

        public ActiveIngredientSUTRuleDefForm() : base("ACTIVEINGREDIENTSUTRULEDEF", "ActiveIngredientSUTRuleDefForm")
        {
        }

        protected ActiveIngredientSUTRuleDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}