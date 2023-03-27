
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
    public partial class FormFTFileFullfilment : EpisodeActionForm
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
        protected ITTTextBox ReasonForRequest;
        protected ITTTextBox ArchiveNote;
        protected ITTTextBox Row;
        protected ITTTextBox Shelf;
        protected ITTLabel labelPatientEpisodeDetails;
        protected ITTLabel labelArchiveNote;
        protected ITTObjectListBox FileLocation;
        protected ITTObjectListBox Requester;
        protected ITTLabel labelRequestersInQueue;
        protected ITTLabel labelFileLocation;
        protected ITTLabel labelRequesterDepartment;
        protected ITTLabel labelRow;
        protected ITTLabel labelRequester;
        protected ITTGrid RequestersInQueue;
        protected ITTTextBoxColumn NoInQueue2;
        protected ITTListBoxColumn RequesterUnit2;
        protected ITTListDefComboBoxColumn Requester2;
        protected ITTCheckBoxColumn SendDepartment2;
        protected ITTCheckBoxColumn Fullfilled2;
        protected ITTLabel labelReasonForRequest;
        protected ITTGrid PatientEpisodeDetails;
        protected ITTDateTimePickerColumn EpisodeOpeningDate;
        protected ITTTextBoxColumn EpisodeID;
        protected ITTTextBoxColumn VolumeNo;
        protected ITTListBoxColumn ReasonForAdmission;
        protected ITTCheckBoxColumn Selection;
        protected ITTLabel labelShelf;
        protected ITTObjectListBox RequesterDepartment;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("80de6061-467a-4f3d-b7d6-d9aa37a73d3c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("18bccccb-8a6c-4971-93f3-85187ca48ae5"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("a5f74226-8f81-4cca-8e32-06edcd04f445"));
            ArchiveNote = (ITTTextBox)AddControl(new Guid("23d72fe9-3100-436d-87c7-7755bf265010"));
            Row = (ITTTextBox)AddControl(new Guid("602c18d0-3e8e-4b2a-bf45-ab45d81b07ac"));
            Shelf = (ITTTextBox)AddControl(new Guid("ba50e717-8ef3-47c1-b29d-b6929c6d883a"));
            labelPatientEpisodeDetails = (ITTLabel)AddControl(new Guid("f25d6ccd-1458-43c2-8e85-14ba12616de6"));
            labelArchiveNote = (ITTLabel)AddControl(new Guid("28108e80-ad06-4f52-a4c3-25e07d258f7b"));
            FileLocation = (ITTObjectListBox)AddControl(new Guid("62d25f91-af58-498c-8d6a-413536406c0b"));
            Requester = (ITTObjectListBox)AddControl(new Guid("60d6a054-62d8-43f2-9d67-44d3d7388854"));
            labelRequestersInQueue = (ITTLabel)AddControl(new Guid("a315a34e-e430-4b78-88e1-4ae7fa366735"));
            labelFileLocation = (ITTLabel)AddControl(new Guid("d3b6f833-4b47-4d5f-ad93-55f857f5ef0c"));
            labelRequesterDepartment = (ITTLabel)AddControl(new Guid("828b19ec-28d2-4660-a1fb-5685bd041795"));
            labelRow = (ITTLabel)AddControl(new Guid("fc0c2f45-5de0-4c1e-9400-6e93ad361dbf"));
            labelRequester = (ITTLabel)AddControl(new Guid("71c3ad50-784e-4786-aa16-76722ae4d7c9"));
            RequestersInQueue = (ITTGrid)AddControl(new Guid("6142a29d-0a1b-4f73-8451-838245aaf774"));
            NoInQueue2 = (ITTTextBoxColumn)AddControl(new Guid("da9162f9-5402-48be-8c8d-d54a12628fd4"));
            RequesterUnit2 = (ITTListBoxColumn)AddControl(new Guid("1273d7f9-113a-4669-b13b-568484420595"));
            Requester2 = (ITTListDefComboBoxColumn)AddControl(new Guid("dc8bcf5e-aba3-42af-ae08-0ea570e6cc67"));
            SendDepartment2 = (ITTCheckBoxColumn)AddControl(new Guid("da4faeb4-3b0b-45f7-9188-81ce509caf4d"));
            Fullfilled2 = (ITTCheckBoxColumn)AddControl(new Guid("b36c90ed-8094-4703-9cc0-b54b32cb2a16"));
            labelReasonForRequest = (ITTLabel)AddControl(new Guid("c4f80f26-0c14-4213-a8d1-8f22ca06a84a"));
            PatientEpisodeDetails = (ITTGrid)AddControl(new Guid("0d52f9e9-ed80-42ce-8b68-b3a7d214211c"));
            EpisodeOpeningDate = (ITTDateTimePickerColumn)AddControl(new Guid("d5fa5fc9-0264-487d-8de6-64f2b3c581da"));
            EpisodeID = (ITTTextBoxColumn)AddControl(new Guid("3a547cc6-22f2-4848-9353-07cc18c28849"));
            VolumeNo = (ITTTextBoxColumn)AddControl(new Guid("aff68f54-b772-4ba9-b266-16e0e09f05f5"));
            ReasonForAdmission = (ITTListBoxColumn)AddControl(new Guid("96a83329-dac9-4b0c-9f8d-45bca3a6948a"));
            Selection = (ITTCheckBoxColumn)AddControl(new Guid("84be89fd-862a-4373-9990-6398b35a3eb9"));
            labelShelf = (ITTLabel)AddControl(new Guid("b14f3f8b-8384-488f-a919-df3bc4964331"));
            RequesterDepartment = (ITTObjectListBox)AddControl(new Guid("6121ce2f-31ea-4aa0-9c6f-e0a49ff8747c"));
            base.InitializeControls();
        }

        public FormFTFileFullfilment() : base("FILETRANSFER", "FormFTFileFullfilment")
        {
        }

        protected FormFTFileFullfilment(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}