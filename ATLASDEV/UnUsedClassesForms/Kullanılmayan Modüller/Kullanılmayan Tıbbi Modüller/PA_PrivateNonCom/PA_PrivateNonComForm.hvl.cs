
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
    /// Er/Erbaş Kabulü
    /// </summary>
    public partial class PA_PrivateNonComForm : PatientAdmissionForm
    {
    /// <summary>
    /// Er/Erbaş Kabul 
    /// </summary>
        protected TTObjectClasses.PA_PrivateNonCom _PA_PrivateNonCom
        {
            get { return (TTObjectClasses.PA_PrivateNonCom)_ttObject; }
        }

        protected ITTLabel labelFoundation;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelMilitaryNo;
        protected ITTTextBox MilitaryNo;
        protected ITTObjectListBox ForcesCommand;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRank;
        protected ITTLabel labelForcesCommand;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelMilitaryOffice;
        protected ITTDateTimePicker MilitaryAcceptanceTime;
        protected ITTLabel labelEnteranceTime;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox MilitaryOffice;
        override protected void InitializeControls()
        {
            labelFoundation = (ITTLabel)AddControl(new Guid("b3269529-6578-4618-b84a-3fb739cd5f86"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("56fa6c87-f75c-41b2-a784-8975ac637993"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("e021f4bb-3c5b-4492-b524-ca33e7a36e9c"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("c4193757-90d4-4c62-806d-29e2107552bd"));
            labelMilitaryNo = (ITTLabel)AddControl(new Guid("e5ceee79-789b-448f-a50a-8106025023c3"));
            MilitaryNo = (ITTTextBox)AddControl(new Guid("a99c4ffb-4545-4b8e-b7a2-b887eeb84a7f"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("d1ccd66f-cb0a-469d-a7ce-e2784f96c4c1"));
            Rank = (ITTObjectListBox)AddControl(new Guid("a141e007-8378-41cf-9939-bf27dfc2a31c"));
            labelRank = (ITTLabel)AddControl(new Guid("2e938da5-4681-4ce8-88fd-c6de9dbd72d0"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("55925ee7-3aa1-4bb8-ad67-8b12b03b9228"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fc889068-a209-416d-8c6d-062f8fcfd234"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("72ea2504-e8e4-458a-90dd-33131ad2ee51"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("db787d10-d661-4a5b-a672-33bc23bf229c"));
            MilitaryAcceptanceTime = (ITTDateTimePicker)AddControl(new Guid("9632f05a-ea83-48f4-a7f0-59359aac1781"));
            labelEnteranceTime = (ITTLabel)AddControl(new Guid("9fdafadc-fb92-44e0-b083-82076b1db6ad"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("300ccbfd-5df4-4634-b998-9d755d7f051a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c6479193-95f9-4d42-ae77-a9ec5152caf4"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("9c75443c-8536-4228-8930-d599e10ae7ad"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("80e32d2d-390d-4c37-801d-e2c9fee6f26a"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("e7bdfc04-a8f8-40d7-bf55-fffa1a37f0cd"));
            base.InitializeControls();
        }

        public PA_PrivateNonComForm() : base("PA_PRIVATENONCOM", "PA_PrivateNonComForm")
        {
        }

        protected PA_PrivateNonComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}