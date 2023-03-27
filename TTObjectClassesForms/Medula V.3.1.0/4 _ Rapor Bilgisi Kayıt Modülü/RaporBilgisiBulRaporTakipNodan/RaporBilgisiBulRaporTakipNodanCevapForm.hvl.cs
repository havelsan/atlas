
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
    public partial class RaporBilgisiBulRaporTakipNodanCevapForm : BaseRaporBilgisiBulRaporTakipNodanForm
    {
    /// <summary>
    /// Rapor Bilgisi Bul Rapor Takip Numarasından
    /// </summary>
        protected TTObjectClasses.RaporBilgisiBulRaporTakipNodan _RaporBilgisiBulRaporTakipNodan
        {
            get { return (TTObjectClasses.RaporBilgisiBulRaporTakipNodan)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelsonucKoduBaseMedulaRaporCevap;
        protected ITTLabel labelraporTakipNoRaporCevapDVO;
        protected ITTListDefComboBox raporTuruRaporCevapDVO;
        protected ITTLabel labelraporTuruRaporCevapDVO;
        protected ITTLabel labelsonucAciklamasiBaseMedulaRaporCevap;
        protected ITTTextBox raporTakipNoRaporCevapDVO;
        protected ITTButton buttonRaporCevapBilgileri;
        protected ITTTextBox sonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucAciklamasiBaseMedulaRaporCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bf209b6e-4a9b-4e0c-8613-17b38aa883fe"));
            labelsonucKoduBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("f9c190aa-6b3d-4c18-ac7d-fbe7fbabf341"));
            labelraporTakipNoRaporCevapDVO = (ITTLabel)AddControl(new Guid("aeb6f808-5c53-4e6a-b7e3-56e88a0bc5bc"));
            raporTuruRaporCevapDVO = (ITTListDefComboBox)AddControl(new Guid("0b059266-eba8-4633-b639-b41e5b5f2ba9"));
            labelraporTuruRaporCevapDVO = (ITTLabel)AddControl(new Guid("6f470b1b-0746-4676-ae20-ff59e2a738ff"));
            labelsonucAciklamasiBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("8d9aaea5-335e-446e-996a-6e961c917bdb"));
            raporTakipNoRaporCevapDVO = (ITTTextBox)AddControl(new Guid("963b1732-644b-4183-a49d-7c1c9952e0ab"));
            buttonRaporCevapBilgileri = (ITTButton)AddControl(new Guid("ac166c2a-412f-4b1a-b11d-29111d6dd1f5"));
            sonucKoduBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("aeeaf244-1381-443b-994b-698bc14d0f12"));
            sonucAciklamasiBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("a295db8b-99a1-49f1-bc2d-627bbaa3c60e"));
            base.InitializeControls();
        }

        public RaporBilgisiBulRaporTakipNodanCevapForm() : base("RAPORBILGISIBULRAPORTAKIPNODAN", "RaporBilgisiBulRaporTakipNodanCevapForm")
        {
        }

        protected RaporBilgisiBulRaporTakipNodanCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}