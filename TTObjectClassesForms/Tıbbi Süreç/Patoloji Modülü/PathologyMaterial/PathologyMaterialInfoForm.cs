
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
    public partial class PathologyMaterialInfo : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }
        
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            base.PostScript(transDef);
            for (int i = 0; i < this._PathologyMaterial.PathologyTestProcedure.Count; i++)
            {
                this._PathologyMaterial.PathologyTestProcedure[i].EpisodeAction = this._PathologyMaterial.Pathology;

            }
            this._PathologyMaterial.ObjectContext.Save();
       
        }
    }
}