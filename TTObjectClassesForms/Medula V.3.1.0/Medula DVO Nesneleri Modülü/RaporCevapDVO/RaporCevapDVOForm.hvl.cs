
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
    public partial class RaporCevapDVOForm : BaseMedulaRaporCevapForm
    {
        protected TTObjectClasses.RaporCevapDVO _RaporCevapDVO
        {
            get { return (TTObjectClasses.RaporCevapDVO)_ttObject; }
        }

        protected ITTButton buttonRaporCevapBilgileri;
        protected ITTLabel labelsonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucKoduBaseMedulaRaporCevap;
        protected ITTTextBox sonucAciklamasiBaseMedulaRaporCevap;
        protected ITTTextBox raporTakipNoRaporCevapDVO;
        protected ITTLabel labelsonucAciklamasiBaseMedulaRaporCevap;
        protected ITTLabel labelraporTuruRaporCevapDVO;
        protected ITTListDefComboBox raporTuruRaporCevapDVO;
        protected ITTLabel labelraporTakipNoRaporCevapDVO;
        override protected void InitializeControls()
        {
            buttonRaporCevapBilgileri = (ITTButton)AddControl(new Guid("b6cac08a-7b8c-4149-9e01-7500646a2cb9"));
            labelsonucKoduBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("de7335dd-6135-4cd9-a682-da76431da287"));
            sonucKoduBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("ab666cf7-8db9-4cf0-867e-39cc24a96fde"));
            sonucAciklamasiBaseMedulaRaporCevap = (ITTTextBox)AddControl(new Guid("560ef636-250b-49de-9976-06485831f3ec"));
            raporTakipNoRaporCevapDVO = (ITTTextBox)AddControl(new Guid("8ff1c2b6-dd08-4b29-9278-8ea27b013f89"));
            labelsonucAciklamasiBaseMedulaRaporCevap = (ITTLabel)AddControl(new Guid("5a79cbd7-224b-4049-9295-8cc0792153c7"));
            labelraporTuruRaporCevapDVO = (ITTLabel)AddControl(new Guid("48dbddf6-a980-49d8-bd4d-07d9a30e4482"));
            raporTuruRaporCevapDVO = (ITTListDefComboBox)AddControl(new Guid("6bee676c-735f-492c-bdad-446b4fb83c90"));
            labelraporTakipNoRaporCevapDVO = (ITTLabel)AddControl(new Guid("3a978013-0cf3-44ff-8b1e-26692e8406ea"));
            base.InitializeControls();
        }

        public RaporCevapDVOForm() : base("RAPORCEVAPDVO", "RaporCevapDVOForm")
        {
        }

        protected RaporCevapDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}