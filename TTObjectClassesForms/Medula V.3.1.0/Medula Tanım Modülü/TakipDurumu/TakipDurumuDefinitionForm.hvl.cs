
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
    /// Takip Durumu Tanımlama
    /// </summary>
    public partial class TakipDurumuDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Takip Durumu
    /// </summary>
        protected TTObjectClasses.TakipDurumu _TakipDurumu
        {
            get { return (TTObjectClasses.TakipDurumu)_ttObject; }
        }

        protected ITTLabel labeltakipDurumuAdi;
        protected ITTTextBox takipDurumuAdi;
        protected ITTLabel labeltakipDurumuKodu;
        protected ITTTextBox takipDurumuKodu;
        override protected void InitializeControls()
        {
            labeltakipDurumuAdi = (ITTLabel)AddControl(new Guid("7d09fe75-4329-4b0a-b53a-63ff88690639"));
            takipDurumuAdi = (ITTTextBox)AddControl(new Guid("833b47d9-4b8d-48f4-b0ea-9569fd8ca228"));
            labeltakipDurumuKodu = (ITTLabel)AddControl(new Guid("1b10f28f-bf33-4b8c-bc31-bcdad64e06d5"));
            takipDurumuKodu = (ITTTextBox)AddControl(new Guid("853bbba8-97dd-461b-965c-92c99ed080ab"));
            base.InitializeControls();
        }

        public TakipDurumuDefinitionForm() : base("TAKIPDURUMU", "TakipDurumuDefinitionForm")
        {
        }

        protected TakipDurumuDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}