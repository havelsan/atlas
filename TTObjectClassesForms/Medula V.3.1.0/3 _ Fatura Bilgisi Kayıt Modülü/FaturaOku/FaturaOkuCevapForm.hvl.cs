
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
    /// Fatura Oku Cevap
    /// </summary>
    public partial class FaturaOkuCevapForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Fatura Oku
    /// </summary>
        protected TTObjectClasses.FaturaOku _FaturaOku
        {
            get { return (TTObjectClasses.FaturaOku)_ttObject; }
        }

        protected ITTGrid faturaDetaylariFaturaCevapDetayDVO;
        protected ITTTextBoxColumn protokolNoFaturaCevapDetayDVO;
        protected ITTListDefComboBoxColumn taburcuKoduFaturaCevapDetayDVO;
        protected ITTTextBoxColumn takipNoFaturaCevapDetayDVO;
        protected ITTTextBoxColumn takipToplamTutarFaturaCevapDetayDVO;
        protected ITTTextBoxColumn aciklamaFaturaCevapDetayDVO;
        protected ITTDateTimePickerColumn CreationDateFaturaCevapDetayDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        protected ITTLabel labelfaturaTutariFaturaOkuCevapDVO;
        protected ITTTextBox faturaTutariFaturaOkuCevapDVO;
        protected ITTLabel labelfaturaTeslimNoFaturaOkuCevapDVO;
        protected ITTTextBox faturaTeslimNoFaturaOkuCevapDVO;
        protected ITTLabel labelfaturaTarihiFaturaOkuCevapDVO;
        protected ITTTextBox faturaTarihiFaturaOkuCevapDVO;
        protected ITTLabel labelfaturaRefNoFaturaOkuCevapDVO;
        protected ITTTextBox faturaRefNoFaturaOkuCevapDVO;
        override protected void InitializeControls()
        {
            faturaDetaylariFaturaCevapDetayDVO = (ITTGrid)AddControl(new Guid("36a2a9b9-23a0-4511-9cdd-60da89c99366"));
            protokolNoFaturaCevapDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("1813fa2d-2466-4a2b-8881-237d707bb5a4"));
            taburcuKoduFaturaCevapDetayDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("60a0ab25-6716-4112-9c80-d5d90ea70056"));
            takipNoFaturaCevapDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("4de9ae2a-f84b-4c76-974a-147401455ebe"));
            takipToplamTutarFaturaCevapDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("9043cd3f-c07a-436f-b9ee-1c225dceda5e"));
            aciklamaFaturaCevapDetayDVO = (ITTTextBoxColumn)AddControl(new Guid("a68d44ba-c1de-4f48-aa43-a9144910f580"));
            CreationDateFaturaCevapDetayDVO = (ITTDateTimePickerColumn)AddControl(new Guid("24c8f0da-b99a-4f08-b94c-3f88f901ba84"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("0d48d30c-bb66-4c08-a6e8-ecd2a6aaa961"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("eef898c5-1610-45b8-9dd3-261bbc0e5376"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("aca1f521-f91a-4b75-9cc8-3626e11f8996"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("ece8fc7d-8b0c-4e9a-be9b-b276a8d245b6"));
            labelfaturaTutariFaturaOkuCevapDVO = (ITTLabel)AddControl(new Guid("2437ab7d-2883-40c4-a9b4-96818bdbc514"));
            faturaTutariFaturaOkuCevapDVO = (ITTTextBox)AddControl(new Guid("c399f54b-bdee-46d2-9241-c42513b74cc4"));
            labelfaturaTeslimNoFaturaOkuCevapDVO = (ITTLabel)AddControl(new Guid("7690fbe9-14d4-4255-b6e3-050ef6aca4ba"));
            faturaTeslimNoFaturaOkuCevapDVO = (ITTTextBox)AddControl(new Guid("3e3c5844-2a05-4cd3-b0bb-2a74db3fb13c"));
            labelfaturaTarihiFaturaOkuCevapDVO = (ITTLabel)AddControl(new Guid("40943eef-a3d2-4cf5-b76f-cfbead0eb718"));
            faturaTarihiFaturaOkuCevapDVO = (ITTTextBox)AddControl(new Guid("bd7ec537-2e9f-4841-8f77-ca921d846079"));
            labelfaturaRefNoFaturaOkuCevapDVO = (ITTLabel)AddControl(new Guid("4293a281-6f8b-4f0b-9efa-552618c044bc"));
            faturaRefNoFaturaOkuCevapDVO = (ITTTextBox)AddControl(new Guid("739db9b6-6875-4dd4-858c-77a9e6eef728"));
            base.InitializeControls();
        }

        public FaturaOkuCevapForm() : base("FATURAOKU", "FaturaOkuCevapForm")
        {
        }

        protected FaturaOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}