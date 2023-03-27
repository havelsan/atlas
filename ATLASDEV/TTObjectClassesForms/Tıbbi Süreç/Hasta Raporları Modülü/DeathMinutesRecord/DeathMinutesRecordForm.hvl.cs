
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
    /// Ölüm Raporu
    /// </summary>
    public partial class DeathMinutesRecordForm : EpisodeActionForm
    {
    /// <summary>
    /// Ölüm Tutanağı
    /// </summary>
        protected TTObjectClasses.DeathMinutesRecord _DeathMinutesRecord
        {
            get { return (TTObjectClasses.DeathMinutesRecord)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelJudicialNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker DocumetDate;
        protected ITTLabel labelSenderChair;
        protected ITTLabel labelJudicialDate;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("19de900c-4d74-4a3b-afbc-2290b0baba32"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("e9118d45-cb31-43c1-abb4-8c15252476e8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("bdb9dd76-206f-4c53-88f1-5e9f4454be24"));
            labelReportNo = (ITTLabel)AddControl(new Guid("0bc11136-2d0c-4c3a-8cd2-06f84cf8ba9e"));
            ReportNo = (ITTTextBox)AddControl(new Guid("d8a26ca5-a034-480e-a5cc-0785ab2897ae"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("80526fea-b730-40fb-abe6-d2f341e054ec"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("3de8fc1c-76ba-42b9-a53c-f1bef3a7ea2c"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("2116bb09-6a42-4caa-a44b-13e9b8775203"));
            labelJudicialNo = (ITTLabel)AddControl(new Guid("1117bac7-02d8-4da7-b4aa-7f59c88742ff"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("1e13972f-3120-4799-b8ea-97fea1bbf9bf"));
            DocumetDate = (ITTDateTimePicker)AddControl(new Guid("8f652610-53d6-424c-a2ec-b7c63f3688a9"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("be0256da-da60-48c0-af27-da48eb978860"));
            labelJudicialDate = (ITTLabel)AddControl(new Guid("31865813-d060-4679-8337-feb3249dce17"));
            base.InitializeControls();
        }

        public DeathMinutesRecordForm() : base("DEATHMINUTESRECORD", "DeathMinutesRecordForm")
        {
        }

        protected DeathMinutesRecordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}