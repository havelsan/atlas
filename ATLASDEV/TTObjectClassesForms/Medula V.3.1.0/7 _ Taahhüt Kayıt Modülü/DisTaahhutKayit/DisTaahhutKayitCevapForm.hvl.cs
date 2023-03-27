
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
    public partial class DisTaahhutKayitCevapForm : DisTaahhutKayitForm
    {
        protected TTObjectClasses.DisTaahhutKayit _DisTaahhutKayit
        {
            get { return (TTObjectClasses.DisTaahhutKayit)_ttObject; }
        }

        protected ITTTabPage TaahhutCevapDVOTabpage;
        protected ITTLabel adobeStatusLabel;
        protected ITTButton printTaahhut;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        protected ITTLabel labeltaahhutNoTaahhutCevapDVO;
        protected ITTTextBox taahhutNoTaahhutCevapDVO;
        override protected void InitializeControls()
        {
            TaahhutCevapDVOTabpage = (ITTTabPage)AddControl(new Guid("ca4959e6-a743-48c9-8dba-3d27aae89694"));
            adobeStatusLabel = (ITTLabel)AddControl(new Guid("62e30a23-a2e6-476b-9242-cd689b388090"));
            printTaahhut = (ITTButton)AddControl(new Guid("3f689f26-f8ac-4bc6-ac1b-acab8499ee87"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("965f8abf-d81a-43d1-bdcc-a7efb163f541"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("c82c531e-e71c-4c3b-b19c-2a55d326b015"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("2240ee57-96ec-48f9-9313-d921aa8b763a"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("ea337e67-5163-4972-81df-0f8cf7e05608"));
            labeltaahhutNoTaahhutCevapDVO = (ITTLabel)AddControl(new Guid("4b98e2ae-ac46-44b9-acfe-a35830da13c8"));
            taahhutNoTaahhutCevapDVO = (ITTTextBox)AddControl(new Guid("05b87667-e358-4c22-a570-ae557c8de83b"));
            base.InitializeControls();
        }

        public DisTaahhutKayitCevapForm() : base("DISTAAHHUTKAYIT", "DisTaahhutKayitCevapForm")
        {
        }

        protected DisTaahhutKayitCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}