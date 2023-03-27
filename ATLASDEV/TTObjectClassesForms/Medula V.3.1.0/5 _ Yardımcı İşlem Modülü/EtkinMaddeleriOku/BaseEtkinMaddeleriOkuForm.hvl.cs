
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
    public partial class BaseEtkinMaddeleriOkuForm : BaseMedulaDefinitionActionForm
    {
        protected TTObjectClasses.EtkinMaddeleriOku _EtkinMaddeleriOku
        {
            get { return (TTObjectClasses.EtkinMaddeleriOku)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKoduIlacAraGirisDVO;
        protected ITTValueListBox saglikTesisKoduIlacAraGirisDVO;
        override protected void InitializeControls()
        {
            labelsaglikTesisKoduIlacAraGirisDVO = (ITTLabel)AddControl(new Guid("66676982-45c7-4394-a457-f2d75751d5cb"));
            saglikTesisKoduIlacAraGirisDVO = (ITTValueListBox)AddControl(new Guid("d8fef28e-37fa-4c8d-a274-cf9fd603b143"));
            base.InitializeControls();
        }

        public BaseEtkinMaddeleriOkuForm() : base("ETKINMADDELERIOKU", "BaseEtkinMaddeleriOkuForm")
        {
        }

        protected BaseEtkinMaddeleriOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}