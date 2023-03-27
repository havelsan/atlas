
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
    public partial class BloodBankBloodProducts_CokluOzelDurumForm : TTForm
    {
    /// <summary>
    /// Kan Ürünleri(Testler)
    /// </summary>
        protected TTObjectClasses.BloodBankBloodProducts _BloodBankBloodProducts
        {
            get { return (TTObjectClasses.BloodBankBloodProducts)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("28681df7-5fd1-4b99-a8de-cdd2c69f720d"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("fa743556-a5f7-49f7-9092-49f3875c874a"));
            base.InitializeControls();
        }

        public BloodBankBloodProducts_CokluOzelDurumForm() : base("BLOODBANKBLOODPRODUCTS", "BloodBankBloodProducts_CokluOzelDurumForm")
        {
        }

        protected BloodBankBloodProducts_CokluOzelDurumForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}