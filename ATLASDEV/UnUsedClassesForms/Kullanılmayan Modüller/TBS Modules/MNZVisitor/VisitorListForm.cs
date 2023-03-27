
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
    /// Ziyaretçi Listesi
    /// </summary>
    public partial class VisitorListForm : TTForm
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
#region VisitorListForm_PreScript
    Console.WriteLine("Buranın visitor list form açılmadan çalışması lazim  :)");
            this.fillVisitorListGrid();
#endregion VisitorListForm_PreScript

            }
            
#region VisitorListForm_Methods
        public void fillVisitorListGrid()
        {
            IList v_list;
            int i = 0;
            Console.WriteLine("Gridi dolduracak fonksiyon çalışıyor!");
            v_list = this._MNZVisitor.getVisitorList();
            foreach(MNZVisitor v in v_list)
            {
                Console.WriteLine(v.Name); 
                this.NewGrid.ReadValueFromObject(v);
            }
            
        }
        
#endregion VisitorListForm_Methods
    }
}