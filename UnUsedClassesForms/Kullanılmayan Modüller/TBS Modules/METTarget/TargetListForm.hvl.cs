
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
    /// Hedefler
    /// </summary>
    public partial class TargetListForm : TTListForm
    {
        protected ITTLabel labelID;
        protected ITTTextBox Type;
        protected ITTLabel labelType;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTTextBox ID;
        override protected void InitializeControls()
        {
            labelID = (ITTLabel)AddControl(new Guid("82b2ad79-51a8-415a-a481-0f373d8da7f2"));
            Type = (ITTTextBox)AddControl(new Guid("d9212945-5563-4413-aabf-1f87dff98375"));
            labelType = (ITTLabel)AddControl(new Guid("3b0df553-8744-4ede-ada8-4ac65e5af48c"));
            Name = (ITTTextBox)AddControl(new Guid("0e1393dd-3621-4545-a2bf-80bb8e97d000"));
            labelName = (ITTLabel)AddControl(new Guid("f07d38c5-2b4f-412c-9410-bba31e4177d6"));
            ID = (ITTTextBox)AddControl(new Guid("e8711ba1-9eb3-47ab-b662-e84d18436f10"));
            base.InitializeControls();
        }

        public TargetListForm(TTList ttList) : base(ttList, "METTARGET", "TargetListForm")
        {
        }
    }
}