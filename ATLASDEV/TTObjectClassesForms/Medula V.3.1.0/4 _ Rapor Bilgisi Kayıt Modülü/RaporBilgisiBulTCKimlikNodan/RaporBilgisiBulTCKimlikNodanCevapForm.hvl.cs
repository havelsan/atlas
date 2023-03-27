
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
    public partial class RaporBilgisiBulTCKimlikNodanCevapForm : BaseRaporBilgisiBulTCKimlikNodanForm
    {
    /// <summary>
    /// Rapor Bilgisi Bul TC Kimlik Numarasından
    /// </summary>
        protected TTObjectClasses.RaporBilgisiBulTCKimlikNodan _RaporBilgisiBulTCKimlikNodan
        {
            get { return (TTObjectClasses.RaporBilgisiBulTCKimlikNodan)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid raporlarRaporCevapDVO;
        protected ITTTextBoxColumn raporTakipNoRaporCevapDVO;
        protected ITTListDefComboBoxColumn raporTuruRaporCevapDVO;
        protected ITTTextBoxColumn sonucKoduRaporCevapDVO;
        protected ITTTextBoxColumn sonucAciklamasiRaporCevapDVO;
        protected ITTTextBox sonucKoduBaseMedulaRaporCevap;
        protected ITTLabel labelsonucAciklamasiBaseMedulaRaporCevap;
        protected ITTLabel labelsonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucAciklamasiBaseMedulaRaporCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("1362578b-1556-44bd-8dfb-1d0a8a8e4374"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("fc3b7339-170e-4327-8f2a-799c48654546"));
            raporlarRaporCevapDVO = (ITTGrid)AddControl(new Guid("bfa7f9f8-a348-4624-933f-9fd6b94c0bfc"));
            raporTakipNoRaporCevapDVO = (ITTTextBoxColumn)AddControl(new Guid("7b623e35-12a6-43a4-b4c0-b3fe02737b23"));
            raporTuruRaporCevapDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("f2fb237a-49fa-4fc2-a742-214852a12f92"));
            sonucKoduRaporCevapDVO = (ITTTextBoxColumn)AddControl(new Guid("9e1bda6f-bf64-49fb-b09c-f789af117469"));
            sonucAciklamasiRaporCevapDVO = (ITTTextBoxColumn)AddControl(new Guid("6311a7d9-3a5e-43ad-9944-82e710a5774e"));
            sonucKoduBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("dfcebc97-98c4-4795-b7fd-e07e12b26e6e"));
            labelsonucAciklamasiBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("4d7d8c33-f39d-44ae-b7f9-7acf56eea506"));
            labelsonucKoduBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("e5c1f59d-b2d1-46fe-9623-ebdce8ff35c3"));
            sonucAciklamasiBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("ef60aaeb-9bdb-4539-9454-17fc707f72fc"));
            base.InitializeControls();
        }

        public RaporBilgisiBulTCKimlikNodanCevapForm() : base("RAPORBILGISIBULTCKIMLIKNODAN", "RaporBilgisiBulTCKimlikNodanCevapForm")
        {
        }

        protected RaporBilgisiBulTCKimlikNodanCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}