
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
    public partial class IlceDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.Ilce _Ilce
        {
            get { return (TTObjectClasses.Ilce)_ttObject; }
        }

        protected ITTLabel labelIl;
        protected ITTObjectListBox Il;
        protected ITTLabel labelIlceAdi;
        protected ITTTextBox IlceAdi;
        protected ITTTextBox IlceKodu;
        protected ITTLabel labelIlceKodu;
        override protected void InitializeControls()
        {
            labelIl = (ITTLabel)AddControl(new Guid("e6ae9b41-8012-431a-9595-94fda81033bd"));
            Il = (ITTObjectListBox)AddControl(new Guid("d432d304-a649-42d9-bd1c-7688d01ee0e2"));
            labelIlceAdi = (ITTLabel)AddControl(new Guid("583f7590-4363-4b0c-b3e4-1e22c43b4fb2"));
            IlceAdi = (ITTTextBox)AddControl(new Guid("b5d5e40c-56fd-4e96-8b1c-7644314cc699"));
            IlceKodu = (ITTTextBox)AddControl(new Guid("0f911f7f-976a-4229-a4a9-25e9e4ef9ae5"));
            labelIlceKodu = (ITTLabel)AddControl(new Guid("7d7b861c-c75c-4df5-a13b-2b77c8f58a18"));
            base.InitializeControls();
        }

        public IlceDefinitionForm() : base("ILCE", "IlceDefinitionForm")
        {
        }

        protected IlceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}