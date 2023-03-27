
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
    /// Kan Bankası Coombs Testi İstek Ekranı
    /// </summary>
    public partial class BloodBankCoombsRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Coombs Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCoombs _BloodBankCoombs
        {
            get { return (TTObjectClasses.BloodBankCoombs)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox4;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox6;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("2fb617fb-2d05-485f-a669-6a0b7739ea0f"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7493bd48-5171-49c5-90d8-0e2f0f01f4a8"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ce474e94-005c-4587-bf0b-085c5e72c213"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("c9563eb6-64be-4a75-a18e-0cb9abf0d401"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("ae02751a-8479-47bb-b637-17c0eafd58e3"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("53852dbd-2522-4daa-a219-1ccaea5bf0e8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5522ece9-fc10-4964-a124-3dd20338155e"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("860f8238-654d-4117-945e-77e3ca213c51"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("36bc7bb5-5b67-437e-99bf-9727e3f8d5af"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("e97848de-caa7-49a9-9143-dc05bb67a591"));
            base.InitializeControls();
        }

        public BloodBankCoombsRequestForm() : base("BLOODBANKCOOMBS", "BloodBankCoombsRequestForm")
        {
        }

        protected BloodBankCoombsRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}