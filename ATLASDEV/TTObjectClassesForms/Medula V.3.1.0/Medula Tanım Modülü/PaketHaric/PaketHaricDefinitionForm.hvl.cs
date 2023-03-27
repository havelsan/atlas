
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
    /// Paket Hariç Tanımlama
    /// </summary>
    public partial class PaketHaricDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Paket Hariç
    /// </summary>
        protected TTObjectClasses.PaketHaric _PaketHaric
        {
            get { return (TTObjectClasses.PaketHaric)_ttObject; }
        }

        protected ITTLabel labelpaketHaricAdi;
        protected ITTTextBox paketHaricAdi;
        protected ITTLabel labelpaketHaricKodu;
        protected ITTTextBox paketHaricKodu;
        override protected void InitializeControls()
        {
            labelpaketHaricAdi = (ITTLabel)AddControl(new Guid("a37fc9b5-0e27-4235-8359-714d6122894b"));
            paketHaricAdi = (ITTTextBox)AddControl(new Guid("5e5f6991-f97b-47d6-abc7-40d5b823ef37"));
            labelpaketHaricKodu = (ITTLabel)AddControl(new Guid("36c439a5-ce66-461c-a052-fa5fcd9a58d7"));
            paketHaricKodu = (ITTTextBox)AddControl(new Guid("bb4b78fb-cf3d-46e9-98d3-cb53e4a21a9a"));
            base.InitializeControls();
        }

        public PaketHaricDefinitionForm() : base("PAKETHARIC", "PaketHaricDefinitionForm")
        {
        }

        protected PaketHaricDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}