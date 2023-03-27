
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
    public partial class NursingWoundedAssesmentForm : BaseNursingDataEntryForm
    {
        protected TTObjectClasses.NursingWoundedAssesment _NursingWoundedAssesment
        {
            get { return (TTObjectClasses.NursingWoundedAssesment)_ttObject; }
        }

        protected ITTLabel labelWoundSide;
        protected ITTObjectListBox WoundSide;
        protected ITTLabel labelNursingWoundTime;
        protected ITTEnumComboBox NursingWoundTime;
        protected ITTLabel labelWoundLocalization;
        protected ITTObjectListBox WoundLocalization;
        protected ITTLabel labelWoundStage;
        protected ITTObjectListBox WoundStage;
        protected ITTGrid WoundPhotos;
        protected ITTDateTimePickerColumn PhotoDateWoundPhoto;
        protected ITTLabel labelDepth;
        protected ITTTextBox Depth;
        protected ITTTextBox Height;
        protected ITTTextBox Width;
        protected ITTLabel labelHeight;
        protected ITTLabel labelOperationDate;
        protected ITTDateTimePicker OperationDate;
        protected ITTLabel labelWidth;
        protected ITTLabel labelWoundedType;
        protected ITTEnumComboBox WoundedType;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        override protected void InitializeControls()
        {
            labelWoundSide = (ITTLabel)AddControl(new Guid("18e2511f-4942-4d3d-ae56-b3d00a09e3b5"));
            WoundSide = (ITTObjectListBox)AddControl(new Guid("50447dba-8b5b-4d30-b200-c69820d004b2"));
            labelNursingWoundTime = (ITTLabel)AddControl(new Guid("128a0a58-73e9-4b22-be86-cb0cca53e0b9"));
            NursingWoundTime = (ITTEnumComboBox)AddControl(new Guid("51d5ef02-2a37-4b90-bedf-2dd933634e10"));
            labelWoundLocalization = (ITTLabel)AddControl(new Guid("c81f16ee-53a3-4245-aa14-0b1ad0b5d46d"));
            WoundLocalization = (ITTObjectListBox)AddControl(new Guid("df576968-48c1-4dd6-87af-d364a3cde3b3"));
            labelWoundStage = (ITTLabel)AddControl(new Guid("2a6d24ef-6a69-4489-8073-bca94a46402c"));
            WoundStage = (ITTObjectListBox)AddControl(new Guid("b0874e96-2cd7-440d-bbda-ba328e26311d"));
            WoundPhotos = (ITTGrid)AddControl(new Guid("6ab3aa9f-cce1-4f44-b5b2-88cf88d884ec"));
            PhotoDateWoundPhoto = (ITTDateTimePickerColumn)AddControl(new Guid("e578e8ef-d24a-4185-b2df-93d9e5352ea5"));
            labelDepth = (ITTLabel)AddControl(new Guid("6e241af6-47af-418a-8d05-e3efd16229a7"));
            Depth = (ITTTextBox)AddControl(new Guid("aac2bcdd-936b-48ef-932c-9a5ba9571790"));
            Height = (ITTTextBox)AddControl(new Guid("60736ef4-e986-48b0-b43e-0c95c5e9d239"));
            Width = (ITTTextBox)AddControl(new Guid("842a3779-9771-4a90-a451-8e4d796fb73f"));
            labelHeight = (ITTLabel)AddControl(new Guid("fa0a98e3-38e5-4fda-84bb-209122b2e2de"));
            labelOperationDate = (ITTLabel)AddControl(new Guid("1e299c14-39a7-468b-8311-d65101e61808"));
            OperationDate = (ITTDateTimePicker)AddControl(new Guid("6e536941-dd56-4980-b18e-ff940a1ccb32"));
            labelWidth = (ITTLabel)AddControl(new Guid("119efb54-773f-4538-8204-7c4e564df731"));
            labelWoundedType = (ITTLabel)AddControl(new Guid("8658e3f1-14d3-4da7-96b8-5bea01cf37e7"));
            WoundedType = (ITTEnumComboBox)AddControl(new Guid("9960084a-54e1-4caf-b043-3d6fe156841e"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("963b0fc7-c338-45d7-8b42-dc4c66757a49"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("83a465d1-ac1e-45a9-8a59-1a5e4582ae8e"));
            base.InitializeControls();
        }

        public NursingWoundedAssesmentForm() : base("NURSINGWOUNDEDASSESMENT", "NursingWoundedAssesmentForm")
        {
        }

        protected NursingWoundedAssesmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}