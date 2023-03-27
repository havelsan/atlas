
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
    /// Özel Durum Tanımlama
    /// </summary>
    public partial class OzelDurumDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.OzelDurum _OzelDurum
        {
            get { return (TTObjectClasses.OzelDurum)_ttObject; }
        }

        protected ITTLabel labelozelDurumKodu;
        protected ITTTextBox ozelDurumKodu;
        protected ITTLabel labelozelDurumAdi;
        protected ITTTextBox ozelDurumAdi;
        override protected void InitializeControls()
        {
            labelozelDurumKodu = (ITTLabel)AddControl(new Guid("4ce790e0-6a9d-4bb4-8104-2e5301a4d1af"));
            ozelDurumKodu = (ITTTextBox)AddControl(new Guid("f0f3d7aa-4bb5-4b4e-a3b3-05170f87f7bd"));
            labelozelDurumAdi = (ITTLabel)AddControl(new Guid("c3f39b03-7d5e-45b7-bd05-79861dffc582"));
            ozelDurumAdi = (ITTTextBox)AddControl(new Guid("1d39d001-d47d-47c7-a41f-007db51a670a"));
            base.InitializeControls();
        }

        public OzelDurumDefinitionForm() : base("OZELDURUM", "OzelDurumDefinitionForm")
        {
        }

        protected OzelDurumDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}