
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
    /// Geriye Dönük Yatış Kabul Cevap
    /// </summary>
    public partial class GeriyeDonukYatisKabulCevapForm : BaseHastaKabulCevapForm
    {
    /// <summary>
    /// Geriye Dönük Yatış Kabul
    /// </summary>
        protected TTObjectClasses.GeriyeDonukYatisKabul _GeriyeDonukYatisKabul
        {
            get { return (TTObjectClasses.GeriyeDonukYatisKabul)_ttObject; }
        }

        protected ITTGroupBox groupboxYatisBilgisi;
        protected ITTTextBox yatisBitisTarihi;
        protected ITTLabel labelyatisBitisTarihi;
        protected ITTDateTimePicker yatisBitisTarihiDatetimepicker;
        override protected void InitializeControls()
        {
            groupboxYatisBilgisi = (ITTGroupBox)AddControl(new Guid("a8d1965e-6d56-4862-aecb-e2407d64b910"));
            yatisBitisTarihi = (ITTTextBox)AddControl(new Guid("061d642e-626d-402d-9665-d9888862459c"));
            labelyatisBitisTarihi = (ITTLabel)AddControl(new Guid("137c5608-7e5c-4f5e-a4ed-ae751431c323"));
            yatisBitisTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("3f92e000-f65a-42c5-80a2-a36e04ed5243"));
            base.InitializeControls();
        }

        public GeriyeDonukYatisKabulCevapForm() : base("GERIYEDONUKYATISKABUL", "GeriyeDonukYatisKabulCevapForm")
        {
        }

        protected GeriyeDonukYatisKabulCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}