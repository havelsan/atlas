
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
    /// Halk Sağlığı İstek Formu
    /// </summary>
    public partial class CommunityHealthRequestForm : ActionForm
    {
        protected TTObjectClasses.CommunityHealthRequest _CommunityHealthRequest
        {
            get { return (TTObjectClasses.CommunityHealthRequest)_ttObject; }
        }

        protected ITTCheckBox NoCharge;
        protected ITTLabel labelCommunityHealthPayer;
        protected ITTObjectListBox CommunityHealthPayer;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelSampleType;
        protected ITTTextBox SampleType;
        protected ITTTextBox SamplePlace;
        protected ITTTextBox Description;
        protected ITTTextBox Deliverer;
        protected ITTTextBox Adresses;
        protected ITTLabel labelSamplePlace;
        protected ITTLabel labelDescription;
        protected ITTLabel labelDeliverer;
        protected ITTLabel labelAdresses;
        protected ITTTabControl tabTetkik;
        protected ITTButton btnCreateTemplate;
        protected ITTButton btnEditTemplate;
        protected ITTButton btnSelectTemplate;
        override protected void InitializeControls()
        {
            NoCharge = (ITTCheckBox)AddControl(new Guid("3e7dedb6-cdc2-4882-a867-19c7b1f103c5"));
            labelCommunityHealthPayer = (ITTLabel)AddControl(new Guid("0485f26c-8f2d-437c-bd1b-2554fa53523d"));
            CommunityHealthPayer = (ITTObjectListBox)AddControl(new Guid("a2b82ddc-796a-48ed-bb9a-b650875a37e5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("cc229893-30a0-4c0e-b7ad-3a7ca21b80c7"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("181e51a0-6c54-4d53-94fd-c0436537a03a"));
            labelSampleType = (ITTLabel)AddControl(new Guid("6945093d-00c2-4ad7-bc76-e368536ec61d"));
            SampleType = (ITTTextBox)AddControl(new Guid("cb343688-0a0b-47a4-990a-9bca58d0ddc1"));
            SamplePlace = (ITTTextBox)AddControl(new Guid("64ebb104-cb8f-4338-8349-295599f1fb7d"));
            Description = (ITTTextBox)AddControl(new Guid("71a98884-6f37-4801-836e-3f05672bd52e"));
            Deliverer = (ITTTextBox)AddControl(new Guid("2c052021-bbf2-4c51-a5e9-a0699550f84a"));
            Adresses = (ITTTextBox)AddControl(new Guid("9c69cc60-ca0c-4fbc-8cb4-ed465970c5d5"));
            labelSamplePlace = (ITTLabel)AddControl(new Guid("76cd9272-d3e2-484e-a886-241a3f159cba"));
            labelDescription = (ITTLabel)AddControl(new Guid("89cc8790-ee50-47de-a2c1-f18b1045272c"));
            labelDeliverer = (ITTLabel)AddControl(new Guid("fea5d6b4-1527-481a-912e-89e443d62ff8"));
            labelAdresses = (ITTLabel)AddControl(new Guid("37e2f40a-03dc-4530-9d05-c5a3f4292cc2"));
            tabTetkik = (ITTTabControl)AddControl(new Guid("485e5fba-5deb-4c39-83fb-f89873e9a7c9"));
            btnCreateTemplate = (ITTButton)AddControl(new Guid("b7a59f4a-752c-4396-8ca1-d1c925b4194b"));
            btnEditTemplate = (ITTButton)AddControl(new Guid("c61074b0-7b7a-4044-abe4-8673cade372f"));
            btnSelectTemplate = (ITTButton)AddControl(new Guid("c6c65f8c-b714-480f-af6d-32aeacb99a64"));
            base.InitializeControls();
        }

        public CommunityHealthRequestForm() : base("COMMUNITYHEALTHREQUEST", "CommunityHealthRequestForm")
        {
        }

        protected CommunityHealthRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}