
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
    /// Yeni Donör Hasta Kabul Cevap
    /// </summary>
    public partial class YeniDonorHastaKabulCevapForm : BaseHastaKabulCevapForm
    {
    /// <summary>
    /// Yeni Donör Hasta Kabul
    /// </summary>
        protected TTObjectClasses.YeniDonorHastaKabul _YeniDonorHastaKabul
        {
            get { return (TTObjectClasses.YeniDonorHastaKabul)_ttObject; }
        }

        protected ITTGroupBox groupboxDonorBilgisi;
        protected ITTLabel labeldonorTCKimlikNo;
        protected ITTTextBox donorTCKimlikNo;
        override protected void InitializeControls()
        {
            groupboxDonorBilgisi = (ITTGroupBox)AddControl(new Guid("4256dd45-415a-44b6-b59c-03c5ecdb5fb0"));
            labeldonorTCKimlikNo = (ITTLabel)AddControl(new Guid("b7c308e3-d840-4a7f-8693-e77283547b58"));
            donorTCKimlikNo = (ITTTextBox)AddControl(new Guid("2f973dab-e80d-4ece-b765-545364dc64fe"));
            base.InitializeControls();
        }

        public YeniDonorHastaKabulCevapForm() : base("YENIDONORHASTAKABUL", "YeniDonorHastaKabulCevapForm")
        {
        }

        protected YeniDonorHastaKabulCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}