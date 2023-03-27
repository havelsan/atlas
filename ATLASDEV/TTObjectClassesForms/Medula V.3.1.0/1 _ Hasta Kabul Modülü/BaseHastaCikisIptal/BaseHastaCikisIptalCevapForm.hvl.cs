
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
    /// BaseHastaCikisIptalCevapForm
    /// </summary>
    public partial class BaseHastaCikisIptalCevapForm : BaseHastaCikisIptalForm
    {
        protected TTObjectClasses.BaseHastaCikisIptal _BaseHastaCikisIptal
        {
            get { return (TTObjectClasses.BaseHastaCikisIptal)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labelyatisBitisTarihi;
        protected ITTTextBox yatisBitisTarihi;
        protected ITTLabel labelyatisBaslangicTarihi;
        protected ITTTextBox yatisBaslangicTarihi;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTLabel labelsonucKodu;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("1068706a-336a-40f6-bafb-dc90573568ea"));
            labelyatisBitisTarihi = (ITTLabel)AddControl(new Guid("e91700e1-b314-4b09-af7a-01f160363f31"));
            yatisBitisTarihi = (ITTTextBox)AddControl(new Guid("9b7cc173-44a9-4b69-8c00-60c8bfba8194"));
            labelyatisBaslangicTarihi = (ITTLabel)AddControl(new Guid("719d94e5-8f4b-4062-a22b-56c9fee55064"));
            yatisBaslangicTarihi = (ITTTextBox)AddControl(new Guid("16228fac-dc49-44f0-8562-f0a1cd6588a1"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("3d455ad5-e031-40fa-8312-bc5361fba634"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("0e05a709-a83e-4eae-8602-44a79c5571f1"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("b0de5d97-5039-47e3-905d-b58a0f3e5bc7"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("f7ea1f6f-c878-4719-a8b3-2d61e50ec0d0"));
            base.InitializeControls();
        }

        public BaseHastaCikisIptalCevapForm() : base("BASEHASTACIKISIPTAL", "BaseHastaCikisIptalCevapForm")
        {
        }

        protected BaseHastaCikisIptalCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}