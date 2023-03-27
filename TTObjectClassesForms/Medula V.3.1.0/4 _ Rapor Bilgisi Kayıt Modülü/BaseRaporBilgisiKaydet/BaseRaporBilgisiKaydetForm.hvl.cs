
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
    public partial class BaseRaporBilgisiKaydetForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Rapor Bilgisi Kaydet
    /// </summary>
        protected TTObjectClasses.BaseRaporBilgisiKaydet _BaseRaporBilgisiKaydet
        {
            get { return (TTObjectClasses.BaseRaporBilgisiKaydet)_ttObject; }
        }

        protected ITTLabel labelkullaniciTesisKoduBaseMedulaRaporObject;
        protected ITTValueListBox kullaniciTesisKoduBaseMedulaRaporObject;
        override protected void InitializeControls()
        {
            labelkullaniciTesisKoduBaseMedulaRaporObject = (ITTLabel)AddControl(new Guid("2c8118a9-aff8-40aa-a09d-aa7ef2aeafc0"));
            kullaniciTesisKoduBaseMedulaRaporObject = (ITTValueListBox)AddControl(new Guid("fe96c79a-d19f-4aef-b3dd-7a6ea9a3c2e7"));
            base.InitializeControls();
        }

        public BaseRaporBilgisiKaydetForm() : base("BASERAPORBILGISIKAYDET", "BaseRaporBilgisiKaydetForm")
        {
        }

        protected BaseRaporBilgisiKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}