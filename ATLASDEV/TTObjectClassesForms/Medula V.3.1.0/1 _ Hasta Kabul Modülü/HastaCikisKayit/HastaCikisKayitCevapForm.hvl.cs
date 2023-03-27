
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
    /// Hasta Çıkış Kayıt Cevap
    /// </summary>
    public partial class HastaCikisKayitCevapForm : BaseHastaCikisKayitForm
    {
    /// <summary>
    /// Hasta Çıkış Kayıt
    /// </summary>
        protected TTObjectClasses.HastaCikisKayit _HastaCikisKayit
        {
            get { return (TTObjectClasses.HastaCikisKayit)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labelyatisBitisTarihi;
        protected ITTTextBox yatisBitisTarihi;
        protected ITTLabel labelyatisBaslangicTarihi;
        protected ITTTextBox yatisBaslangicTarihi;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("d8d2d5e5-70d8-4101-8301-07ca63efa17a"));
            labelyatisBitisTarihi = (ITTLabel)AddControl(new Guid("e5d46261-477d-433e-9995-ff4601f41f64"));
            yatisBitisTarihi = (ITTTextBox)AddControl(new Guid("dd892e0a-29cd-49d4-ac4a-1ab4346d7dfd"));
            labelyatisBaslangicTarihi = (ITTLabel)AddControl(new Guid("5440f14e-75aa-4dca-b098-5d700b61e59e"));
            yatisBaslangicTarihi = (ITTTextBox)AddControl(new Guid("ab5423c8-5499-468b-ac2d-3fb6b9456c9d"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("d8cb1274-9838-4288-9975-20753baafcc5"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("192e347a-cd0a-4346-aa2c-0dc0d14595f9"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("f6fbfd5b-daac-46d4-b88a-a9cd74c5f200"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("e83938b5-126b-4dd4-9c7d-656c6511a24c"));
            base.InitializeControls();
        }

        public HastaCikisKayitCevapForm() : base("HASTACIKISKAYIT", "HastaCikisKayitCevapForm")
        {
        }

        protected HastaCikisKayitCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}