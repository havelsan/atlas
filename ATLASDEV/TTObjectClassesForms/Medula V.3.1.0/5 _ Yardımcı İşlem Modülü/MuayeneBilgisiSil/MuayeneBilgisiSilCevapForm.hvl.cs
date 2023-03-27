
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
    public partial class MuayeneBilgisiSilCevapForm : BaseMuayeneBilgisiSilForm
    {
        protected TTObjectClasses.MuayeneBilgisiSil _MuayeneBilgisiSil
        {
            get { return (TTObjectClasses.MuayeneBilgisiSil)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelsonucMesajiBaseMedulaCevap;
        protected ITTTextBox sonucMesajiBaseMedulaCevap;
        protected ITTLabel labelsonucKoduBaseMedulaCevap;
        protected ITTTextBox sonucKoduBaseMedulaCevap;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5a084607-63f0-4c4e-aba7-ff2f03f74fef"));
            labelsonucMesajiBaseMedulaCevap = (ITTLabel)AddControl(new Guid("2da4497a-0332-4520-a721-181ededbf682"));
            sonucMesajiBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("998e9195-43d3-40f6-9375-100b45819dd8"));
            labelsonucKoduBaseMedulaCevap = (ITTLabel)AddControl(new Guid("7f44de99-54f5-468a-8ca9-54a3f57185b5"));
            sonucKoduBaseMedulaCevap = (ITTTextBox)AddControl(new Guid("b8e79885-a301-4936-b19f-36dadc266d0a"));
            base.InitializeControls();
        }

        public MuayeneBilgisiSilCevapForm() : base("MUAYENEBILGISISIL", "MuayeneBilgisiSilCevapForm")
        {
        }

        protected MuayeneBilgisiSilCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}