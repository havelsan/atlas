
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
    public partial class MuayeneGirisCevapForm : BaseMuayeneGirisForm
    {
        protected TTObjectClasses.MuayeneGiris _MuayeneGiris
        {
            get { return (TTObjectClasses.MuayeneGiris)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labeltcKimlikNoMuayeneGirisCevapDVO;
        protected ITTTextBox tcKimlikNoMuayeneGirisCevapDVO;
        protected ITTLabel labelmuayeneNoMuayeneGirisCevapDVO;
        protected ITTTextBox muayeneNoMuayeneGirisCevapDVO;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("83f678b0-4a3a-4297-b0f4-f452b570ac2f"));
            labeltcKimlikNoMuayeneGirisCevapDVO = (ITTLabel)AddControl(new Guid("0fdb739d-dea5-413d-8d72-50d64e6d1e31"));
            tcKimlikNoMuayeneGirisCevapDVO = (ITTTextBox)AddControl(new Guid("dfe50110-5f4f-41c6-8c0b-3617e461b59c"));
            labelmuayeneNoMuayeneGirisCevapDVO = (ITTLabel)AddControl(new Guid("aff1f079-5eae-497d-b02f-c88f8a667e9f"));
            muayeneNoMuayeneGirisCevapDVO = (ITTTextBox)AddControl(new Guid("b7993ebe-fb5c-4d51-b74f-c534521ace11"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("9469cb07-cdaf-4791-a500-e4220b5f084a"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("ad81a8c0-d41f-4d40-887e-170f00d0a298"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("a471d5d3-60a4-4d6a-8745-6aa37d4587b6"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("a3a493ed-cd55-4d0f-beac-95895520499b"));
            base.InitializeControls();
        }

        public MuayeneGirisCevapForm() : base("MUAYENEGIRIS", "MuayeneGirisCevapForm")
        {
        }

        protected MuayeneGirisCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}