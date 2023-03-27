
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
    public partial class DisTaahhutOkuCevapForm : DisTaahhutOkuForm
    {
        protected TTObjectClasses.DisTaahhutOku _DisTaahhutOku
        {
            get { return (TTObjectClasses.DisTaahhutOku)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labeltaahhutNoTaahhutCevapDVO;
        protected ITTTextBox sonucMesaji;
        protected ITTTextBox taahhutNoTaahhutCevapDVO;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        protected ITTLabel adobeStatusLabel;
        protected ITTButton printTaahhut;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("da701299-e772-4f64-81fe-bc18497c1109"));
            labeltaahhutNoTaahhutCevapDVO = (ITTLabel)AddControl(new Guid("74fbb7ff-489f-4450-875f-df8763fc8d90"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("dea989f1-a75a-483c-9fc6-65e8a8f968a2"));
            taahhutNoTaahhutCevapDVO = (ITTTextBox)AddControl(new Guid("339c9121-e68f-48c8-9f6b-771a5de20b96"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("1b26bcd3-08b3-4cfb-93da-77ecda76bd01"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("8147b45f-dfb5-4e74-b002-e343c63506d5"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("36cad8a1-996d-4061-8dfe-15d91f53ad4e"));
            adobeStatusLabel = (ITTLabel)AddControl(new Guid("f8bc29dd-8109-40bf-abc9-a8b1e274282d"));
            printTaahhut = (ITTButton)AddControl(new Guid("671b33d6-f1e0-4e79-a1b1-aecf7b8a5c10"));
            base.InitializeControls();
        }

        public DisTaahhutOkuCevapForm() : base("DISTAAHHUTOKU", "DisTaahhutOkuCevapForm")
        {
        }

        protected DisTaahhutOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}