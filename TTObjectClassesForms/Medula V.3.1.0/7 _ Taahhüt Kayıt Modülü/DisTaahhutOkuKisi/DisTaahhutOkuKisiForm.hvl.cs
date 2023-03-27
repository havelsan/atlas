
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
    public partial class DisTaahhutOkuKisiForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.DisTaahhutOkuKisi _DisTaahhutOkuKisi
        {
            get { return (TTObjectClasses.DisTaahhutOkuKisi)_ttObject; }
        }

        protected ITTLabel labeltcKimlikNoTaahhutKisiOkuDVO;
        protected ITTTextBox tcKimlikNoTaahhutKisiOkuDVO;
        protected ITTValueListBox saglikTesisKoduTaahhutKayitDVO;
        protected ITTLabel labelsaglikTesisKoduTaahhutKayitDVO;
        override protected void InitializeControls()
        {
            labeltcKimlikNoTaahhutKisiOkuDVO = (ITTLabel)AddControl(new Guid("4096f386-66b5-4580-bb5c-60ff6af6b009"));
            tcKimlikNoTaahhutKisiOkuDVO = (ITTTextBox)AddControl(new Guid("2e781164-caf2-42cc-97e9-96621f524fc7"));
            saglikTesisKoduTaahhutKayitDVO = (ITTValueListBox)AddControl(new Guid("e92b0436-2e44-4680-8c28-2dd4b0bd6155"));
            labelsaglikTesisKoduTaahhutKayitDVO = (ITTLabel)AddControl(new Guid("7da74dfb-371f-4a1d-ae97-ccc21a2a04c9"));
            base.InitializeControls();
        }

        public DisTaahhutOkuKisiForm() : base("DISTAAHHUTOKUKISI", "DisTaahhutOkuKisiForm")
        {
        }

        protected DisTaahhutOkuKisiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}