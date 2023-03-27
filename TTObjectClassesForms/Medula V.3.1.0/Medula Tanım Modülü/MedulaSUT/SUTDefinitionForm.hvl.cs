
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
    /// <summary>
    /// SUT Tanımlama
    /// </summary>
    public partial class SUTDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.MedulaSUT _MedulaSUT
        {
            get { return (TTObjectClasses.MedulaSUT)_ttObject; }
        }

        protected ITTCheckBox disTaahhutAlinmalidir;
        protected ITTLabel labelsutKodu;
        protected ITTTextBox sutKodu;
        protected ITTTextBox sutAdi;
        protected ITTLabel labelsutAdi;
        override protected void InitializeControls()
        {
            disTaahhutAlinmalidir = (ITTCheckBox)AddControl(new Guid("26f5e326-a7ef-41d5-89ae-7ef5c278c1e4"));
            labelsutKodu = (ITTLabel)AddControl(new Guid("b61d9d33-4c8b-4039-9562-9aa52bc2a0ba"));
            sutKodu = (ITTTextBox)AddControl(new Guid("bbbed9bc-6cba-415a-83f4-6f17b62950a9"));
            sutAdi = (ITTTextBox)AddControl(new Guid("f5064cb4-076a-45ec-bf4a-d326749b0349"));
            labelsutAdi = (ITTLabel)AddControl(new Guid("7149816b-c581-4628-929f-b9a2fcc2f3a8"));
            base.InitializeControls();
        }

        public SUTDefinitionForm() : base("MEDULASUT", "SUTDefinitionForm")
        {
        }

        protected SUTDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}