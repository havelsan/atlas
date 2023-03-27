
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
    public partial class KullanimDozBirimDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.KullanimDozBirim _KullanimDozBirim
        {
            get { return (TTObjectClasses.KullanimDozBirim)_ttObject; }
        }

        protected ITTLabel labelkullanimDozBirimAdi;
        protected ITTTextBox kullanimDozBirimAdi;
        protected ITTTextBox kullanimDozBirimKodu;
        protected ITTLabel labelkullanimDozBirimKodu;
        override protected void InitializeControls()
        {
            labelkullanimDozBirimAdi = (ITTLabel)AddControl(new Guid("09f12b53-ff00-446c-962c-1cf3fd07cb9b"));
            kullanimDozBirimAdi = (ITTTextBox)AddControl(new Guid("35dc9c13-d2ae-4ba0-b77c-68f144fd21fa"));
            kullanimDozBirimKodu = (ITTTextBox)AddControl(new Guid("39d17eb7-f033-4bed-bf6a-0905f9fb16d0"));
            labelkullanimDozBirimKodu = (ITTLabel)AddControl(new Guid("3e8c2c20-69ac-45ab-b47f-ecf081e07053"));
            base.InitializeControls();
        }

        public KullanimDozBirimDefinitionForm() : base("KULLANIMDOZBIRIM", "KullanimDozBirimDefinitionForm")
        {
        }

        protected KullanimDozBirimDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}