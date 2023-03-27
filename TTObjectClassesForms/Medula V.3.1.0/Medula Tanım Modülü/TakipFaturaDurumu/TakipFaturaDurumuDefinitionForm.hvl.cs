
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
    /// Takip Fatura Durumu Tanımlama
    /// </summary>
    public partial class TakipFaturaDurumuDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Takip Fatura Durumu
    /// </summary>
        protected TTObjectClasses.TakipFaturaDurumu _TakipFaturaDurumu
        {
            get { return (TTObjectClasses.TakipFaturaDurumu)_ttObject; }
        }

        protected ITTLabel labeltakipFaturaDurumuKodu;
        protected ITTTextBox takipFaturaDurumuKodu;
        protected ITTLabel labeltakipFaturaDurumuAdi;
        protected ITTTextBox takipFaturaDurumuAdi;
        override protected void InitializeControls()
        {
            labeltakipFaturaDurumuKodu = (ITTLabel)AddControl(new Guid("4aadaa13-7cdd-4f23-b719-ff932c848491"));
            takipFaturaDurumuKodu = (ITTTextBox)AddControl(new Guid("8aebde4d-91bb-4e8e-89b3-0c6029ebafbe"));
            labeltakipFaturaDurumuAdi = (ITTLabel)AddControl(new Guid("9d9e4df2-94be-4383-a4c1-590d4752ab1f"));
            takipFaturaDurumuAdi = (ITTTextBox)AddControl(new Guid("56a9dcf1-6c37-4b9f-b03d-50aec4186248"));
            base.InitializeControls();
        }

        public TakipFaturaDurumuDefinitionForm() : base("TAKIPFATURADURUMU", "TakipFaturaDurumuDefinitionForm")
        {
        }

        protected TakipFaturaDurumuDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}