using AtlasSmsManager;
using Core.AtlasWebSocketManager.Containers;
using Core.Models;
using Core.Security;
using Infrastructure.Filters;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Services;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TTConnectionManager;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IAccountService _accountService;
        private readonly TTUtils.IActiveUserService _activeUserService;
        private readonly JWTSettings _jwtSettings;
        //Key:IP Address, Value: Failed login attempt count git deneme

        public AccountController(IOptions<JWTSettings> optionsAccessor, TTUtils.IActiveUserService activeUserService
            , IAccountService accountService
            , ITokenStoreService tokenStoreService)
        {
            _activeUserService = activeUserService;
            _jwtSettings = optionsAccessor.Value;
            _accountService = accountService;
            _tokenStoreService = tokenStoreService;
        }

        public Tuple<string, Guid> GetToken(Tuple<AuthenticationResultEnum, TTUser> result)
        {
            var user = result.Item2;
            _activeUserService.AddUserToCache(user);
            this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(user.UserID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, user.UserID.ToString())
                    }));

            var accessTokenResult = GetAccessToken(_jwtSettings, user);
            var tokenInfo = new AtlasTokenInfo();
            tokenInfo.TokenIdentifier = accessTokenResult.Item2;
            tokenInfo.UserId = user.UserID;
            _tokenStoreService.AddIssuedToken(tokenInfo);
            return accessTokenResult;
        }

        //
        // POST: /Account/Authenticate
        [HttpPost]
        [AllowAnonymous]
        public Task<IActionResult> Authenticate(AuthViewModel model)
        {
            string ipAddress = ControllerContext.HttpContext.GetRemoteIpAddress();
            //TTUtils.Logger.WriteInfo("Authenticatex : " + ipAddress);
            JsonResult failedLoginAttemptResult = null;
            AuthViewResultModel captchaLogResult;

            //Is captcha required
            LockAccountModel lockAccountModel = null;
            if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                lockAccountModel = Captcha.IsLimitExceeded(ipAddress, model.UserName);
                if (lockAccountModel.ReturnCaptcha)
                {
                    using (DbConnection dbConnection = ConnectionManager.CreateConnection())
                    {
                        DbCommand cmd = ConnectionManager.CreateCommand("SELECT * FROM TTFAILEDLOGINATTEMPTS WHERE CAPTCHAGUID =" + "'" + model.CaptchaGuid.ToString().Replace("'", "''") + "'", dbConnection);

                        DbDataAdapter adapter = ConnectionManager.CreateDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        DataTable tbl = ds.Tables[0];
                        string captchaCode = string.Empty;
                        if (tbl.Rows.Count != 0)
                        {
                            DataRow dr = tbl.Rows[0];
                            captchaCode = dr["CAPTCHACODE"].ToString();
                        }
                        if (string.IsNullOrEmpty(captchaCode) || captchaCode.ToUpperInvariant() != model.CaptchaCode.ToUpperInvariant())
                        {
                            captchaLogResult = CreateCaptcha();
                            captchaLogResult.ErrorMessage = TTUtils.CultureService.GetText("M25508", "Doğrulama kodu yanlış!");
                            Captcha.IncreaseFailedLoginAttemptsAndCheckLimit(ipAddress, model.UserName);
                            return Task.FromResult<IActionResult>(Ok(new JsonResult(captchaLogResult)));
                        }
                    }
                }
                else if (lockAccountModel.LockUserLoginDate != null)
                {
                    if ((DateTime.Now - lockAccountModel.LockUserLoginDate.Value).Seconds >= 0)
                    {
                        Captcha.RemoveFailedLoginAttempts(ipAddress, model.UserName);
                    }
                    else
                    {
                        failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { ErrorMessage = lockAccountModel.LockUserLoginDate + " tarihine kadar giriş işlemi yapmanız engellenmiştir!" });
                        return Task.FromResult<IActionResult>(Ok(failedLoginAttemptResult));
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var result = TTUser.CheckAuthenticate(model.UserName, model.Password);

                if (result.Item1 == AuthenticationResultEnum.PasswordOK)
                {
                    var user = result.Item2;

                    _activeUserService.AddUserToCache(user);

                    this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(user.UserID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, user.UserID.ToString())
                    }));

                    var accessTokenResult = GetToken(result);
                    var jsonResult = new JsonResult(new AuthViewResultModel() { access_token = accessTokenResult.Item1, user = user });
                    //{
                    //    { "access_token", GetAccessToken(_jwtSettings, user) },
                    //    { "id_token", GetIdToken(_jwtSettings, user) },
                    //    { "user", user }
                    //});

                    if (result.Item2.IsSuperUser)
                    {
                        TTObjectClasses.SystemParameter.RefreshCache();
                    }

                    Captcha.RemoveFailedLoginAttempts(ipAddress, model.UserName);

                    return Task.FromResult<IActionResult>(Ok(jsonResult));
                }
                else if (result.Item1 == AuthenticationResultEnum.UserOnVacation)
                {
                    failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { ErrorMessage = "Giriş yapmaya çalıştığınız personel izinli olduğu için giriş yapmanız engellenmiştir!" });
                    return Task.FromResult<IActionResult>(Ok(failedLoginAttemptResult));
                }
                else if (result.Item1 == AuthenticationResultEnum.WarnUserToChangePassword)
                {
                    var user = result.Item2;
                    _activeUserService.AddUserToCache(user);
                    this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(user.UserID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, user.UserID.ToString())
                    }));

                    var accessTokenResult = GetToken(result);
                    var jsonResult = new JsonResult(new AuthViewResultModel() { access_token = accessTokenResult.Item1, user = user });
                    failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { access_token = accessTokenResult.Item1, ErrorMessage = "Şifrenizin süresi dolmak üzere. Şifrenizi değiştiriniz.", user = user, AuthResultEnum = result.Item1 });
                    return Task.FromResult<IActionResult>(Ok(failedLoginAttemptResult));
                }
                else if (result.Item1 == AuthenticationResultEnum.PasswordExpired)
                {
                    var user = result.Item2;
                    _activeUserService.AddUserToCache(user);
                    this.ControllerContext.HttpContext.User = new ClaimsPrincipal(new AtlasUser(new GenericIdentity(user.UserID.ToString(), "Token"), new Claim[] {
                        new Claim(JwtRegisteredClaimNames.Sid, user.UserID.ToString())
                    }));

                    var accessTokenResult = GetToken(result);
                    var jsonResult = new JsonResult(new AuthViewResultModel() { access_token = accessTokenResult.Item1, user = user });
                    failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { access_token = accessTokenResult.Item1, ErrorMessage = "Şifrenizin süresi dolmuştur. Lütfen şifrenizi değiştiriniz.", user = user, AuthResultEnum = result.Item1 });
                    return Task.FromResult<IActionResult>(Ok(failedLoginAttemptResult));
                }
                else if (result.Item1 == AuthenticationResultEnum.RestrictedTimeRange)
                {
                    Captcha.RemoveFailedLoginAttempts(ipAddress, model.UserName);
                    failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { ErrorMessage = "Bulunduğunuz saat aralığında sistemi kullanmanıza izin verilmiyor." });
                    return Task.FromResult<IActionResult>(Ok(failedLoginAttemptResult));
                }
            }
            lockAccountModel = Captcha.IncreaseFailedLoginAttemptsAndCheckLimit(ipAddress, model.UserName);
            if (lockAccountModel.ReturnCaptcha)
            {
                captchaLogResult = CreateCaptcha();
                captchaLogResult.ErrorMessage = TTUtils.CultureService.GetText("M27040", "Tanımlı olmayan kullanıcı ve/veya şifre");
                failedLoginAttemptResult = new JsonResult(captchaLogResult);
            }
            else if (lockAccountModel.LockUserLoginDate != null)
            {
                failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { ErrorMessage = lockAccountModel.LockUserLoginDate + " tarihine kadar giriş işlemi yapmanız engellenmiştir!" });
            }
            else
            {
                failedLoginAttemptResult = new JsonResult(new AuthViewResultModel() { ErrorMessage = TTUtils.CultureService.GetText("M27040", "Tanımlı olmayan kullanıcı ve/veya şifre") }) { /*StatusCode = StatusCodes.Status400BadRequest*/ };
            }

            return Task.FromResult<IActionResult>(Ok(failedLoginAttemptResult));
        }

        [HttpPost]
        public Task<IActionResult> Logout()
        {
            _accountService.Logout(this.HttpContext);
            return Task.FromResult<IActionResult>(Ok());
        }


        [HttpGet]
        public Task<IActionResult> GetUser([FromQuery]string userID)
        {
            Guid userIDGuid;
            if (Guid.TryParse(userID, out userIDGuid))
            {
                var user = TTUser.GetUser(userIDGuid);
                var jsonResult = new JsonResult(new { user = user });
                return Task.FromResult<IActionResult>(jsonResult);
            }

            var errorResult = new JsonResult(new { error_description = "Unknown UserID" }) { StatusCode = StatusCodes.Status400BadRequest };
            return Task.FromResult<IActionResult>(errorResult);
        }

        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> RefreshCaptcha(string userName)
        {
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            JsonResult result = null;
            LockAccountModel lockAccountModel = Captcha.IsLimitExceeded(ipAddress, userName);
            if (lockAccountModel.ReturnCaptcha)
            {
                result = new JsonResult(CreateCaptcha());
            }
            else if (lockAccountModel.LockUserLoginDate != null)
            {
                result = new JsonResult(new AuthViewResultModel { ErrorMessage = lockAccountModel.LockUserLoginDate + " tarihine kadar giriş işlemi yapmanız engellenmiştir!" });
            }
            else
            {
                result = new JsonResult(new AuthViewResultModel { ErrorMessage = TTUtils.CultureService.GetText("M25507", "Doğrulama Kodu alamazsınız!") });
            }

            return Task.FromResult<IActionResult>(Ok(result));
        }

        [HttpPost]
        public bool HasRole(InputFor_HasRole input)
        {
            if (Common.CurrentUser.HasRole(input.roleID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static Tuple<string, Guid> GetIdToken(JWTSettings jwtSettings, TTUser user)
        {
            var payload = new Dictionary<string, object>
              {
                { JwtRegisteredClaimNames.Sid, user.UserID },
                { JwtRegisteredClaimNames.Sub, user.Name },
                { JwtRegisteredClaimNames.UniqueName, user.UniqueRefNo },
              };
            return GetToken(jwtSettings, payload);
        }


        internal static Tuple<string, Guid> GetAccessToken(JWTSettings jwtSettings, TTUser user)
        {
            var payload = new Dictionary<string, object>
            {
                { JwtRegisteredClaimNames.Sid, user.UserID },
                { JwtRegisteredClaimNames.Sub, user.Name },
            };
            return GetToken(jwtSettings, payload);
        }

        internal static Tuple<string, Guid> GetToken(JWTSettings jwtSettings, Dictionary<string, object> payload)
        {
            var tokenIdentifier = Guid.NewGuid();
            var secret = jwtSettings.SecretKey;
            var currentDate = DateTime.UtcNow;
            payload.Add(JwtRegisteredClaimNames.Iss, jwtSettings.Issuer);
            payload.Add(JwtRegisteredClaimNames.Aud, jwtSettings.Audience);
            payload.Add(JwtRegisteredClaimNames.Nbf, ConvertToUnixTimestamp(currentDate));
            payload.Add(JwtRegisteredClaimNames.Iat, ConvertToUnixTimestamp(currentDate));
            payload.Add(JwtRegisteredClaimNames.Exp, ConvertToUnixTimestamp(currentDate.Add(jwtSettings.Expiration)));
            payload.Add(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return Tuple.Create(token, tokenIdentifier);
        }

        [HttpGet]
        public bool ValidateToken(string id_token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(id_token, validationParameters, out validatedToken);
                return principal.Identity.IsAuthenticated;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "atlas",
                ValidAudience = "atlas",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Atlas-web-api-secret_KEY!+")) // The same key as the one that generate the token
            };
        }

        internal static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public CaptchaResult GetImage()
        {
            int width = 200;
            int height = 40;
            var captchaCode = Captcha.GenerateCaptchaCode();

            return Captcha.GenerateCaptchaImage(width, height, captchaCode);

        }
        public AuthViewResultModel CreateCaptcha()
        {
            Guid captchaGuid = Guid.NewGuid();

            CaptchaResult captchaResult = GetImage();

            using (DbConnection cn = ConnectionManager.CreateConnection())
            {
                DbCommand cmd = ConnectionManager.CreateCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = "INSERT INTO TTFAILEDLOGINATTEMPTS (CAPTCHAGUID,CAPTCHACODE,CAPTCHADATE) VALUES ("
            + ConnectionManager.ParameterChar + "CAPTCHAGUID, "
            + ConnectionManager.ParameterChar + "CAPTCHACODE, "
             + ConnectionManager.ParameterChar + "CAPTCHADATE)";

                cmd.Parameters.Add(ConnectionManager.CreateParameter(ConnectionManager.ParameterChar + "CAPTCHAGUID", ConnectionManager.ToDBGuid(captchaGuid)));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(ConnectionManager.ParameterChar + "CAPTCHACODE", captchaResult.CaptchaCode));
                cmd.Parameters.Add(ConnectionManager.CreateParameter(ConnectionManager.ParameterChar + "CAPTCHADATE", TTDefinitionManagement.TTObjectDefManager.GetRealServerTime(false)));

                cmd.ExecuteNonQuery();

                return new AuthViewResultModel() { CaptchaGuid = captchaGuid, CaptchaImage = captchaResult.CaptchBase64Data };
            }
        }

        [HttpGet]
        [HvlResult]
        public bool AddToFavorites(string key)
        {
            var userID = Common.CurrentUser.TTObjectID.ToString();

            using (var objectContext = new TTObjectContext(false))
            {
                var userOptions = UserOption.GetOption(objectContext, userID, UserOptionType.FavoriteMenuItem);

                var isExist = userOptions.FirstOrDefault(x => x.Value == key);

                if (isExist != null)
                {
                    return false;
                }

                UserOption uo = new UserOption(objectContext);
                uo.OptionType = UserOptionType.FavoriteMenuItem;
                uo.ResUser = Common.CurrentResource;
                uo.Value = key;

                objectContext.Save();
            }

            return true;
        }
        [HttpGet]
        [HvlResult]
        public bool RemoveFromFavorites(string key)
        {
            var userID = Common.CurrentUser.TTObjectID.ToString();

            using (var objectContext = new TTObjectContext(false))
            {
                var userOptions = UserOption.GetOption(objectContext, userID, UserOptionType.FavoriteMenuItem);
                var isExist = userOptions.FirstOrDefault(x => x.Value == key);
                if (isExist == null)
                {
                    return false;
                }
                var ttObj = isExist as ITTObject;

                ttObj.Delete();
                objectContext.Save();
            }


            return true;
        }
        [HttpGet]
        [HvlResult]
        public List<string> GetFavorites()
        {
            var userID = Common.CurrentUser.TTObjectID.ToString();
            List<string> result = null;
            using (var objectContext = new TTObjectContext(true))
            {
                result = UserOption.GetOption(objectContext, userID, UserOptionType.FavoriteMenuItem).Select(x => x.Value).ToList(); ;

            }
            return result;
        }

        [HttpGet]
        [HvlResult]
        public object GetNotifications(string lastTime, int size)
        {
            System.Threading.Thread.Sleep(500);
            DateTime time;
            if (string.IsNullOrEmpty(lastTime))
            {
                time = DateTime.Now;
            }
            else
            {
                var timeSpan = Convert.ToDouble(lastTime);
                time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timeSpan).ToLocalTime();
            }
            return NotificationService.GetNotifications(time, size);
        }

        [HttpGet]
        [HvlResult]
        public object SetRead(string notificationID, bool read)
        {
            return NotificationService.SetRead(notificationID, read);
        }

        [HttpGet]
        [HvlResult]
        public object ReadAll()
        {
            return NotificationService.ReadAll();
        }

        [HttpGet]
        [HvlResult]
        public ServerInfo ServerInfo()
        {
            ServerInfo serverInfo = new ServerInfo();
            serverInfo.IPAddress = this.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            serverInfo.ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            serverInfo.SoftwareVersion = null;

            return serverInfo;
        }

        [HttpPost]
        [HvlResult]
        public bool SendFB(UserInfoDto jsonData)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var userInfo = _context.QueryObjects<UserInfo>("User = '" + Common.CurrentResource.ObjectID + "'").FirstOrDefault();
                if (userInfo == null)
                {
                    userInfo = new UserInfo(_context);
                    userInfo.User = Common.CurrentResource;
                    userInfo.Ping = jsonData.Ping;
                    userInfo.PingCount = 0;
                }
                if (!userInfo.PingCount.HasValue)
                {
                    userInfo.PingCount = 1;
                }
                if (userInfo.PingCount >= 10)
                {
                    userInfo.PingCount = 9;
                }

                userInfo.UserName = jsonData.UserName;
                userInfo.ChromeVersion = jsonData.ChromeVersion;
                userInfo.CPU = jsonData.CPU;
                userInfo.Height = jsonData.Height;
                userInfo.JSTime = jsonData.JSTime;
                userInfo.Ping = Math.Floor((((userInfo.PingCount.Value) * Convert.ToInt32(userInfo.Ping)) + Convert.ToInt32(jsonData.Ping)) / (userInfo.PingCount.Value + 1.0)).ToString();
                userInfo.RAM = jsonData.RAM;
                userInfo.ServerTime = jsonData.ServerTime;
                userInfo.SoftwareVersion = jsonData.SoftwareVersion;
                userInfo.Width = jsonData.Width;
                userInfo.IP = jsonData.IP;
                userInfo.PingCount++;
                _context.Save();

            }

            return true;
        }


        [HttpPost]
        
        public bool SendNotificationSms(AtlasSMS sms)
        {
            var isSuperUser = TTUser.CurrentUser.IsSuperUser;

            if(isSuperUser == false)
            {
                return false;
            }

            var userPhones = TTObjectClasses.SystemParameter.GetParameterValue("NotifyUserPhones", "");

            if (string.IsNullOrEmpty(userPhones))
            {
                return false;
            }

            var phoneNumbers = userPhones.Split(',');
            if (phoneNumbers.Length > 0)
            {
                foreach (var item in phoneNumbers)
                {
                    SmsManager.Instance.SendSms(new AtlasSMS()
                    {
                        Text = sms.Text,
                        Number = item
                    });
                }
            }
            return true;
        }
    }



    public class ServerInfo
    {
        public string IPAddress { get; set; }
        public string ServerTime { get; set; }
        public string SoftwareVersion { get; set; }
    }
    public class UserInfoDto
    {
        public string ChromeVersion { get; set; }
        public string CPU { get; set; }
        public string Height { get; set; }
        public string JSTime { get; set; }
        public string Ping { get; set; }
        public string RAM { get; set; }
        public string ServerTime { get; set; }
        public string SoftwareVersion { get; set; }
        public string Width { get; set; }
        public string IP { get; set; }
        public string UserName { get; set; }
    }
}