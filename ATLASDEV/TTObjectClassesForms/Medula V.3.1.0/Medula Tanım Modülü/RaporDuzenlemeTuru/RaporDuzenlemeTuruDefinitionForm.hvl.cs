
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
    public partial class RaporDuzenlemeTuruDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.RaporDuzenlemeTuru _RaporDuzenlemeTuru
        {
            get { return (TTObjectClasses.RaporDuzenlemeTuru)_ttObject; }
        }

        protected ITTLabel labelraporDuzmenlemeTuruKodu;
        protected ITTTextBox raporDuzmenlemeTuruKodu;
        protected ITTTextBox raporDuzmenlemeTuruAdi;
        protected ITTLabel labelraporDuzmenlemeTuruAdi;
        override protected void InitializeControls()
        {
            labelraporDuzmenlemeTuruKodu = (ITTLabel)AddControl(new Guid("a89dea31-30bc-4825-a61c-4cf2e0afb95a"));
            raporDuzmenlemeTuruKodu = (ITTTextBox)AddControl(new Guid("4b8cbe9a-09ff-4dc4-be77-4da02a649fce"));
            raporDuzmenlemeTuruAdi = (ITTTextBox)AddControl(new Guid("c0d17f70-a642-4224-bd79-f78b0ed757e4"));
            labelraporDuzmenlemeTuruAdi = (ITTLabel)AddControl(new Guid("4139c7b3-5511-4082-a56b-2d0670e571e2"));
            base.InitializeControls();
        }

        public RaporDuzenlemeTuruDefinitionForm() : base("RAPORDUZENLEMETURU", "RaporDuzenlemeTuruDefinitionForm")
        {
        }

        protected RaporDuzenlemeTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}