
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
    public partial class BaseRaporBilgisiKaydetCevapForm : BaseRaporBilgisiKaydetForm
    {
    /// <summary>
    /// Rapor Bilgisi Kaydet
    /// </summary>
        protected TTObjectClasses.BaseRaporBilgisiKaydet _BaseRaporBilgisiKaydet
        {
            get { return (TTObjectClasses.BaseRaporBilgisiKaydet)_ttObject; }
        }

        protected ITTButton buttonRaporCevapBilgileri;
        protected ITTLabel labelsonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucAciklamasiBaseMedulaRaporCevap;
        protected ITTTextBox raporTakipNoRaporCevapDVO;
        protected ITTLabel labelsonucAciklamasiBaseMedulaRaporCevap;
        protected ITTLabel labelraporTuruRaporCevapDVO;
        protected ITTListDefComboBox raporTuruRaporCevapDVO;
        protected ITTLabel labelraporTakipNoRaporCevapDVO;
        override protected void InitializeControls()
        {
            buttonRaporCevapBilgileri = (ITTButton)AddControl(new Guid("48248ec4-939e-4f76-bbef-b79b19d22ebf"));
            labelsonucKoduBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("335d6332-b215-4b37-8368-fa868d5291ae"));
            sonucKoduBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("9e697128-a03c-42c5-8f54-b0c709b9de5e"));
            sonucAciklamasiBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("f32716c7-3d92-417d-8bd2-9438d63ff748"));
            raporTakipNoRaporCevapDVO = (ITTTextBox)AddControl(new Guid("5385bfa0-77dc-494c-8ce1-754ce44fd909"));
            labelsonucAciklamasiBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("55eda8e9-d14c-45c6-88c3-c39ec64542a3"));
            labelraporTuruRaporCevapDVO = (ITTLabel)AddControl(new Guid("2ace49a0-b661-47cb-b66e-c1edd4d13e26"));
            raporTuruRaporCevapDVO = (ITTListDefComboBox)AddControl(new Guid("aad71bf8-b99b-4705-99e9-4f0a78229a68"));
            labelraporTakipNoRaporCevapDVO = (ITTLabel)AddControl(new Guid("88bc7f78-ef06-42cb-93ee-874c58ecd003"));
            base.InitializeControls();
        }

        public BaseRaporBilgisiKaydetCevapForm() : base("BASERAPORBILGISIKAYDET", "BaseRaporBilgisiKaydetCevapForm")
        {
        }

        protected BaseRaporBilgisiKaydetCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}