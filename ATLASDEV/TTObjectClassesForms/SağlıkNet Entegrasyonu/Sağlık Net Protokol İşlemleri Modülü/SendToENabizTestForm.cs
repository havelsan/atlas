
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
    public partial class SendToENabizTestForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            getAndSend.Click += new TTControlEventDelegate(getAndSend_Click);
            send102.Click += new TTControlEventDelegate(send102_Click);
            send103.Click += new TTControlEventDelegate(send103_Click);
            send105.Click += new TTControlEventDelegate(send105_Click);
            send252.Click += new TTControlEventDelegate(send252_Click);
            send104.Click += new TTControlEventDelegate(send104_Click);
            send106.Click += new TTControlEventDelegate(send106_Click);
            send901.Click += new TTControlEventDelegate(send901_Click);
            Send_201.Click += new TTControlEventDelegate(Send_201_Click);
            testST101.Click += new TTControlEventDelegate(testST101_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            getAndSend.Click -= new TTControlEventDelegate(getAndSend_Click);
            send102.Click -= new TTControlEventDelegate(send102_Click);
            send103.Click -= new TTControlEventDelegate(send103_Click);
            send105.Click -= new TTControlEventDelegate(send105_Click);
            send252.Click -= new TTControlEventDelegate(send252_Click);
            send104.Click -= new TTControlEventDelegate(send104_Click);
            send106.Click -= new TTControlEventDelegate(send106_Click);
            send901.Click -= new TTControlEventDelegate(send901_Click);
            Send_201.Click -= new TTControlEventDelegate(Send_201_Click);
            testST101.Click -= new TTControlEventDelegate(testST101_Click);
            base.UnBindControlEvents();
        }

        private void getAndSend_Click()
        {
#region SendToENabizTestForm_getAndSend_Click
   // Scheduled Task olayına geçerirken Gönderilecek paket sayısı kontrolü silinecek.
            int i= 0;                                               //TODO: AAE - Silinecek
            
            System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSent(objectcontext,"101");
            DateTime dt = DateTime.Now;
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                ResponseOfENabiz roen;
                if(sendToBeIn.SubEpisode.Episode.Patient.IsTrusted.HasValue && sendToBeIn.SubEpisode.Episode.Patient.IsTrusted.Value)
                {
                    try
                    {
                        if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                        {                                               //TODO: AAE - Silinecek
                            if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                            {
                                ENabiz101_HastaKayit.SYSMessage sYSMessage = ENabiz101_HastaKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                                responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                                var xdoc = new XmlDocument();
                                xdoc.LoadXml(responce);
                                sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                                sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                                sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                                
                                if (sonucKodu.Equals("S0000") || sonucKodu.Equals("E2033"))
                                {
                                    if (sonucKodu.Equals("E2033"))
                                    {
                                        string[] temp = System.Text.RegularExpressions.Regex.Split(sonucMesaji, "SYSTakipNo=");
                                        string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp[1].ToString(), "\"");
                                        sysTakipNo = temp2[0];

                                    }
                                    sendToBeIn.SubEpisode.SYSTakipNo = sysTakipNo;

                                    sendToBeIn.Status = SendToENabizEnum.Successful;
                                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");

                                }
                                else
                                {
                                    sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                                }
                                sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                            }
                            else
                            {
                                sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                            }
                        }
                        else
                        {
                            break;
                        }
                        TimeSpan t = (DateTime.Now - dt);
                        addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                        dt = DateTime.Now;
                    }
                    catch(Exception ex)
                    {
                        sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                        roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL101", ex.Message);
                        //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                        TimeSpan t = (DateTime.Now - dt);
                        addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                        dt = DateTime.Now;
                    }
                }
                else
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL102","TC kimlik numarası KPS sisteminden doğrulanmadığı için gönderilmedi.(Patient.IsTrusted)");
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value,sendToBeIn.InternalObjectDefName,sendToBeIn.PackageCode,Input, "-",sysTakipNo,"TC kimlik numarası KPS sisteminden doğrulanmadığı için gönderilmedi.(Patient.IsTrusted)",t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_getAndSend_Click
        }

        private void send102_Click()
        {
#region SendToENabizTestForm_send102_Click
   System.Diagnostics.Debugger.Break();

            int i = 0;                                               //TODO: AAE - Silinecek
            
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"102");
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
             DateTime dt = DateTime.Now;
            ResponseOfENabiz roen;
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz102_HizmetIlacMalzemeBilgisiKayit.SYSMessage sYSMessage = ENabiz102_HizmetIlacMalzemeBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                              Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                              responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                              sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                              sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                              sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                            }
                            else
                            {
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                                sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                            }

                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL102", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_send102_Click
        }

        private void send103_Click()
        {
#region SendToENabizTestForm_send103_Click
   //System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"103");
            int i = 0;                                           //TODO: AAE - Silinecek
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            
            
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                { 
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz103_MuayeneBilgisiKayit.SYSMessage sYSMessage = ENabiz103_MuayeneBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                            }
                            else
                            {
                                sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                            }

                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                        
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL103", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;//TODO: AAE - Silinecek 
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_send103_Click
        }

        private void send105_Click()
        {
#region SendToENabizTestForm_send105_Click
   //System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"105");
            int i = 0;                                          //TODO: AAE - Silinecek
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            ResponseOfENabiz roen;
            
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        IList countOfSuccesPackage = SendToENabiz.GetCountOfSuccesPackage(objectcontextIn, sendToBeIn.InternalObjectID.Value,"102");

                        if (countOfSuccesPackage.Count > 0)
                        {
                            if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                            {
                                ENabiz105_LaboratuvarSonucKayit.SYSMessage sYSMessage = ENabiz105_LaboratuvarSonucKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                                responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                                var xdoc = new XmlDocument();
                                xdoc.LoadXml(responce);
                                sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                                sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                                sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                                
                                if (sonucKodu.Equals("S0000"))
                                {
                                    sendToBeIn.Status = SendToENabizEnum.Successful;
                                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                                }
                                else
                                {
                                    sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                                }

                                sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                            }
                            else
                            {
                                sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                            }
                        }
                        else
                        {
                            sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                            roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL1051", "Sonuçların gönderilebilmesi için ilk önce hizmet kaydı yapılmalıdır.");
                        }
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL105", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                    
                }
                i++;//TODO: AAE - Silinecek
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_send105_Click
        }

        private void send252_Click()
        {
#region SendToENabizTestForm_send252_Click
   System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"252");
            int i = 0;
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            
            
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz252_KonsultasyonKayit.SYSMessage sYSMessage = ENabiz252_KonsultasyonKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                            }
                            else
                            {
                               sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                               roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                            }

                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL252", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;//TODO: AAE - Silinecek
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_send252_Click
        }

        private void send104_Click()
        {
#region SendToENabizTestForm_send104_Click
   //System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"104");
            int i = 0;
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            
            
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                ResponseOfENabiz roen;
                try
                {
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz104_FaturaBilgisiKayit.SYSMessage sYSMessage = ENabiz104_FaturaBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                            }
                            else
                            {
                                sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                            }

                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL104", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;//TODO: AAE - Silinecek
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_send104_Click
        }

        private void send106_Click()
        {
#region SendToENabizTestForm_send106_Click
   //System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(false);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"106");
            int i = 0;
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                ResponseOfENabiz roen;
                try
                {
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz106_CikisBilgisiKayit.SYSMessage sYSMessage = ENabiz106_CikisBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                            }
                            else
                            {
                                sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                            }

                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL106", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;//TODO: AAE - Silinecek
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_send106_Click
        }

        private void send901_Click()
        {
#region SendToENabizTestForm_send901_Click
   //TODO: AAE - Silinecek
            
            System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(false);
            IList sendToBeList = SendToENabiz.GetToBeSent(objectcontext,"901");
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            
            if(sendToBeList.Count > 0)
            {
                foreach (SendToENabiz sendToBe in sendToBeList)
                {
                    ResponseOfENabiz roen;
                    Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                    try
                    {
                        if (!sentItems.ContainsKey(sendToBe.InternalObjectID.Value))
                        {
                            ENabiz901_YatakBilgisiKayit.SYSMessage sYSMessage = ENabiz901_YatakBilgisiKayit.Get(); //sendToBe.InternalObjectID.Value, sendToBe.InternalObjectDefName
                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            
                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBe.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontext, sendToBe, "", "");
                            }
                            else
                            {
                                sendToBe.Status = SendToENabizEnum.UnSuccessful;
                                roen = new ResponseOfENabiz(objectcontext, sendToBe, sonucKodu, sonucMesaji);
                            }
                        }
                        else
                        {
                            sendToBe.Status = sentItems[sendToBe.InternalObjectID.Value];
                        }
                        TimeSpan t = (DateTime.Now - dt);
                        addRowToGridview(sendToBe.InternalObjectID.Value,sendToBe.InternalObjectDefName,sendToBe.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                        dt = DateTime.Now;
                    }
                    catch(Exception ex)
                    {
                        sendToBe.Status = SendToENabizEnum.UnableToSent;
                        roen = new ResponseOfENabiz(objectcontext, sendToBe, "HVL901", ex.Message);
                        //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                        TimeSpan t = (DateTime.Now - dt);
                        addRowToGridview(sendToBe.InternalObjectID.Value,sendToBe.InternalObjectDefName,sendToBe.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                        dt = DateTime.Now;
                    }
                }
                objectcontext.Save();
                objectcontext.Dispose();
            }
#endregion SendToENabizTestForm_send901_Click
        }

        private void Send_201_Click()
        {
#region SendToENabizTestForm_Send_201_Click
   System.Diagnostics.Debugger.Break();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext,"201");
            int i = 0;
            
            string Input = "",sonucKodu = "",sonucMesaji = "",sysTakipNo = "",responce = "";
            DateTime dt = DateTime.Now;
            
            
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (i < Convert.ToInt32(packageCount.Text))     //TODO: AAE - Silinecek
                    {                                               //TODO: AAE - Silinecek

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz201_PatolojiKayit.SYSMessage sYSMessage = ENabiz201_PatolojiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                            
                            if (sonucKodu.Equals("S0000"))
                            {
                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");
                            }
                            else
                            {
                               sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                               roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                            }

                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        break;
                    }
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,"", t.TotalMilliseconds.ToString()  );
                    dt = DateTime.Now;
                }
                catch(Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL201", ex.Message);
                    //AddLog(ex.Message);           //BaseObject i değiştirildiğinde açılabilir.
                    TimeSpan t = (DateTime.Now - dt);
                    addRowToGridview(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.PackageCode,Input,sonucKodu +"-" + sonucMesaji,sysTakipNo,ex.Message,t.TotalMilliseconds.ToString() );
                    dt = DateTime.Now;
                }
                i++;//TODO: AAE - Silinecek
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
#endregion SendToENabizTestForm_Send_201_Click
        }

        private void testST101_Click()
        {
#region SendToENabizTestForm_testST101_Click
   try
            {
//                System.Diagnostics.Debugger.Break();
//                TTObjectContext ctx = new TTObjectContext(false);
//                ENABIZSend101 e101 = null;
//                var olist = ctx.QueryObjects("ENABIZSend101");
//                if (olist.Count==0)
//                {
//                    e101 = new ENABIZSend101(ctx);
//                    e101.Active=true;
//                    e101.TaskName="e101";
//                    ctx.Save();
//                }
//                else
//                {
//                    e101 = (ENABIZSend101)olist[0];
//                }
//                e101.TaskScript();
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex.ToString());
            }
#endregion SendToENabizTestForm_testST101_Click
        }

#region SendToENabizTestForm_Methods
        public void addRowToGridview(Guid oID,string odefName,string pc,string sXML,string rXML,string sys,string ex,string tTime)
        {            
            ITTGridRow row = resultGrid.Rows.Add();
            row.Cells[0].Value = oID;
            row.Cells[1].Value = odefName;
            row.Cells[2].Value = pc;
            row.Cells[3].Value = sXML;
            row.Cells[4].Value = rXML;
            row.Cells[5].Value = sys;
            row.Cells[6].Value = ex; 
            row.Cells[7].Value = tTime; 
        }
        
#endregion SendToENabizTestForm_Methods
    }
}