
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
    public partial class EtkinMaddeleriOkuCevapForm : BaseEtkinMaddeleriOkuForm
    {
        protected TTObjectClasses.EtkinMaddeleriOku _EtkinMaddeleriOku
        {
            get { return (TTObjectClasses.EtkinMaddeleriOku)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid etkinMaddelerEtkinMaddeDVO;
        protected ITTTextBoxColumn etkinMaddeKoduEtkinMaddeDVO;
        protected ITTTextBoxColumn etkinMaddeAdiEtkinMaddeDVO;
        protected ITTTextBoxColumn adetMiktarEtkinMaddeDVO;
        protected ITTTextBoxColumn icerikMiktariEtkinMaddeDVO;
        protected ITTTextBoxColumn formEtkinMaddeDVO;
        protected ITTDateTimePickerColumn CreationDateEtkinMaddeDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f0cbd6f1-33d9-46f1-ad35-6043cd37f0ee"));
            etkinMaddelerEtkinMaddeDVO = (ITTGrid)AddControl(new Guid("c7ffc8d4-cfa0-4f6c-a002-a1df16bebd25"));
            etkinMaddeKoduEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("086fdb3f-5791-4f78-bf38-20bf8eeac82c"));
            etkinMaddeAdiEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("b5966cbb-ffd1-44f1-8b54-71fd046a80e9"));
            adetMiktarEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("f62c356c-32bf-4a6f-bc5b-b64a51660e6d"));
            icerikMiktariEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("a68bd226-6e7c-412d-b511-a0ebf1e13c4b"));
            formEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("6d8d6a96-a63e-42ab-9c82-664d8fa9691e"));
            CreationDateEtkinMaddeDVO = (ITTDateTimePickerColumn)AddControl(new Guid("7c86c12a-07ef-486b-bd76-02af1f6f2be9"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("a17d281d-f234-412b-b19f-01ef4b69b27b"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("dd69e056-3c6c-4348-8532-5e34c0bd265d"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("8d347362-1d8f-4bbe-9726-8354ebdf41b1"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("eb43d683-3364-491c-bcc3-8ac6a20094a0"));
            base.InitializeControls();
        }

        public EtkinMaddeleriOkuCevapForm() : base("ETKINMADDELERIOKU", "EtkinMaddeleriOkuCevapForm")
        {
        }

        protected EtkinMaddeleriOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}