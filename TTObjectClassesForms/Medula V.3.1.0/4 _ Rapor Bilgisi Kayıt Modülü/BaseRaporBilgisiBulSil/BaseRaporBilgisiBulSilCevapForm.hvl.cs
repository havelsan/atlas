
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
    public partial class BaseRaporBilgisiBulSilCevapForm : BaseRaporBilgisiBulSilForm
    {
        protected TTObjectClasses.BaseRaporBilgisiBulSil _BaseRaporBilgisiBulSil
        {
            get { return (TTObjectClasses.BaseRaporBilgisiBulSil)_ttObject; }
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
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("6469b138-9e81-4ee9-8b36-a44793e7df4f"));
            labelsonucKoduBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("ab88b210-9cd3-4bf3-b716-e10fefa1afda"));
            labelraporTakipNoRaporCevapDVO = (ITTLabel)AddControl(new Guid("91f18186-bfa1-4e97-b2dd-1e405087de5f"));
            raporTuruRaporCevapDVO = (ITTListDefComboBox)AddControl(new Guid("054994a5-e4e8-4bec-b6dc-867e4cdf78a0"));
            labelraporTuruRaporCevapDVO = (ITTLabel)AddControl(new Guid("409d7ec5-736b-4492-94c4-25cfd1a28cec"));
            labelsonucAciklamasiBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("b37b37fc-846e-4b85-9e4f-b8fb13232f26"));
            raporTakipNoRaporCevapDVO = (ITTTextBox)AddControl(new Guid("7b8e68c0-2ee9-4e0b-88a5-c24536b7bae7"));
            buttonRaporCevapBilgileri = (ITTButton)AddControl(new Guid("5068dcb1-aa92-47f2-97b9-8154220873ba"));
            sonucKoduBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("2b1afd2b-ff11-48cc-8bdb-47ef25debb6e"));
            sonucAciklamasiBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("aef8bf25-0468-4328-a639-f14641ffe9fe"));
            base.InitializeControls();
        }

        public BaseRaporBilgisiBulSilCevapForm() : base("BASERAPORBILGISIBULSIL", "BaseRaporBilgisiBulSilCevapForm")
        {
        }

        protected BaseRaporBilgisiBulSilCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}