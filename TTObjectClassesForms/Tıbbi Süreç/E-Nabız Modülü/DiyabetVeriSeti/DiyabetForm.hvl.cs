
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
    public partial class DiyabetForm : TTForm
    {
        protected TTObjectClasses.DiyabetVeriSeti _DiyabetVeriSeti
        {
            get { return (TTObjectClasses.DiyabetVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSDiyabetEgitimi;
        protected ITTObjectListBox SKRSDiyabetEgitimi;
        protected ITTGrid DiyabetKompBilgisi;
        protected ITTListBoxColumn SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi;
        protected ITTLabel labelKilo;
        protected ITTTextBox Kilo;
        protected ITTTextBox Boy;
        protected ITTLabel labelBoy;
        protected ITTLabel labelIlkTaniTarihi;
        protected ITTDateTimePicker IlkTaniTarihi;
        override protected void InitializeControls()
        {
            labelSKRSDiyabetEgitimi = (ITTLabel)AddControl(new Guid("e29d8d84-5e08-484e-a15f-d551bc334db0"));
            SKRSDiyabetEgitimi = (ITTObjectListBox)AddControl(new Guid("9f53d26c-d81c-4f45-806d-16cafeaa9b6d"));
            DiyabetKompBilgisi = (ITTGrid)AddControl(new Guid("0bc1bc36-65a3-4e4a-97bc-19afcf7c93f5"));
            SKRSDiyabetKomplikasyonlariDiyabetKompBilgisi = (ITTListBoxColumn)AddControl(new Guid("c18d7a29-2f4b-4735-bd10-110a4ee6a5e3"));
            labelKilo = (ITTLabel)AddControl(new Guid("df4328a0-128f-4115-9739-929855154c08"));
            Kilo = (ITTTextBox)AddControl(new Guid("54eb9695-e752-4580-abfe-796923472b1c"));
            Boy = (ITTTextBox)AddControl(new Guid("83f0a556-63f6-4fcb-9c10-bae813d1eb9e"));
            labelBoy = (ITTLabel)AddControl(new Guid("9c2486bf-fe3f-4a58-a706-71f6e693f4cf"));
            labelIlkTaniTarihi = (ITTLabel)AddControl(new Guid("5f92be86-92b9-44f6-9b86-8303f61ce745"));
            IlkTaniTarihi = (ITTDateTimePicker)AddControl(new Guid("790040f2-fd3e-41dd-b487-e6492f30f84e"));
            base.InitializeControls();
        }

        public DiyabetForm() : base("DIYABETVERISETI", "DiyabetForm")
        {
        }

        protected DiyabetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}