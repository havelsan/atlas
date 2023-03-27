
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
    public partial class MuscleStrengthMeasuringForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// Kas Gücünün Dinamometre ile Ölçümü (Tek Ekstremite)
    /// </summary>
        protected TTObjectClasses.MuscleStrengthMeasuringForm _MuscleStrengthMeasuringForm
        {
            get { return (TTObjectClasses.MuscleStrengthMeasuringForm)_ttObject; }
        }

        protected ITTLabel labelGripStrengthMeasuring;
        protected ITTTextBox GripStrengthMeasuring;
        protected ITTTextBox Code;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelGripStrengthMeasuring = (ITTLabel)AddControl(new Guid("7c70eeb9-acd3-4a62-9a93-2deb5d0e8834"));
            GripStrengthMeasuring = (ITTTextBox)AddControl(new Guid("7caec617-fee1-4970-a982-5859ca0ed881"));
            Code = (ITTTextBox)AddControl(new Guid("5fafc0aa-f897-4b0a-a684-f5c7abd4fb71"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("586b78d1-f5c6-45f0-a587-0066b3a898cc"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("a159ab17-44a6-4ace-9848-477f3909e805"));
            labelCode = (ITTLabel)AddControl(new Guid("83bf48be-3e7a-47a4-b529-cb726d116eae"));
            base.InitializeControls();
        }

        public MuscleStrengthMeasuringForm() : base("MUSCLESTRENGTHMEASURINGFORM", "MuscleStrengthMeasuringForm")
        {
        }

        protected MuscleStrengthMeasuringForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}