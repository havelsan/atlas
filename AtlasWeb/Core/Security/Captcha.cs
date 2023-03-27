using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public static class Captcha
    {
        //Convert.ToInt32(SystemParameter.GetParameterValue("FAILEDLOGINATTEMPTLIMIT", "5")) yapılacak
        static int failedLoginAttempLimit = 5;
        //Convert.ToInt32(SystemParameter.GetParameterValue("LOCKUSERLOGINATTEMPTCOUNT", "10")); yapılacak
        static int lockUserLoginAttemptCount = 10;
        //Convert.ToInt32(SystemParameter.GetParameterValue("LOCKACCOUNTINMINUTES", "1")); yapılacak
        static int lockAccountInMinutes = 1;

        //const int failedLoginAttempLimit = 5;

        static object failedLoginAttemptsLock = new object();
        static Dictionary<string, int> failedLoginAttempts = new Dictionary<string, int>();
        //static KeyPairDictonary<string, string, int> keyPairDictonary = new KeyPairDictonary<string, string, int>();
        static Dictionary<FailedToLoginAttemp, LockAccountModel> hashtable = new Dictionary<FailedToLoginAttemp, LockAccountModel>();

        public static LockAccountModel IsLimitExceeded(string ipAddress, string userName)
        {
            //int attempCount;
            LockAccountModel lockAccountModel;
            lock (failedLoginAttemptsLock)
            {
                //if (failedLoginAttempts.TryGetValue(ipAddress, out attempCount))
                //{
                //    if (attempCount >= failedLoginAttempLimit)
                //        return true;
                //}
                FailedToLoginAttemp failedToLoginAttemp = new FailedToLoginAttemp(ipAddress, userName, null);

                if (hashtable.TryGetValue(failedToLoginAttemp, out lockAccountModel))
                {
                    DateTime? lockUserLoginDate = hashtable.FirstOrDefault(x => x.Key.IpAddress == failedToLoginAttemp.IpAddress || x.Key.UserName == failedToLoginAttemp.UserName).Value.LockUserLoginDate;

                    if (lockAccountModel.AttemptCount >= lockUserLoginAttemptCount && lockUserLoginDate != null)
                    {
                        lockAccountModel.ReturnCaptcha = false;
                        lockAccountModel.LockUserLoginDate = lockUserLoginDate;
                    }
                    else if (lockAccountModel.AttemptCount >= failedLoginAttempLimit && lockUserLoginDate == null)
                    {
                        lockAccountModel.ReturnCaptcha = true;
                        lockAccountModel.LockUserLoginDate = null;
                    }
                }
                else
                {
                    lockAccountModel = new LockAccountModel { LockUserLoginDate = null, ReturnCaptcha = false };
                }
            }
            return lockAccountModel;
        }

        public static void RemoveFailedLoginAttempts(string ipAddress, string userName)
        {
            lock (failedLoginAttemptsLock)
            {
                FailedToLoginAttemp failedToLoginAttemp = new FailedToLoginAttemp(ipAddress, userName, null);
                hashtable.Remove(failedToLoginAttemp);
            }
        }

        public static LockAccountModel IncreaseFailedLoginAttemptsAndCheckLimit(string ipAddress, string userName)
        {
            //int attempCount;
            LockAccountModel lockAccountModel;
            lock (failedLoginAttemptsLock)
            {
                //if (failedLoginAttempts.TryGetValue(ipAddress, out attempCount))
                //{
                //    attempCount++;
                //    failedLoginAttempts[ipAddress] = attempCount;
                //    if (attempCount >= failedLoginAttempLimit)
                //        return true;
                //}
                //else
                //{
                //    failedLoginAttempts.Add(ipAddress, 1);
                //}
                FailedToLoginAttemp failedToLoginAttemp = new FailedToLoginAttemp(ipAddress, userName, null);
                if (hashtable.TryGetValue(failedToLoginAttemp, out lockAccountModel))
                {
                    lockAccountModel.AttemptCount++;
                    hashtable[failedToLoginAttemp] = lockAccountModel;
                    DateTime? lockUserLoginDate = hashtable.FirstOrDefault(x => x.Key.IpAddress == failedToLoginAttemp.IpAddress || x.Key.UserName == failedToLoginAttemp.UserName).Value.LockUserLoginDate;
                    if (lockUserLoginDate != null)
                    {
                        lockAccountModel.LockUserLoginDate = lockUserLoginDate;
                        lockAccountModel.ReturnCaptcha = false;
                    }
                    else if (lockAccountModel.AttemptCount >= lockUserLoginAttemptCount && lockUserLoginDate == null)
                    {
                        lockAccountModel.LockUserLoginDate = DateTime.Now.AddMinutes(lockAccountInMinutes);

                        hashtable.FirstOrDefault(x => x.Key.IpAddress == failedToLoginAttemp.IpAddress || x.Key.UserName == failedToLoginAttemp.UserName).Value.LockUserLoginDate = lockAccountModel.LockUserLoginDate;
                        hashtable.FirstOrDefault(x => x.Key.IpAddress == failedToLoginAttemp.IpAddress || x.Key.UserName == failedToLoginAttemp.UserName).Value.ReturnCaptcha = false;
                        lockAccountModel.ReturnCaptcha = false;
                    }
                    else if (lockAccountModel.AttemptCount >= failedLoginAttempLimit && lockUserLoginDate == null)
                    {
                        lockAccountModel.LockUserLoginDate = null;
                        lockAccountModel.ReturnCaptcha = true;
                    }
                }
                else
                {
                    lockAccountModel = new LockAccountModel();
                    lockAccountModel.AttemptCount++;
                    hashtable.Add(failedToLoginAttemp, lockAccountModel);
                }

            }
            return lockAccountModel;
        }

        const string Letters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GenerateCaptchaCode()
        {
            Random rand = new Random();
            int maxRand = Letters.Length - 1;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                int index = rand.Next(maxRand);
                sb.Append(Letters[index]);
            }

            return sb.ToString();
        }

        public static CaptchaResult GenerateCaptchaImage(int width, int height, string captchaCode)
        {
            using (Bitmap baseMap = new Bitmap(width, height))
            using (Graphics graph = Graphics.FromImage(baseMap))
            {
                Random rand = new Random();

                graph.Clear(GetRandomLightColor());

                DrawCaptchaCode();

                DrawDisorderLine();

                //AdjustRippleEffect();

                MemoryStream ms = new MemoryStream();

                baseMap.Save(ms, ImageFormat.Png);

                return new CaptchaResult { CaptchaCode = captchaCode, CaptchaByteData = ms.ToArray(), Timestamp = DateTime.Now };

                int GetFontSize(int imageWidth, int captchCodeCount)
                {
                    //var averageSize = imageWidth / captchCodeCount;
                    return Convert.ToInt32(height);
                    //return Convert.ToInt32(averageSize);
                }

                Color GetRandomDeepColor()
                {
                    int redlow = 160, greenLow = 100, blueLow = 160;

                    return Color.FromArgb(rand.Next(redlow), rand.Next(greenLow), rand.Next(blueLow));
                }

                Color GetRandomLightColor()
                {
                    int low = 180, high = 255;

                    int nRend = rand.Next(high) % (high - low) + low;
                    int nGreen = rand.Next(high) % (high - low) + low;
                    int nBlue = rand.Next(high) % (high - low) + low;

                    return Color.FromArgb(nRend, nGreen, nBlue);
                }

                void DrawCaptchaCode()
                {
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    int fontSize = GetFontSize(width, captchaCode.Length);
                    Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                    for (int i = 0; i < captchaCode.Length; i++)
                    {
                        fontBrush.Color = GetRandomDeepColor();

                        int shiftPx = fontSize / 6;

                        float x = i * fontSize + rand.Next(-shiftPx, shiftPx) + rand.Next(-shiftPx, shiftPx);
                        int maxY = height - fontSize;
                        if (maxY < 0) maxY = 0;
                        float y = rand.Next(0, maxY);

                        graph.DrawString(captchaCode[i].ToString(), font, fontBrush, x, y);
                    }
                }

                void DrawDisorderLine()
                {
                    Pen linePen = new Pen(new SolidBrush(Color.Black), 3);
                    for (int i = 0; i < rand.Next(3, 5); i++)
                    {
                        linePen.Color = GetRandomDeepColor();

                        Point startPoint = new Point(rand.Next(0, width), rand.Next(0, height));
                        Point endPoint = new Point(rand.Next(0, width), rand.Next(0, height));
                        graph.DrawLine(linePen, startPoint, endPoint);

                        Point bezierPoint1 = new Point(rand.Next(0, width), rand.Next(0, height));
                        Point bezierPoint2 = new Point(rand.Next(0, width), rand.Next(0, height));

                        graph.DrawBezier(linePen, startPoint, bezierPoint1, bezierPoint2, endPoint);
                    }
                }

            }
        }
    }

    public class CaptchaResult
    {
        public string CaptchaCode { get; set; }

        public byte[] CaptchaByteData { get; set; }

        public string CaptchBase64Data
        {
            get
            {
                return Convert.ToBase64String(CaptchaByteData);
            }
        }

        public DateTime Timestamp { get; set; }
    }

    public struct FailedToLoginAttemp
    {
        public string IpAddress { get; set; }
        public string UserName { get; set; }
        public DateTime? LockUserLoginDate { get; set; }

        public FailedToLoginAttemp(string ipAddress, string userName, DateTime? lockUserLoginDate)
        {
            UserName = userName;
            IpAddress = ipAddress;
            LockUserLoginDate = lockUserLoginDate;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to ThreeDPoint return false:
            FailedToLoginAttemp p = (FailedToLoginAttemp)obj;
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return UserName == p.UserName || IpAddress == p.IpAddress;
            //return base.Equals(obj) && UserName == p.UserName || IpAddress == p.IpAddress;
        }

        public bool Equals(FailedToLoginAttemp p)
        {
            // Return true if the fields match:
            return base.Equals((FailedToLoginAttemp)p) || UserName == p.UserName || IpAddress == p.IpAddress;
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(IpAddress))
                return 0;
            int userNameHash = string.IsNullOrEmpty(UserName) ? UserName.GetHashCode() : 0;
            int ipAddressHash = string.IsNullOrEmpty(IpAddress) ? IpAddress.GetHashCode() : 0;
            return userNameHash ^ ipAddressHash;
        }

    }

    public class LockAccountModel
    {
        public bool ReturnCaptcha { get; set; }
        public DateTime? LockUserLoginDate { get; set; }
        public int AttemptCount = 0;
    }
}

