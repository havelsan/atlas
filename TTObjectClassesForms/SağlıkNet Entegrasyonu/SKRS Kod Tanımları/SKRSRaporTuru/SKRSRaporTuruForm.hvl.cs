
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
    /// Rapor türü eşleştirme ekranı
    /// </summary>
    public partial class SKRSRaporTuruForm : BaseSKRSForm
    {
    /// <summary>
    /// 3fb672ac-0675-44ef-9f91-86856dc79370
    /// </summary>
        protected TTObjectClasses.SKRSRaporTuru _SKRSRaporTuru
        {
            get { return (TTObjectClasses.SKRSRaporTuru)_ttObject; }
        }

        protected ITTComboBox ttcombobox1;
        protected ITTTextBox RaporTuru;
        protected ITTTextBox RaporAdi;
        override protected void InitializeControls()
        {
            ttcombobox1 = (ITTComboBox)AddControl(new Guid("8f910071-97bf-416a-88b9-c5da862f327d"));
            RaporTuru = (ITTTextBox)AddControl(new Guid("cda29d7c-47a0-497e-bd12-4c31f9b159a6"));
            RaporAdi = (ITTTextBox)AddControl(new Guid("5a564c98-7580-4096-8282-bc557d27a060"));
            base.InitializeControls();
        }

        public SKRSRaporTuruForm() : base("SKRSRAPORTURU", "SKRSRaporTuruForm")
        {
        }

        protected SKRSRaporTuruForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}