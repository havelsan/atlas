
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
    public partial class BaseTeshisleriOkuForm : BaseMedulaDefinitionActionForm
    {
        protected TTObjectClasses.TeshisleriOku _TeshisleriOku
        {
            get { return (TTObjectClasses.TeshisleriOku)_ttObject; }
        }

        protected ITTValueListBox saglikTesisKoduIlacAraGirisDVO;
        protected ITTLabel labelsaglikTesisKoduIlacAraGirisDVO;
        override protected void InitializeControls()
        {
            saglikTesisKoduIlacAraGirisDVO = (ITTValueListBox)AddControl(new Guid("254dddee-f751-4d07-a2aa-fcebef6bfef6"));
            labelsaglikTesisKoduIlacAraGirisDVO = (ITTLabel)AddControl(new Guid("6cb36ee9-4514-4aef-a3a9-ac80f2b1d43e"));
            base.InitializeControls();
        }

        public BaseTeshisleriOkuForm() : base("TESHISLERIOKU", "BaseTeshisleriOkuForm")
        {
        }

        protected BaseTeshisleriOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}