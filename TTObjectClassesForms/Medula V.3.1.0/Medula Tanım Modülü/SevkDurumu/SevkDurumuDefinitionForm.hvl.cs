
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
    /// Sevk Durumu Tanımlama
    /// </summary>
    public partial class SevkDurumuDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Sevk Durumu
    /// </summary>
        protected TTObjectClasses.SevkDurumu _SevkDurumu
        {
            get { return (TTObjectClasses.SevkDurumu)_ttObject; }
        }

        protected ITTLabel labelsevkDurumuKodu;
        protected ITTTextBox sevkDurumuKodu;
        protected ITTLabel labelsevkDurumuAdi;
        protected ITTTextBox sevkDurumuAdi;
        override protected void InitializeControls()
        {
            labelsevkDurumuKodu = (ITTLabel)AddControl(new Guid("62875dd2-e6fd-481f-96e5-38e63a7f6204"));
            sevkDurumuKodu = (ITTTextBox)AddControl(new Guid("41741a4a-1ef3-421a-9fdc-493b84db9f23"));
            labelsevkDurumuAdi = (ITTLabel)AddControl(new Guid("9bf9e306-aa94-4541-b889-0f3c9648eac1"));
            sevkDurumuAdi = (ITTTextBox)AddControl(new Guid("9dacbc05-c1e4-4210-b011-eb0ab7c365cd"));
            base.InitializeControls();
        }

        public SevkDurumuDefinitionForm() : base("SEVKDURUMU", "SevkDurumuDefinitionForm")
        {
        }

        protected SevkDurumuDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}