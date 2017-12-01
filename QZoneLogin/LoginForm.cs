using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using SufeiUtil;
using DotNet.Utilities;

namespace QZoneLogin
{
    public partial class LoginForm : Form
    {
        public int hasimage = 0;   //表示是否含有验证码图片
        private string QQ = null;
        private string password = null;
        private string verifycode = null;
        private HttpResult outcomeFromLogin = new HttpResult();
        private HttpResult outcomeFromCheck = new HttpResult();
        private Int32 qq_num = 0;
        private string ptv = "";
        private string pt_login_sig;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpHelper helper1 = new HttpHelper();
            
            if (QQ_acount_box.Text == null)
            {
                MessageBox.Show("账号不能为空");
            }
            if (QQ_pass_box.Text == null)
            {
                MessageBox.Show("密码不能为空");
            }
            if (Vericode_box.Text == null)
            {
                MessageBox.Show("验证码不能为空");
            }
            //string pass = helper2.GetPassword(this.QQ, this.password, Vericode_box.Text);
            String forLoginUrl = "https://ssl.ptlogin2.qq.com/login?u=" + QQ + "&verifycode=" + Vericode_box.Text + "&pt_vcode_v1=0&pt_verifysession_v1=" + ptv + "&p=" +
                GetEncryption() + "&pt_randsalt=2&pt_jstoken=3611214356&u1=" +
                "http://xinyue.qq.com/" +
                "&pt_randsalt=2&pt_jstoken=3611214356&u1=http%3A%2F%2Fxinyue.qq.com%2Fcomm-htdocs%2Flogin%2Flogincallback.htm&ptredirect=0&h=1&t=1&g=1&from_ui=1&ptlang=2052&action=2-8-1511447270214&js_ver=10232&js_type=1&login_sig=" +
                pt_login_sig +
                "&pt_uistyle=40&aid=21000111&daid=8&has_onekey=1&&pt_guid_sig=EBA5671BFBE1E66DFC16E6001B8556A5716C0F0FF45791CC89C8C9EE146D9957D7D7046D3CA42DC5";

            HttpItem h = new HttpItem
            {
                URL = forLoginUrl,
                ResultCookieType = ResultCookieType.CookieCollection,
            };
            outcomeFromLogin = helper1.GetHtml(h);
            String revFromLogin = outcomeFromLogin.Html;
            Return_box.Text = revFromLogin; //打印登录后返回信息
            int a = revFromLogin.IndexOf("ptsigx=");
            int i = a + 7;
            string ptsigx = "";
            while (revFromLogin[i] != '&')
                ptsigx += revFromLogin[i++];

            string u = "";
            i = revFromLogin.IndexOf("http");
            while (revFromLogin[i] != '\'')
                u += revFromLogin[i++];


            String forCheckUrl = u;

            HttpItem Check = new HttpItem
            {
                URL = forCheckUrl,
                Cookie = outcomeFromLogin.Cookie,
                ResultCookieType = ResultCookieType.CookieCollection,
                Allowautoredirect = true,
            };
            HttpResult HR = helper1.GetHtml(Check);
            //至此登录成功
            MessageBox.Show(HR.Cookie);

            HttpItem m = new HttpItem
            {
                URL = "https://apps.game.qq.com/comm-cgi-bin/login/LoginReturnInfo.cgi",
                //CookieCollection = outcomeFromLogin.CookieCollection,
                //Cookie = MyCookie,
                Allowautoredirect = true,
                Cookie = HR.Cookie,
                Host = "apps.game.qq.com",
                Referer = "http://xinyue.qq.com/",
                UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)",
                Accept = "text/html, application/xhtml+xml, image/jxr, */*"

            };

            outcomeFromLogin = helper1.GetHtml(m);
            revFromLogin = outcomeFromLogin.Html;
            //Return_box.Text = revFromLogin; //打印登录后返回信息
            //MessageBox.Show(outcomeFromLogin.Html);
            //MessageBox.Show(outcomeFromLogin.Cookie);


        }

        private void QQ_acount_box_TextChanged(object sender, EventArgs e)
        {
            this.QQ = QQ_acount_box.Text;
        }
        
        private void QQ_pass_box_TextChanged(object sender, EventArgs e)
        {
            this.password = QQ_pass_box.Text;
        }

        private void Return_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vericode_box_TextChanged(object sender, EventArgs e)
        {
            this.verifycode = Vericode_box.Text;
        }

        private void QQ_acount_box_Leave_1(object sender, EventArgs e) //当焦点(光标)离开QQ账号输入框是触发此函数，获取验证码
        {
            GetCheck();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            QQ_acount_box.Focus();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e) //双击时刷新验证码
        {
            GetCheck();
        }

        private string GetLoginSig()
        {
            String forCheckUrl = "https://xui.ptlogin2.qq.com/cgi-bin/xlogin?proxy_url=http://game.qq.com/comm-htdocs/milo/proxy.html&appid=21000111&f_url=loginerroralert&target=self&qtarget=self&s_url=http%3A//xinyue.qq.com/comm-htdocs/login/logincallback.htm&no_verifyimg=1&daid=8&qlogin_jumpname=jump&qlogin_param=u1%3Dhttp%3A//xinyue.qq.com/comm-htdocs/login/logincallback.htm";
            HttpHelper helper = new HttpHelper();
            outcomeFromCheck = helper.GetHtml(new HttpItem { URL = forCheckUrl});
            MessageBox.Show(outcomeFromCheck.Cookie);
            return HttpCookieHelper.GetCookieValue("pt_login_sig", outcomeFromCheck.Cookie);
        }

        private void GetCheck()
        {
            //获取验证信息
            //验证信息格式为：ptui_checkVC('0','!MIW','\x00\x00\x00\x00\x9a\x65\x0f\xd7') 
            //其中分为三部分，第一个值0或1判断是否需要图片验证码
            //                          第二个值是默认验证码，若不需要图片验证码，就用此验证码来提交
            //                          第三部分是所使用的QQ号码的16进制形式
            pt_login_sig = GetLoginSig();

            //https://ssl.ptlogin2.qq.com/check?regmaster=&pt_tea=2&pt_vcode=1&uin=66456804&appid=21000111&js_ver=10232&js_type=1&login_sig=-PB6vLz9Tbc*6XY0haBM1qyXFU-3dn70pj0uX6-wNeLO8oz4k2u9tKuaC2PO-fJv&u1=http%3A%2F%2Fxinyue.qq.com%2Fcomm-htdocs%2Flogin%2Flogincallback.htm&r=0.00668773893967356&pt_uistyle=40&pt_jstoken=3611214356
            String forCheckUrl = "https://ssl.ptlogin2.qq.com/check?regmaster=&pt_tea=2&pt_vcode=1&uin=" + QQ + "&appid=21000111&js_ver=10232&js_type=1&login_sig=" + pt_login_sig + "&u1=http%3A%2F%2Fxinyue.qq.com%2Fcomm-htdocs%2Flogin%2Flogincallback.htm&r=0.00668773893967356&pt_uistyle=40&pt_jstoken=3611214356";
            CookieContainer cookieNull = new CookieContainer();
            HttpHelper helper = new HttpHelper()
            {
                
            };


            HttpItem h = new HttpItem() { URL = forCheckUrl,ResultType = ResultType.String };
            String receiveFromCheck = "";

            HttpResult result = helper.GetHtml(h);
            receiveFromCheck = result.Html;

            ptv = HttpCookieHelper.GetCookieValue("ptvfsession", result.Cookie);

            //将验证码信息的三部分存入数组
            int checkCodePosition = receiveFromCheck.IndexOf("(") + 1;
            String checkCode = receiveFromCheck.Substring(checkCodePosition, receiveFromCheck.LastIndexOf(")") - checkCodePosition);
            String[] checkNum = checkCode.Replace("'", "").Split(',');  //验证码数组


            if ("1".Equals(checkNum[0])) //判断是否需要图片验证码
            {
                hasimage = 1;
                String forImageUrl = "http://captcha.qq.com/getimage?aid=21000111&uin=" + QQ + "&cap_cd=" + checkNum[1];
                Stream receiveStream = new MemoryStream(helper.GetHtml(new HttpItem { URL = forImageUrl, ResultType = ResultType.Byte }).ResultByte);
                //将获取的图片验证码存入电脑
                //System.Drawing.Image.FromStream(receiveStream).Save(@"d:/code.jpg");
                Image img = Image.FromStream(receiveStream);
                pictureBox1.Image = img; //将读取到的图片验证码输出到picture_box面板上
            }
            else //若不需图片验证码，验证码就等于checkNum[1]
            {
                hasimage = 0;
                Vericode_box.Text = checkNum[1];
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //当鼠标在有图片显示的picturebox上移动时提醒可刷新验证码
        {
            if (hasimage==1)
            {
                toolTip1.SetToolTip(pictureBox1, "双击可以刷新验证码");
            }
        }
        private string ExecuteScript(string sExpression, string sCode)
         {
             MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
             scriptControl.UseSafeSubset = true;
             scriptControl.Language = "JScript";
             scriptControl.AddCode(sCode);
             try
             {
                 string str = scriptControl.Eval(sExpression).ToString();
                 return str;
             }
             catch (Exception ex)
             {
                 string str = ex.Message;
             }
             return null;
        }

        string GetEncryption()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "test.js";
            string str2 = File.ReadAllText(path);

            string fun = "getmd5(\"" + QQ + "\",\"" + password + "\",\"" + Vericode_box.Text + "\")";
            string result = ExecuteScript(fun, str2);
            //result = result.Replace('/', '-');
            //result = result.Replace('+', '*');
            //result = result.Replace('=', '_');
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
    public struct RetData //网页请求返回对象
    {
        public string str;
        public CookieContainer cookie;
    }
}
