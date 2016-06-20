using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Hni.Debugging.Data.Capture.Models
{
    public partial class HniDiagnosticEntities
    {
        public HniDiagnosticEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}