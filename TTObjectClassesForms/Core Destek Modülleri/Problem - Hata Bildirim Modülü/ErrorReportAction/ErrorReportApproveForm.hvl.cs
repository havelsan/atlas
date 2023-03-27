
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
    /// Problem / Hata Bildirimi
    /// </summary>
    public partial class ErrorReportApproveForm : BaseErrorReportForm
    {
    /// <summary>
    /// Problem / Hata Bildirimi
    /// </summary>
        protected TTObjectClasses.ErrorReportAction _ErrorReportAction
        {
            get { return (TTObjectClasses.ErrorReportAction)_ttObject; }
        }

        protected ITTLabel labelOwnerUser;
        protected ITTObjectListBox OwnerUser;
        protected ITTLabel labelOwnerResource;
        protected ITTObjectListBox OwnerResource;
        protected ITTLabel labelErrorPriority;
        protected ITTEnumComboBox ErrorPriority;
        override protected void InitializeControls()
        {
            labelOwnerUser = (ITTLabel)AddControl(new Guid("5cbad42c-b187-43af-ba74-546ecec760f1"));
            OwnerUser = (ITTObjectListBox)AddControl(new Guid("80d87abf-a28a-49c6-bb69-5649fec331ef"));
            labelOwnerResource = (ITTLabel)AddControl(new Guid("c79babf3-9c7f-4aba-8ea4-96d2bf5a6d9f"));
            OwnerResource = (ITTObjectListBox)AddControl(new Guid("85522979-4038-4944-9544-72dc1cebedd8"));
            labelErrorPriority = (ITTLabel)AddControl(new Guid("1418abd8-1248-45d7-b294-28b50f9f4fc7"));
            ErrorPriority = (ITTEnumComboBox)AddControl(new Guid("5d37886d-cb9a-48a4-a27a-48843c877b36"));
            base.InitializeControls();
        }

        public ErrorReportApproveForm() : base("ERRORREPORTACTION", "ErrorReportApproveForm")
        {
        }

        protected ErrorReportApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}