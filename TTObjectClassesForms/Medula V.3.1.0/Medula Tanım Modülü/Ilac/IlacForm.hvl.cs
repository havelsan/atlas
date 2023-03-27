
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
    public partial class IlacForm : TTForm
    {
    /// <summary>
    /// İlaç
    /// </summary>
        protected TTObjectClasses.Ilac _Ilac
        {
            get { return (TTObjectClasses.Ilac)_ttObject; }
        }

        protected ITTGrid ilacFiyatlari;
        protected ITTTextBoxColumn fiyatFiyat;
        protected ITTTextBoxColumn gecerlilikTarihiFiyat;
        protected ITTLabel labelkullanimBirimi;
        protected ITTTextBox kullanimBirimi;
        protected ITTTextBox ilacAdi;
        protected ITTTextBox barkod;
        protected ITTLabel labelilacAdi;
        protected ITTLabel labelbarkod;
        protected ITTLabel labelIlacFiyatlari;
        override protected void InitializeControls()
        {
            ilacFiyatlari = (ITTGrid)AddControl(new Guid("7d6355f1-b98f-4379-956e-a1f7f218f458"));
            fiyatFiyat = (ITTTextBoxColumn)AddControl(new Guid("4baf6826-6ad4-4b4b-9391-c67b60cf6aae"));
            gecerlilikTarihiFiyat = (ITTTextBoxColumn)AddControl(new Guid("5cbb5708-4dff-4516-983e-09d5f6f6b544"));
            labelkullanimBirimi = (ITTLabel)AddControl(new Guid("c3cf5fcb-e6fd-431f-9534-8a48291cb0af"));
            kullanimBirimi = (ITTTextBox)AddControl(new Guid("efbb4542-f03a-4940-99eb-5efd2b2c27e3"));
            ilacAdi = (ITTTextBox)AddControl(new Guid("843257ea-dc3b-4e05-9992-b7d76262ca89"));
            barkod = (ITTTextBox)AddControl(new Guid("7f306a4b-5b0b-4d89-aa67-e5dabdfee45c"));
            labelilacAdi = (ITTLabel)AddControl(new Guid("451c44f4-ff9f-431d-abcf-7ceec903f017"));
            labelbarkod = (ITTLabel)AddControl(new Guid("c5266edc-dd8c-466f-be82-d632f3fb93f2"));
            labelIlacFiyatlari = (ITTLabel)AddControl(new Guid("505c9d22-2959-4d9b-9958-9c21fc79814a"));
            base.InitializeControls();
        }

        public IlacForm() : base("ILAC", "IlacForm")
        {
        }

        protected IlacForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}