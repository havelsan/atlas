
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
    /// İlaç Tanımlama
    /// </summary>
    public partial class IlacDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// İlaç
    /// </summary>
        protected TTObjectClasses.Ilac _Ilac
        {
            get { return (TTObjectClasses.Ilac)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTGrid ilacFiyatlari;
        protected ITTTextBoxColumn fiyatFiyat;
        protected ITTTextBoxColumn gecerlilikTarihiFiyat;
        protected ITTDateTimePickerColumn ValidityDate;
        protected ITTLabel labelkullanimBirimi;
        protected ITTTextBox kullanimBirimi;
        protected ITTTextBox ilacAdi;
        protected ITTTextBox barkod;
        protected ITTLabel labelilacAdi;
        protected ITTLabel labelbarkod;
        protected ITTCheckBox isActive;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("2bfb627d-0c71-4423-a34b-c1e99e6a896d"));
            ilacFiyatlari = (ITTGrid)AddControl(new Guid("d6d4434a-383b-44d0-9b07-6d0a23368fc2"));
            fiyatFiyat = (ITTTextBoxColumn)AddControl(new Guid("9fb7c148-3f5b-43fd-a260-6d56ef6ff4db"));
            gecerlilikTarihiFiyat = (ITTTextBoxColumn)AddControl(new Guid("a448a7b0-2434-4cad-972b-fba54990a40d"));
            ValidityDate = (ITTDateTimePickerColumn)AddControl(new Guid("ef75505a-7e4f-45e4-af87-06e39a66fb17"));
            labelkullanimBirimi = (ITTLabel)AddControl(new Guid("d0f93f27-48c1-4df4-a4a9-8a6718c15d68"));
            kullanimBirimi = (ITTTextBox)AddControl(new Guid("5c49655b-c329-40b2-bcc8-71e1fd8f8cb6"));
            ilacAdi = (ITTTextBox)AddControl(new Guid("6da9c144-654e-430c-a36f-dc6f69187c7b"));
            barkod = (ITTTextBox)AddControl(new Guid("c2f08bbf-0cb0-4fe8-a86f-ee949bdef006"));
            labelilacAdi = (ITTLabel)AddControl(new Guid("ce6104e6-fff1-43f5-9da9-9db345852231"));
            labelbarkod = (ITTLabel)AddControl(new Guid("b962c568-6277-42d0-b16e-022992d38d67"));
            isActive = (ITTCheckBox)AddControl(new Guid("ed149268-2420-4f45-b6cc-a481d1a80d2c"));
            base.InitializeControls();
        }

        public IlacDefinitionForm() : base("ILAC", "IlacDefinitionForm")
        {
        }

        protected IlacDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}