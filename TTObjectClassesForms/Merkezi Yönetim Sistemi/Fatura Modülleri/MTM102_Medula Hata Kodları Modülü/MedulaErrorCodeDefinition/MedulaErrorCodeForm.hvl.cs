
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
    public partial class MedulaErrorCodeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Medula Hata Kodları
    /// </summary>
        protected TTObjectClasses.MedulaErrorCodeDefinition _MedulaErrorCodeDefinition
        {
            get { return (TTObjectClasses.MedulaErrorCodeDefinition)_ttObject; }
        }

        protected ITTCheckBox AllowWorkAsAsync;
        protected ITTLabel labelKullaniciNotu;
        protected ITTTextBox KullaniciNotu;
        protected ITTTextBox Aciklama;
        protected ITTTextBox Mesaj;
        protected ITTTextBox Kod;
        protected ITTLabel labelAciklama;
        protected ITTLabel labelMesaj;
        protected ITTLabel labelKod;
        override protected void InitializeControls()
        {
            AllowWorkAsAsync = (ITTCheckBox)AddControl(new Guid("923cdab6-dc47-4a38-96fc-2c023b6ba534"));
            labelKullaniciNotu = (ITTLabel)AddControl(new Guid("673a1b0f-9b48-4085-a134-64fd5f91ca0e"));
            KullaniciNotu = (ITTTextBox)AddControl(new Guid("1ab5328c-572e-4b78-bfaf-031f0453502a"));
            Aciklama = (ITTTextBox)AddControl(new Guid("d9418afb-9e64-4673-882f-b609f2c1e6b3"));
            Mesaj = (ITTTextBox)AddControl(new Guid("2333c061-5d6e-4e1b-b229-7dd03443267b"));
            Kod = (ITTTextBox)AddControl(new Guid("59db9f9c-f03d-40f9-bc85-53b2326e58cc"));
            labelAciklama = (ITTLabel)AddControl(new Guid("e4cd8ab6-a92b-4f78-93ee-6f438f216bb2"));
            labelMesaj = (ITTLabel)AddControl(new Guid("fa66cf79-e959-43b8-96ed-ff448499b218"));
            labelKod = (ITTLabel)AddControl(new Guid("f4344408-4a38-4a21-a41e-ae9707c5249b"));
            base.InitializeControls();
        }

        public MedulaErrorCodeForm() : base("MEDULAERRORCODEDEFINITION", "MedulaErrorCodeForm")
        {
        }

        protected MedulaErrorCodeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}