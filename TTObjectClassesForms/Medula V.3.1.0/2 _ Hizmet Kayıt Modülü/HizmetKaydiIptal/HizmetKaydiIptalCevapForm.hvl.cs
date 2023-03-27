
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
    /// Hizmet Kaydı İptal Cevap
    /// </summary>
    public partial class HizmetKaydiIptalCevapForm : HizmetKaydiIptalForm
    {
    /// <summary>
    /// Hizmet Kaydı İptal
    /// </summary>
        protected TTObjectClasses.HizmetKaydiIptal _HizmetKaydiIptal
        {
            get { return (TTObjectClasses.HizmetKaydiIptal)_ttObject; }
        }

        protected ITTTabPage cevapBilgileriTabpage;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            cevapBilgileriTabpage = (ITTTabPage)AddControl(new Guid("eba5af98-aa50-4ff1-8899-3fc5b451b973"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("94fee5ae-f053-4328-a17c-56feaba46dde"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("64280e15-b67c-4f3b-9e4f-4ad70aeeebed"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("1004bc76-9b3c-40b7-9727-12cc88174d96"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("67032198-0e0c-47dc-bf9e-6d2b8de4bf0c"));
            base.InitializeControls();
        }

        public HizmetKaydiIptalCevapForm() : base("HIZMETKAYDIIPTAL", "HizmetKaydiIptalCevapForm")
        {
        }

        protected HizmetKaydiIptalCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}