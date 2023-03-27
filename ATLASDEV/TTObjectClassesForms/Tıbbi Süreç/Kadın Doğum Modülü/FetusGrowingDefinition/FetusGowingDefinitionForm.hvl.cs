
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
    /// Beklenen Fetus Gelişimi Tanımlama Formu
    /// </summary>
    public partial class FetusGowingDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.FetusGrowingDefinition _FetusGrowingDefinition
        {
            get { return (TTObjectClasses.FetusGrowingDefinition)_ttObject; }
        }

        protected ITTLabel labelFemurLength;
        protected ITTTextBox FemurLength;
        protected ITTTextBox AbdominalCircumference;
        protected ITTTextBox HeadCircumference;
        protected ITTTextBox BiparietalDiameter;
        protected ITTTextBox Weight;
        protected ITTTextBox PregnancyWeek;
        protected ITTTextBox Length;
        protected ITTLabel labelAbdominalCircumference;
        protected ITTLabel labelHeadCircumference;
        protected ITTLabel labelBiparietalDiameter;
        protected ITTLabel labelWeight;
        protected ITTLabel labelPregnancyWeek;
        protected ITTLabel labelLength;
        override protected void InitializeControls()
        {
            labelFemurLength = (ITTLabel)AddControl(new Guid("d358a6f1-c3fb-4ca1-9adf-bbf4797a9d97"));
            FemurLength = (ITTTextBox)AddControl(new Guid("67002ddb-34ca-4cc8-b7be-d99deb3116ff"));
            AbdominalCircumference = (ITTTextBox)AddControl(new Guid("dd2ddcdb-3594-42e2-b41b-6a5fc0114072"));
            HeadCircumference = (ITTTextBox)AddControl(new Guid("9116ccba-4978-4764-b7a5-fe808304b85e"));
            BiparietalDiameter = (ITTTextBox)AddControl(new Guid("c64156c9-7169-43a5-808c-5158c29bc7ce"));
            Weight = (ITTTextBox)AddControl(new Guid("ed159efe-d6f3-467b-b7b7-76b0ddbdce98"));
            PregnancyWeek = (ITTTextBox)AddControl(new Guid("755de280-0302-4dd7-98ff-48de5a1a9485"));
            Length = (ITTTextBox)AddControl(new Guid("b7c9b1a3-cc15-4eb2-82db-feb39da49b97"));
            labelAbdominalCircumference = (ITTLabel)AddControl(new Guid("b32313bf-dc0a-4df7-9f2b-261d8fe9cd38"));
            labelHeadCircumference = (ITTLabel)AddControl(new Guid("8237c971-6306-4019-a2eb-bbb2bdfb5d8d"));
            labelBiparietalDiameter = (ITTLabel)AddControl(new Guid("2d08811c-f93b-47e0-9824-7473ff12e7ee"));
            labelWeight = (ITTLabel)AddControl(new Guid("0b23fa4a-2feb-4263-bf5e-9b5fb5946b2c"));
            labelPregnancyWeek = (ITTLabel)AddControl(new Guid("e577c633-024d-4f60-8426-6bae6f7bacfb"));
            labelLength = (ITTLabel)AddControl(new Guid("01777ef4-1ebd-40db-8096-6415b5fae045"));
            base.InitializeControls();
        }

        public FetusGowingDefinitionForm() : base("FETUSGROWINGDEFINITION", "FetusGowingDefinitionForm")
        {
        }

        protected FetusGowingDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}