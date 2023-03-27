
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
    /// Sayım Tartı Çizelgesinden İlk Giriş
    /// </summary>
    public partial class STCFirstInActionCompleted : TTForm
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
            cmdStock = (ITTButton)AddControl(new Guid("fb041c1f-b077-4d70-abfb-9a653b9fd72b"));
            cmdCreateCardDrawer = (ITTButton)AddControl(new Guid("13af806a-4378-4d63-93ad-1021b5e8ef77"));
            cmdFirstTransfer = (ITTButton)AddControl(new Guid("cd0a39dc-6ee9-497a-bce5-03d9e49b67f5"));
            cmdFirstTermOpen = (ITTButton)AddControl(new Guid("a529d2ca-27bf-43b8-b45d-de65b6f9ac1c"));
            cmdFirstIn = (ITTButton)AddControl(new Guid("444f5b6a-ef55-4cc3-bcc0-729bf611cf4b"));
            cmdSTCCheck = (ITTButton)AddControl(new Guid("25dbd887-6e5a-400b-8fca-b226f19accf1"));
            labelProgress = (ITTLabel)AddControl(new Guid("c6b815bf-88a0-41cd-b529-6d7bf8e5b22e"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("891de826-166a-460e-b633-b358698a4c66"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("fc0c6ae6-d676-464f-ad37-99a90c56b1e1"));
            labelID = (ITTLabel)AddControl(new Guid("a0225508-ab2d-418f-8686-3e6c3adc6ead"));
            ID = (ITTTextBox)AddControl(new Guid("d2c3099f-5611-4a1d-9797-d92284faedcb"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5d8c56f9-1697-4ac0-8873-369845427c59"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ff1d9814-fdb6-46f7-a542-787b1dcc1c4b"));
            base.InitializeControls();
        }

        public STCFirstInActionCompleted() : base("STCFIRSTINACTION", "STCFirstInActionCompleted")
        {
        }

        protected STCFirstInActionCompleted(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}