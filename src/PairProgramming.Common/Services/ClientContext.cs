using System;
using PairProgramming.Common.Models;

namespace PairProgramming.Common.Services
{
    public class ClientContext : IClientContext
    {
        private ClientDetails details;

        public ClientDetails Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (this.details != null)
                {
                    throw new InvalidOperationException("Client details have already been set");
                }

                this.details = value;
            }
        }
    }
}
