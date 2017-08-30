using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotAPIforLOL
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        public string regionShort;
        MiddleTier dbmt = new MiddleTier();
        public static string api_pvp_net = ".api.pvp.net/api/lol/";
        public static string api_key = "?api_key=76f850ea-d3b4-436e-a2cc-69a575250661";
        public static string summer_by_name = "v1.4/summoner/by-name/";
        public SummonerValidate1 sv = new SummonerValidate1();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDropDown();
        }

        public void PopulateDropDown()
        {
            //North America - NA League Championship Series (NA LCS)
            //Europe - EU League Championship Series (EU LCS)
            //Korea - OGN Champions (OGN)
            //China - League of Legends Pro League (LPL)
            //Southeast Asia - Garena Premier League (GPL)
            string[] regionarray = { "North America", "Brazil", "Europe Nordic & East", "Europe West", "Latin America North", "Latin America South", 
                                       "Korea", "Oceania", "Russia", "Turkey" };
            for (int i = 0; i < regionarray.Length; i++)
            {
                cboRegion.Items.Add(regionarray[i]);
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                int randomint = r.Next(1000, 10000);

                if (txtFname.Text != " " || txtLname.Text != " " || txtUsername.Text != " " || txtemail.Text != " " || txtPassword.Text != " ")
                {
                    string data = APIrequest(txtUsername.Text);
                    var obj = JObject.Parse(data);
                    if (obj != null)
                    {
                        var root = obj.First;
                        if (root != null)
                        {
                            var sumJson = root.First;
                            if (sumJson != null)
                            {
                                var ro = sumJson.ToObject<SummonerValidate>();
                                if (ro.name == txtUsername.Text)
                                {
                                    if (dbmt.returnUsername(ro.name) == "0")
                                    {
                                        if (dbmt.returnEmail(txtemail.Text) == "0")
                                        {
                                            dbmt.AddANewRecord(randomint.ToString(), txtFname.Text, txtLname.Text, txtemail.Text, returnregion(cboRegion.SelectedItem.Value), txtUsername.Text, txtPassword.Text);
                                            //Response.Redirect("SuccessPage.aspx");
                                            MessageBox.Show("Account activation complete!");
                                        }
                                    }
                                    if (dbmt.returnUsername(ro.name) == "1")
                                    {
                                        MessageBox.Show("Username already exists.");
                                    }
                                    if (dbmt.returnEmail(txtemail.Text) == "1")
                                    {
                                        MessageBox.Show("Email already exists.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Undefined League of Legends Profile.");
                                }
                            }
                        }
                    }
                }
                //dbmt.AddANewRecord(randomint.ToString(), txtFname.Text, txtLname.Text, txtemail.Text, returnregion(cboRegion.SelectedItem.Value), txtUsername.Text, txtPassword.Text);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("400"))
                {
                    MessageBox.Show("There are missing fields.");
                }
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

        public string returnregion(string region)
        {

            if (region == "North America")
            {
                regionShort = "NA";
            }
            else if (region == "Brazil")
            {
                regionShort = "BR";
            }
            else if (region == "Europe Nordic & East")
            {
                regionShort = "EUNE";
            }
            else if (region == "Europe West")
            {
                regionShort = "EUW";
            }
            else if (region == "Latin America North")
            {
                regionShort = "LAN";
            }
            else if (region == "Latin America South")
            {
                regionShort = "LAS";
            }
            else if (region == "Korea")
            {
                regionShort = "KR";
            }
            else if (region == "Oceania")
            {
                regionShort = "OCE";
            }
            else if (region == "Russia")
            {
                regionShort = "RU";
            }
            else if (region == "Turkey")
            {
                regionShort = "TR";
            }

            return regionShort;
        }

        protected void lbLOLredirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://na.leagueoflegends.com/");
        }
    }

    public class SummonerValidate1
    {
        public SummonerValidate1()
        {

        }

        public string id { get; set; }
        public string name { get; set; }
        public string profileIconId { get; set; }
        public string summonerLevel { get; set; }
        public string revisionDate { get; set; }
    }
}