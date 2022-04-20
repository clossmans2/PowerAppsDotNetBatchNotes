using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class PlaystationRemote : Remote
    {
        private readonly string _remoteType;
        private string _company;

        public PlaystationRemote(bool wired, bool batteries, string company)
        {
            _remoteType = "Playstation";
            _company = company;
            this.Wire = wired ? new PSWire() : null;
            this.Batteries = batteries ? new PSBatteries() : null;
        }

        public override string RemoteType
        {
            get { return _remoteType; }
        }

        public override string Company
        {
            get { return _company; }
            set { _company = value; }
        }

    }
}
