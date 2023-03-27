
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
    public partial class BaseRaporBilgisiBulSilForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.BaseRaporBilgisiBulSil _BaseRaporBilgisiBulSil
        {
            get { return (TTObjectClasses.BaseRaporBilgisiBulSil)_ttObject; }
        }

        protected ITTLabel labelraporTesisKoduRaporOkuDVO;
        protected ITTValueListBox raporTesisKoduRaporOkuDVO;
        protected ITTValueListBox kullaniciTesisKoduBaseMedulaRaporObject;
        protected ITTLabel labelkullaniciTesisKoduBaseMedulaRaporObject;
        protected ITTLabel labeltarihDateTimeRaporOkuDVO;
        protected ITTDateTimePicker tarihDateTimeRaporOkuDVO;
        protected ITTLabel labelturuRaporOkuDVO;
        protected ITTListDefComboBox turuRaporOkuDVO;
        protected ITTTextBox noRaporOkuDVO;
        protected ITTLabel labelnoRaporOkuDVO;
        override protected void InitializeControls()
        {
            labelraporTesisKoduRaporOkuDVO = (ITTLabel)AddControl(new Guid("8bb25311-10af-46a6-a229-ce9d72049e1d"));
            raporTesisKoduRaporOkuDVO = (ITTValueListBox)AddControl(new Guid("f618d18a-cfa9-4881-aafa-dcd77e08a69c"));
            kullaniciTesisKoduBaseMedulaRaporObject = (ITTValueListBox)AddControl(new Guid("9a792735-4658-4dbb-8127-652175c8060a"));
            labelkullaniciTesisKoduBaseMedulaRaporObject = (ITTLabel)AddControl(new Guid("628c0723-385d-49f9-8d1b-3b4a9f30c468"));
            labeltarihDateTimeRaporOkuDVO = (ITTLabel)AddControl(new Guid("fe8563fb-e9fb-46c5-9230-c342d5eaed25"));
            tarihDateTimeRaporOkuDVO = (ITTDateTimePicker)AddControl(new Guid("8ef46661-f7bb-4ecc-a60c-a4f51ab9e113"));
            labelturuRaporOkuDVO = (ITTLabel)AddControl(new Guid("bdeac5ef-48a7-41c3-b114-4f6bfe156d4a"));
            turuRaporOkuDVO = (ITTListDefComboBox)AddControl(new Guid("1490f86e-7c4d-427e-9856-64d7f73392fc"));
            noRaporOkuDVO = (ITTTextBox)AddControl(new Guid("884ea056-014b-4c05-9319-564647cbc595"));
            labelnoRaporOkuDVO = (ITTLabel)AddControl(new Guid("9f25eb41-2b27-435b-992e-688a5ab30b61"));
            base.InitializeControls();
        }

        public BaseRaporBilgisiBulSilForm() : base("BASERAPORBILGISIBULSIL", "BaseRaporBilgisiBulSilForm")
        {
        }

        protected BaseRaporBilgisiBulSilForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}