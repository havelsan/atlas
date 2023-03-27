
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
    /// Basvuru Takip Oku Cevap
    /// </summary>
    public partial class BasvuruTakipOkuCevapForm : BaseBasvuruTakipOkuForm
    {
    /// <summary>
    /// Başvuru Takip Oku
    /// </summary>
        protected TTObjectClasses.BasvuruTakipOku _BasvuruTakipOku
        {
            get { return (TTObjectClasses.BasvuruTakipOku)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        protected ITTGrid basvuruTakip;
        protected ITTTextBoxColumn takipNo;
        protected ITTTextBoxColumn takipFaturaDurumu;
        protected ITTLabel labelhastaBasvuruNoCevap;
        protected ITTTextBox hastaBasvuruNoCevap;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("b0880b02-2638-447e-8343-bd5beb1f83c2"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("1676477e-60c9-4d0a-a34a-7e25d9e6e391"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("cb2bc602-3276-4536-9694-851fa2a4070c"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("3f8d01ac-be59-4f7e-a0a4-ddebbe6de03c"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("39e2f62a-3b4d-4e14-85ae-0b34ada4e446"));
            basvuruTakip = (ITTGrid)AddControl(new Guid("8dbf59d2-6437-4dc1-a1ea-b7208f64cd03"));
            takipNo = (ITTTextBoxColumn)AddControl(new Guid("63ef71f1-1690-4ac3-b77c-9655ac8cb318"));
            takipFaturaDurumu = (ITTTextBoxColumn)AddControl(new Guid("e3fbd4f9-33c4-4797-ab99-45d630c3f8e3"));
            labelhastaBasvuruNoCevap = (ITTLabel)AddControl(new Guid("88a15e01-2b68-4c6b-b2b0-1c13affae8b7"));
            hastaBasvuruNoCevap = (ITTTextBox)AddControl(new Guid("b431392f-63dd-48dc-9582-6414555d4b18"));
            base.InitializeControls();
        }

        public BasvuruTakipOkuCevapForm() : base("BASVURUTAKIPOKU", "BasvuruTakipOkuCevapForm")
        {
        }

        protected BasvuruTakipOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}