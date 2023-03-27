
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
    /// Sigortalı Türü Tanımlama
    /// </summary>
    public partial class SigortaliTuruDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sigortalı Türü
    /// </summary>
        protected TTObjectClasses.SigortaliTuru _SigortaliTuru
        {
            get { return (TTObjectClasses.SigortaliTuru)_ttObject; }
        }

        protected ITTLabel labelsigortaliTuruKodu;
        protected ITTTextBox sigortaliTuruKodu;
        protected ITTLabel labelsigortaliTuruAdi;
        protected ITTTextBox sigortaliTuruAdi;
        override protected void InitializeControls()
        {
            labelsigortaliTuruKodu = (ITTLabel)AddControl(new Guid("fc9c3079-bd40-4460-a856-d053587e9d7e"));
            sigortaliTuruKodu = (ITTTextBox)AddControl(new Guid("1a8e487a-eaef-4f4c-8b8b-0cf8dabab0c1"));
            labelsigortaliTuruAdi = (ITTLabel)AddControl(new Guid("da29e720-d31a-43a0-9034-356d81c1354a"));
            sigortaliTuruAdi = (ITTTextBox)AddControl(new Guid("eb63a762-8676-478d-b07f-51aba7e7f02a"));
            base.InitializeControls();
        }

        public SigortaliTuruDefinitionForm() : base("SIGORTALITURU", "SigortaliTuruDefinitionForm")
        {
        }

        protected SigortaliTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}