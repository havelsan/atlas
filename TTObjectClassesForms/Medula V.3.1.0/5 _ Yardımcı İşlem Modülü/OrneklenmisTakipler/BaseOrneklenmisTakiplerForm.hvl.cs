
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
    public partial class BaseOrneklenmisTakiplerForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Örneklenmiş Takipler
    /// </summary>
        protected TTObjectClasses.OrneklenmisTakipler _OrneklenmisTakipler
        {
            get { return (TTObjectClasses.OrneklenmisTakipler)_ttObject; }
        }

        protected ITTLabel labelevrakIdOrneklenmisTakiplerGirisDVO;
        protected ITTTextBox evrakIdOrneklenmisTakiplerGirisDVO;
        protected ITTLabel labelsaglikTesisKodu;
        protected ITTValueListBox saglikTesisKodu;
        override protected void InitializeControls()
        {
            labelevrakIdOrneklenmisTakiplerGirisDVO = (ITTLabel)AddControl(new Guid("1fe012ae-ede7-459e-a47d-0913a256ff52"));
            evrakIdOrneklenmisTakiplerGirisDVO = (ITTTextBox)AddControl(new Guid("81fe4f5c-4884-4542-8963-4cee88628088"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("fce7319c-9b47-4cca-a0fd-1ead720f1661"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("7df111ae-1cda-4421-9592-ed345f92edb1"));
            base.InitializeControls();
        }

        public BaseOrneklenmisTakiplerForm() : base("ORNEKLENMISTAKIPLER", "BaseOrneklenmisTakiplerForm")
        {
        }

        protected BaseOrneklenmisTakiplerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}