
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
    /// BaseErrorReportForm
    /// </summary>
    public partial class BaseErrorReportForm : ActionForm
    {
    /// <summary>
    /// Problem / Hata Bildirimi
    /// </summary>
        protected TTObjectClasses.ErrorReportAction _ErrorReportAction
        {
            get { return (TTObjectClasses.ErrorReportAction)_ttObject; }
        }

        protected ITTLabel labelFromTelephone;
        protected ITTTextBox FromTelephone;
        protected ITTTabControl ErrorReportTabcontrol;
        protected ITTTabPage ErrorReportTabpage;
        protected ITTButton inventoryAddButton;
        protected ITTObjectListBox ErrorReportCategory;
        protected ITTObjectListBox MainCategoryErrorReportCategory;
        protected ITTLabel labelErrorReportInventory;
        protected ITTObjectListBox ErrorReportInventory;
        protected ITTLabel labelErrorReportCategory;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage SolutionTabpage;
        protected ITTTextBox ErrorReportNO;
        protected ITTLabel labelFromUser;
        protected ITTObjectListBox FromUser;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelErrorReportNO;
        override protected void InitializeControls()
        {
            labelFromTelephone = (ITTLabel)AddControl(new Guid("6538e2d2-7803-4eea-b638-a8578871a199"));
            FromTelephone = (ITTTextBox)AddControl(new Guid("91ba38f3-93e0-4275-b840-22cd28ce6205"));
            ErrorReportTabcontrol = (ITTTabControl)AddControl(new Guid("ec045886-5164-45c6-a0f9-e8db454b6172"));
            ErrorReportTabpage = (ITTTabPage)AddControl(new Guid("8f018b5d-f32f-4eee-ac66-876be220849b"));
            inventoryAddButton = (ITTButton)AddControl(new Guid("82a2ea00-71f5-4823-a4bc-ef8e398d4d68"));
            ErrorReportCategory = (ITTObjectListBox)AddControl(new Guid("97198c14-a195-47c6-968f-7f5198588c7c"));
            MainCategoryErrorReportCategory = (ITTObjectListBox)AddControl(new Guid("4aa712f3-4007-45b7-a70f-591cf820b74d"));
            labelErrorReportInventory = (ITTLabel)AddControl(new Guid("c7add376-1b4c-4b0f-8b26-f630338621b4"));
            ErrorReportInventory = (ITTObjectListBox)AddControl(new Guid("1405574f-1e58-427b-bcb4-9ba52939f120"));
            labelErrorReportCategory = (ITTLabel)AddControl(new Guid("1da473a0-f9e6-4138-8759-6e925eeb5da6"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("ec1eb29a-cc64-42e4-8d3a-76b81dd5fcc0"));
            labelToResource = (ITTLabel)AddControl(new Guid("3f3ff25f-a763-4954-8fa7-f9b2e2f40389"));
            labelName = (ITTLabel)AddControl(new Guid("05fbdbb0-ab94-49d3-ab51-1ce4586944e7"));
            Name = (ITTTextBox)AddControl(new Guid("c8d92229-491b-43eb-8c73-3c95f14c0d94"));
            labelDescription = (ITTLabel)AddControl(new Guid("9a25afce-76d2-48d4-a021-9b679d031646"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("b9c22b7c-d29f-4cba-ab3e-060a10dca38f"));
            SolutionTabpage = (ITTTabPage)AddControl(new Guid("e0203724-979e-4f82-999b-8e89d6b9f3ca"));
            ErrorReportNO = (ITTTextBox)AddControl(new Guid("c8e017ea-9caa-4f94-9c8b-c5f676c65a25"));
            labelFromUser = (ITTLabel)AddControl(new Guid("550b5a3c-d70d-4061-a85f-7a992489faa0"));
            FromUser = (ITTObjectListBox)AddControl(new Guid("7470cfe1-984a-4924-924a-beaa3d0149f0"));
            labelFromResource = (ITTLabel)AddControl(new Guid("877127dc-e774-4145-a9e4-2d7a0a72d2f0"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("a8d333a2-fbfb-46dc-bea2-bb674fbf857a"));
            labelActionDate = (ITTLabel)AddControl(new Guid("dc72ee54-14a4-4732-b8f0-0e89212b3f84"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("cc2a1203-e3e2-40e2-bb07-8535f3216aa9"));
            labelErrorReportNO = (ITTLabel)AddControl(new Guid("3e0b4d3e-6889-4e8c-867f-5366443fc4c9"));
            base.InitializeControls();
        }

        public BaseErrorReportForm() : base("ERRORREPORTACTION", "BaseErrorReportForm")
        {
        }

        protected BaseErrorReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}