
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
    /// Yeni Donör Hasta Kabul
    /// </summary>
    public partial class YeniDonorHastaKabulForm : BaseHastaKabulForm
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
            groupboxDonorBilgisi = (ITTGroupBox)AddControl(new Guid("0b6f530d-6eec-453a-9482-74b85f98d220"));
            labeldonorTCKimlikNo = (ITTLabel)AddControl(new Guid("ea010a48-a897-4936-8d4d-c2d3b8804114"));
            donorTCKimlikNo = (ITTTextBox)AddControl(new Guid("d590ad10-e898-43ef-aa5b-42ab5e051e76"));
            base.InitializeControls();
        }

        public YeniDonorHastaKabulForm() : base("YENIDONORHASTAKABUL", "YeniDonorHastaKabulForm")
        {
        }

        protected YeniDonorHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}