
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
    public partial class TasLokalizasyonDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.TasLokalizasyon _TasLokalizasyon
        {
            get { return (TTObjectClasses.TasLokalizasyon)_ttObject; }
        }

        protected ITTLabel labeltasLokalizasyonAdi;
        protected ITTTextBox tasLokalizasyonAdi;
        protected ITTLabel labeltasLokalizasyonKodu;
        protected ITTTextBox tasLokalizasyonKodu;
        override protected void InitializeControls()
        {
            labeltasLokalizasyonAdi = (ITTLabel)AddControl(new Guid("079c533e-8de6-44ff-9ff3-f1e1bfdcf9c7"));
            tasLokalizasyonAdi = (ITTTextBox)AddControl(new Guid("2dac1aee-464b-49bf-b861-669c86c0ba3b"));
            labeltasLokalizasyonKodu = (ITTLabel)AddControl(new Guid("42140b86-b50c-41af-aa85-e5dfd12d57f2"));
            tasLokalizasyonKodu = (ITTTextBox)AddControl(new Guid("99a9709d-e5dd-43ba-89fb-abb78884e667"));
            base.InitializeControls();
        }

        public TasLokalizasyonDefinitionForm() : base("TASLOKALIZASYON", "TasLokalizasyonDefinitionForm")
        {
        }

        protected TasLokalizasyonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}