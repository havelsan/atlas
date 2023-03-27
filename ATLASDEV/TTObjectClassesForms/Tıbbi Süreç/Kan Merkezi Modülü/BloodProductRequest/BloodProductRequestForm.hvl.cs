
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
    /// Kan Bankası Kan Ürünü İstek
    /// </summary>
    public partial class BloodProductRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTGroupBox ttgroupbox1;
        protected ITTPanel pnlUrgent;
        protected ITTCheckBox chkWithTest;
        protected ITTCheckBox chkWithoutTests;
        protected ITTCheckBox chkUrgentCross;
        protected ITTCheckBox chkWithoutCross;
        protected ITTCheckBox chkNormal;
        protected ITTDateTimePicker dtTransfused;
        protected ITTDateTimePicker dtPregnancy;
        protected ITTCheckBox chkBlock;
        protected ITTCheckBox chkOther;
        protected ITTCheckBox chkHB;
        protected ITTCheckBox chkPrepare;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox chkSurgery;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox chkPregnancy;
        protected ITTLabel ttlabel5;
        protected ITTCheckBox chkTransfused;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox chkUrgent;
        protected ITTCheckBox ttcheckbox4;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTDateTimePicker dtRequirement;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistbox1;
        protected ITTTextBoxColumn txtAmount;
        protected ITTCheckBoxColumn chkIsinlama;
        protected ITTCheckBoxColumn chkFilter;
        protected ITTListBoxColumn OzelDurum;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("fdc9127c-0ebf-41f9-8e88-7d870b3bc860"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b0c94998-ac3f-419b-9ac6-e709ae9c2de9"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("a3d52793-7067-429a-984f-028c447ac84b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("d0c6c334-0382-48da-922c-c9c5c92d8785"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b3cd8fbf-1cd5-45ca-a445-8a535e202628"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d9f2c7e3-8503-4f22-a52e-399520b627df"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("46bee0ce-6a4e-466e-8d19-da4d2dca3801"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("8e0a9c07-5ece-4283-b6b2-b90b6c8bd3b2"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("8d67dfe7-4a4f-4252-8368-b47f1e3548b6"));
            pnlUrgent = (ITTPanel)AddControl(new Guid("4da6a0bc-f484-4737-b892-cbf29c73506e"));
            chkWithTest = (ITTCheckBox)AddControl(new Guid("dc5f78b0-6658-4faf-80ff-25c121826ccd"));
            chkWithoutTests = (ITTCheckBox)AddControl(new Guid("9d935b1d-2869-41cc-a489-91d3ae1a8ef8"));
            chkUrgentCross = (ITTCheckBox)AddControl(new Guid("e99a0043-b38c-415e-8943-983368e7f424"));
            chkWithoutCross = (ITTCheckBox)AddControl(new Guid("4cfab6fd-6c12-4325-a8a5-ff2ffd662284"));
            chkNormal = (ITTCheckBox)AddControl(new Guid("a6dd566d-26d0-49cb-a107-2d5e7d30b9e0"));
            dtTransfused = (ITTDateTimePicker)AddControl(new Guid("a3f0e04b-049f-4abc-b1b7-0bafaa0e27ed"));
            dtPregnancy = (ITTDateTimePicker)AddControl(new Guid("00525ccc-0532-448d-a427-d09431aca19f"));
            chkBlock = (ITTCheckBox)AddControl(new Guid("a8903010-f5f0-4e0e-b0b9-6d0c6a683b7a"));
            chkOther = (ITTCheckBox)AddControl(new Guid("32e8b811-9e83-4025-919c-46f54d28a0ae"));
            chkHB = (ITTCheckBox)AddControl(new Guid("9af48a08-058f-4458-8630-2193e3c3d287"));
            chkPrepare = (ITTCheckBox)AddControl(new Guid("615efaac-1bdb-4e46-9273-5c1aebbdfdac"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("29e13463-f11d-47f1-83b0-c723396519b3"));
            chkSurgery = (ITTCheckBox)AddControl(new Guid("e1844742-3b35-43e6-bfbb-412f9a67c752"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("7e102f67-88ef-4423-b071-ca3e3af66f75"));
            chkPregnancy = (ITTCheckBox)AddControl(new Guid("e07560e3-c46e-4535-ba3e-43b611f883c6"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f1fd8579-3115-4d08-8784-2fc9cd71097c"));
            chkTransfused = (ITTCheckBox)AddControl(new Guid("8527b79b-d18b-484a-8183-f57241c3807c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("15270f69-afca-4aee-9eaa-d7efba71ad87"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c1a36e8e-7fa8-41a6-94ca-12196ee66246"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("786ad297-cd32-4afd-af97-6245fe957a26"));
            chkUrgent = (ITTCheckBox)AddControl(new Guid("edb39ded-8c39-410d-b35d-6287f5c1a760"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("6b87c7a4-b48c-478a-9c6f-90ef10fcab3e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b9d62c77-4787-4b24-ac4c-955ac1aa098b"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("4ee091d9-9e0c-42c9-be3d-9eb38dcc1fed"));
            dtRequirement = (ITTDateTimePicker)AddControl(new Guid("d714037d-9c76-448e-96e4-ae6beca7233e"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d8c512e5-3a5e-4421-b7d7-f33f70b51fe3"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("2a20e261-0a2d-4158-a5dc-6b1fa689f55e"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("665127c0-f7d7-4b9a-a16a-8594e182e9b7"));
            ttlistbox1 = (ITTListBoxColumn)AddControl(new Guid("4dfd75b1-ad33-45ad-b279-d4a1dbb32466"));
            txtAmount = (ITTTextBoxColumn)AddControl(new Guid("9eeb00d0-5f28-4796-bc95-e2762de6f8be"));
            chkIsinlama = (ITTCheckBoxColumn)AddControl(new Guid("8562b538-bbfc-4a90-a70d-bcfbe810c456"));
            chkFilter = (ITTCheckBoxColumn)AddControl(new Guid("734ac344-828f-4fa3-90c9-8e42e8f0e8e2"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("3bae8ecd-576d-4e38-9bd2-9d11b0af752f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("24f9e45c-88da-44e2-9acf-5170f72dd849"));
            base.InitializeControls();
        }

        public BloodProductRequestForm() : base("BLOODPRODUCTREQUEST", "BloodProductRequestForm")
        {
        }

        protected BloodProductRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}