
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
    /// Sağlık Tesisi Ara Cevap
    /// </summary>
    public partial class SaglikTesisiAraCevapForm : BaseSaglikTesisiAraForm
    {
    /// <summary>
    /// Sağlık Tesisi Ara
    /// </summary>
        protected TTObjectClasses.SaglikTesisiAra _SaglikTesisiAra
        {
            get { return (TTObjectClasses.SaglikTesisiAra)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid tesislerSaglikTesisiListDVO;
        protected ITTTextBoxColumn tesisKoduSaglikTesisiListDVO;
        protected ITTTextBoxColumn tesisAdiSaglikTesisiListDVO;
        protected ITTTextBoxColumn tesisIlSaglikTesisiListDVO;
        protected ITTTextBoxColumn tesisSinifKoduSaglikTesisiListDVO;
        protected ITTTextBoxColumn tesisTuruSaglikTesisiListDVO;
        protected ITTDateTimePickerColumn CreationDateSaglikTesisiListDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("aadf6598-9f77-465f-9554-92818c61dd1f"));
            tesislerSaglikTesisiListDVO = (ITTGrid)AddControl(new Guid("541e3ab7-c3e9-4773-86da-7ea9368f4892"));
            tesisKoduSaglikTesisiListDVO = (ITTTextBoxColumn)AddControl(new Guid("3e9415da-c486-4671-8280-30f5faf5f214"));
            tesisAdiSaglikTesisiListDVO = (ITTTextBoxColumn)AddControl(new Guid("5509a155-c176-4fe3-bcae-e40759fb7d4a"));
            tesisIlSaglikTesisiListDVO = (ITTTextBoxColumn)AddControl(new Guid("60e9292a-c137-4149-9997-6884e8425f02"));
            tesisSinifKoduSaglikTesisiListDVO = (ITTTextBoxColumn)AddControl(new Guid("18796175-7d3d-4262-9dc8-0dda692496fe"));
            tesisTuruSaglikTesisiListDVO = (ITTTextBoxColumn)AddControl(new Guid("6e8b81f4-bdb0-45db-ac94-d06e42ce3f3b"));
            CreationDateSaglikTesisiListDVO = (ITTDateTimePickerColumn)AddControl(new Guid("b3acb75b-d310-45c9-9f06-75b73efd00e3"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("9d903ff1-abd1-4fca-9aa1-2d01940c459d"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("76ca3423-62bc-471b-8f00-e02544e3cfdf"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("3dddb420-1fc0-4fad-a5fb-652e2e28e078"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("259e5a52-85c8-4436-b41e-11de802dad9c"));
            base.InitializeControls();
        }

        public SaglikTesisiAraCevapForm() : base("SAGLIKTESISIARA", "SaglikTesisiAraCevapForm")
        {
        }

        protected SaglikTesisiAraCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}