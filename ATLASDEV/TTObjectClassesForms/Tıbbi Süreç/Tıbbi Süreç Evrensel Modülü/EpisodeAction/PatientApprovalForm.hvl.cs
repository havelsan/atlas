
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
    /// Aydınlanmış Onam Formu
    /// </summary>
    public partial class PatientApprovalForm : TTForm
    {
    /// <summary>
    /// Vakaya Bağlı Hasta İşlemlerinini Ana Nesnesi
    /// </summary>
        protected TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get { return (TTObjectClasses.EpisodeAction)_ttObject; }
        }

        protected ITTRichTextBoxControl RTFField;
        override protected void InitializeControls()
        {
            RTFField = (ITTRichTextBoxControl)AddControl(new Guid("ce35cee2-e4de-4591-b2f7-14ad8677e3cd"));
            base.InitializeControls();
        }

        public PatientApprovalForm() : base("EPISODEACTION", "PatientApprovalForm")
        {
        }

        protected PatientApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}