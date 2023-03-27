
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
    /// <summary>
    /// İlaç / Etken Madde Sorgulama Formu
    /// </summary>
    public partial class EtkenMaddeIlacSorgulamaFormu : TTUnboundForm
    {
        protected ITTGrid gridEtkinMaddeler;
        protected ITTTextBoxColumn txtGridEtkinMaddeKodu;
        protected ITTTextBoxColumn txtGridEtkinMaddeAdi;
        protected ITTButton btnEtkinMaddeAra;
        protected ITTLabel ttlabel2;
        protected ITTGrid gridIlaclar;
        protected ITTTextBoxColumn txtGridBarcode;
        protected ITTTextBoxColumn txtIlacAdi;
        protected ITTButton btnIlacAra;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox lstEtkinMadde;
        protected ITTObjectListBox lstIlac;
        override protected void InitializeControls()
        {
            gridEtkinMaddeler = (ITTGrid)AddControl(new Guid("de006bcd-de1b-4471-8dd2-535b0174ef69"));
            txtGridEtkinMaddeKodu = (ITTTextBoxColumn)AddControl(new Guid("de89bfa5-4b26-4fc6-ad34-e352425e5e6b"));
            txtGridEtkinMaddeAdi = (ITTTextBoxColumn)AddControl(new Guid("a12a20cb-4932-4c0f-bd1f-30015154c2e4"));
            btnEtkinMaddeAra = (ITTButton)AddControl(new Guid("3e42cf06-5171-457f-966e-11d79c09486f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e532a157-b7fd-4dd9-b7de-26cf8745631e"));
            gridIlaclar = (ITTGrid)AddControl(new Guid("aeb70535-8d88-41ec-b997-f6ed45595461"));
            txtGridBarcode = (ITTTextBoxColumn)AddControl(new Guid("0577b07e-9bac-4b5a-bc26-39a10dadc114"));
            txtIlacAdi = (ITTTextBoxColumn)AddControl(new Guid("0a6fa688-1b78-47b9-9c92-e72f97e9dadb"));
            btnIlacAra = (ITTButton)AddControl(new Guid("dd568707-45c1-4ce1-acdf-6d3f0650ec3f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ec7ce431-7b20-42e4-b278-baaf4ed2e00d"));
            lstEtkinMadde = (ITTObjectListBox)AddControl(new Guid("66a7446a-73ad-4064-80e2-97418a8d8910"));
            lstIlac = (ITTObjectListBox)AddControl(new Guid("82d267d5-389f-4481-a66f-43467983480a"));
            base.InitializeControls();
        }

        public EtkenMaddeIlacSorgulamaFormu() : base("EtkenMaddeIlacSorgulamaFormu")
        {
        }

        protected EtkenMaddeIlacSorgulamaFormu(string formDefName) : base(formDefName)
        {
        }
    }
}