
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
    /// Radyoloji Tetkik Tanımları
    /// </summary>
    public partial class RadiologyTestDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            ttobjectlistbox3.SelectedObjectChanged += new TTControlEventDelegate(ttobjectlistbox3_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttobjectlistbox3.SelectedObjectChanged -= new TTControlEventDelegate(ttobjectlistbox3_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void ttobjectlistbox3_SelectedObjectChanged()
        {
#region RadiologyTestDefinitionForm_ttobjectlistbox3_SelectedObjectChanged
   //            if (((TTListBox) this.ttobjectlistbox3).SelectedObject != null)
//            {
//                IList RadTestList = RadiologyTestDefinition.GetByTMRadTest(_RadiologyTestDefinition.ObjectContext, ((TTListBox) this.ttobjectlistbox3).SelectedObject.ObjectID.ToString()  );
//                if ( RadTestList.Count > 1 )
//                {
//                    
//                    //((TTListBox) this.Equipment).SelectedObject
//                    
//                    
//                    MessageBox.Show(  "Bu TM Radyoloji testi daha önce kaydedilmiştir..  " );
//                    this.ttobjectlistbox3.SelectedValue = null;
//                    
//                }
//                
//                else
//                {
//                    
//                    
//                    
//                }
//                
//            }
#endregion RadiologyTestDefinitionForm_ttobjectlistbox3_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region RadiologyTestDefinitionForm_PreScript
    base.PreScript();
#endregion RadiologyTestDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestDefinitionForm_PostScript
    Dictionary<String,Object> dictionary = new Dictionary<String,Object>();

                // Aynı Bölüm Kontrolü
                for (int i = 0; i < _RadiologyTestDefinition.Departments.Count; i++)
                {
                    String Code = _RadiologyTestDefinition.Departments[i].Department.Name.ToString();
                    if(dictionary.ContainsKey(Code))
                    {
                        throw new Exception("Aynı Bölüm eklenmiş!");
                    }
                    else
                    {
                        dictionary.Add(Code,_ttObject);
                    }
                }

                dictionary.Clear();
                
                // Aynı Cihaz Kontrolü
                for (int i = 0; i < _RadiologyTestDefinition.Equipments.Count; i++)
                {
                    String Code = _RadiologyTestDefinition.Equipments[i].Equipment.Name.ToString();
                    if(dictionary.ContainsKey(Code))
                    {
                        throw new Exception("Aynı Cihaz eklenmiş!");
                    }
                    else
                    {
                        dictionary.Add(Code,_ttObject);
                    }
                }
                
                dictionary.Clear();
                
                //Material class ında code alanı kullanılmadığı için commentlendi
                
                // Aynı Malzeme Kontrolü
//                for (int i = 0; i < _RadiologyTestDefinition.Materials.Count; i++)
//                {
//                    String Code = _RadiologyTestDefinition.Materials[i].Material.Code;
//                    if(dictionary.ContainsKey(Code))
//                    {
//                        throw new Exception("Aynı Malzemeden eklenmiş!");
//                    }
//                    else
//                    {
//                        dictionary.Add(Code,_ttObject);
//                    }
//                }
                
                
                if(!this._RadiologyTestDefinition.TestID.Value.HasValue)
                    this._RadiologyTestDefinition.TestID.GetNextValue();
                
                //if((bool)_RadiologyTestDefinition.IsActive) {_RadiologyTestDefinition.DeparmentControl();}
                
                //_RadiologyTestDefinition.LocationArrange();
#endregion RadiologyTestDefinitionForm_PostScript

            }
                }
}