
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
    /// Medula Hasta Kabulleri
    /// </summary>
    public partial class EpisodeActionMedulaHastaKabulForm : TTForm
    {
    /// <summary>
    /// Vakaya Bağlı Hasta İşlemlerinini Ana Nesnesi
    /// </summary>
        protected TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get { return (TTObjectClasses.EpisodeAction)_ttObject; }
        }

        protected ITTListView listviewPatientMedulaHastaKabul;
        override protected void InitializeControls()
        {
            listviewPatientMedulaHastaKabul = (ITTListView)AddControl(new Guid("4e8ac727-eec5-4dd9-b893-7f3a8b8b5787"));
            base.InitializeControls();
        }

        public EpisodeActionMedulaHastaKabulForm() : base("EPISODEACTION", "EpisodeActionMedulaHastaKabulForm")
        {
        }

        protected EpisodeActionMedulaHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}