
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
    /// Hasta Kabul İptal Cevap
    /// </summary>
    public partial class HastaKabulIptalCevapForm : BaseHastaKabulIptalForm
    {
    /// <summary>
    /// Hasta Kabul İptal
    /// </summary>
        protected TTObjectClasses.HastaKabulIptal _HastaKabulIptal
        {
            get { return (TTObjectClasses.HastaKabulIptal)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labeltakipNoCevap;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTTextBox takipNoCevap;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("9f4e2830-411c-4b9e-8501-c48def6250e8"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("2b92300b-2147-45ed-bc80-1ad0401198d5"));
            labeltakipNoCevap = (ITTLabel)AddControl(new Guid("64fee8f5-0c92-4b65-8d5e-1673cbfbd602"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("c550a054-dd14-4cf4-8080-d14196b02cd9"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("d98f0714-ea36-4ed8-a2bb-a29f08323ee0"));
            takipNoCevap = (ITTTextBox)AddControl(new Guid("e83d4bc1-24d6-44ed-93b8-f690182d5835"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("a03fa72a-b04d-4c7b-94b5-2f35fa1087b9"));
            base.InitializeControls();
        }

        public HastaKabulIptalCevapForm() : base("HASTAKABULIPTAL", "HastaKabulIptalCevapForm")
        {
        }

        protected HastaKabulIptalCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}