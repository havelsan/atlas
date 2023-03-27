
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
    /// İşlem Kaynak Eşleştirme Tanımları
    /// </summary>
    public partial class ActionDefaultMasterResourceDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// İşlemler Göre Standart Kaynak Tanımları
    /// </summary>
        protected TTObjectClasses.ActionDefaultMasterResourceDefinition _ActionDefaultMasterResourceDefinition
        {
            get { return (TTObjectClasses.ActionDefaultMasterResourceDefinition)_ttObject; }
        }

        protected ITTGrid MasterResources;
        protected ITTListBoxColumn Resource;
        protected ITTLabel labelActionType;
        protected ITTEnumComboBox ActionType;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            MasterResources = (ITTGrid)AddControl(new Guid("d306dee3-a486-49ac-8c13-13ff39b37107"));
            Resource = (ITTListBoxColumn)AddControl(new Guid("1a820cce-16d1-4fad-acef-b9ba0c984338"));
            labelActionType = (ITTLabel)AddControl(new Guid("4bb93d68-afcf-400f-982d-68a22d2ce1a8"));
            ActionType = (ITTEnumComboBox)AddControl(new Guid("e387ed68-6b16-4641-ac36-73a20680f352"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("84f17680-a8d5-4ec8-80e2-c44150ef60ee"));
            base.InitializeControls();
        }

        public ActionDefaultMasterResourceDefinitionForm() : base("ACTIONDEFAULTMASTERRESOURCEDEFINITION", "ActionDefaultMasterResourceDefinitionForm")
        {
        }

        protected ActionDefaultMasterResourceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}