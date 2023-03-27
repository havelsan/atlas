
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
    public partial class BaseKatilimPayiUcretiForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.KatilimPayiUcreti _KatilimPayiUcreti
        {
            get { return (TTObjectClasses.KatilimPayiUcreti)_ttObject; }
        }

        protected ITTLabel labelevrakRefNoKatilimPayiGirisDVO;
        protected ITTTextBox evrakRefNoKatilimPayiGirisDVO;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelsaglikTesisKodu;
        override protected void InitializeControls()
        {
            labelevrakRefNoKatilimPayiGirisDVO = (ITTLabel)AddControl(new Guid("6f4418cb-8105-4dae-b75b-9b7d018561b0"));
            evrakRefNoKatilimPayiGirisDVO = (ITTTextBox)AddControl(new Guid("7fc98e70-3654-4a03-ae39-fa69ae70fdf0"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("0f856805-fbe8-4d2e-a41e-126ba4bd915b"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("75c17b69-1a01-45a8-b121-9e0e2984cbfc"));
            base.InitializeControls();
        }

        public BaseKatilimPayiUcretiForm() : base("KATILIMPAYIUCRETI", "BaseKatilimPayiUcretiForm")
        {
        }

        protected BaseKatilimPayiUcretiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}