
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
    public partial class IlacRaporDuzeltCevapForm : BaseIlacRaporDuzeltForm
    {
    /// <summary>
    /// Ilaç Raporu Düzelt
    /// </summary>
        protected TTObjectClasses.IlacRaporDuzelt _IlacRaporDuzelt
        {
            get { return (TTObjectClasses.IlacRaporDuzelt)_ttObject; }
        }

        protected ITTListDefComboBox raporTuruRaporCevapDVO;
        protected ITTLabel labelsonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucAciklamasiBaseMedulaRaporCevap;
        protected ITTTextBox raporTakipNoRaporCevapDVO;
        protected ITTLabel labelsonucAciklamasiBaseMedulaRaporCevap;
        protected ITTLabel labelraporTuruRaporCevapDVO;
        protected ITTButton buttonRaporCevapBilgileri;
        protected ITTLabel labelraporTakipNoRaporCevapDVO;
        override protected void InitializeControls()
        {
            raporTuruRaporCevapDVO = (ITTListDefComboBox)AddControl(new Guid("c9d780d5-4463-4ffd-90ed-eda0038f94fe"));
            labelsonucKoduBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("8d87b13a-8bfa-47d9-b0f0-8ce8e87c83cc"));
            sonucKoduBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("c0fdca6f-d847-4fbb-8f96-daa06246ce01"));
            sonucAciklamasiBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("b2fdf234-fc9a-4de5-8b8f-f9c2aaa40b4c"));
            raporTakipNoRaporCevapDVO = (ITTTextBox)AddControl(new Guid("f1c1d637-33c2-4991-a4dd-8816abd6a9be"));
            labelsonucAciklamasiBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("f920436e-33f4-42c2-9e24-d4ca454c1ee2"));
            labelraporTuruRaporCevapDVO = (ITTLabel)AddControl(new Guid("178de456-f790-4d8c-abf3-fafa274a9e01"));
            buttonRaporCevapBilgileri = (ITTButton)AddControl(new Guid("394f438c-d22d-48e3-9686-9a9e15cfcfb9"));
            labelraporTakipNoRaporCevapDVO = (ITTLabel)AddControl(new Guid("2d7bf1c2-6988-4b92-85bd-0751ecec5089"));
            base.InitializeControls();
        }

        public IlacRaporDuzeltCevapForm() : base("ILACRAPORDUZELT", "IlacRaporDuzeltCevapForm")
        {
        }

        protected IlacRaporDuzeltCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}