
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
    /// Kan Bankası Coombs Testi İstek Karşılama  Ekranı
    /// </summary>
    public partial class BloodBankCoombsRequestSupplyingForm : EpisodeActionForm
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
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("43926420-ce0e-4ab7-86f9-677de6d13383"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("92f75090-1a80-46a4-8f21-858b0080f546"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("a00fccdb-1cbc-4d72-bfd4-89369ed7d742"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("dfaa37cc-0421-4dce-9c28-915329473862"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3c4f618d-a111-4ef4-b599-9814ca3c46b4"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("226f86ad-a953-45b9-811e-9f0756ecc99c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("a82f49e9-2041-4ec2-a7ff-e85e7e64316e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8f49111e-406c-48b9-8998-f0673f16c133"));
            base.InitializeControls();
        }

        public BloodBankCoombsRequestSupplyingForm() : base("BLOODBANKCOOMBS", "BloodBankCoombsRequestSupplyingForm")
        {
        }

        protected BloodBankCoombsRequestSupplyingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}