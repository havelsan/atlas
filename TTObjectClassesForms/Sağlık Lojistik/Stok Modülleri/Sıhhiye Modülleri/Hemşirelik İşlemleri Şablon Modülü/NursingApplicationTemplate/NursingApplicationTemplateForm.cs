
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
    /// <summary>
    /// Hemşilerik İşlemleri Şablon Oluşturma Formu
    /// </summary>
    public partial class NursingApplicationTemplateForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region NursingApplicationTemplateForm_PreScript
    base.PreScript();
            
            
            if(_NursingApplicationTemplate.CurrentStateDefID == NursingApplicationTemplate.States.Complated)
            {
                this.TemplateName.ReadOnly = true;
                this.NursingAppTempDetails.ReadOnly = true;
            }
#endregion NursingApplicationTemplateForm_PreScript

            }
                }
}