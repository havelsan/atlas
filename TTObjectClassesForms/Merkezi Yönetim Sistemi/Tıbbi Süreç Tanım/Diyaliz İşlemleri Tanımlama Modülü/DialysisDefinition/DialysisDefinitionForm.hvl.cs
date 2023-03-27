
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
    /// Diyaliz Hizmeti Tanımı
    /// </summary>
    public partial class DialysisDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diyaliz İşlemleri Tanımlama
    /// </summary>
        protected TTObjectClasses.DialysisDefinition _DialysisDefinition
        {
            get { return (TTObjectClasses.DialysisDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox TREATMENTDURATION;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox Chargable;
        protected ITTLabel labelID;
        protected ITTGrid TreatmentUnits;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTGrid DialysisTreatmentEquipments;
        protected ITTListBoxColumn TreatmentEquipment;
        protected ITTLabel labelQref;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("fc35ed3b-a0fd-49ad-adbb-28431921c28f"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("d9dea415-575d-4ea6-a687-1dde2ddfed0e"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("6e26ac0c-6bec-4298-b323-af572e3db9bf"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("31c8eb94-aec3-4954-a002-43cef65ab0cc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("dac9bd94-2f4c-4438-8b2b-d612f591937b"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("12de5d87-1c56-487c-bcb1-d310ac79235d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0efe42c2-7362-4b17-ad9a-4b9fa00c44bc"));
            labelName = (ITTLabel)AddControl(new Guid("2117b31e-842d-49cf-bc7c-e697f78b1cc9"));
            Name = (ITTTextBox)AddControl(new Guid("d0095fd6-a85e-400f-ba83-651350e1f0eb"));
            EnglishName = (ITTTextBox)AddControl(new Guid("a8b2536c-bae5-486e-a59a-f69cd891dac6"));
            Description = (ITTTextBox)AddControl(new Guid("474c51fa-3484-4c96-b700-56dda6b233c2"));
            Code = (ITTTextBox)AddControl(new Guid("975a0aad-bbdd-44d6-bc64-873aafc3c26a"));
            TREATMENTDURATION = (ITTTextBox)AddControl(new Guid("0bf47f60-aaba-40ef-bb9b-a2765bb5b148"));
            ID = (ITTTextBox)AddControl(new Guid("7e12761e-23ea-44de-9b30-236f288cc367"));
            Qref = (ITTTextBox)AddControl(new Guid("6a4ef959-b888-427b-a8bb-ceb30cfb1517"));
            IsActive = (ITTCheckBox)AddControl(new Guid("f3d23cb3-544d-4c9b-85d3-db0523ba0453"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("33d1af3d-51ba-4130-8a10-452f73961e68"));
            labelDescription = (ITTLabel)AddControl(new Guid("e3116907-1f73-467f-99b3-0e74a714a0c1"));
            labelCode = (ITTLabel)AddControl(new Guid("31ca3394-05ca-4574-990a-7fcd94320f1f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8a4eefbe-836d-4411-baa3-e889a42c925f"));
            Chargable = (ITTCheckBox)AddControl(new Guid("f95f37ad-f71b-4beb-8fdb-52729ceea4e4"));
            labelID = (ITTLabel)AddControl(new Guid("1fe7388f-c6cc-4f0e-9150-1d0726a0cc2e"));
            TreatmentUnits = (ITTGrid)AddControl(new Guid("760097fb-51c3-4724-97b4-0bbca255ffb0"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("bb6e0834-c042-4d23-9830-99752668217a"));
            DialysisTreatmentEquipments = (ITTGrid)AddControl(new Guid("dca0ac5f-3324-46d1-944e-f5cdefdaa9a1"));
            TreatmentEquipment = (ITTListBoxColumn)AddControl(new Guid("20227a56-aa60-4ff7-b1d9-119b0d760006"));
            labelQref = (ITTLabel)AddControl(new Guid("d4c52b7f-2b6b-4f3e-bd23-720454c90c08"));
            base.InitializeControls();
        }

        public DialysisDefinitionForm() : base("DIALYSISDEFINITION", "DialysisDefinitionForm")
        {
        }

        protected DialysisDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}