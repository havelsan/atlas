
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
    /// Tanı Tipi Tanımlama
    /// </summary>
    public partial class TaniTipiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Tanı Tipi
    /// </summary>
        protected TTObjectClasses.TaniTipi _TaniTipi
        {
            get { return (TTObjectClasses.TaniTipi)_ttObject; }
        }

        protected ITTLabel labeltaniTipiKodu;
        protected ITTTextBox taniTipiKodu;
        protected ITTLabel labeltaniTipiAdi;
        protected ITTTextBox taniTipiAdi;
        override protected void InitializeControls()
        {
            labeltaniTipiKodu = (ITTLabel)AddControl(new Guid("1110025b-5d54-4485-a3e3-12a9222a401f"));
            taniTipiKodu = (ITTTextBox)AddControl(new Guid("404f2fd5-f45a-484e-8dab-d2762a0b7332"));
            labeltaniTipiAdi = (ITTLabel)AddControl(new Guid("074bcb65-f58f-4499-957a-8e0978aff2ad"));
            taniTipiAdi = (ITTTextBox)AddControl(new Guid("f530e5a1-1cc6-46d9-b5ac-e3629ccc67c6"));
            base.InitializeControls();
        }

        public TaniTipiDefinitionForm() : base("TANITIPI", "TaniTipiDefinitionForm")
        {
        }

        protected TaniTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}