
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
    public partial class AppointmentViewerCompDefForm : TTDefinitionForm
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
#region AppointmentViewerCompDefForm_PreScript
    base.PreScript();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            if (this._AppointmentViewerCompDef.ComputerName == null)
                this._AppointmentViewerCompDef.ComputerName = Common.GetCurrentUserComputerName().ToUpper(cultureInfo);
#endregion AppointmentViewerCompDefForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentViewerCompDefForm_PostScript
    base.PostScript(transDef);
//            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
//            List<ExaminationQueueDefinition> list = ExaminationQueueDefinition.GetMyExaminationQueueDefs(Common.GetCurrentWindowsUserName().ToUpper(cultureInfo));
//            if(list.Count > 1)
//                throw new TTUtils.TTException("Bu bilgisayara daha önce tanım yapılmış. Mükerrer kayıt yapılamaz. Mevcut tanımı düzeltiniz.");
//            
//            list = ExaminationQueueDefinition.GetMyExaminationQueueDefs(Common.GetCurrentUserComputerName().ToUpper(cultureInfo));
//            if(list.Count > 1)
//                throw new TTUtils.TTException("Bu bilgisayara daha önce tanım yapılmış. Mükerrer kayıt yapılamaz. Mevcut tanımı düzeltiniz.");
#endregion AppointmentViewerCompDefForm_PostScript

            }
                }
}