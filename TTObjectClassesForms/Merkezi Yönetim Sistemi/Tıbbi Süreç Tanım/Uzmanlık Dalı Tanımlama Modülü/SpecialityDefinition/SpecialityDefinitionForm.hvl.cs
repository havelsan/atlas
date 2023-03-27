
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
    /// Uzmanlık Dalı Tanımlama
    /// </summary>
    public partial class SpecialityDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Uzmanlık Dalı
    /// </summary>
        protected TTObjectClasses.SpecialityDefinition _SpecialityDefinition
        {
            get { return (TTObjectClasses.SpecialityDefinition)_ttObject; }
        }

        protected ITTLabel labelSpecialityResponsibleUser;
        protected ITTObjectListBox SpecialityResponsibleUser;
        protected ITTLabel labelSpecialityBasedObjectType;
        protected ITTEnumComboBox SpecialityBasedObjectType;
        protected ITTCheckBox IsMHRSClinic;
        protected ITTLabel labelMHRSClinicCode;
        protected ITTTextBox MHRSClinicCode;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox EpisodeClosingDayLimit;
        protected ITTCheckBox IsMinorSpeciality;
        protected ITTCheckBox chkIsPrivate;
        protected ITTCheckBox EHU;
        protected ITTCheckBox IsToBeConsultation;
        protected ITTLabel labelName;
        protected ITTLabel labelCode;
        protected ITTLabel labelEpisodeClosingDayLimit;
        protected ITTCheckBox IsSpecialistRequired;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox SKRSKlinik;
        protected ITTObjectListBox TakipTipi;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox IsBulletin;
        protected ITTCheckBox ttcheckbox1;
        override protected void InitializeControls()
        {
            labelSpecialityResponsibleUser = (ITTLabel)AddControl(new Guid("855b87a4-2c0e-4fc9-86f3-fd7b0a5a4917"));
            SpecialityResponsibleUser = (ITTObjectListBox)AddControl(new Guid("1ae39004-ef09-459a-bea7-b5408abd2213"));
            labelSpecialityBasedObjectType = (ITTLabel)AddControl(new Guid("ec31d893-5332-4d8d-a36c-64b657709be2"));
            SpecialityBasedObjectType = (ITTEnumComboBox)AddControl(new Guid("4c85dc93-08ac-484d-b1b6-9365f967ab49"));
            IsMHRSClinic = (ITTCheckBox)AddControl(new Guid("2d902eb2-7b3c-4a42-9564-6d9b370d23ce"));
            labelMHRSClinicCode = (ITTLabel)AddControl(new Guid("715a3811-7df5-41a8-9535-d3b07d472309"));
            MHRSClinicCode = (ITTTextBox)AddControl(new Guid("30d0d2a6-76cc-4c8e-99a7-efd2da9fbacd"));
            Name = (ITTTextBox)AddControl(new Guid("3f4c0c0c-1153-4337-b3ab-204255725836"));
            Code = (ITTTextBox)AddControl(new Guid("d5414538-b5cb-4ebf-a560-183452dc5083"));
            EpisodeClosingDayLimit = (ITTTextBox)AddControl(new Guid("9767ecde-33b0-4ffa-8039-4239a7e04dbe"));
            IsMinorSpeciality = (ITTCheckBox)AddControl(new Guid("3ba6d18e-1c61-4386-9f95-f85727f3ea86"));
            chkIsPrivate = (ITTCheckBox)AddControl(new Guid("2ce93b67-4f28-4f7b-b131-aebdf3417ac4"));
            EHU = (ITTCheckBox)AddControl(new Guid("9cefe939-f414-46bf-a55d-13e851b2846c"));
            IsToBeConsultation = (ITTCheckBox)AddControl(new Guid("9e37eb7c-5215-4fd2-8cd7-4e0833606598"));
            labelName = (ITTLabel)AddControl(new Guid("b9eb78bf-0640-4d34-b83c-25705e5fc0de"));
            labelCode = (ITTLabel)AddControl(new Guid("32b0107c-6938-461b-bb62-39e6abcd4712"));
            labelEpisodeClosingDayLimit = (ITTLabel)AddControl(new Guid("41d53889-c304-4dbb-829f-c581afac1665"));
            IsSpecialistRequired = (ITTCheckBox)AddControl(new Guid("b97c27f9-eb85-41a1-9491-d3ccbc6529c7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("acfb77db-fce4-44bc-a360-4f31c3e24623"));
            SKRSKlinik = (ITTObjectListBox)AddControl(new Guid("030b0af7-0593-4afd-97f0-29a5fe719d47"));
            TakipTipi = (ITTObjectListBox)AddControl(new Guid("08bf1819-4fbb-4b1b-b053-492dbfed9816"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8a97a988-9368-415c-a065-7e58eae5c803"));
            IsBulletin = (ITTCheckBox)AddControl(new Guid("710ae929-6582-4354-85d2-8a2f507a13bf"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("c6ec5f68-5c86-402b-a8e4-cc8f0856d9c9"));
            base.InitializeControls();
        }

        public SpecialityDefinitionForm() : base("SPECIALITYDEFINITION", "SpecialityDefinitionForm")
        {
        }

        protected SpecialityDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}