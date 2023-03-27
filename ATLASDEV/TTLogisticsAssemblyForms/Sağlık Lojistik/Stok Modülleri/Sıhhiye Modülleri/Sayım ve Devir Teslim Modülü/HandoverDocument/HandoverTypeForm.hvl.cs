
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
    public partial class HandoverTypeForm : TTForm
    {
    /// <summary>
    /// Devir Teslim Belgesi
    /// </summary>
        protected TTObjectClasses.HandoverDocument _HandoverDocument
        {
            get { return (TTObjectClasses.HandoverDocument)_ttObject; }
        }

        protected ITTLabel labelCardDrawer;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelCensusOrderType;
        protected ITTEnumComboBox CensusOrderType;
        override protected void InitializeControls()
        {
            labelCardDrawer = (ITTLabel)AddControl(new Guid("58cd2f39-4dd4-4cb4-bf0f-ca852a23535f"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("7a71d633-92e8-48d1-a2e7-4c4be2bf6278"));
            labelCensusOrderType = (ITTLabel)AddControl(new Guid("e360f39e-d5e0-4ec9-8a07-463d70bde224"));
            CensusOrderType = (ITTEnumComboBox)AddControl(new Guid("be67042f-dc2c-4b6b-9fbb-7c09e9e11434"));
            base.InitializeControls();
        }

        public HandoverTypeForm() : base("HANDOVERDOCUMENT", "HandoverTypeForm")
        {
        }

        protected HandoverTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}