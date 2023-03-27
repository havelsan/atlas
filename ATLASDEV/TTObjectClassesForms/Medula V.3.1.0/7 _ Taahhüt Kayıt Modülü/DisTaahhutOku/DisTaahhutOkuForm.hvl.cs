
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
    public partial class DisTaahhutOkuForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.DisTaahhutOku _DisTaahhutOku
        {
            get { return (TTObjectClasses.DisTaahhutOku)_ttObject; }
        }

        protected ITTLabel labeltaahhutNoTaahhutOkuDVO;
        protected ITTTextBox taahhutNoTaahhutOkuDVO;
        protected ITTValueListBox saglikTesisKoduTaahhutKayitDVO;
        protected ITTLabel labelsaglikTesisKoduTaahhutKayitDVO;
        override protected void InitializeControls()
        {
            labeltaahhutNoTaahhutOkuDVO = (ITTLabel)AddControl(new Guid("69391577-bee3-4aa6-9e34-79479592c8a2"));
            taahhutNoTaahhutOkuDVO = (ITTTextBox)AddControl(new Guid("118df73e-3723-4d2b-8761-c5f8ef4d2cb3"));
            saglikTesisKoduTaahhutKayitDVO = (ITTValueListBox)AddControl(new Guid("65287488-c3a7-4319-88a0-98b8306b0184"));
            labelsaglikTesisKoduTaahhutKayitDVO = (ITTLabel)AddControl(new Guid("333e6fc7-95a0-4d09-88fc-dc67455dc4fa"));
            base.InitializeControls();
        }

        public DisTaahhutOkuForm() : base("DISTAAHHUTOKU", "DisTaahhutOkuForm")
        {
        }

        protected DisTaahhutOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}