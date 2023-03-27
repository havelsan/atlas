
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
    public partial class InfectiousIllnesesInformationForm : EpisodeActionForm
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
        protected ITTMaskedTextBox ttmaskedtextbox1;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            labelSKRSKoyKodlariPatient = (ITTLabel)AddControl(new Guid("014b631b-3c55-4bcf-9ace-e0b653884e27"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1432a37a-7ddd-4917-babf-991760f35485"));
            SKRSKoyKodlariPatient = (ITTObjectListBox)AddControl(new Guid("a11a03cb-6340-40f2-88d7-a10c83bcf3c5"));
            SKRSMahalleKodlariPatient = (ITTObjectListBox)AddControl(new Guid("0e57ce08-2941-4ed5-bfed-ab0e75fe1862"));
            labelSKRSILKodlariPatient = (ITTLabel)AddControl(new Guid("56e66b0a-f9a2-4be5-859f-b566205d367b"));
            SKRSILKodlariPatient = (ITTObjectListBox)AddControl(new Guid("daff555b-7f8e-476b-8da1-dd62aceb8252"));
            labelSKRSIlceKodlariPatient = (ITTLabel)AddControl(new Guid("54f65bfe-6f13-4968-99d7-2e7dca7313a4"));
            SKRSIlceKodlariPatient = (ITTObjectListBox)AddControl(new Guid("2f6e1d05-6c57-40eb-96a2-416a8b5802df"));
            labelDisKapiPatient = (ITTLabel)AddControl(new Guid("97cec2ae-2687-4e13-8255-9114e3d52063"));
            DisKapiPatient = (ITTTextBox)AddControl(new Guid("b6613cbe-fcc7-48d8-819f-7018440fc7a9"));
            BucakKoduPatient = (ITTTextBox)AddControl(new Guid("ad4934b4-d65a-4319-8fed-daa1eec6c54d"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7d1d0736-d370-4c55-80f3-00dae0eb7687"));
            labelBucakKoduPatient = (ITTLabel)AddControl(new Guid("90633b1a-b5be-4dc9-8ad6-2889dfda56f2"));
            panelIllnessınfo = (ITTPanel)AddControl(new Guid("73d7a10b-0cca-40c3-a2f6-145a58ca8456"));
            labelSKRSVakaTipi = (ITTLabel)AddControl(new Guid("4eacfe47-a009-4d46-9304-96c64cc6ef9f"));
            SKRSVakaTipi = (ITTObjectListBox)AddControl(new Guid("98d6299b-aa18-4cdb-a0d2-796ff103be7b"));
            labelDeathTime = (ITTLabel)AddControl(new Guid("8593712e-642a-4a2d-bad7-3afa95d9f49b"));
            labelInfectiousIllnesesDiagnosis = (ITTLabel)AddControl(new Guid("886d2d70-0019-4114-8ff4-3faaeaab9a13"));
            StartTimeOfInfectious = (ITTDateTimePicker)AddControl(new Guid("48aa341b-ae51-418e-8b93-5a19b10f6599"));
            InfectiousIllnesesDiagnosis = (ITTObjectListBox)AddControl(new Guid("2bf68bee-813c-4d72-9ab9-6d679a033783"));
            labelIllnesesName = (ITTLabel)AddControl(new Guid("b8a0e3c7-e941-4913-b0ba-6ff2c9a44a34"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("b9933199-0eb3-48a6-98bb-013b847e4b09"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e85ada67-cf44-44ee-aefa-89d4b49fec72"));
            NotAlive = (ITTCheckBox)AddControl(new Guid("58be36c4-b584-4d35-b92f-97e7dc64a94a"));
            Description = (ITTTextBox)AddControl(new Guid("083f0ad6-3c33-4683-bede-d42e4b2b2413"));
            labelStartTimeOfInfectious = (ITTLabel)AddControl(new Guid("1b532fb6-a8da-4e59-bd41-e89400edcb73"));
            DeathTime = (ITTDateTimePicker)AddControl(new Guid("004361a8-dcb3-43c0-8a8b-ef7c17a292d7"));
            labelDescription = (ITTLabel)AddControl(new Guid("fac35e24-95f9-4608-8269-f6e916249b8a"));
            IllnesesName = (ITTTextBox)AddControl(new Guid("aa2e3575-7bdf-4d1d-913c-127b42ee1ea1"));
            labelCommunicationınfo = (ITTLabel)AddControl(new Guid("fe499844-d495-4a26-9586-4e29d1becaea"));
            panelPatientInfo = (ITTPanel)AddControl(new Guid("4ccf5b44-ce43-4482-8fbf-51e7d1a021b5"));
            Job = (ITTTextBox)AddControl(new Guid("eee7db63-2613-45ed-9a97-913e1128d4ac"));
            labelFatherName = (ITTLabel)AddControl(new Guid("ef88d97f-aa4e-437e-a137-9258f48a9e4e"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("92d127ed-3aec-4f3b-837d-aa2ce1eff7ef"));
            FatherName = (ITTTextBox)AddControl(new Guid("bf8fca67-b9e6-42a2-b7b2-ffdde721e69e"));
            labelSex = (ITTLabel)AddControl(new Guid("5f74915b-910a-4c79-979e-03f6b3c9a8af"));
            labelJob = (ITTLabel)AddControl(new Guid("8a894331-54d7-4203-b60b-04ba324f18d3"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("8288b132-9015-4a08-9413-43aa1d12a469"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("ec181036-ff98-4bb9-8e1a-4bbf810d2a1f"));
            labelPatientInfo = (ITTLabel)AddControl(new Guid("c4368c88-e483-427d-b511-82a03c9d3eec"));
            labelIllness = (ITTLabel)AddControl(new Guid("0b97eab7-e0af-4b75-85a0-f995ba9a5622"));
            BulasiciAdresBilgisi = (ITTGrid)AddControl(new Guid("0dfcbe34-c1c7-496d-8ce0-e3445238ee8e"));
            SKRSAdresTipiBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("f184089f-cf4e-4c3d-b58a-d2cd9ed87b89"));
            SKRSIlBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("ff171ea5-939e-4ea8-86bd-9acb1017f908"));
            SKRSIlceBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("5c5c8970-ad8d-42bc-998e-cb3806554f13"));
            SKRSBucakKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("126e3f15-c381-481c-9167-36b303c5cb62"));
            SKRSKoyKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("6a6f58f6-111b-4b81-85e8-246c61e770fe"));
            SKRSMahalleKodlariBulasiciAdresBilgisi = (ITTListBoxColumn)AddControl(new Guid("3c01438e-710a-43f3-bad4-bd79bbc3df86"));
            DisKapi = (ITTTextBoxColumn)AddControl(new Guid("be0fe370-6bb7-40d2-90c9-f8544cc03c50"));
            IcKapi = (ITTTextBoxColumn)AddControl(new Guid("2c99d71c-f889-4bb0-897c-3c7626abdb37"));
            CSBMKodu = (ITTTextBoxColumn)AddControl(new Guid("a532461e-a831-4d31-8855-24949e23318a"));
            BulasiciTelefonBilgisi = (ITTGrid)AddControl(new Guid("e5b9355d-1317-46de-a28c-adf40f550d96"));
            SKRSTelefonTipiBulasiciTelefonBilgisi = (ITTListBoxColumn)AddControl(new Guid("6e7720d8-4a99-4ec9-b9fc-b124a904045f"));
            Phone = (ITTTextBoxColumn)AddControl(new Guid("ccbc80dc-90e4-4aae-938b-db336b819fd8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("647cdf18-2449-4492-add2-c8126f2ad201"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("83010a91-4112-4fd8-9189-d46e32bd5748"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("e23f428b-45db-49ff-b313-95ab33f51c5a"));
            ttMobilePhone = (ITTMaskedTextBox)AddControl(new Guid("2a351f20-d329-41fb-8def-e9a13c064b7b"));
            ttHomePhoneTxt = (ITTMaskedTextBox)AddControl(new Guid("30771ee9-49cf-4338-b8b0-64425bb02b73"));
            BaselabelMobilePhone = (ITTLabel)AddControl(new Guid("dbb7c939-1511-41fb-b5f2-8ce3c7f63ff9"));
            BaselabelHomePhone = (ITTLabel)AddControl(new Guid("7c606e51-34ee-4294-8999-11454080c330"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bf55f835-1230-41c0-9750-5f7b2f784c56"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("39e3b51a-5c49-4175-a75b-b62a56fb3fd4"));
            ttmaskedtextbox1 = (ITTMaskedTextBox)AddControl(new Guid("9708243d-bc75-4f68-8dac-40785b0af857"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d05bf1dd-0107-4bbf-a919-f0dd885e425e"));
            base.InitializeControls();
        }

        public InfectiousIllnesesInformationForm() : base("INFECTIOUSILLNESESINFORMATION", "InfectiousIllnesesInformationForm")
        {
        }

        protected InfectiousIllnesesInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}