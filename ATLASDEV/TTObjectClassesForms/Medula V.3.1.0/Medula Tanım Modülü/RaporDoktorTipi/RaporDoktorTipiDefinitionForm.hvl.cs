
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
    public partial class RaporDoktorTipiDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.RaporDoktorTipi _RaporDoktorTipi
        {
            get { return (TTObjectClasses.RaporDoktorTipi)_ttObject; }
        }

        protected ITTLabel labelraporDoktorTipiAdi;
        protected ITTTextBox raporDoktorTipiAdi;
        protected ITTTextBox raporDoktorTipiKodu;
        protected ITTLabel labelraporDoktorTipiKodu;
        override protected void InitializeControls()
        {
            labelraporDoktorTipiAdi = (ITTLabel)AddControl(new Guid("1b383924-915c-479b-8e43-9e15134f5682"));
            raporDoktorTipiAdi = (ITTTextBox)AddControl(new Guid("b24db5e7-3ed8-44c5-a131-77dfaef7ce8e"));
            raporDoktorTipiKodu = (ITTTextBox)AddControl(new Guid("b13dd0b1-81a4-40cc-8677-85c619300f11"));
            labelraporDoktorTipiKodu = (ITTLabel)AddControl(new Guid("482d7dc7-219a-4173-9a17-01efd5407028"));
            base.InitializeControls();
        }

        public RaporDoktorTipiDefinitionForm() : base("RAPORDOKTORTIPI", "RaporDoktorTipiDefinitionForm")
        {
        }

        protected RaporDoktorTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}