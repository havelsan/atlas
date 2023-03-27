
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
    /// Dış XXXXXX Hizmet Ana Formu
    /// </summary>
    public partial class ExternalProcedureBaseForm : TTForm
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
#region ExternalProcedureBaseForm_PostScript
    base.PostScript(transDef);
            
            this.SetAllProcedureDefsAsProcedureRequests(ProcedureGrid);
#endregion ExternalProcedureBaseForm_PostScript

            }
            
#region ExternalProcedureBaseForm_Methods
        private void SetAllProcedureDefsAsProcedureRequests(ITTGrid ProcedureGrid)
        {
            foreach(ITTGridRow procedure in ProcedureGrid.Rows)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                
                string defId = procedure.Cells[0].Value.ToString();
                ProcedureDefinition procDef = (ProcedureDefinition)this._ttObject.ObjectContext.GetObject(new Guid (defId),"PROCEDUREDEFINITION");
                

                //                if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                //                {
                //                    if(rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant()== RFAprosedureDef.ProcedureDefinition.ObjectDef.Name.ToUpperInvariant())
                //                    {
                //                        try{
                //                            SubActionProcedure firedSubactionProcedure= (SubActionProcedure)this._PatientAdmission.ObjectContext.CreateObject(rSubType.ChildObjectDef.Name.ToUpperInvariant());
                //                            //BindingList<TTObjectStateDef> subactionProcedureStates = (BindingList<TTObjectStateDef>)((ITTObject)firedSubactionProcedure).GetNextStateDefs();
                ////                            if (subactionProcedureStates.Count > 0)
                ////                                firedSubactionProcedure.CurrentStateDef = (TTObjectStateDef)subactionProcedureStates[0];
                ////                            firedSubactionProcedure.Amount=1;
                ////                            firedSubactionProcedure.ProcedureObject=RFAprosedureDef.ProcedureDefinition;
                ////                            firedSubactionProcedure.Episode=this._PatientAdmission.Episode;
                ////                            if( firedSubactionProcedure.ObjectDef.IsOfType(typeof(SubactionProcedureFlowable).Name.ToUpperInvariant())){
                ////                                ((SubactionProcedureFlowable)firedSubactionProcedure).MasterResource=(ResSection)((ReasonForAdmissionRelatedResources)(selectedItem.SubItems[1]).Tag).Resource;
                ////                            }
                ////                            firedAction.SubactionProcedures.Add(firedSubactionProcedure);
                //                        }
                //                        catch (System.Exception ex)// required hatası alırsa formu açsın.
                //                        {
                //                            throw new Exception(ex.ToString());
                //                        }
                //                    }
                //                }
                
                
                
                foreach(TTObjectRelationDef relationDef in procDef.ObjectDef.AllChildRelationDefs)
                {
                    if(relationDef.OverridesRelationDef != null)
                    {
                        if(relationDef.OverridesRelationDef.CodeName == "ProcedureObject")
                        {
                            SubActionProcedure externalSubactionProcedure= (SubActionProcedure)this._ttObject.ObjectContext.CreateObject(relationDef.ChildObjectDef.Name.ToUpperInvariant());
                            externalSubactionProcedure.EpisodeAction = this._ExternalProcedureRequest;
                            externalSubactionProcedure.ProcedureObject = procDef;
                            externalSubactionProcedure.Amount = 1;
                        }
                    }
                }
            }
        }
        
#endregion ExternalProcedureBaseForm_Methods
    }
}