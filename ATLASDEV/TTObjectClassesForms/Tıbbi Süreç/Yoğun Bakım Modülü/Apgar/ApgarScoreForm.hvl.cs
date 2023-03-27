
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
    public partial class ApgarScoreForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.Apgar _Apgar
        {
            get { return (TTObjectClasses.Apgar)_ttObject; }
        }

        protected ITTTextBox TotalScore;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelTotalScore;
        protected ITTLabel labelStimulusResponse;
        protected ITTEnumComboBox StimulusResponse;
        protected ITTLabel labelSkinColor;
        protected ITTEnumComboBox SkinColor;
        protected ITTLabel labelRespiration;
        protected ITTEnumComboBox Respiration;
        protected ITTLabel labelMuscularTonus;
        protected ITTEnumComboBox MuscularTonus;
        protected ITTLabel labelHeartRate;
        protected ITTEnumComboBox HeartRate;
        override protected void InitializeControls()
        {
            TotalScore = (ITTTextBox)AddControl(new Guid("e447c316-336c-4e88-8d5d-76fa0b09fa08"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("c3a53721-ff48-4818-9f92-605461802546"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("b08be13c-e421-4c28-a782-ef01f143a32c"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("82de04c4-d337-4533-8853-7b802d96a522"));
            labelStimulusResponse = (ITTLabel)AddControl(new Guid("b95cb9ab-3e4a-4975-8ceb-bd1aba119946"));
            StimulusResponse = (ITTEnumComboBox)AddControl(new Guid("480eaaa4-facc-4c36-aca5-f56435f9edcf"));
            labelSkinColor = (ITTLabel)AddControl(new Guid("4fe7db5f-4e80-40b0-bcb0-f45219523225"));
            SkinColor = (ITTEnumComboBox)AddControl(new Guid("9a9ecc4e-2ded-410e-a9f0-544eaf3fa150"));
            labelRespiration = (ITTLabel)AddControl(new Guid("02629812-334d-42fe-b6db-4281f31d07f2"));
            Respiration = (ITTEnumComboBox)AddControl(new Guid("15b88506-8dfb-4cfa-8681-5a10e28bae6f"));
            labelMuscularTonus = (ITTLabel)AddControl(new Guid("14cf0a04-5ad1-4076-a120-ab1124aa48d8"));
            MuscularTonus = (ITTEnumComboBox)AddControl(new Guid("a8293f21-75df-458d-bdaa-cca056fae692"));
            labelHeartRate = (ITTLabel)AddControl(new Guid("3e19d52b-6391-475a-bec3-c4a3c6912854"));
            HeartRate = (ITTEnumComboBox)AddControl(new Guid("c8c1ed61-f50c-4cde-b6ee-f81125562928"));
            base.InitializeControls();
        }

        public ApgarScoreForm() : base("APGAR", "ApgarScoreForm")
        {
        }

        protected ApgarScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}