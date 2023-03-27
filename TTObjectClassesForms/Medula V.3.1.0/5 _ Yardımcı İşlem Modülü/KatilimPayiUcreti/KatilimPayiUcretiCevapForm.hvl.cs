
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
    public partial class KatilimPayiUcretiCevapForm : BaseKatilimPayiUcretiForm
    {
        protected TTObjectClasses.KatilimPayiUcreti _KatilimPayiUcreti
        {
            get { return (TTObjectClasses.KatilimPayiUcreti)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        protected ITTTextBox evrakRefNoKatilimPayiCevapDVO;
        protected ITTGrid katilimPaylariKatilimPayiDVO;
        protected ITTTextBoxColumn takipNoKatilimPayiDVO;
        protected ITTTextBoxColumn malzemeKatilimTutariKatilimPayiDVO;
        protected ITTTextBoxColumn muayeneKatilimTutariKatilimPayiDVO;
        protected ITTTextBoxColumn tupBebekKatilimTutariKatilimPayiDVO;
        protected ITTLabel labelevrakRefNoKatilimPayiCevapDVO;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("99eda848-3b23-49b5-892d-7e539fe89b59"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c515dd95-3dd0-4aa4-8251-bb4aae1e0a1e"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("b5d45bf9-38aa-440b-bd36-3f1a0ac02638"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("2080ecae-7aa4-4acf-995d-c2074e0babd3"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("8e140c6e-e440-49dd-b15b-6a9c5f7a76e5"));
            evrakRefNoKatilimPayiCevapDVO = (ITTTextBox)AddControl(new Guid("2e096213-29b0-4f86-b964-31446ad8c833"));
            katilimPaylariKatilimPayiDVO = (ITTGrid)AddControl(new Guid("f8c3653a-5762-406a-9a0d-fbb3be5f85fe"));
            takipNoKatilimPayiDVO = (ITTTextBoxColumn)AddControl(new Guid("6a3faf6d-aef5-409d-bf38-c5044a053d69"));
            malzemeKatilimTutariKatilimPayiDVO = (ITTTextBoxColumn)AddControl(new Guid("c743475e-2934-4121-a435-4bcac63a4587"));
            muayeneKatilimTutariKatilimPayiDVO = (ITTTextBoxColumn)AddControl(new Guid("56b7606a-23ad-41d2-98c3-672943ed6b6a"));
            tupBebekKatilimTutariKatilimPayiDVO = (ITTTextBoxColumn)AddControl(new Guid("209ddec8-856c-48a6-b7aa-9c1b57ebf884"));
            labelevrakRefNoKatilimPayiCevapDVO = (ITTLabel)AddControl(new Guid("d950dee5-82ba-48ff-91a8-880d144f743d"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("8e2cc268-a121-48b2-bd42-2fbc2b7b2462"));
            base.InitializeControls();
        }

        public KatilimPayiUcretiCevapForm() : base("KATILIMPAYIUCRETI", "KatilimPayiUcretiCevapForm")
        {
        }

        protected KatilimPayiUcretiCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}