
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
    /// Sağlık Kurulu Tanımı
    /// </summary>
    public partial class HealthCommitteeDefinitionForm : TTForm
    {
    /// <summary>
    /// Sağlık Kurulu
    /// </summary>
        protected TTObjectClasses.ResHealthCommittee _ResHealthCommittee
        {
            get { return (TTObjectClasses.ResHealthCommittee)_ttObject; }
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
        protected ITTCheckBox PCSInUse;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("e9cbcdb0-d03d-44d2-b766-6bec0e7d406a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("989d89a0-746b-43f1-b0b7-b915d40ea8c0"));
            Location = (ITTTextBox)AddControl(new Guid("3224415d-3117-471a-a03d-fbfa77474402"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("9fa1050d-24c0-4843-8184-125d1392790a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bd2cb59e-0dc1-4a6b-bb2c-a7f625256d6c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b5e7a74b-30d7-42e2-8c58-99f1641bed79"));
            labelStore = (ITTLabel)AddControl(new Guid("815ae294-738f-47d9-b74b-e44b2233e254"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("015b4a3a-674a-46fa-a71d-d577a03abbc8"));
            Store = (ITTObjectListBox)AddControl(new Guid("44a4cdc0-0358-47f9-904c-4fffcaa8838c"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("58987763-d13c-4c2e-b30f-aa43d6c72e58"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("144ba41e-906d-4551-892d-c4bd8de1e825"));
            Quotas = (ITTGroupBox)AddControl(new Guid("c36b451e-0a63-4872-be60-ecbe980a6d46"));
            labelJanuaryQuota = (ITTLabel)AddControl(new Guid("afdc5445-8864-4a74-a94d-136863196a84"));
            labelSeptemberQuota = (ITTLabel)AddControl(new Guid("4eb09797-ab0c-42f4-8f36-656ab60a3111"));
            AprilQuota = (ITTTextBox)AddControl(new Guid("b4fa250e-bc48-46af-8c02-57baab510d8f"));
            SeptemberQuota = (ITTTextBox)AddControl(new Guid("94dfd547-c971-4a9c-bf47-b6f07440dfee"));
            labelAprilQuota = (ITTLabel)AddControl(new Guid("da8281f3-3a49-41ba-b707-e27b2eaf8a29"));
            labelOctoberQuota = (ITTLabel)AddControl(new Guid("5a2ab636-4042-4a2f-b4e9-8b8e8fbbdf57"));
            August = (ITTTextBox)AddControl(new Guid("ec071d19-b3e4-48c0-a72e-f662360bafb5"));
            OctoberQuota = (ITTTextBox)AddControl(new Guid("d41c155e-f28e-45bb-b0d2-571eb7c1d549"));
            labelAugust = (ITTLabel)AddControl(new Guid("4b070f01-4da5-417f-8b8d-1f98be3bc1ad"));
            labelNovemberQuota = (ITTLabel)AddControl(new Guid("df8cef70-4e7d-4abf-bb65-a9aea7bf3e25"));
            DecemberQuota = (ITTTextBox)AddControl(new Guid("e3ad7276-cfaa-4488-a575-afb0c9b9f790"));
            NovemberQuota = (ITTTextBox)AddControl(new Guid("636b150f-4590-418e-a14b-3faebacf0d60"));
            labelDecemberQuota = (ITTLabel)AddControl(new Guid("6a593008-0e2d-4936-8903-1f3e37117b36"));
            labelMayQuota = (ITTLabel)AddControl(new Guid("7178d24a-37b4-4cf1-83cf-9babd2dcfe6a"));
            FebruaryQuota = (ITTTextBox)AddControl(new Guid("37dc6127-5774-40b6-96e5-1b5d45df536d"));
            MayQuota = (ITTTextBox)AddControl(new Guid("f97c5248-fa80-482c-a162-ae5de57a8a1f"));
            labelFebruaryQuota = (ITTLabel)AddControl(new Guid("6d703ea8-0876-495c-b54e-8a0007afe4dd"));
            labelMarchQuota = (ITTLabel)AddControl(new Guid("d3a91f1b-7c0b-4b16-ae52-ed0df4fe380a"));
            JanuaryQuota = (ITTTextBox)AddControl(new Guid("374316bc-497c-430e-92bc-396428bd1a2a"));
            MarchQuota = (ITTTextBox)AddControl(new Guid("1df6bd63-3d09-452a-aa8c-77cf62169c85"));
            JulyQuota = (ITTTextBox)AddControl(new Guid("b410e04b-d7d4-4f33-837e-d041d4ce84eb"));
            labelJuneQuata = (ITTLabel)AddControl(new Guid("c8d49b54-5605-43c2-8e32-6fa84a0bc4ca"));
            labelJulyQuota = (ITTLabel)AddControl(new Guid("bf7f3969-cae4-4803-b8f7-670f88aaaa38"));
            JuneQuata = (ITTTextBox)AddControl(new Guid("c09f8aa3-8544-48b1-8973-9762e5e52af2"));
            PCSInUse = (ITTCheckBox)AddControl(new Guid("7c9982c5-2e9e-41b9-a4fa-ada7df252c7e"));
            labelLocation = (ITTLabel)AddControl(new Guid("d28b90e6-7ca9-4bfc-b605-a40801fb3854"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("fb18cc49-b49c-402c-b1a5-50b0a1c4e68b"));
            base.InitializeControls();
        }

        public HealthCommitteeDefinitionForm() : base("RESHEALTHCOMMITTEE", "HealthCommitteeDefinitionForm")
        {
        }

        protected HealthCommitteeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}