
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
    /// Dış XXXXXX Hizmet İstek
    /// </summary>
    public partial class ExternalProcedureRequestForm : TTForm
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
#region ExternalProcedureRequestForm_PostScript
    base.PostScript(transDef);
            
            // Aşağıdaki metod açılırsa içindeki new SubactionProcedure() kodunun SubactionProcedure den türeyen bir yeni bir class yapılıp
            // onunla değiştirilmesi gerekir, yoksa medulaya hizmet kaydı yapan GetDVO metodu null döndürür. )
            
            //this.SetAllProcedureDefsAsProcedureRequests(ProcedureGrid);
#endregion ExternalProcedureRequestForm_PostScript

            }
            
#region ExternalProcedureRequestForm_Methods
        // Aşağıdaki metod, şu anda sadece formun PostScript inde kullanılıyor ve orada da commentlenmiş durumda, yani herhangi bir yerden 
        // çağırılmıyor. Eğer kullanılmaya karar veririlse içindeki new SubactionProcedure() kodunun, SubactionProcedure den türeyen bir yeni bir 
        // class yapılıp onunla değiştirilmesi gerekir, yoksa medulaya hizmet kaydı yapan GetDVO metodu null döndürür. )

        private void SetAllProcedureDefsAsProcedureRequests(ITTGrid ProcedureGrid)
        {
            foreach(ITTGridRow procedure in ProcedureGrid.Rows)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                
                string defId = procedure.Cells[0].Value.ToString();
                ProcedureDefinition procDef = (ProcedureDefinition)this._ttObject.ObjectContext.GetObject(new Guid (defId),"PROCEDUREDEFINITION");
                
                SubActionProcedure newSb = new SubActionProcedure(this._ExternalProcedureRequest.ObjectContext);
                newSb.ProcedureObject = procDef;
                
                foreach(TTObjectRelationDef relationDef in procDef.ObjectDef.AllChildRelationDefs)
                {
                    if(relationDef.OverridesRelationDef != null)
                    {
                        if(relationDef.OverridesRelationDef.CodeName == "ProcedureObject")
                        {
                            SubActionProcedure externalSubactionProcedure= (SubActionProcedure)this._ttObject.ObjectContext.CreateObject(relationDef.ChildObjectDef.Name.ToUpperInvariant());
                            if(externalSubactionProcedure is SubactionProcedureFlowable)
                            {
                                SubactionProcedureFlowable externalSubactionProcedureFlowable = (SubactionProcedureFlowable)externalSubactionProcedure;
                                externalSubactionProcedureFlowable.EpisodeAction = this._ExternalProcedureRequest;
                                externalSubactionProcedureFlowable.ProcedureObject = procDef;
                                externalSubactionProcedureFlowable.Amount = 1;
                                externalSubactionProcedureFlowable.MasterResource = this._ExternalProcedureRequest.MasterResource;
                            }
                            else
                            {
                                externalSubactionProcedure.EpisodeAction = this._ExternalProcedureRequest;
                                externalSubactionProcedure.ProcedureObject = procDef;
                                externalSubactionProcedure.Amount = 1;
                            }
                        }
                    }
                    else
                    {
                        if (relationDef.ParentObjectDef.IsOfType(typeof(ProcedureDefinition).Name.ToUpperInvariant()) && relationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                        {
                            SubActionProcedure externalSubactionProcedure= (SubActionProcedure)this._ttObject.ObjectContext.CreateObject(relationDef.ChildObjectDef.Name.ToUpperInvariant());
                            if(externalSubactionProcedure is SubactionProcedureFlowable)
                            {
                                SubactionProcedureFlowable externalSubactionProcedureFlowable = (SubactionProcedureFlowable)externalSubactionProcedure;
                                externalSubactionProcedureFlowable.EpisodeAction = this._ExternalProcedureRequest;
                                externalSubactionProcedureFlowable.ProcedureObject = procDef;
                                externalSubactionProcedureFlowable.Amount = 1;
                                externalSubactionProcedureFlowable.MasterResource = this._ExternalProcedureRequest.MasterResource;
                            }
                            else
                            {
                                externalSubactionProcedure.EpisodeAction = this._ExternalProcedureRequest;
                                externalSubactionProcedure.ProcedureObject = procDef;
                                externalSubactionProcedure.Amount = 1;
                            }
                        }
                    }
                }
            }
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            //this._ExternalProcedureRequest.PrintExternalRequestDescriptonReport(this._ExternalProcedureRequest);
            this.PrintExternalRequestDescriptonReport(this._ExternalProcedureRequest);
            
            /*
            foreach(SubActionProcedure procedure in this._ExternalProcedureRequest.SubactionProcedures)
            {
                this._ExternalProcedureRequest.PrintExternalRequestDescriptonReport(procedure);
            }
             */
        }
        
#endregion ExternalProcedureRequestForm_Methods

#region ExternalProcedureRequestForm_ClientSideMethods
        public void PrintExternalRequestDescriptonReport(ExternalProcedureRequest request)
        {
            //ProcedureDefinition procedureDef = (ProcedureDefinition)procedure.ProcedureObject;
            
            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", request.ObjectID.ToString());
            
            parameters.Add("TTOBJECTID",objectID);
            
            //TTReportTool.TTReport.PrintReport("ExternalProcedureRequestReport", true, 1, parameters);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_ExternalProcedureRequestReport),true,1,parameters);
        }
        
#endregion ExternalProcedureRequestForm_ClientSideMethods
    }
}