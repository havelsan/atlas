
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
    public partial class DisTaahhutSilForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.DisTaahhutSil _DisTaahhutSil
        {
            get { return (TTObjectClasses.DisTaahhutSil)_ttObject; }
        }

        protected ITTLabel labeltaahhutNoTaahhutOkuDVO;
        protected ITTTextBox taahhutNoTaahhutOkuDVO;
        protected ITTValueListBox saglikTesisKoduTaahhutKayitDVO;
        protected ITTLabel labelsaglikTesisKoduTaahhutKayitDVO;
        override protected void InitializeControls()
        {
            labeltaahhutNoTaahhutOkuDVO = (ITTLabel)AddControl(new Guid("07b3d739-29d6-4a84-b2db-4d9584ff17a2"));
            taahhutNoTaahhutOkuDVO = (ITTTextBox)AddControl(new Guid("17734b13-a847-4120-9e7a-f3e1247ba473"));
            saglikTesisKoduTaahhutKayitDVO = (ITTValueListBox)AddControl(new Guid("0a8087b6-3d8d-49cb-926b-f1c78a72f0af"));
            labelsaglikTesisKoduTaahhutKayitDVO = (ITTLabel)AddControl(new Guid("a79f2c04-8eca-42a4-82b0-5f08e640af04"));
            base.InitializeControls();
        }

        public DisTaahhutSilForm() : base("DISTAAHHUTSIL", "DisTaahhutSilForm")
        {
        }

        protected DisTaahhutSilForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}