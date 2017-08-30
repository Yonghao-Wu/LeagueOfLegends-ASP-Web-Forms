using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace RiotAPIforLOL
{
    public partial class LoginPage : System.Web.UI.Page
    {

        public static string api_pvp_net = ".api.pvp.net/api/lol/";
        public static string api_key = "?api_key=76f850ea-d3b4-436e-a2cc-69a575250661";
        public static string summer_by_name = "v1.4/summoner/by-name/";
        public SummonerValidate sv = new SummonerValidate();
        MiddleTier dbmt = new MiddleTier();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string pass = txtPassword.Text;

                SqlDataReader sdr;

                sdr = dbmt.Login(username, pass);
                if (pass == " " || username == " ")
                    MessageBox.Show("Missing Paramters");
                if (sdr.Read() == true)
                {
                    Response.Redirect("RankedGames.aspx", false);
                }
                else
                {
                    MessageBox.Show("Unknown User", "No record found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = " ";
                }
                sdr.Close();
            }


                //MessageBox.Show(sdrs);
                //frmMainMenu fmm = new frmMainMenu(sdrs);
            
            catch (SqlException sqx)
            {
                MessageBox.Show(sqx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string APIrequest(string name)
        {
            string data = "";
            WebRequest req = WebRequest.Create("https://" + "na" + api_pvp_net + "na" + "/" + summer_by_name + name + api_key);

            WebResponse res = req.GetResponse();
            Stream dataStream = res.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            data = reader.ReadToEnd();

            res.Close();
            return data;


            //http://stackoverflow.com/questions/22922881/json-with-dynamic-root-object
        }

        protected void lbSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }
    }

    public class SummonerValidate
    {
        public SummonerValidate()
        {

        }

        public string id { get; set; }
        public string name { get; set; }
        public string profileIconId { get; set; }
        public string summonerLevel { get; set; }
        public string revisionDate { get; set; }
    }
}