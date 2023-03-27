
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
    public partial class BaseMedulaTransferForm : TTForm
    {
    /// <summary>
    /// Medulaya Aktar
    /// </summary>
        protected TTObjectClasses.MedulaTransfer _MedulaTransfer
        {
            get { return (TTObjectClasses.MedulaTransfer)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage cancelledTabpage;
        protected ITTGrid cancelledBaseMedulaWLActions;
        protected ITTTextBoxColumn MedulaActionID;
        protected ITTDateTimePickerColumn WorkListDate;
        protected ITTStateComboBoxColumn CurrentStateDefID;
        protected ITTTabPage waitForAnswerTabpage;
        protected ITTGrid waitForAnswerBaseMedulaWLActions;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTStateComboBoxColumn ttstatecomboboxcolumn1;
        protected ITTTabPage completedTabpage;
        protected ITTGrid completedBaseMedulaWLActions;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTStateComboBoxColumn ttstatecomboboxcolumn2;
        protected ITTTextBox TemplateFileName;
        protected ITTLabel labelTemplateFileName;
        protected ITTLabel labelTransferDate;
        protected ITTDateTimePicker TransferDate;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labelsaglikTesisKodu;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4308c44e-1a32-4c06-a892-0ecbd1b53c1f"));
            cancelledTabpage = (ITTTabPage)AddControl(new Guid("d8a7864a-54d0-4657-8438-05430fdce512"));
            cancelledBaseMedulaWLActions = (ITTGrid)AddControl(new Guid("813ef818-3792-40da-a8d5-aaaa66314783"));
            MedulaActionID = (ITTTextBoxColumn)AddControl(new Guid("b8830073-07bf-4f20-b525-b788f5b63162"));
            WorkListDate = (ITTDateTimePickerColumn)AddControl(new Guid("ab6842b3-ae7e-40c5-a87c-7b46cc957a02"));
            CurrentStateDefID = (ITTStateComboBoxColumn)AddControl(new Guid("f18b7c50-7806-41ef-83b5-7bd439599930"));
            waitForAnswerTabpage = (ITTTabPage)AddControl(new Guid("eed9911b-ef64-4e91-bf39-b920158c09e2"));
            waitForAnswerBaseMedulaWLActions = (ITTGrid)AddControl(new Guid("11754fa7-7d18-4747-950b-99b0451cf877"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("8d332059-fe27-4b3b-9a7d-39e60a4fa736"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("801f1bf1-7969-40d7-9a16-1fe5137605dc"));
            ttstatecomboboxcolumn1 = (ITTStateComboBoxColumn)AddControl(new Guid("583d7a10-bd45-46ef-ab8f-2f35cb3398fc"));
            completedTabpage = (ITTTabPage)AddControl(new Guid("61da6605-6b48-44f2-9275-427db994d2da"));
            completedBaseMedulaWLActions = (ITTGrid)AddControl(new Guid("7820b200-55a3-46d8-8a01-e58e89f4f056"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("9be0351e-7541-4eab-b953-fca43383678b"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("22d77add-9774-4b0e-a942-6e6f712a5b0d"));
            ttstatecomboboxcolumn2 = (ITTStateComboBoxColumn)AddControl(new Guid("63fee76b-ec48-4b19-a433-a56ebe0bf0a7"));
            TemplateFileName = (ITTTextBox)AddControl(new Guid("3b9b2d32-272c-480d-9f2b-aae15c1bd0cb"));
            labelTemplateFileName = (ITTLabel)AddControl(new Guid("d8dc8123-ef2a-4f68-b54b-6a746a714955"));
            labelTransferDate = (ITTLabel)AddControl(new Guid("a57b2e2b-4f5c-48c0-a1a9-0f3309d2554c"));
            TransferDate = (ITTDateTimePicker)AddControl(new Guid("9e84fa87-ed05-4c27-b46f-4d76c56a5946"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("2b611268-4404-47c0-9cac-cfd9da9b51e5"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("e4e3b080-ae1e-4c0e-af01-6c5d5d8673e3"));
            base.InitializeControls();
        }

        public BaseMedulaTransferForm() : base("MEDULATRANSFER", "BaseMedulaTransferForm")
        {
        }

        protected BaseMedulaTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}