
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
    /// Takip Tipi Tanımlama
    /// </summary>
    public partial class TakipTipiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Takip Tipi
    /// </summary>
        protected TTObjectClasses.TakipTipi _TakipTipi
        {
            get { return (TTObjectClasses.TakipTipi)_ttObject; }
        }

        protected ITTLabel labeltakipTipiKodu;
        protected ITTTextBox takipTipiKodu;
        protected ITTLabel labeltakipTipiAdi;
        protected ITTTextBox takipTipiAdi;
        override protected void InitializeControls()
        {
            labeltakipTipiKodu = (ITTLabel)AddControl(new Guid("a6e0ad61-40cb-43c0-b86a-f91531e02113"));
            takipTipiKodu = (ITTTextBox)AddControl(new Guid("03d48989-e83a-4462-86e3-6f3edf678edc"));
            labeltakipTipiAdi = (ITTLabel)AddControl(new Guid("4d13f545-7804-41c9-a34c-36d8b66c7cb9"));
            takipTipiAdi = (ITTTextBox)AddControl(new Guid("d1c43287-7436-4d15-b4de-f31825a6092e"));
            base.InitializeControls();
        }

        public TakipTipiDefinitionForm() : base("TAKIPTIPI", "TakipTipiDefinitionForm")
        {
        }

        protected TakipTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}