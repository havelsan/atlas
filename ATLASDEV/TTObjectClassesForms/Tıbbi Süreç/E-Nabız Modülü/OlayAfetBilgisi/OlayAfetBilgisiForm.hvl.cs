
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
    public partial class OlayAfetBilgisiForm : TTForm
    {
        protected TTObjectClasses.OlayAfetBilgisi _OlayAfetBilgisi
        {
            get { return (TTObjectClasses.OlayAfetBilgisi)_ttObject; }
        }

        protected ITTLabel labelSKRSHayatiTehlikeDurumu;
        protected ITTObjectListBox SKRSHayatiTehlikeDurumu;
        protected ITTLabel labelSKRSOlayAfetBilgisi;
        protected ITTObjectListBox SKRSOlayAfetBilgisi;
        protected ITTLabel labelSKRSAFETOLAYVATANDASTIPI;
        protected ITTObjectListBox SKRSAFETOLAYVATANDASTIPI;
        protected ITTLabel labelGlasgowKomaSkalasi;
        protected ITTTextBox GlasgowKomaSkalasi;
        override protected void InitializeControls()
        {
            labelSKRSHayatiTehlikeDurumu = (ITTLabel)AddControl(new Guid("ca5f0c44-c335-4d58-ab87-e77df8dc7efc"));
            SKRSHayatiTehlikeDurumu = (ITTObjectListBox)AddControl(new Guid("dcd1dd6f-c954-4306-bd0a-d845cc416a72"));
            labelSKRSOlayAfetBilgisi = (ITTLabel)AddControl(new Guid("b01597a8-bbf9-4f35-949a-89a9ab693a28"));
            SKRSOlayAfetBilgisi = (ITTObjectListBox)AddControl(new Guid("a504ee66-3246-4b6a-a532-b13af60925fa"));
            labelSKRSAFETOLAYVATANDASTIPI = (ITTLabel)AddControl(new Guid("66ebf610-432f-4e65-8402-c1bcaea43735"));
            SKRSAFETOLAYVATANDASTIPI = (ITTObjectListBox)AddControl(new Guid("1bc36f9f-508c-4b2f-8d50-54d08bce017e"));
            labelGlasgowKomaSkalasi = (ITTLabel)AddControl(new Guid("c98915f9-463a-46a4-9228-57d66e375678"));
            GlasgowKomaSkalasi = (ITTTextBox)AddControl(new Guid("cfd65774-0cf2-4bc6-a0d6-359af281ba93"));
            base.InitializeControls();
        }

        public OlayAfetBilgisiForm() : base("OLAYAFETBILGISI", "OlayAfetBilgisiForm")
        {
        }

        protected OlayAfetBilgisiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}