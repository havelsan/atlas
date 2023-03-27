
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
    /// Birlik Üst Kademe Tanımları
    /// </summary>
    public partial class CMRRelationDefinitionsForm : TTDefinitionForm
    {
    /// <summary>
    /// Birlik Üst Kademe Tanımlama
    /// </summary>
        protected TTObjectClasses.CMRRelationsDefinition _CMRRelationsDefinition
        {
            get { return (TTObjectClasses.CMRRelationsDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelCalibrationStage;
        protected ITTObjectListBox CalibrationStage;
        protected ITTLabel labelMaintenanceOrderStage;
        protected ITTObjectListBox MaintenanceOrderStage;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("bed7c477-5c0a-4be7-83d3-0fdb6dff96fa"));
            labelCalibrationStage = (ITTLabel)AddControl(new Guid("63717e34-0d51-430b-8c94-8a363cad1e08"));
            CalibrationStage = (ITTObjectListBox)AddControl(new Guid("4bb28206-e83f-4f4c-94bc-fdfa9612600e"));
            labelMaintenanceOrderStage = (ITTLabel)AddControl(new Guid("7b8992a6-91ee-4c09-98bc-1cb643a68f8e"));
            MaintenanceOrderStage = (ITTObjectListBox)AddControl(new Guid("443cdff5-1b85-4d8f-b9fd-a201fe6f0daa"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("8c94ffbc-577c-4f7c-beae-d8afe996c14d"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("58840783-85cb-4678-b835-bce5bbd75760"));
            base.InitializeControls();
        }

        public CMRRelationDefinitionsForm() : base("CMRRELATIONSDEFINITION", "CMRRelationDefinitionsForm")
        {
        }

        protected CMRRelationDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}