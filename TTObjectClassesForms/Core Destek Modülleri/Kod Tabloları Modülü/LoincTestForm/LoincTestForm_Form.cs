
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class LoincTestForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdCreate.Click += new TTControlEventDelegate(cmdCreate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdCreate.Click -= new TTControlEventDelegate(cmdCreate_Click);
            base.UnBindControlEvents();
        }

        private void cmdCreate_Click()
        {
#region LoincTestForm_cmdCreate_Click
   TTObjectContext context = new TTObjectContext(false);
            
            for(int i = 0 ; i < 48600 ; i++)
            {
                LoincDef newDef = new LoincDef(context);
                newDef.IsActive = true;
            }
            context.Save();
#endregion LoincTestForm_cmdCreate_Click
        }
    }
}