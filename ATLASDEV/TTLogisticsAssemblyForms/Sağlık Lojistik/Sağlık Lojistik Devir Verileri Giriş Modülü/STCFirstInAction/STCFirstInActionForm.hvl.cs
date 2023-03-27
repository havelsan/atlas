
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
    /// Sayım Tartı Çizelgelerinin İlk Girişi
    /// </summary>
    public partial class STCFirstInActionForm : TTForm
    {
    /// <summary>
    /// Sayım Tartı Çizelgesinden İlk Giriş
    /// </summary>
        protected TTObjectClasses.STCFirstInAction _STCFirstInAction
        {
            get { return (TTObjectClasses.STCFirstInAction)_ttObject; }
        }

        protected ITTButton cmdStock;
        protected ITTButton cmdCreateCardDrawer;
        protected ITTButton cmdFirstTransfer;
        protected ITTButton cmdFirstTermOpen;
        protected ITTButton cmdFirstIn;
        protected ITTButton cmdSTCCheck;
        protected ITTLabel labelProgress;
        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            cmdStock = (ITTButton)AddControl(new Guid("95b27bed-4469-411a-b9bb-4085e63d120c"));
            cmdCreateCardDrawer = (ITTButton)AddControl(new Guid("ea7de4ac-953e-4903-9f80-c7a15f387cfa"));
            cmdFirstTransfer = (ITTButton)AddControl(new Guid("eaf9bc35-cc54-4f76-b0e7-58370cf6407a"));
            cmdFirstTermOpen = (ITTButton)AddControl(new Guid("e8cf3782-25c5-4241-9b62-64624e633692"));
            cmdFirstIn = (ITTButton)AddControl(new Guid("7964a266-8e1a-49ed-8d5b-3b92ee3ec6d4"));
            cmdSTCCheck = (ITTButton)AddControl(new Guid("d1a98a3b-e877-454a-9e24-366086baa556"));
            labelProgress = (ITTLabel)AddControl(new Guid("b4bc442b-22b4-45c1-a79c-f04dd95aa0c1"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("d2a88211-073f-47fc-b134-05ecff4b5b90"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("7dda930b-37e0-42d8-92df-b311762bc164"));
            labelID = (ITTLabel)AddControl(new Guid("7e82238d-8268-4692-922c-f260f251a46a"));
            ID = (ITTTextBox)AddControl(new Guid("f41b13ea-fb07-4c4f-8a82-ec94684d9cb9"));
            labelActionDate = (ITTLabel)AddControl(new Guid("b8934e2b-6769-4e9d-ab24-cb842bfcfc99"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("1e72acfb-c450-4f71-a036-174c986d9f1e"));
            base.InitializeControls();
        }

        public STCFirstInActionForm() : base("STCFIRSTINACTION", "STCFirstInActionForm")
        {
        }

        protected STCFirstInActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}