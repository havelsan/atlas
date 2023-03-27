
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
    /// Genel Radyoloji Test Tanımları
    /// </summary>
    public partial class RadiologyTestTMDefinitionForm : TTForm
    {
    /// <summary>
    /// Radyoloji Tetkik Tanımları (TM)
    /// </summary>
        protected TTObjectClasses.RadiologyTestTMDefinition _RadiologyTestTMDefinition
        {
            get { return (TTObjectClasses.RadiologyTestTMDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelID;
        protected ITTLabel labelQref;
        protected ITTTextBox EnglishName;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTLabel labelEnglishName;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("f9f984a5-3f9f-4816-8564-99a1a54c898a"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("d4739d09-32e1-4ea1-9a54-9127f068f665"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("5adeccf8-247d-49c8-949f-3886e6406af3"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("f1738c1e-3895-474d-a4f4-c78c5c518172"));
            labelID = (ITTLabel)AddControl(new Guid("48bf3975-3cdc-471a-8f04-1c9a6d463031"));
            labelQref = (ITTLabel)AddControl(new Guid("4de86ea0-36b2-405b-b45a-1d11d2bee627"));
            EnglishName = (ITTTextBox)AddControl(new Guid("5324613a-4c69-432f-8d19-393525c54bc7"));
            ID = (ITTTextBox)AddControl(new Guid("49874ce6-17b7-4f1d-8dd7-2ddc3214d410"));
            Qref = (ITTTextBox)AddControl(new Guid("06709f77-4007-429a-9f89-367a0adc53a5"));
            Name = (ITTTextBox)AddControl(new Guid("8ede3fdb-d9ed-47a0-bffe-840484eea237"));
            Code = (ITTTextBox)AddControl(new Guid("76dccb98-3e71-44f5-ad18-79ae0f31f671"));
            Description = (ITTTextBox)AddControl(new Guid("718cfbcc-3ae2-4b68-81e3-d54fda73992a"));
            labelDescription = (ITTLabel)AddControl(new Guid("b84aa1a6-5170-426b-9c27-37851da16055"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c519e71c-6ebd-4e7f-81f9-824f474963bc"));
            labelCode = (ITTLabel)AddControl(new Guid("1b501b97-56f2-43ee-aa1a-8f4892977dfd"));
            labelName = (ITTLabel)AddControl(new Guid("9a447d83-7564-47bc-86e3-c808efb3d872"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("8a4c13b1-3a62-489d-b5ba-c72297fb400e"));
            base.InitializeControls();
        }

        public RadiologyTestTMDefinitionForm() : base("RADIOLOGYTESTTMDEFINITION", "RadiologyTestTMDefinitionForm")
        {
        }

        protected RadiologyTestTMDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}