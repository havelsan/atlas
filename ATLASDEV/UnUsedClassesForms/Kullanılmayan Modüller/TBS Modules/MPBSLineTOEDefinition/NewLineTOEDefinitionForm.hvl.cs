
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
    /// Satır TMK Tanımlama
    /// </summary>
    public partial class NewLineTOEDefinitionForm : TTForm
    {
    /// <summary>
    /// Satır TMK Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSLineTOEDefinition _MPBSLineTOEDefinition
        {
            get { return (TTObjectClasses.MPBSLineTOEDefinition)_ttObject; }
        }

        protected ITTListDefComboBox ParaphTOE;
        protected ITTLabel labelOccupation;
        protected ITTLabel labelLineTOECode;
        protected ITTTextBox Peace;
        protected ITTLabel labelSection;
        protected ITTListDefComboBox ArmedForce;
        protected ITTLabel ttlabel11;
        protected ITTCheckBox Active;
        protected ITTLabel labelParaphTOE;
        protected ITTTextBox LineTOECode;
        protected ITTLabel labelArmedForce;
        protected ITTTextBox Mobilization;
        protected ITTCheckBox Rotative;
        protected ITTLabel labelPeace;
        protected ITTLabel labelBranch;
        protected ITTListDefComboBox Occupation;
        protected ITTListDefComboBox Honorific;
        protected ITTListDefComboBox Class;
        protected ITTLabel labelHonorific;
        protected ITTListDefComboBox Branch;
        protected ITTListDefComboBox Section;
        protected ITTLabel labelRank;
        protected ITTLabel labelMobilization;
        protected ITTListDefComboBox MainTOE;
        protected ITTCheckBox GeneralStaff;
        protected ITTListDefComboBox ttlistdefcombobox6;
        protected ITTLabel labelClass;
        override protected void InitializeControls()
        {
            ParaphTOE = (ITTListDefComboBox)AddControl(new Guid("b067a778-23c1-46f9-ab4a-17d775c2937b"));
            labelOccupation = (ITTLabel)AddControl(new Guid("29ba7238-b74a-483b-a383-f3af227c8d1f"));
            labelLineTOECode = (ITTLabel)AddControl(new Guid("d4655d73-a983-4aae-96de-e5959bbcc0e5"));
            Peace = (ITTTextBox)AddControl(new Guid("c3774196-2a47-44f3-8527-ec728cc61af5"));
            labelSection = (ITTLabel)AddControl(new Guid("9a360f84-76e4-4566-acd9-e87bafe5bb8e"));
            ArmedForce = (ITTListDefComboBox)AddControl(new Guid("687d984f-2534-4e23-9dc7-e1b9b28116cc"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("324db04e-32ae-47ac-b795-af56fb653964"));
            Active = (ITTCheckBox)AddControl(new Guid("f80e424a-f942-47fc-a826-ae631c1521e3"));
            labelParaphTOE = (ITTLabel)AddControl(new Guid("b3c046dd-2c45-4730-b0e1-bdbf45f843ca"));
            LineTOECode = (ITTTextBox)AddControl(new Guid("ed1e0847-5608-49f0-974f-bb026e84fc9a"));
            labelArmedForce = (ITTLabel)AddControl(new Guid("76c1b28b-c4d8-44eb-9a34-9ae4dd70fd9a"));
            Mobilization = (ITTTextBox)AddControl(new Guid("778fac5e-d9be-4ace-96c7-b667f2c3cc2f"));
            Rotative = (ITTCheckBox)AddControl(new Guid("eb5dc745-1bb1-450f-9e75-f057c5b14610"));
            labelPeace = (ITTLabel)AddControl(new Guid("9fb86503-cb3e-418f-8c02-95eafe8350ac"));
            labelBranch = (ITTLabel)AddControl(new Guid("3b7ab4c0-898d-476e-97c1-b2235d862b4a"));
            Occupation = (ITTListDefComboBox)AddControl(new Guid("9f077df2-456e-4f7d-b74f-70312854eaaf"));
            Honorific = (ITTListDefComboBox)AddControl(new Guid("8cf3407a-4f3f-49ca-8162-940478d7b828"));
            Class = (ITTListDefComboBox)AddControl(new Guid("435ce35c-27d1-4818-9cad-8a99b27c9b1f"));
            labelHonorific = (ITTLabel)AddControl(new Guid("57d53fd8-19b9-465f-a37d-58b51ba891b4"));
            Branch = (ITTListDefComboBox)AddControl(new Guid("48447fbc-ab2b-4075-805b-61708f0ccc47"));
            Section = (ITTListDefComboBox)AddControl(new Guid("fa376c89-47b8-4176-9551-43f2471defa4"));
            labelRank = (ITTLabel)AddControl(new Guid("2c54e9c5-a1d7-455a-af25-2be11a7e3a05"));
            labelMobilization = (ITTLabel)AddControl(new Guid("bb2a82e6-9fe9-4131-b2fb-0c8981ca4a24"));
            MainTOE = (ITTListDefComboBox)AddControl(new Guid("709df9b4-eb89-4a1c-b347-049b5a14a5b1"));
            GeneralStaff = (ITTCheckBox)AddControl(new Guid("371fff7e-b635-40f8-8a18-0a8c08eacadf"));
            ttlistdefcombobox6 = (ITTListDefComboBox)AddControl(new Guid("b8b79d98-95ac-4687-b4a7-a337882e7206"));
            labelClass = (ITTLabel)AddControl(new Guid("0515356a-57da-4c96-a5df-fcd596b1afa1"));
            base.InitializeControls();
        }

        public NewLineTOEDefinitionForm() : base("MPBSLINETOEDEFINITION", "NewLineTOEDefinitionForm")
        {
        }

        protected NewLineTOEDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}