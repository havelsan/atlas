
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
    public partial class MorgueRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage Morguetabpage;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage Materials;
        protected ITTGrid MaterialsGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTListBoxColumn ExMaterials;
        protected ITTTextBoxColumn ExAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn ExNotes;
        protected ITTObjectListBox SenderDoctor;
        protected ITTEnumComboBox StatisticalDeathReason;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelReasonForDeath;
        protected ITTLabel labelDoctorFixed;
        protected ITTLabel labelSenderDoctor;
        protected ITTObjectListBox DoctorFixed;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTTabPage Reporttabpage;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0aa2a320-0a67-4547-9b26-9f667db42c24"));
            Morguetabpage = (ITTTabPage)AddControl(new Guid("5d120d77-8d22-4233-b333-dadbec38f4f9"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("fac8a101-2a49-4749-9adb-617b21923c19"));
            Materials = (ITTTabPage)AddControl(new Guid("8643f529-5b1f-4bfd-b042-0beddee0019b"));
            MaterialsGrid = (ITTGrid)AddControl(new Guid("81feee8c-0641-48e1-bb4e-f5988abe435d"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("68cd2993-5232-4e19-a2c1-a1315a731850"));
            ExMaterials = (ITTListBoxColumn)AddControl(new Guid("2af3759d-880a-4a76-b1d1-f127be8ab110"));
            ExAmount = (ITTTextBoxColumn)AddControl(new Guid("975ae9e6-16b8-482e-8d6c-3b4fd3a6a157"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("ba63bed5-0431-46c3-b66a-d560594c1395"));
            ExNotes = (ITTTextBoxColumn)AddControl(new Guid("7f1a0236-8be3-463d-b017-3405d3da18fa"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("1d78a6d3-c754-4b43-9171-096a1bfed797"));
            StatisticalDeathReason = (ITTEnumComboBox)AddControl(new Guid("21efebb5-83f4-4d00-b6dc-75c8d97ae601"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("29d0896a-450b-4ad7-be32-9424e5d913e2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b03a5410-bc71-429b-9fa7-4f2e70834050"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("26dc6d0b-29f3-497b-a5c0-7cd5f68aaf53"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("a3112d8a-a283-4f80-bd81-77e1d9700815"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("e57b988a-f4ce-4af5-ab6c-41579e4e622a"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("a6e485a4-4484-49ef-b31d-3c50d28f6e7c"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("33b8f42f-9da5-43f5-ac3b-067e14215ce4"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("3739e0ea-292e-4241-b033-a1bf446d26d0"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("fe0f1204-7e34-47a6-9a0e-04496810f12d"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("5543acfb-7162-4a72-9a18-e73eb8371562"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ce4025b3-4028-40a9-ac2b-385ff61fedd9"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("cba59df2-95fd-4e5b-b650-8f87cd8be190"));
            Reporttabpage = (ITTTabPage)AddControl(new Guid("d70adf28-93d5-4aa9-9eec-40e02507184b"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("82841dc4-2d51-4a0f-b9a4-a1750d34c904"));
            base.InitializeControls();
        }

        public MorgueRequestAcceptionForm() : base("MORGUE", "MorgueRequestAcceptionForm")
        {
        }

        protected MorgueRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}