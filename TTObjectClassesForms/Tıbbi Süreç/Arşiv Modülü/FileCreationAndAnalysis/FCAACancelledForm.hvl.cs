
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
    public partial class FCAACancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Dosya Oluşturma ve Analiz (Arşiv Oluşturma) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FileCreationAndAnalysis _FileCreationAndAnalysis
        {
            get { return (TTObjectClasses.FileCreationAndAnalysis)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextboxOnlyYear;
        protected ITTTextBox Shelf;
        protected ITTTextBox FolderInformation;
        protected ITTTextBox Row;
        protected ITTTextBox PatientFolderID;
        protected ITTTextBox EpisodeFolderDefID;
        protected ITTTextBox txtRoom;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFolderContent;
        protected ITTLabel labelShelf;
        protected ITTGrid FolderContents;
        protected ITTTextBoxColumn EpisodeFolderID;
        protected ITTListBoxColumn File;
        protected ITTCheckBoxColumn chkStatus;
        protected ITTLabel labelFolderInformation;
        protected ITTLabel labelRow;
        protected ITTLabel labelPatientFolderID;
        protected ITTLabel labelEpisodeFolderID;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox chkAdliVaka;
        protected ITTObjectListBox listBoxBuilding;
        protected ITTLabel lblBuilding;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("fa89d979-522e-4368-a78a-038f00f0d62e"));
            tttextboxOnlyYear = (ITTTextBox)AddControl(new Guid("bb0cb7ab-5012-4181-84f2-feea23e655d0"));
            Shelf = (ITTTextBox)AddControl(new Guid("7d5e37a6-3af2-4308-8a37-01c49805e3b5"));
            FolderInformation = (ITTTextBox)AddControl(new Guid("9e775039-da4c-434c-9b91-cf0526d55a80"));
            Row = (ITTTextBox)AddControl(new Guid("6813b7dd-3de0-4051-a01b-58370ab6e926"));
            PatientFolderID = (ITTTextBox)AddControl(new Guid("4e8cd948-078c-4964-984d-36760396108d"));
            EpisodeFolderDefID = (ITTTextBox)AddControl(new Guid("93e2458c-f14f-49d8-9fe2-12a136dbbfbc"));
            txtRoom = (ITTTextBox)AddControl(new Guid("9e5a2409-0559-4f06-be02-919bd6d26c03"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("91fae12e-2475-442f-88f4-063201947f83"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("058c09c7-a917-43ff-a996-dacebfe3e066"));
            labelFolderContent = (ITTLabel)AddControl(new Guid("82b5be3f-d0e5-420e-b1a0-e8d12590fa1c"));
            labelShelf = (ITTLabel)AddControl(new Guid("e7a3100c-4e7a-4a63-98b5-eb73134602ba"));
            FolderContents = (ITTGrid)AddControl(new Guid("da06f75f-8e9e-47ff-864d-2b1946c03092"));
            EpisodeFolderID = (ITTTextBoxColumn)AddControl(new Guid("03bed1b4-fd6b-4fd7-a7cd-14dafe4f2877"));
            File = (ITTListBoxColumn)AddControl(new Guid("deac5d4d-158f-4a3c-9028-709ff0cd82b9"));
            chkStatus = (ITTCheckBoxColumn)AddControl(new Guid("244c4883-0657-41c3-bb90-b717fa463033"));
            labelFolderInformation = (ITTLabel)AddControl(new Guid("c2940155-7a11-483e-a079-2895cb09ce69"));
            labelRow = (ITTLabel)AddControl(new Guid("d1435783-ecbd-44b7-806a-a20d32d1bbea"));
            labelPatientFolderID = (ITTLabel)AddControl(new Guid("e5de0bd4-619e-421c-9f5e-7720776e4a48"));
            labelEpisodeFolderID = (ITTLabel)AddControl(new Guid("0c352f83-82b8-4e2a-a174-e16d5061e343"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("bdfa48bc-e489-44a3-921b-88ddb208e021"));
            chkAdliVaka = (ITTCheckBox)AddControl(new Guid("e46ca1c0-b65e-45ba-a946-bbf1b7c2bcb1"));
            listBoxBuilding = (ITTObjectListBox)AddControl(new Guid("9e1030a2-ce76-4189-abaf-966f7f96867d"));
            lblBuilding = (ITTLabel)AddControl(new Guid("22d1e90a-eb30-4efe-b48d-d12d97802077"));
            base.InitializeControls();
        }

        public FCAACancelledForm() : base("FILECREATIONANDANALYSIS", "FCAACancelledForm")
        {
        }

        protected FCAACancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}