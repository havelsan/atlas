
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
    /// Dış XXXXXX Sağlık Kurulu Raporları Kontrol
    /// </summary>
    public partial class CEHHCRCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXX Sağlık Kurulu Raporları Kontrol
    /// </summary>
        protected TTObjectClasses.CheckingExternalHospitalHealthCommitteeReports _CheckingExternalHospitalHealthCommitteeReports
        {
            get { return (TTObjectClasses.CheckingExternalHospitalHealthCommitteeReports)_ttObject; }
        }

        protected ITTTextBox ConsignmentNote;
        protected ITTTextBox ReasonForRequest;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ChairSendFrom;
        protected ITTLabel labelChairSendFrom;
        protected ITTLabel labelConsignmentNote;
        protected ITTLabel labelSendingDate;
        protected ITTLabel labelReasonForExamination;
        protected ITTLabel labelReasonForRequest;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTDateTimePicker SendingDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid MatterSliceAnecdote;
        protected ITTTextBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTTextBoxColumn Matter;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        override protected void InitializeControls()
        {
            ConsignmentNote = (ITTTextBox)AddControl(new Guid("37c26bd9-0e0e-4fec-be20-133e1b123165"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("8560e4ce-74d4-4a77-9a61-69be46b6137f"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("435f2bff-b140-495c-b624-5a847519c694"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("3d391726-c310-4353-81b1-e301e7e25859"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6e6fc2b5-f724-4ef8-83e1-584d88a73182"));
            ChairSendFrom = (ITTObjectListBox)AddControl(new Guid("470f0a84-2e39-4558-b47d-009b4fc10854"));
            labelChairSendFrom = (ITTLabel)AddControl(new Guid("8b17e1d4-def0-4989-9c5e-952618bf135e"));
            labelConsignmentNote = (ITTLabel)AddControl(new Guid("acc93e52-33e6-4f2d-b2e0-b63c8b14ea0e"));
            labelSendingDate = (ITTLabel)AddControl(new Guid("a55862ab-8d06-47d3-b3d2-21612fb7ddfe"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("1cf309c2-61b9-4403-be99-87e2f483cf1c"));
            labelReasonForRequest = (ITTLabel)AddControl(new Guid("fa55e25f-13b3-4f59-ad64-d4d4a9835abc"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("af855f2a-5846-44c2-a967-21f1b221360c"));
            SendingDate = (ITTDateTimePicker)AddControl(new Guid("8fb8d2cb-b008-4d8d-8368-9f571c5e43f7"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("5215874e-ad53-48e5-b21b-fd9ae23ad7f6"));
            MatterSliceAnecdote = (ITTGrid)AddControl(new Guid("50e903d3-acef-44f1-9f4c-fd8c973b44dd"));
            Slice = (ITTTextBoxColumn)AddControl(new Guid("2120c862-629f-488d-85bd-d5f428d6a371"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("9c70fd6a-20fc-4b62-973c-3a0198c95759"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("d74d3134-3124-4d73-961e-25eb1da92d17"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("08655b8a-5848-4722-83c9-12e35362e1dc"));
            base.InitializeControls();
        }

        public CEHHCRCancelledForm() : base("CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS", "CEHHCRCancelledForm")
        {
        }

        protected CEHHCRCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}