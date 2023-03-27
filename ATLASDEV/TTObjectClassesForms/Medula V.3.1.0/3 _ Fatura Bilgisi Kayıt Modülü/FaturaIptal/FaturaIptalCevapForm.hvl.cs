
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
    /// Fatura İptal Cevap
    /// </summary>
    public partial class FaturaIptalCevapForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Fatura İptal
    /// </summary>
        protected TTObjectClasses.FaturaIptal _FaturaIptal
        {
            get { return (TTObjectClasses.FaturaIptal)_ttObject; }
        }

        protected ITTGrid hataliKayitlarFaturaIptalHataliKayitDVO;
        protected ITTTextBoxColumn faturaTeslimNoFaturaIptalHataliKayitDVO;
        protected ITTTextBoxColumn hataKoduFaturaIptalHataliKayitDVO;
        protected ITTTextBoxColumn hataMesajiFaturaIptalHataliKayitDVO;
        protected ITTDateTimePickerColumn CreationDateFaturaIptalHataliKayitDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            hataliKayitlarFaturaIptalHataliKayitDVO = (ITTGrid)AddControl(new Guid("18bfe262-cc9d-4570-86e2-96cbc2bce459"));
            faturaTeslimNoFaturaIptalHataliKayitDVO = (ITTTextBoxColumn)AddControl(new Guid("212b4072-d053-466e-b57a-f935dc2bfbbc"));
            hataKoduFaturaIptalHataliKayitDVO = (ITTTextBoxColumn)AddControl(new Guid("73cd930d-6587-4019-8b53-3c75f4aed2d5"));
            hataMesajiFaturaIptalHataliKayitDVO = (ITTTextBoxColumn)AddControl(new Guid("67ff27a9-ff43-482e-9722-e45b46f61539"));
            CreationDateFaturaIptalHataliKayitDVO = (ITTDateTimePickerColumn)AddControl(new Guid("9fb7a9aa-049d-47c7-b749-66ae3b719e8e"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("4c76286e-73e5-43fc-8a81-b5844014554a"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("53d5068b-8c69-4494-8620-6587ca9089c7"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("7ba3b8ac-c276-4bb7-8f43-d72aed6c5f9d"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("e572b61d-3095-40fc-b17f-b445543cb29b"));
            base.InitializeControls();
        }

        public FaturaIptalCevapForm() : base("FATURAIPTAL", "FaturaIptalCevapForm")
        {
        }

        protected FaturaIptalCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}