
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
    public partial class DogumTipiDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.DogumTipi _DogumTipi
        {
            get { return (TTObjectClasses.DogumTipi)_ttObject; }
        }

        protected ITTLabel labeldogumTipiAdi;
        protected ITTTextBox dogumTipiAdi;
        protected ITTTextBox dogumTipiKodu;
        protected ITTLabel labeldogumTipiKodu;
        override protected void InitializeControls()
        {
            labeldogumTipiAdi = (ITTLabel)AddControl(new Guid("ed1771f8-9e1e-420d-975e-c36e4a03aa2c"));
            dogumTipiAdi = (ITTTextBox)AddControl(new Guid("7ddf1652-83ab-408a-945d-286055a1a1a2"));
            dogumTipiKodu = (ITTTextBox)AddControl(new Guid("b19d2834-8f92-4a19-bb3a-88864bebbdae"));
            labeldogumTipiKodu = (ITTLabel)AddControl(new Guid("393f7b23-6ff4-4318-80a1-73a204236cdf"));
            base.InitializeControls();
        }

        public DogumTipiDefinitionForm() : base("DOGUMTIPI", "DogumTipiDefinitionForm")
        {
        }

        protected DogumTipiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}