
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
    /// Kan Ürünü Detay Açıklama Formu
    /// </summary>
    public partial class BloodBankProductInfoForm : TTForm
    {
    /// <summary>
    /// Kan Ürünleri(Testler)
    /// </summary>
        protected TTObjectClasses.BloodBankBloodProducts _BloodBankBloodProducts
        {
            get { return (TTObjectClasses.BloodBankBloodProducts)_ttObject; }
        }

        protected ITTTextBox Amount;
        protected ITTLabel labelLamCount;
        protected ITTCheckBox chkIsinlamali;
        protected ITTCheckBox chkFiltrelenmeli;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        override protected void InitializeControls()
        {
            Amount = (ITTTextBox)AddControl(new Guid("feef5348-b51b-4ca9-9ae8-ad4d05b26bdc"));
            labelLamCount = (ITTLabel)AddControl(new Guid("34ad471f-ce6b-4bde-b693-a58678262d7b"));
            chkIsinlamali = (ITTCheckBox)AddControl(new Guid("311ed1c6-aa62-4815-a7b6-f5149e9dd0e1"));
            chkFiltrelenmeli = (ITTCheckBox)AddControl(new Guid("7a9f40ff-b819-45f4-bb35-fce8e3b36e1f"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("a8c1c62f-3512-4c5a-81ba-e900986217bb"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("0e014939-7272-4fcb-a3d9-968d78a86809"));
            base.InitializeControls();
        }

        public BloodBankProductInfoForm() : base("BLOODBANKBLOODPRODUCTS", "BloodBankProductInfoForm")
        {
        }

        protected BloodBankProductInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}