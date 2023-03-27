
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
    public partial class InfertilityForm : TTForm
    {
        protected TTObjectClasses.Infertility _Infertility
        {
            get { return (TTObjectClasses.Infertility)_ttObject; }
        }

        protected ITTLabel labelSecondarySexCharacter;
        protected ITTTextBox SecondarySexCharacter;
        protected ITTTextBox WeightPatient;
        protected ITTTextBox Vulva;
        protected ITTTextBox Vagina;
        protected ITTTextBox Uterus;
        protected ITTTextBox Thyroid;
        protected ITTTextBox RightOvaryVolume;
        protected ITTTextBox LeftOvaryVolume;
        protected ITTTextBox Hirsutism;
        protected ITTTextBox Endometrium;
        protected ITTTextBox Decision;
        protected ITTTextBox Chlamdydia;
        protected ITTTextBox Cervix;
        protected ITTTextBox Candida;
        protected ITTLabel labelWeightPatient;
        protected ITTLabel labelVulva;
        protected ITTLabel labelVagina;
        protected ITTLabel labelUterus;
        protected ITTLabel labelThyroid;
        protected ITTLabel labelRightOvaryVolume;
        protected ITTLabel labelLeftOvaryVolume;
        protected ITTLabel labelHirsutism;
        protected ITTLabel labelEndometrium;
        protected ITTLabel labelDecision;
        protected ITTLabel labelChlamdydia;
        protected ITTLabel labelCervix;
        protected ITTLabel labelCandida;
        protected ITTLabel labelBasalUltrasoundDate;
        protected ITTDateTimePicker BasalUltrasoundDate;
        override protected void InitializeControls()
        {
            labelSecondarySexCharacter = (ITTLabel)AddControl(new Guid("a82d9abe-8f15-4b91-a2ee-4cec09620ca2"));
            SecondarySexCharacter = (ITTTextBox)AddControl(new Guid("0a22a32c-8727-4d71-ba74-6f5b40e305da"));
            WeightPatient = (ITTTextBox)AddControl(new Guid("f835a75d-72d7-4763-b71a-0de204df2e07"));
            Vulva = (ITTTextBox)AddControl(new Guid("f87941c6-820a-4ab2-a2a8-70ee20ea5492"));
            Vagina = (ITTTextBox)AddControl(new Guid("d49406cb-418f-4c72-8392-d81a443659ce"));
            Uterus = (ITTTextBox)AddControl(new Guid("416bc663-19a3-4649-9bae-9aa2405dd96d"));
            Thyroid = (ITTTextBox)AddControl(new Guid("13203f9e-4c08-4786-a758-352fb4b0b89c"));
            RightOvaryVolume = (ITTTextBox)AddControl(new Guid("3e98e884-1ba1-432b-b971-3a6dab73af3c"));
            LeftOvaryVolume = (ITTTextBox)AddControl(new Guid("2c68356c-960f-4200-b074-bb35894ce277"));
            Hirsutism = (ITTTextBox)AddControl(new Guid("77856434-1bde-402b-97a8-f75b6d8b785f"));
            Endometrium = (ITTTextBox)AddControl(new Guid("78863887-c409-4ce4-a654-1518a34ab2af"));
            Decision = (ITTTextBox)AddControl(new Guid("21b7e1bb-e9f0-4cf3-9c21-0c9e123f4ce9"));
            Chlamdydia = (ITTTextBox)AddControl(new Guid("6d92bd34-cb26-456e-8d7b-f30e537155a5"));
            Cervix = (ITTTextBox)AddControl(new Guid("01cbff8e-f898-476c-b2b6-75a918160065"));
            Candida = (ITTTextBox)AddControl(new Guid("1e0e9069-6ad2-4585-a672-7c7528b1a55b"));
            labelWeightPatient = (ITTLabel)AddControl(new Guid("6227d3f4-e45d-4243-b45e-0eef21eb95e1"));
            labelVulva = (ITTLabel)AddControl(new Guid("49402315-180c-4231-8072-75c49a910075"));
            labelVagina = (ITTLabel)AddControl(new Guid("5e2491d3-2fcb-4a0b-bc20-dbea83eef8b9"));
            labelUterus = (ITTLabel)AddControl(new Guid("eeae4b49-b73a-48b0-89f9-0dca296e8cab"));
            labelThyroid = (ITTLabel)AddControl(new Guid("39212c7e-846e-4970-8a2b-fbe42df0dc85"));
            labelRightOvaryVolume = (ITTLabel)AddControl(new Guid("92237a08-33fc-4380-805b-cc8aa916b315"));
            labelLeftOvaryVolume = (ITTLabel)AddControl(new Guid("cda41e5f-4e06-4b57-ada6-09e81cbd98d3"));
            labelHirsutism = (ITTLabel)AddControl(new Guid("cfa33ff7-f001-4a72-9f0a-f3941e71ba63"));
            labelEndometrium = (ITTLabel)AddControl(new Guid("f4af7a43-1fb3-4069-8ba7-7a7ce5a269a3"));
            labelDecision = (ITTLabel)AddControl(new Guid("109596aa-0680-4716-974b-d7410af513ba"));
            labelChlamdydia = (ITTLabel)AddControl(new Guid("319eaade-4e03-47b4-a520-e2b5f6880af0"));
            labelCervix = (ITTLabel)AddControl(new Guid("9e1b12b2-7bc6-4073-95db-a8bb2abcbf81"));
            labelCandida = (ITTLabel)AddControl(new Guid("67457111-e104-44bc-8ade-6a03f1c35623"));
            labelBasalUltrasoundDate = (ITTLabel)AddControl(new Guid("0cd3b29f-0869-4eb9-bf88-3a2709cc5533"));
            BasalUltrasoundDate = (ITTDateTimePicker)AddControl(new Guid("be8c1a24-a7e5-4b30-97f3-32731e44992b"));
            base.InitializeControls();
        }

        public InfertilityForm() : base("INFERTILITY", "InfertilityForm")
        {
        }

        protected InfertilityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}