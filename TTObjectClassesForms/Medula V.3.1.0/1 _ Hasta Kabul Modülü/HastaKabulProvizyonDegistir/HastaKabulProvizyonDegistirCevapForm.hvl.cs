
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
    /// Hasta Kabul Provizyon Degiştir
    /// </summary>
    public partial class HastaKabulProvizyonDegistirCevapForm : BaseHastaKabulProvizyonDegistirForm
    {
    /// <summary>
    /// Hasta Kabul Provizyon Degiştir
    /// </summary>
        protected TTObjectClasses.HastaKabulProvizyonDegistir _HastaKabulProvizyonDegistir
        {
            get { return (TTObjectClasses.HastaKabulProvizyonDegistir)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labeltakipNoCevap;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTTextBox takipNoCevap;
        protected ITTLabel labelsonucKodu;
        protected ITTListDefComboBox yeniProvizyonTipiCevap;
        protected ITTLabel labelhastaBasvuruNoCevap;
        protected ITTTextBox hastaBasvuruNoCevap;
        protected ITTLabel labelyeniProvizyonTipiCevap;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("abfbd972-f139-46bf-81e8-a473432a770a"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("0dc26468-ef6f-4159-90e8-8d7e03034dd2"));
            labeltakipNoCevap = (ITTLabel)AddControl(new Guid("f3fb65f1-2d5a-4d33-b499-345deb7b68b7"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("d04deef1-e96b-4e8b-ae9e-7f8c9b7df29f"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("bba9848e-a999-463a-9f60-a33a1a7b5b5e"));
            takipNoCevap = (ITTTextBox)AddControl(new Guid("7e37e664-70fe-48c1-81df-dffb03d96da7"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("bdd7ea0d-ade7-47ee-90ed-03964a0a7549"));
            yeniProvizyonTipiCevap = (ITTListDefComboBox)AddControl(new Guid("f8c0350a-2a44-4b5d-a4cc-08768129ab44"));
            labelhastaBasvuruNoCevap = (ITTLabel)AddControl(new Guid("e9baf959-f13f-4e15-bef5-7d8e0b36719a"));
            hastaBasvuruNoCevap = (ITTTextBox)AddControl(new Guid("4dc1a0fd-29e2-4375-80cd-79d99c5d07a4"));
            labelyeniProvizyonTipiCevap = (ITTLabel)AddControl(new Guid("efbb061a-30f5-4c63-817d-c7a6d36705af"));
            base.InitializeControls();
        }

        public HastaKabulProvizyonDegistirCevapForm() : base("HASTAKABULPROVIZYONDEGISTIR", "HastaKabulProvizyonDegistirCevapForm")
        {
        }

        protected HastaKabulProvizyonDegistirCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}