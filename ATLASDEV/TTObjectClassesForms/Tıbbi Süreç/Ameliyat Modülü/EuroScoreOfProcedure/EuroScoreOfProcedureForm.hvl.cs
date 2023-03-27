
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
    public partial class EuroScoreOfProcedureForm : TTForm
    {
        protected TTObjectClasses.EuroScoreOfProcedure _EuroScoreOfProcedure
        {
            get { return (TTObjectClasses.EuroScoreOfProcedure)_ttObject; }
        }

        protected ITTPanel panelPatientFactor;
        protected ITTLabel lablePatientFactor;
        protected ITTEnumComboBox EuroScoreAge;
        protected ITTLabel labelEuroScoreAge;
        protected ITTEnumComboBox Sex;
        protected ITTLabel labelSex;
        protected ITTCheckBox ChronicPulmonaryDisease;
        protected ITTCheckBox ExtracardiacArteriopathy;
        protected ITTCheckBox DiabetesMellitus;
        protected ITTCheckBox PreviousCardiacSurgery;
        protected ITTCheckBox CriticalPreoperativeState;
        protected ITTCheckBox NeurologicalDysfunction;
        protected ITTCheckBox ActiveEndokardit;
        protected ITTCheckBox HemodiyalizPatient;
        protected ITTPanel panellCardiacFactor;
        protected ITTLabel labelCardiacFactor;
        protected ITTLabel labelLvDysfunction;
        protected ITTCheckBox PulmonerHipertansiyon;
        protected ITTEnumComboBox LvDysfunction;
        protected ITTPanel panelOperationFactor;
        protected ITTLabel abelOperationFactor;
        protected ITTCheckBox TorasikAortaSurgery;
        protected ITTCheckBox PostMI_VSD;
        override protected void InitializeControls()
        {
            panelPatientFactor = (ITTPanel)AddControl(new Guid("58660271-16d3-4db3-84a2-b06aebe54def"));
            lablePatientFactor = (ITTLabel)AddControl(new Guid("fb13e591-247c-4722-95b7-fb4d691e0ba1"));
            EuroScoreAge = (ITTEnumComboBox)AddControl(new Guid("a3b719e1-eaa5-411c-8b2f-eef9eefdfd82"));
            labelEuroScoreAge = (ITTLabel)AddControl(new Guid("7d4fda9c-13ae-46cd-82da-29ca204ffb75"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("422ae7b4-d81a-4a7f-bd05-4e543afced84"));
            labelSex = (ITTLabel)AddControl(new Guid("e7226fef-ff0c-489b-b1fd-dcc649157aec"));
            ChronicPulmonaryDisease = (ITTCheckBox)AddControl(new Guid("6fe48a5f-ac40-4a61-9121-24001b9ad95a"));
            ExtracardiacArteriopathy = (ITTCheckBox)AddControl(new Guid("6b067293-7ae4-403d-9beb-ebffe0eab50b"));
            DiabetesMellitus = (ITTCheckBox)AddControl(new Guid("c49dec93-33c7-4996-a988-31db3c888d53"));
            PreviousCardiacSurgery = (ITTCheckBox)AddControl(new Guid("c3afde8b-7cf5-4890-ab5e-4e35b88865a8"));
            CriticalPreoperativeState = (ITTCheckBox)AddControl(new Guid("12b1d200-1be4-47fa-a965-da2bc5d3f980"));
            NeurologicalDysfunction = (ITTCheckBox)AddControl(new Guid("ff9edeef-c66f-4987-8d45-bf22cd34fc40"));
            ActiveEndokardit = (ITTCheckBox)AddControl(new Guid("2a63abde-a88c-4e2d-a2fc-a7a701d489d7"));
            HemodiyalizPatient = (ITTCheckBox)AddControl(new Guid("2c754ab4-fc1b-4a84-afac-6c30099549b0"));
            panellCardiacFactor = (ITTPanel)AddControl(new Guid("dded3088-c403-44f5-9804-b5176fc55480"));
            labelCardiacFactor = (ITTLabel)AddControl(new Guid("b8b549e0-bd58-4b67-a4e6-1ad2056b5c0b"));
            labelLvDysfunction = (ITTLabel)AddControl(new Guid("3a439db2-ef91-4e6e-a60e-0b6ad22cedff"));
            PulmonerHipertansiyon = (ITTCheckBox)AddControl(new Guid("86897173-53b5-46df-ae95-d1e90909ce8b"));
            LvDysfunction = (ITTEnumComboBox)AddControl(new Guid("6373e612-4a8d-496e-918b-1a0ff7af1b44"));
            panelOperationFactor = (ITTPanel)AddControl(new Guid("1f29badd-328a-4dcd-9d86-e1566dc6290e"));
            abelOperationFactor = (ITTLabel)AddControl(new Guid("a06c5961-503e-4ab4-afe5-96c94f971be8"));
            TorasikAortaSurgery = (ITTCheckBox)AddControl(new Guid("7ae7cca1-6098-493a-80d3-f24b388a81fa"));
            PostMI_VSD = (ITTCheckBox)AddControl(new Guid("ce9d052a-3521-4a6b-ad42-fcab86487e64"));
            base.InitializeControls();
        }

        public EuroScoreOfProcedureForm() : base("EUROSCOREOFPROCEDURE", "EuroScoreOfProcedureForm")
        {
        }

        protected EuroScoreOfProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}