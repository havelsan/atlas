
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
    /// Hasta Kabul Tedavi Tipi Değiştir
    /// </summary>
    public partial class HastaKabulTedaviTipiDegistirForm : BaseHastaKabulOkuForm
    {
    /// <summary>
    /// Hasta Kabul Tedavi Tipi Değiştir
    /// </summary>
        protected TTObjectClasses.HastaKabulTedaviTipiDegistir _HastaKabulTedaviTipiDegistir
        {
            get { return (TTObjectClasses.HastaKabulTedaviTipiDegistir)_ttObject; }
        }

        protected ITTLabel labelyeniTedaviTipi;
        protected ITTListDefComboBox yeniTedaviTipi;
        override protected void InitializeControls()
        {
            labelyeniTedaviTipi = (ITTLabel)AddControl(new Guid("567cb5af-f998-4938-b313-b6fe2196b171"));
            yeniTedaviTipi = (ITTListDefComboBox)AddControl(new Guid("9dd663f7-bb4e-4928-93fb-60e200a6af08"));
            base.InitializeControls();
        }

        public HastaKabulTedaviTipiDegistirForm() : base("HASTAKABULTEDAVITIPIDEGISTIR", "HastaKabulTedaviTipiDegistirForm")
        {
        }

        protected HastaKabulTedaviTipiDegistirForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}