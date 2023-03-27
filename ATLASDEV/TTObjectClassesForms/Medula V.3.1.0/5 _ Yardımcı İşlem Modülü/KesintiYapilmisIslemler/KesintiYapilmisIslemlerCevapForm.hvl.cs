
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
    public partial class KesintiYapilmisIslemlerCevapForm : BaseKesintiYapilmisIslemlerForm
    {
        protected TTObjectClasses.KesintiYapilmisIslemler _KesintiYapilmisIslemler
        {
            get { return (TTObjectClasses.KesintiYapilmisIslemler)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox tupBebekKatilimTutariEvrakKesintiCevapDVO;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelevrakKesintiIslemEvrakKesintiIslemDVO;
        protected ITTGrid evrakKesintiIslemEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn takipNoEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn islemSiraNoEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn islemTarihiEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn sutKoduEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn islemAdiEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn tutarEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn kesintiTutariEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn aciklamaEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn grupTuruEvrakKesintiIslemDVO;
        protected ITTTextBoxColumn grupAdiEvrakKesintiIslemDVO;
        protected ITTDateTimePickerColumn CreationDateEvrakKesintiIslemDVO;
        protected ITTTextBox muayeneKatilimTutariEvrakKesintiCevapDVO;
        protected ITTLabel labelsonucKodu;
        protected ITTLabel labeltupBebekKatilimTutariEvrakKesintiCevapDVO;
        protected ITTTextBox malzemeKatilimTutariEvrakKesintiCevapDVO;
        protected ITTLabel labelevrakRefNoEvrakKesintiCevapDVO;
        protected ITTTextBox evrakRefNoEvrakKesintiCevapDVO;
        protected ITTLabel labelmuayeneKatilimTutariEvrakKesintiCevapDVO;
        protected ITTLabel labelmalzemeKatilimTutariEvrakKesintiCevapDVO;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("959b2ca7-01b1-49c4-a77e-f82a7e587da1"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("cf9ee591-51d2-4d22-bc86-7ddc3507685c"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("372366c1-8003-45a8-a361-0423062f58f6"));
            tupBebekKatilimTutariEvrakKesintiCevapDVO = (ITTTextBox)AddControl(new Guid("fb5f5d02-eacb-4881-8b9f-392bf41fd4bb"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("42da98e3-b728-480e-8899-98950ac12995"));
            labelevrakKesintiIslemEvrakKesintiIslemDVO = (ITTLabel)AddControl(new Guid("b7256e9a-e8af-442c-a22c-a939639047a1"));
            evrakKesintiIslemEvrakKesintiIslemDVO = (ITTGrid)AddControl(new Guid("b59ce6a0-c7db-4134-bb13-4697ac622804"));
            takipNoEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("c3e88ad5-94ca-4de9-bd75-96178502892d"));
            islemSiraNoEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("113e0da4-d945-44eb-b840-21613d50e365"));
            islemTarihiEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("4d7cbef2-c0fe-4af9-a2cc-971326c02efb"));
            sutKoduEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("c62cbc17-6bbc-4a1e-9f2a-885b8eaeb185"));
            islemAdiEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("3c9c6396-834b-4c74-93e0-38f4ae89e5ac"));
            tutarEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("86292b57-983f-4169-8051-9960d2f78881"));
            kesintiTutariEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("66b4a4a6-e699-4cb0-8eb0-607aee867d78"));
            aciklamaEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("e8ac7dc9-5fdc-4a61-8a7c-cc853c669e97"));
            grupTuruEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("ea1b8c4e-c886-4d65-af18-064c4698d9c3"));
            grupAdiEvrakKesintiIslemDVO = (ITTTextBoxColumn)AddControl(new Guid("999aaf43-0a82-48f9-af5d-bc7b77dda4fc"));
            CreationDateEvrakKesintiIslemDVO = (ITTDateTimePickerColumn)AddControl(new Guid("8cd0fd34-9b06-460d-99e9-257cc4bd1f79"));
            muayeneKatilimTutariEvrakKesintiCevapDVO = (ITTTextBox)AddControl(new Guid("0eeff26c-2336-4145-bccf-75ea845b136d"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("a66d767b-5bfe-4d91-b4aa-30d4a530f364"));
            labeltupBebekKatilimTutariEvrakKesintiCevapDVO = (ITTLabel)AddControl(new Guid("83c939f7-20b3-48a0-9ee3-0d9ad13f22e6"));
            malzemeKatilimTutariEvrakKesintiCevapDVO = (ITTTextBox)AddControl(new Guid("b930f566-26a8-4d86-9c33-33e53f351cd4"));
            labelevrakRefNoEvrakKesintiCevapDVO = (ITTLabel)AddControl(new Guid("32240fd4-6cdf-4b84-81ac-e576e4caeed7"));
            evrakRefNoEvrakKesintiCevapDVO = (ITTTextBox)AddControl(new Guid("c3019b0c-9d9f-43e8-8b70-33620005f174"));
            labelmuayeneKatilimTutariEvrakKesintiCevapDVO = (ITTLabel)AddControl(new Guid("8b06faad-3bda-41c0-ac49-fd34c4310ab0"));
            labelmalzemeKatilimTutariEvrakKesintiCevapDVO = (ITTLabel)AddControl(new Guid("5722bd3d-f608-4ccc-8225-7b007e95e40e"));
            base.InitializeControls();
        }

        public KesintiYapilmisIslemlerCevapForm() : base("KESINTIYAPILMISISLEMLER", "KesintiYapilmisIslemlerCevapForm")
        {
        }

        protected KesintiYapilmisIslemlerCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}