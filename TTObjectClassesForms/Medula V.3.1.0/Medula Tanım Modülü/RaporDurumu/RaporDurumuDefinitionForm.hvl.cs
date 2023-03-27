
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
    public partial class RaporDurumuDefinitionForm : BaseMedulaDefinitionForm
    {
        protected TTObjectClasses.RaporDurumu _RaporDurumu
        {
            get { return (TTObjectClasses.RaporDurumu)_ttObject; }
        }

        protected ITTLabel labelraporDurumuKodu;
        protected ITTTextBox raporDurumuKodu;
        protected ITTLabel labelraporDurumuAdi;
        protected ITTTextBox raporDurumuAdi;
        override protected void InitializeControls()
        {
            labelraporDurumuKodu = (ITTLabel)AddControl(new Guid("79109bbd-999a-46bb-9f52-d5f91de8c834"));
            raporDurumuKodu = (ITTTextBox)AddControl(new Guid("10cfa210-7010-4136-ac1b-fc8b63c9f9e4"));
            labelraporDurumuAdi = (ITTLabel)AddControl(new Guid("a30b91d5-302d-4be4-983d-aa55e38646e7"));
            raporDurumuAdi = (ITTTextBox)AddControl(new Guid("2af9fedf-9b45-4e5b-979a-97a1698e54a2"));
            base.InitializeControls();
        }

        public RaporDurumuDefinitionForm() : base("RAPORDURUMU", "RaporDurumuDefinitionForm")
        {
        }

        protected RaporDurumuDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}