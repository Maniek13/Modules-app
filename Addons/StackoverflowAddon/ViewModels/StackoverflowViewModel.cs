using StackoverflowAddon.Controllers;
using StackoverflowAddon.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http.Json;

namespace StackoverflowAddon.ViewModels
{
    public class StackoverflowViewModel
    {
        public ObservableCollection<Topic> Topics => _topics;

        private ObservableCollection<Topic> _topics;
        private readonly StackoverflowController _stackoverflowController;

        public StackoverflowViewModel()
        {
            _stackoverflowController = new StackoverflowController();
            _topics = _stackoverflowController.Topic;
        }

        public async Task GetTopicsPopularity(int nrOf)
        {
            if (nrOf <= 0)
                throw new ArgumentOutOfRangeException(nameof(nrOf));

            try
            {
                _topics = await _stackoverflowController.GetPopularity(nrOf);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
