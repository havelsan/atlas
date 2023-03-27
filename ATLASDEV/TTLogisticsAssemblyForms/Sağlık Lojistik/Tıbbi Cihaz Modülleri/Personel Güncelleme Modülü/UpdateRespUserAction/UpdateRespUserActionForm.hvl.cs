
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
    /// Personel Güncelleme
    /// </summary>
    public partial class UpdateRespUserActionForm : TTForm
    {
    /// <summary>
    /// Personel Güncelleme
    /// </summary>
        protected TTObjectClasses.UpdateRespUserAction _UpdateRespUserAction
        {
            get { return (TTObjectClasses.UpdateRespUserAction)_ttObject; }
        }

        protected ITTGrid UpdateRespUserActionDetails;
        protected ITTTextBoxColumn RequestNo;
        protected ITTListBoxColumn CMRResponsibleUser;
        protected ITTListBoxColumn UpdateResUserUpdateRespUserActionDetail;
        protected ITTButton cmdUpdateCMRAction;
        protected ITTButton cmdGetCMRAction;
        protected ITTLabel labelUpdateUser;
        protected ITTObjectListBox UpdateUser;
        protected ITTLabel labelResponsibleUser;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            UpdateRespUserActionDetails = (ITTGrid)AddControl(new Guid("1d1e387e-a468-4687-b5f1-f1ca02103681"));
            RequestNo = (ITTTextBoxColumn)AddControl(new Guid("fe28bc09-afb4-4709-8071-e9bd20854914"));
            CMRResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("955ca52f-28fe-43e3-975f-1669bce71593"));
            UpdateResUserUpdateRespUserActionDetail = (ITTListBoxColumn)AddControl(new Guid("8354013a-77d3-4ae7-b778-ca6c5bcadd8f"));
            cmdUpdateCMRAction = (ITTButton)AddControl(new Guid("ae243d6b-8a5c-4368-b374-b22bb7c35184"));
            cmdGetCMRAction = (ITTButton)AddControl(new Guid("270a27c0-41ef-4968-bdba-ff3e4ff9e896"));
            labelUpdateUser = (ITTLabel)AddControl(new Guid("2e048cb0-7752-4fe2-a781-a9d941fb4a17"));
            UpdateUser = (ITTObjectListBox)AddControl(new Guid("5ee24cc9-13f5-4730-b7ae-ff5e3ea8868c"));
            labelResponsibleUser = (ITTLabel)AddControl(new Guid("aa65325b-f533-42d8-b4e7-442c8bc51c04"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("6a21f0e3-81f2-4423-8f98-efeed03f2fe3"));
            labelID = (ITTLabel)AddControl(new Guid("38dc7336-3d19-427f-998c-7f2de473cab4"));
            ID = (ITTTextBox)AddControl(new Guid("432e156c-408d-4a89-9437-f44a7b900a53"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c9efc820-a89f-4345-ac4f-afbe57b23867"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("cd3f9d42-8bb2-4c0a-bd45-500c27d2c835"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("61696ec0-ff00-4229-abf0-e3678923bd14"));
            base.InitializeControls();
        }

        public UpdateRespUserActionForm() : base("UPDATERESPUSERACTION", "UpdateRespUserActionForm")
        {
        }

        protected UpdateRespUserActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}