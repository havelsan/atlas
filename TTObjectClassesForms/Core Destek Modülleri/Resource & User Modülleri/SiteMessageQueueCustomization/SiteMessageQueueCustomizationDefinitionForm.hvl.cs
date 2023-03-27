
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
    public partial class SiteMessageQueueCustomizationDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.SiteMessageQueueCustomization _SiteMessageQueueCustomization
        {
            get { return (TTObjectClasses.SiteMessageQueueCustomization)_ttObject; }
        }

        protected ITTLabel labelTurnCount;
        protected ITTTextBox TurnCount;
        protected ITTTextBox MessageQueueMinVolume;
        protected ITTTextBox MessageQueueMaxVolume;
        protected ITTTextBox MessageSuccessiveCount;
        protected ITTTextBox MessageSizeLimit;
        protected ITTLabel labelMessageQueueMinVolume;
        protected ITTLabel labelMessageQueueMaxVolume;
        protected ITTLabel labelSite;
        protected ITTObjectListBox Site;
        protected ITTGrid SiteRemoteMethodDefCustomizations;
        protected ITTButtonColumn SelectSiteRemoteMethodDefID;
        protected ITTTextBoxColumn RemoteMethodDefIDSiteRemoteMethodDefCustomization;
        protected ITTTextBoxColumn RemoteMethodDefNameSiteRemoteMethodDefCustomization;
        protected ITTCheckBoxColumn IsKeepCompletedSiteRemoteMethodDefCustomization;
        protected ITTCheckBoxColumn IsSendingStartStopSiteRemoteMethodDefCustomization;
        protected ITTDateTimePickerColumn SendingStartTimeSiteRemoteMethodDefCustomization;
        protected ITTDateTimePickerColumn SendingEndTimeSiteRemoteMethodDefCustomization;
        protected ITTCheckBoxColumn IsActiveSiteRemoteMethodDefCustomization;
        protected ITTLabel labelSendingStartTime;
        protected ITTDateTimePicker SendingStartTime;
        protected ITTLabel labelSendingEndTime;
        protected ITTDateTimePicker SendingEndTime;
        protected ITTLabel labelMessageSuccessiveCount;
        protected ITTLabel labelMessageSizeLimit;
        protected ITTCheckBox IsSendingStartStop;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelTurnCount = (ITTLabel)AddControl(new Guid("30fbc825-fa52-410b-99d5-aa4ee5a27a40"));
            TurnCount = (ITTTextBox)AddControl(new Guid("3a444794-7139-4106-94b5-01be4abf5db1"));
            MessageQueueMinVolume = (ITTTextBox)AddControl(new Guid("cf9a11f1-48a7-412a-b516-664d1ca878ac"));
            MessageQueueMaxVolume = (ITTTextBox)AddControl(new Guid("e68c5c07-caed-47a4-a69a-6f5521f22ded"));
            MessageSuccessiveCount = (ITTTextBox)AddControl(new Guid("be11b3b2-12a1-44bc-b634-f81ad22c5808"));
            MessageSizeLimit = (ITTTextBox)AddControl(new Guid("9f76bec1-58bd-4487-9516-17f57fd63218"));
            labelMessageQueueMinVolume = (ITTLabel)AddControl(new Guid("c052a39b-676c-4fba-adf2-02d033c81bac"));
            labelMessageQueueMaxVolume = (ITTLabel)AddControl(new Guid("e5efa489-1203-4749-ab80-6a331293548d"));
            labelSite = (ITTLabel)AddControl(new Guid("87e7a530-0000-4c34-9e8a-9bf92b3f87eb"));
            Site = (ITTObjectListBox)AddControl(new Guid("5cc96f02-1398-41db-b4f1-fab9af283009"));
            SiteRemoteMethodDefCustomizations = (ITTGrid)AddControl(new Guid("9c8d9d88-f1cb-47f9-a299-84ac28979025"));
            SelectSiteRemoteMethodDefID = (ITTButtonColumn)AddControl(new Guid("1122314a-2362-404f-ad2f-5c90439ddcc6"));
            RemoteMethodDefIDSiteRemoteMethodDefCustomization = (ITTTextBoxColumn)AddControl(new Guid("3e301c65-4dc6-48bc-9fe5-f96d2d0f3d94"));
            RemoteMethodDefNameSiteRemoteMethodDefCustomization = (ITTTextBoxColumn)AddControl(new Guid("77754df9-87cd-43c4-8244-b67b7a95013b"));
            IsKeepCompletedSiteRemoteMethodDefCustomization = (ITTCheckBoxColumn)AddControl(new Guid("6d42384d-30db-41f5-875f-8c669efe3f47"));
            IsSendingStartStopSiteRemoteMethodDefCustomization = (ITTCheckBoxColumn)AddControl(new Guid("4558e88d-0de7-47e6-8a2a-8bb559729896"));
            SendingStartTimeSiteRemoteMethodDefCustomization = (ITTDateTimePickerColumn)AddControl(new Guid("f52204a1-4236-45a9-b2ed-617e632d1c05"));
            SendingEndTimeSiteRemoteMethodDefCustomization = (ITTDateTimePickerColumn)AddControl(new Guid("2620a33d-ad09-4e82-b439-a7e4ccb3ebdf"));
            IsActiveSiteRemoteMethodDefCustomization = (ITTCheckBoxColumn)AddControl(new Guid("719da345-54cc-4ac1-91d9-3d83de28757e"));
            labelSendingStartTime = (ITTLabel)AddControl(new Guid("cf35f775-e143-4cf8-889d-f0434ab547df"));
            SendingStartTime = (ITTDateTimePicker)AddControl(new Guid("80d6106f-07bb-44f3-859b-e8aaddeaeaa4"));
            labelSendingEndTime = (ITTLabel)AddControl(new Guid("2eb745db-a42f-40ef-8210-7ba5c20e9740"));
            SendingEndTime = (ITTDateTimePicker)AddControl(new Guid("13de89a2-2fa2-4bfa-9bfd-cb259bcdad91"));
            labelMessageSuccessiveCount = (ITTLabel)AddControl(new Guid("0ef59b3a-bc88-406c-9531-c8a0b87709c3"));
            labelMessageSizeLimit = (ITTLabel)AddControl(new Guid("5ac76875-4c41-43fa-a880-d493d2e195f2"));
            IsSendingStartStop = (ITTCheckBox)AddControl(new Guid("2882a24a-a964-40f5-bb9b-30c81cf45663"));
            IsActive = (ITTCheckBox)AddControl(new Guid("4912414a-217d-4c9e-b6df-ec291d71d54e"));
            base.InitializeControls();
        }

        public SiteMessageQueueCustomizationDefinitionForm() : base("SITEMESSAGEQUEUECUSTOMIZATION", "SiteMessageQueueCustomizationDefinitionForm")
        {
        }

        protected SiteMessageQueueCustomizationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}