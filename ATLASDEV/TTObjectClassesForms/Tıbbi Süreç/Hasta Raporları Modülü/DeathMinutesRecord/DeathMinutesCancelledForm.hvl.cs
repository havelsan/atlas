
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
    public partial class DeathMinutesCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Ölüm Tutanağı
    /// </summary>
        protected TTObjectClasses.DeathMinutesRecord _DeathMinutesRecord
        {
            get { return (TTObjectClasses.DeathMinutesRecord)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox Report;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelJudicialNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker DocumetDate;
        protected ITTLabel labelReport;
        protected ITTLabel labelSenderChair;
        protected ITTLabel labelJudicialDate;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("50735e27-5dd1-464c-b3dc-29fbfd292a90"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3dbf4e64-4c0b-402c-b753-124f9b280176"));
            labelReportNo = (ITTLabel)AddControl(new Guid("7ffd420e-9763-44f2-b7e6-f82581ae3e84"));
            ReportNo = (ITTTextBox)AddControl(new Guid("8f4645d3-f5f0-43dd-87e7-a6eb2eca5833"));
            Report = (ITTTextBox)AddControl(new Guid("8ca8b834-7245-4bbf-bb92-039ec5b4d65b"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("9ea4b34e-1979-4904-b8d4-b96b34ad4cc0"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("0f88cc8b-c64d-4ba5-94af-ea191e5ff35a"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("2fe52867-13cb-4da5-85be-2d9ce3b401e1"));
            labelJudicialNo = (ITTLabel)AddControl(new Guid("5a593e48-23a6-4c36-a4a1-bd6340dac608"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("0ec3f274-8a39-49b0-9978-1054546c39c1"));
            DocumetDate = (ITTDateTimePicker)AddControl(new Guid("c8e4145a-670f-4119-b57f-91d64b8864ff"));
            labelReport = (ITTLabel)AddControl(new Guid("e3807257-7512-43e2-8fc6-408cc669c928"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("a35965f7-80d4-4fe7-a01d-0a614c1643d2"));
            labelJudicialDate = (ITTLabel)AddControl(new Guid("f66f724d-b462-4d0d-9d57-91d93322f0ee"));
            base.InitializeControls();
        }

        public DeathMinutesCancelledForm() : base("DEATHMINUTESRECORD", "DeathMinutesCancelledForm")
        {
        }

        protected DeathMinutesCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}