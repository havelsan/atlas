
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
    /// Basic Comm Test Form
    /// </summary>
    public partial class BasicCommTestForm : TTUnboundForm
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
#region BasicCommTestForm_ttbutton3_Click
   TTMessage msg = TTMessageFactory.GetMessage(new Guid(result2.Text));
            if (msg.MessageStatus == TTMessageStatusEnum.Completed)
            {
                result3.Text = msg.ReturnValue.ToString();
            }
            else if (((int)msg.MessageStatus)<0)
            {
                InfoBox.Show("Bir sorun oluşmuş.\r\n");
            }
            else
            {
                InfoBox.Show("Mesaj daha işlenmemiş");
            }
            
            msg = TTMessageFactory.GetMessage(new Guid((string)result2.Tag));
            if (msg.MessageStatus == TTMessageStatusEnum.Completed)
            {
                InfoBox.Show(msg.ReturnValue.ToString());
            }
            else if (((int)msg.MessageStatus)<0)
            {
                InfoBox.Show("Bir sorun oluşmuş.\r\n");
            }
            else
            {
                InfoBox.Show("Mesaj daha işlenmemiş");
            }
#endregion BasicCommTestForm_ttbutton3_Click
        }

        private void ttbutton2_Click()
        {
#region BasicCommTestForm_ttbutton2_Click
   try
            {
                int carpan1 = Convert.ToInt32(field1.Text);
                int carpan2 = Convert.ToInt32(field2.Text);
                //TTMessage msg = Common.RemoteMethods.Carp_ASync(Sites.SiteLocalHost ,carpan1,carpan2);
                //result2.Text =  msg.MessageID.ToString();
                
 
                ///////
                
                List<TTObject> tlist = new List<TTObject>();

                TTObjectContext o = new TTObjectContext(false);
                RemoteTest p = (RemoteTest) o.CreateObject("RemoteTest");
                p.i = 1;
                p.j = 2;
                tlist.Add(p);
                
                Sites s = (Sites) o.CreateObject("Sites");
                s.Name = "alo";
                s.IP = "2.0.0.0";
                tlist.Add(s);

                p = (RemoteTest) o.CreateObject("RemoteTest");
                p.i = 3;
                p.j = 4;
                tlist.Add(p);
                
                s = (Sites) o.CreateObject("Sites");
                s.Name = "alo2";
                s.IP = "0.3.0.1";
                tlist.Add(s);

                //msg = RemoteTest.RemoteMethods.TTObjectListTestAsync(new Guid("f0a6bd14-1de2-4a7e-bdd2-cd23658f88f5"),tlist);
                //result2.Tag =  msg.MessageID.ToString();
                
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex.ToString());
            }
#endregion BasicCommTestForm_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region BasicCommTestForm_ttbutton1_Click
   try
            {
                int carpan1 = Convert.ToInt32(field1.Text);
                int carpan2 = Convert.ToInt32(field2.Text);
                //int result = Common.RemoteMethods.Carp2(new Guid("f0a6bd14-1de2-4a7e-bdd2-cd23658f88f5"),carpan1,carpan2);
                //result1.Text = result.ToString();
                
                
                /////////////////////
                
                List<TTObject> tlist = new List<TTObject>();

                TTObjectContext o = new TTObjectContext(false);
                RemoteTest p = (RemoteTest) o.CreateObject("RemoteTest");
                p.i = 1;
                p.j = 2;
                tlist.Add(p);
                
                Sites s = (Sites) o.CreateObject("Sites");
                s.Name = "alo";
                s.IP = "0.0.0.0";
                tlist.Add(s);

                p = (RemoteTest) o.CreateObject("RemoteTest");
                p.i = 3;
                p.j = 4;
                tlist.Add(p);
                
                s = (Sites) o.CreateObject("Sites");
                s.Name = "alo2";
                s.IP = "0.0.0.1";
                tlist.Add(s);

                
                //RemoteTest.RemoteMethods.TTObjectListTest(new Guid("f0a6bd14-1de2-4a7e-bdd2-cd23658f88f5"),tlist);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex.ToString());
            }
#endregion BasicCommTestForm_ttbutton1_Click
        }

#region BasicCommTestForm_Methods
        protected override void OnShown(EventArgs e)
        {
            try
            {
                InitializeSmartCard();
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);   
            }
        }
        
        protected override void SmartCardInserted(string readerName)
        {
            //KimlikBilgileri k = SmartCard.ReadSmartCardData(readerName);
            string rawData = SmartCard.ReadSmartCardRawData(readerName);
            KimlikBilgileri k = SmartCard.GetKimlikBilgileri(rawData);
            InfoBox.Show(k.Adi + " " + k.Soyadi +" için XML veri \r\n\r\n"+rawData);
        }
        
        protected override void SmartCardEjected(string readerName)
        {
            InfoBox.Show(readerName + "'deki kart çıkarıldı.");
        }
        
#endregion BasicCommTestForm_Methods
    }
}