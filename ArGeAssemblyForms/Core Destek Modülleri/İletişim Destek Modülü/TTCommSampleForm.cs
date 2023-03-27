
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
    /// TT Communication Sample Form
    /// </summary>
    public partial class TTCommSampleForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton3_Click()
        {
#region TTCommSampleForm_ttbutton3_Click
   Object o = TTMessageFactory.SyncCall(Sites.SiteLocalHost,"ilyas","ozge","nida","burcu","diren","filiz",3);
            yilmaz y = (yilmaz) o;
            InfoBox.Show(y.sonucnotu);
            System.Diagnostics.Debugger.Break();
#endregion TTCommSampleForm_ttbutton3_Click
        }

        private void ttbutton2_Click()
        {
#region TTCommSampleForm_ttbutton2_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            
            List<Patient> pList = new List<Patient>();
            
            Patient p = new Patient(objectContext);
            p.Name = "Diren1";
            p.Surname = "Düzgünoğlu1";
            p.BirthDate = DateTime.Now.AddYears(-32);
          //  p.Sex = SexEnum.Male;
            pList.Add(p);

            p = new Patient(objectContext);
            p.Name = "Diren2";
            p.Surname = "Düzgünoğlu2";
            p.BirthDate = DateTime.Now.AddYears(-32);
          //  p.Sex = SexEnum.Male;
            pList.Add(p);
            
            Type t = typeof(List<Patient>);

            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(t);
            System.IO.StringWriter sw = new System.IO.StringWriter();
            ser.Serialize(sw, pList);
            sw.Close();
            string xml = sw.ToString();

            System.Xml.Serialization.XmlSerializer deser = new System.Xml.Serialization.XmlSerializer(t);
            System.IO.StringReader s = new System.IO.StringReader(xml);
            System.Diagnostics.Debugger.Break();
            object yeni = deser.Deserialize(s);
            s.Close();
#endregion TTCommSampleForm_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region TTCommSampleForm_ttbutton1_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            
            List<Patient> pList = new List<Patient>();
            
            Patient p = new Patient(objectContext);
            p.Name = "Diren1";
            p.Surname = "Düzgünoğlu1";
            p.BirthDate = DateTime.Now.AddYears(-32);
           // p.Sex = SexEnum.Male;
            pList.Add(p);

            p = new Patient(objectContext);
            p.Name = "Diren2";
            p.Surname = "Düzgünoğlu2";
            p.BirthDate = DateTime.Now.AddYears(-32);
           // p.Sex = SexEnum.Male;
            pList.Add(p);
            
            //Patient.RemoteMethods.SendPatient(new Guid("f0a6bd14-1de2-4a7e-bdd2-cd23658f88f5"),pList);
#endregion TTCommSampleForm_ttbutton1_Click
        }

#region TTCommSampleForm_Methods
        [Serializable]
        public class ihsan
        {
            public string alo;
            public int velo;
        }
        
   public class yilmaz
    {
        public string sonucnotu;
        public int sonuc;
    }
        
#endregion TTCommSampleForm_Methods
    }
}