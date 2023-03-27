
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
    public partial class MorgueDoctorControlForm : EpisodeActionForm
    {
    /// <summary>
    /// Morg İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Morgue _Morgue
        {
            get { return (TTObjectClasses.Morgue)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageMorgue;
        protected ITTTextBox externalDoctFixed;
        protected ITTEnumComboBox DeathPlace;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage Materials;
        protected ITTGrid MaterialsGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTListBoxColumn ExMaterials;
        protected ITTTextBoxColumn ExAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn ExNotes;
        protected ITTLabel ttlabel1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox Cupboard;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelMorgueCupboardNo;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox SenderDoctor;
        protected ITTObjectListBox MaterialsAdmittedFrom;
        protected ITTObjectListBox DoctorFixed;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelQuarantineCupboardNo;
        protected ITTLabel labelMaterialsAdmittedTo;
        protected ITTLabel ttlabel10;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel3;
        protected ITTTextBox MorgueCupboardNo;
        protected ITTTextBox MaterialsAdmittedTo;
        protected ITTTextBox DeathBodyAdmittedTo;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelMaterialsAdmittedFrom;
        protected ITTTabPage tttabpageReport;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("328dfaeb-9cf2-4888-977a-98474afbdeab"));
            tttabpageMorgue = (ITTTabPage)AddControl(new Guid("97d7bbb7-cd7a-41da-952f-6036e4b38e98"));
            externalDoctFixed = (ITTTextBox)AddControl(new Guid("e7efe64f-9355-4dc5-9684-20048e56cde8"));
            DeathPlace = (ITTEnumComboBox)AddControl(new Guid("cd364799-a23b-444f-af60-42e6fe13db65"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("c255e4ba-84db-4147-bc0f-5a007058a05b"));
            Materials = (ITTTabPage)AddControl(new Guid("dce28b79-2ce6-4a68-9658-dbfe1b60b3c1"));
            MaterialsGrid = (ITTGrid)AddControl(new Guid("fd2baa82-4c70-412a-9588-0468c1d92fff"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("e7226c1f-8922-4231-a69f-afea70005c59"));
            ExMaterials = (ITTListBoxColumn)AddControl(new Guid("43b243a2-4dbb-441d-b531-b2c23b64b017"));
            ExAmount = (ITTTextBoxColumn)AddControl(new Guid("adfb314f-63c8-482c-89ec-d77833ae6937"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("95ec6e7f-88f3-4973-aed2-c08cd603d086"));
            ExNotes = (ITTTextBoxColumn)AddControl(new Guid("30208c1c-7bf3-4df9-b76f-dff83d04f1a6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d3ad5ac3-5c50-4b9d-8ae7-c269dcbfe0c7"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("eefdbc23-dd69-43a0-9343-35a6facea14b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("5db066be-2f04-4853-bc47-35bc70a83900"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("ebd610c4-acd2-4279-aeef-46ee987e2331"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("f6fafdbc-5388-4e04-929e-f6c9bfc491aa"));
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("0a796088-f057-40e3-a4f3-411d2236f5af"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d72daa14-2534-4aef-a3e5-14f60a345083"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("caaebaef-86ce-4a8d-935f-7db09c952e1b"));
            Cupboard = (ITTObjectListBox)AddControl(new Guid("2f88e292-b16a-4771-b130-8deb1e8eb022"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9a170b2e-c8dd-4a05-81b9-7b09313aa90a"));
            labelMorgueCupboardNo = (ITTLabel)AddControl(new Guid("bb511588-87d7-42b4-8053-7a785e8a9043"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6828a91d-fd1b-4e21-99ed-41eb5499643a"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("8236825d-df26-46ae-a654-29a024b18b37"));
            MaterialsAdmittedFrom = (ITTObjectListBox)AddControl(new Guid("102c7ac7-fdab-407b-a2a3-1493de20a64e"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("21117710-df81-4ee2-98ee-c83e870fcbdb"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("e976730d-4866-45ca-86b7-2dfbb7aecb3f"));
            labelQuarantineCupboardNo = (ITTLabel)AddControl(new Guid("ad3dbea4-f8fb-4555-98d5-73dbc627e4e2"));
            labelMaterialsAdmittedTo = (ITTLabel)AddControl(new Guid("be7837d2-44e8-43af-9554-0c453f2ed482"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("42db6274-23bb-493a-a755-33bd41bc895a"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("9ab6dcc5-7f4c-469a-9816-6587397c4fcd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("224ea39e-3793-4998-9540-1e102fafdf36"));
            MorgueCupboardNo = (ITTTextBox)AddControl(new Guid("61e0b990-ca63-45ef-9c48-110ac2a464d9"));
            MaterialsAdmittedTo = (ITTTextBox)AddControl(new Guid("d8dfe88d-925a-470d-998b-8b7bd06c427f"));
            DeathBodyAdmittedTo = (ITTTextBox)AddControl(new Guid("2c3417e4-634e-47c5-8261-8391e16cd367"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("5fa373f0-a4f6-4460-aedc-eec32924af53"));
            labelMaterialsAdmittedFrom = (ITTLabel)AddControl(new Guid("0fa7a586-0148-44b4-ba54-489a43b2b5b4"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("5700a2f5-cbe8-4e07-9895-1358f668c5ae"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("466aee3e-c73e-496e-8f0a-3638e336a1b4"));
            base.InitializeControls();
        }

        public MorgueDoctorControlForm() : base("MORGUE", "MorgueDoctorControlForm")
        {
        }

        protected MorgueDoctorControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}