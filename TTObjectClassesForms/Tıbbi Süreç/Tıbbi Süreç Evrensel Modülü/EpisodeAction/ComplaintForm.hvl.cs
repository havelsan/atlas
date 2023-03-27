
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
    public partial class ComplaintForm : TTForm
    {
    /// <summary>
    /// Vakaya Bağlı Hasta İşlemlerinini Ana Nesnesi
    /// </summary>
        protected TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get { return (TTObjectClasses.EpisodeAction)_ttObject; }
        }

        protected ITTGrid Complaints;
        protected ITTListBoxColumn ComplaintDefinitionComplaint;
        override protected void InitializeControls()
        {
            Complaints = (ITTGrid)AddControl(new Guid("cf06ac86-6185-489a-b2bf-e8e23d45c7a8"));
            ComplaintDefinitionComplaint = (ITTListBoxColumn)AddControl(new Guid("66521989-78df-486a-bbf1-29fb28eebfa3"));
            base.InitializeControls();
        }

        public ComplaintForm() : base("EPISODEACTION", "ComplaintForm")
        {
        }

        protected ComplaintForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}