
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
    public partial class DisTaahhutKayitForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.DisTaahhutKayit _DisTaahhutKayit
        {
            get { return (TTObjectClasses.DisTaahhutKayit)_ttObject; }
        }

        protected ITTObjectListBox IlceTTObjectTaahhutDVO;
        protected ITTObjectListBox IlTTObjectTaahhutDVO;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TaahhutDisDVOTabpage;
        protected ITTGrid taahhutDissTaahhutDisDVO;
        protected ITTListBoxColumn sutKoduTaahhutDisDVO;
        protected ITTTextBoxColumn disNoTaahhutDisDVO;
        protected ITTButtonColumn semadanSec;
        protected ITTTextBox taahhutAlanSoyadTaahhutDVO;
        protected ITTTextBox taahhutAlanAdTaahhutDVO;
        protected ITTTextBox hastaTCKimlikNoTaahhutDVO;
        protected ITTTextBox adressTelefonTaahhutDVO;
        protected ITTTextBox adressPostaKoduTaahhutDVO;
        protected ITTTextBox adressIcKapiNoTaahhutDVO;
        protected ITTTextBox adressEpostaTaahhutDVO;
        protected ITTTextBox adressDisKapiNoTaahhutDVO;
        protected ITTTextBox adressCaddeSokakTaahhutDVO;
        protected ITTTextBox takipNoTaahhutKayitDVO;
        protected ITTLabel labeltaahhutAlanSoyadTaahhutDVO;
        protected ITTLabel labeltaahhutAlanAdTaahhutDVO;
        protected ITTLabel labelhastaTCKimlikNoTaahhutDVO;
        protected ITTLabel labeladressTelefonTaahhutDVO;
        protected ITTLabel labeladressPostaKoduTaahhutDVO;
        protected ITTLabel labeladressIlPlakaTaahhutDVO;
        protected ITTLabel labeladressIlceTaahhutDVO;
        protected ITTLabel labeladressIcKapiNoTaahhutDVO;
        protected ITTLabel labeladressEpostaTaahhutDVO;
        protected ITTLabel labeladressDisKapiNoTaahhutDVO;
        protected ITTLabel labeladressCaddeSokakTaahhutDVO;
        protected ITTLabel labeltakipNoTaahhutKayitDVO;
        protected ITTLabel labelsaglikTesisKoduTaahhutKayitDVO;
        protected ITTValueListBox saglikTesisKoduTaahhutKayitDVO;
        override protected void InitializeControls()
        {
            IlceTTObjectTaahhutDVO = (ITTObjectListBox)AddControl(new Guid("901b7388-cda5-4ce0-ba5d-4124a36c1846"));
            IlTTObjectTaahhutDVO = (ITTObjectListBox)AddControl(new Guid("8e1c6a42-b6d2-4382-9bb1-e0dc9a345c3b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("391af4b4-50c0-4e4c-989f-daa641223dfb"));
            TaahhutDisDVOTabpage = (ITTTabPage)AddControl(new Guid("d6d8adb0-c03b-4b64-8a45-d1333cec2448"));
            taahhutDissTaahhutDisDVO = (ITTGrid)AddControl(new Guid("a4bc1be5-5861-4e1a-bcc8-e9e1f7a597a6"));
            sutKoduTaahhutDisDVO = (ITTListBoxColumn)AddControl(new Guid("18bf8e5b-ff4e-41a2-913b-28779b257e34"));
            disNoTaahhutDisDVO = (ITTTextBoxColumn)AddControl(new Guid("ecfa0f84-40b5-48a0-b7f6-78258ff55892"));
            semadanSec = (ITTButtonColumn)AddControl(new Guid("cdca7f0d-200f-4cdc-b537-061ad7492a97"));
            taahhutAlanSoyadTaahhutDVO = (ITTTextBox)AddControl(new Guid("c1628e83-7da3-4b66-b87b-a35d4039bfb3"));
            taahhutAlanAdTaahhutDVO = (ITTTextBox)AddControl(new Guid("d2281129-a1d3-42e0-9376-00e0e702211b"));
            hastaTCKimlikNoTaahhutDVO = (ITTTextBox)AddControl(new Guid("d529438f-4f78-4406-8194-d42f9c15f68f"));
            adressTelefonTaahhutDVO = (ITTTextBox)AddControl(new Guid("84157c08-4451-453a-a99b-77af2c6b1255"));
            adressPostaKoduTaahhutDVO = (ITTTextBox)AddControl(new Guid("80cfe5d6-8e17-41f5-9075-040e51372054"));
            adressIcKapiNoTaahhutDVO = (ITTTextBox)AddControl(new Guid("9fed748f-3530-481f-8941-d822c52de6a6"));
            adressEpostaTaahhutDVO = (ITTTextBox)AddControl(new Guid("5079dd56-b67b-42ba-ba1e-8c64393890fa"));
            adressDisKapiNoTaahhutDVO = (ITTTextBox)AddControl(new Guid("3395311d-a34d-4e35-b0d0-859dfd6571a3"));
            adressCaddeSokakTaahhutDVO = (ITTTextBox)AddControl(new Guid("30af6457-68c5-444b-a72b-a29bddd425d4"));
            takipNoTaahhutKayitDVO = (ITTTextBox)AddControl(new Guid("0f8d9775-ce24-4fad-95d5-b05c1a54d156"));
            labeltaahhutAlanSoyadTaahhutDVO = (ITTLabel)AddControl(new Guid("bf9e478d-a94d-4002-81ed-f303582603aa"));
            labeltaahhutAlanAdTaahhutDVO = (ITTLabel)AddControl(new Guid("6c589099-62fb-4d72-8fd7-342a9978f20e"));
            labelhastaTCKimlikNoTaahhutDVO = (ITTLabel)AddControl(new Guid("64f0e0bf-16cc-4410-ada4-b1b6314d8995"));
            labeladressTelefonTaahhutDVO = (ITTLabel)AddControl(new Guid("86d03618-1b41-4513-9cfb-e6e728e34625"));
            labeladressPostaKoduTaahhutDVO = (ITTLabel)AddControl(new Guid("40c84422-9a2f-4f63-9831-e4b30c3e38d9"));
            labeladressIlPlakaTaahhutDVO = (ITTLabel)AddControl(new Guid("557013f4-f58c-4f13-a512-8fc827b29b7b"));
            labeladressIlceTaahhutDVO = (ITTLabel)AddControl(new Guid("8e40c841-f18d-4d01-9e80-00658e64b1e1"));
            labeladressIcKapiNoTaahhutDVO = (ITTLabel)AddControl(new Guid("9a265c48-f0d1-496d-8854-35ce6f192a1a"));
            labeladressEpostaTaahhutDVO = (ITTLabel)AddControl(new Guid("0a3481d1-af1b-4bcc-b3ee-3cce93c38fb0"));
            labeladressDisKapiNoTaahhutDVO = (ITTLabel)AddControl(new Guid("f7b5a783-6d22-4a6f-a3ef-02141a83df82"));
            labeladressCaddeSokakTaahhutDVO = (ITTLabel)AddControl(new Guid("6b8875bf-ddc2-47e6-8d40-121c5ea3862a"));
            labeltakipNoTaahhutKayitDVO = (ITTLabel)AddControl(new Guid("8b3a8dc5-0722-4564-9cdb-cffff3c8e17c"));
            labelsaglikTesisKoduTaahhutKayitDVO = (ITTLabel)AddControl(new Guid("efd4d7f2-3814-4135-8d11-aadcce68754d"));
            saglikTesisKoduTaahhutKayitDVO = (ITTValueListBox)AddControl(new Guid("d8e7fb27-6979-4e9e-be6f-b2b3ba486246"));
            base.InitializeControls();
        }

        public DisTaahhutKayitForm() : base("DISTAAHHUTKAYIT", "DisTaahhutKayitForm")
        {
        }

        protected DisTaahhutKayitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}