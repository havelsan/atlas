
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
    public partial class ProcedureRequestNewForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region ProcedureRequestNewForm_ttbutton1_Click
   this.GenerateForms();
            //ASLI
#endregion ProcedureRequestNewForm_ttbutton1_Click
        }

#region ProcedureRequestNewForm_Methods
        private void BoundedTestController(object sender, ItemCheckEventArgs e)
        {
          
            ListView lv = sender as ListView;
            ListViewItem selectedTest = (ListViewItem)lv.Items[e.Index];
            Guid objId = (Guid)selectedTest.Tag;
            TTObjectContext thisContext = new TTObjectContext(true);

            ProcedureDefinition testDef = null;

            testDef = (ProcedureDefinition)thisContext.GetObject(objId, "ProcedureDefinition"); 
             
            if(testDef is LaboratoryTestDefinition)  //Sadece Lab işlemlerinde bağlı test oldugu için 
            {
                LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)testDef;

                if (labTestDef.IsBoundedTest == true) { 
                    string _message = "";
                    bool _goOn = false;
                    //Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        foreach (LaboratoryGridBoundedTestDefinition testBounded in labTestDef.BoundedTests)
                        {
                            foreach (ListViewItem otherTest in lv.Items)
                            {
                                LaboratoryTestDefinition otherTestDef = (LaboratoryTestDefinition)thisContext.GetObject(new Guid(otherTest.Tag.ToString()), "LaboratoryTestDefinition");

                                if (e.NewValue == CheckState.Unchecked)
                                {
                                    if (otherTest.Checked && (testBounded.LaboratoryTest.ObjectID == otherTestDef.ObjectID))
                                    {
                                        _message += labTestDef.Name.ToString() + " testi, " + testBounded.LaboratoryTest.Name.ToString() + " testi ile birlikte istendiği için bağımlı tetkik isteğinden vazgeçildi. \r\n";
                                        otherTest.Checked = false;
                                        break;
                                    }
                                }
                                else
                                {

                                    if (!otherTest.Checked && (testBounded.LaboratoryTest.ObjectID == otherTestDef.ObjectID))
                                    {
                                        _message += labTestDef.Name.ToString() + " testi, " + testBounded.LaboratoryTest.Name.ToString() + " testi ile birlikte istenmelidir. İstek olarak işaretlendi. \r\n";
                                        otherTest.Checked = true;
                                        break;
                                    }
                                }
                            }
                        }
                        _goOn = true;
                        InfoBox.Show(_message);
                    }
                    catch (Exception ex)
                    {
                        InfoBox.Show(ex.ToString());
                    }
                    finally
                    {
                      //  Cursor.Current = Cursors.Default;
                    }
                
                }
            }
            
        
            
        }
        
#endregion ProcedureRequestNewForm_Methods
    }
}