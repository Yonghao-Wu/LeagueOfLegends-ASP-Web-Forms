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
    public partial class RankedGames : System.Web.UI.Page
    {
        MiddleTier dbmt = new MiddleTier();
        public static string api_pvp_net = ".api.pvp.net/api/lol/";
        public static string api_key = "?rankedQueues=RANKED_SOLO_5x5&api_key=76f850ea-d3b4-436e-a2cc-69a575250661";
        public static string summer_by_name = "v2.2/matchlist/by-summoner/";
        public static string summonerid;
        public static List<matchinfo> mi = new List<matchinfo>();
        //https://na.api.pvp.net/api/lol/na/v2.2/matchlist/by-summoner/49169861?rankedQueues=RANKED_SOLO_5x5&api_key=76f850ea-d3b4-436e-a2cc-69a575250661

        public static string api_pvp_net1 = ".api.pvp.net/api/lol/";
        //public static string api_key = "?api_key=76f850ea-d3b4-436e-a2cc-69a575250661";
        public static string summer_by_name1 = "v1.4/summoner/by-name/";

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = " ";
            Label3.Text = " ";
            
        }

        public void SampleRequest()
        {
            string data = "";
            WebRequest req = WebRequest.Create("https://" + "na" + api_pvp_net + "na" + "/" + summer_by_name + summonerid + api_key);

            WebResponse res = req.GetResponse();
            Stream dataStream = res.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            data = reader.ReadToEnd();

            var json = new JavaScriptSerializer();
            mi = json.Deserialize<List<matchinfo>>(data);
            var datastring = data.Substring(data.IndexOf("[") + 1);
            datastring = datastring.Substring(0, datastring.LastIndexOf("]"));
            //var json = "[{'platformId':'NA1','matchId':1905603238,'champion':412,'queue':'RANKED_SOLO_5x5','season':'SEASON2015','timestamp':1438426074848,'lane':'BOTTOM','role':'DUO_SUPPORT'},{'platformId':'NA1','matchId':1905508957,'champion':74,'queue':'RANKED_SOLO_5x5','season':'SEASON2015','timestamp':1438423625359,'lane':'TOP','role':'SOLO'}]";
            mi = JsonConvert.DeserializeObject<List<matchinfo>>("[" + datastring + "]");
            res.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        public string APIrequest(string name)
        {
            string data = "";
            WebRequest req = WebRequest.Create("https://" + "na" + api_pvp_net1 + "na" + "/" + summer_by_name1 + name + api_key);

            WebResponse res = req.GetResponse();
            Stream dataStream = res.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            data = reader.ReadToEnd();

            res.Close();
            return data;


            //http://stackoverflow.com/questions/22922881/json-with-dynamic-root-object
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                string data = APIrequest(txtusername.Text);
                var obj = JObject.Parse(data);
                if (obj != null)
                {
                    var root = obj.First;
                    if (root != null)
                    {
                        var sumJson = root.First;
                        if (sumJson != null)
                        {
                            var ro = sumJson.ToObject<SummonerInfo>();
                            summonerid = ro.id.ToString();
                        }
                    }
                }

                Label1.Text = " ";

                SqlDataReader sdr;
                SampleRequest();
                foreach (matchinfo mi1 in mi)
                {
                    sdr = dbmt.returnChampName(mi1.champion.ToString());
                    while (sdr.Read())
                    {
                        Label1.Text += sdr["ChampionName"].ToString() + "<br/><br/>";
                    }
                    sdr.Close();
                }
            }
            catch (WebException wex)
            {
                MessageBox.Show("Username not found: " + wex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int methodreturningagg(int number)
        {
            foreach (matchinfo mi1 in mi)
            {
                number++;
            }
            return number;
        }
    }

    public class matchinfo
    {
        public matchinfo()
        {

        }

        public string platformId { get; set; }
        public string matchId { get; set; }
        public string champion { get; set; }
        public string queue { get; set; }
        public string season { get; set; }
        public string timestamp { get; set; }
        public string lane { get; set; }
        public string role { get; set; }
    }

    public class Record
    {
        public matchinfo record;
    }

    public class SummonerInfo
    {
        public SummonerInfo()
        {

        }

        public string id { get; set; }
        public string name { get; set; }
        public string profileIconId { get; set; }
        public string summonerLevel { get; set; }
        public string revisionDate { get; set; }
    }
}