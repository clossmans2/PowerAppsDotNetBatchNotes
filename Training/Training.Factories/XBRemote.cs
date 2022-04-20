using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Factories
{
    public class XBRemote : Remote
    {
        private readonly string _remoteType;
        private string _company;

        public XBRemote(bool wired, bool batteries, string company)
        {
            _remoteType = "XBOX";
            _company = company;
            this.Wire = wired ? new XBWire() : null;
            this.Batteries = batteries ? new XBBatteries() : null;
        }

        public override string RemoteType => _remoteType;

        public override string Company { get => _company; set => _company = value; }
    }
}
