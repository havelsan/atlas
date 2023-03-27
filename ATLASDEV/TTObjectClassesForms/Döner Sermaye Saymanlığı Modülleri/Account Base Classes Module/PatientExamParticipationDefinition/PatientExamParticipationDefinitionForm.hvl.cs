
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
    /// Katılım Payı Alınmayacak Hal, Sağlık Hizmeti ve Kişi Tanımları
    /// </summary>
    public partial class PatientExamParticipationDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Katılım Payı Alınmayacak Hal, Sağlık Hizmeti ve Kişi Tanımları
    /// </summary>
        protected TTObjectClasses.PatientExamParticipationDefinition _PatientExamParticipationDefinition
        {
            get { return (TTObjectClasses.PatientExamParticipationDefinition)_ttObject; }
        }

        protected ITTGrid RELATIONSHIPSGRID;
        protected ITTListBoxColumn RELATIONSHIPNAME;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox TYPE;
        protected ITTLabel ttlabel2;
        protected ITTTextBox DESCRIPTION;
        protected ITTTextBox EXTERNALCODE;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox OnlyForDefinedUnits;
        protected ITTGrid UNITSGRID;
        protected ITTListBoxColumn RESSECTIONNAME;
        override protected void InitializeControls()
        {
            RELATIONSHIPSGRID = (ITTGrid)AddControl(new Guid("33b0fe78-055f-469e-954e-fd7bd0b920b3"));
            RELATIONSHIPNAME = (ITTListBoxColumn)AddControl(new Guid("29a336ef-5835-46a0-a969-66145e195bbc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("65062782-034d-4298-a470-b740d73c86a6"));
            TYPE = (ITTEnumComboBox)AddControl(new Guid("9bdcd28d-99ad-4e7d-9f77-2199c02b12aa"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2acacd44-47bc-4971-82e7-abcd230707e8"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("55748b1b-255f-491a-86f3-5cca4589ec11"));
            EXTERNALCODE = (ITTTextBox)AddControl(new Guid("410b1d93-b74e-4337-a1b3-d99a6aed9e74"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("93802509-56fb-4706-93fb-ba531b732491"));
            OnlyForDefinedUnits = (ITTCheckBox)AddControl(new Guid("0b89df4b-6204-4512-a644-c073894ca069"));
            UNITSGRID = (ITTGrid)AddControl(new Guid("ddfed054-95c0-4ee9-ac4b-9fe81fd9ecd8"));
            RESSECTIONNAME = (ITTListBoxColumn)AddControl(new Guid("e0bb5bc4-5724-4faa-852c-533d440aea8b"));
            base.InitializeControls();
        }

        public PatientExamParticipationDefinitionForm() : base("PATIENTEXAMPARTICIPATIONDEFINITION", "PatientExamParticipationDefinitionForm")
        {
        }

        protected PatientExamParticipationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}