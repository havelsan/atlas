
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
    public partial class EtkinMaddeSutKuraliGetirCevapForm : BaseEtkinMaddeSutKuraliGetirForm
    {
        protected TTObjectClasses.EtkinMaddeSutKuraliGetir _EtkinMaddeSutKuraliGetir
        {
            get { return (TTObjectClasses.EtkinMaddeSutKuraliGetir)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid sutKurallariEtkinMaddeSUTKuraliDVO;
        protected ITTTextBoxColumn kuralIDEtkinMaddeSUTKuraliDVO;
        protected ITTTextBoxColumn bransKuralUygulamaEtkinMaddeSUTKuraliDVO;
        protected ITTTextBoxColumn duzenlemeTuruEtkinMaddeSUTKuraliDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("56b94089-7ec8-48a0-ae84-e490ab9dca02"));
            sutKurallariEtkinMaddeSUTKuraliDVO = (ITTGrid)AddControl(new Guid("3a2301e2-ebd7-48b3-95c6-eeb74e4ff71f"));
            kuralIDEtkinMaddeSUTKuraliDVO = (ITTTextBoxColumn)AddControl(new Guid("442b0afa-c824-4625-9504-bd4cd4e77993"));
            bransKuralUygulamaEtkinMaddeSUTKuraliDVO = (ITTTextBoxColumn)AddControl(new Guid("2344efb0-2903-4510-9174-395fe823b118"));
            duzenlemeTuruEtkinMaddeSUTKuraliDVO = (ITTTextBoxColumn)AddControl(new Guid("38063c79-1f1e-4f59-83d2-eb6aeff328a0"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("61021fcd-f901-45e6-820f-ebe09632fb94"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("a2ea720a-706d-4499-a84d-a268969a6141"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("4d3d4e70-2eae-4d18-a36f-1e6bb2d44709"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("45e55ec6-45bb-427b-8afe-e1656ff17fa2"));
            base.InitializeControls();
        }

        public EtkinMaddeSutKuraliGetirCevapForm() : base("ETKINMADDESUTKURALIGETIR", "EtkinMaddeSutKuraliGetirCevapForm")
        {
        }

        protected EtkinMaddeSutKuraliGetirCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}