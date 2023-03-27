
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
    /// Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri
    /// </summary>
    public partial class InfectiousIllnesesInformationCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri 
    /// </summary>
        protected TTObjectClasses.InfectiousIllnesesInformation _InfectiousIllnesesInformation
        {
            get { return (TTObjectClasses.InfectiousIllnesesInformation)_ttObject; }
        }

        protected ITTLabel labelSKRSKoyKodlariPatient;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox SKRSKoyKodlariPatient;
        protected ITTObjectListBox SKRSMahalleKodlariPatient;
        protected ITTLabel labelSKRSILKodlariPatient;
        protected ITTObjectListBox SKRSILKodlariPatient;
        protected ITTLabel labelSKRSIlceKodlariPatient;
        protected ITTObjectListBox SKRSIlceKodlariPatient;
        protected ITTLabel labelDisKapiPatient;
        protected ITTTextBox DisKapiPatient;
        protected ITTTextBox BucakKoduPatient;
        protected ITTTextBox tttextbox2;
        protected ITTLabel labelBucakKoduPatient;
        protected ITTPanel panelIllnessınfo;
        protected ITTLabel labelSKRSVakaTipi;
        protected ITTObjectListBox SKRSVakaTipi;
        protected ITTLabel labelDeathTime;
        protected ITTLabel labelInfectiousIllnesesDiagnosis;
        protected ITTDateTimePicker StartTimeOfInfectious;
        protected ITTObjectListBox InfectiousIllnesesDiagnosis;
        protected ITTLabel labelIllnesesName;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTCheckBox NotAlive;
        protected ITTTextBox Description;
        protected ITTLabel labelStartTimeOfInfectious;
        protected ITTDateTimePicker DeathTime;
        protected ITTLabel labelDescription;
        protected ITTTextBox IllnesesName;
        protected ITTLabel labelCommunicationınfo;
        protected ITTPanel panelPatientInfo;
        protected ITTTextBox Job;
        protected ITTLabel labelFatherName;
        protected ITTEnumComboBox Sex;
        protected ITTTextBox FatherName;
        protected ITTLabel labelSex;
        protected ITTLabel labelJob;
        protected ITTLabel labelBirthDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelPatientInfo;
        protected ITTLabel labelIllness;
        protected ITTGrid BulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSAdresTipiBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSIlBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSIlceBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSBucakKodlariBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSKoyKodlariBulasiciAdresBilgisi;
        protected ITTListBoxColumn SKRSMahalleKodlariBulasiciAdresBilgisi;
        protected ITTTextBoxColumn DisKapi;
        protected ITTTextBoxColumn IcKapi;
        protected ITTTextBoxColumn CSBMKodu;
        protected ITTGrid BulasiciTelefonBilgisi;
        protected ITTListBoxColumn SKRSTelefonTipiBulasiciTelefonBilgisi;
        protected ITTTextBoxColumn Phone;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTMaskedTextBox ttMobilePhone;
        protected ITTMaskedTextBox ttHomePhoneTxt;
        protected ITTLabel BaselabelMobilePhone;
        protected ITTLabel BaselabelHomePhone;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            labelSKRSKoyKodlariPatient = (ITTLabel)AddControl(new Guid("5d340909-b8a3-4285-bd39-60631d16d66b"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("6de0bd15-d730-4d08-b607-f95d4e6f94f6"));
            SKRSKoyKodlariPatient = (ITTObjectListBox)AddControl(new Guid("4b02e901-140b-49fe-9855-22d5e2ed8cc7"));
            SKRSMahalleKodlariPatient = (ITTObjectListBox)AddControl(new Guid("49bcd43b-d731-4f70-a467-bfcab54dc075"));
            labelSKRSILKodlariPatient = (ITTLabel)AddControl(new Guid("bef3bd20-9210-4fb7-b193-c5e0e419608f"));
            SKRSILKodlariPatient = (ITTObjectListBox)AddControl(new Guid("f8572b4f-271a-4739-a4a7-b1e2766aa5f7"));
            labelSKRSIlceKodlariPatient = (ITTLabel)AddControl(new Guid("5002acf8-0c7d-42c3-8773-60b2bce850d1"));
            SKRSIlceKodlariPatient = (ITTObjectListBox)AddControl(new Guid("38d6fedd-2249-492d-9995-c371a61795f7"));
            labelDisKapiPatient = (ITTLabel)AddControl(new Guid("a6701740-abdb-4f3c-b0e1-9ebf54160147"));
            DisKapiPatient = (ITTTextBox)AddControl(new Guid("8f35de68-5167-45ea-a088-46415b7d9fb2"));
            BucakKoduPatient = (ITTTextBox)AddControl(new Guid("ec2e7930-c39f-4dce-af5d-4e02d87bf99a"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("af5e0258-f6c3-46ba-bc41-819aa3c6fcf6"));
            labelBucakKoduPatient = (ITTLabel)AddControl(new Guid("64774a88-557a-4504-9d3d-c7c7ba839fdf"));
            panelIllnessınfo = (ITTPanel)AddControl(new Guid("f6d47046-ebc4-485b-b657-02d2bee0ad50"));
            labelSKRSVakaTipi = (ITTLabel)AddControl(new Guid("d8f01017-ccec-4c40-a702-c6f71c02f058"));
            SKRSVakaTipi = (ITTObjectListBox)AddControl(new Guid("0c75ab06-7ddd-49b3-941b-7cb5d889d317"));
            labelDeathTime = (ITTLabel)AddControl(new Guid("8e4b3b02-510e-46ae-8925-bb1ff04f2bf5"));
            labelInfectiousIllnesesDiagnosis = (ITTLabel)AddControl(new Guid("61de1079-8169-4fd7-9dcb-7c58479e12cb"));
            StartTimeOfInfectious = (ITTDateTimePicker)AddControl(new Guid("6df1e085-ea6e-4238-9e47-48d628f8384a"));
            InfectiousIllnesesDiagnosis = (ITTObjectListBox)AddControl(new Guid("50a517ce-7051-4d86-8917-e73877f2be13"));
            labelIllnesesName = (ITTLabel)AddControl(new Guid("3f3600fd-e7a5-420e-b36c-81fb59abf719"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("03758f95-c8f1-4c23-9be8-ea7a65f51f0a"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a55923e8-c32e-4919-9989-472d00d0c7ca"));
            NotAlive = (ITTCheckBox)AddControl(new Guid("15e73fef-fa6a-44f4-bc28-7498e7a75756"));
            Description = (ITTTextBox)AddControl(new Guid("b5d744ea-ebdb-434f-b746-c60bceea4bba"));
            labelStartTimeOfInfectious = (ITTLabel)AddControl(new Guid("fbf2a425-8fd6-4cc2-b08a-103bc4b025ae"));
            DeathTime = (ITTDateTimePicker)AddControl(new Guid("cdab7984-018c-44a6-b024-1afc42289983"));
            labelDescription = (ITTLabel)AddControl(new Guid("b03630a7-4770-4035-acb0-6ca1c3f04a85"));
            IllnesesName = (ITTTextBox)AddControl(new Guid("054726c8-2b8d-44d6-92ad-a5df7eb43071"));
            labelCommunicationınfo = (ITTLabel)AddControl(new Guid("d39f6646-a9a9-418e-8ca8-6b6d44598f01"));
            panelPatientInfo = (ITTPanel)AddControl(new Guid("240e7f04-77f2-44bd-ab47-4446e19344b1"));
            Job = (ITTTextBox)AddControl(new Guid("02f75547-cc5f-475a-8474-23a1ff629815"));
            labelFatherName = (ITTLabel)AddControl(new Guid("36417222-e63d-4c14-887b-cf2e0f208432"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("dc2b04ec-8611-4515-9e8c-06f5c554a3f5"));
            FatherName = (ITTTextBox)AddControl(new Guid("d2431cbb-6bed-43ac-81dd-980d5ffe2c68"));
            labelSex = (ITTLabel)AddControl(new Guid("ad72a760-752c-487e-a577-0fdd67cfba58"));
            labelJob = (ITTLabel)AddControl(new Guid("9833ea8e-b786-4774-8dc5-404702798e7d"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("dec45a7e-1a53-4582-af89-a02c7b4a4b43"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("556483c1-7236-45fa-beea-1335f2cccdd5"));
            labelPatientInfo = (ITTLabel)AddControl(new Guid("3d883dc4-7be6-40ee-9f9a-d262bf0d3be4"));
            labelIllness = (ITTLabel)AddControl(new Guid("aab5b42f-d13a-4f5e-ae99-dc86ac56fe35"));
            BulasiciAdresBilgisi = (ITTGrid)AddControl(new Guid("32ddf392-afe5-465c-b8d8-8ef37d43404f"));
            SKRSAdresTipiBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("87aafa0a-0570-4319-b419-ccf5e7d9ce39"));
            SKRSIlBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("f3c9aebe-c0dc-4276-8a72-d81761dfa644"));
            SKRSIlceBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("0c958dc7-476f-4b4f-8700-86f0a75d853b"));
            SKRSBucakKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("9ded914c-2f71-43fc-879c-d7ce803161f2"));
            SKRSKoyKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("fb5b00d9-7038-4008-80db-2b6557b03589"));
            SKRSMahalleKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("dd847405-9946-4573-ab59-777724102350"));
            DisKapi = (ITTTextBoxColumn)AddControl(new Guid("7c93f9d1-d1df-40fc-96d2-9b0ae5bedcf3"));
            IcKapi = (ITTTextBoxColumn)AddControl(new Guid("50ed2271-c4c8-40da-ab72-844163e6c0e4"));
            CSBMKodu = (ITTTextBoxColumn)AddControl(new Guid("09818a45-4713-4894-aa19-f155ce6b2250"));
            BulasiciTelefonBilgisi = (ITTGrid)AddControl(new Guid("e44913f7-fb26-4084-9d4b-32052bd0059c"));
            SKRSTelefonTipiBulasiciTelefonBilgisi = (ITTListBoxColumn)AddControl(new Guid("95de7500-da69-4ca0-a385-55261d8bec98"));
            Phone = (ITTTextBoxColumn)AddControl(new Guid("6b69054c-c504-463b-bbef-e3325c4fcf79"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f00f9182-616c-4f10-a1de-3608fc38406e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2d9b826b-c0ad-41dc-bafa-080347eda980"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7793b965-aa72-4c6f-be94-1da088ecac84"));
            ttMobilePhone = (ITTMaskedTextBox)AddControl(new Guid("6aee7672-2f3a-4c2e-9c65-43ccd364e220"));
            ttHomePhoneTxt = (ITTMaskedTextBox)AddControl(new Guid("201a6c35-222d-4eaa-a888-56410195e9f9"));
            BaselabelMobilePhone = (ITTLabel)AddControl(new Guid("3daf51e1-386e-484a-972d-22e38508e123"));
            BaselabelHomePhone = (ITTLabel)AddControl(new Guid("b99a6f3a-0a12-4828-9faa-7e8915818b3b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a9f2d9fe-05d5-4e5b-930d-1023b54acde2"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("fae01144-165c-44b2-802f-db5289fdd5cb"));
            base.InitializeControls();
        }

        public InfectiousIllnesesInformationCancelledForm() : base("INFECTIOUSILLNESESINFORMATION", "InfectiousIllnesesInformationCancelledForm")
        {
        }

        protected InfectiousIllnesesInformationCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}