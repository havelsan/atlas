
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
    /// Tahlil Tipi Tanımlama
    /// </summary>
    public partial class TahlilTipiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Tahlil Tipi
    /// </summary>
        protected TTObjectClasses.TahlilTipi _TahlilTipi
        {
            get { return (TTObjectClasses.TahlilTipi)_ttObject; }
        }

        protected ITTLabel labeltahlilTipKodu;
        protected ITTTextBox tahlilTipKodu;
        override protected void InitializeControls()
        {
            labeltahlilTipKodu = (ITTLabel)AddControl(new Guid("5ab6601e-aa3f-4075-998e-55c49145ffcd"));
            tahlilTipKodu = (ITTTextBox)AddControl(new Guid("b96b81a0-a238-4887-a143-3db386b6f56f"));
            base.InitializeControls();
        }

        public TahlilTipiDefinitionForm() : base("TAHLILTIPI", "TahlilTipiDefinitionForm")
        {
        }

        protected TahlilTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}