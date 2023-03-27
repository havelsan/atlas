
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
    /// Genel Cihaz Tanımları
    /// </summary>
    public partial class ClinicEquipmentDefinitionForm : TTForm
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
#region ClinicEquipmentDefinitionForm_PostScript
    base.PostScript(transDef);
            if (this._ResEquipment.EnabledType==null)
            {
                this._ResEquipment.EnabledType=ResourceEnableType.UnEnable;
            }
            
            if(this._ResEquipment.ObservationUnit==null && this._ResEquipment.Clinic==null){
                throw new Exception(SystemMessage.GetMessage(1252));
            }else if(this._ResEquipment.ObservationUnit!=null && this._ResEquipment.Clinic!=null){
                throw new Exception(SystemMessage.GetMessage(1253));
            }
#endregion ClinicEquipmentDefinitionForm_PostScript

            }
                }
}