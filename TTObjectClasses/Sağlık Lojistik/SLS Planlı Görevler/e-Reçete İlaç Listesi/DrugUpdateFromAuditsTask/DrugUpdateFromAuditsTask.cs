
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



using TTStorageManager;
using System.Runtime.Versioning;


using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Threading;

namespace TTObjectClasses
{
    public  partial class DrugUpdateFromAuditsTask : BaseScheduledTask
    {
        public override void TaskScript()
        {
            TTObjectContext context = new TTObjectContext(false);
            TTObjectContext objectContextReadOnly = new TTObjectContext(true);
            List<ResUser> toUsers = new List<ResUser>();

            string resultMessage = string.Empty;
            string UpdateEdilenler = string.Empty;
            string UpdateEdilemeyenler = string.Empty;
            SOSFarmaXXXXXX sos = new SOSFarmaXXXXXX(objectContextReadOnly);

            resultMessage = sos.FetchSOSFarma(resultMessage);

              ///VademecumIDGüncelleme
            IList urunler = objectContextReadOnly.QueryObjects("DRUGDEFINITION", "VADEMECUMPRODUCTID IS NULL AND BARCODE IS NOT NULL AND ISACTIVE = 1");

            string barcodes_Param = string.Empty;
            int counter = 0;
            int mainCounter = 0;

            foreach (DrugDefinition drugDefItem in urunler)
            {
                barcodes_Param += drugDefItem.Barcode;

                string barcodeTemp = drugDefItem.Barcode;


                if (counter != 29 && mainCounter != urunler.Count-1 )
                {
                    barcodes_Param += ",";
                    counter++;
                }
                else
                {
                    TTObjectClasses.VademecumOnline.AllProductSearch_Response ProductList_Response = null;
                    string responseContent = Get_ProductIDByBarcode(barcodes_Param).Content;

                    if (responseContent.Contains('<') || responseContent.Contains('>')) //Geri dönen HTML response işime yaramaz! %99 ihtimalle Authorization hatasıdır!
                    {
                        barcodes_Param = string.Empty;
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        ProductList_Response = JsonConvert.DeserializeObject<TTObjectClasses.VademecumOnline.AllProductSearch_Response>(responseContent);

                        if (ProductList_Response.Data != null && ProductList_Response.Data.Length != 0)
                        {
                            foreach (TTObjectClasses.VademecumOnline.AllProductSearch_Datum datum in ProductList_Response.Data)
                            {
                                TTObjectContext context_Temp_ReadOnly = new TTObjectContext(true);
                                TTObjectContext context_Temp = new TTObjectContext(false);

                                var drugDefToUpdate_List = context_Temp_ReadOnly.QueryObjects("DRUGDEFINITION", "BARCODE = '" + datum.Barcode + "'");

                                if (drugDefToUpdate_List != null && drugDefToUpdate_List.Count == 1)
                                {
                                    DrugDefinition drugDefToUpdate = (DrugDefinition)context_Temp.GetObject(((DrugDefinition)drugDefToUpdate_List[0]).ObjectID, typeof(DrugDefinition));
                                    if (drugDefToUpdate != null)
                                    {

                                        drugDefToUpdate.VademecumProductID = ((TTObjectClasses.VademecumOnline.AllProductSearch_Datum)datum).Id;
                                        context_Temp.Save();
                                        

                                        /*********Bu bölümde out of memory Exception oluşuyor nasıl olacak düşünmek lazım!***********/
                                        //UpdateEdilenler += UpdateEdilenler + "\r\n " + drugDefToUpdate.Barcode + "-" + drugDefToUpdate.Name + " ilacın VademecumProductID'si güncellendi.";

                                    }
                                }

                                context_Temp_ReadOnly.Dispose();
                                context_Temp.Dispose();
                            }
                        }

                        barcodes_Param = string.Empty;
                        counter = 0;
                    }
                }

                mainCounter++;
            }

            //resultMessage += resultMessage + "\r\n" + "VademecumProductID'si Güncellenen İlaçlar" + "\r\n" + UpdateEdilenler;

            foreach (DrugUpdateTaskUser taskUser in TaskUsers)
            {
                UserMessage newMessage = new UserMessage(context);
                newMessage.InitializeSentMessage();
                newMessage.ToUser = taskUser.User;
                newMessage.Subject = TTUtils.CultureService.GetText("M25752", "Güncellenen İlaçlar Bildirimi");
                newMessage.MessageBody = resultMessage;
                newMessage.IsSystemMessage = true;
                newMessage.IsSplashMessage = false;
                newMessage.MessageFeedback = true;
            }

            context.Save();
            context.Dispose();

            if (!String.IsNullOrEmpty(resultMessage))
            {
                AddLog(resultMessage);
            }

            objectContextReadOnly.Dispose();

        }

       

        public override void AddLog(string log)
        {
            base.AddLog(log);
        }

        private IRestResponse Get_ProductIDByBarcode(string DrugDefBarcode)
        {

            TTObjectContext context = new TTObjectContext(false);
            IBindingList tokenParameter = context.QueryObjects("SYSTEMPARAMETER", "NAME='VADEMECUMTOKEN'");
            string tokenTxt = string.Empty;
            TTObjectClasses.SystemParameter tp = null;
            if (tokenParameter.Count > 0)
            {
                tp = (TTObjectClasses.SystemParameter)tokenParameter[0];
                tokenTxt = tp.Value;
            }

            string BaseUrl = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMURL", "http://xxxxxx.com");
            string url = BaseUrl+"/v1/products/search?barcodes=" + DrugDefBarcode;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
            request.AddHeader("Authorization", "Basic " + tokenTxt);

            Thread.Sleep(2500);

            IRestResponse response = client.Execute(request);

            Thread.Sleep(2500);

            int counter = 0;
            while (response.Content.Contains("\"code\":0,\"status\":429") == true || response.Content.Contains("Authorization Required") == true)
            {
                Thread.Sleep(2500);

                response = client.Execute(request);
                counter++;
                
                if (counter == 10)
                {
                    counter = 0;
                    break;
                }
            }

            if (response.Content.Contains("\"code\":9001"))
            {
                var authResult = GetAuthToken();
                tp.Value = authResult.data.Base64Token;
                context.Save();

                RestClient sclient = new RestClient(url);
                RestRequest srequest = new RestRequest(Method.GET);

                srequest.RequestFormat = DataFormat.Json;
                srequest.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
                srequest.AddHeader("Authorization", "Basic " + tp.Value);

                IRestResponse sresponse = sclient.Execute(srequest);

                context.Dispose();

                return sresponse;
            }

            context.Dispose();

            return response;

        }

        private TTObjectClasses.VademecumOnline.AuthResult GetAuthToken()
        {
            string BaseUrl = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMURL", "http://xxxxxx.com");
            string Username = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMUSERNAME", "XXXXXX");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("VADEMECUMPASSWORD", "XXXXXX");

            Uri baseUrl = new Uri(BaseUrl);
            RestClient client = new RestClient(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(Username, Password)
            };
            RestRequest requestAuth = new RestRequest("v1/auth-token", Method.GET);
            requestAuth.AddHeader("ApplicationId", "89a15fac0864d562b1ce1aca233db951");
            IRestResponse responseAuth = client.Execute(requestAuth);
            var authResult = JsonConvert.DeserializeObject<TTObjectClasses.VademecumOnline.AuthResult>(responseAuth.Content);

            return authResult;
        }
    }
}