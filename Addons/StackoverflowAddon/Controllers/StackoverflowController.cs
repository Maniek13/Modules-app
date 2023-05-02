using StackoverflowAddon.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Json;

namespace StackoverflowAddon.Controllers
{
    internal class StackoverflowController
    {
        protected static ObservableCollection<Topic> _topics = new ObservableCollection<Topic>();
        internal ObservableCollection<Topic> Topic => _topics;

        internal async Task<ObservableCollection<Topic>> GetPopularity(int nrOf)
        {
            List<Topic> list = new List<Topic>();
            string page = "https://api.stackexchange.com/2.3/tags";
            _topics.Clear();

            try
            {
                using (HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })
                {
                    using (HttpClient client = new HttpClient(handler))
                    {
                        int id = 1;
                        bool end = false;
                        while (end == false)
                        {
                            string urlParameters = $"?page={id}&pagesize=100&order=desc&sort=popular&site=stackoverflow";
                            Uri url = new Uri(page + urlParameters);


                            Response<Topic> res = await client.GetFromJsonAsync<Response<Topic>>(url);
                            foreach (Topic item in res.Items)
                            {
                                if (list.Count == nrOf)
                                {
                                    end = true;
                                    break;
                                }

                                list.Add(item);
                            }
                        }
                    }
                    
                    
                    foreach (Topic item in list)
                    {
                        _topics.Add(item);
                    }

                    return _topics;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
