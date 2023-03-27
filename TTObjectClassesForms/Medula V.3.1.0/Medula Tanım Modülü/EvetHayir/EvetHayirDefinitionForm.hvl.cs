
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
    public partial class EvetHayirDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.EvetHayir _EvetHayir
        {
            get { return (TTObjectClasses.EvetHayir)_ttObject; }
        }

        protected ITTLabel labelevetHayirAdi;
        protected ITTTextBox evetHayirAdi;
        protected ITTTextBox evetHayirKodu;
        protected ITTLabel labelevetHayirKodu;
        override protected void InitializeControls()
        {
            labelevetHayirAdi = (ITTLabel)AddControl(new Guid("8fd4a368-f854-4ccc-bdb9-50e2b9155562"));
            evetHayirAdi = (ITTTextBox)AddControl(new Guid("6045c366-d71d-419f-a6be-10af7bebd45d"));
            evetHayirKodu = (ITTTextBox)AddControl(new Guid("b2389e6f-f400-4fcd-9532-aee5051f3ea3"));
            labelevetHayirKodu = (ITTLabel)AddControl(new Guid("a8b1f588-52fb-477c-837e-db916ab7c279"));
            base.InitializeControls();
        }

        public EvetHayirDefinitionForm() : base("EVETHAYIR", "EvetHayirDefinitionForm")
        {
        }

        protected EvetHayirDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}