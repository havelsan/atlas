
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
    public partial class DisTaahhutSilCevapForm : DisTaahhutSilForm
    {
        protected TTObjectClasses.DisTaahhutSil _DisTaahhutSil
        {
            get { return (TTObjectClasses.DisTaahhutSil)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labeltaahhutNoTaahhutCevapDVO;
        protected ITTTextBox sonucMesaji;
        protected ITTTextBox taahhutNoTaahhutCevapDVO;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("35d98fb7-43c1-43d8-b10f-2bd8da0f2815"));
            labeltaahhutNoTaahhutCevapDVO = (ITTLabel)AddControl(new Guid("28ef5f2a-4eee-4646-8e9a-2cdd15c7f2e8"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("a6364827-dcda-459e-89b9-5703f2a46b0d"));
            taahhutNoTaahhutCevapDVO = (ITTTextBox)AddControl(new Guid("2594de28-5ef5-452b-b508-eb3108f0ff87"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("d354a23c-ab9a-4dd9-bf5c-a336899cbe24"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("9e9957c9-7f46-4b9a-9ab0-2449257b5cd7"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("e1d0892a-58d2-452b-8d94-f06b82cbb97d"));
            base.InitializeControls();
        }

        public DisTaahhutSilCevapForm() : base("DISTAAHHUTSIL", "DisTaahhutSilCevapForm")
        {
        }

        protected DisTaahhutSilCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}