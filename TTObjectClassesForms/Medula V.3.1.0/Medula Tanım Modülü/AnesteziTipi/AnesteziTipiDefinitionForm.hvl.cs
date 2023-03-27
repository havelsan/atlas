
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
    public partial class AnesteziTipiDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.AnesteziTipi _AnesteziTipi
        {
            get { return (TTObjectClasses.AnesteziTipi)_ttObject; }
        }

        protected ITTLabel labelanesteziTipiKodu;
        protected ITTTextBox anesteziTipiKodu;
        protected ITTTextBox anesteziTipiAdi;
        protected ITTLabel labelanesteziTipiAdi;
        override protected void InitializeControls()
        {
            labelanesteziTipiKodu = (ITTLabel)AddControl(new Guid("5a60acf7-90ff-4c04-8504-1eefb2eb8e9d"));
            anesteziTipiKodu = (ITTTextBox)AddControl(new Guid("8286e7d2-9a78-4a50-88a0-cca8d0c32125"));
            anesteziTipiAdi = (ITTTextBox)AddControl(new Guid("d5a1e246-c281-4340-8d60-3b198cfdda8c"));
            labelanesteziTipiAdi = (ITTLabel)AddControl(new Guid("34516087-0e64-4fb8-b277-562305f0d723"));
            base.InitializeControls();
        }

        public AnesteziTipiDefinitionForm() : base("ANESTEZITIPI", "AnesteziTipiDefinitionForm")
        {
        }

        protected AnesteziTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}