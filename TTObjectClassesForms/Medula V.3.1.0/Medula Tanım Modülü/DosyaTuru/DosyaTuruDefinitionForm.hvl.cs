
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
    public partial class DosyaTuruDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.DosyaTuru _DosyaTuru
        {
            get { return (TTObjectClasses.DosyaTuru)_ttObject; }
        }

        protected ITTLabel labeldosyaTuruKodu;
        protected ITTTextBox dosyaTuruKodu;
        protected ITTTextBox dosyaTuruAdi;
        protected ITTLabel labeldosyaTuruAdi;
        override protected void InitializeControls()
        {
            labeldosyaTuruKodu = (ITTLabel)AddControl(new Guid("f909b2da-1c7d-4a8f-9378-3b5a64676624"));
            dosyaTuruKodu = (ITTTextBox)AddControl(new Guid("19bd29a9-06d2-416a-bc4f-60c536dcb9d8"));
            dosyaTuruAdi = (ITTTextBox)AddControl(new Guid("18515074-6446-444d-a0ad-e7dcc72ba227"));
            labeldosyaTuruAdi = (ITTLabel)AddControl(new Guid("9b3beb1a-0cbc-4967-b253-d4e34f1723f8"));
            base.InitializeControls();
        }

        public DosyaTuruDefinitionForm() : base("DOSYATURU", "DosyaTuruDefinitionForm")
        {
        }

        protected DosyaTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}