﻿using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> booths;

        public BoothRepository()
        {
            booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => booths.AsReadOnly();

        public void AddModel(IBooth model)
        {
            booths.Add(model);
        }
    }
}
