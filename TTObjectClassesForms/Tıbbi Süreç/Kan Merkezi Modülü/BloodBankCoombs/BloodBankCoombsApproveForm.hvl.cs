
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
    /// Kan Bankası Coombs Testi Onay Ekranı
    /// </summary>
    public partial class BloodBankCoombsApproveForm : EpisodeActionForm
    {
    /// <summary>
    /// Coombs Testi
    /// </summary>
        protected TTObjectClasses.BloodBankCoombs _BloodBankCoombs
        {
            get { return (TTObjectClasses.BloodBankCoombs)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox4;
        protected ITTCheckBox ttcheckbox1;
        protected ITTComboBox ttcombobox5;
        protected ITTComboBox ttcombobox2;
        protected ITTCheckBox ttcheckbox6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox2;
        protected ITTCheckBox ttcheckbox12;
        protected ITTCheckBox ttcheckbox8;
        protected ITTComboBox ttcombobox1;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox9;
        protected ITTComboBox ttcombobox4;
        protected ITTCheckBox ttcheckbox5;
        protected ITTLabel ttlabel9;
        protected ITTComboBox ttcombobox3;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox ttcheckbox10;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox7;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel3;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox ttcheckbox11;
        protected ITTCheckBox ttcheckbox13;
        protected ITTCheckBox ttcheckbox14;
        override protected void InitializeControls()
        {
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("781667c8-6a6e-4230-903d-1088fefbddc7"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("2e1888f1-0f55-48eb-a115-ff6ecccba91c"));
            ttcombobox5 = (ITTComboBox)AddControl(new Guid("e13cd9e0-b350-49ef-b3a2-c11156065826"));
            ttcombobox2 = (ITTComboBox)AddControl(new Guid("6840a598-0ffb-4742-bbda-d9c00a17ef74"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("63a4a015-19e3-432f-8936-e7566d1abb25"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("289ea6f5-2436-4624-9d91-acaac63d782a"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("bbd7c4e2-f5c9-4f25-a2d7-c85376d4ae4c"));
            ttcheckbox12 = (ITTCheckBox)AddControl(new Guid("82f67a91-4a51-4285-a441-db18a9473214"));
            ttcheckbox8 = (ITTCheckBox)AddControl(new Guid("a60dfae4-d3e7-45cc-88e7-b0177ae8effd"));
            ttcombobox1 = (ITTComboBox)AddControl(new Guid("a634b572-1e13-4d5e-b801-b09999fd6dcb"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("57a4117d-6bbd-4454-a161-958bb57befcb"));
            ttcheckbox9 = (ITTCheckBox)AddControl(new Guid("c4555b73-73a1-49ba-b457-78070176df24"));
            ttcombobox4 = (ITTComboBox)AddControl(new Guid("fdcab19f-3783-46f9-af14-88e0c859bc40"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("76105132-185b-4753-86de-7d11cb9d963b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("4e51aa8a-ffed-4d2a-865a-9ca85e7c63c0"));
            ttcombobox3 = (ITTComboBox)AddControl(new Guid("555bf7b3-f9c3-4a1c-9dd0-6df2551cd0e2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("cd3643cf-e0fd-426f-be07-977cf94b6746"));
            ttcheckbox10 = (ITTCheckBox)AddControl(new Guid("4eee9bae-c1a8-4309-8125-7e79aeb5153c"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("0c36c02c-85db-461e-8b16-93477e67c194"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("2a369825-accb-4bd4-81af-5c37413ec128"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("29a9ff87-1635-48f8-bc71-757fec57f5f4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4fa0b827-c774-43f2-8169-3ca07a663d80"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4294b390-fad6-404d-bde3-3344408a6f65"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("05b54158-94a6-4e0e-abec-3aa7f4411f0c"));
            ttcheckbox7 = (ITTCheckBox)AddControl(new Guid("36c260c2-7e12-4c72-afc1-51dbabbd233a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("50f0cc90-e217-4e82-b657-0fea94afe831"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("537fbc7e-7d2e-4924-8178-208db9d63fde"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("425dde18-c4dd-4373-ab3e-12fcf408cff8"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("6a272598-1d75-40dc-956d-1636dd66e224"));
            ttcheckbox11 = (ITTCheckBox)AddControl(new Guid("95398dbb-8b14-4b35-9e52-1671b154d212"));
            ttcheckbox13 = (ITTCheckBox)AddControl(new Guid("fdd4b936-bf61-4bce-a4ae-fa3b4959e29f"));
            ttcheckbox14 = (ITTCheckBox)AddControl(new Guid("6407a265-e160-4a8a-b15b-f6033aba4148"));
            base.InitializeControls();
        }

        public BloodBankCoombsApproveForm() : base("BLOODBANKCOOMBS", "BloodBankCoombsApproveForm")
        {
        }

        protected BloodBankCoombsApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}