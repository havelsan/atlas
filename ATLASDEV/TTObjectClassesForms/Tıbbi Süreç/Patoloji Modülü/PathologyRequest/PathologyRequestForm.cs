
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
    /// Patoloji Tetkik İstek Formu
    /// </summary>
    public partial class PathologyRequestForm : EpisodeActionForm
    {
        //TODO ASLI
        override protected void BindControlEvents()
        {
            //btnSelectTemplate.Click += new TTControlEventDelegate(btnSelectTemplate_Click);
            //GridPathologyTests.CellValueChanged += new TTGridCellEventDelegate(GridPathologyTests_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //btnSelectTemplate.Click -= new TTControlEventDelegate(btnSelectTemplate_Click);
            //GridPathologyTests.CellValueChanged -= new TTGridCellEventDelegate(GridPathologyTests_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void btnSelectTemplate_Click()
        {
#region PathologyRequestForm_btnSelectTemplate_Click
   TTObjectContext objectContext = new TTObjectContext(true);
            IList templates = objectContext.QueryObjects("PATHOLOGYACCEPTTEMPLATEDEFINITION");
            MultiSelectForm pForm = new MultiSelectForm();
            foreach(PathologyAcceptTemplateDefinition template in templates)
                pForm.AddMSItem(template.Name, template.ObjectID.ToString(),template);

            string sKey = pForm.GetMSItem(this, "Patoloji paketi seçiniz.",false,false,false,false,true,false);
            if(!String.IsNullOrEmpty(sKey))
            {
                PathologyAcceptTemplateDefinition selectedTemplate = (PathologyAcceptTemplateDefinition)pForm.MSSelectedItemObject;
                foreach(PathologyAcceptTemplateDetail detail in selectedTemplate.PathologyAcceptTemplateDetails)
                {
                    
                    AddTestsFromSelectedTemplate(detail, this._PathologyRequest);
                }
            }
#endregion PathologyRequestForm_btnSelectTemplate_Click
        }

        private void GridPathologyTests_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PathologyRequestForm_GridPathologyTests_CellValueChanged
 /*  if (columnIndex == 1)
            {
                
                if (GridPathologyTests.Rows[rowIndex].Cells[1].Value != null)
                {
                    PathologyTestDefinition testDef = (PathologyTestDefinition)PathologyTestDefinition.GetByObjectID(this._PathologyRequest.ObjectContext, GridPathologyTests.Rows[rowIndex].Cells[1].Value.ToString())[0];
                if (testDef.TestCategory != null)
                    GridPathologyTests.Rows[rowIndex].Cells["TestCategory"].Value = testDef.TestCategory.ObjectID;
            }
            }
            
            PathologyTestCategoryDefinition testCatDef;
            if(columnIndex == 0)
            {
                if(GridPathologyTests.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    Guid objId = new Guid(GridPathologyTests.Rows[rowIndex].Cells[columnIndex].Value.ToString());
                    testCatDef = (PathologyTestCategoryDefinition)this._PathologyRequest.ObjectContext.GetObject(objId, "PATHOLOGYTESTCATEGORYDEFINITION");
                    
                    switch (testCatDef.Name)
                    {
                        case "Sitoloji":
                            break;
                        case "Konsultasyon":
                            break;
                        case "Otopsi":
                            break;
                        case "Biyopsi":
                            break;
                    }
                }
            }
            */
#endregion PathologyRequestForm_GridPathologyTests_CellValueChanged
        }

        protected override void PreScript()
        {
#region PathologyRequestForm_PreScript
    base.PreScript();
#endregion PathologyRequestForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region PathologyRequestForm_ClientSidePreScript
    base.ClientSidePreScript();
            
          
            this.REQUESTDOCTOR.Enabled = true;
            this.REQUESTDOCTOR.ReadOnly = false;
            this._PathologyRequest.RequestDoctor = Common.CurrentResource;
            
            
#endregion PathologyRequestForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PathologyRequestForm_PostScript
    base.PostScript(transDef);
            
           
            if (this.REQUESTDOCTOR == null || this.REQUESTDOCTOR.SelectedObject == null)
                throw new TTUtils.TTException("İstek yapan tabip bilgisini giriniz!");

            System.DateTime actionDate = DateTime.Parse(this.ActionDate.Text);

            foreach ( PathologyMaterial material in  this._PathologyRequest.PathologyMaterials)
            {
                System.DateTime materialDate = Convert.ToDateTime(material.DateOfSampleTaken);
                int comparisonResult = DateTime.Compare(materialDate, actionDate);
                if (comparisonResult > 0 || comparisonResult == 0)
                    throw new TTUtils.TTException("'Numunenin Alındığı Tarih' 'İstek Tarihi''nden önceki bir tarih olmalıdır!");
            }
         
            if (this._PathologyRequest.RequestMaterialNumber.Value == null)
            {
                this._PathologyRequest.RequestMaterialNumber.GetNextValue();
              
            }

                #endregion PathologyRequestForm_PostScript

            }
            
#region PathologyRequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
           

            int count = 1;
            for (int i = 0; i < this._PathologyRequest.PathologyMaterials.Count; i++)
            {
                this._PathologyRequest.PathologyMaterials[i].MaterialNumber = this._PathologyRequest.RequestMaterialNumber.Value.ToString() + "-" + count.ToString();
                count++;
            }
            this._PathologyRequest.ObjectContext.Save();
            //foreach (Pathology pt in this._PathologyRequest.Pathologies)
            //{
            //    if(pt.CurrentStateDefID == Pathology.States.Request)
            //    {
            //        PathologyTestDefinition testDef = (PathologyTestDefinition)pt.ProcedureObject;

            //        this.Update();
            //        pt.CurrentStateDefID = testDef.RequestApprove == true
            //            ? Pathology.States.RequestApprovement
            //            : Pathology.States.RequestAcception;
            //    }
            //    this._PathologyRequest.ObjectContext.Save();
            //}
            //base.AfterContextSavedScript(transDef);
        }
        
        public void AddTestsFromSelectedTemplate(PathologyAcceptTemplateDetail detail, PathologyRequest pathology)
        {
            //Pathology test = new Pathology(this._PathologyRequest.ObjectContext);
            //PathologyTestDefinition pathologyTestDef = (PathologyTestDefinition)detail.PathologyTestDefinition;
            //test.ProcedureObject = pathologyTestDef;
            ////test.EpisodeAction = this._EpisodeAction;
            //test.Amount = detail.Amount;
            //test.Eligible = true; // Fatura'ya düşmez.
            //pathology.Pathologies.Add(test);
        }
        
#endregion PathologyRequestForm_Methods
    }
}