
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
    public partial class AnnouncementDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Duyuru Tanımları
    /// </summary>
        protected TTObjectClasses.AnnouncementDefinition _AnnouncementDefinition
        {
            get { return (TTObjectClasses.AnnouncementDefinition)_ttObject; }
        }

        protected ITTPictureBoxControl previewPictureBox;
        protected ITTLabel lblPreview;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel lblStartDate;
        protected ITTGrid AnnouncementUserTypes;
        protected ITTEnumComboBoxColumn UserTypeAnnouncementUserType;
        protected ITTGrid AnnouncementHospitals;
        protected ITTListBoxColumn SitesAnnouncementHospital;
        protected ITTLabel labelAnnouncementName;
        protected ITTTextBox AnnouncementName;
        protected ITTTextBox Link;
        protected ITTPictureBoxControl Announcement;
        protected ITTButton cmdAppendAll;
        protected ITTLabel labelLink;
        protected ITTButton cmdAppendAllTypes;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel lblEndDate;
        override protected void InitializeControls()
        {
            previewPictureBox = (ITTPictureBoxControl)AddControl(new Guid("cdc6c983-6fca-4178-8d4d-27223728fa0f"));
            lblPreview = (ITTLabel)AddControl(new Guid("ed99f8bf-4773-479b-8a86-b67429f4effd"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("2cf55195-051b-4bc5-b5c8-8bfb0164dd04"));
            lblStartDate = (ITTLabel)AddControl(new Guid("bfbfaf53-1e27-4521-8a0c-4b50eed71c84"));
            AnnouncementUserTypes = (ITTGrid)AddControl(new Guid("3e056204-1d98-463b-a654-37950b11d55e"));
            UserTypeAnnouncementUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("767fabb8-b631-419f-9667-9f5c513655d6"));
            AnnouncementHospitals = (ITTGrid)AddControl(new Guid("81ec5856-3cac-4927-a102-7fae66e53c54"));
            SitesAnnouncementHospital = (ITTListBoxColumn)AddControl(new Guid("0d7e85cb-4824-4d5a-8f39-1f95945d73b5"));
            labelAnnouncementName = (ITTLabel)AddControl(new Guid("b307e8a1-4795-457e-b157-07f53da3ceaf"));
            AnnouncementName = (ITTTextBox)AddControl(new Guid("2bb18957-6ccc-4bb3-836c-a1bda4d305db"));
            Link = (ITTTextBox)AddControl(new Guid("7b9fe608-e880-403f-a99a-365da2fd13c0"));
            Announcement = (ITTPictureBoxControl)AddControl(new Guid("17d7adc6-0e9a-468d-94fb-d0098ac18629"));
            cmdAppendAll = (ITTButton)AddControl(new Guid("b7f4fd66-8873-4d95-9dfc-cb5e99a8f2f8"));
            labelLink = (ITTLabel)AddControl(new Guid("59aab0fc-e091-4a6d-bb7b-61e7df0f2cf8"));
            cmdAppendAllTypes = (ITTButton)AddControl(new Guid("6bd915e1-c5a7-4957-a62e-48d9e82f77e7"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("d04b7740-79fc-423c-a661-c641b693c42f"));
            lblEndDate = (ITTLabel)AddControl(new Guid("8c6fb2bb-3ffe-4731-93a8-9d70e9cf5875"));
            base.InitializeControls();
        }

        public AnnouncementDefinitionForm() : base("ANNOUNCEMENTDEFINITION", "AnnouncementDefinitionForm")
        {
        }

        protected AnnouncementDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}