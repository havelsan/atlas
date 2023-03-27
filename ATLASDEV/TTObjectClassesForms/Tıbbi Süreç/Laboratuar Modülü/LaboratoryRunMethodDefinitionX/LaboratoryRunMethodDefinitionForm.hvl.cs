
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
    /// Laboratuvar Çalışma Metod Tanım Formu
    /// </summary>
    public partial class LaboratoryRunMethodDefinitionForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Çalışma Metod Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryRunMethodDefinitionX _LaboratoryRunMethodDefinitionX
        {
            get { return (TTObjectClasses.LaboratoryRunMethodDefinitionX)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTTextBox txtDescri;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox3;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("c512e2a1-ebc8-4e3f-aba5-1868dbf7b3f9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("feb550a7-cb9d-4503-9984-1f831cdd222e"));
            txtDescri = (ITTTextBox)AddControl(new Guid("0ecaa977-8567-42e4-ad27-69ec1eb4967c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("501d5e25-6b9e-4fa1-851b-71bac3dbf7fd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3bdc1c45-5fc8-4706-8165-762a9459c71b"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0676fd66-b0b6-4dc5-b1d1-7bb218b02b89"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("04ddef0d-ccd1-4c8e-9f8f-cc95d248f591"));
            base.InitializeControls();
        }

        public LaboratoryRunMethodDefinitionForm() : base("LABORATORYRUNMETHODDEFINITIONX", "LaboratoryRunMethodDefinitionForm")
        {
        }

        protected LaboratoryRunMethodDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}