
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
    public partial class SevkVasitasiDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sevk Vasıtası
    /// </summary>
        protected TTObjectClasses.SevkVasitasi _SevkVasitasi
        {
            get { return (TTObjectClasses.SevkVasitasi)_ttObject; }
        }

        protected ITTLabel labelsevkVasitasiKodu;
        protected ITTTextBox sevkVasitasiKodu;
        protected ITTTextBox sevkVasitasiAdi;
        protected ITTLabel labelsevkVasitasiAdi;
        override protected void InitializeControls()
        {
            labelsevkVasitasiKodu = (ITTLabel)AddControl(new Guid("c6d8ff84-a07d-4265-a301-5e98235113c3"));
            sevkVasitasiKodu = (ITTTextBox)AddControl(new Guid("e1854ac7-8d62-41ac-8ba0-9e52c1bd1fe0"));
            sevkVasitasiAdi = (ITTTextBox)AddControl(new Guid("1004657b-f44a-423c-b749-708f9b11c912"));
            labelsevkVasitasiAdi = (ITTLabel)AddControl(new Guid("cd1be43c-7a38-4de7-9a0e-8594b707b45e"));
            base.InitializeControls();
        }

        public SevkVasitasiDefinitionForm() : base("SEVKVASITASI", "SevkVasitasiDefinitionForm")
        {
        }

        protected SevkVasitasiDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}