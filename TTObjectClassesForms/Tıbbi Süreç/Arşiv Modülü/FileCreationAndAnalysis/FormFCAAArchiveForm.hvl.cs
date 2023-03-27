
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
    /// Dosya Oluşturma ve Analiz
    /// </summary>
    public partial class FormFCAAArchive : EpisodeActionForm
    {
    /// <summary>
    /// Dosya Oluşturma ve Analiz (Arşiv Oluşturma) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FileCreationAndAnalysis _FileCreationAndAnalysis
        {
            get { return (TTObjectClasses.FileCreationAndAnalysis)_ttObject; }
        }

        protected ITTObjectListBox listBoxBuilding;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox chkHMHastaYakini;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox4;
        protected ITTCheckBox ttcheckbox5;
        protected ITTCheckBox ttcheckbox6;
        protected ITTCheckBox ttcheckbox7;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextboxOnlyYear;
        protected ITTTextBox Shelf;
        protected ITTTextBox EpisodeFolderID;
        protected ITTTextBox FolderInformation;
        protected ITTTextBox Row;
        protected ITTTextBox PatientFolderID;
        protected ITTTextBox txtRoom;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox chkAdliVaka;
        protected ITTLabel labelEpisodeFolderID;
        protected ITTLabel labelPatientEpisodeDetails;
        protected ITTLabel labelRow;
        protected ITTLabel labelFolderInformation;
        protected ITTLabel labelPatientFolderID;
        protected ITTGrid FolderContents;
        protected ITTTextBoxColumn GridEpisodeFolderID;
        protected ITTListBoxColumn File;
        protected ITTCheckBoxColumn FolderContentStatus;
        protected ITTLabel labelShelf;
        protected ITTLabel labelFileContent;
        protected ITTGrid PatientEpisodeDetails;
        protected ITTDateTimePickerColumn OpeningDate;
        protected ITTTextBoxColumn EpisodeID;
        protected ITTTextBoxColumn VolumeNo;
        protected ITTListBoxColumn ReasonForAdmission;
        protected ITTLabel labelFile;
        protected ITTCheckBox InArchive;
        protected ITTCheckBox InInCompleteArea;
        protected ITTLabel ttlabel2;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox ttcheckbox8;
        protected ITTCheckBox ttcheckbox9;
        protected ITTCheckBox ttcheckbox10;
        protected ITTCheckBox ttcheckbox11;
        protected ITTCheckBox ttcheckbox12;
        protected ITTCheckBox ttcheckbox13;
        protected ITTCheckBox ttcheckbox14;
        protected ITTCheckBox ttcheckbox18;
        protected ITTCheckBox ttcheckbox17;
        protected ITTCheckBox ttcheckbox16;
        protected ITTCheckBox ttcheckbox15;
        protected ITTCheckBox ttcheckbox19;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel4;
        protected ITTGroupBox ttgroupbox3;
        protected ITTCheckBox ttcheckbox20;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel5;
        protected ITTLabel lblBuilding;
        override protected void InitializeControls()
        {
            listBoxBuilding = (ITTObjectListBox)AddControl(new Guid("61af415a-6fe2-42b6-94bf-2821d6e8cc39"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("8604e4d7-fe7b-4651-a880-253971892e89"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2cd24070-2077-4b5f-bb56-b3643256d6b9"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c1cd4467-bf5a-4a24-8b23-da5fcf9489f1"));
            chkHMHastaYakini = (ITTCheckBox)AddControl(new Guid("c42f5a5c-e3c0-4ff8-80be-37dca6729321"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("90128aa8-5427-437b-98a2-5a378ddda144"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("154e3ce5-8ff7-4432-bc8d-fd0c7c172fd3"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("e5a6c4ed-c688-4371-9dbf-07493cb52a9e"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("e2fd32cd-d4e8-4ebc-adca-f3cf0613f4d1"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("21a01d6b-b1a9-408d-acc9-54c7bb39801c"));
            ttcheckbox7 = (ITTCheckBox)AddControl(new Guid("215ad538-6a91-489a-acf0-6b8a10d55222"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d40dde30-6b0f-464b-afef-69963d523259"));
            tttextboxOnlyYear = (ITTTextBox)AddControl(new Guid("32cbb1c7-00c2-4bdf-8a87-7f5b0506c9b0"));
            Shelf = (ITTTextBox)AddControl(new Guid("3ab630a0-906f-4f27-a4f1-40175ddc41aa"));
            EpisodeFolderID = (ITTTextBox)AddControl(new Guid("7e715f31-2a96-4837-85dc-5306e4e4dad9"));
            FolderInformation = (ITTTextBox)AddControl(new Guid("8da87634-a2d6-4fdb-874b-595e07b170f0"));
            Row = (ITTTextBox)AddControl(new Guid("c4eab4e5-1dc7-4725-95ab-8d7b9ff044c2"));
            PatientFolderID = (ITTTextBox)AddControl(new Guid("98e40c21-0051-4ffb-a752-d04a313d8c78"));
            txtRoom = (ITTTextBox)AddControl(new Guid("c667d963-05e3-4f38-9777-c8252e550111"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("b6073b77-48b0-4428-a560-8fcf11e10844"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c812e369-d93d-4d94-9e7e-f6d4afb2d256"));
            chkAdliVaka = (ITTCheckBox)AddControl(new Guid("646c62ca-7e23-41b6-9135-505dcd341206"));
            labelEpisodeFolderID = (ITTLabel)AddControl(new Guid("3774317b-db55-48f2-a384-04d03c983ea8"));
            labelPatientEpisodeDetails = (ITTLabel)AddControl(new Guid("93dd75ae-c365-4762-a16d-171e730efa8f"));
            labelRow = (ITTLabel)AddControl(new Guid("56edc2b2-9ffd-42cd-ad5e-2114ee53b89c"));
            labelFolderInformation = (ITTLabel)AddControl(new Guid("c47120f8-29a5-4bfa-b32b-3b03bc71d250"));
            labelPatientFolderID = (ITTLabel)AddControl(new Guid("729cde0c-6277-4f78-b7d1-a7b378fd9f02"));
            FolderContents = (ITTGrid)AddControl(new Guid("a781a71d-1680-439e-872a-b67b06d80197"));
            GridEpisodeFolderID = (ITTTextBoxColumn)AddControl(new Guid("b3411234-edda-4e0a-87a2-54cd069b19e2"));
            File = (ITTListBoxColumn)AddControl(new Guid("53e0aa3e-6f40-4dd1-a9f6-db0e177d5ad7"));
            FolderContentStatus = (ITTCheckBoxColumn)AddControl(new Guid("2b1943fc-1fc2-45a1-ba4a-952b6084e183"));
            labelShelf = (ITTLabel)AddControl(new Guid("51bad674-7abc-4c3d-a5a8-c3815d09f56f"));
            labelFileContent = (ITTLabel)AddControl(new Guid("21459d0f-7eeb-494b-bd1c-c9af645201bd"));
            PatientEpisodeDetails = (ITTGrid)AddControl(new Guid("815ba239-4c2c-44f4-aa5b-fb9c99c498bb"));
            OpeningDate = (ITTDateTimePickerColumn)AddControl(new Guid("c553d3cd-f1ff-40e2-aaf4-21a59a9570cf"));
            EpisodeID = (ITTTextBoxColumn)AddControl(new Guid("e9853b03-7c58-4fc5-9419-3a5aab436ffc"));
            VolumeNo = (ITTTextBoxColumn)AddControl(new Guid("a9d8d732-4e7e-4533-b8f2-9f7c0bb00ed6"));
            ReasonForAdmission = (ITTListBoxColumn)AddControl(new Guid("6fc8197e-57c0-4b65-9724-9403258324e5"));
            labelFile = (ITTLabel)AddControl(new Guid("475949a4-de6f-42ba-afd9-61b2f78e2cf8"));
            InArchive = (ITTCheckBox)AddControl(new Guid("9af55a59-e19e-4ecd-b28d-655f91f4a990"));
            InInCompleteArea = (ITTCheckBox)AddControl(new Guid("11c68b87-13a9-43da-b07c-7019257161a3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7cf2adcc-4018-44c1-9160-c89b49198569"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("09a314af-02d5-42d0-8f17-456b479790f3"));
            ttcheckbox8 = (ITTCheckBox)AddControl(new Guid("9f1f0405-59f2-46e3-9b3e-d703ac20e6f3"));
            ttcheckbox9 = (ITTCheckBox)AddControl(new Guid("073ef1d3-ee17-4921-9d14-cefe8fb16add"));
            ttcheckbox10 = (ITTCheckBox)AddControl(new Guid("8c5c52a2-e624-4f46-a301-ee79b3c4c2ad"));
            ttcheckbox11 = (ITTCheckBox)AddControl(new Guid("40561b24-a84b-450d-91ff-966860cdcd83"));
            ttcheckbox12 = (ITTCheckBox)AddControl(new Guid("46a504ba-4fa6-4fde-bc09-b82d1981ba8d"));
            ttcheckbox13 = (ITTCheckBox)AddControl(new Guid("3c92dfc5-6a46-4512-acdc-b3827c2804ce"));
            ttcheckbox14 = (ITTCheckBox)AddControl(new Guid("c2cf998d-687a-43e2-bc92-0221aefb6e09"));
            ttcheckbox18 = (ITTCheckBox)AddControl(new Guid("b122c312-997a-4599-a9f3-a350d6d01c7f"));
            ttcheckbox17 = (ITTCheckBox)AddControl(new Guid("fa5eee74-a631-4f6d-b325-a68d911c417d"));
            ttcheckbox16 = (ITTCheckBox)AddControl(new Guid("3513c0c6-64de-4db5-8952-173ffd5c57b7"));
            ttcheckbox15 = (ITTCheckBox)AddControl(new Guid("0da3324f-20f6-4400-a711-515d8cb81a8a"));
            ttcheckbox19 = (ITTCheckBox)AddControl(new Guid("173d985f-1ea6-470c-a16b-4328de039683"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("cce1e2ba-d688-4322-b4cc-bd424339e678"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c13a0abc-deda-4d6e-a9c1-4fd30dcbc385"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("fc9c85d5-b3ef-4725-ba5f-932ed846267f"));
            ttcheckbox20 = (ITTCheckBox)AddControl(new Guid("7e906f16-0cb7-43c1-8d60-bb4caf4e80e2"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("4ab6de6c-d8a9-47e6-b0c3-57186ec0b8ae"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ebab9aa6-cb25-4a70-bcd4-c216935e0e96"));
            lblBuilding = (ITTLabel)AddControl(new Guid("062a43e3-90b8-4a0d-a6a2-4023308940fc"));
            base.InitializeControls();
        }

        public FormFCAAArchive() : base("FILECREATIONANDANALYSIS", "FormFCAAArchive")
        {
        }

        protected FormFCAAArchive(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}