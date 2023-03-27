
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
    /// Provizyon Tipi Tanımlama
    /// </summary>
    public partial class ProvizyonTipiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Provizyon Tipi
    /// </summary>
        protected TTObjectClasses.ProvizyonTipi _ProvizyonTipi
        {
            get { return (TTObjectClasses.ProvizyonTipi)_ttObject; }
        }

        protected ITTLabel labelprovizyonTipiKodu;
        protected ITTTextBox provizyonTipiKodu;
        protected ITTLabel labelprovizyonTipiAdi;
        protected ITTTextBox provizyonTipiAdi;
        override protected void InitializeControls()
        {
            labelprovizyonTipiKodu = (ITTLabel)AddControl(new Guid("51813c3e-d97a-4258-8927-cc5838e6300f"));
            provizyonTipiKodu = (ITTTextBox)AddControl(new Guid("ac74c030-4716-4545-b7b8-ddfbd57bc60d"));
            labelprovizyonTipiAdi = (ITTLabel)AddControl(new Guid("bfc98273-4e5a-4f37-8190-448eb9a25eb2"));
            provizyonTipiAdi = (ITTTextBox)AddControl(new Guid("fda248f5-1a27-4671-8fb1-bd2c3523fffa"));
            base.InitializeControls();
        }

        public ProvizyonTipiDefinitionForm() : base("PROVIZYONTIPI", "ProvizyonTipiDefinitionForm")
        {
        }

        protected ProvizyonTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}