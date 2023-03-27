
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
    /// Kan Bankası Coombs Testi Red Ekranı
    /// </summary>
    public partial class BloodBankCoombsRejectForm : EpisodeActionForm
    {
    /// <summary>
    /// Coombs Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCoombs _BloodBankCoombs
        {
            get { return (TTObjectClasses.BloodBankCoombs)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox4;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox5;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox6;
        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("51988e6f-ae8a-4a16-8f29-a52b73a23d58"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("8dcfab71-dec8-48a6-91e1-04a0723deff2"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("ff86440e-d01a-4165-94df-13a127eec163"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("79835623-bf48-4a25-887b-627bd7253571"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("dd0e9731-8e76-471f-b5d1-d79c51fc2bf7"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("b0669d6d-8075-415f-9d39-cd8057050013"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("5c264cda-593a-43e2-811b-ca91e5e8b12f"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("39a04801-2533-4bca-b9e0-cecd337eab63"));
            base.InitializeControls();
        }

        public BloodBankCoombsRejectForm() : base("BLOODBANKCOOMBS", "BloodBankCoombsRejectForm")
        {
        }

        protected BloodBankCoombsRejectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}