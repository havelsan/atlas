
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
    /// Morg İşlemleri
    /// </summary>
    public partial class MorgueRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTTabControl tttabcontrol3;
        protected ITTTabPage MorgueTabPage;
        protected ITTButton ttbutton1;
        protected ITTButton cmdAutopsy;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel3;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage Materials;
        protected ITTGrid MaterialsGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTListBoxColumn ExMaterials;
        protected ITTTextBoxColumn ExAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn ExNotes;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTLabel labelDoctorFixed;
        protected ITTEnumComboBox StatisticalDeathReason;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTLabel labelReasonForDeath;
        protected ITTLabel labelSenderDoctor;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTObjectListBox DoctorFixed;
        protected ITTObjectListBox SenderDoctor;
        protected ITTTabPage Reporttabpage;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            tttabcontrol3 = (ITTTabControl)AddControl(new Guid("0c435419-5a58-4b05-86ad-57ccc2d9e65c"));
            MorgueTabPage = (ITTTabPage)AddControl(new Guid("e7ea1d21-47f5-4f4c-ac84-2a595746f6a2"));
            ttbutton1 = (ITTButton)AddControl(new Guid("d4f39b40-d697-4519-b88b-3e9489144c14"));
            cmdAutopsy = (ITTButton)AddControl(new Guid("faba5e1f-0223-4ce1-a94a-1122ffd574e6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("cdc9a73e-7be4-46c7-a3e5-2ea5b13bb558"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f509cfd4-889a-4cdb-b9d3-518c40dc421a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5d6e7b02-81c8-472a-a3d1-d0a5c148933f"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("46be301a-0255-409e-be07-acd902aa458e"));
            Materials = (ITTTabPage)AddControl(new Guid("3b365713-a1b2-4762-b7e9-60b73f02cb40"));
            MaterialsGrid = (ITTGrid)AddControl(new Guid("681b91f6-b371-4ee6-9b9f-0896213cd787"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("e2e8b71c-e0e6-4f80-b084-7c43ecfc925d"));
            ExMaterials = (ITTListBoxColumn)AddControl(new Guid("f74de145-fb84-4172-97c6-7819abcc245b"));
            ExAmount = (ITTTextBoxColumn)AddControl(new Guid("fbe194e9-9de5-4d60-a104-3246084d1b8e"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("601b65b1-c88f-44b5-b477-042537e66271"));
            ExNotes = (ITTTextBoxColumn)AddControl(new Guid("562e791e-314a-4839-a080-f9c38ef999ff"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("4207e4e4-a05a-45a4-b856-5b348570fb2f"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("e6352b1f-4eb6-4c4e-80c6-4843323c6847"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("c8fe3acf-4a10-48f5-bb58-81eeeaddbc4f"));
            StatisticalDeathReason = (ITTEnumComboBox)AddControl(new Guid("de494282-72d5-4e63-9cd2-bd2effeb1545"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("69f84bea-c365-474b-b96a-554b3ac909e9"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("fc711b9b-5d05-40bf-adc5-9528c456884b"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("c2e4a534-1ccf-4f68-a8da-1a4ba33d0903"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("7aa10dc9-5d29-46e9-b3ab-5da174825e6d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1c40a0f6-a074-44ec-b243-9e1b2f01f5a7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("72aed1b0-3791-4ee5-934a-5b3296ce3c1c"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("961c76b2-bd3c-40df-bf81-27c69f4fcfd0"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("50c799e6-bde4-4e7f-8e14-61a8da8a4625"));
            Reporttabpage = (ITTTabPage)AddControl(new Guid("de7198fd-9190-4452-8988-85b17fdaae19"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("f2432a87-421d-40be-a287-cf9750921371"));
            base.InitializeControls();
        }

        public MorgueRequestForm() : base("MORGUE", "MorgueRequestForm")
        {
        }

        protected MorgueRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}