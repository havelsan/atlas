
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
    /// Konsültasyon İstek
    /// </summary>
    public partial class ConsultationRequestForm : EpisodeActionForm
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
#region ConsultationRequestForm_PreScript
    Guid Doctor= new Guid("9431A69C-1A2A-4DCF-B1D3-6B1368318F89");
            Guid Dietician= new Guid("0a5a3824-d3fa-4400-a3c1-c2a8906726a5");
            Guid Psychologist= new Guid("fa55ee1d-3048-453d-b46d-64ea35953e50");
            
            base.PreScript();
            if(this.RequestedDoctor.SelectedObject == null)
            {
                //SetProcedureDoctorAsCurrentResource();
                if(Common.CurrentUser.HasRole(Doctor) || Common.CurrentUser.HasRole(Dietician)|| Common.CurrentUser.HasRole(Psychologist))
                {
                    this.RequestedDoctor.SelectedObject = Common.CurrentResource;
                }
            }
            if(this.RequestedDoctor.SelectedObject != null)
                this.RequestedDoctor.ReadOnly=true;
            else
                this.RequestedDoctor.ReadOnly=false;
         
            
//            TTObjectContext rocontext = new TTObjectContext(true);
//             //anestezi konsültasyonu isteğı yapılan birimlere burda istek yapılamasın
//            string filter = "";
//            
//            BindingList<ActionDefaultMasterResourceDefinition> adMasterResourceDefinitionList = ActionDefaultMasterResourceDefinition.GetByActionType(rocontext, ActionTypeEnum.AnesthesiaConsultation);
//            
//            foreach (ActionDefaultMasterResourceDefinition adMasterResourceDefinition in adMasterResourceDefinitionList)
//            {
//                foreach(ActionDefaultMasterResourceGrid adMasterResourceGrid in adMasterResourceDefinition.MasterResources)
//                {
//                    if(adMasterResourceGrid.Resource != null)
//                    {
//                        if(filter == "")
//                            filter += " OBJECTID NOT IN(";
//                        else
//                            filter += ",";
//                        filter += "'" + adMasterResourceGrid.Resource.ObjectID.ToString() + "'";
//                    }
//                }
//                break;
//            }
//            if(filter != "")
//                filter += ")";
//            
//            ((ITTListBoxColumn)((ITTGridColumn)this.ConsultationProcedures.Columns["MasterResource"])).ListFilterExpression =  filter;
#endregion ConsultationRequestForm_PreScript

            }
                }
}