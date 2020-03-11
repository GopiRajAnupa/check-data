using Effecta.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Effecta.AutomationTool
{
    public partial class HTMLRecorder : System.Web.UI.Page
    {
        private CurrentUser CurUsr;
        private string transId;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ecName="";
                CurUsr = (Session["CurUserContext"] != null) ? (CurrentUser)Session["CurUserContext"] : null;
                if (CurUsr == null)
                {
                    Response.Redirect("login.aspx", false);
                    return;
                }
                if (Request.QueryString["TCID"] != null)
                {
                    transId = Request.QueryString["TCID"].ToString();
               
                }
                if (Request.QueryString["ECName"] != null)
                {
                    ecName = Request.QueryString["ECName"].ToString();
                    lblEcName.Text = ecName;
                }
                

                if (ValidateSoftware())
                {
                    ifrmGrabber.Attributes.Add("src", "AutomationTool.xbap?ECID=" + Request.QueryString["ECID"].ToString() + "&TCID=" + Request.QueryString["TCID"].ToString()
                            + "&UserId=" + CurUsr.userId + "&InstanceId=" + CurUsr.instanceId + "&ECName=" + ecName);
               }
            }
            catch (Exception ex)
            {
                //  Logger.Write("Exception in HTMLRecorder.Page_Load Event: " + ex.Message);
            }
        }
        protected void lnkBtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Constants.TESTSCRIPTS.EXECUTIONCOMPONENT, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidateSoftware()
        {
            RegistryKey regKey=null;
            bool frameworkExist = true;
            //try
            //{
            //    string DotNet = @"Microsoft .NET Framework";
            //    List<string> softwaresFound = new List<string>();
            //    if (IntPtr.Size == 4)
            //    {
            //        regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            //    }
            //    else if (IntPtr.Size == 8)
            //    {
            //        regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            //    }
               
            //    CheckSoftwares(DotNet, softwaresFound, regKey);
            //    if (softwaresFound.Count < 1)
            //    {
            //        frameworkExist = false;
            //        MessageBox.Show("Please Install latest .Net Framework to Proceed Further");
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return frameworkExist;
        }
        private static void CheckSoftwares(string DotNet, List<string> softwaresFound, RegistryKey regKey)
        {
            try
            {

                foreach (String keyName in regKey.GetSubKeyNames())
                {

                    RegistryKey subkey = regKey.OpenSubKey(keyName);
                    string SoftwareName = subkey.GetValue("DisplayName") as string;
                    //MessageBox.Show(SoftwareName ?? keyName);
                    if (Regex.IsMatch(SoftwareName ?? keyName, DotNet))
                    {
                        softwaresFound.Add(SoftwareName ?? keyName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}