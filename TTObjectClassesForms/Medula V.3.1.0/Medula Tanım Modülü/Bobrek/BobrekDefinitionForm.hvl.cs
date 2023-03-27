
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
    public partial class BobrekDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.Bobrek _Bobrek
        {
            get { return (TTObjectClasses.Bobrek)_ttObject; }
        }

        protected ITTLabel labelbobrekKodu;
        protected ITTTextBox bobrekKodu;
        protected ITTLabel labelbobrekAdi;
        protected ITTTextBox bobrekAdi;
        override protected void InitializeControls()
        {
            labelbobrekKodu = (ITTLabel)AddControl(new Guid("41ab25bb-65fd-42a6-a40a-5d90588543bf"));
            bobrekKodu = (ITTTextBox)AddControl(new Guid("ed9f45da-69de-4c9c-bb6a-f2b933def18d"));
            labelbobrekAdi = (ITTLabel)AddControl(new Guid("97129abd-4ae0-4449-9ed0-285868b18a28"));
            bobrekAdi = (ITTTextBox)AddControl(new Guid("410476c4-26dc-48e8-8e36-7592c1dca6c1"));
            base.InitializeControls();
        }

        public BobrekDefinitionForm() : base("BOBREK", "BobrekDefinitionForm")
        {
        }

        protected BobrekDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}