
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
    /// Elektronik Reçete Listele Sorgulama
    /// </summary>
    public partial class EReceteListeSorgulaForm : TTUnboundForm
    {
        protected ITTButton cmdClose;
        protected ITTLabel ttlabel3;
        protected ITTTextBox edtHastaTC;
        protected ITTTextBox edtEreceteNo;
        protected ITTListView EreceteList;
        protected ITTCheckBox checkboxType;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox groupboxHasta;
        protected ITTLabel ttlabel4;
        protected ITTTextBox edtPassword;
        protected ITTTextBox edtDoktorTC;
        protected ITTLabel ttlabel2;
        protected ITTButton ttbutton1;
        protected ITTButton btnIptalEt;
        protected ITTButton btnImzaliIptalEt;
        override protected void InitializeControls()
        {
            cmdClose = (ITTButton)AddControl(new Guid("0f9bab2b-d4e7-48d3-85ad-29814af3ebdb"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("07db9db6-3f34-4852-88c9-391a73b514e2"));
            edtHastaTC = (ITTTextBox)AddControl(new Guid("22bf17fa-d5a3-4363-b716-5932b6231396"));
            edtEreceteNo = (ITTTextBox)AddControl(new Guid("a480526a-ce25-4b51-8e8b-7edd72b5d8ee"));
            EreceteList = (ITTListView)AddControl(new Guid("e53f0168-109f-4dc7-9b19-2b2942811158"));
            checkboxType = (ITTCheckBox)AddControl(new Guid("d64c7d53-4637-4344-9957-8d3bec6aa223"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7de1bd1c-76ec-4578-89bd-b02fc5a671f4"));
            groupboxHasta = (ITTGroupBox)AddControl(new Guid("4975b0b1-0fe6-4dfd-878e-83f45372d117"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0c9904b9-f48c-45b1-b314-413623e4175a"));
            edtPassword = (ITTTextBox)AddControl(new Guid("5898b835-13bf-4ada-a045-4541a1a3a758"));
            edtDoktorTC = (ITTTextBox)AddControl(new Guid("66c5deac-b059-40fd-973b-43da638973a7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5c2b5968-e86e-4c12-ac77-03f4f49ab946"));
            ttbutton1 = (ITTButton)AddControl(new Guid("bd9eeb42-0fdb-45ed-aea0-b56f162aa9d6"));
            btnIptalEt = (ITTButton)AddControl(new Guid("eae0d006-3461-4a41-8bde-ad0aca53d670"));
            btnImzaliIptalEt = (ITTButton)AddControl(new Guid("70f31b61-a3f5-4c4a-8620-9d2604c30907"));
            base.InitializeControls();
        }

        public EReceteListeSorgulaForm() : base("EReceteListeSorgulaForm")
        {
        }

        protected EReceteListeSorgulaForm(string formDefName) : base(formDefName)
        {
        }
    }
}