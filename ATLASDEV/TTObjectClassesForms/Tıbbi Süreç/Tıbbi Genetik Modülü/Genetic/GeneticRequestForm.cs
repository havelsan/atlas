
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
    /// Tıbbi Genetik Tetkik İstek Formu
    /// </summary>
    public partial class GeneticRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            TestToStudyTTListBox.SelectedObjectChanged += new TTControlEventDelegate(TestToStudyTTListBox_SelectedObjectChanged);
            cmdPrintBarcode.Click += new TTControlEventDelegate(cmdPrintBarcode_Click);
            btnSelectTemplate.Click += new TTControlEventDelegate(btnSelectTemplate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TestToStudyTTListBox.SelectedObjectChanged -= new TTControlEventDelegate(TestToStudyTTListBox_SelectedObjectChanged);
            cmdPrintBarcode.Click -= new TTControlEventDelegate(cmdPrintBarcode_Click);
            btnSelectTemplate.Click -= new TTControlEventDelegate(btnSelectTemplate_Click);
            base.UnBindControlEvents();
        }

        private void TestToStudyTTListBox_SelectedObjectChanged()
        {
#region GeneticRequestForm_TestToStudyTTListBox_SelectedObjectChanged
   GeneticTest gt = new GeneticTest(_Genetic.ObjectContext);
            GeneticTestDefinition testDef = (GeneticTestDefinition)this.TestToStudyTTListBox.SelectedObject;
            gt.ProcedureObject = testDef;
            gt.Genetic = this._Genetic;
#endregion GeneticRequestForm_TestToStudyTTListBox_SelectedObjectChanged
        }

        private void cmdPrintBarcode_Click()
        {
            /*
#region GeneticRequestForm_cmdPrintBarcode_Click
   if(this._Genetic.GeneticSampleNo.Value != null)
                Genetic.PrintGeneticBarcode(this._Genetic);
            else
                TTVisual.InfoBox.Show("Barkod basmak için önce Kaydet(F12) yapılmalıdır!",MessageIconEnum.WarningMessage);
#endregion GeneticRequestForm_cmdPrintBarcode_Click */
        }

        private void btnSelectTemplate_Click()
        {
#region GeneticRequestForm_btnSelectTemplate_Click
   TTObjectContext objectContext = new TTObjectContext(true);
            IList templates = objectContext.QueryObjects("GENETICACCEPTTEMPLATEDEFINITION");
            MultiSelectForm pForm = new MultiSelectForm();
            foreach(GeneticAcceptTemplateDefinition template in templates)
                pForm.AddMSItem(template.Name, template.ObjectID.ToString(),template);

            string sKey = pForm.GetMSItem(this, "Tıbbi Genetik paketi seçiniz.",false,false,false,false,true,false);
            if(!String.IsNullOrEmpty(sKey))
            {
                GeneticAcceptTemplateDefinition selectedTemplate = (GeneticAcceptTemplateDefinition)pForm.MSSelectedItemObject;
                foreach(GeneticAcceptTemplateDetail detail in selectedTemplate.GeneticAcceptTemplateDetails)
                {
                    
                    AddTestsFromSelectedTemplate(detail, this._Genetic);
                    
                    /*
                    foreach(TabPage page in this.TabGridConrol.TabPages)
                    {
                        foreach(Control control in page.Controls)
                        {
                            if(control is ListView)
                            {
                                ListView lv = (ListView)control;
                                foreach(ListViewItem otherTest in lv.Items){
                                    RadiologyTestDefinition radReqTestDef = (RadiologyTestDefinition)objectContext.GetObject(new Guid(otherTest.Tag.ToString()), "RadiologyTestDefinition");
                                    if(!otherTest.Checked && (detail.RadiologyTestDefinition.ObjectID == radReqTestDef.ObjectID)){
                                        otherTest.Checked = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    */
                }
            }
#endregion GeneticRequestForm_btnSelectTemplate_Click
        }

        protected override void PreScript()
        {
#region GeneticRequestForm_PreScript
    base.PreScript();
           
            /* Çoklu istek haline getirilince sil 
            GeneticTestDefinition genTestDef = ((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject as GeneticTestDefinition;
            if(genTestDef != null)this.TestToStudyTTListBox.SelectedObject = genTestDef;
            */
           
            RequestedDoctor.SelectedObject = Common.CurrentUser.UserObject;
            _Genetic.PatientAge = _Genetic.Episode.Patient.Age;
            EmergencyCheckBox.Value = false;
#endregion GeneticRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GeneticRequestForm_PostScript
    base.PostScript(transDef);
            
            foreach(GeneticTest test in this._Genetic.GeneticTests)
            {
                GeneticTestDefinition genTestDef = test.ProcedureObject as GeneticTestDefinition;
                if(genTestDef != null)
                {
                    //this.TestToStudyTTListBox.SelectedObject = genTestDef;
                    foreach(GeneticGridMaterialDefinition geneticMaterial in genTestDef.GeneticGridMaterialDefinitions)
                    {
                        BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(this._Genetic.ObjectContext);
                        newMaterial.Material = geneticMaterial.Material;
                        newMaterial.EpisodeAction = this._Genetic;
                    }
                    foreach(GeneticGridEquipmentDefinition equipmentDef in genTestDef.Equipment)
                    {
                        GeneticEquipment myEquipment = new GeneticEquipment(_Genetic.ObjectContext);
                        myEquipment.Equipment = (ResGeneticEqiupmentDef)equipmentDef.MyEquipment;
                        this._Genetic.UsedEquipments.Add(myEquipment);
                    }
                }
            }
            /*
            if( this._Genetic.GeneticTests.Count > 0 )
            {
                GeneticTestDefinition genTestDef = ((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject as GeneticTestDefinition;
                if(genTestDef != null)
                {
                    this.TestToStudyTTListBox.SelectedObject = genTestDef;
                    foreach(GeneticGridMaterialDefinition geneticMaterial in genTestDef.GeneticGridMaterialDefinitions)
                    {
                        BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(this._Genetic.ObjectContext);
                        newMaterial.Material = geneticMaterial.Material;
                        newMaterial.EpisodeAction = this._Genetic;
                    }
                    foreach(GeneticGridEquipmentDefinition equipmentDef in genTestDef.Equipment)
                    {
                        GeneticEquipment myEquipment = new GeneticEquipment(_Genetic.ObjectContext);
                        myEquipment.Equipment = (ResGeneticEqiupmentDef)equipmentDef.MyEquipment;
                        this._Genetic.UsedEquipments.Add(myEquipment);
                    }
                }
            }
             */
            if(!this._Genetic.GeneticSampleNo.Value.HasValue)
                this._Genetic.GeneticSampleNo.GetNextValue();
#endregion GeneticRequestForm_PostScript

            }
            
#region GeneticRequestForm_Methods
        public void AddTestsFromSelectedTemplate(GeneticAcceptTemplateDetail detail, Genetic genetic)
        {
            GeneticTest test = new GeneticTest(this._Genetic.ObjectContext);
            GeneticTestDefinition geneticTestDef = (GeneticTestDefinition)detail.GeneticTestDefinition;
            test.ProcedureObject = geneticTestDef;
            //test.EpisodeAction = this._EpisodeAction;
            test.Amount = detail.Amount;
            test.Eligible = true; // Fatura'ya düşmez.
            genetic.GeneticTests.Add(test);
        }
        
#endregion GeneticRequestForm_Methods
    }
}