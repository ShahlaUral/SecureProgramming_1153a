using CampusDocs.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;


namespace CampusDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(SourceDocuments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDocumentById(int id)
        {
            Documents? doc = SourceDocuments.FirstOrDefault(w => w.Id == id);
            if (doc is null)
                return NotFound();

            return Ok(doc);

        }

        [HttpPost]
        public IActionResult CreateDocument(Documents doc)
        {
            doc.Id = SourceDocuments.Max(x => x.Id) + 1;
            doc.CreatedAt = DateTime.UtcNow;



            SourceDocuments.Add(doc);
            return CreatedAtAction(nameof(GetDocumentById), new { id = doc.Id }, doc);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(int id)
        {

            var doc = SourceDocuments.FirstOrDefault(f => f.Id == id);
            if (doc is null)
                return NotFound();

            SourceDocuments.Remove(doc);

            return NoContent();
        }

        [HttpGet("owner/{ownerId}")]
        public IActionResult GetDocumentsByOwnerId(int ownerId)
        {
            var doc = SourceDocuments.Where(w => w.OwnerId == ownerId).ToList();

            if (doc is null)
                return NotFound();

            return Ok(doc);

        }





        private static readonly List<Documents> SourceDocuments =
[
    new Documents
    {
        Id = 1,
        Title = "Secure Programming - Lecture 1",
        Content = "Introduction to secure programming and Secure SDLC.",
        OwnerId = 1,
        CreatedAt = DateTime.UtcNow
    },
    new Documents
    {
        Id = 2,
        Title = "Database Security Notes",
        Content = "Introduction to database security concepts.",
        OwnerId = 1,
        CreatedAt = DateTime.UtcNow
    },
    new Documents
    {
        Id = 3,
        Title = "System Programming Notes",
        Content = "Linux, kernel and system call introduction.",
        OwnerId = 2,
        CreatedAt = DateTime.UtcNow
    },
    new Documents
    {
        Id = 4,
        Title = "Project Requirements",
        Content = "Initial requirements for the CampusDocs project.",
        OwnerId = 2,
        CreatedAt = DateTime.UtcNow
    },
    new Documents
    {
        Id = 5,
        Title = "Meeting Notes",
        Content = "Notes from the weekly project meeting.",
        OwnerId = 3,
        CreatedAt = DateTime.UtcNow
    }
];
    }
}
