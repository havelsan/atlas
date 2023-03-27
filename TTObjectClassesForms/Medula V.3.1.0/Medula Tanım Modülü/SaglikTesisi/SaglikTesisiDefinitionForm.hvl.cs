
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
    /// Sağlık Tesisi Tanımlama
    /// </summary>
    public partial class SaglikTesisiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sağlık Tesisi
    /// </summary>
        protected TTObjectClasses.SaglikTesisi _SaglikTesisi
        {
            get { return (TTObjectClasses.SaglikTesisi)_ttObject; }
        }

        protected ITTGroupBox PTSUserDetail;
        protected ITTLabel labelPTSUserName;
        protected ITTLabel labelPTSGLN;
        protected ITTTextBox PTSGLN;
        protected ITTLabel labelPTSPassword;
        protected ITTTextBox PTSPassword;
        protected ITTTextBox PTSUserName;
        protected ITTGroupBox ITSUserDetail;
        protected ITTLabel labelITSPassword;
        protected ITTTextBox GLN;
        protected ITTTextBox ITSPassword;
        protected ITTLabel labelGLN;
        protected ITTLabel labelITSUserName;
        protected ITTTextBox ITSUserName;
        protected ITTGroupBox SGKUserDetail;
        protected ITTLabel labelkullaniciSifresi;
        protected ITTLabel labelkullaniciAdi;
        protected ITTTextBox kullaniciSifresi;
        protected ITTTextBox kullaniciAdi;
        protected ITTLabel labelkullaniciAdiTest;
        protected ITTTextBox kullaniciSifresiTest;
        protected ITTLabel labelkullaniciSifresiTest;
        protected ITTTextBox kullaniciAdiTest;
        protected ITTCheckBox IsXXXXXXExist;
        protected ITTLabel labeltesisKisaAdi;
        protected ITTTextBox tesisKisaAdi;
        protected ITTTextBox tesisTuru;
        protected ITTTextBox tesisSinifKodu;
        protected ITTTextBox tesisKodu;
        protected ITTTextBox tesisIl;
        protected ITTTextBox tesisAdi;
        protected ITTCheckBox isActive;
        protected ITTLabel labeltesisTuru;
        protected ITTLabel labeltesisSinifKodu;
        protected ITTLabel labeltesisKodu;
        protected ITTLabel labeltesisIl;
        protected ITTLabel labeltesisAdi;
        override protected void InitializeControls()
        {
            PTSUserDetail = (ITTGroupBox)AddControl(new Guid("a25db7f5-c92f-4db5-b9fa-16822d80ed4a"));
            labelPTSUserName = (ITTLabel)AddControl(new Guid("3aca0951-53c6-43a1-b5fa-654fced053a1"));
            labelPTSGLN = (ITTLabel)AddControl(new Guid("82feb618-5d4c-4286-b14e-be4387f999fb"));
            PTSGLN = (ITTTextBox)AddControl(new Guid("770ff095-5932-464d-ae84-7262824e6863"));
            labelPTSPassword = (ITTLabel)AddControl(new Guid("1ced2a18-f60f-4f8e-ac3c-99a4bfa4e939"));
            PTSPassword = (ITTTextBox)AddControl(new Guid("7b128bcb-728c-489d-a470-13dd877936f9"));
            PTSUserName = (ITTTextBox)AddControl(new Guid("1d7fb9e1-70de-439c-a588-f242022fc97d"));
            ITSUserDetail = (ITTGroupBox)AddControl(new Guid("41be43e5-9c2c-44ec-8e87-97c6b8a69e39"));
            labelITSPassword = (ITTLabel)AddControl(new Guid("87b640e8-7fdc-4df3-a939-56991f0e2813"));
            GLN = (ITTTextBox)AddControl(new Guid("f4f472ba-65b9-4ccc-8d2c-64279e4f7091"));
            ITSPassword = (ITTTextBox)AddControl(new Guid("25219db6-6040-436a-9d45-4a5060f53b80"));
            labelGLN = (ITTLabel)AddControl(new Guid("c6693be5-a3d4-43f3-b784-fff9ee646d45"));
            labelITSUserName = (ITTLabel)AddControl(new Guid("2ef1e75d-e9b5-43f7-b994-d7e1e9d57461"));
            ITSUserName = (ITTTextBox)AddControl(new Guid("a54c7acd-ab06-4cd4-809a-1f1180653bc6"));
            SGKUserDetail = (ITTGroupBox)AddControl(new Guid("b3fa2690-eb73-4507-892d-baea18ff19bb"));
            labelkullaniciSifresi = (ITTLabel)AddControl(new Guid("7bb9f79d-3588-4f47-9dcd-8de51fb243de"));
            labelkullaniciAdi = (ITTLabel)AddControl(new Guid("7be6ac9a-ec0e-4e6a-9973-402cb3eb7367"));
            kullaniciSifresi = (ITTTextBox)AddControl(new Guid("7b1a3830-5994-4a34-a91d-d98e669723c0"));
            kullaniciAdi = (ITTTextBox)AddControl(new Guid("a241429b-3443-4bbf-a1f6-5b0a1b8bdca5"));
            labelkullaniciAdiTest = (ITTLabel)AddControl(new Guid("3dec3065-2840-48cb-85d0-5fa9a51a6a76"));
            kullaniciSifresiTest = (ITTTextBox)AddControl(new Guid("8a79c975-29cc-4842-acf6-583dcf6c8335"));
            labelkullaniciSifresiTest = (ITTLabel)AddControl(new Guid("66556a6d-eae0-4d38-b0fe-c663ca3d2c7f"));
            kullaniciAdiTest = (ITTTextBox)AddControl(new Guid("452b200b-eb3b-48c0-95b2-49defbcdc818"));
            IsXXXXXXExist = (ITTCheckBox)AddControl(new Guid("a8ec248c-873c-46ba-841f-29ca79783a48"));
            labeltesisKisaAdi = (ITTLabel)AddControl(new Guid("a8e39fff-5117-4cfa-8887-0b53ef91706a"));
            tesisKisaAdi = (ITTTextBox)AddControl(new Guid("1318eec2-0210-4da5-99ca-55ca4eb65a59"));
            tesisTuru = (ITTTextBox)AddControl(new Guid("f01a328e-2dff-4080-8a79-e13ba0af159a"));
            tesisSinifKodu = (ITTTextBox)AddControl(new Guid("07a4c869-3ecc-451b-80ea-a555ffe48377"));
            tesisKodu = (ITTTextBox)AddControl(new Guid("f11e9827-636f-48be-9ac0-c05099bb2c24"));
            tesisIl = (ITTTextBox)AddControl(new Guid("b87a81a4-2c47-4e5f-bf51-3d44c41429ec"));
            tesisAdi = (ITTTextBox)AddControl(new Guid("ad6ed82f-e472-4516-b195-94a2e47a1522"));
            isActive = (ITTCheckBox)AddControl(new Guid("a7c5b709-18f6-4995-bc13-54cf79efb3d2"));
            labeltesisTuru = (ITTLabel)AddControl(new Guid("d8a6c712-5955-4f5f-a2d9-8dc2f6b50b81"));
            labeltesisSinifKodu = (ITTLabel)AddControl(new Guid("055175b3-90bb-42fd-b7e1-1c3c48dceb84"));
            labeltesisKodu = (ITTLabel)AddControl(new Guid("c1c1919d-cc1c-4ae2-848a-81f36a0cd535"));
            labeltesisIl = (ITTLabel)AddControl(new Guid("2c7a8628-4e20-4b9a-9e58-9c759f451bb0"));
            labeltesisAdi = (ITTLabel)AddControl(new Guid("c2e8d070-9be3-4453-8ae3-8bd9edc6e515"));
            base.InitializeControls();
        }

        public SaglikTesisiDefinitionForm() : base("SAGLIKTESISI", "SaglikTesisiDefinitionForm")
        {
        }

        protected SaglikTesisiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}