using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Hni.Debugging.Data.Capture.Models;
using HNI.Environment;

namespace Hni.Debugging.Data.Capture.Controllers
{
    public class DiagnosticsController : ApiController
    {
        private HniDiagnosticEntities db = new HniDiagnosticEntities(ConfigurationUtil.GetDeploymentValue("HniDiagnosticEntities"));

        // GET: api/Diagnostics
        //public IQueryable<Diagnostic> GetDiagnostics()
        //{
        //    return db.Diagnostics;
        //}

        // GET: api/Diagnostics/5
        //[ResponseType(typeof(Diagnostic))]
        //public IHttpActionResult GetDiagnostic(long id)
        //{
        //    Diagnostic diagnostic = db.Diagnostics.Find(id);
        //    if (diagnostic == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(diagnostic);
        //}

        // PUT: api/Diagnostics/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDiagnostic(long id, Diagnostic diagnostic)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != diagnostic.DiagnosticID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(diagnostic).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DiagnosticExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Diagnostics
        [ResponseType(typeof(Diagnostic))]
        public IHttpActionResult PostDiagnostic(Diagnostic diagnostic)
        {
            if (diagnostic.DiagnosticSource == null)
            {
                diagnostic.DiagnosticSource = "The source didn't identified itself.";
            }

            if (diagnostic.DiagnosticData == null)
            {
                diagnostic.DiagnosticData = "No diagnostic data was sent by the source.";
            }

            if(diagnostic.DiagnosticDateTime == null)
            {
                diagnostic.DiagnosticDateTime = System.DateTime.Now;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Diagnostics.Add(diagnostic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = diagnostic.DiagnosticID }, diagnostic);
        }

        //// DELETE: api/Diagnostics/5
        //[ResponseType(typeof(Diagnostic))]
        //public IHttpActionResult DeleteDiagnostic(long id)
        //{
        //    Diagnostic diagnostic = db.Diagnostics.Find(id);
        //    if (diagnostic == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Diagnostics.Remove(diagnostic);
        //    db.SaveChanges();

        //    return Ok(diagnostic);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool DiagnosticExists(long id)
        //{
        //    return db.Diagnostics.Count(e => e.DiagnosticID == id) > 0;
        //}
    }
}