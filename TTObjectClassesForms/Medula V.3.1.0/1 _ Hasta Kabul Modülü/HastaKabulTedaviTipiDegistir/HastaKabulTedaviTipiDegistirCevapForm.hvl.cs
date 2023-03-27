
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
    /// Hasta Kabul Tedavi Tipi Değiştir Cevap
    /// </summary>
    public partial class HastaKabulTedaviTipiDegistirCevapForm : BaseHastaKabulOkuCevapForm
    {
    /// <summary>
    /// Hasta Kabul Tedavi Tipi Değiştir
    /// </summary>
        protected TTObjectClasses.HastaKabulTedaviTipiDegistir _HastaKabulTedaviTipiDegistir
        {
            get { return (TTObjectClasses.HastaKabulTedaviTipiDegistir)_ttObject; }
        }

        protected ITTListDefComboBox yeniTedaviTipi;
        protected ITTLabel labelyeniTedaviTipi;
        override protected void InitializeControls()
        {
            yeniTedaviTipi = (ITTListDefComboBox)AddControl(new Guid("f212c17a-a42d-46bc-94db-ecf7ad2816b8"));
            labelyeniTedaviTipi = (ITTLabel)AddControl(new Guid("467e70c7-c8b7-4f97-8f41-979179b1332a"));
            base.InitializeControls();
        }

        public HastaKabulTedaviTipiDegistirCevapForm() : base("HASTAKABULTEDAVITIPIDEGISTIR", "HastaKabulTedaviTipiDegistirCevapForm")
        {
        }

        protected HastaKabulTedaviTipiDegistirCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}