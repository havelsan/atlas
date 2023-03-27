
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
    /// Malzeme Detayları
    /// </summary>
    public partial class CensusFixedMaterialOutForm : BaseStockActionDetailOutForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi - Eksiltilen malzeme detaylarını tutan sınıftır
    /// </summary>
        protected TTObjectClasses.CensusFixedMaterialOut _CensusFixedMaterialOut
        {
            get { return (TTObjectClasses.CensusFixedMaterialOut)_ttObject; }
        }

        protected ITTListBoxColumn FromAccountancy;
        override protected void InitializeControls()
        {
            FromAccountancy = (ITTListBoxColumn)AddControl(new Guid("15e2adc5-bb01-420c-8b6e-367965cae0c2"));
            base.InitializeControls();
        }

        public CensusFixedMaterialOutForm() : base("CENSUSFIXEDMATERIALOUT", "CensusFixedMaterialOutForm")
        {
        }

        protected CensusFixedMaterialOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}