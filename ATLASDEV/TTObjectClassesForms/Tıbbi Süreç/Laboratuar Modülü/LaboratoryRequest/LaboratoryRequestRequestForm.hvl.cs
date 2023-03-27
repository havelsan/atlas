
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
    /// Laboratuvar İstek Formu
    /// </summary>
    public partial class LaboratoryRequestRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Laboratuvar
    /// </summary>
        protected TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get { return (TTObjectClasses.LaboratoryRequest)_ttObject; }
        }

        protected ITTButton ttBinaryScanInfo;
        protected ITTButton btnCreateTemplate;
        protected ITTButton btnEditTemplate;
        protected ITTButton btnSelectTemplate;
        protected ITTTabControl tabTetkik;
        protected ITTTabControl TabForInformations;
        protected ITTTabPage TabPageGeneralInfo;
        protected ITTLabel ttStringLength;
        protected ITTEnumComboBox PatientGroup;
        protected ITTEnumComboBox PatientSex;
        protected ITTTextBox PatientAge;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox ReasonForAdmisson;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelPreInformation;
        protected ITTCheckBox Urgent;
        protected ITTLabel ttlabel1;
        protected ITTTextBox Note;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabPageAdditionalInfo;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox requestDoctor;
        protected ITTTabPage TabPagePregnancyInfo;
        protected ITTEnumComboBox Gebelik;
        protected ITTDateTimePicker SonAdetTarihi;
        protected ITTLabel labelSonAdetTarihi;
        protected ITTLabel labelGebelik;
        protected ITTTabPage TabPageFutureRequest;
        protected ITTDateTimePicker WorkListDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel3drawgradient;
        protected ITTButton ttTripleTestInfo;
        override protected void InitializeControls()
        {
            ttBinaryScanInfo = (ITTButton)AddControl(new Guid("dd975538-aaad-4189-8f13-8c388ad6c802"));
            btnCreateTemplate = (ITTButton)AddControl(new Guid("186abb25-1907-4d5b-b8ce-66107f2ee5ec"));
            btnEditTemplate = (ITTButton)AddControl(new Guid("2e696782-cdec-43ab-be7c-bfa69ab9966d"));
            btnSelectTemplate = (ITTButton)AddControl(new Guid("48bf3f83-2efc-40a3-af96-eb22d513116a"));
            tabTetkik = (ITTTabControl)AddControl(new Guid("d00aa2e7-71b6-4be5-b7d5-458cb4a1ff47"));
            TabForInformations = (ITTTabControl)AddControl(new Guid("0a4944d6-b3d4-4c13-ae9b-396761231c28"));
            TabPageGeneralInfo = (ITTTabPage)AddControl(new Guid("e9258534-b83b-40e8-a942-45dee950fb9d"));
            ttStringLength = (ITTLabel)AddControl(new Guid("94be1693-701f-43fd-a840-ddfb76ccc594"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("b49eabf2-7dec-4c74-b272-0047eadbb2bb"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("d47a4325-891c-4818-a38b-81631aa3d30e"));
            PatientAge = (ITTTextBox)AddControl(new Guid("943392ab-2921-430a-9cb6-3f57ea415dc6"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("06b51daa-53a6-4595-9a03-47b536f549f0"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4787a61b-5fdd-40de-bbce-9c480af7fc1f"));
            ReasonForAdmisson = (ITTTextBox)AddControl(new Guid("fc646dee-756f-4b3d-8442-c68a312def3a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("580bb19b-02b3-4b0c-88e3-fa987c66e198"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a58e1754-7b5d-46f6-8aa1-36109a2ef7ac"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("6921dbc9-a54c-42b2-a961-9ea46593c1f0"));
            Urgent = (ITTCheckBox)AddControl(new Guid("1caa08a4-5407-41b7-b71e-55359a474d77"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c3bd223b-3c65-4d9b-8c13-1b18d4cc7446"));
            Note = (ITTTextBox)AddControl(new Guid("9fbf02af-47ec-4b6a-8d15-ddd150e0be71"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("a8fdd2b5-020f-4476-b6e3-4fde4ba665b4"));
            TabPageAdditionalInfo = (ITTTabPage)AddControl(new Guid("44629e55-714d-46f2-a2a9-c2b56f148be8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fa053ef6-2def-4675-aa7a-06e4b1639af2"));
            requestDoctor = (ITTObjectListBox)AddControl(new Guid("0ac27d5a-a0d0-490d-982c-f00c660962a4"));
            TabPagePregnancyInfo = (ITTTabPage)AddControl(new Guid("fe350576-964b-4eea-9337-32536172e470"));
            Gebelik = (ITTEnumComboBox)AddControl(new Guid("d195c5f5-289a-4a03-a0b3-2bdd9df89c86"));
            SonAdetTarihi = (ITTDateTimePicker)AddControl(new Guid("4888cca4-24d9-4421-835b-27b13e853fad"));
            labelSonAdetTarihi = (ITTLabel)AddControl(new Guid("de762d7a-a946-4b11-8433-b9e342ea9e3c"));
            labelGebelik = (ITTLabel)AddControl(new Guid("79b29023-32c8-43f5-b57f-5bde481c1770"));
            TabPageFutureRequest = (ITTTabPage)AddControl(new Guid("4d703bc3-f44c-4569-a6cd-db212af5e025"));
            WorkListDate = (ITTDateTimePicker)AddControl(new Guid("66a30253-3e4c-4bb6-8147-d76224cb9081"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("1fccaa53-2bd6-4b46-98d4-5edf8abf5a06"));
            ttlabel3drawgradient = (ITTLabel)AddControl(new Guid("d7460639-dce0-4e77-a000-53d4e4496440"));
            ttTripleTestInfo = (ITTButton)AddControl(new Guid("7ca187b7-6f14-4054-b93f-ddae2b3b1fbd"));
            base.InitializeControls();
        }

        public LaboratoryRequestRequestForm() : base("LABORATORYREQUEST", "LaboratoryRequestRequestForm")
        {
        }

        protected LaboratoryRequestRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}