
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
    /// New Form
    /// </summary>
    public partial class FaturalanmaDurumuDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Faturalanma Durumu
    /// </summary>
        protected TTObjectClasses.FaturalanmaDurumu _FaturalanmaDurumu
        {
            get { return (TTObjectClasses.FaturalanmaDurumu)_ttObject; }
        }

        protected ITTLabel labelfaturalanmaDurumuKodu;
        protected ITTTextBox faturalanmaDurumuKodu;
        protected ITTLabel labelfaturalanmaDurumuAdi;
        protected ITTTextBox faturalanmaDurumuAdi;
        override protected void InitializeControls()
        {
            labelfaturalanmaDurumuKodu = (ITTLabel)AddControl(new Guid("4a18b9b4-d4c4-4c93-8b38-8fa224be9dd4"));
            faturalanmaDurumuKodu = (ITTTextBox)AddControl(new Guid("fc7a5994-358e-40b9-ba41-4af669db9b56"));
            labelfaturalanmaDurumuAdi = (ITTLabel)AddControl(new Guid("b56940c9-19b0-4302-937d-51ecde371ce7"));
            faturalanmaDurumuAdi = (ITTTextBox)AddControl(new Guid("a48ec68a-1b6e-46e9-b8b3-c1399a55d7a9"));
            base.InitializeControls();
        }

        public FaturalanmaDurumuDefinitionForm() : base("FATURALANMADURUMU", "FaturalanmaDurumuDefinitionForm")
        {
        }

        protected FaturalanmaDurumuDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}