
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
    /// FormFTFileCancelled
    /// </summary>
    public partial class FormFTFileCancelled : EpisodeActionForm
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
        protected ITTTextBoxColumn NoInQueueInner;
        protected ITTListBoxColumn RequesterUnitInner;
        protected ITTListDefComboBoxColumn RequesterInner;
        protected ITTCheckBoxColumn SendDepartmentInner;
        protected ITTCheckBoxColumn FullfilledInner;
        protected ITTLabel labelReasonForRequest;
        protected ITTLabel labelShelf;
        protected ITTObjectListBox RequesterDepartment;
        protected ITTGrid PatientEpisodeDetails;
        protected ITTDateTimePickerColumn EpisodeOpeningDate;
        protected ITTTextBoxColumn EpisodeID;
        protected ITTTextBoxColumn VolumeNo;
        protected ITTListBoxColumn ReasonForAdmission;
        protected ITTCheckBoxColumn Selection;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("60b50d8f-b406-4bca-9ac3-33da6139784c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("47431bef-5eec-4d85-8aec-21da1ec18b2d"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("b77a83a4-c256-467c-82de-0e29701b2bdf"));
            ArchiveNote = (ITTTextBox)AddControl(new Guid("1e3e0a5d-a7b4-4652-93dd-010b84ceb522"));
            Row = (ITTTextBox)AddControl(new Guid("ae046b12-6530-49b4-a017-866ea8f1b8b4"));
            Shelf = (ITTTextBox)AddControl(new Guid("84a0dfb6-5dee-45a6-a3ea-b92124285d65"));
            labelPatientEpisodeDetails = (ITTLabel)AddControl(new Guid("53623b51-f137-442f-af07-55e16aa6b133"));
            labelArchiveNote = (ITTLabel)AddControl(new Guid("49817afc-5327-4666-b563-634a04825707"));
            FileLocation = (ITTObjectListBox)AddControl(new Guid("a65679eb-1556-4a9e-882e-88b83f82d05b"));
            Requester = (ITTObjectListBox)AddControl(new Guid("330d0cf3-67ea-41dc-a1ce-5b0b8317c795"));
            labelRequestersInQueue = (ITTLabel)AddControl(new Guid("ddaff593-1bed-4998-90e4-898c29d41972"));
            labelFileLocation = (ITTLabel)AddControl(new Guid("ed965f37-67e6-41e9-baad-851eb572650c"));
            labelRequesterDepartment = (ITTLabel)AddControl(new Guid("a42fa474-f15a-485a-8453-127b74494bc6"));
            labelRow = (ITTLabel)AddControl(new Guid("970aab98-d449-4d86-a78a-16fc523a3fb5"));
            labelRequester = (ITTLabel)AddControl(new Guid("684a3923-c912-4ac6-9aa6-a053994bf6c2"));
            RequestersInQueue = (ITTGrid)AddControl(new Guid("b7a121e8-5527-4e65-9a97-4c841c0e4153"));
            NoInQueueInner = (ITTTextBoxColumn)AddControl(new Guid("a16f6cbd-c377-420f-9a82-d8202064d7ea"));
            RequesterUnitInner = (ITTListBoxColumn)AddControl(new Guid("847603d5-6cd9-4635-a270-159a2a7fb225"));
            RequesterInner = (ITTListDefComboBoxColumn)AddControl(new Guid("762edf00-cfa4-4b7c-935f-8fbeab9fb7bc"));
            SendDepartmentInner = (ITTCheckBoxColumn)AddControl(new Guid("e3661f51-32ec-4eac-880a-22c9ce53fcb5"));
            FullfilledInner = (ITTCheckBoxColumn)AddControl(new Guid("8bdd645f-2cf1-4753-b1c4-748b6c96da54"));
            labelReasonForRequest = (ITTLabel)AddControl(new Guid("a508635e-b69d-41b6-9839-1ee7d2fae3eb"));
            labelShelf = (ITTLabel)AddControl(new Guid("e3ee254f-69ec-4502-afff-07e65af34684"));
            RequesterDepartment = (ITTObjectListBox)AddControl(new Guid("23bb38aa-b406-43c1-afcd-a152b6bb1cd3"));
            PatientEpisodeDetails = (ITTGrid)AddControl(new Guid("7dad140e-445d-4610-a170-d56548a79357"));
            EpisodeOpeningDate = (ITTDateTimePickerColumn)AddControl(new Guid("5a8553fa-aff9-405a-82ca-a46f0062ba07"));
            EpisodeID = (ITTTextBoxColumn)AddControl(new Guid("1c81e0b6-e8d3-41a9-8bba-0bc96cbce3e5"));
            VolumeNo = (ITTTextBoxColumn)AddControl(new Guid("e912a1d4-409c-4e86-8fba-f282f6e9ba08"));
            ReasonForAdmission = (ITTListBoxColumn)AddControl(new Guid("23273efc-0ad3-436f-a57c-b812789498e9"));
            Selection = (ITTCheckBoxColumn)AddControl(new Guid("db3542ff-a1c6-48df-89c6-e726dfbace14"));
            base.InitializeControls();
        }

        public FormFTFileCancelled() : base("FILETRANSFER", "FormFTFileCancelled")
        {
        }

        protected FormFTFileCancelled(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}