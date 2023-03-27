
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
    public partial class DispatchToOtherHospital_SaglikTesisiAraForm : TTForm
    {
    /// <summary>
    /// XXXXXXler Arası Sevk 
    /// </summary>
        protected TTObjectClasses.DispatchToOtherHospital _DispatchToOtherHospital
        {
            get { return (TTObjectClasses.DispatchToOtherHospital)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelSonucMesaji;
        protected ITTLabel labelSonucKodu;
        protected ITTTextBox tttextboxSonucMesaji;
        protected ITTTextBox tttextboxSonucKodu;
        protected ITTGrid ttgridSaglikTesisleri;
        protected ITTTextBoxColumn TesisIl;
        protected ITTTextBoxColumn TesisAdi;
        protected ITTTextBoxColumn TesisKodu;
        protected ITTTextBoxColumn TesisSinifKodu;
        protected ITTTextBoxColumn TesisTuru;
        protected ITTButton buttonSaglikTesisiAra;
        protected ITTTextBox tesisAdiSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisIlKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisTuruSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        protected ITTLabel labeltesisKoduSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisIlKoduSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisTuruSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisAdiSaglikTesisiAraGirisDVO;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e59d812a-5cc4-468f-9777-830def550504"));
            labelSonucMesaji = (ITTLabel)AddControl(new Guid("3f0ba869-de19-4b61-9c23-553fc2e11b3f"));
            labelSonucKodu = (ITTLabel)AddControl(new Guid("9df54646-c473-49f5-b00b-3bf229a08147"));
            tttextboxSonucMesaji = (ITTTextBox)AddControl(new Guid("6faee74f-d948-412e-b9f2-0c03bb46a56c"));
            tttextboxSonucKodu = (ITTTextBox)AddControl(new Guid("ab57f834-54e8-4748-acd8-19bf8eb3bd8c"));
            ttgridSaglikTesisleri = (ITTGrid)AddControl(new Guid("93ad634e-f3b9-4a1d-ab40-4a131a7d3a48"));
            TesisIl = (ITTTextBoxColumn)AddControl(new Guid("8d0134c9-a5ea-4cd4-8298-a2be7a68e87c"));
            TesisAdi = (ITTTextBoxColumn)AddControl(new Guid("58695847-b9c8-435f-8759-7bbde5fdc46e"));
            TesisKodu = (ITTTextBoxColumn)AddControl(new Guid("fac857db-8e47-4ed7-8c84-8f0e8026c8a7"));
            TesisSinifKodu = (ITTTextBoxColumn)AddControl(new Guid("b474d926-a98b-4095-939c-7b748b5f966f"));
            TesisTuru = (ITTTextBoxColumn)AddControl(new Guid("8a42aaf9-1c26-410f-83de-55c703f46463"));
            buttonSaglikTesisiAra = (ITTButton)AddControl(new Guid("19480de6-4769-42c7-a359-6e18051e1501"));
            tesisAdiSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("5e795039-9ee7-4161-84d8-9418552e1685"));
            tesisIlKoduSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("68c64248-bf96-4d05-b06d-39560387c831"));
            tesisTuruSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("ab6dd124-0fd0-4077-a3a4-819228595e32"));
            tesisKoduSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("949063e8-4e11-4320-90b9-10f3c00bcbbd"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("8792f992-1358-459a-9e1e-4f8d8ec34ddb"));
            labeltesisKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("c2b851f9-b97f-45ac-aa51-691b5cc31531"));
            labeltesisIlKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("04994917-e501-4e3c-b5ec-7c55c639e110"));
            labeltesisTuruSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("a3edbb4a-185e-485b-8115-99ad0d6b65ae"));
            labeltesisAdiSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("d75ece7f-1816-45b0-ba15-f558a27bba5c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9dd184d4-b65f-440a-82ac-1ce9e93dd3a8"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("599a5bfd-d316-4641-97b4-2b0134830d28"));
            base.InitializeControls();
        }

        public DispatchToOtherHospital_SaglikTesisiAraForm() : base("DISPATCHTOOTHERHOSPITAL", "DispatchToOtherHospital_SaglikTesisiAraForm")
        {
        }

        protected DispatchToOtherHospital_SaglikTesisiAraForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}