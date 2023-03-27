
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
    public partial class DentalConsultationRequestForm : TTForm
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
#region DentalConsultationRequestForm_PreScript
    base.PreScript();
#endregion DentalConsultationRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalConsultationRequestForm_PostScript
    base.PostScript(transDef);
    if(string.IsNullOrEmpty(this._DentalConsultationRequest.RequestDescription))
    {
        throw new Exception ("İstek açıklaması alanı dolu olmalıdır!");
    }
            
//           foreach (ITTGridRow tempRow in this.DentalConsultationProcedures.Rows) {
//                    Resource consultationDepartment = (TTObjectClasses.Resource) tempRow.TTObject;
//                 
//                    //newConsultation.DentalConsultationRequest.Add(newConsultationRequest);
//                }
#endregion DentalConsultationRequestForm_PostScript

            }
                }
}