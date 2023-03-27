
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
    /// Giriş-Çıkış Yapan Firma Personeli
    /// </summary>
    public partial class NewFirmPersonnelAtCampus : TTForm
    {
        protected TTObjectClasses.MNZFirmPersonnelAtCampus _MNZFirmPersonnelAtCampus
        {
            get { return (TTObjectClasses.MNZFirmPersonnelAtCampus)_ttObject; }
        }

        protected ITTLabel surnameLabel;
        protected ITTTextBox workingUnitTextBox;
        protected ITTLabel labelExitTime;
        protected ITTDateTimePicker EntranceTimeDatePicker;
        protected ITTLabel firmPersonnelLabel;
        protected ITTTextBox nationalIdentityTextBox;
        protected ITTLabel labelLisencePlate;
        protected ITTTextBox nameTextBox;
        protected ITTLabel labelVisitDate;
        protected ITTGroupBox visitHistoryGroupBox;
        protected ITTGroupBox AllowedVisitTimeGroupBox;
        protected ITTObjectListBox firmPersonnelListBox;
        protected ITTLabel nationalIdentityLabel;
        protected ITTLabel nameLabel;
        protected ITTLabel firmNameLabel;
        protected ITTLabel labelEntranceTime;
        protected ITTTextBox firmNameTextBox;
        protected ITTGrid AllowedVisitTimeGrid;
        protected ITTDateTimePicker ExitTimeDatePicker;
        protected ITTDateTimePicker VisitDateDatePicker;
        protected ITTLabel workingUnitLabel;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox textBoxLisencePlate;
        protected ITTTextBox surnameTextBox;
        override protected void InitializeControls()
        {
            surnameLabel = (ITTLabel)AddControl(new Guid("fa8a7ff0-5fe5-4e16-ad00-184bd49e7984"));
            workingUnitTextBox = (ITTTextBox)AddControl(new Guid("5bd685b0-5ad7-4fef-a259-f4b199e9c442"));
            labelExitTime = (ITTLabel)AddControl(new Guid("cc7a1286-8598-4503-9458-f994c05667d2"));
            EntranceTimeDatePicker = (ITTDateTimePicker)AddControl(new Guid("2aac5cf4-c797-4ea5-a5e9-aadb4c7a4e1e"));
            firmPersonnelLabel = (ITTLabel)AddControl(new Guid("0e135913-8ca6-4dc8-a381-c12062db842b"));
            nationalIdentityTextBox = (ITTTextBox)AddControl(new Guid("6981178b-d493-4edf-8b39-cc6da815b9f3"));
            labelLisencePlate = (ITTLabel)AddControl(new Guid("46baf532-12a4-4816-8356-7695841dc3cd"));
            nameTextBox = (ITTTextBox)AddControl(new Guid("69672d21-d9b2-4a7a-b275-7b101e1c2a03"));
            labelVisitDate = (ITTLabel)AddControl(new Guid("891f176e-578f-4a2c-b17b-6a70d1a3dca3"));
            visitHistoryGroupBox = (ITTGroupBox)AddControl(new Guid("8a0d4e34-0f6b-41ce-ba61-713721626fb7"));
            AllowedVisitTimeGroupBox = (ITTGroupBox)AddControl(new Guid("c2175ec6-58b2-4880-a791-4362a75269fd"));
            firmPersonnelListBox = (ITTObjectListBox)AddControl(new Guid("59865073-0b6d-4ead-bcb4-43921f604560"));
            nationalIdentityLabel = (ITTLabel)AddControl(new Guid("7eb3a009-0a6c-4f02-99be-2ca244989263"));
            nameLabel = (ITTLabel)AddControl(new Guid("e54cf47d-65ea-4d5b-a79a-105dddc4b762"));
            firmNameLabel = (ITTLabel)AddControl(new Guid("d63aee86-70c3-43d7-800f-21638d715d48"));
            labelEntranceTime = (ITTLabel)AddControl(new Guid("14a032e9-abe4-4087-80f4-1791539c06fb"));
            firmNameTextBox = (ITTTextBox)AddControl(new Guid("9c5dcc3d-fb29-41b0-ac2a-1278d947a3b9"));
            AllowedVisitTimeGrid = (ITTGrid)AddControl(new Guid("7ed4e00d-0c32-4728-be5c-09ecdcbd062c"));
            ExitTimeDatePicker = (ITTDateTimePicker)AddControl(new Guid("a3fe7f8a-cfe4-43eb-a91a-2463dc70b570"));
            VisitDateDatePicker = (ITTDateTimePicker)AddControl(new Guid("0723183d-3d49-4d3b-86a1-08eab75854a9"));
            workingUnitLabel = (ITTLabel)AddControl(new Guid("43b388b9-3c3b-478b-9791-15ed05985799"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("fc6d3015-dfa9-4cb5-93fb-2ffc93da65c6"));
            textBoxLisencePlate = (ITTTextBox)AddControl(new Guid("bb43d6f4-a77b-48d6-ac16-e1121f9e3e84"));
            surnameTextBox = (ITTTextBox)AddControl(new Guid("a79c2b98-3b45-474f-a66f-eff2ee1ce24a"));
            base.InitializeControls();
        }

        public NewFirmPersonnelAtCampus() : base("MNZFIRMPERSONNELATCAMPUS", "NewFirmPersonnelAtCampus")
        {
        }

        protected NewFirmPersonnelAtCampus(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}