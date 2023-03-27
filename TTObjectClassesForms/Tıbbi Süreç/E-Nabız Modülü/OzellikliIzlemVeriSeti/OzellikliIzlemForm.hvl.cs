
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
    public partial class OzellikliIzlemForm : TTForm
    {
        protected TTObjectClasses.OzellikliIzlemVeriSeti _OzellikliIzlemVeriSeti
        {
            get { return (TTObjectClasses.OzellikliIzlemVeriSeti)_ttObject; }
        }

        protected ITTLabel labelGeneralStatus;
        protected ITTObjectListBox GeneralStatus;
        protected ITTLabel labelCTResult;
        protected ITTObjectListBox CTResult;
        protected ITTLabel labelFavipavirAvigan;
        protected ITTObjectListBox FavipavirAvigan;
        protected ITTLabel labelAzitromisin;
        protected ITTObjectListBox Azitromisin;
        protected ITTLabel labelOseltamivir;
        protected ITTObjectListBox Oseltamivir;
        protected ITTLabel labelKaletra;
        protected ITTObjectListBox Kaletra;
        protected ITTLabel labelHydroxychloroquine;
        protected ITTObjectListBox Hydroxychloroquine;
        protected ITTLabel labelHighDoseCvitamin;
        protected ITTObjectListBox HighDoseCvitamin;
        protected ITTLabel labelHasIntubation;
        protected ITTObjectListBox HasIntubation;
        protected ITTLabel labelHasPneumonia;
        protected ITTObjectListBox HasPneumonia;
        protected ITTLabel labelHasCT;
        protected ITTObjectListBox HasCT;
        protected ITTLabel labelHasClinicalFinding;
        protected ITTObjectListBox HasClinicalFinding;
        protected ITTLabel labelNonCovidInpatient;
        protected ITTObjectListBox NonCovidInpatient;
        protected ITTLabel labelIsIsolatedInpatient;
        protected ITTObjectListBox IsIsolatedInpatient;
        protected ITTLabel labelIsIntensiveCare;
        protected ITTObjectListBox IsIntensiveCare;
        protected ITTLabel labelProgressDate;
        protected ITTDateTimePicker ProgressDate;
        protected ITTLabel labelPaoFioRatio;
        protected ITTTextBox PaoFioRatio;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl Description;
        override protected void InitializeControls()
        {
            labelGeneralStatus = (ITTLabel)AddControl(new Guid("350212cb-430d-4c21-bc42-dd0d0b1dfedc"));
            GeneralStatus = (ITTObjectListBox)AddControl(new Guid("dc3b8efc-797c-4f02-882b-2e1596e59932"));
            labelCTResult = (ITTLabel)AddControl(new Guid("de27459d-6669-4df7-b755-262844dc80e7"));
            CTResult = (ITTObjectListBox)AddControl(new Guid("64ff2814-2d35-4860-a693-50c4846a3858"));
            labelFavipavirAvigan = (ITTLabel)AddControl(new Guid("39b4e40e-1de8-436e-a13e-ade2a0ece53c"));
            FavipavirAvigan = (ITTObjectListBox)AddControl(new Guid("7a75e6b9-b902-434a-a6b9-15b032017916"));
            labelAzitromisin = (ITTLabel)AddControl(new Guid("d6386a7b-f79f-471f-a395-bc2ddfe2b246"));
            Azitromisin = (ITTObjectListBox)AddControl(new Guid("df9aff3a-0b4f-4c50-98d7-01ca0f8d61aa"));
            labelOseltamivir = (ITTLabel)AddControl(new Guid("d6c48761-5e9d-437a-8630-08891dbc974f"));
            Oseltamivir = (ITTObjectListBox)AddControl(new Guid("8f2aafd4-98fe-4e8d-bef1-82450d3ad652"));
            labelKaletra = (ITTLabel)AddControl(new Guid("bd2602a8-7f73-4c1e-8af0-9c042ee1fc8d"));
            Kaletra = (ITTObjectListBox)AddControl(new Guid("71664a37-c446-4b8d-ab03-07acd88aefc8"));
            labelHydroxychloroquine = (ITTLabel)AddControl(new Guid("614f696d-0a39-4efc-ba20-2a6a5a73e63a"));
            Hydroxychloroquine = (ITTObjectListBox)AddControl(new Guid("8fd3b1f1-8be6-4972-8667-34966c8631d2"));
            labelHighDoseCvitamin = (ITTLabel)AddControl(new Guid("8a482ab5-165e-49dc-b0d8-12d37091a92c"));
            HighDoseCvitamin = (ITTObjectListBox)AddControl(new Guid("76993c0c-bc26-4e96-81c4-7dc06721f9b6"));
            labelHasIntubation = (ITTLabel)AddControl(new Guid("c18a9565-6d4c-4f64-87ce-bf475a3bb2b7"));
            HasIntubation = (ITTObjectListBox)AddControl(new Guid("1a7eb6e5-6e57-49f1-8b55-84e05c8b0d76"));
            labelHasPneumonia = (ITTLabel)AddControl(new Guid("3612675b-2a8b-4378-9030-690366a21a34"));
            HasPneumonia = (ITTObjectListBox)AddControl(new Guid("bf81df52-795d-404d-a96e-e878f11fc77a"));
            labelHasCT = (ITTLabel)AddControl(new Guid("b46bd463-7203-4e24-bf3b-ab021bb062e9"));
            HasCT = (ITTObjectListBox)AddControl(new Guid("c5ce924c-61f8-46c5-900d-253e1561f328"));
            labelHasClinicalFinding = (ITTLabel)AddControl(new Guid("92af10be-b24a-4cac-a501-f808f371be83"));
            HasClinicalFinding = (ITTObjectListBox)AddControl(new Guid("bd278bae-dbfc-4ab9-aa87-be6bafa7af38"));
            labelNonCovidInpatient = (ITTLabel)AddControl(new Guid("45fa4ab4-f1fd-4df2-84a6-f106595756ff"));
            NonCovidInpatient = (ITTObjectListBox)AddControl(new Guid("601bbd8d-8575-4df2-b054-78751b5f1a1e"));
            labelIsIsolatedInpatient = (ITTLabel)AddControl(new Guid("ff043962-a5d8-4b97-8b2b-f3a22d990194"));
            IsIsolatedInpatient = (ITTObjectListBox)AddControl(new Guid("ce2235a4-34b6-4dae-a3e0-7b0f14f77837"));
            labelIsIntensiveCare = (ITTLabel)AddControl(new Guid("9fceb7e1-0447-4eb8-9038-62c31a5cce50"));
            IsIntensiveCare = (ITTObjectListBox)AddControl(new Guid("691cde31-a06c-4c10-8631-0fdf65d5f3d3"));
            labelProgressDate = (ITTLabel)AddControl(new Guid("ded0d6d4-5e02-4efc-8129-f77dfa43fb9c"));
            ProgressDate = (ITTDateTimePicker)AddControl(new Guid("4916d441-6c42-4019-93a6-3d6e1bb06789"));
            labelPaoFioRatio = (ITTLabel)AddControl(new Guid("57e66bdd-8e47-42c7-a220-58a7a321d1f2"));
            PaoFioRatio = (ITTTextBox)AddControl(new Guid("b23af79e-7506-415f-9562-539a6feac029"));
            labelDescription = (ITTLabel)AddControl(new Guid("4cf3648b-f756-4947-a752-667862ef3b47"));
            Description = (ITTRichTextBoxControl)AddControl(new Guid("8a0b2dac-c142-4794-98dd-10abd79c4350"));
            base.InitializeControls();
        }

        public OzellikliIzlemForm() : base("OZELLIKLIIZLEMVERISETI", "OzellikliIzlemForm")
        {
        }

        protected OzellikliIzlemForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}