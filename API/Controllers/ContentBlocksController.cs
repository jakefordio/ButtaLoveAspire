using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContentBlocksController(ButtaLoveDbContext db) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ContentBlock>> Create(CreateContentBlockDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var name = User.FindFirstValue("name");

            if (userId is null || name is null)
            {
                return BadRequest("Failed to get user details");
            }

            var contentBlock = new ContentBlock
            {
                Title = dto.Title,
                Type = dto.Type,
                HtmlContent = dto.HtmlContent,
                OrderOnPage = dto.OrderOnPage,
                CreatedAt = dto.CreatedAt,
                PageId = dto.PageId,
                AuthorId = dto.AuthorId
            };

            await db.ContentBlocks.AddAsync(contentBlock);
            await db.SaveChangesAsync();
            return Created($"/contentblocks/{contentBlock.Id}", contentBlock);
        }

        [HttpGet("{pageId}")]
        public async Task<ActionResult<IEnumerable<ContentBlock>>> RetrieveAll(int? pageId = null)
        {
            List<ContentBlock> contentBlocks = [];
            if (pageId is not null) //get contentblocks for this page
            {
                contentBlocks = await db.ContentBlocks.Where(cb => cb.PageId == pageId).Select(cb => new ContentBlock()
                {
                    Id = cb.PageId,
                    Title = cb.Title,
                    Type = cb.Type,
                    HtmlContent = cb.HtmlContent,
                    OrderOnPage = cb.OrderOnPage,
                    CreatedAt = cb.CreatedAt,
                    UpdatedAt = cb.UpdatedAt,
                    PageId = cb.PageId,
                    AuthorId = cb.AuthorId
                }).OrderBy(cb => cb.OrderOnPage).ToListAsync();
            }
            else //get all contentblocks
            {
                contentBlocks = await db.ContentBlocks.ToListAsync();
            }
            return Ok(contentBlocks);
        }

        [HttpGet($"{{id}}")]
        public async Task<ActionResult<ContentBlock?>> Retrieve(int id = 0)
        {
            ContentBlock? contentBlock = null;
            if (id > 0)
            {
                contentBlock = await db.ContentBlocks.Where(cb => cb.Id == id).Select(cb => new ContentBlock()
                {
                    Id = cb.PageId,
                    Title = cb.Title,
                    Type = cb.Type,
                    HtmlContent = cb.HtmlContent,
                    OrderOnPage = cb.OrderOnPage,
                    CreatedAt = cb.CreatedAt,
                    UpdatedAt = cb.UpdatedAt,
                    PageId = cb.PageId,
                    AuthorId = cb.AuthorId
                }).FirstOrDefaultAsync();
                return Ok(contentBlock);
            }
            return NotFound(contentBlock);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateContentBlockDto dto)
        {
            ContentBlock? contentBlock = await db.ContentBlocks.FindAsync(id);
            if (contentBlock is null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != contentBlock.AuthorId)
                return Forbid();

            contentBlock.Title = dto.Title;
            contentBlock.Type = dto.Type;
            contentBlock.HtmlContent = dto.HtmlContent;
            contentBlock.OrderOnPage = dto.OrderOnPage;
            contentBlock.UpdatedAt = DateTime.Now;
            contentBlock.PageId = dto.PageId;
            contentBlock.AuthorId = dto.AuthorId;

            await db.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            ContentBlock? contentBlock = await db.ContentBlocks.FindAsync(id);
            if (contentBlock is null)
                return NotFound();

            string? appUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (appUserId != contentBlock.AuthorId)
                return Forbid();

            db.ContentBlocks.Remove(contentBlock);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
