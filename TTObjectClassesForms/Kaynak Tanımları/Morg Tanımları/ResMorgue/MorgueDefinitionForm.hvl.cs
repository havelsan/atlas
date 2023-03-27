
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
    /// Morg Tanımı
    /// </summary>
    public partial class MorgueDefinitionForm : TTForm
    {
    /// <summary>
    /// Morg
    /// </summary>
        protected TTObjectClasses.ResMorgue _ResMorgue
        {
            get { return (TTObjectClasses.ResMorgue)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelStore;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTGroupBox Quotas;
        protected ITTLabel labelJanuaryQuota;
        protected ITTLabel labelSeptemberQuota;
        protected ITTTextBox AprilQuota;
        protected ITTTextBox SeptemberQuota;
        protected ITTLabel labelAprilQuota;
        protected ITTLabel labelOctoberQuota;
        protected ITTTextBox August;
        protected ITTTextBox OctoberQuota;
        protected ITTLabel labelAugust;
        protected ITTLabel labelNovemberQuota;
        protected ITTTextBox DecemberQuota;
        protected ITTTextBox NovemberQuota;
        protected ITTLabel labelDecemberQuota;
        protected ITTLabel labelMayQuota;
        protected ITTTextBox FebruaryQuota;
        protected ITTTextBox MayQuota;
        protected ITTLabel labelFebruaryQuota;
        protected ITTLabel labelMarchQuota;
        protected ITTTextBox JanuaryQuota;
        protected ITTTextBox MarchQuota;
        protected ITTTextBox JulyQuota;
        protected ITTLabel labelJuneQuata;
        protected ITTLabel labelJulyQuota;
        protected ITTTextBox JuneQuata;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("cb8e1dbe-907b-4f7e-a1de-f7cb12803d94"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("64b5ff0e-076c-4619-878f-e2a1e8f2da25"));
            Location = (ITTTextBox)AddControl(new Guid("7bcfd12b-b1c1-4615-8ab7-15698bf9b93f"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("6249e2ce-13a0-4fb5-a304-6242ecf129f8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2b294081-d158-440b-8874-905132e04886"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b67f7313-b3f7-4273-8b3b-1863e7b248cb"));
            labelStore = (ITTLabel)AddControl(new Guid("2a04b3f6-b784-492e-995b-6abc78d9a876"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("fe5e6c29-cbe3-4c81-8373-51f8b801c9b6"));
            Store = (ITTObjectListBox)AddControl(new Guid("726ea400-0239-43be-9fde-426798af62e1"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("7797a623-c666-4c59-9f45-65f2dd959cad"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4d381c2b-f1f8-45b6-a21e-b3ae1a884706"));
            Quotas = (ITTGroupBox)AddControl(new Guid("eb2399e9-030e-4ad0-a6a3-11b588c157c5"));
            labelJanuaryQuota = (ITTLabel)AddControl(new Guid("641f8ee4-daca-4525-9d72-25da09c57d1f"));
            labelSeptemberQuota = (ITTLabel)AddControl(new Guid("956f06b1-889a-4cd9-9035-f6370b148835"));
            AprilQuota = (ITTTextBox)AddControl(new Guid("3b0ffa57-9984-4ab5-8dfe-3436e47ad389"));
            SeptemberQuota = (ITTTextBox)AddControl(new Guid("507ccabb-08d2-4975-afb9-e5c49c083530"));
            labelAprilQuota = (ITTLabel)AddControl(new Guid("62240bde-badb-4300-ac22-264050f09c4c"));
            labelOctoberQuota = (ITTLabel)AddControl(new Guid("e5928129-db18-4d56-9fe8-47be7ed164a3"));
            August = (ITTTextBox)AddControl(new Guid("bcc28788-fcb4-4c6b-b8db-cea077a18a02"));
            OctoberQuota = (ITTTextBox)AddControl(new Guid("f8068924-f18b-4fdb-90e6-d1aaba0b786f"));
            labelAugust = (ITTLabel)AddControl(new Guid("cececec3-81dd-40be-b8cd-170db071539a"));
            labelNovemberQuota = (ITTLabel)AddControl(new Guid("92b6b475-636e-487c-98b3-8d064e5cd31a"));
            DecemberQuota = (ITTTextBox)AddControl(new Guid("eafa252b-b13e-4f8d-8444-27dbb870e682"));
            NovemberQuota = (ITTTextBox)AddControl(new Guid("90838a74-a3b8-408a-874f-59a6cf2c3702"));
            labelDecemberQuota = (ITTLabel)AddControl(new Guid("ee8bd85c-fa46-48f8-b766-73a14ebb355f"));
            labelMayQuota = (ITTLabel)AddControl(new Guid("a9b48577-af44-46db-b167-be6363286f74"));
            FebruaryQuota = (ITTTextBox)AddControl(new Guid("ce5f7b13-1f31-4043-b3a0-5e2fa6dee815"));
            MayQuota = (ITTTextBox)AddControl(new Guid("6f6f18a4-35f2-4311-98cf-4825b827a363"));
            labelFebruaryQuota = (ITTLabel)AddControl(new Guid("14b19122-d255-4b0a-bf27-392d45490b8c"));
            labelMarchQuota = (ITTLabel)AddControl(new Guid("c184b334-e1a3-491a-8ed8-528ea443e6b6"));
            JanuaryQuota = (ITTTextBox)AddControl(new Guid("eb593a9f-08ed-4da5-be40-c6ca431c218d"));
            MarchQuota = (ITTTextBox)AddControl(new Guid("aa8c6293-84d3-4699-969b-21ea083cf1ac"));
            JulyQuota = (ITTTextBox)AddControl(new Guid("6d7e57f2-3dab-4a04-be21-dc77e2d07be9"));
            labelJuneQuata = (ITTLabel)AddControl(new Guid("610deebf-19ff-462a-8f3b-cdace1ac8a4b"));
            labelJulyQuota = (ITTLabel)AddControl(new Guid("62fd33a7-25fd-4aab-a532-b84d28a50e43"));
            JuneQuata = (ITTTextBox)AddControl(new Guid("7211bccb-4f1a-4bd1-bc88-a08d491e2811"));
            labelLocation = (ITTLabel)AddControl(new Guid("77649763-05f3-4ddf-a0a7-c08a7070538c"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("194988d9-e6f2-4ce9-b892-893b3edbae2c"));
            base.InitializeControls();
        }

        public MorgueDefinitionForm() : base("RESMORGUE", "MorgueDefinitionForm")
        {
        }

        protected MorgueDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}