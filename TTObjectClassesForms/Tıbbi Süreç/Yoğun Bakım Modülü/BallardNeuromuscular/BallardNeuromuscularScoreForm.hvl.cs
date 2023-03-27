
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
    public partial class BallardNeuromuscularScoreForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.BallardNeuromuscular _BallardNeuromuscular
        {
            get { return (TTObjectClasses.BallardNeuromuscular)_ttObject; }
        }

        protected ITTTextBox TotalScore;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelTotalScore;
        protected ITTLabel labelSquare;
        protected ITTEnumComboBox Square;
        protected ITTLabel labelScarf;
        protected ITTEnumComboBox Scarf;
        protected ITTLabel labelPosture;
        protected ITTEnumComboBox Posture;
        protected ITTLabel labelPopliteal;
        protected ITTEnumComboBox Popliteal;
        protected ITTLabel labelHeel;
        protected ITTEnumComboBox Heel;
        protected ITTLabel labelArm;
        protected ITTEnumComboBox Arm;
        override protected void InitializeControls()
        {
            TotalScore = (ITTTextBox)AddControl(new Guid("50a9dc93-c855-42b3-8f0a-98f16562973d"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("c689a3b1-438a-49da-b2ac-17011f2f9add"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("b28d67ed-a608-472f-88a7-60261b97d131"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("e47b8309-6c53-43d8-b16a-25a09b6a39c0"));
            labelSquare = (ITTLabel)AddControl(new Guid("e7c981f6-0a8b-41ac-96e6-f32ed8bad6da"));
            Square = (ITTEnumComboBox)AddControl(new Guid("8604c50e-b985-4117-bfaa-535ed1b2278a"));
            labelScarf = (ITTLabel)AddControl(new Guid("80e5ec78-bace-4c67-b96c-7f75cd338602"));
            Scarf = (ITTEnumComboBox)AddControl(new Guid("354484f5-ed68-4e5d-b726-e01ea34d8575"));
            labelPosture = (ITTLabel)AddControl(new Guid("6433fa67-2466-4ff8-86da-67efdd2e5b8d"));
            Posture = (ITTEnumComboBox)AddControl(new Guid("b9198727-4983-4019-b7d4-c59ecc89f422"));
            labelPopliteal = (ITTLabel)AddControl(new Guid("ebe9724b-a890-40e3-a448-e80fc535345b"));
            Popliteal = (ITTEnumComboBox)AddControl(new Guid("52a79f32-8077-469e-8a12-8e1a03235f36"));
            labelHeel = (ITTLabel)AddControl(new Guid("ed0340fb-6c22-4923-afce-760713c4e55f"));
            Heel = (ITTEnumComboBox)AddControl(new Guid("76d3e789-42c4-4862-a30c-ab68f5583039"));
            labelArm = (ITTLabel)AddControl(new Guid("da8b61c4-205b-4c19-9a3b-9235e183de7e"));
            Arm = (ITTEnumComboBox)AddControl(new Guid("58c3f5ed-681c-44d0-9b81-0d39b1308939"));
            base.InitializeControls();
        }

        public BallardNeuromuscularScoreForm() : base("BALLARDNEUROMUSCULAR", "BallardNeuromuscularScoreForm")
        {
        }

        protected BallardNeuromuscularScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}