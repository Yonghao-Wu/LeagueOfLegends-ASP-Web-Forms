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

namespace RiotAPIforLOL
{
    public partial class Test : System.Web.UI.Page
    {
        public static string api_pvp_net = ".api.pvp.net/api/lol/";
        public static string api_key = "?rankedQueues=RANKED_SOLO_5x5&api_key=76f850ea-d3b4-436e-a2cc-69a575250661";
        public static string summer_by_name = "v2.2/matchlist/by-summoner/";
        public static string summonerid = "49169861";
        public static List<matchinfo1> mi = new List<matchinfo1>();
        public List<Record> r = new List<Record>();

        //https://na.api.pvp.net/api/lol/na/v2.2/matchlist/by-summoner/49169861?rankedQueues=RANKED_SOLO_5x5&api_key=76f850ea-d3b4-436e-a2cc-69a575250661

        protected void Page_Load(object sender, EventArgs e)
        {
            SampleRequest();
            foreach (matchinfo1 mi1 in mi)
            {
                Label1.Text += mi1.champion + " ";
            }
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
            mi = json.Deserialize<List<matchinfo1>>(data);
            var datastring = data.Substring(data.IndexOf("[") + 1);
            datastring = datastring.Substring(0, datastring.LastIndexOf("]"));
            //var json = "[{'platformId':'NA1','matchId':1905603238,'champion':412,'queue':'RANKED_SOLO_5x5','season':'SEASON2015','timestamp':1438426074848,'lane':'BOTTOM','role':'DUO_SUPPORT'},{'platformId':'NA1','matchId':1905508957,'champion':74,'queue':'RANKED_SOLO_5x5','season':'SEASON2015','timestamp':1438423625359,'lane':'TOP','role':'SOLO'}]";
            mi = JsonConvert.DeserializeObject<List<matchinfo1>>("["+datastring+"]");
            res.Close();
        }
    }

    public class matchinfo1
    {
        public matchinfo1()
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

    public class Record1
    {
        public matchinfo record;
    }
}