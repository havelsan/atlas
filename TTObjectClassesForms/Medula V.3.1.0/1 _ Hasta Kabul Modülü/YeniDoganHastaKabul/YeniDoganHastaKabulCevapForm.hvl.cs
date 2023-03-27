
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
    /// Yeni Doğan Hasta Kabul Cevap
    /// </summary>
    public partial class YeniDoganHastaKabulCevapForm : BaseHastaKabulCevapForm
    {
    /// <summary>
    /// Yeni Doğan Hasta Kabul
    /// </summary>
        protected TTObjectClasses.YeniDoganHastaKabul _YeniDoganHastaKabul
        {
            get { return (TTObjectClasses.YeniDoganHastaKabul)_ttObject; }
        }

        protected ITTGroupBox groupboxYeniDoganBilgisi;
        protected ITTDateTimePicker bebeginDogumTarihiDatetimepicker;
        protected ITTLabel labelbebeginDogumTarihi;
        protected ITTTextBox cocukSira;
        protected ITTLabel labelcocukSira;
        protected ITTTextBox bebeginDogumTarihi;
        override protected void InitializeControls()
        {
            groupboxYeniDoganBilgisi = (ITTGroupBox)AddControl(new Guid("02b49360-4358-4b91-a58a-b0160ba410bd"));
            bebeginDogumTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("e81da5a6-68d8-41f9-81ba-c3ccd8dcb4e8"));
            labelbebeginDogumTarihi = (ITTLabel)AddControl(new Guid("18d722f3-edfc-4d3c-9a94-e5e55c4c3b99"));
            cocukSira = (ITTTextBox)AddControl(new Guid("5dec229a-0e55-4562-acaf-ed5b578cb81e"));
            labelcocukSira = (ITTLabel)AddControl(new Guid("6d765e0f-2793-4181-a18e-c5250bb8d168"));
            bebeginDogumTarihi = (ITTTextBox)AddControl(new Guid("2e4a89de-8f6a-4abc-83c6-896cee0ff6dc"));
            base.InitializeControls();
        }

        public YeniDoganHastaKabulCevapForm() : base("YENIDOGANHASTAKABUL", "YeniDoganHastaKabulCevapForm")
        {
        }

        protected YeniDoganHastaKabulCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}