
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
    public partial class BaseEtkinMaddeSutKuraliGetirForm : BaseMedulaDefinitionActionForm
    {
        protected TTObjectClasses.EtkinMaddeSutKuraliGetir _EtkinMaddeSutKuraliGetir
        {
            get { return (TTObjectClasses.EtkinMaddeSutKuraliGetir)_ttObject; }
        }

        protected ITTTextBox raporTarihiEtkinMaddeSUTGirisDVO;
        protected ITTLabel labeletkinMaddeKoduEtkinMaddeSUTGirisDVO;
        protected ITTValueListBox etkinMaddeKoduEtkinMaddeSUTGirisDVO;
        protected ITTValueListBox saglikTesisKoduIlacAraGirisDVO;
        protected ITTLabel labelsaglikTesisKoduIlacAraGirisDVO;
        protected ITTLabel labelraporTarihiEtkinMaddeSUTGirisDVO;
        protected ITTDateTimePicker raporTarihiDateTimePicker;
        override protected void InitializeControls()
        {
            raporTarihiEtkinMaddeSUTGirisDVO = (ITTTextBox)AddControl(new Guid("b78b4c60-945d-4dee-a644-f2208fc882bb"));
            labeletkinMaddeKoduEtkinMaddeSUTGirisDVO = (ITTLabel)AddControl(new Guid("40c08d4b-c6fd-4662-8de6-0f9b3b255789"));
            etkinMaddeKoduEtkinMaddeSUTGirisDVO = (ITTValueListBox)AddControl(new Guid("d4f7ad89-15ee-4604-8ac3-17fea80a8ca2"));
            saglikTesisKoduIlacAraGirisDVO = (ITTValueListBox)AddControl(new Guid("7fde372d-e4d1-402c-8f37-e4bc9624feda"));
            labelsaglikTesisKoduIlacAraGirisDVO = (ITTLabel)AddControl(new Guid("0dccfdf8-00cd-4dc5-877d-9cca6915407d"));
            labelraporTarihiEtkinMaddeSUTGirisDVO = (ITTLabel)AddControl(new Guid("332d5ad4-6a5c-4b9d-8b0a-62e5fa7d01cf"));
            raporTarihiDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("89c1f95f-55d9-408a-94e6-2d5294fb9b83"));
            base.InitializeControls();
        }

        public BaseEtkinMaddeSutKuraliGetirForm() : base("ETKINMADDESUTKURALIGETIR", "BaseEtkinMaddeSutKuraliGetirForm")
        {
        }

        protected BaseEtkinMaddeSutKuraliGetirForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}