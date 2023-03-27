
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
    /// Dosya Transfer
    /// </summary>
    public partial class FormFTFileRequest : EpisodeActionForm
    {
    /// <summary>
    /// Dosya Transfer (Arşiv Karşılama) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FileTransfer _FileTransfer
        {
            get { return (TTObjectClasses.FileTransfer)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelShelf;
        protected ITTTextBox ReasonForRequest;
        protected ITTTextBox Row;
        protected ITTTextBox Shelf;
        protected ITTLabel labelRequesterDepartment;
        protected ITTLabel labelPatientEpisodeDetails;
        protected ITTLabel labelRequestersInQueue;
        protected ITTLabel labelRequester;
        protected ITTObjectListBox RequesterDepartment;
        protected ITTObjectListBox Requester;
        protected ITTLabel labelFileLocation;
        protected ITTGrid RequestersInQueue;
        protected ITTTextBoxColumn NoInQueue2;
        protected ITTListBoxColumn RequesterUnit2;
        protected ITTListBoxColumn Requester2;
        protected ITTCheckBoxColumn SendDepartment2;
        protected ITTCheckBoxColumn Fullfilled2;
        protected ITTLabel labelRow;
        protected ITTLabel labelReasonForRequest;
        protected ITTObjectListBox FileLocation;
        protected ITTGrid PatientEpisodeDetails;
        protected ITTDateTimePickerColumn EpisodeOpeningDate;
        protected ITTTextBoxColumn EpisodeID;
        protected ITTTextBoxColumn VolumeNo;
        protected ITTListBoxColumn ReasonForAdmission;
        protected ITTCheckBoxColumn Selection;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("70d5e063-59db-400d-ab72-bd5b92b12129"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("373be55d-acf0-404e-be77-64c576247486"));
            labelShelf = (ITTLabel)AddControl(new Guid("40da8f15-7779-447a-a44e-3b361aa3e843"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("da327301-9d20-4560-ac09-609f6bc66e80"));
            Row = (ITTTextBox)AddControl(new Guid("5f5ebcec-654e-4289-8d53-c4c83011b36b"));
            Shelf = (ITTTextBox)AddControl(new Guid("ef8e5819-56ea-4afd-b725-fae8ec4b59f7"));
            labelRequesterDepartment = (ITTLabel)AddControl(new Guid("3c703a0a-57e9-4bc7-8d32-6523b00cf8fe"));
            labelPatientEpisodeDetails = (ITTLabel)AddControl(new Guid("930ab001-b95b-42e9-a433-6d9511482215"));
            labelRequestersInQueue = (ITTLabel)AddControl(new Guid("556f488b-a753-428b-b1fe-70ed2ee8b8a0"));
            labelRequester = (ITTLabel)AddControl(new Guid("6739b7c3-8122-4035-ab95-8bcf3d8efab4"));
            RequesterDepartment = (ITTObjectListBox)AddControl(new Guid("cbfb6737-8c62-4682-bc63-a4a7304ce434"));
            Requester = (ITTObjectListBox)AddControl(new Guid("501769a1-9939-47c7-97e6-bc491c9b03e9"));
            labelFileLocation = (ITTLabel)AddControl(new Guid("46b5fc44-6974-4de8-ac6c-c5f5dfd64da4"));
            RequestersInQueue = (ITTGrid)AddControl(new Guid("9ac699cd-117c-4f79-a6e0-dc52f66b27a4"));
            NoInQueue2 = (ITTTextBoxColumn)AddControl(new Guid("0f287c38-bc42-4dad-8fe1-3cb57d131580"));
            RequesterUnit2 = (ITTListBoxColumn)AddControl(new Guid("5b351363-1611-4006-ad9a-aae179318ea7"));
            Requester2 = (ITTListBoxColumn)AddControl(new Guid("4486d766-f5fa-4eeb-8526-da7d89252ddc"));
            SendDepartment2 = (ITTCheckBoxColumn)AddControl(new Guid("56347dce-0d01-47be-ad0b-aa3ea1bbc927"));
            Fullfilled2 = (ITTCheckBoxColumn)AddControl(new Guid("314f833b-d763-4c28-b974-aac42a0e823d"));
            labelRow = (ITTLabel)AddControl(new Guid("26e358d1-9fbe-455e-863f-dc883aaaed71"));
            labelReasonForRequest = (ITTLabel)AddControl(new Guid("2dd66113-10b9-4cbe-a665-dea9db83548b"));
            FileLocation = (ITTObjectListBox)AddControl(new Guid("007dfed5-c918-4e39-afd1-e2c8bb509b8c"));
            PatientEpisodeDetails = (ITTGrid)AddControl(new Guid("74c368c5-f5b0-4b18-b16c-71f82eeba4a3"));
            EpisodeOpeningDate = (ITTDateTimePickerColumn)AddControl(new Guid("813538bf-a8f3-43c9-9484-f9be61a51311"));
            EpisodeID = (ITTTextBoxColumn)AddControl(new Guid("b4b628ee-eae1-480d-aa79-d661aa36de38"));
            VolumeNo = (ITTTextBoxColumn)AddControl(new Guid("55e496df-f4f7-47d3-9a59-3f586df73c7d"));
            ReasonForAdmission = (ITTListBoxColumn)AddControl(new Guid("f60fb101-36f8-4e84-99e7-312430343e1d"));
            Selection = (ITTCheckBoxColumn)AddControl(new Guid("6ec1af21-d604-4423-bade-929b53483ddb"));
            base.InitializeControls();
        }

        public FormFTFileRequest() : base("FILETRANSFER", "FormFTFileRequest")
        {
        }

        protected FormFTFileRequest(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}